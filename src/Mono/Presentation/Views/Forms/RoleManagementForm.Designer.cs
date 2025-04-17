namespace Integrador.Presentation.Views.Forms
{
    partial class RoleManagementForm
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
            lblRoleName = new Label();
            txtRoleName = new TextBox();
            btnCreateRole = new Button();
            lstRoles = new ListBox();
            btnDeleteRole = new Button();
            grpPermissions = new GroupBox();
            btnSavePermissions = new Button();
            clbPermissions = new CheckedListBox();
            grpPermissions.SuspendLayout();
            SuspendLayout();
            // 
            // lblRoleName
            // 
            lblRoleName.AutoSize = true;
            lblRoleName.Location = new Point(253, 9);
            lblRoleName.Name = "lblRoleName";
            lblRoleName.Size = new Size(115, 20);
            lblRoleName.TabIndex = 0;
            lblRoleName.Text = "Nombre del Rol";
            // 
            // txtRoleName
            // 
            txtRoleName.Location = new Point(253, 33);
            txtRoleName.Margin = new Padding(3, 4, 3, 4);
            txtRoleName.Name = "txtRoleName";
            txtRoleName.Size = new Size(114, 27);
            txtRoleName.TabIndex = 1;
            // 
            // btnCreateRole
            // 
            btnCreateRole.Location = new Point(253, 67);
            btnCreateRole.Name = "btnCreateRole";
            btnCreateRole.Size = new Size(114, 28);
            btnCreateRole.TabIndex = 2;
            btnCreateRole.Text = "Crear Rol";
            btnCreateRole.UseVisualStyleBackColor = true;
            btnCreateRole.Click += ButtonCreateRole_Click;
            // 
            // lstRoles
            // 
            lstRoles.FormattingEnabled = true;
            lstRoles.Location = new Point(12, 12);
            lstRoles.Name = "lstRoles";
            lstRoles.Size = new Size(235, 224);
            lstRoles.TabIndex = 3;
            lstRoles.SelectedIndexChanged += ListBoxRoles_SelectedIndexChanged;
            // 
            // btnDeleteRole
            // 
            btnDeleteRole.Location = new Point(254, 208);
            btnDeleteRole.Name = "btnDeleteRole";
            btnDeleteRole.Size = new Size(114, 28);
            btnDeleteRole.TabIndex = 4;
            btnDeleteRole.Text = "Eliminar Rol";
            btnDeleteRole.UseVisualStyleBackColor = true;
            btnDeleteRole.Click += ButtonDeleteRole_Click;
            // 
            // grpPermissions
            // 
            grpPermissions.Controls.Add(btnSavePermissions);
            grpPermissions.Controls.Add(clbPermissions);
            grpPermissions.Location = new Point(12, 242);
            grpPermissions.Name = "grpPermissions";
            grpPermissions.Size = new Size(356, 235);
            grpPermissions.TabIndex = 5;
            grpPermissions.TabStop = false;
            grpPermissions.Text = "Asignación de Permisos";
            // 
            // btnSavePermissions
            // 
            btnSavePermissions.Location = new Point(241, 200);
            btnSavePermissions.Name = "btnSavePermissions";
            btnSavePermissions.Size = new Size(112, 28);
            btnSavePermissions.TabIndex = 7;
            btnSavePermissions.Text = "Guardar Permisos";
            btnSavePermissions.UseVisualStyleBackColor = true;
            btnSavePermissions.Click += ButtonSavePermissions_Click;
            // 
            // chkPermissions
            // 
            clbPermissions.FormattingEnabled = true;
            clbPermissions.Location = new Point(6, 26);
            clbPermissions.Name = "chkPermissions";
            clbPermissions.Size = new Size(229, 202);
            clbPermissions.TabIndex = 6;
            // 
            // RoleManagementForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(379, 488);
            Controls.Add(grpPermissions);
            Controls.Add(btnDeleteRole);
            Controls.Add(lstRoles);
            Controls.Add(btnCreateRole);
            Controls.Add(txtRoleName);
            Controls.Add(lblRoleName);
            Font = new Font("Segoe UI", 11F);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "RoleManagementForm";
            Text = "RoleManagementForm";
            grpPermissions.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblRoleName;
        private TextBox txtRoleName;
        private Button btnCreateRole;
        private ListBox lstRoles;
        private Button btnDeleteRole;
        private GroupBox grpPermissions;
        private CheckedListBox clbPermissions;
        private Button btnSavePermissions;
    }
}