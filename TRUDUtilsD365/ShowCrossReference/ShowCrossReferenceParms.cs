using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.Dynamics.Framework.Tools.Extensibility;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Tables;

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
        public string TableName { get; set; }
        public string FieldName { get; set; }
        public bool IsTableExtension { get; set; }
        public string DisplayName => $"{TableName}.{FieldName}";
        public SortableBindingList<CrossReferenceEntry> References { get; set; }

        private readonly CrossReferenceService _service = new CrossReferenceService();
        private readonly List<CrossReferenceEntry> _allReferences = new List<CrossReferenceEntry>();

        public void Init(string tableName, string fieldName, bool isTableExtension = false)
        {
            TableName = tableName;
            FieldName = fieldName;
            IsTableExtension = isTableExtension;

            _allReferences.Clear();
            References = new SortableBindingList<CrossReferenceEntry>();

            var loaded = _service.LoadCrossReferences(TableName, FieldName, IsTableExtension);
            foreach (var entry in loaded)
            {
                entry.AccessType = DetermineAccessType(entry.CodeLine, FieldName);
            }
            _allReferences.AddRange(loaded);

            foreach (var entry in _allReferences)
                References.Add(entry);
        }

        public void InitFromSelectedElement(AddinDesignerEventArgs e)
        {
            var field = (BaseField)e.SelectedElement;

            string tableName;
            bool isExtension;

            if (field.Table != null)
            {
                tableName = field.Table.GetMetadataType().Name;
                isExtension = false;
            }
            else if (field.TableExtension != null)
            {
                tableName = field.TableExtension.GetMetadataType().Name;
                isExtension = true;
            }
            else
            {
                return;
            }

            Init(tableName, field.Name, isExtension);
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

        public static AccessType DetermineAccessType(string codeLine, string fieldName)
        {
            if (string.IsNullOrEmpty(codeLine))
                return AccessType.NotDefined;

            int fieldIdx = codeLine.IndexOf(fieldName, StringComparison.OrdinalIgnoreCase);
            if (fieldIdx < 0)
                return AccessType.NotDefined;

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
