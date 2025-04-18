namespace Integrador;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
        txtCarsCount = new TextBox();
        lblQuantity = new Label();
        txtApellido = new TextBox();
        txtNombre = new TextBox();
        txtDNI = new TextBox();
        txtPersonId = new TextBox();
        lblLastname = new Label();
        lblFirstname = new Label();
        lblIdentityNumber = new Label();
        lblPersonId = new Label();
        dgvPersonCars = new DataGridView();
        btnDeletePerson = new Button();
        btnSavePerson = new Button();
        btnNewPerson = new Button();
        dgvPersons = new DataGridView();
        txtModelo = new TextBox();
        txtPrecio = new TextBox();
        txtAño = new TextBox();
        lblYear = new Label();
        lblPrice = new Label();
        txtMarca = new TextBox();
        txtPatente = new TextBox();
        txtCarId = new TextBox();
        lblModel = new Label();
        lblBrand = new Label();
        lblLicensePlate = new Label();
        lblCarId = new Label();
        btnDeleteCar = new Button();
        btnSaveCar = new Button();
        btnNewCar = new Button();
        dgvAvailableCars = new DataGridView();
        btnAssignCar = new Button();
        btnRemoveCar = new Button();
        dgvAssignedCars = new DataGridView();
        btnLogViewer = new Button();
        cmbLanguages = new ComboBox();
        lblLanguage = new Label();
        lblPersistence = new Label();
        cmbPersistence = new ComboBox();
        btnUserManagement = new Button();
        btnRoleManagement = new Button();
        btnLogout = new Button();
        grpPersons = new GroupBox();
        grpPersonCars = new GroupBox();
        txtCarsPrice = new TextBox();
        grpAvailableCars = new GroupBox();
        grpAssignedCars = new GroupBox();
        ((System.ComponentModel.ISupportInitialize)dgvPersonCars).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dgvPersons).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dgvAvailableCars).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dgvAssignedCars).BeginInit();
        grpPersons.SuspendLayout();
        grpPersonCars.SuspendLayout();
        grpAvailableCars.SuspendLayout();
        grpAssignedCars.SuspendLayout();
        SuspendLayout();
        // 
        // txtCarsCount
        // 
        txtCarsCount.Location = new Point(81, 26);
        txtCarsCount.Name = "txtCarsCount";
        txtCarsCount.ReadOnly = true;
        txtCarsCount.Size = new Size(222, 27);
        txtCarsCount.TabIndex = 8;
        // 
        // lblQuantity
        // 
        lblQuantity.AutoSize = true;
        lblQuantity.Location = new Point(6, 29);
        lblQuantity.Name = "lblQuantity";
        lblQuantity.Size = new Size(69, 20);
        lblQuantity.TabIndex = 15;
        lblQuantity.Text = "Cantidad";
        // 
        // txtApellido
        // 
        txtApellido.Location = new Point(87, 125);
        txtApellido.Name = "txtApellido";
        txtApellido.Size = new Size(156, 27);
        txtApellido.TabIndex = 4;
        // 
        // txtNombre
        // 
        txtNombre.Location = new Point(87, 92);
        txtNombre.Name = "txtNombre";
        txtNombre.Size = new Size(156, 27);
        txtNombre.TabIndex = 3;
        // 
        // txtDNI
        // 
        txtDNI.Location = new Point(87, 59);
        txtDNI.Name = "txtDNI";
        txtDNI.Size = new Size(156, 27);
        txtDNI.TabIndex = 2;
        // 
        // txtPersonId
        // 
        txtPersonId.Location = new Point(87, 26);
        txtPersonId.Name = "txtPersonId";
        txtPersonId.ReadOnly = true;
        txtPersonId.Size = new Size(156, 27);
        txtPersonId.TabIndex = 1;
        // 
        // lblLastname
        // 
        lblLastname.AutoSize = true;
        lblLastname.Location = new Point(6, 128);
        lblLastname.Name = "lblLastname";
        lblLastname.Size = new Size(66, 20);
        lblLastname.TabIndex = 10;
        lblLastname.Text = "Apellido";
        // 
        // lblFirstname
        // 
        lblFirstname.AutoSize = true;
        lblFirstname.Location = new Point(6, 95);
        lblFirstname.Name = "lblFirstname";
        lblFirstname.Size = new Size(64, 20);
        lblFirstname.TabIndex = 9;
        lblFirstname.Text = "Nombre";
        // 
        // lblIdentityNumber
        // 
        lblIdentityNumber.AutoSize = true;
        lblIdentityNumber.Location = new Point(6, 62);
        lblIdentityNumber.Name = "lblIdentityNumber";
        lblIdentityNumber.Size = new Size(35, 20);
        lblIdentityNumber.TabIndex = 8;
        lblIdentityNumber.Text = "DNI";
        // 
        // lblPersonId
        // 
        lblPersonId.AutoSize = true;
        lblPersonId.Location = new Point(6, 29);
        lblPersonId.Name = "lblPersonId";
        lblPersonId.Size = new Size(22, 20);
        lblPersonId.TabIndex = 7;
        lblPersonId.Text = "Id";
        // 
        // dgvPersonCars
        // 
        dgvPersonCars.AllowUserToAddRows = false;
        dgvPersonCars.AllowUserToDeleteRows = false;
        dgvPersonCars.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvPersonCars.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvPersonCars.Location = new Point(6, 59);
        dgvPersonCars.Name = "dgvPersonCars";
        dgvPersonCars.ReadOnly = true;
        dgvPersonCars.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvPersonCars.Size = new Size(526, 131);
        dgvPersonCars.TabIndex = 19;
        // 
        // btnDeletePerson
        // 
        btnDeletePerson.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        btnDeletePerson.Location = new Point(168, 158);
        btnDeletePerson.Name = "btnDeletePerson";
        btnDeletePerson.Size = new Size(75, 30);
        btnDeletePerson.TabIndex = 7;
        btnDeletePerson.Text = "Eliminar";
        btnDeletePerson.UseVisualStyleBackColor = true;
        btnDeletePerson.Click += DeletePersonButton_Click;
        // 
        // btnSavePerson
        // 
        btnSavePerson.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        btnSavePerson.Location = new Point(87, 158);
        btnSavePerson.Name = "btnSavePerson";
        btnSavePerson.Size = new Size(75, 30);
        btnSavePerson.TabIndex = 6;
        btnSavePerson.Text = "Guardar";
        btnSavePerson.UseVisualStyleBackColor = true;
        btnSavePerson.Click += SavePersonButton_Click;
        // 
        // btnNewPerson
        // 
        btnNewPerson.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        btnNewPerson.Location = new Point(6, 158);
        btnNewPerson.Name = "btnNewPerson";
        btnNewPerson.Size = new Size(75, 30);
        btnNewPerson.TabIndex = 5;
        btnNewPerson.Text = "Nuevo";
        btnNewPerson.UseVisualStyleBackColor = true;
        btnNewPerson.Click += NewPersonButton_Click;
        // 
        // dgvPersons
        // 
        dgvPersons.AllowUserToAddRows = false;
        dgvPersons.AllowUserToDeleteRows = false;
        dgvPersons.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvPersons.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvPersons.Location = new Point(267, 12);
        dgvPersons.Name = "dgvPersons";
        dgvPersons.ReadOnly = true;
        dgvPersons.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvPersons.Size = new Size(463, 196);
        dgvPersons.TabIndex = 18;
        dgvPersons.SelectionChanged += PersonsDataGridView_SelectionChanged;
        // 
        // txtModelo
        // 
        txtModelo.Location = new Point(87, 130);
        txtModelo.Name = "txtModelo";
        txtModelo.Size = new Size(156, 27);
        txtModelo.TabIndex = 12;
        // 
        // txtPrecio
        // 
        txtPrecio.Location = new Point(87, 199);
        txtPrecio.Name = "txtPrecio";
        txtPrecio.Size = new Size(156, 27);
        txtPrecio.TabIndex = 14;
        // 
        // txtAño
        // 
        txtAño.Location = new Point(87, 164);
        txtAño.Name = "txtAño";
        txtAño.Size = new Size(156, 27);
        txtAño.TabIndex = 13;
        // 
        // lblYear
        // 
        lblYear.AutoSize = true;
        lblYear.Location = new Point(6, 167);
        lblYear.Name = "lblYear";
        lblYear.Size = new Size(36, 20);
        lblYear.TabIndex = 17;
        lblYear.Text = "Año";
        // 
        // lblPrice
        // 
        lblPrice.AutoSize = true;
        lblPrice.Location = new Point(6, 202);
        lblPrice.Name = "lblPrice";
        lblPrice.Size = new Size(50, 20);
        lblPrice.TabIndex = 16;
        lblPrice.Text = "Precio";
        // 
        // txtMarca
        // 
        txtMarca.Location = new Point(87, 95);
        txtMarca.Name = "txtMarca";
        txtMarca.Size = new Size(156, 27);
        txtMarca.TabIndex = 11;
        // 
        // txtPatente
        // 
        txtPatente.Location = new Point(87, 60);
        txtPatente.Name = "txtPatente";
        txtPatente.Size = new Size(156, 27);
        txtPatente.TabIndex = 10;
        // 
        // txtCarId
        // 
        txtCarId.Location = new Point(87, 26);
        txtCarId.Name = "txtCarId";
        txtCarId.ReadOnly = true;
        txtCarId.Size = new Size(156, 27);
        txtCarId.TabIndex = 9;
        // 
        // lblModel
        // 
        lblModel.AutoSize = true;
        lblModel.Location = new Point(6, 133);
        lblModel.Name = "lblModel";
        lblModel.Size = new Size(61, 20);
        lblModel.TabIndex = 10;
        lblModel.Text = "Modelo";
        // 
        // lblBrand
        // 
        lblBrand.AutoSize = true;
        lblBrand.Location = new Point(6, 98);
        lblBrand.Name = "lblBrand";
        lblBrand.Size = new Size(50, 20);
        lblBrand.TabIndex = 9;
        lblBrand.Text = "Marca";
        // 
        // lblLicensePlate
        // 
        lblLicensePlate.AutoSize = true;
        lblLicensePlate.Location = new Point(6, 63);
        lblLicensePlate.Name = "lblLicensePlate";
        lblLicensePlate.Size = new Size(95, 20);
        lblLicensePlate.TabIndex = 8;
        lblLicensePlate.Text = "License plate";
        // 
        // lblCarId
        // 
        lblCarId.AutoSize = true;
        lblCarId.Location = new Point(6, 29);
        lblCarId.Name = "lblCarId";
        lblCarId.Size = new Size(22, 20);
        lblCarId.TabIndex = 7;
        lblCarId.Text = "Id";
        // 
        // btnDeleteCar
        // 
        btnDeleteCar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        btnDeleteCar.Location = new Point(168, 232);
        btnDeleteCar.Name = "btnDeleteCar";
        btnDeleteCar.Size = new Size(75, 30);
        btnDeleteCar.TabIndex = 17;
        btnDeleteCar.Text = "Eliminar";
        btnDeleteCar.UseVisualStyleBackColor = true;
        btnDeleteCar.Click += DeleteCarButton_Click;
        // 
        // btnSaveCar
        // 
        btnSaveCar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        btnSaveCar.Location = new Point(87, 232);
        btnSaveCar.Name = "btnSaveCar";
        btnSaveCar.Size = new Size(75, 30);
        btnSaveCar.TabIndex = 16;
        btnSaveCar.Text = "Guardar";
        btnSaveCar.UseVisualStyleBackColor = true;
        btnSaveCar.Click += SaveCarButton_Click;
        // 
        // btnNewCar
        // 
        btnNewCar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        btnNewCar.Location = new Point(6, 232);
        btnNewCar.Name = "btnNewCar";
        btnNewCar.Size = new Size(75, 30);
        btnNewCar.TabIndex = 15;
        btnNewCar.Text = "Nuevo";
        btnNewCar.UseVisualStyleBackColor = true;
        btnNewCar.Click += NewCarButton_Click;
        // 
        // dgvAvailableCars
        // 
        dgvAvailableCars.AllowUserToAddRows = false;
        dgvAvailableCars.AllowUserToDeleteRows = false;
        dgvAvailableCars.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvAvailableCars.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvAvailableCars.Location = new Point(267, 256);
        dgvAvailableCars.Name = "dgvAvailableCars";
        dgvAvailableCars.ReadOnly = true;
        dgvAvailableCars.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvAvailableCars.Size = new Size(463, 270);
        dgvAvailableCars.TabIndex = 22;
        // 
        // btnAssignCar
        // 
        btnAssignCar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        btnAssignCar.Image = (Image)resources.GetObject("btnAssignCar.Image");
        btnAssignCar.Location = new Point(267, 214);
        btnAssignCar.Name = "btnAssignCar";
        btnAssignCar.Size = new Size(101, 36);
        btnAssignCar.TabIndex = 20;
        btnAssignCar.Text = "Asignar";
        btnAssignCar.TextAlign = ContentAlignment.MiddleRight;
        btnAssignCar.TextImageRelation = TextImageRelation.ImageBeforeText;
        btnAssignCar.UseVisualStyleBackColor = true;
        btnAssignCar.Click += AssignCarButton_Click;
        // 
        // btnRemoveCar
        // 
        btnRemoveCar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        btnRemoveCar.Image = (Image)resources.GetObject("btnRemoveCar.Image");
        btnRemoveCar.Location = new Point(629, 214);
        btnRemoveCar.Name = "btnRemoveCar";
        btnRemoveCar.Size = new Size(101, 36);
        btnRemoveCar.TabIndex = 21;
        btnRemoveCar.Text = "Quitar";
        btnRemoveCar.TextAlign = ContentAlignment.MiddleRight;
        btnRemoveCar.TextImageRelation = TextImageRelation.TextBeforeImage;
        btnRemoveCar.UseVisualStyleBackColor = true;
        btnRemoveCar.Click += RemoveCarButton_Click;
        // 
        // dgvAssignedCars
        // 
        dgvAssignedCars.AllowUserToAddRows = false;
        dgvAssignedCars.AllowUserToDeleteRows = false;
        dgvAssignedCars.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvAssignedCars.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvAssignedCars.Location = new Point(6, 26);
        dgvAssignedCars.Name = "dgvAssignedCars";
        dgvAssignedCars.ReadOnly = true;
        dgvAssignedCars.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvAssignedCars.Size = new Size(525, 236);
        dgvAssignedCars.TabIndex = 23;
        // 
        // btnLogViewer
        // 
        btnLogViewer.Location = new Point(655, 568);
        btnLogViewer.Name = "btnLogViewer";
        btnLogViewer.Size = new Size(150, 30);
        btnLogViewer.TabIndex = 24;
        btnLogViewer.Text = "Log Viewer";
        btnLogViewer.UseVisualStyleBackColor = true;
        btnLogViewer.Click += ButtonViewLog_Click;
        // 
        // cmbLanguages
        // 
        cmbLanguages.FormattingEnabled = true;
        cmbLanguages.Items.AddRange(new object[] { "Español", "English" });
        cmbLanguages.Location = new Point(99, 570);
        cmbLanguages.Name = "cmbLanguages";
        cmbLanguages.Size = new Size(150, 28);
        cmbLanguages.TabIndex = 25;
        cmbLanguages.SelectedIndexChanged += ComboBoxLanguages_SelectedIndexChanged;
        // 
        // lblLanguage
        // 
        lblLanguage.AutoSize = true;
        lblLanguage.Location = new Point(12, 573);
        lblLanguage.Name = "lblLanguage";
        lblLanguage.Size = new Size(56, 20);
        lblLanguage.TabIndex = 26;
        lblLanguage.Text = "Idioma";
        // 
        // lblPersistence
        // 
        lblPersistence.AutoSize = true;
        lblPersistence.Location = new Point(267, 573);
        lblPersistence.Name = "lblPersistence";
        lblPersistence.Size = new Size(85, 20);
        lblPersistence.TabIndex = 27;
        lblPersistence.Text = "Persistencia";
        // 
        // cmbPersistence
        // 
        cmbPersistence.FormattingEnabled = true;
        cmbPersistence.Location = new Point(348, 570);
        cmbPersistence.Name = "cmbPersistence";
        cmbPersistence.Size = new Size(150, 28);
        cmbPersistence.TabIndex = 28;
        cmbPersistence.SelectedIndexChanged += ComboBoxPersistence_SelectedIndexChanged;
        // 
        // btnUserManagement
        // 
        btnUserManagement.Location = new Point(967, 568);
        btnUserManagement.Name = "btnUserManagement";
        btnUserManagement.Size = new Size(150, 30);
        btnUserManagement.TabIndex = 29;
        btnUserManagement.Text = "User Management";
        btnUserManagement.UseVisualStyleBackColor = true;
        btnUserManagement.Click += ButtonUserManagement_Click;
        // 
        // btnRoleManagement
        // 
        btnRoleManagement.Location = new Point(811, 568);
        btnRoleManagement.Name = "btnRoleManagement";
        btnRoleManagement.Size = new Size(150, 30);
        btnRoleManagement.TabIndex = 30;
        btnRoleManagement.Text = "Role Management";
        btnRoleManagement.UseVisualStyleBackColor = true;
        btnRoleManagement.Click += ButtonRoleManagement_Click;
        // 
        // btnLogout
        // 
        btnLogout.Location = new Point(1123, 568);
        btnLogout.Name = "btnLogout";
        btnLogout.Size = new Size(150, 30);
        btnLogout.TabIndex = 31;
        btnLogout.Text = "Logout";
        btnLogout.UseVisualStyleBackColor = true;
        btnLogout.Click += ButtonLogout_Click;
        // 
        // grpPersons
        // 
        grpPersons.Controls.Add(btnDeletePerson);
        grpPersons.Controls.Add(btnSavePerson);
        grpPersons.Controls.Add(btnNewPerson);
        grpPersons.Controls.Add(txtPersonId);
        grpPersons.Controls.Add(lblIdentityNumber);
        grpPersons.Controls.Add(lblFirstname);
        grpPersons.Controls.Add(lblPersonId);
        grpPersons.Controls.Add(lblLastname);
        grpPersons.Controls.Add(txtDNI);
        grpPersons.Controls.Add(txtNombre);
        grpPersons.Controls.Add(txtApellido);
        grpPersons.Location = new Point(12, 12);
        grpPersons.Name = "grpPersons";
        grpPersons.Size = new Size(249, 196);
        grpPersons.TabIndex = 32;
        grpPersons.TabStop = false;
        grpPersons.Text = "Personas";
        // 
        // grpPersonCars
        // 
        grpPersonCars.Controls.Add(txtCarsPrice);
        grpPersonCars.Controls.Add(dgvPersonCars);
        grpPersonCars.Controls.Add(txtCarsCount);
        grpPersonCars.Controls.Add(lblQuantity);
        grpPersonCars.Location = new Point(736, 12);
        grpPersonCars.Name = "grpPersonCars";
        grpPersonCars.Size = new Size(537, 196);
        grpPersonCars.TabIndex = 33;
        grpPersonCars.TabStop = false;
        grpPersonCars.Text = "Autos de persona";
        // 
        // txtCarsPrice
        // 
        txtCarsPrice.Location = new Point(309, 26);
        txtCarsPrice.Name = "txtCarsPrice";
        txtCarsPrice.ReadOnly = true;
        txtCarsPrice.Size = new Size(222, 27);
        txtCarsPrice.TabIndex = 20;
        // 
        // grpAvailableCars
        // 
        grpAvailableCars.Controls.Add(txtCarId);
        grpAvailableCars.Controls.Add(lblCarId);
        grpAvailableCars.Controls.Add(lblLicensePlate);
        grpAvailableCars.Controls.Add(txtPatente);
        grpAvailableCars.Controls.Add(lblBrand);
        grpAvailableCars.Controls.Add(txtMarca);
        grpAvailableCars.Controls.Add(lblModel);
        grpAvailableCars.Controls.Add(lblYear);
        grpAvailableCars.Controls.Add(txtAño);
        grpAvailableCars.Controls.Add(txtModelo);
        grpAvailableCars.Controls.Add(lblPrice);
        grpAvailableCars.Controls.Add(btnDeleteCar);
        grpAvailableCars.Controls.Add(btnNewCar);
        grpAvailableCars.Controls.Add(btnSaveCar);
        grpAvailableCars.Controls.Add(txtPrecio);
        grpAvailableCars.Location = new Point(12, 256);
        grpAvailableCars.Name = "grpAvailableCars";
        grpAvailableCars.Size = new Size(249, 270);
        grpAvailableCars.TabIndex = 34;
        grpAvailableCars.TabStop = false;
        grpAvailableCars.Text = "Autos disponibles";
        // 
        // grpAssignedCars
        // 
        grpAssignedCars.Controls.Add(dgvAssignedCars);
        grpAssignedCars.Location = new Point(736, 256);
        grpAssignedCars.Name = "grpAssignedCars";
        grpAssignedCars.Size = new Size(537, 270);
        grpAssignedCars.TabIndex = 35;
        grpAssignedCars.TabStop = false;
        grpAssignedCars.Text = "Autos asignados";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.Ivory;
        ClientSize = new Size(1283, 615);
        Controls.Add(grpAssignedCars);
        Controls.Add(grpAvailableCars);
        Controls.Add(grpPersonCars);
        Controls.Add(grpPersons);
        Controls.Add(btnLogout);
        Controls.Add(btnRoleManagement);
        Controls.Add(btnUserManagement);
        Controls.Add(cmbPersistence);
        Controls.Add(lblPersistence);
        Controls.Add(lblLanguage);
        Controls.Add(cmbLanguages);
        Controls.Add(btnLogViewer);
        Controls.Add(btnAssignCar);
        Controls.Add(btnRemoveCar);
        Controls.Add(dgvPersons);
        Controls.Add(dgvAvailableCars);
        Font = new Font("Segoe UI", 11F);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Margin = new Padding(5, 4, 5, 4);
        MaximizeBox = false;
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "MainForm";
        Load += MainForm_Load;
        ((System.ComponentModel.ISupportInitialize)dgvPersonCars).EndInit();
        ((System.ComponentModel.ISupportInitialize)dgvPersons).EndInit();
        ((System.ComponentModel.ISupportInitialize)dgvAvailableCars).EndInit();
        ((System.ComponentModel.ISupportInitialize)dgvAssignedCars).EndInit();
        grpPersons.ResumeLayout(false);
        grpPersons.PerformLayout();
        grpPersonCars.ResumeLayout(false);
        grpPersonCars.PerformLayout();
        grpAvailableCars.ResumeLayout(false);
        grpAvailableCars.PerformLayout();
        grpAssignedCars.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    internal DataGridView dgvPersons;
    internal Button btnDeletePerson;
    internal Button btnSavePerson;
    internal Button btnNewPerson;
    internal DataGridView dgvPersonCars;
    internal Label lblLastname;
    internal Label lblFirstname;
    internal Label lblIdentityNumber;
    internal Label lblPersonId;
    internal TextBox txtApellido;
    internal TextBox txtNombre;
    internal TextBox txtDNI;
    internal TextBox txtPersonId;
    internal TextBox txtMarca;
    internal TextBox txtPatente;
    internal TextBox txtCarId;
    internal Label lblModel;
    internal Label lblBrand;
    internal Label lblLicensePlate;
    internal Label lblCarId;
    internal Button btnDeleteCar;
    internal Button btnSaveCar;
    internal Button btnNewCar;
    internal DataGridView dgvAvailableCars;
    internal Label lblPrice;
    internal Button btnAssignCar;
    internal Button btnRemoveCar;
    internal DataGridView dgvAssignedCars;
    internal TextBox txtAño;
    internal Label lblYear;
    internal TextBox txtPrecio;
    internal TextBox txtCarsCount;
    internal Label lblQuantity;
    private TextBox txtModelo;
    private Button btnLogViewer;
    private ComboBox cmbLanguages;
    private Label lblLanguage;
    private Label lblPersistence;
    private ComboBox cmbPersistence;
    private Button btnUserManagement;
    private Button btnRoleManagement;
    private Button btnLogout;
    private GroupBox grpPersons;
    private GroupBox grpPersonCars;
    internal TextBox txtCarsPrice;
    private GroupBox grpAvailableCars;
    private GroupBox grpAssignedCars;
}
