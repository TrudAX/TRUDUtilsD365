using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.Dynamics.Framework.Tools.Extensibility;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.BaseTypes;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Classes;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.DataEntityViews;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Forms;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Tables;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Views;

namespace TRUDUtilsD365.ShowCrossReference
{
    public enum AccessType
    {
        Read,
        Write,
        NotDefined
    }

    public class CrossReferenceEntry
    {
        public string SourcePath { get; set; }
        public string ElementType { get; set; }
        public string ElementName { get; set; }
        public string MethodName { get; set; }
        public string Kind { get; set; }
        public int LineNumber { get; set; }
        public int ColumnNumber { get; set; }
        public string SourceModule { get; set; }
        public string CodeLine { get; set; }
        public AccessType AccessType { get; set; }
    }

    public class SortableBindingList<T> : BindingList<T>
    {
        private bool _isSorted;
        private PropertyDescriptor _sortProperty;
        private ListSortDirection _sortDirection;

        public SortableBindingList() { }
        public SortableBindingList(IList<T> list) : base(list) { }

        protected override bool SupportsSortingCore => true;
        protected override bool IsSortedCore => _isSorted;
        protected override PropertyDescriptor SortPropertyCore => _sortProperty;
        protected override ListSortDirection SortDirectionCore => _sortDirection;

        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            var items = Items as List<T>;
            if (items != null)
            {
                items.Sort((x, y) =>
                {
                    object xVal = prop.GetValue(x);
                    object yVal = prop.GetValue(y);
                    if (xVal == null && yVal == null) return 0;
                    if (xVal == null) return -1;
                    if (yVal == null) return 1;
                    int result = xVal is IComparable comparable
                        ? comparable.CompareTo(yVal)
                        : string.Compare(xVal.ToString(), yVal.ToString(), StringComparison.OrdinalIgnoreCase);
                    return direction == ListSortDirection.Descending ? -result : result;
                });
            }
            _sortProperty = prop;
            _sortDirection = direction;
            _isSorted = true;
            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        protected override void RemoveSortCore()
        {
            _isSorted = false;
            _sortProperty = null;
        }
    }

    public class ShowCrossReferenceParms
    {
        public string TargetPath { get; set; }
        public string DisplayName { get; set; }
        public SortableBindingList<CrossReferenceEntry> References { get; set; }

        private readonly CrossReferenceService _service = new CrossReferenceService();
        private readonly List<CrossReferenceEntry> _allReferences = new List<CrossReferenceEntry>();

        public void Init(string targetPath)
        {
            TargetPath = targetPath;
            DisplayName = targetPath;

            _allReferences.Clear();
            References = new SortableBindingList<CrossReferenceEntry>();

            var loaded = _service.LoadCrossReferences(targetPath);

            // Extract field name from path for access type detection (only for field-level refs)
            string fieldName = null;
            int fieldsIdx = targetPath.IndexOf("/Fields/", StringComparison.OrdinalIgnoreCase);
            if (fieldsIdx >= 0)
            {
                fieldName = targetPath.Substring(fieldsIdx + "/Fields/".Length);
            }

            foreach (var entry in loaded)
            {
                entry.AccessType = fieldName != null
                    ? DetermineAccessType(entry.CodeLine, fieldName)
                    : AccessType.NotDefined;
            }
            _allReferences.AddRange(loaded);

            foreach (var entry in _allReferences)
                References.Add(entry);
        }

        /// <summary>Convenience overload for table field references.</summary>
        public void Init(string tableName, string fieldName, bool isTableExtension = false)
        {
            string pathPrefix = isTableExtension ? "TableExtensions" : "Tables";
            Init($"/{pathPrefix}/{tableName}/Fields/{fieldName}");
        }

        public void InitFromSelectedElement(AddinDesignerEventArgs e)
        {
            var element = e.SelectedElement;
            string targetPath = null;

            if (element is BaseField field)
            {
                string tableName = field.Table?.GetMetadataType().Name
                                ?? field.TableExtension?.GetMetadataType().Name;
                string prefix = field.Table != null ? "Tables" : "TableExtensions";
                targetPath = $"/{prefix}/{tableName}/Fields/{field.Name}";
            }
            else if (element is IDataEntityViewField || element is IViewField)
            {
                var rootElement = ((NamedElement)element).RootElement;
                if (rootElement != null)
                {
                    string rootName = rootElement.GetMetadataType().Name;
                    string rootType = GetXRefPathPrefix(rootElement);
                    targetPath = $"/{rootType}/{rootName}/Fields/{((NamedElement)element).Name}";
                }
            }
            else if (element is ITable table)
            {
                targetPath = $"/Tables/{((NamedElement)element).Name}";
            }
            else if (element is TableExtension tableExt)
            {
                targetPath = $"/TableExtensions/{((NamedElement)element).Name}";
            }
            else if (element is ClassItem classItem)
            {
                targetPath = $"/Classes/{((NamedElement)element).Name}";
            }
            else if (element is IForm form)
            {
                targetPath = $"/Forms/{((NamedElement)element).Name}";
            }
            else if (element is IView view)
            {
                targetPath = $"/Views/{((NamedElement)element).Name}";
            }
            else if (element is IDataEntity dataEntity)
            {
                targetPath = $"/DataEntityViews/{((NamedElement)element).Name}";
            }
            else if (element is DataEntityViewExtension dataEntityExt)
            {
                targetPath = $"/DataEntityViewExtensions/{((NamedElement)element).Name}";
            }
            else if (element is IBaseEnum baseEnum)
            {
                targetPath = $"/Enums/{((NamedElement)element).Name}";
            }
            else if (element is IMethodBase method)
            {
                var rootElement = ((NamedElement)element).RootElement;
                if (rootElement != null)
                {
                    string rootName = rootElement.GetMetadataType().Name;
                    string rootType = GetXRefPathPrefix(rootElement);
                    targetPath = $"/{rootType}/{rootName}/Methods/{((NamedElement)element).Name}";
                }
            }
            else if (element is NamedElement namedElement)
            {
                // Fallback for any other named element
                targetPath = $"/{namedElement.Name}";
            }

            if (targetPath != null)
                Init(targetPath);
        }

        public void ReloadCodeLines(int totalLines)
        {
            foreach (var entry in _allReferences)
            {
                entry.CodeLine = _service.ExtractCodeLine(entry, totalLines);
            }
            References.ResetBindings();
        }

        public void ApplyDefaultSort()
        {
            var sorted = References.OrderBy(r => r.ElementType)
                                   .ThenBy(r => r.ElementName)
                                   .ThenBy(r => r.MethodName)
                                   .ThenBy(r => r.LineNumber)
                                   .ThenBy(r => r.ColumnNumber)
                                   .ToList();
            References.RaiseListChangedEvents = false;
            References.Clear();
            foreach (var item in sorted)
                References.Add(item);
            References.RaiseListChangedEvents = true;
            References.ResetBindings();
        }

        public List<string> GetDistinctModules()
        {
            return _allReferences.Select(r => r.SourceModule ?? "")
                                 .Where(m => !string.IsNullOrEmpty(m))
                                 .Distinct()
                                 .OrderBy(m => m)
                                 .ToList();
        }

        public void ApplyFilters(string moduleFilter, string accessFilter)
        {
            IEnumerable<CrossReferenceEntry> filtered = _allReferences;

            if (!string.IsNullOrEmpty(moduleFilter) && moduleFilter != "All")
            {
                filtered = filtered.Where(r => string.Equals(r.SourceModule, moduleFilter, StringComparison.OrdinalIgnoreCase));
            }

            if (accessFilter == "Read")
            {
                filtered = filtered.Where(r => r.AccessType == AccessType.Read || r.AccessType == AccessType.NotDefined);
            }
            else if (accessFilter == "Write")
            {
                filtered = filtered.Where(r => r.AccessType == AccessType.Write || r.AccessType == AccessType.NotDefined);
            }

            References.RaiseListChangedEvents = false;
            References.Clear();
            foreach (var entry in filtered)
                References.Add(entry);
            References.RaiseListChangedEvents = true;
            References.ResetBindings();
        }

        public void NavigateToSource(CrossReferenceEntry entry)
        {
            _service.NavigateToSource(entry);
        }

        private static string GetXRefPathPrefix(IRootElement rootElement)
        {
            if (rootElement is ClassItem) return "Classes";
            if (rootElement is ITable) return "Tables";
            if (rootElement is TableExtension) return "TableExtensions";
            if (rootElement is IForm) return "Forms";
            if (rootElement is IView) return "Views";
            if (rootElement is IDataEntity) return "DataEntityViews";
            if (rootElement is DataEntityViewExtension) return "DataEntityViewExtensions";
            return "Classes"; // default fallback
        }

        public static AccessType DetermineAccessType(string codeLine, string fieldName)
        {
            if (string.IsNullOrEmpty(codeLine))
                return AccessType.NotDefined;

            int fieldIdx = codeLine.IndexOf(fieldName, StringComparison.OrdinalIgnoreCase);
            if (fieldIdx < 0)
                return AccessType.NotDefined;

            // setField(fieldNum(Table, Field) — field inside the first fieldNum is Write
            string setFieldPattern = ".setField(fieldNum(";
            int setFieldIdx = codeLine.IndexOf(setFieldPattern, StringComparison.OrdinalIgnoreCase);
            if (setFieldIdx >= 0)
            {
                int argsStart = setFieldIdx + setFieldPattern.Length;
                int argsEnd = codeLine.IndexOf(')', argsStart);
                if (argsEnd > 0 && fieldIdx >= argsStart && fieldIdx < argsEnd)
                    return AccessType.Write;
            }

            int equalIdx = codeLine.IndexOf('=');
            if (equalIdx < 0)
                return AccessType.Read;

            // Skip comparison/compound operators: ==, !=, >=, <=, +=, -=
            if (equalIdx + 1 < codeLine.Length && codeLine[equalIdx + 1] == '=')
                return AccessType.Read;
            if (equalIdx > 0 && (codeLine[equalIdx - 1] == '!' ||
                                  codeLine[equalIdx - 1] == '>' ||
                                  codeLine[equalIdx - 1] == '<'))
                return AccessType.Read;

            // += and -= on the field is still a write
            if (equalIdx > 0 && (codeLine[equalIdx - 1] == '+' || codeLine[equalIdx - 1] == '-'))
            {
                if (fieldIdx < equalIdx - 1)
                    return AccessType.Write;
                return AccessType.Read;
            }

            if (fieldIdx < equalIdx)
                return AccessType.Write;

            return AccessType.Read;
        }
    }
}
