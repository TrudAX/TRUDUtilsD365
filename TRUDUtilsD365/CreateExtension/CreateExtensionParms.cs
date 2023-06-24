using Microsoft.Dynamics.AX.Metadata.MetaModel;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Forms;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Tables;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Views;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.BaseTypes;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Menus;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Security;
using TRUDUtilsD365.Kernel;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Core;
using TRUDUtilsD365.KernelSettings;
using Microsoft.Dynamics.AX.Metadata.Core.MetaModel;
using System;

namespace TRUDUtilsD365.CreateExtension
{

    public class CreateExtensionParms
    {
        public string ResultClassName { get; set; } = "";

        //private KernelSettingsManager _kernelSettingsManager;

        INamedElement SelectedElement;

        public bool Run()
        {
            Boolean         res = false;
            AxHelper        axHelper = new AxHelper();
            INamedObject    newExtension = null;

            ResultClassName = SelectedElement.Name + '.' + axHelper.ModelSaveInfo.Name;

            if (SelectedElement is IBaseEnum)
            {
                newExtension = axHelper.MetadataProvider.EnumExtensions.Read(ResultClassName);
                if (newExtension == null)
                {
                    newExtension = new AxEnumExtension() { Name = ResultClassName };
                    axHelper.MetadataProvider.EnumExtensions.Create((AxEnumExtension)newExtension, axHelper.ModelSaveInfo);
                    res = true;                    
                }
            }
            else if (SelectedElement is ITable)
            {
                newExtension = axHelper.MetadataProvider.TableExtensions.Read(ResultClassName);
                if (newExtension == null)
                {
                    newExtension = new AxTableExtension() { Name = ResultClassName };
                    axHelper.MetadataProvider.TableExtensions.Create((AxTableExtension)newExtension, axHelper.ModelSaveInfo);
                    res = true;
                }
            }
            else if (SelectedElement is IView)
            {
                newExtension = axHelper.MetadataProvider.ViewExtensions.Read(ResultClassName);
                if (newExtension == null)
                {
                    newExtension = new AxViewExtension() { Name = ResultClassName };
                    axHelper.MetadataProvider.ViewExtensions.Create((AxViewExtension)newExtension, axHelper.ModelSaveInfo);
                    res = true;
                }
            }
            else if (SelectedElement is IDataEntity)
            {
                newExtension = axHelper.MetadataProvider.DataEntityViewExtensions.Read(ResultClassName);
                if (newExtension == null)
                {
                    newExtension = new AxDataEntityViewExtension() { Name = ResultClassName };
                    axHelper.MetadataProvider.DataEntityViewExtensions.Create((AxDataEntityViewExtension)newExtension, axHelper.ModelSaveInfo);
                    res = true;
                }
            }
            else if (SelectedElement is IForm)
            {
                newExtension = axHelper.MetadataProvider.FormExtensions.Read(ResultClassName);
                if (newExtension == null)
                {
                    newExtension = new AxFormExtension() { Name = ResultClassName };
                    axHelper.MetadataProvider.FormExtensions.Create((AxFormExtension)newExtension, axHelper.ModelSaveInfo);
                    res = true;
                }
            }
            else if (SelectedElement is IMenu)
            {
                newExtension = axHelper.MetadataProvider.MenuExtensions.Read(ResultClassName);
                if (newExtension == null)
                {
                    newExtension = new AxMenuExtension() { Name = ResultClassName };
                    axHelper.MetadataProvider.MenuExtensions.Create((AxMenuExtension)newExtension, axHelper.ModelSaveInfo);
                    res = true;
                }
            }
            else if (SelectedElement is IMenuItemDisplay)
            {
                newExtension = axHelper.MetadataProvider.MenuItemDisplayExtensions.Read(ResultClassName);
                if (newExtension == null)
                {
                    newExtension = new AxMenuItemDisplayExtension() { Name = ResultClassName };
                    axHelper.MetadataProvider.MenuItemDisplayExtensions.Create((AxMenuItemDisplayExtension)newExtension, axHelper.ModelSaveInfo);
                    res = true;
                }
            }
            else if (SelectedElement is IMenuItemOutput)
            {
                newExtension = axHelper.MetadataProvider.MenuItemOutputExtensions.Read(ResultClassName);
                if (newExtension == null)
                {
                    newExtension = new AxMenuItemOutputExtension() { Name = ResultClassName };
                    axHelper.MetadataProvider.MenuItemOutputExtensions.Create((AxMenuItemOutputExtension)newExtension, axHelper.ModelSaveInfo);
                    res = true;
                }
            }
            else if (SelectedElement is IMenuItemAction)
            {
                newExtension = axHelper.MetadataProvider.MenuItemActionExtensions.Read(ResultClassName);
                if (newExtension == null)
                {
                    newExtension = new AxMenuItemActionExtension() { Name = ResultClassName };
                    axHelper.MetadataProvider.MenuItemActionExtensions.Create((AxMenuItemActionExtension)newExtension, axHelper.ModelSaveInfo);
                    res = true;
                }
            }
            else if (SelectedElement is ISecurityDuty)
            {
                newExtension = axHelper.MetadataProvider.SecurityDutyExtensions.Read(ResultClassName);
                if (newExtension == null)
                {
                    newExtension = new AxSecurityDutyExtension() { Name = ResultClassName };
                    axHelper.MetadataProvider.SecurityDutyExtensions.Create((AxSecurityDutyExtension)newExtension, axHelper.ModelSaveInfo);
                    res = true;
                }
            }
            else if (SelectedElement is ISecurityRole)
            {
                newExtension = axHelper.MetadataProvider.SecurityRoleExtensions.Read(ResultClassName);
                if (newExtension == null)
                {
                    newExtension = new AxSecurityRoleExtension() { Name = ResultClassName };
                    axHelper.MetadataProvider.SecurityRoleExtensions.Create((AxSecurityRoleExtension)newExtension, axHelper.ModelSaveInfo);
                    res = true;
                }
            }
            else
            {
                CoreUtility.DisplayError("Not implemented");
            }
            axHelper.AppendToActiveProject(newExtension);

            if (res)
            {
                CoreUtility.DisplayInfo($"Element {newExtension.Name} was created and added to the project");
            }
            else
            {
                CoreUtility.DisplayInfo($"Element {newExtension.Name} already exists");                
            }

            return res;

        }

        public void InitFromSelectedElement(object selectedElement)
        {
            SelectedElement = (INamedElement)selectedElement;
        }
    }
}
