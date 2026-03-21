
## Project Overview

TRUDUtilsD365 is a Visual Studio 2022 VSIX add-in for D365 Finance & Operations X++ development. It provides context-menu tools in the VS designer for code generation and cross-reference analysis.

## Extension Folder

`C:\Program Files\Microsoft Visual Studio\2022\Professional\Common7\IDE\Extensions\s3rpjihy.vwj`

The project references DLLs from this directory via `$(DynamicsVSToolsHintPath)`. Use `ilspycmd` (already installed) to decompile DLLs when API docs are needed. Save decompiled output to `C:\AAA\GitHub\TRUDUtilsD365\Tools\`.

## Add-in Architecture

Each add-in follows a 3-file pattern in its own folder under `TRUDUtilsD365\`:

1. **Menu.cs** - MEF entry point: `[Export(typeof(IDesignerMenu))]` + `[DesignerMenuExportMetadata(AutomationNodeType = typeof(TargetType))]`, inherits `DesignerMenuBase`
2. **Parms.cs** - Business logic with `InitFromSelectedElement(AddinDesignerEventArgs e)`
3. **Dialog.cs + Designer.cs** - WinForms UI with `SetParameters(Parms)`

Example: `AddTableFindMethod\AddTableFindMethodMenu.cs`

## Key Services

- `AxServiceProvider.GetService<T>()` - service locator (used for DTE, IDesignMetaModelService)
- `DesignMetaModelService.Instance` - singleton for metadata access
- `DesignMetaModelService.Instance.CrossReferenceProvider` - cross-reference queries
- `DesignMetaModelService.Instance.CurrentMetadataProvider` - read metadata elements
- `MetaModelUtility.GetXppSourceText(IRootNamedObject)` - extract X++ source code
- `MetaModelUtility.GetXppSourceFilePath(xmlFilePath)` - convert XML path to XPP source path
- `CoreUtility.HandleExceptionWithErrorMessage(ex)` - standard error handling

## API Documentation

See `Tools\documentation.md` for detailed decompiled API signatures and usage patterns.

## Build

MSBuild with .NET Framework 4.8. Post-build copies output to `$(DynamicsVSToolsHintPath)\AddinExtensions\`.
