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
        label2 = new Label();
        txtApellido = new TextBox();
        txtNombre = new TextBox();
        txtDNI = new TextBox();
        txtPersonId = new TextBox();
        label6 = new Label();
        label5 = new Label();
        label4 = new Label();
        label3 = new Label();
        lblCarsPrice = new Label();
        dgvPersonCars = new DataGridView();
        btnDeletePerson = new Button();
        btnSavePerson = new Button();
        btnNewPerson = new Button();
        dgvPersons = new DataGridView();
        label1 = new Label();
        txtModelo = new TextBox();
        txtPrecio = new TextBox();
        txtAño = new TextBox();
        label14 = new Label();
        label11 = new Label();
        txtMarca = new TextBox();
        txtPatente = new TextBox();
        txtCarId = new TextBox();
        label7 = new Label();
        label8 = new Label();
        label9 = new Label();
        label10 = new Label();
        btnDeleteCar = new Button();
        btnSaveCar = new Button();
        btnNewCar = new Button();
        dgvAvailableCars = new DataGridView();
        label12 = new Label();
        btnAssignCar = new Button();
        btnRemoveCar = new Button();
        dgvAssignedCars = new DataGridView();
        label13 = new Label();
        label15 = new Label();
        ((System.ComponentModel.ISupportInitialize)dgvPersonCars).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dgvPersons).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dgvAvailableCars).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dgvAssignedCars).BeginInit();
        SuspendLayout();
        // 
        // txtCarsCount
        // 
        txtCarsCount.Location = new Point(77, 250);
        txtCarsCount.Name = "txtCarsCount";
        txtCarsCount.ReadOnly = true;
        txtCarsCount.Size = new Size(207, 25);
        txtCarsCount.TabIndex = 8;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(12, 253);
        label2.Name = "label2";
        label2.Size = new Size(62, 18);
        label2.TabIndex = 15;
        label2.Text = "Cantidad";
        // 
        // txtApellido
        // 
        txtApellido.Location = new Point(77, 145);
        txtApellido.Name = "txtApellido";
        txtApellido.Size = new Size(207, 25);
        txtApellido.TabIndex = 4;
        // 
        // txtNombre
        // 
        txtNombre.Location = new Point(77, 114);
        txtNombre.Name = "txtNombre";
        txtNombre.Size = new Size(207, 25);
        txtNombre.TabIndex = 3;
        // 
        // txtDNI
        // 
        txtDNI.Location = new Point(77, 83);
        txtDNI.Name = "txtDNI";
        txtDNI.Size = new Size(207, 25);
        txtDNI.TabIndex = 2;
        // 
        // txtPersonId
        // 
        txtPersonId.Location = new Point(77, 52);
        txtPersonId.Name = "txtPersonId";
        txtPersonId.ReadOnly = true;
        txtPersonId.Size = new Size(207, 25);
        txtPersonId.TabIndex = 1;
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.Location = new Point(12, 148);
        label6.Name = "label6";
        label6.Size = new Size(61, 18);
        label6.TabIndex = 10;
        label6.Text = "Apellido";
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new Point(12, 117);
        label5.Name = "label5";
        label5.Size = new Size(59, 18);
        label5.TabIndex = 9;
        label5.Text = "Nombre";
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(12, 86);
        label4.Name = "label4";
        label4.Size = new Size(31, 18);
        label4.TabIndex = 8;
        label4.Text = "DNI";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(12, 55);
        label3.Name = "label3";
        label3.Size = new Size(20, 18);
        label3.TabIndex = 7;
        label3.Text = "Id";
        // 
        // lblCarsPrice
        // 
        lblCarsPrice.Font = new Font("Calibri", 22F);
        lblCarsPrice.Location = new Point(12, 278);
        lblCarsPrice.Name = "lblCarsPrice";
        lblCarsPrice.Size = new Size(272, 37);
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
        dgvPersonCars.Location = new Point(290, 210);
        dgvPersonCars.Name = "dgvPersonCars";
        dgvPersonCars.ReadOnly = true;
        dgvPersonCars.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvPersonCars.Size = new Size(526, 105);
        dgvPersonCars.TabIndex = 19;
        // 
        // btnDeletePerson
        // 
        btnDeletePerson.AutoSize = true;
        btnDeletePerson.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        btnDeletePerson.Location = new Point(215, 176);
        btnDeletePerson.Name = "btnDeletePerson";
        btnDeletePerson.Size = new Size(69, 28);
        btnDeletePerson.TabIndex = 7;
        btnDeletePerson.Text = "Eliminar";
        btnDeletePerson.UseVisualStyleBackColor = true;
        btnDeletePerson.Click += DeletePersonButton_Click;
        // 
        // btnSavePerson
        // 
        btnSavePerson.AutoSize = true;
        btnSavePerson.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        btnSavePerson.Location = new Point(142, 176);
        btnSavePerson.Name = "btnSavePerson";
        btnSavePerson.Size = new Size(67, 28);
        btnSavePerson.TabIndex = 6;
        btnSavePerson.Text = "Guardar";
        btnSavePerson.UseVisualStyleBackColor = true;
        btnSavePerson.Click += SavePersonButton_Click;
        // 
        // btnNewPerson
        // 
        btnNewPerson.AutoSize = true;
        btnNewPerson.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        btnNewPerson.Location = new Point(77, 176);
        btnNewPerson.Name = "btnNewPerson";
        btnNewPerson.Size = new Size(59, 28);
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
        dgvPersons.Location = new Point(290, 12);
        dgvPersons.Name = "dgvPersons";
        dgvPersons.ReadOnly = true;
        dgvPersons.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvPersons.Size = new Size(526, 192);
        dgvPersons.TabIndex = 18;
        dgvPersons.SelectionChanged += PersonsDataGridView_SelectionChanged;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new Font("Calibri", 22F);
        label1.Location = new Point(12, 12);
        label1.Name = "label1";
        label1.Size = new Size(126, 37);
        label1.TabIndex = 0;
        label1.Text = "Personas";
        // 
        // txtModelo
        // 
        txtModelo.Location = new Point(77, 488);
        txtModelo.Name = "txtModelo";
        txtModelo.Size = new Size(207, 25);
        txtModelo.TabIndex = 12;
        // 
        // txtPrecio
        // 
        txtPrecio.Location = new Point(77, 550);
        txtPrecio.Name = "txtPrecio";
        txtPrecio.Size = new Size(207, 25);
        txtPrecio.TabIndex = 14;
        // 
        // txtAño
        // 
        txtAño.Location = new Point(77, 519);
        txtAño.Name = "txtAño";
        txtAño.Size = new Size(207, 25);
        txtAño.TabIndex = 13;
        // 
        // label14
        // 
        label14.AutoSize = true;
        label14.Location = new Point(12, 521);
        label14.Name = "label14";
        label14.Size = new Size(33, 18);
        label14.TabIndex = 17;
        label14.Text = "Año";
        // 
        // label11
        // 
        label11.AutoSize = true;
        label11.Location = new Point(12, 553);
        label11.Name = "label11";
        label11.Size = new Size(47, 18);
        label11.TabIndex = 16;
        label11.Text = "Precio";
        // 
        // txtMarca
        // 
        txtMarca.Location = new Point(77, 457);
        txtMarca.Name = "txtMarca";
        txtMarca.Size = new Size(207, 25);
        txtMarca.TabIndex = 11;
        // 
        // txtPatente
        // 
        txtPatente.Location = new Point(77, 426);
        txtPatente.Name = "txtPatente";
        txtPatente.Size = new Size(207, 25);
        txtPatente.TabIndex = 10;
        // 
        // txtCarId
        // 
        txtCarId.Location = new Point(77, 395);
        txtCarId.Name = "txtCarId";
        txtCarId.ReadOnly = true;
        txtCarId.Size = new Size(207, 25);
        txtCarId.TabIndex = 9;
        // 
        // label7
        // 
        label7.AutoSize = true;
        label7.Location = new Point(12, 491);
        label7.Name = "label7";
        label7.Size = new Size(56, 18);
        label7.TabIndex = 10;
        label7.Text = "Modelo";
        // 
        // label8
        // 
        label8.AutoSize = true;
        label8.Location = new Point(12, 460);
        label8.Name = "label8";
        label8.Size = new Size(45, 18);
        label8.TabIndex = 9;
        label8.Text = "Marca";
        // 
        // label9
        // 
        label9.AutoSize = true;
        label9.Location = new Point(12, 429);
        label9.Name = "label9";
        label9.Size = new Size(57, 18);
        label9.TabIndex = 8;
        label9.Text = "Patente";
        // 
        // label10
        // 
        label10.AutoSize = true;
        label10.Location = new Point(12, 398);
        label10.Name = "label10";
        label10.Size = new Size(20, 18);
        label10.TabIndex = 7;
        label10.Text = "Id";
        // 
        // btnDeleteCar
        // 
        btnDeleteCar.AutoSize = true;
        btnDeleteCar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        btnDeleteCar.Location = new Point(215, 581);
        btnDeleteCar.Name = "btnDeleteCar";
        btnDeleteCar.Size = new Size(69, 28);
        btnDeleteCar.TabIndex = 17;
        btnDeleteCar.Text = "Eliminar";
        btnDeleteCar.UseVisualStyleBackColor = true;
        btnDeleteCar.Click += DeleteCarButton_Click;
        // 
        // btnSaveCar
        // 
        btnSaveCar.AutoSize = true;
        btnSaveCar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        btnSaveCar.Location = new Point(142, 581);
        btnSaveCar.Name = "btnSaveCar";
        btnSaveCar.Size = new Size(67, 28);
        btnSaveCar.TabIndex = 16;
        btnSaveCar.Text = "Guardar";
        btnSaveCar.UseVisualStyleBackColor = true;
        btnSaveCar.Click += SaveCarButton_Click;
        // 
        // btnNewCar
        // 
        btnNewCar.AutoSize = true;
        btnNewCar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        btnNewCar.Location = new Point(77, 581);
        btnNewCar.Name = "btnNewCar";
        btnNewCar.Size = new Size(59, 28);
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
        dgvAvailableCars.Location = new Point(290, 355);
        dgvAvailableCars.Name = "dgvAvailableCars";
        dgvAvailableCars.ReadOnly = true;
        dgvAvailableCars.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvAvailableCars.Size = new Size(526, 254);
        dgvAvailableCars.TabIndex = 22;
        // 
        // label12
        // 
        label12.AutoSize = true;
        label12.Font = new Font("Calibri", 22F);
        label12.Location = new Point(12, 355);
        label12.Name = "label12";
        label12.Size = new Size(235, 37);
        label12.TabIndex = 0;
        label12.Text = "Autos disponibles";
        label12.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // btnAssignCar
        // 
        btnAssignCar.AutoSize = true;
        btnAssignCar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        btnAssignCar.Location = new Point(290, 321);
        btnAssignCar.Name = "btnAssignCar";
        btnAssignCar.Size = new Size(81, 28);
        btnAssignCar.TabIndex = 20;
        btnAssignCar.Text = "↑ Asignar";
        btnAssignCar.TextImageRelation = TextImageRelation.TextBeforeImage;
        btnAssignCar.UseVisualStyleBackColor = true;
        btnAssignCar.Click += AssignCarButton_Click;
        // 
        // btnRemoveCar
        // 
        btnRemoveCar.AutoSize = true;
        btnRemoveCar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        btnRemoveCar.Location = new Point(725, 321);
        btnRemoveCar.Name = "btnRemoveCar";
        btnRemoveCar.Size = new Size(91, 28);
        btnRemoveCar.TabIndex = 21;
        btnRemoveCar.Text = "↓ Remover";
        btnRemoveCar.TextImageRelation = TextImageRelation.ImageBeforeText;
        btnRemoveCar.UseVisualStyleBackColor = true;
        btnRemoveCar.Click += RemoveCarButton_Click;
        // 
        // dgvAssignedCars
        // 
        dgvAssignedCars.AllowUserToAddRows = false;
        dgvAssignedCars.AllowUserToDeleteRows = false;
        dgvAssignedCars.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvAssignedCars.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvAssignedCars.Location = new Point(290, 615);
        dgvAssignedCars.Name = "dgvAssignedCars";
        dgvAssignedCars.ReadOnly = true;
        dgvAssignedCars.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvAssignedCars.Size = new Size(526, 159);
        dgvAssignedCars.TabIndex = 23;
        // 
        // label13
        // 
        label13.AutoSize = true;
        label13.Font = new Font("Calibri", 22F);
        label13.Location = new Point(12, 612);
        label13.Name = "label13";
        label13.Size = new Size(216, 37);
        label13.TabIndex = 18;
        label13.Text = "Autos asignados";
        // 
        // label15
        // 
        label15.AutoSize = true;
        label15.Font = new Font("Calibri", 22F);
        label15.Location = new Point(12, 210);
        label15.Name = "label15";
        label15.Size = new Size(231, 37);
        label15.TabIndex = 19;
        label15.Text = "Autos de persona";
        // 
        // ViewForm
        // 
        AutoScaleDimensions = new SizeF(8F, 18F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.Ivory;
        ClientSize = new Size(829, 786);
        Controls.Add(btnDeleteCar);
        Controls.Add(btnSaveCar);
        Controls.Add(txtPrecio);
        Controls.Add(btnNewCar);
        Controls.Add(label11);
        Controls.Add(txtModelo);
        Controls.Add(txtAño);
        Controls.Add(label14);
        Controls.Add(label15);
        Controls.Add(lblCarsPrice);
        Controls.Add(txtCarsCount);
        Controls.Add(btnAssignCar);
        Controls.Add(label7);
        Controls.Add(label13);
        Controls.Add(txtMarca);
        Controls.Add(label12);
        Controls.Add(label8);
        Controls.Add(txtPatente);
        Controls.Add(label2);
        Controls.Add(txtCarId);
        Controls.Add(label9);
        Controls.Add(dgvAssignedCars);
        Controls.Add(btnRemoveCar);
        Controls.Add(label10);
        Controls.Add(txtApellido);
        Controls.Add(dgvPersonCars);
        Controls.Add(btnDeletePerson);
        Controls.Add(btnSavePerson);
        Controls.Add(txtNombre);
        Controls.Add(btnNewPerson);
        Controls.Add(dgvPersons);
        Controls.Add(dgvAvailableCars);
        Controls.Add(txtDNI);
        Controls.Add(label1);
        Controls.Add(txtPersonId);
        Controls.Add(label6);
        Controls.Add(label3);
        Controls.Add(label5);
        Controls.Add(label4);
        Font = new Font("Calibri", 11F);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Margin = new Padding(4);
        MaximizeBox = false;
        Name = "ViewForm";
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
    internal Label label1;
    internal DataGridView dgvPersons;
    internal Button btnDeletePerson;
    internal Button btnSavePerson;
    internal Button btnNewPerson;
    internal DataGridView dgvPersonCars;
    internal Label lblCarsPrice;
    internal Label label6;
    internal Label label5;
    internal Label label4;
    internal Label label3;
    internal TextBox txtApellido;
    internal TextBox txtNombre;
    internal TextBox txtDNI;
    internal TextBox txtPersonId;
    internal TextBox txtMarca;
    internal TextBox txtPatente;
    internal TextBox txtCarId;
    internal Label label7;
    internal Label label8;
    internal Label label9;
    internal Label label10;
    internal Button btnDeleteCar;
    internal Button btnSaveCar;
    internal Button btnNewCar;
    internal DataGridView dgvAvailableCars;
    internal Label label12;
    internal Label label11;
    internal Button btnAssignCar;
    internal Button btnRemoveCar;
    internal DataGridView dgvAssignedCars;
    internal Label label13;
    internal TextBox txtAño;
    internal Label label14;
    internal TextBox txtPrecio;
    internal TextBox txtCarsCount;
    internal Label label2;
    private TextBox txtModelo;
    internal Label label15;
}
