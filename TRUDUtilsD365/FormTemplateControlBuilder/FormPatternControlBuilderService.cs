using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Dynamics.AX.Metadata.MetaModel;
using Microsoft.Dynamics.AX.Metadata.Patterns;

namespace TRUDUtilsD365.FormTemplateControlBuilder
{
    /// <summary>
    /// Headless engine that adds the controls a form pattern (template) requires to a form design.
    ///
    /// It walks the pattern's <see cref="PatternNode"/> tree (see documentation 11.6/11.7), creates the minimal
    /// set of <b>required</b> controls (RequireOne) - one instance per node - and finally stamps the pattern with
    /// the standard "Apply Pattern" engine (<see cref="Extensions.ApplyPattern(IPatternable, Pattern)"/>), which
    /// sets Pattern/PatternVersion and every pattern-mandated layout property on the design and its new children.
    ///
    /// Embedded sub-patterns ARE expanded: when a node references one or more sub-patterns the container control is
    /// created, a sub-pattern is chosen for it (preferring FieldsFieldGroups), the controls THAT sub-pattern
    /// requires are created inside it - recursively, so nested sub-patterns are expanded too - and the sub-pattern
    /// is stamped on the container. The outer pattern still matches because the analyzer treats a node carrying
    /// sub-patterns as opaque (it only checks the container's stamped Pattern is one of the node's sub-patterns).
    /// A depth cap guards against pathologically deep / self-referential pattern definitions.
    /// </summary>
    public class FormPatternControlBuilderService
    {
        // Safety net against a self-referential / pathologically deep pattern definition.
        private const int MaxDepth = 20;

        // A quick filter is a Custom control carrying the "QuickFilterControl" extension (documentation 11.7).
        private const string QuickFilterControlType = "QuickFilterControl";

        // Generic "Fields and field groups" sub-pattern - applies to an empty container, matching the form
        // designer default for detail tab pages / header groups.
        private const string PreferredSubPattern = "FieldsFieldGroups";

        // Standard patterns are embedded resources in Microsoft.Dynamics.AX.Metadata.Patterns.dll and cached
        // statically inside PatternFactory, so a single shared instance is enough and always matches the platform.
        private static readonly PatternFactory PatternCatalog = new PatternFactory();

        // Pattern node Type string -> concrete metadata control class.
        private static readonly Dictionary<string, Type> ControlTypeMap = new Dictionary<string, Type>(StringComparer.Ordinal)
        {
            { "ActionPane",         typeof(AxFormActionPaneControl) },
            { "ActionPaneTab",      typeof(AxFormActionPaneTabControl) },
            { "Group",              typeof(AxFormGroupControl) },
            { "Grid",               typeof(AxFormGridControl) },
            { "Tab",                typeof(AxFormTabControl) },
            { "TabPage",            typeof(AxFormTabPageControl) },
            { "Tree",               typeof(AxFormTreeControl) },
            { "Table",              typeof(AxFormTableControl) },
            { "ListView",           typeof(AxFormListViewControl) },
            { "ListBox",            typeof(AxFormListBoxControl) },
            { "ButtonGroup",        typeof(AxFormButtonGroupControl) },
            { "CommandButton",      typeof(AxFormCommandButtonControl) },
            { "Button",             typeof(AxFormButtonControl) },
            { "MenuButton",         typeof(AxFormMenuButtonControl) },
            { "MenuFunctionButton", typeof(AxFormMenuFunctionButtonControl) },
            { "DropDialogButton",   typeof(AxFormDropDialogButtonControl) },
            { "ButtonSeparator",    typeof(AxFormButtonSeparatorControl) },
            { "String",             typeof(AxFormStringControl) },
            { "Integer",            typeof(AxFormIntegerControl) },
            { "Int64",              typeof(AxFormInt64Control) },
            { "Real",               typeof(AxFormRealControl) },
            { "Date",               typeof(AxFormDateControl) },
            { "Time",               typeof(AxFormTimeControl) },
            { "DateTime",           typeof(AxFormDateTimeControl) },
            { "ComboBox",           typeof(AxFormComboBoxControl) },
            { "CheckBox",           typeof(AxFormCheckBoxControl) },
            { "RadioButton",        typeof(AxFormRadioButtonControl) },
            { "ReferenceGroup",     typeof(AxFormReferenceGroupControl) },
            { "SegmentedEntry",     typeof(AxFormSegmentedEntryControl) },
            { "Guid",               typeof(AxFormGuidControl) },
            { "StaticText",         typeof(AxFormStaticTextControl) },
            { "Image",              typeof(AxFormImageControl) },
            { "HTML",               typeof(AxFormHTMLControl) },
        };

        // Pattern meta-aliases ($Field, $List, ...) -> a sensible concrete control type (documentation 11.7).
        private static readonly Dictionary<string, string> AliasDefault = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            { "$Field",             "String" },
            { "$List",              "Grid" },
            { "$Container",         "Group" },
            { "$Button",            "CommandButton" },
            { "$Any",               "Group" },
            { "$ContainerOrDesign", "Group" },
        };

        private readonly StringBuilder _log = new StringBuilder();
        private readonly HashSet<string> _usedNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        private readonly Dictionary<string, int> _nameCounters = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        private readonly bool _includeOptional;

        /// <param name="includeOptionalControls">
        /// When true (default), optional nodes (<c>!RequireOne</c>) are created as well as required ones; when
        /// false only the minimal required set is created.
        /// </param>
        public FormPatternControlBuilderService(bool includeOptionalControls = true)
        {
            _includeOptional = includeOptionalControls;
        }

        /// <summary>Human-readable tree of the controls that were created.</summary>
        public string Log => _log.ToString();

        /// <summary>Number of controls created.</summary>
        public int ControlsCreated { get; private set; }

        /// <summary>
        /// Resolve a pattern by the name (and optional version) assigned to a form design. Prefers the exact
        /// assigned version, then the active version, then any version.
        /// </summary>
        public static Pattern ResolvePattern(string name, string version)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }

            Pattern pattern = null;
            if (!string.IsNullOrEmpty(version))
            {
                pattern = PatternCatalog.GetPatternByName(name, version, false);
            }

            if (pattern == null)
            {
                List<Pattern> all = PatternCatalog.GetPatternsByName(name, false);
                pattern = all.FirstOrDefault(p => p.Active) ?? all.FirstOrDefault();
            }

            return pattern;
        }

        /// <summary>
        /// Create the required controls for <paramref name="pattern"/> on <paramref name="design"/> and stamp the
        /// pattern. Throws (leaving the form unsaved by the caller) if the generated structure cannot be stamped.
        /// </summary>
        public void BuildControls(AxFormDesign design, Pattern pattern)
        {
            if (design == null)
            {
                throw new ArgumentNullException(nameof(design));
            }
            if (pattern == null)
            {
                throw new ArgumentNullException(nameof(pattern));
            }

            BuildChildren(design, pattern.Root, 0);

            // All-or-nothing: this only succeeds if the built structure matches the pattern. It sets the design
            // Pattern/PatternVersion and every pattern-mandated property on the design and all created descendants.
            if (!((IPatternable)design).ApplyPattern(pattern))
            {
                throw new Exception(
                    $"The controls were created but the '{pattern.Name} {pattern.Version}' template could not be applied - " +
                    "the generated structure does not match the template, so no changes were saved.");
            }
        }

        private void BuildChildren(IFormControlCollection container, PatternNode node, int depth)
        {
            if (depth > MaxDepth)
            {
                return;
            }

            foreach (PatternNode child in node.SubNodes)
            {
                PatternNode effective = child;

                if (child.IsOneOf)
                {
                    // An alternatives wrapper - pick the first option (e.g. $List -> Grid). Skip it when it is
                    // optional and optional controls are not requested.
                    if (!child.RequireOne && !_includeOptional)
                    {
                        continue;
                    }
                    effective = child.SubNodes.FirstOrDefault();
                    if (effective == null)
                    {
                        continue;
                    }
                }
                else if (!child.RequireOne && !_includeOptional)
                {
                    // Optional node - excluded unless optional controls are requested.
                    continue;
                }

                AxFormControl control = CreateControl(effective);
                container.AddControl(control);
                ControlsCreated++;

                bool hasSubPattern = effective.SubPatterns != null && effective.SubPatterns.Any();
                if (hasSubPattern)
                {
                    // Embedded template: create the container, expand the controls the sub-pattern requires, stamp it.
                    BuildFromSubPattern(control, effective, depth);
                }
                else
                {
                    AppendLog(depth, control, effective, null);
                    // ChildrenUnconstrained ("Children=*") nodes allow any children and mandate none - stop there.
                    if (!effective.ChildrenUnconstrained && control is IFormControlCollection childContainer)
                    {
                        BuildChildren(childContainer, effective, depth + 1);
                    }
                }
            }
        }

        private AxFormControl CreateControl(PatternNode node)
        {
            AxFormControl control;
            string type = node.Type ?? string.Empty;

            if (type == QuickFilterControlType)
            {
                control = new AxFormControl
                {
                    FormControlExtension = new AxFormControlExtension { Name = QuickFilterControlType }
                };
            }
            else
            {
                string concrete = AliasDefault.ContainsKey(type) ? AliasDefault[type] : type;
                if (!ControlTypeMap.TryGetValue(concrete, out Type clrType))
                {
                    throw new Exception(
                        $"Template node '{(string.IsNullOrEmpty(node.Part) ? type : node.Part)}' requires a control of type " +
                        $"'{type}' that this tool does not know how to create.");
                }
                control = (AxFormControl)Activator.CreateInstance(clrType);
            }

            control.Name = MakeUniqueName(string.IsNullOrEmpty(node.Part) ? NameBaseForType(type) : node.Part);
            return control;
        }

        private void BuildFromSubPattern(AxFormControl control, PatternNode node, int depth)
        {
            Pattern subPattern = ChooseSubPattern(node.SubPatterns);
            if (subPattern == null)
            {
                // Only "Custom" / unknown sub-patterns: nothing in the catalog to expand - leave for the developer.
                AppendLog(depth, control, node, "embedded template (apply pattern in designer)");
                return;
            }

            AppendLog(depth, control, node, "embedded: " + subPattern.Name + " " + subPattern.Version);

            // Create the controls the sub-pattern requires inside the container. The sub-pattern Root represents
            // the container itself, so its SubNodes are the children to add. Nested sub-patterns are expanded by
            // the same recursion (the depth cap protects against runaway definitions).
            if (control is IFormControlCollection childContainer)
            {
                BuildChildren(childContainer, subPattern.Root, depth + 1);
            }

            // Stamp the sub-pattern (version + its mandated layout properties). Children created above make the
            // container match it; if a definition still does not match we keep the controls but note it.
            if (!((IPatternable)control).ApplyPattern(subPattern))
            {
                AppendLog(depth + 1, control, node, $"could not stamp {subPattern.Name} - apply it in the designer");
            }
        }

        private Pattern ChooseSubPattern(IEnumerable<string> subPatterns)
        {
            // Prefer the generic "Fields and field groups" sub-pattern, then the declared order. Skip "Custom"
            // (the developer's own pattern; not in the catalog).
            List<string> ordered = subPatterns
                .Where(n => !string.IsNullOrEmpty(n) && !string.Equals(n, PatternFactory.CustomSubPatternName, StringComparison.Ordinal))
                .OrderByDescending(n => string.Equals(n, PreferredSubPattern, StringComparison.Ordinal))
                .ToList();

            foreach (string subPatternName in ordered)
            {
                Pattern subPattern = PatternCatalog.GetPatternsByName(subPatternName, false).FirstOrDefault(p => p.Active);
                if (subPattern != null)
                {
                    return subPattern;
                }
            }

            return null;
        }

        private static string NameBaseForType(string type)
        {
            if (string.IsNullOrEmpty(type))
            {
                return "Control";
            }
            if (type == QuickFilterControlType)
            {
                return "QuickFilter";
            }
            string concrete = AliasDefault.ContainsKey(type) ? AliasDefault[type] : type;
            return concrete.Replace("$", string.Empty);
        }

        private string MakeUniqueName(string baseName)
        {
            if (string.IsNullOrEmpty(baseName))
            {
                baseName = "Control";
            }
            if (_usedNames.Add(baseName))
            {
                return baseName;
            }

            int counter = _nameCounters.TryGetValue(baseName, out int existing) ? existing : 0;
            string candidate;
            do
            {
                counter++;
                candidate = baseName + counter;
            }
            while (!_usedNames.Add(candidate));

            _nameCounters[baseName] = counter;
            return candidate;
        }

        private void AppendLog(int depth, AxFormControl control, PatternNode node, string note)
        {
            _log.Append(new string(' ', depth * 2));
            _log.Append(control.Name);
            _log.Append(" [").Append(node.Type).Append("]");
            if (!string.IsNullOrEmpty(note))
            {
                _log.Append(" - ").Append(note);
            }
            _log.Append(Environment.NewLine);
        }
    }
}
