using System;
using Microsoft.Dynamics.AX.Metadata.Core.MetaModel;
using TRUDUtilsD365.Kernel;
using Microsoft.Dynamics.AX.Metadata.MetaModel;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Menus;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Core;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.DataEntityViews;

namespace TRUDUtilsD365.SecurityPrivilegeBuilder
{
    public enum PrivilegeAccessLevel
    {
        Read,
        Update,
        Create,
        Correct,
        Delete
    }
    public class SecurityPrivilegeBuilderParms
    {

        public string MenuItemName { get; set; } = "";
        public EntryPointType MenuItemType { get; set; } 

        public string ObjectName { get; set; } = "";
        public PrivilegeAccessLevel AccessLevel { get; set; } = PrivilegeAccessLevel.Delete;

        public string FormLabel { get; set; } = "";
        private string FormLabelOrig { get; set; } = "";

        private string FormName { get; set; } = "";

        public bool IsDataEntity { get; set; } = false;

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

        public void InitFromSelectedElement(IMenuItem selectedElement)
        {
            MenuItemName = selectedElement.Name;
            FormLabelOrig = selectedElement.Label;
            //FormLabel = selectedElement.Label;

            if (selectedElement is IMenuItemAction)
            {
                MenuItemType  = EntryPointType.MenuItemAction;
            }
            if (selectedElement is IMenuItemOutput)
            {
                MenuItemType = EntryPointType.MenuItemOutput;
            }
            if (selectedElement is IMenuItemDisplay)
            {
                MenuItemType = EntryPointType.MenuItemDisplay;
            }

            if (selectedElement.ObjectType == MenuItemObjectType.Form)
            {
                FormName = selectedElement.Object;
            }

            GenerateNames();
        }

        public void InitFromDataEntity(IDataEntityView selectedElement)
        {
            MenuItemName = selectedElement.Name;
            FormLabelOrig = selectedElement.Label;
            IsDataEntity = true;
            MenuItemType = EntryPointType.None;

            GenerateNames();
        }
        public void Run()
        {
            _logString = "";
            ValidateData();
            if (_axHelper == null)
            {
                _axHelper = new AxHelper();
            }

            DoPrivilegeCreate();

        }

        public void GenerateNames()
        {
            string suffix = string.Empty;

            switch (AccessLevel)
            {
                case PrivilegeAccessLevel.Read:
                    suffix = "View";
                    break;
                case PrivilegeAccessLevel.Update:
                    suffix = "Update";
                    break;
                case PrivilegeAccessLevel.Create:
                    suffix = "Create";
                    break;
                case PrivilegeAccessLevel.Correct:
                    suffix = "Correct";
                    break;
                case PrivilegeAccessLevel.Delete:
                    suffix = "Maintain";
                    break;
                default:
                    throw new NotImplementedException(
                        $"Value {AccessLevel} is not implemented.");
            }

            ObjectName = $"{MenuItemName}{suffix}";
            FormLabel = $"{FormLabelOrig} {suffix.ToLower()}";

        }

        AccessGrant GetGrant()
        {
            AccessGrant grant;
            switch (AccessLevel)
            {
                case PrivilegeAccessLevel.Read:
                    grant = AccessGrant.ConstructGrantRead();
                    break;
                case PrivilegeAccessLevel.Update:
                    grant = AccessGrant.ConstructGrantUpdate();
                    break;
                case PrivilegeAccessLevel.Create:
                    grant = AccessGrant.ConstructGrantCreate();
                    break;
                case PrivilegeAccessLevel.Correct:
                    grant = AccessGrant.ConstructGrantCorrect();
                    break;
                case PrivilegeAccessLevel.Delete:
                    grant = AccessGrant.ConstructGrantDelete();
                    break;
                default:
                    throw new NotImplementedException(
                        $"Value {AccessLevel} is not implemented.");
            }

            return grant;
        }
      
        void DoPrivilegeCreate()
        {
            AxSecurityPrivilege privilege;

            privilege = _axHelper.MetadataProvider.SecurityPrivileges.Read(ObjectName);
            if (privilege != null)
            {
                throw new Exception($"Privilege {ObjectName} already exists");
            }
            privilege = new AxSecurityPrivilege();
            privilege.Name = ObjectName;
            if (IsDataEntity)
            {
                AxSecurityDataEntityPermission dataEntityPermission = new AxSecurityDataEntityPermission();

                dataEntityPermission.Grant = GetGrant();
                dataEntityPermission.IntegrationMode = IntegrationMode.All;
                dataEntityPermission.Name = MenuItemName;

                privilege.DataEntityPermissions.Add(dataEntityPermission);
            }
            else
            {
                AxSecurityEntryPointReference entryPoint = new AxSecurityEntryPointReference();

                entryPoint.Name = MenuItemName;
                entryPoint.Grant = GetGrant();
                entryPoint.ObjectName = MenuItemName;
                entryPoint.ObjectType = MenuItemType;

                if (!string.IsNullOrEmpty(FormName))
                {
                    AxSecurityEntryPointReferenceForm formRef = new AxSecurityEntryPointReferenceForm();
                    formRef.Name = FormName;
                    entryPoint.Forms.Add(formRef);
                }
                privilege.EntryPoints.Add(entryPoint);
            }
            privilege.Label = FormLabel;

            _axHelper.MetaModelService.CreateSecurityPrivilege(privilege, _axHelper.ModelSaveInfo);
            _axHelper.AppendToActiveProject(privilege);

            AddLog($"Privilege: {privilege.Name}; ");
        }

    }
}
