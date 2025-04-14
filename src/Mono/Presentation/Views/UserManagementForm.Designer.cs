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
            dgvUsers = new DataGridView();
            lblId = new Label();
            txtId = new TextBox();
            txtUsername = new TextBox();
            lblUsername = new Label();
            txtPassword = new TextBox();
            lblPassword = new Label();
            lblRole = new Label();
            cmbRole = new ComboBox();
            btnNew = new Button();
            btnSave = new Button();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            SuspendLayout();
            // 
            // dgvUsers
            // 
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Location = new Point(12, 12);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.Size = new Size(830, 194);
            dgvUsers.TabIndex = 0;
            dgvUsers.SelectionChanged += DgvUsers_SelectionChanged;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(52, 258);
            lblId.Name = "lblId";
            lblId.Size = new Size(20, 18);
            lblId.TabIndex = 1;
            lblId.Text = "Id";
            // 
            // txtId
            // 
            txtId.Location = new Point(129, 255);
            txtId.Name = "txtId";
            txtId.Size = new Size(100, 25);
            txtId.TabIndex = 2;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(129, 299);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(100, 25);
            txtUsername.TabIndex = 4;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(52, 302);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(71, 18);
            lblUsername.TabIndex = 3;
            lblUsername.Text = "Username";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(129, 344);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(100, 25);
            txtPassword.TabIndex = 6;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(52, 347);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(67, 18);
            lblPassword.TabIndex = 5;
            lblPassword.Text = "Password";
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Location = new Point(52, 408);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(36, 18);
            lblRole.TabIndex = 7;
            lblRole.Text = "Role";
            // 
            // cmbRole
            // 
            cmbRole.FormattingEnabled = true;
            cmbRole.Location = new Point(129, 405);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(121, 26);
            cmbRole.TabIndex = 8;
            // 
            // btnNew
            // 
            btnNew.Location = new Point(66, 486);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(100, 30);
            btnNew.TabIndex = 9;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(172, 486);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 30);
            btnSave.TabIndex = 10;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(283, 486);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 30);
            btnDelete.TabIndex = 11;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // UserManagementForm
            // 
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(915, 540);
            Controls.Add(btnDelete);
            Controls.Add(btnSave);
            Controls.Add(btnNew);
            Controls.Add(cmbRole);
            Controls.Add(lblRole);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Controls.Add(txtId);
            Controls.Add(lblId);
            Controls.Add(dgvUsers);
            Font = new Font("Calibri", 11F);
            Margin = new Padding(4);
            Name = "UserManagementForm";
            Text = "UserManagementForm";
            Load += UserManagementForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvUsers;
        private Label lblId;
        private TextBox txtId;
        private TextBox txtUsername;
        private Label lblUsername;
        private TextBox txtPassword;
        private Label lblPassword;
        private Label lblRole;
        private ComboBox cmbRole;
        private Button btnNew;
        private Button btnSave;
        private Button btnDelete;
    }
}