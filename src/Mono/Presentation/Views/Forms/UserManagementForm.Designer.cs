namespace Integrador.Presentation.Views
{
    partial class UserManagementForm
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
            txtUsername = new TextBox();
            lblUsername = new Label();
            txtPassword = new TextBox();
            lblPassword = new Label();
            btnCreateUser = new Button();
            btnSaveUserChanges = new Button();
            btnDeleteUser = new Button();
            lstUsers = new ListBox();
            grpUserRoles = new GroupBox();
            clbRoles = new CheckedListBox();
            grpSpecialPermissions = new GroupBox();
            clbSpecialPermissions = new CheckedListBox();
            grpUserRoles.SuspendLayout();
            grpSpecialPermissions.SuspendLayout();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(266, 32);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(121, 27);
            txtUsername.TabIndex = 4;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(266, 9);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(75, 20);
            lblUsername.TabIndex = 3;
            lblUsername.Text = "Username";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(393, 32);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(121, 27);
            txtPassword.TabIndex = 6;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(393, 9);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(70, 20);
            lblPassword.TabIndex = 5;
            lblPassword.Text = "Password";
            // 
            // btnCreateUser
            // 
            btnCreateUser.Location = new Point(393, 65);
            btnCreateUser.Name = "btnCreateUser";
            btnCreateUser.Size = new Size(121, 33);
            btnCreateUser.TabIndex = 9;
            btnCreateUser.Text = "Create User";
            btnCreateUser.UseVisualStyleBackColor = true;
            btnCreateUser.Click += ButtonCreateUser_Click;
            // 
            // btnSaveUserChanges
            // 
            btnSaveUserChanges.Location = new Point(266, 223);
            btnSaveUserChanges.Name = "btnSaveUserChanges";
            btnSaveUserChanges.Size = new Size(121, 33);
            btnSaveUserChanges.TabIndex = 10;
            btnSaveUserChanges.Text = "Save Changes";
            btnSaveUserChanges.UseVisualStyleBackColor = true;
            btnSaveUserChanges.Click += ButtonSaveChanges_Click;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.Location = new Point(393, 223);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(121, 33);
            btnDeleteUser.TabIndex = 11;
            btnDeleteUser.Text = "Delete User";
            btnDeleteUser.UseVisualStyleBackColor = true;
            btnDeleteUser.Click += ButtonDeleteUser_Click;
            // 
            // lstUsers
            // 
            lstUsers.FormattingEnabled = true;
            lstUsers.Location = new Point(12, 12);
            lstUsers.Name = "lstUsers";
            lstUsers.Size = new Size(248, 244);
            lstUsers.TabIndex = 12;
            lstUsers.SelectedIndexChanged += ListBoxUsers_SelectedIndexChanged;
            // 
            // grpUserRoles
            // 
            grpUserRoles.Controls.Add(clbRoles);
            grpUserRoles.Location = new Point(12, 262);
            grpUserRoles.Name = "grpUserRoles";
            grpUserRoles.Size = new Size(248, 248);
            grpUserRoles.TabIndex = 13;
            grpUserRoles.TabStop = false;
            grpUserRoles.Text = "User Roles";
            // 
            // clbRoles
            // 
            clbRoles.FormattingEnabled = true;
            clbRoles.Location = new Point(6, 26);
            clbRoles.Name = "clbRoles";
            clbRoles.Size = new Size(236, 202);
            clbRoles.TabIndex = 0;
            // 
            // grpSpecialPermissions
            // 
            grpSpecialPermissions.Controls.Add(clbSpecialPermissions);
            grpSpecialPermissions.Location = new Point(266, 262);
            grpSpecialPermissions.Name = "grpSpecialPermissions";
            grpSpecialPermissions.Size = new Size(248, 248);
            grpSpecialPermissions.TabIndex = 14;
            grpSpecialPermissions.TabStop = false;
            grpSpecialPermissions.Text = "Special Permissions";
            // 
            // clbSpecialPermissions
            // 
            clbSpecialPermissions.FormattingEnabled = true;
            clbSpecialPermissions.Location = new Point(6, 26);
            clbSpecialPermissions.Name = "clbSpecialPermissions";
            clbSpecialPermissions.Size = new Size(236, 202);
            clbSpecialPermissions.TabIndex = 0;
            // 
            // UserManagementForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(526, 519);
            Controls.Add(grpSpecialPermissions);
            Controls.Add(grpUserRoles);
            Controls.Add(lstUsers);
            Controls.Add(btnDeleteUser);
            Controls.Add(btnSaveUserChanges);
            Controls.Add(btnCreateUser);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Font = new Font("Segoe UI", 11F);
            Margin = new Padding(5, 4, 5, 4);
            MaximizeBox = false;
            Name = "UserManagementForm";
            Text = "UserManagementForm";
            grpUserRoles.ResumeLayout(false);
            grpSpecialPermissions.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtUsername;
        private Label lblUsername;
        private TextBox txtPassword;
        private Label lblPassword;
        private Button btnCreateUser;
        private Button btnSaveUserChanges;
        private Button btnDeleteUser;
        private ListBox lstUsers;
        private GroupBox grpUserRoles;
        private CheckedListBox clbRoles;
        private GroupBox grpSpecialPermissions;
        private CheckedListBox clbSpecialPermissions;
    }
}