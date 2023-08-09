
namespace TRUDUtilsD365.SysOperationBuilder
{
    partial class SysOperationBuilderDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.sysOperationBuilderParmsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SysOperationNameLabel = new System.Windows.Forms.Label();
            this.SysOperationNameTextBox = new System.Windows.Forms.TextBox();
            this.ServiceGroup = new System.Windows.Forms.GroupBox();
            this.ServiceEntryMethodTextBox = new System.Windows.Forms.TextBox();
            this.ServiceEntryMethodLabel = new System.Windows.Forms.Label();
            this.ServiceImplementsClassTextBox = new System.Windows.Forms.TextBox();
            this.ServiceImplementsClassLabel = new System.Windows.Forms.Label();
            this.ServiceExtendsClassTextBox = new System.Windows.Forms.TextBox();
            this.ServiceExtendsClassLabel = new System.Windows.Forms.Label();
            this.ServiceClassNameTextBox = new System.Windows.Forms.TextBox();
            this.ServiceClassNameLabel = new System.Windows.Forms.Label();
            this.ControllerGroup = new System.Windows.Forms.GroupBox();
            this.ControllerCaptionLabelTextbox = new System.Windows.Forms.TextBox();
            this.ControllerCaptionLabelLabel = new System.Windows.Forms.Label();
            this.ControllerImplementsClassTextBox = new System.Windows.Forms.TextBox();
            this.ControllerImplementsClassLabel = new System.Windows.Forms.Label();
            this.ControllerExtendsClassTextBox = new System.Windows.Forms.TextBox();
            this.ControllerExtendsClassLabel = new System.Windows.Forms.Label();
            this.ControllerClassNameTextBox = new System.Windows.Forms.TextBox();
            this.ControllerClassNameLabel = new System.Windows.Forms.Label();
            this.CreateControllerCheckBox = new System.Windows.Forms.CheckBox();
            this.DataContractGroup = new System.Windows.Forms.GroupBox();
            this.ContractIsValidatableCheckBox = new System.Windows.Forms.CheckBox();
            this.ContractImplementsClassTextBox = new System.Windows.Forms.TextBox();
            this.ContractImplementsClassLabel = new System.Windows.Forms.Label();
            this.ContractExtendsClassTextBox = new System.Windows.Forms.TextBox();
            this.ContractExtendsClassLabel = new System.Windows.Forms.Label();
            this.ContractClassNameTextBox = new System.Windows.Forms.TextBox();
            this.ContractClassNameLabel = new System.Windows.Forms.Label();
            this.CreateDataContractCheckBox = new System.Windows.Forms.CheckBox();
            this.UIBuilderGroup = new System.Windows.Forms.GroupBox();
            this.UIBuilderImplementsClassTextBox = new System.Windows.Forms.TextBox();
            this.UIBuilderImplementationClassLabel = new System.Windows.Forms.Label();
            this.UIBuilderExtendsClassTextBox = new System.Windows.Forms.TextBox();
            this.UIBuilderExtendsClassLabel = new System.Windows.Forms.Label();
            this.UIBuilderClassNameTextBox = new System.Windows.Forms.TextBox();
            this.UIBuilderClassNameLabel = new System.Windows.Forms.Label();
            this.CreateUIBuilderCheckBox = new System.Windows.Forms.CheckBox();
            this.PrivilegeGroup = new System.Windows.Forms.GroupBox();
            this.MaintainPrivilegeLabelTextBox = new System.Windows.Forms.TextBox();
            this.MaintainPrivilegeLabelLabel = new System.Windows.Forms.Label();
            this.MaintainPrivilegeNameTextBox = new System.Windows.Forms.TextBox();
            this.MaintainPrivilegeNameLabel = new System.Windows.Forms.Label();
            this.CreateMaintainPrivilegeCheckBox = new System.Windows.Forms.CheckBox();
            this.MenuItemGroup = new System.Windows.Forms.GroupBox();
            this.MenuItemNameLabel = new System.Windows.Forms.Label();
            this.MenuItemNameTextBox = new System.Windows.Forms.TextBox();
            this.MenuItemLabelLabel = new System.Windows.Forms.Label();
            this.MenuItemLabelTextBox = new System.Windows.Forms.TextBox();
            this.CreateMenuItemCheckBox = new System.Windows.Forms.CheckBox();
            this.CreateSysOperationButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sysOperationBuilderParmsBindingSource)).BeginInit();
            this.ServiceGroup.SuspendLayout();
            this.ControllerGroup.SuspendLayout();
            this.DataContractGroup.SuspendLayout();
            this.UIBuilderGroup.SuspendLayout();
            this.PrivilegeGroup.SuspendLayout();
            this.MenuItemGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // sysOperationBuilderParmsBindingSource
            // 
            this.sysOperationBuilderParmsBindingSource.DataSource = typeof(TRUDUtilsD365.SysOperationBuilder.SysOperationBuilderParms);
            // 
            // SysOperationNameLabel
            // 
            this.SysOperationNameLabel.AutoSize = true;
            this.SysOperationNameLabel.Location = new System.Drawing.Point(12, 9);
            this.SysOperationNameLabel.Name = "SysOperationNameLabel";
            this.SysOperationNameLabel.Size = new System.Drawing.Size(102, 13);
            this.SysOperationNameLabel.TabIndex = 0;
            this.SysOperationNameLabel.Text = "SysOperation name:";
            // 
            // SysOperationNameTextBox
            // 
            this.SysOperationNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sysOperationBuilderParmsBindingSource, "SysOperationName", true));
            this.SysOperationNameTextBox.Location = new System.Drawing.Point(120, 6);
            this.SysOperationNameTextBox.Name = "SysOperationNameTextBox";
            this.SysOperationNameTextBox.Size = new System.Drawing.Size(513, 20);
            this.SysOperationNameTextBox.TabIndex = 1;
            // 
            // ServiceGroup
            // 
            this.ServiceGroup.Controls.Add(this.ServiceEntryMethodTextBox);
            this.ServiceGroup.Controls.Add(this.ServiceEntryMethodLabel);
            this.ServiceGroup.Controls.Add(this.ServiceImplementsClassTextBox);
            this.ServiceGroup.Controls.Add(this.ServiceImplementsClassLabel);
            this.ServiceGroup.Controls.Add(this.ServiceExtendsClassTextBox);
            this.ServiceGroup.Controls.Add(this.ServiceExtendsClassLabel);
            this.ServiceGroup.Controls.Add(this.ServiceClassNameTextBox);
            this.ServiceGroup.Controls.Add(this.ServiceClassNameLabel);
            this.ServiceGroup.Location = new System.Drawing.Point(15, 32);
            this.ServiceGroup.Name = "ServiceGroup";
            this.ServiceGroup.Size = new System.Drawing.Size(384, 222);
            this.ServiceGroup.TabIndex = 2;
            this.ServiceGroup.TabStop = false;
            this.ServiceGroup.Text = "Service";
            // 
            // ServiceEntryMethodTextBox
            // 
            this.ServiceEntryMethodTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sysOperationBuilderParmsBindingSource, "ServiceEntryMethod", true));
            this.ServiceEntryMethodTextBox.Location = new System.Drawing.Point(9, 165);
            this.ServiceEntryMethodTextBox.Name = "ServiceEntryMethodTextBox";
            this.ServiceEntryMethodTextBox.Size = new System.Drawing.Size(369, 20);
            this.ServiceEntryMethodTextBox.TabIndex = 7;
            // 
            // ServiceEntryMethodLabel
            // 
            this.ServiceEntryMethodLabel.AutoSize = true;
            this.ServiceEntryMethodLabel.Location = new System.Drawing.Point(7, 149);
            this.ServiceEntryMethodLabel.Name = "ServiceEntryMethodLabel";
            this.ServiceEntryMethodLabel.Size = new System.Drawing.Size(101, 13);
            this.ServiceEntryMethodLabel.TabIndex = 6;
            this.ServiceEntryMethodLabel.Text = "Entry method name:";
            // 
            // ServiceImplementsClassTextBox
            // 
            this.ServiceImplementsClassTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sysOperationBuilderParmsBindingSource, "ServiceImplementsClass", true));
            this.ServiceImplementsClassTextBox.Location = new System.Drawing.Point(9, 122);
            this.ServiceImplementsClassTextBox.Name = "ServiceImplementsClassTextBox";
            this.ServiceImplementsClassTextBox.Size = new System.Drawing.Size(369, 20);
            this.ServiceImplementsClassTextBox.TabIndex = 5;
            // 
            // ServiceImplementsClassLabel
            // 
            this.ServiceImplementsClassLabel.AutoSize = true;
            this.ServiceImplementsClassLabel.Location = new System.Drawing.Point(7, 106);
            this.ServiceImplementsClassLabel.Name = "ServiceImplementsClassLabel";
            this.ServiceImplementsClassLabel.Size = new System.Drawing.Size(119, 13);
            this.ServiceImplementsClassLabel.TabIndex = 4;
            this.ServiceImplementsClassLabel.Text = "Implements class name:";
            // 
            // ServiceExtendsClassTextBox
            // 
            this.ServiceExtendsClassTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sysOperationBuilderParmsBindingSource, "ServiceExtendsClass", true));
            this.ServiceExtendsClassTextBox.Location = new System.Drawing.Point(9, 79);
            this.ServiceExtendsClassTextBox.Name = "ServiceExtendsClassTextBox";
            this.ServiceExtendsClassTextBox.Size = new System.Drawing.Size(369, 20);
            this.ServiceExtendsClassTextBox.TabIndex = 3;
            // 
            // ServiceExtendsClassLabel
            // 
            this.ServiceExtendsClassLabel.AutoSize = true;
            this.ServiceExtendsClassLabel.Location = new System.Drawing.Point(7, 63);
            this.ServiceExtendsClassLabel.Name = "ServiceExtendsClassLabel";
            this.ServiceExtendsClassLabel.Size = new System.Drawing.Size(104, 13);
            this.ServiceExtendsClassLabel.TabIndex = 2;
            this.ServiceExtendsClassLabel.Text = "Extends class name:";
            // 
            // ServiceClassNameTextBox
            // 
            this.ServiceClassNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sysOperationBuilderParmsBindingSource, "ServiceClassName", true));
            this.ServiceClassNameTextBox.Location = new System.Drawing.Point(9, 36);
            this.ServiceClassNameTextBox.Name = "ServiceClassNameTextBox";
            this.ServiceClassNameTextBox.Size = new System.Drawing.Size(369, 20);
            this.ServiceClassNameTextBox.TabIndex = 1;
            // 
            // ServiceClassNameLabel
            // 
            this.ServiceClassNameLabel.AutoSize = true;
            this.ServiceClassNameLabel.Location = new System.Drawing.Point(6, 19);
            this.ServiceClassNameLabel.Name = "ServiceClassNameLabel";
            this.ServiceClassNameLabel.Size = new System.Drawing.Size(102, 13);
            this.ServiceClassNameLabel.TabIndex = 0;
            this.ServiceClassNameLabel.Text = "Service class name:";
            // 
            // ControllerGroup
            // 
            this.ControllerGroup.Controls.Add(this.ControllerCaptionLabelTextbox);
            this.ControllerGroup.Controls.Add(this.ControllerCaptionLabelLabel);
            this.ControllerGroup.Controls.Add(this.ControllerImplementsClassTextBox);
            this.ControllerGroup.Controls.Add(this.ControllerImplementsClassLabel);
            this.ControllerGroup.Controls.Add(this.ControllerExtendsClassTextBox);
            this.ControllerGroup.Controls.Add(this.ControllerExtendsClassLabel);
            this.ControllerGroup.Controls.Add(this.ControllerClassNameTextBox);
            this.ControllerGroup.Controls.Add(this.ControllerClassNameLabel);
            this.ControllerGroup.Controls.Add(this.CreateControllerCheckBox);
            this.ControllerGroup.Location = new System.Drawing.Point(405, 32);
            this.ControllerGroup.Name = "ControllerGroup";
            this.ControllerGroup.Size = new System.Drawing.Size(384, 222);
            this.ControllerGroup.TabIndex = 3;
            this.ControllerGroup.TabStop = false;
            this.ControllerGroup.Text = "Controller";
            // 
            // ControllerCaptionLabelTextbox
            // 
            this.ControllerCaptionLabelTextbox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sysOperationBuilderParmsBindingSource, "ControllerCaptionLabel", true));
            this.ControllerCaptionLabelTextbox.Enabled = false;
            this.ControllerCaptionLabelTextbox.Location = new System.Drawing.Point(8, 189);
            this.ControllerCaptionLabelTextbox.Name = "ControllerCaptionLabelTextbox";
            this.ControllerCaptionLabelTextbox.Size = new System.Drawing.Size(369, 20);
            this.ControllerCaptionLabelTextbox.TabIndex = 15;
            // 
            // ControllerCaptionLabelLabel
            // 
            this.ControllerCaptionLabelLabel.AutoSize = true;
            this.ControllerCaptionLabelLabel.Location = new System.Drawing.Point(8, 173);
            this.ControllerCaptionLabelLabel.Name = "ControllerCaptionLabelLabel";
            this.ControllerCaptionLabelLabel.Size = new System.Drawing.Size(117, 13);
            this.ControllerCaptionLabelLabel.TabIndex = 14;
            this.ControllerCaptionLabelLabel.Text = "Controller caption label:";
            // 
            // ControllerImplementsClassTextBox
            // 
            this.ControllerImplementsClassTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sysOperationBuilderParmsBindingSource, "ControllerImplementsClass", true));
            this.ControllerImplementsClassTextBox.Enabled = false;
            this.ControllerImplementsClassTextBox.Location = new System.Drawing.Point(8, 146);
            this.ControllerImplementsClassTextBox.Name = "ControllerImplementsClassTextBox";
            this.ControllerImplementsClassTextBox.Size = new System.Drawing.Size(369, 20);
            this.ControllerImplementsClassTextBox.TabIndex = 13;
            // 
            // ControllerImplementsClassLabel
            // 
            this.ControllerImplementsClassLabel.AutoSize = true;
            this.ControllerImplementsClassLabel.Location = new System.Drawing.Point(8, 130);
            this.ControllerImplementsClassLabel.Name = "ControllerImplementsClassLabel";
            this.ControllerImplementsClassLabel.Size = new System.Drawing.Size(119, 13);
            this.ControllerImplementsClassLabel.TabIndex = 12;
            this.ControllerImplementsClassLabel.Text = "Implements class name:";
            // 
            // ControllerExtendsClassTextBox
            // 
            this.ControllerExtendsClassTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sysOperationBuilderParmsBindingSource, "ControllerExtendsClass", true));
            this.ControllerExtendsClassTextBox.Enabled = false;
            this.ControllerExtendsClassTextBox.Location = new System.Drawing.Point(8, 103);
            this.ControllerExtendsClassTextBox.Name = "ControllerExtendsClassTextBox";
            this.ControllerExtendsClassTextBox.Size = new System.Drawing.Size(369, 20);
            this.ControllerExtendsClassTextBox.TabIndex = 11;
            // 
            // ControllerExtendsClassLabel
            // 
            this.ControllerExtendsClassLabel.AutoSize = true;
            this.ControllerExtendsClassLabel.Location = new System.Drawing.Point(8, 87);
            this.ControllerExtendsClassLabel.Name = "ControllerExtendsClassLabel";
            this.ControllerExtendsClassLabel.Size = new System.Drawing.Size(104, 13);
            this.ControllerExtendsClassLabel.TabIndex = 10;
            this.ControllerExtendsClassLabel.Text = "Extends class name:";
            // 
            // ControllerClassNameTextBox
            // 
            this.ControllerClassNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sysOperationBuilderParmsBindingSource, "ControllerClassName", true));
            this.ControllerClassNameTextBox.Enabled = false;
            this.ControllerClassNameTextBox.Location = new System.Drawing.Point(8, 60);
            this.ControllerClassNameTextBox.Name = "ControllerClassNameTextBox";
            this.ControllerClassNameTextBox.Size = new System.Drawing.Size(369, 20);
            this.ControllerClassNameTextBox.TabIndex = 9;
            // 
            // ControllerClassNameLabel
            // 
            this.ControllerClassNameLabel.AutoSize = true;
            this.ControllerClassNameLabel.Location = new System.Drawing.Point(5, 43);
            this.ControllerClassNameLabel.Name = "ControllerClassNameLabel";
            this.ControllerClassNameLabel.Size = new System.Drawing.Size(83, 13);
            this.ControllerClassNameLabel.TabIndex = 8;
            this.ControllerClassNameLabel.Text = "Controller name:";
            // 
            // CreateControllerCheckBox
            // 
            this.CreateControllerCheckBox.AutoSize = true;
            this.CreateControllerCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.sysOperationBuilderParmsBindingSource, "CreateController", true));
            this.CreateControllerCheckBox.Location = new System.Drawing.Point(8, 19);
            this.CreateControllerCheckBox.Name = "CreateControllerCheckBox";
            this.CreateControllerCheckBox.Size = new System.Drawing.Size(103, 17);
            this.CreateControllerCheckBox.TabIndex = 0;
            this.CreateControllerCheckBox.Text = "Create controller";
            this.CreateControllerCheckBox.UseVisualStyleBackColor = true;
            this.CreateControllerCheckBox.CheckedChanged += new System.EventHandler(this.CreateControllerCheckBox_CheckedChanged);
            // 
            // DataContractGroup
            // 
            this.DataContractGroup.Controls.Add(this.ContractIsValidatableCheckBox);
            this.DataContractGroup.Controls.Add(this.ContractImplementsClassTextBox);
            this.DataContractGroup.Controls.Add(this.ContractImplementsClassLabel);
            this.DataContractGroup.Controls.Add(this.ContractExtendsClassTextBox);
            this.DataContractGroup.Controls.Add(this.ContractExtendsClassLabel);
            this.DataContractGroup.Controls.Add(this.ContractClassNameTextBox);
            this.DataContractGroup.Controls.Add(this.ContractClassNameLabel);
            this.DataContractGroup.Controls.Add(this.CreateDataContractCheckBox);
            this.DataContractGroup.Location = new System.Drawing.Point(15, 258);
            this.DataContractGroup.Name = "DataContractGroup";
            this.DataContractGroup.Size = new System.Drawing.Size(384, 193);
            this.DataContractGroup.TabIndex = 4;
            this.DataContractGroup.TabStop = false;
            this.DataContractGroup.Text = "DataContract";
            // 
            // ContractIsValidatableCheckBox
            // 
            this.ContractIsValidatableCheckBox.AutoSize = true;
            this.ContractIsValidatableCheckBox.Location = new System.Drawing.Point(6, 164);
            this.ContractIsValidatableCheckBox.Name = "ContractIsValidatableCheckBox";
            this.ContractIsValidatableCheckBox.Size = new System.Drawing.Size(156, 17);
            this.ContractIsValidatableCheckBox.TabIndex = 18;
            this.ContractIsValidatableCheckBox.Text = "Data Contract is validatable";
            this.ContractIsValidatableCheckBox.UseVisualStyleBackColor = true;
            // 
            // ContractImplementsClassTextBox
            // 
            this.ContractImplementsClassTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sysOperationBuilderParmsBindingSource, "ContractImplementsClass", true));
            this.ContractImplementsClassTextBox.Enabled = false;
            this.ContractImplementsClassTextBox.Location = new System.Drawing.Point(6, 138);
            this.ContractImplementsClassTextBox.Name = "ContractImplementsClassTextBox";
            this.ContractImplementsClassTextBox.Size = new System.Drawing.Size(369, 20);
            this.ContractImplementsClassTextBox.TabIndex = 17;
            // 
            // ContractImplementsClassLabel
            // 
            this.ContractImplementsClassLabel.AutoSize = true;
            this.ContractImplementsClassLabel.Location = new System.Drawing.Point(6, 122);
            this.ContractImplementsClassLabel.Name = "ContractImplementsClassLabel";
            this.ContractImplementsClassLabel.Size = new System.Drawing.Size(119, 13);
            this.ContractImplementsClassLabel.TabIndex = 16;
            this.ContractImplementsClassLabel.Text = "Implements class name:";
            // 
            // ContractExtendsClassTextBox
            // 
            this.ContractExtendsClassTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sysOperationBuilderParmsBindingSource, "ContractExtendsClass", true));
            this.ContractExtendsClassTextBox.Enabled = false;
            this.ContractExtendsClassTextBox.Location = new System.Drawing.Point(6, 95);
            this.ContractExtendsClassTextBox.Name = "ContractExtendsClassTextBox";
            this.ContractExtendsClassTextBox.Size = new System.Drawing.Size(369, 20);
            this.ContractExtendsClassTextBox.TabIndex = 15;
            // 
            // ContractExtendsClassLabel
            // 
            this.ContractExtendsClassLabel.AutoSize = true;
            this.ContractExtendsClassLabel.Location = new System.Drawing.Point(6, 79);
            this.ContractExtendsClassLabel.Name = "ContractExtendsClassLabel";
            this.ContractExtendsClassLabel.Size = new System.Drawing.Size(104, 13);
            this.ContractExtendsClassLabel.TabIndex = 14;
            this.ContractExtendsClassLabel.Text = "Extends class name:";
            // 
            // ContractClassNameTextBox
            // 
            this.ContractClassNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sysOperationBuilderParmsBindingSource, "ContractClassName", true));
            this.ContractClassNameTextBox.Enabled = false;
            this.ContractClassNameTextBox.Location = new System.Drawing.Point(6, 56);
            this.ContractClassNameTextBox.Name = "ContractClassNameTextBox";
            this.ContractClassNameTextBox.Size = new System.Drawing.Size(369, 20);
            this.ContractClassNameTextBox.TabIndex = 11;
            // 
            // ContractClassNameLabel
            // 
            this.ContractClassNameLabel.AutoSize = true;
            this.ContractClassNameLabel.Location = new System.Drawing.Point(6, 39);
            this.ContractClassNameLabel.Name = "ContractClassNameLabel";
            this.ContractClassNameLabel.Size = new System.Drawing.Size(105, 13);
            this.ContractClassNameLabel.TabIndex = 10;
            this.ContractClassNameLabel.Text = "Data Contract name:";
            // 
            // CreateDataContractCheckBox
            // 
            this.CreateDataContractCheckBox.AutoSize = true;
            this.CreateDataContractCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.sysOperationBuilderParmsBindingSource, "CreateDataContract", true));
            this.CreateDataContractCheckBox.Location = new System.Drawing.Point(6, 19);
            this.CreateDataContractCheckBox.Name = "CreateDataContractCheckBox";
            this.CreateDataContractCheckBox.Size = new System.Drawing.Size(123, 17);
            this.CreateDataContractCheckBox.TabIndex = 1;
            this.CreateDataContractCheckBox.Text = "Create DataContract";
            this.CreateDataContractCheckBox.UseVisualStyleBackColor = true;
            this.CreateDataContractCheckBox.CheckedChanged += new System.EventHandler(this.CreateDataContractCheckBox_CheckedChanged);
            // 
            // UIBuilderGroup
            // 
            this.UIBuilderGroup.Controls.Add(this.UIBuilderImplementsClassTextBox);
            this.UIBuilderGroup.Controls.Add(this.UIBuilderImplementationClassLabel);
            this.UIBuilderGroup.Controls.Add(this.UIBuilderExtendsClassTextBox);
            this.UIBuilderGroup.Controls.Add(this.UIBuilderExtendsClassLabel);
            this.UIBuilderGroup.Controls.Add(this.UIBuilderClassNameTextBox);
            this.UIBuilderGroup.Controls.Add(this.UIBuilderClassNameLabel);
            this.UIBuilderGroup.Controls.Add(this.CreateUIBuilderCheckBox);
            this.UIBuilderGroup.Location = new System.Drawing.Point(405, 258);
            this.UIBuilderGroup.Name = "UIBuilderGroup";
            this.UIBuilderGroup.Size = new System.Drawing.Size(384, 193);
            this.UIBuilderGroup.TabIndex = 5;
            this.UIBuilderGroup.TabStop = false;
            this.UIBuilderGroup.Text = "UIBuilder";
            // 
            // UIBuilderImplementsClassTextBox
            // 
            this.UIBuilderImplementsClassTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sysOperationBuilderParmsBindingSource, "UIBuilderImplementsClass", true));
            this.UIBuilderImplementsClassTextBox.Enabled = false;
            this.UIBuilderImplementsClassTextBox.Location = new System.Drawing.Point(8, 136);
            this.UIBuilderImplementsClassTextBox.Name = "UIBuilderImplementsClassTextBox";
            this.UIBuilderImplementsClassTextBox.Size = new System.Drawing.Size(369, 20);
            this.UIBuilderImplementsClassTextBox.TabIndex = 23;
            // 
            // UIBuilderImplementationClassLabel
            // 
            this.UIBuilderImplementationClassLabel.AutoSize = true;
            this.UIBuilderImplementationClassLabel.Location = new System.Drawing.Point(8, 120);
            this.UIBuilderImplementationClassLabel.Name = "UIBuilderImplementationClassLabel";
            this.UIBuilderImplementationClassLabel.Size = new System.Drawing.Size(119, 13);
            this.UIBuilderImplementationClassLabel.TabIndex = 22;
            this.UIBuilderImplementationClassLabel.Text = "Implements class name:";
            // 
            // UIBuilderExtendsClassTextBox
            // 
            this.UIBuilderExtendsClassTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sysOperationBuilderParmsBindingSource, "UIBuilderExtendsClass", true));
            this.UIBuilderExtendsClassTextBox.Enabled = false;
            this.UIBuilderExtendsClassTextBox.Location = new System.Drawing.Point(8, 93);
            this.UIBuilderExtendsClassTextBox.Name = "UIBuilderExtendsClassTextBox";
            this.UIBuilderExtendsClassTextBox.Size = new System.Drawing.Size(369, 20);
            this.UIBuilderExtendsClassTextBox.TabIndex = 21;
            // 
            // UIBuilderExtendsClassLabel
            // 
            this.UIBuilderExtendsClassLabel.AutoSize = true;
            this.UIBuilderExtendsClassLabel.Location = new System.Drawing.Point(8, 77);
            this.UIBuilderExtendsClassLabel.Name = "UIBuilderExtendsClassLabel";
            this.UIBuilderExtendsClassLabel.Size = new System.Drawing.Size(104, 13);
            this.UIBuilderExtendsClassLabel.TabIndex = 20;
            this.UIBuilderExtendsClassLabel.Text = "Extends class name:";
            // 
            // UIBuilderClassNameTextBox
            // 
            this.UIBuilderClassNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sysOperationBuilderParmsBindingSource, "UIBuilderClassName", true));
            this.UIBuilderClassNameTextBox.Enabled = false;
            this.UIBuilderClassNameTextBox.Location = new System.Drawing.Point(8, 54);
            this.UIBuilderClassNameTextBox.Name = "UIBuilderClassNameTextBox";
            this.UIBuilderClassNameTextBox.Size = new System.Drawing.Size(369, 20);
            this.UIBuilderClassNameTextBox.TabIndex = 19;
            // 
            // UIBuilderClassNameLabel
            // 
            this.UIBuilderClassNameLabel.AutoSize = true;
            this.UIBuilderClassNameLabel.Location = new System.Drawing.Point(8, 37);
            this.UIBuilderClassNameLabel.Name = "UIBuilderClassNameLabel";
            this.UIBuilderClassNameLabel.Size = new System.Drawing.Size(85, 13);
            this.UIBuilderClassNameLabel.TabIndex = 18;
            this.UIBuilderClassNameLabel.Text = "UI Builder name:";
            // 
            // CreateUIBuilderCheckBox
            // 
            this.CreateUIBuilderCheckBox.AutoSize = true;
            this.CreateUIBuilderCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.sysOperationBuilderParmsBindingSource, "CreateUIBuilder", true));
            this.CreateUIBuilderCheckBox.Location = new System.Drawing.Point(8, 19);
            this.CreateUIBuilderCheckBox.Name = "CreateUIBuilderCheckBox";
            this.CreateUIBuilderCheckBox.Size = new System.Drawing.Size(103, 17);
            this.CreateUIBuilderCheckBox.TabIndex = 1;
            this.CreateUIBuilderCheckBox.Text = "Create UIBuilder";
            this.CreateUIBuilderCheckBox.UseVisualStyleBackColor = true;
            this.CreateUIBuilderCheckBox.CheckedChanged += new System.EventHandler(this.CreateUIBuilderCheckBox_CheckedChanged);
            // 
            // PrivilegeGroup
            // 
            this.PrivilegeGroup.Controls.Add(this.MaintainPrivilegeLabelTextBox);
            this.PrivilegeGroup.Controls.Add(this.MaintainPrivilegeLabelLabel);
            this.PrivilegeGroup.Controls.Add(this.MaintainPrivilegeNameTextBox);
            this.PrivilegeGroup.Controls.Add(this.MaintainPrivilegeNameLabel);
            this.PrivilegeGroup.Controls.Add(this.CreateMaintainPrivilegeCheckBox);
            this.PrivilegeGroup.Location = new System.Drawing.Point(405, 457);
            this.PrivilegeGroup.Name = "PrivilegeGroup";
            this.PrivilegeGroup.Size = new System.Drawing.Size(384, 131);
            this.PrivilegeGroup.TabIndex = 7;
            this.PrivilegeGroup.TabStop = false;
            this.PrivilegeGroup.Text = "Privileges";
            // 
            // MaintainPrivilegeLabelTextBox
            // 
            this.MaintainPrivilegeLabelTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sysOperationBuilderParmsBindingSource, "MaintainPrivilegeLabel", true));
            this.MaintainPrivilegeLabelTextBox.Enabled = false;
            this.MaintainPrivilegeLabelTextBox.Location = new System.Drawing.Point(6, 95);
            this.MaintainPrivilegeLabelTextBox.Name = "MaintainPrivilegeLabelTextBox";
            this.MaintainPrivilegeLabelTextBox.Size = new System.Drawing.Size(369, 20);
            this.MaintainPrivilegeLabelTextBox.TabIndex = 29;
            // 
            // MaintainPrivilegeLabelLabel
            // 
            this.MaintainPrivilegeLabelLabel.AutoSize = true;
            this.MaintainPrivilegeLabelLabel.Location = new System.Drawing.Point(6, 79);
            this.MaintainPrivilegeLabelLabel.Name = "MaintainPrivilegeLabelLabel";
            this.MaintainPrivilegeLabelLabel.Size = new System.Drawing.Size(75, 13);
            this.MaintainPrivilegeLabelLabel.TabIndex = 28;
            this.MaintainPrivilegeLabelLabel.Text = "Privilege label:";
            // 
            // MaintainPrivilegeNameTextBox
            // 
            this.MaintainPrivilegeNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sysOperationBuilderParmsBindingSource, "MaintainPrivilegeName", true));
            this.MaintainPrivilegeNameTextBox.Enabled = false;
            this.MaintainPrivilegeNameTextBox.Location = new System.Drawing.Point(6, 56);
            this.MaintainPrivilegeNameTextBox.Name = "MaintainPrivilegeNameTextBox";
            this.MaintainPrivilegeNameTextBox.Size = new System.Drawing.Size(369, 20);
            this.MaintainPrivilegeNameTextBox.TabIndex = 27;
            // 
            // MaintainPrivilegeNameLabel
            // 
            this.MaintainPrivilegeNameLabel.AutoSize = true;
            this.MaintainPrivilegeNameLabel.Location = new System.Drawing.Point(6, 39);
            this.MaintainPrivilegeNameLabel.Name = "MaintainPrivilegeNameLabel";
            this.MaintainPrivilegeNameLabel.Size = new System.Drawing.Size(79, 13);
            this.MaintainPrivilegeNameLabel.TabIndex = 26;
            this.MaintainPrivilegeNameLabel.Text = "Privilege name:";
            // 
            // CreateMaintainPrivilegeCheckBox
            // 
            this.CreateMaintainPrivilegeCheckBox.AutoSize = true;
            this.CreateMaintainPrivilegeCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.sysOperationBuilderParmsBindingSource, "CreateMaintainPrivilege", true));
            this.CreateMaintainPrivilegeCheckBox.Location = new System.Drawing.Point(8, 19);
            this.CreateMaintainPrivilegeCheckBox.Name = "CreateMaintainPrivilegeCheckBox";
            this.CreateMaintainPrivilegeCheckBox.Size = new System.Drawing.Size(105, 17);
            this.CreateMaintainPrivilegeCheckBox.TabIndex = 1;
            this.CreateMaintainPrivilegeCheckBox.Text = "Create Privileges";
            this.CreateMaintainPrivilegeCheckBox.UseVisualStyleBackColor = true;
            this.CreateMaintainPrivilegeCheckBox.CheckedChanged += new System.EventHandler(this.CreateMaintainPrivilegeCheckBox_CheckedChanged);
            // 
            // MenuItemGroup
            // 
            this.MenuItemGroup.Controls.Add(this.MenuItemNameLabel);
            this.MenuItemGroup.Controls.Add(this.MenuItemNameTextBox);
            this.MenuItemGroup.Controls.Add(this.MenuItemLabelLabel);
            this.MenuItemGroup.Controls.Add(this.MenuItemLabelTextBox);
            this.MenuItemGroup.Controls.Add(this.CreateMenuItemCheckBox);
            this.MenuItemGroup.Location = new System.Drawing.Point(15, 457);
            this.MenuItemGroup.Name = "MenuItemGroup";
            this.MenuItemGroup.Size = new System.Drawing.Size(384, 131);
            this.MenuItemGroup.TabIndex = 6;
            this.MenuItemGroup.TabStop = false;
            this.MenuItemGroup.Text = "Menu Item";
            // 
            // MenuItemNameLabel
            // 
            this.MenuItemNameLabel.AutoSize = true;
            this.MenuItemNameLabel.Location = new System.Drawing.Point(6, 79);
            this.MenuItemNameLabel.Name = "MenuItemNameLabel";
            this.MenuItemNameLabel.Size = new System.Drawing.Size(84, 13);
            this.MenuItemNameLabel.TabIndex = 24;
            this.MenuItemNameLabel.Text = "Menu item label:";
            // 
            // MenuItemNameTextBox
            // 
            this.MenuItemNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sysOperationBuilderParmsBindingSource, "MenuItemName", true));
            this.MenuItemNameTextBox.Enabled = false;
            this.MenuItemNameTextBox.Location = new System.Drawing.Point(6, 56);
            this.MenuItemNameTextBox.Name = "MenuItemNameTextBox";
            this.MenuItemNameTextBox.Size = new System.Drawing.Size(369, 20);
            this.MenuItemNameTextBox.TabIndex = 23;
            // 
            // MenuItemLabelLabel
            // 
            this.MenuItemLabelLabel.AutoSize = true;
            this.MenuItemLabelLabel.Location = new System.Drawing.Point(6, 39);
            this.MenuItemLabelLabel.Name = "MenuItemLabelLabel";
            this.MenuItemLabelLabel.Size = new System.Drawing.Size(88, 13);
            this.MenuItemLabelLabel.TabIndex = 22;
            this.MenuItemLabelLabel.Text = "Menu item name:";
            // 
            // MenuItemLabelTextBox
            // 
            this.MenuItemLabelTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sysOperationBuilderParmsBindingSource, "MenuItemLabel", true));
            this.MenuItemLabelTextBox.Enabled = false;
            this.MenuItemLabelTextBox.Location = new System.Drawing.Point(6, 95);
            this.MenuItemLabelTextBox.Name = "MenuItemLabelTextBox";
            this.MenuItemLabelTextBox.Size = new System.Drawing.Size(369, 20);
            this.MenuItemLabelTextBox.TabIndex = 25;
            // 
            // CreateMenuItemCheckBox
            // 
            this.CreateMenuItemCheckBox.AutoSize = true;
            this.CreateMenuItemCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.sysOperationBuilderParmsBindingSource, "CreateMenuItem", true));
            this.CreateMenuItemCheckBox.Location = new System.Drawing.Point(6, 19);
            this.CreateMenuItemCheckBox.Name = "CreateMenuItemCheckBox";
            this.CreateMenuItemCheckBox.Size = new System.Drawing.Size(107, 17);
            this.CreateMenuItemCheckBox.TabIndex = 1;
            this.CreateMenuItemCheckBox.Text = "Create MenuItem";
            this.CreateMenuItemCheckBox.UseVisualStyleBackColor = true;
            this.CreateMenuItemCheckBox.CheckedChanged += new System.EventHandler(this.CreateMenuItemCheckBox_CheckedChanged);
            // 
            // CreateSysOperationButton
            // 
            this.CreateSysOperationButton.Location = new System.Drawing.Point(639, 4);
            this.CreateSysOperationButton.Name = "CreateSysOperationButton";
            this.CreateSysOperationButton.Size = new System.Drawing.Size(149, 23);
            this.CreateSysOperationButton.TabIndex = 8;
            this.CreateSysOperationButton.Text = "Create SysOperation";
            this.CreateSysOperationButton.UseVisualStyleBackColor = true;
            this.CreateSysOperationButton.Click += new System.EventHandler(this.CreateSysOperationButton_Click);
            // 
            // SysOperationBuilderDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 594);
            this.Controls.Add(this.CreateSysOperationButton);
            this.Controls.Add(this.ServiceGroup);
            this.Controls.Add(this.MenuItemGroup);
            this.Controls.Add(this.PrivilegeGroup);
            this.Controls.Add(this.UIBuilderGroup);
            this.Controls.Add(this.DataContractGroup);
            this.Controls.Add(this.ControllerGroup);
            this.Controls.Add(this.SysOperationNameTextBox);
            this.Controls.Add(this.SysOperationNameLabel);
            this.Name = "SysOperationBuilderDialog";
            this.Text = "SysOperation Builder";
            ((System.ComponentModel.ISupportInitialize)(this.sysOperationBuilderParmsBindingSource)).EndInit();
            this.ServiceGroup.ResumeLayout(false);
            this.ServiceGroup.PerformLayout();
            this.ControllerGroup.ResumeLayout(false);
            this.ControllerGroup.PerformLayout();
            this.DataContractGroup.ResumeLayout(false);
            this.DataContractGroup.PerformLayout();
            this.UIBuilderGroup.ResumeLayout(false);
            this.UIBuilderGroup.PerformLayout();
            this.PrivilegeGroup.ResumeLayout(false);
            this.PrivilegeGroup.PerformLayout();
            this.MenuItemGroup.ResumeLayout(false);
            this.MenuItemGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource sysOperationBuilderParmsBindingSource;
        private System.Windows.Forms.Label SysOperationNameLabel;
        private System.Windows.Forms.TextBox SysOperationNameTextBox;
        private System.Windows.Forms.GroupBox ServiceGroup;
        private System.Windows.Forms.GroupBox ControllerGroup;
        private System.Windows.Forms.GroupBox DataContractGroup;
        private System.Windows.Forms.GroupBox UIBuilderGroup;
        private System.Windows.Forms.GroupBox PrivilegeGroup;
        private System.Windows.Forms.GroupBox MenuItemGroup;
        private System.Windows.Forms.CheckBox CreateControllerCheckBox;
        private System.Windows.Forms.CheckBox CreateDataContractCheckBox;
        private System.Windows.Forms.CheckBox CreateUIBuilderCheckBox;
        private System.Windows.Forms.CheckBox CreateMaintainPrivilegeCheckBox;
        private System.Windows.Forms.CheckBox CreateMenuItemCheckBox;
        private System.Windows.Forms.TextBox ServiceEntryMethodTextBox;
        private System.Windows.Forms.Label ServiceEntryMethodLabel;
        private System.Windows.Forms.TextBox ServiceImplementsClassTextBox;
        private System.Windows.Forms.Label ServiceImplementsClassLabel;
        private System.Windows.Forms.TextBox ServiceExtendsClassTextBox;
        private System.Windows.Forms.Label ServiceExtendsClassLabel;
        private System.Windows.Forms.TextBox ServiceClassNameTextBox;
        private System.Windows.Forms.Label ServiceClassNameLabel;
        private System.Windows.Forms.TextBox ControllerCaptionLabelTextbox;
        private System.Windows.Forms.Label ControllerCaptionLabelLabel;
        private System.Windows.Forms.TextBox ControllerImplementsClassTextBox;
        private System.Windows.Forms.Label ControllerImplementsClassLabel;
        private System.Windows.Forms.TextBox ControllerExtendsClassTextBox;
        private System.Windows.Forms.Label ControllerExtendsClassLabel;
        private System.Windows.Forms.TextBox ControllerClassNameTextBox;
        private System.Windows.Forms.Label ControllerClassNameLabel;
        private System.Windows.Forms.Button CreateSysOperationButton;
        private System.Windows.Forms.TextBox ContractClassNameTextBox;
        private System.Windows.Forms.Label ContractClassNameLabel;
        private System.Windows.Forms.CheckBox ContractIsValidatableCheckBox;
        private System.Windows.Forms.TextBox ContractImplementsClassTextBox;
        private System.Windows.Forms.Label ContractImplementsClassLabel;
        private System.Windows.Forms.TextBox ContractExtendsClassTextBox;
        private System.Windows.Forms.Label ContractExtendsClassLabel;
        private System.Windows.Forms.TextBox UIBuilderImplementsClassTextBox;
        private System.Windows.Forms.Label UIBuilderImplementationClassLabel;
        private System.Windows.Forms.TextBox UIBuilderExtendsClassTextBox;
        private System.Windows.Forms.Label UIBuilderExtendsClassLabel;
        private System.Windows.Forms.TextBox UIBuilderClassNameTextBox;
        private System.Windows.Forms.Label UIBuilderClassNameLabel;
        private System.Windows.Forms.TextBox MenuItemLabelTextBox;
        private System.Windows.Forms.Label MenuItemNameLabel;
        private System.Windows.Forms.TextBox MenuItemNameTextBox;
        private System.Windows.Forms.Label MenuItemLabelLabel;
        private System.Windows.Forms.TextBox MaintainPrivilegeLabelTextBox;
        private System.Windows.Forms.Label MaintainPrivilegeLabelLabel;
        private System.Windows.Forms.TextBox MaintainPrivilegeNameTextBox;
        private System.Windows.Forms.Label MaintainPrivilegeNameLabel;
    }
}