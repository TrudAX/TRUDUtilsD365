
## Project Overview

TRUDUtilsD365 is a Visual Studio 2022 Developer Tools Add-in for D365 Finance & Operations X++ development. It provides context-menu tools in the VS designer for code generation and cross-reference analysis.

## Extension Folder

`C:\Program Files\Microsoft Visual Studio\2022\Professional\Common7\IDE\Extensions\s3rpjihy.vwj`

The project references DLLs from this directory via `$(DynamicsVSToolsHintPath)`. Use `ilspycmd` (already installed) to decompile DLLs when API docs are needed. Save decompiled output to `C:\AAA\GitHub\TRUDUtilsD365\Tools\`.

## Add-in Architecture

Each add-in follows a pattern in its own folder under `TRUDUtilsD365\`:

1. **Menu.cs** - MEF entry point: `[Export(typeof(IDesignerMenu))]` + `[DesignerMenuExportMetadata(AutomationNodeType = typeof(TargetType))]`, inherits `DesignerMenuBase`
2. **Parms.cs** - Data model and UI-facing logic with `InitFromSelectedElement(AddinDesignerEventArgs e)`
3. **Dialog.cs + Designer.cs** - WinForms UI with `SetParameters(Parms)`
4. **Service.cs** *(optional)* - D365 API interactions separated from UI logic (e.g., `CrossReferenceService.cs`)

### ShowCrossReference Add-in (extended pattern)

The cross-reference viewer uses a 5-file pattern with clear separation:

| File | Responsibility |
|------|---------------|
| `ShowCrossReferenceMenu.cs` | MEF entry point, targets multiple element types (tables, classes, forms, views, data entities, enums, methods, fields) |
| `ShowCrossReferenceParms.cs` | Data models (`CrossReferenceEntry`, `SortableBindingList<T>`), filtering, sorting, access type detection, element-to-targetPath mapping |
| `CrossReferenceService.cs` | All D365 API calls: XRef queries (`LoadCrossReferences(targetPath)`), source text extraction, VS editor navigation |
| `ShowCrossReferenceDialog.cs` | WinForms event handlers, layout management |
| `ShowCrossReferenceDialog.Designer.cs` | WinForms designer-generated controls |

Example: `AddTableFindMethod\AddTableFindMethodMenu.cs` (simple 3-file pattern)

## Key Services

- `AxServiceProvider.GetService<T>()` - service locator (used for DTE, IDesignMetaModelService)
- `DesignMetaModelService.Instance` - singleton for metadata access
- `DesignMetaModelService.Instance.CrossReferenceProvider` - cross-reference queries
- `DesignMetaModelService.Instance.CurrentMetadataProvider` - read metadata elements
- `MetaModelUtility.GetXppSourceText(IRootNamedObject)` - extract X++ source code
- `AxServiceProvider.GetService<IMetadataInfoProvider>().GetXppSourceFilePath(xmlFilePath)` - convert XML path to XPP source path (replaces deprecated `MetaModelUtility.GetXppSourceFilePath`)
- `CoreUtility.HandleExceptionWithErrorMessage(ex)` - standard error handling

## Known D365 XRef Quirks

- **XRef reports entities/views as Tables**: `CrossReferenceProvider.FindReferences` returns `SourcePath` like `/Tables/EntityName/...` even for DataEntityViews and Views. When `Tables.Read()` returns null, fall back to `DataEntityViews.Read()` then `Views.Read()`. The `CrossReferenceService.ResolveActualElementType` method handles this and caches results.

- **Standard X++ References uses hierarchical matching**: The standard X++ References panel does prefix/hierarchical queries — e.g. references to `/Classes/MyClass` also include references to `/Classes/MyClass/Methods/*`. Our `FindReferences` call uses exact target path matching, so it returns fewer results (only direct references to the element, not its children).

## Cross-Reference Target Path Format

`FindReferences(sourcePath, targetPath, CrossReferenceKind)` — `sourcePath` empty = find all references TO target.

| Element | targetPath |
|---------|-----------|
| Table | `/Tables/{Name}` |
| Table field | `/Tables/{TableName}/Fields/{FieldName}` |
| Table extension | `/TableExtensions/{Name}` |
| Class | `/Classes/{Name}` |
| Class method | `/Classes/{Name}/Methods/{MethodName}` |
| Form | `/Forms/{Name}` |
| View | `/Views/{Name}` |
| Data entity | `/DataEntityViews/{Name}` |
| Data entity field | `/DataEntityViews/{Name}/Fields/{FieldName}` |
| Enum | `/Enums/{Name}` |

## Supported Automation Types for Designer Menus

Key types from `Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.*`:

| Namespace | Types |
|-----------|-------|
| `.Tables` | `BaseField`, `ITable`, `Table`, `ITableExtension`, `TableExtension` |
| `.Classes` | `ClassItem` |
| `.Forms` | `IForm`, `FormExtension`, `FormDataSource`, `FormDataSourceField`, `FormControl` |
| `.Views` | `IView`, `IViewField`, `View`, `ViewExtension` |
| `.DataEntityViews` | `IDataEntity`, `IDataEntityView`, `DataEntityView`, `DataEntityViewExtension`, `IDataEntityViewField` |
| `.BaseTypes` | `IBaseEnum`, `EdtString` |
| `.Menus` | `IMenuItem`, `IMenu` |
| `.Security` | `ISecurityDuty`, `ISecurityRole` |
| *(base)* | `IMethodBase`, `NamedElement`, `IRootElement` |

Use `((NamedElement)element).RootElement` to get the parent element from a method or field. `IRootElement.GetMetadataType().Name` returns the metadata element name.

## API Documentation

See `Tools\documentation.md` for detailed decompiled API signatures and usage patterns.

## Build

MSBuild with .NET Framework 4.8. Post-build copies output to `AddinExtensions\`. Always use `-p:BuildingInsideVisualStudio=true` to trigger the copy step (it is conditioned on this property):

```
"/c/Program Files/Microsoft Visual Studio/2022/Professional/MSBuild/Current/Bin/MSBuild.exe" "TRUDUtilsD365.sln" -p:Configuration=Debug -p:BuildingInsideVisualStudio=true -verbosity:minimal
```
