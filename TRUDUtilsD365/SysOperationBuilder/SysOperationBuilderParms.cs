using Microsoft.Dynamics.AX.Metadata.Core.MetaModel;
using Microsoft.Dynamics.AX.Metadata.MetaModel;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Core;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TRUDUtilsD365.Kernel;

namespace TRUDUtilsD365.SysOperationBuilder
{
    public class SysOperationBuilderParms
    {
        private string sysOperationName;
        public string SysOperationName
        {
            get => sysOperationName;
            set
            {
                sysOperationName = value;
                OnPropertyChanged();
            }
        }

        public string ServiceClassName { get; set; }
        public string ServiceExtendsClass { get; set; }
        public string ServiceImplementsClass { get; set; }
        public string ServiceEntryMethod { get; set; } = "processOperation";

        public bool CreateDataContract { get; set; }
        public string ContractClassName { get; set; }
        public string ContractExtendsClass { get; set; }
        public string ContractImplementsClass { get; set; }

        private bool contractIsValidatable = false;
        public bool ContractIsValidatable
        {
            get => contractIsValidatable;
            set
            {
                contractIsValidatable = value;
                OnPropertyChanged();
            }
        }

        public bool CreateController { get; set; }
        public string ControllerClassName { get; set; }
        public string ControllerExtendsClass { get; set; } = "SysOperationServiceController";
        public string ControllerImplementsClass { get; set; }

        private string controllerCaptionLabel;
        public string ControllerCaptionLabel
        {
            get => controllerCaptionLabel;
            set
            {
                controllerCaptionLabel = value;
                OnPropertyChanged();
            }
        }

        public bool CreateUIBuilder { get; set; }
        public string UIBuilderClassName { get; set; }
        public string UIBuilderExtendsClass { get; set; } = "SysOperationAutomaticUIBuilder";
        public string UIBuilderImplementsClass { get; set; }

        public bool CreateMenuItem { get; set; }
        public string MenuItemName { get; set; }
        public string MenuItemLabel { get; set; }

        public bool CreateMaintainPrivilege { get; set; }
        public string MaintainPrivilegeName { get; set; }
        public string MaintainPrivilegeLabel { get; set; }

        public string KeyFieldName { get; set; } = "Id";

        private AxHelper _axHelper;

        private string _logString;

        private AxClass _serviceClass;
        private AxClass _dataContractClass;
        private AxClass _controllerClass;
        private AxClass _uiBuilderClass;
        private AxMenuItemAction _menuItemAction;
        private AxSecurityPrivilege _maintainPrivilege;

        void AddLog(string logLocal)
        {
            _logString += logLocal;
        }

        public void DisplayLog()
        {
            CoreUtility.DisplayInfo($"The following elements({_logString}) were created and added to the project");
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            switch (propertyName)
            {
                case nameof(SysOperationName):
                    SysOperationNameChanged();
                    break;
                case nameof(ContractIsValidatable):
                    ContractIsValidatableChanged();
                    break;
                case nameof(ControllerCaptionLabel):
                    ControllerCaptionLabelChanged();
                    break;
                default:
                    break;
            }
        }

        private void SysOperationNameChanged()
        {
            ServiceClassName = SysOperationName + "Service";
            ControllerClassName = SysOperationName + "Controller";
            ContractClassName = SysOperationName + "DataContract";
            UIBuilderClassName = SysOperationName + "UIBuilder";
            MaintainPrivilegeName = MenuItemName = SysOperationName;
        }

        private void ContractIsValidatableChanged()
        {
            ContractImplementsClass = "SysOperationValidatable";
        }

        private void ControllerCaptionLabelChanged()
        {
            MenuItemLabel = ControllerCaptionLabel;
        }

        public void ValidateData()
        {

            if (CreateDataContract)
            {
                if (string.IsNullOrWhiteSpace(ContractClassName))
                    throw new Exception("Data contract name should be specified");
            }
            if (CreateController)
            {
                if (string.IsNullOrWhiteSpace(ControllerClassName))
                    throw new Exception("Data contract name should be specified");
            }
            if (CreateUIBuilder)
            {
                if (string.IsNullOrWhiteSpace(UIBuilderClassName))
                    throw new Exception("Data contract name should be specified");
            }
            if (CreateMenuItem)
            {
                if (string.IsNullOrWhiteSpace(MenuItemName))
                    throw new Exception("Data contract name should be specified");
            }
            if (CreateMaintainPrivilege)
            {
                if (string.IsNullOrWhiteSpace(MaintainPrivilegeName))
                    throw new Exception("Data contract name should be specified");
            }
        }

        public void CreateSysOperation()
        {
            _logString = "";
            ValidateData();
            if (_axHelper == null)
            {
                _axHelper = new AxHelper();
            }

            InitServiceClass();

            if (CreateController)
                InitControllerClass();

            if (CreateDataContract)
                InitDataContractClass();

            if (CreateUIBuilder)
                InitUIBuilderClass();

            if (CreateMenuItem)
                InitMenuItemAction();

            if (CreateMaintainPrivilege)
                InitMaintainPrivilege();

            DoCreateObjects();
        }

        void DoCreateObjects()
        {
            if (CreateDataContract)
            {
                _axHelper.MetaModelService.CreateClass(_dataContractClass, _axHelper.ModelSaveInfo);
                _axHelper.AppendToActiveProject(_dataContractClass);
            }

            if (CreateUIBuilder)
            {
                _axHelper.MetaModelService.CreateClass(_uiBuilderClass, _axHelper.ModelSaveInfo);
                _axHelper.AppendToActiveProject(_uiBuilderClass);
            }

            _axHelper.MetaModelService.CreateClass(_serviceClass, _axHelper.ModelSaveInfo);
            _axHelper.AppendToActiveProject(_serviceClass);

            if (CreateController)
            {
                _axHelper.MetaModelService.CreateClass(_controllerClass, _axHelper.ModelSaveInfo);
                _axHelper.AppendToActiveProject(_controllerClass);
            }

            if (CreateMenuItem)
            {
                _axHelper.MetaModelService.CreateMenuItemAction(_menuItemAction, _axHelper.ModelSaveInfo);
                _axHelper.AppendToActiveProject(_menuItemAction);
            }

            if (CreateMaintainPrivilege)
            {
                _axHelper.MetaModelService.CreateSecurityPrivilege(_maintainPrivilege, _axHelper.ModelSaveInfo);
                _axHelper.AppendToActiveProject(_maintainPrivilege);
            }
        }

        void InitServiceClass()
        {
            _serviceClass = _axHelper.MetadataProvider.Classes.Read(ServiceClassName);
            if (_serviceClass != null)
                return;

            _serviceClass = new AxClass { Name = ServiceClassName, IsPublic = true };
            if (!string.IsNullOrWhiteSpace(ServiceExtendsClass))
                _serviceClass.Extends = ServiceExtendsClass;
            if (!string.IsNullOrWhiteSpace(ServiceImplementsClass))
                _serviceClass.AddImplements(ServiceImplementsClass);

            AxMethod entrymethod = new AxMethod();
            entrymethod.Name = ServiceEntryMethod;

            AddLog($"Class: {_serviceClass.Name}; ");
        }

        void InitDataContractClass()
        {
            _dataContractClass = _axHelper.MetadataProvider.Classes.Read(ContractClassName);
            if (_dataContractClass != null)
                return;

            _dataContractClass = new AxClass { Name = ContractClassName, IsPublic = true };
            _dataContractClass.AddAttribute(new AxAttribute
            {
                Name = "DataContract"
            });
            if (!string.IsNullOrWhiteSpace(ContractExtendsClass))
                _dataContractClass.Extends = ContractExtendsClass;
            if (!string.IsNullOrWhiteSpace(ContractImplementsClass))
                _dataContractClass.AddImplements(ContractImplementsClass);

            _dataContractClass.Declaration = $@"[DataContractAttribute]
public class {ContractClassName}{(string.IsNullOrWhiteSpace(ContractExtendsClass) ? "" : $" extends {ContractExtendsClass}")}{(string.IsNullOrWhiteSpace(ContractImplementsClass) ? "" : $" implements {ContractImplementsClass}")}
{{

}}";

            if (ContractIsValidatable)
            {
                AxMethod validateMethod = new AxMethod()
                {
                    Name = "validate",
                    ReturnType = new AxMethodReturnType { Type = CompilerBaseType.ClrType, TypeName = "boolean" }
                };
                validateMethod.Source = @"
    public boolean validate()
    {
        boolean ret = true;

        ;

        return ret;
    }
    ";
                _dataContractClass.AddMethod(validateMethod);
            }

            AxMethod entrymethod = new AxMethod();
            entrymethod.Name = ServiceEntryMethod;
            entrymethod.AddParameter(new AxMethodParameter()
            {
                Name = "_dataContract",
                Type = CompilerBaseType.Class,
                TypeName = ContractClassName
            });
            entrymethod.Source = $@"
    public void {ServiceEntryMethod}({ContractClassName} _dataContract)
    {{

    }}
";
            _serviceClass.Methods.Clear();
            _serviceClass.AddMethod(entrymethod);

            AddLog($"Class: {_dataContractClass.Name}; ");
        }

        void InitUIBuilderClass()
        {
            _uiBuilderClass = _axHelper.MetadataProvider.Classes.Read(UIBuilderClassName);
            if (_uiBuilderClass != null)
                return;

            _uiBuilderClass = new AxClass()
            {
                Name = UIBuilderClassName,
                IsPublic = true
            };
            _uiBuilderClass.Extends = UIBuilderExtendsClass;
            if (!string.IsNullOrWhiteSpace(UIBuilderImplementsClass))
                _uiBuilderClass.AddImplements(UIBuilderImplementsClass);

            var uiBuilderAttribute = new AxAttribute()
            {
                Name = "SysOperationContractProcessingAttribute"
            };
            uiBuilderAttribute.AddParameter(new AxAttributeParameter()
            {
                TypeValue = $"classStr({UIBuilderClassName})"
            });

            _dataContractClass.Declaration = $@"[
    DataContractAttribute,
    SysOperationContractProcessingAttribute(classStr({UIBuilderClassName}))
]
public class {ContractClassName}{(string.IsNullOrWhiteSpace(ContractExtendsClass) ? "" : $" extends {ContractExtendsClass}")}{(string.IsNullOrWhiteSpace(ContractImplementsClass) ? "" : $" implements {ContractImplementsClass}")}
{{

}}";

            _dataContractClass.AddAttribute(uiBuilderAttribute);

            AddLog($"Class: {_uiBuilderClass.Name}; ");
        }

        void InitControllerClass()
        {
            _controllerClass = _axHelper.MetadataProvider.Classes.Read(ControllerClassName);
            if (_controllerClass != null)
                return;

            _controllerClass = new AxClass { Name = ControllerClassName, IsPublic = true };
            if (!string.IsNullOrWhiteSpace(ControllerExtendsClass))
                _controllerClass.Extends = ControllerExtendsClass;
            if (!string.IsNullOrWhiteSpace(ControllerImplementsClass))
                _controllerClass.AddImplements(ControllerImplementsClass);

            AxMethod constructMethod = new AxMethod()
            {
                Name = "construct",
                IsStatic = true,
                ReturnType = new AxMethodReturnType
                {
                    Type = CompilerBaseType.Class,
                    TypeName = ControllerClassName
                },
                Parameters = new List<AxMethodParameter>()
                {
                    new AxMethodParameter()
                    {
                        Type = CompilerBaseType.Enum,
                        TypeName = "SysOperationExecutionMode",
                        DefaultValue = "SysOperationExecutionMode::Synchronous",
                        Name = "_executionMode"
                    }
                }
            };
            constructMethod.Source = $@"
    public static {ControllerClassName} construct(SysOperationExecutionMode _executionMode = SysOperationExecutionMode::Synchronous)
    {{
        {ControllerClassName} controller = new {ControllerClassName}(_executionMode);

        ;

        return controller;
    }}
";
            _controllerClass.AddMethod(constructMethod);

            AxMethod newMethod = new AxMethod()
            {
                Name = "new",
                IsExtendedMethod = true,
                ReturnType = new AxMethodReturnType
                {
                    Type = CompilerBaseType.Void
                },
                Parameters = new List<AxMethodParameter>()
                {
                    new AxMethodParameter()
                    {
                        Type = CompilerBaseType.Enum,
                        TypeName = "SysOperationExecutionMode",
                        DefaultValue = "SysOperationExecutionMode::Synchronous",
                        Name = "_executionMode"
                    }
                }
            };
            newMethod.Source = $@"
    protected void new(SysOperationExecutionMode _executionMode = SysOperationExecutionMode::Synchronous)
    {{
        super(classStr({ServiceClassName}), methodStr({ServiceClassName}, {ServiceEntryMethod}), _executionMode);
    }}
";
            _controllerClass.AddMethod(newMethod);

            AxMethod mainMethod = new AxMethod()
            {
                Name = "main",
                IsStatic = true,
                ReturnType = new AxMethodReturnType
                {
                    Type = CompilerBaseType.Void
                },
                Parameters = new List<AxMethodParameter>()
                {
                    new AxMethodParameter()
                    {
                        Type = CompilerBaseType.Class,
                        TypeName = "Args",
                        Name = "_args"
                    }
                }
            };
            mainMethod.Source = $@"
    public static void main(Args _args)
    {{
        {ControllerClassName} controller = {ControllerClassName}::construct();

        ;

        controller.parmArgs(_args);
        
        controller.startOperation();
    }}
";

            _controllerClass.AddMethod(mainMethod);

            AxMethod defaultCaptionMethod = new AxMethod()
            {
                Name = "defaultCaption",
                ReturnType = new AxMethodReturnType
                {
                    Type = CompilerBaseType.ExtendedDataType,
                    TypeName = "ClassDescription"
                }
            };
            defaultCaptionMethod.Source = $@"
    public ClassDescription defaultCaption()
    {{
        return ""{ControllerCaptionLabel}"";
    }}
";

            _controllerClass.AddMethod(defaultCaptionMethod);

            AddLog($"Class: {_controllerClass.Name}; ");
        }

        void InitMenuItemAction()
        {
            _menuItemAction = _axHelper.MetadataProvider.MenuItemActions.Read(MenuItemName);
            if (_menuItemAction != null)
            {
                return;
            }

            _menuItemAction = new AxMenuItemAction { Name = MenuItemName, Object = ControllerClassName, Label = MenuItemLabel, ObjectType = MenuItemObjectType.Class};

            AddLog($"MenuItem: {_menuItemAction.Name}; ");
        }

        void InitMaintainPrivilege()
        {
            _maintainPrivilege = _axHelper.MetadataProvider.SecurityPrivileges.Read(MaintainPrivilegeName);
            if (_maintainPrivilege != null)
            {
                return;
            }
            _maintainPrivilege = new AxSecurityPrivilege();

            _maintainPrivilege.Name = MaintainPrivilegeName;
            _maintainPrivilege.Label = MaintainPrivilegeLabel;

            AxSecurityEntryPointReference entryPoint = new AxSecurityEntryPointReference();

            entryPoint.Name = MaintainPrivilegeName;
            entryPoint.Grant = AccessGrant.ConstructGrantDelete();
            entryPoint.ObjectName = ControllerClassName;
            entryPoint.ObjectType = EntryPointType.MenuItemAction;

            _maintainPrivilege.EntryPoints.Add(entryPoint);

            AddLog($"Privilege: {_maintainPrivilege.Name}; ");
        }
    }
}
