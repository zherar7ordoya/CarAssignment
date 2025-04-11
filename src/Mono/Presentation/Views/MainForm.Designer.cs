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
        lblIdentityCard = new Label();
        lblPersonId = new Label();
        lblCarsPrice = new Label();
        dgvPersonCars = new DataGridView();
        btnDeletePerson = new Button();
        btnSavePerson = new Button();
        btnNewPerson = new Button();
        dgvPersons = new DataGridView();
        lblPersons = new Label();
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
        lblAvailableCars = new Label();
        btnAssignCar = new Button();
        btnRemoveCar = new Button();
        dgvAssignedCars = new DataGridView();
        lblAssignedCars = new Label();
        lblPersonCars = new Label();
        btnViewLog = new Button();
        ((System.ComponentModel.ISupportInitialize)dgvPersonCars).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dgvPersons).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dgvAvailableCars).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dgvAssignedCars).BeginInit();
        SuspendLayout();
        // 
        // txtCarsCount
        // 
        txtCarsCount.Location = new Point(107, 250);
        txtCarsCount.Name = "txtCarsCount";
        txtCarsCount.ReadOnly = true;
        txtCarsCount.Size = new Size(222, 25);
        txtCarsCount.TabIndex = 8;
        // 
        // lblQuantity
        // 
        lblQuantity.AutoSize = true;
        lblQuantity.Location = new Point(12, 253);
        lblQuantity.Name = "lblQuantity";
        lblQuantity.Size = new Size(62, 18);
        lblQuantity.TabIndex = 15;
        lblQuantity.Text = "Cantidad";
        // 
        // txtApellido
        // 
        txtApellido.Location = new Point(107, 145);
        txtApellido.Name = "txtApellido";
        txtApellido.Size = new Size(222, 25);
        txtApellido.TabIndex = 4;
        // 
        // txtNombre
        // 
        txtNombre.Location = new Point(107, 114);
        txtNombre.Name = "txtNombre";
        txtNombre.Size = new Size(222, 25);
        txtNombre.TabIndex = 3;
        // 
        // txtDNI
        // 
        txtDNI.Location = new Point(107, 83);
        txtDNI.Name = "txtDNI";
        txtDNI.Size = new Size(222, 25);
        txtDNI.TabIndex = 2;
        // 
        // txtPersonId
        // 
        txtPersonId.Location = new Point(107, 52);
        txtPersonId.Name = "txtPersonId";
        txtPersonId.ReadOnly = true;
        txtPersonId.Size = new Size(222, 25);
        txtPersonId.TabIndex = 1;
        // 
        // lblLastname
        // 
        lblLastname.AutoSize = true;
        lblLastname.Location = new Point(12, 148);
        lblLastname.Name = "lblLastname";
        lblLastname.Size = new Size(61, 18);
        lblLastname.TabIndex = 10;
        lblLastname.Text = "Apellido";
        // 
        // lblFirstname
        // 
        lblFirstname.AutoSize = true;
        lblFirstname.Location = new Point(12, 117);
        lblFirstname.Name = "lblFirstname";
        lblFirstname.Size = new Size(59, 18);
        lblFirstname.TabIndex = 9;
        lblFirstname.Text = "Nombre";
        // 
        // lblIdentityCard
        // 
        lblIdentityCard.AutoSize = true;
        lblIdentityCard.Location = new Point(12, 86);
        lblIdentityCard.Name = "lblIdentityCard";
        lblIdentityCard.Size = new Size(31, 18);
        lblIdentityCard.TabIndex = 8;
        lblIdentityCard.Text = "DNI";
        // 
        // lblPersonId
        // 
        lblPersonId.AutoSize = true;
        lblPersonId.Location = new Point(12, 55);
        lblPersonId.Name = "lblPersonId";
        lblPersonId.Size = new Size(20, 18);
        lblPersonId.TabIndex = 7;
        lblPersonId.Text = "Id";
        // 
        // lblCarsPrice
        // 
        lblCarsPrice.Font = new Font("Calibri", 22F);
        lblCarsPrice.Location = new Point(107, 278);
        lblCarsPrice.Name = "lblCarsPrice";
        lblCarsPrice.Size = new Size(222, 37);
        lblCarsPrice.TabIndex = 6;
        lblCarsPrice.Text = "Total";
        lblCarsPrice.TextAlign = ContentAlignment.MiddleRight;
        // 
        // dgvPersonCars
        // 
        dgvPersonCars.AllowUserToAddRows = false;
        dgvPersonCars.AllowUserToDeleteRows = false;
        dgvPersonCars.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvPersonCars.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvPersonCars.Location = new Point(335, 210);
        dgvPersonCars.Name = "dgvPersonCars";
        dgvPersonCars.ReadOnly = true;
        dgvPersonCars.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvPersonCars.Size = new Size(526, 105);
        dgvPersonCars.TabIndex = 19;
        // 
        // btnDeletePerson
        // 
        btnDeletePerson.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        btnDeletePerson.Location = new Point(259, 176);
        btnDeletePerson.Name = "btnDeletePerson";
        btnDeletePerson.Size = new Size(70, 28);
        btnDeletePerson.TabIndex = 7;
        btnDeletePerson.Text = "Eliminar";
        btnDeletePerson.UseVisualStyleBackColor = true;
        btnDeletePerson.Click += DeletePersonButton_Click;
        // 
        // btnSavePerson
        // 
        btnSavePerson.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        btnSavePerson.Location = new Point(183, 176);
        btnSavePerson.Name = "btnSavePerson";
        btnSavePerson.Size = new Size(70, 28);
        btnSavePerson.TabIndex = 6;
        btnSavePerson.Text = "Guardar";
        btnSavePerson.UseVisualStyleBackColor = true;
        btnSavePerson.Click += SavePersonButton_Click;
        // 
        // btnNewPerson
        // 
        btnNewPerson.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        btnNewPerson.Location = new Point(107, 176);
        btnNewPerson.Name = "btnNewPerson";
        btnNewPerson.Size = new Size(70, 28);
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
        dgvPersons.Location = new Point(335, 12);
        dgvPersons.Name = "dgvPersons";
        dgvPersons.ReadOnly = true;
        dgvPersons.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvPersons.Size = new Size(526, 192);
        dgvPersons.TabIndex = 18;
        dgvPersons.SelectionChanged += PersonsDataGridView_SelectionChanged;
        // 
        // lblPersons
        // 
        lblPersons.AutoSize = true;
        lblPersons.Font = new Font("Calibri", 22F);
        lblPersons.Location = new Point(12, 12);
        lblPersons.Name = "lblPersons";
        lblPersons.Size = new Size(126, 37);
        lblPersons.TabIndex = 0;
        lblPersons.Text = "Personas";
        // 
        // txtModelo
        // 
        txtModelo.Location = new Point(107, 492);
        txtModelo.Name = "txtModelo";
        txtModelo.Size = new Size(222, 25);
        txtModelo.TabIndex = 12;
        // 
        // txtPrecio
        // 
        txtPrecio.Location = new Point(107, 554);
        txtPrecio.Name = "txtPrecio";
        txtPrecio.Size = new Size(222, 25);
        txtPrecio.TabIndex = 14;
        // 
        // txtAño
        // 
        txtAño.Location = new Point(107, 523);
        txtAño.Name = "txtAño";
        txtAño.Size = new Size(222, 25);
        txtAño.TabIndex = 13;
        // 
        // lblYear
        // 
        lblYear.AutoSize = true;
        lblYear.Location = new Point(12, 525);
        lblYear.Name = "lblYear";
        lblYear.Size = new Size(33, 18);
        lblYear.TabIndex = 17;
        lblYear.Text = "Año";
        // 
        // lblPrice
        // 
        lblPrice.AutoSize = true;
        lblPrice.Location = new Point(12, 557);
        lblPrice.Name = "lblPrice";
        lblPrice.Size = new Size(47, 18);
        lblPrice.TabIndex = 16;
        lblPrice.Text = "Precio";
        // 
        // txtMarca
        // 
        txtMarca.Location = new Point(107, 461);
        txtMarca.Name = "txtMarca";
        txtMarca.Size = new Size(222, 25);
        txtMarca.TabIndex = 11;
        // 
        // txtPatente
        // 
        txtPatente.Location = new Point(107, 430);
        txtPatente.Name = "txtPatente";
        txtPatente.Size = new Size(222, 25);
        txtPatente.TabIndex = 10;
        // 
        // txtCarId
        // 
        txtCarId.Location = new Point(107, 399);
        txtCarId.Name = "txtCarId";
        txtCarId.ReadOnly = true;
        txtCarId.Size = new Size(222, 25);
        txtCarId.TabIndex = 9;
        // 
        // lblModel
        // 
        lblModel.AutoSize = true;
        lblModel.Location = new Point(12, 495);
        lblModel.Name = "lblModel";
        lblModel.Size = new Size(56, 18);
        lblModel.TabIndex = 10;
        lblModel.Text = "Modelo";
        // 
        // lblBrand
        // 
        lblBrand.AutoSize = true;
        lblBrand.Location = new Point(12, 464);
        lblBrand.Name = "lblBrand";
        lblBrand.Size = new Size(45, 18);
        lblBrand.TabIndex = 9;
        lblBrand.Text = "Marca";
        // 
        // lblLicensePlate
        // 
        lblLicensePlate.AutoSize = true;
        lblLicensePlate.Location = new Point(12, 433);
        lblLicensePlate.Name = "lblLicensePlate";
        lblLicensePlate.Size = new Size(89, 18);
        lblLicensePlate.TabIndex = 8;
        lblLicensePlate.Text = "License plate";
        // 
        // lblCarId
        // 
        lblCarId.AutoSize = true;
        lblCarId.Location = new Point(12, 402);
        lblCarId.Name = "lblCarId";
        lblCarId.Size = new Size(20, 18);
        lblCarId.TabIndex = 7;
        lblCarId.Text = "Id";
        // 
        // btnDeleteCar
        // 
        btnDeleteCar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        btnDeleteCar.Location = new Point(259, 585);
        btnDeleteCar.Name = "btnDeleteCar";
        btnDeleteCar.Size = new Size(70, 28);
        btnDeleteCar.TabIndex = 17;
        btnDeleteCar.Text = "Eliminar";
        btnDeleteCar.UseVisualStyleBackColor = true;
        btnDeleteCar.Click += DeleteCarButton_Click;
        // 
        // btnSaveCar
        // 
        btnSaveCar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        btnSaveCar.Location = new Point(183, 585);
        btnSaveCar.Name = "btnSaveCar";
        btnSaveCar.Size = new Size(70, 28);
        btnSaveCar.TabIndex = 16;
        btnSaveCar.Text = "Guardar";
        btnSaveCar.UseVisualStyleBackColor = true;
        btnSaveCar.Click += SaveCarButton_Click;
        // 
        // btnNewCar
        // 
        btnNewCar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        btnNewCar.Location = new Point(107, 585);
        btnNewCar.Name = "btnNewCar";
        btnNewCar.Size = new Size(70, 28);
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
        dgvAvailableCars.Location = new Point(335, 359);
        dgvAvailableCars.Name = "dgvAvailableCars";
        dgvAvailableCars.ReadOnly = true;
        dgvAvailableCars.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvAvailableCars.Size = new Size(526, 254);
        dgvAvailableCars.TabIndex = 22;
        // 
        // lblAvailableCars
        // 
        lblAvailableCars.AutoSize = true;
        lblAvailableCars.Font = new Font("Calibri", 22F);
        lblAvailableCars.Location = new Point(12, 359);
        lblAvailableCars.Name = "lblAvailableCars";
        lblAvailableCars.Size = new Size(235, 37);
        lblAvailableCars.TabIndex = 0;
        lblAvailableCars.Text = "Autos disponibles";
        lblAvailableCars.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // btnAssignCar
        // 
        btnAssignCar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        btnAssignCar.Image = (Image)resources.GetObject("btnAssignCar.Image");
        btnAssignCar.Location = new Point(335, 321);
        btnAssignCar.Name = "btnAssignCar";
        btnAssignCar.Size = new Size(100, 32);
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
        btnRemoveCar.Location = new Point(761, 321);
        btnRemoveCar.Name = "btnRemoveCar";
        btnRemoveCar.Size = new Size(100, 32);
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
        dgvAssignedCars.Location = new Point(335, 619);
        dgvAssignedCars.Name = "dgvAssignedCars";
        dgvAssignedCars.ReadOnly = true;
        dgvAssignedCars.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvAssignedCars.Size = new Size(809, 159);
        dgvAssignedCars.TabIndex = 23;
        // 
        // lblAssignedCars
        // 
        lblAssignedCars.AutoSize = true;
        lblAssignedCars.Font = new Font("Calibri", 22F);
        lblAssignedCars.Location = new Point(12, 616);
        lblAssignedCars.Name = "lblAssignedCars";
        lblAssignedCars.Size = new Size(216, 37);
        lblAssignedCars.TabIndex = 18;
        lblAssignedCars.Text = "Autos asignados";
        // 
        // lblPersonCars
        // 
        lblPersonCars.AutoSize = true;
        lblPersonCars.Font = new Font("Calibri", 22F);
        lblPersonCars.Location = new Point(12, 210);
        lblPersonCars.Name = "lblPersonCars";
        lblPersonCars.Size = new Size(231, 37);
        lblPersonCars.TabIndex = 19;
        lblPersonCars.Text = "Autos de persona";
        // 
        // btnViewLog
        // 
        btnViewLog.Location = new Point(104, 708);
        btnViewLog.Name = "btnViewLog";
        btnViewLog.Size = new Size(75, 23);
        btnViewLog.TabIndex = 24;
        btnViewLog.Text = "Ver bitácora";
        btnViewLog.UseVisualStyleBackColor = true;
        btnViewLog.Click += ButtonViewLog_Click;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(8F, 18F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.Ivory;
        ClientSize = new Size(1156, 791);
        Controls.Add(btnViewLog);
        Controls.Add(btnDeleteCar);
        Controls.Add(btnSaveCar);
        Controls.Add(txtPrecio);
        Controls.Add(btnNewCar);
        Controls.Add(lblPrice);
        Controls.Add(txtModelo);
        Controls.Add(txtAño);
        Controls.Add(lblYear);
        Controls.Add(lblPersonCars);
        Controls.Add(lblCarsPrice);
        Controls.Add(txtCarsCount);
        Controls.Add(btnAssignCar);
        Controls.Add(lblModel);
        Controls.Add(lblAssignedCars);
        Controls.Add(txtMarca);
        Controls.Add(lblAvailableCars);
        Controls.Add(lblBrand);
        Controls.Add(txtPatente);
        Controls.Add(lblQuantity);
        Controls.Add(txtCarId);
        Controls.Add(lblLicensePlate);
        Controls.Add(dgvAssignedCars);
        Controls.Add(btnRemoveCar);
        Controls.Add(lblCarId);
        Controls.Add(txtApellido);
        Controls.Add(dgvPersonCars);
        Controls.Add(btnDeletePerson);
        Controls.Add(btnSavePerson);
        Controls.Add(txtNombre);
        Controls.Add(btnNewPerson);
        Controls.Add(dgvPersons);
        Controls.Add(dgvAvailableCars);
        Controls.Add(txtDNI);
        Controls.Add(lblPersons);
        Controls.Add(txtPersonId);
        Controls.Add(lblLastname);
        Controls.Add(lblPersonId);
        Controls.Add(lblFirstname);
        Controls.Add(lblIdentityCard);
        Font = new Font("Calibri", 11F);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Margin = new Padding(4);
        MaximizeBox = false;
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Integrador";
        ((System.ComponentModel.ISupportInitialize)dgvPersonCars).EndInit();
        ((System.ComponentModel.ISupportInitialize)dgvPersons).EndInit();
        ((System.ComponentModel.ISupportInitialize)dgvAvailableCars).EndInit();
        ((System.ComponentModel.ISupportInitialize)dgvAssignedCars).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    internal Label lblPersons;
    internal DataGridView dgvPersons;
    internal Button btnDeletePerson;
    internal Button btnSavePerson;
    internal Button btnNewPerson;
    internal DataGridView dgvPersonCars;
    internal Label lblCarsPrice;
    internal Label lblLastname;
    internal Label lblFirstname;
    internal Label lblIdentityCard;
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
    internal Label lblAvailableCars;
    internal Label lblPrice;
    internal Button btnAssignCar;
    internal Button btnRemoveCar;
    internal DataGridView dgvAssignedCars;
    internal Label lblAssignedCars;
    internal TextBox txtAño;
    internal Label lblYear;
    internal TextBox txtPrecio;
    internal TextBox txtCarsCount;
    internal Label lblQuantity;
    private TextBox txtModelo;
    internal Label lblPersonCars;
    private Button btnViewLog;
}
