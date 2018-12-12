using System;
using Microsoft.Dynamics.AX.Metadata.Core.MetaModel;
using TRUDUtilsD365.Kernel;
using Microsoft.Dynamics.AX.Metadata.MetaModel;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Classes;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Forms;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Reports;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Core;
using UtilElementType = Dynamics.AX.Application.UtilElementType;

namespace TRUDUtilsD365.MenuItemBuilder
{
    public class MenuItemBuilderParms
    {
        public string ObjectName { get; set; } = "";

        public string MenuItemName { get; set; } = "";

        public UtilElementType MenuItemType { get; set; } = UtilElementType.DisplayTool;

        public string FormLabel { get; set; } = "";
        public string FormHelp { get; set; } = "";

        private MenuItemObjectType ObjectTypeCaller;


        private AxHelper _axHelper;

        private string _logString;

        void AddLog(string logLocal)
        {
            _logString += logLocal;
        }

        public void DisplayLog()
        {
            CoreUtility.DisplayInfo($"The following elements({_logString}) were created and added to the project");
        }

        public void ValidateData()
        {
           if (string.IsNullOrWhiteSpace(ObjectName) || string.IsNullOrWhiteSpace(MenuItemName))
            {
                throw new Exception($"Object name should be specified");
            }
            
        }

        public void InitFromSelectedElement(object selectedElement)
        {
            if (selectedElement is IForm)
            {
                var form = selectedElement as IForm;
                ObjectName    = form.Name;
                FormLabel     = form.FormDesign.Caption;
                MenuItemType  = UtilElementType.DisplayTool;
                ObjectTypeCaller = MenuItemObjectType.Form;
            }
            if (selectedElement is ClassItem)
            {
                ClassItem form = selectedElement as ClassItem;

                ObjectName   = form.Name;
                //FormLabel    = form.FormDesign.Caption;//add description here
                MenuItemType = UtilElementType.ActionTool;
                ObjectTypeCaller = MenuItemObjectType.Class;
            }
            if (selectedElement is IReport)
            {
                IReport form = selectedElement as IReport;

                ObjectName = form.Name;
                //FormLabel    = form.FormDesign.Caption;
                MenuItemType = UtilElementType.OutputTool;
                ObjectTypeCaller = MenuItemObjectType.SSRSReport;
            }

            MenuItemName = ObjectName;
        }

        public void Run()
        {
            _logString = "";
            ValidateData();
            if (_axHelper == null)
            {
                _axHelper = new AxHelper();
            }

            DoMenuItemCreate();
            
        }

        void DoMenuItemCreate()
        {
            AxMenuItem axMenuItem;

            switch (MenuItemType)
            {
                case UtilElementType.DisplayTool:
                    axMenuItem = _axHelper.MetadataProvider.MenuItemDisplays.Read(MenuItemName);
                    if (axMenuItem != null)
                    {
                        throw new Exception($"MenuItem: {MenuItemName} already exists");
                    }
                    axMenuItem = new AxMenuItemDisplay { Name = MenuItemName, Object = ObjectName, Label = FormLabel, HelpText = FormHelp, ObjectType = ObjectTypeCaller };
                    _axHelper.MetaModelService.CreateMenuItemDisplay((AxMenuItemDisplay)axMenuItem, _axHelper.ModelSaveInfo);
                    break;

                case UtilElementType.OutputTool:
                    axMenuItem = _axHelper.MetadataProvider.MenuItemOutputs.Read(MenuItemName);
                    if (axMenuItem != null)
                    {
                        throw new Exception($"MenuItem: {MenuItemName} already exists");
                    }
                    axMenuItem = new AxMenuItemOutput { Name = MenuItemName, Object = ObjectName, Label = FormLabel, HelpText = FormHelp, ObjectType = ObjectTypeCaller };
                    _axHelper.MetaModelService.CreateMenuItemOutput((AxMenuItemOutput)axMenuItem, _axHelper.ModelSaveInfo);
                    break;

                case UtilElementType.ActionTool:
                    axMenuItem = _axHelper.MetadataProvider.MenuItemActions.Read(MenuItemName);
                    if (axMenuItem != null)
                    {
                        throw new Exception($"MenuItem: {MenuItemName} already exists");
                    }
                    axMenuItem = new AxMenuItemAction { Name = MenuItemName, Object = ObjectName, Label = FormLabel, HelpText = FormHelp, ObjectType = ObjectTypeCaller };
                    _axHelper.MetaModelService.CreateMenuItemAction((AxMenuItemAction)axMenuItem, _axHelper.ModelSaveInfo);                    
                    break;

                default:
                    throw new Exception("Element not supported");
            }
            _axHelper.AppendToActiveProject(axMenuItem);

            AddLog($"MenuItem: {axMenuItem.Name}; ");
        }

    }
}
