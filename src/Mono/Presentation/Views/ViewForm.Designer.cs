namespace Integrador;

partial class ViewForm
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
        panel1 = new Panel();
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
        panel2 = new Panel();
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
        panel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvPersonCars).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dgvPersons).BeginInit();
        panel2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvAvailableCars).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dgvAssignedCars).BeginInit();
        SuspendLayout();
        // 
        // panel1
        // 
        panel1.BackColor = Color.White;
        panel1.BorderStyle = BorderStyle.FixedSingle;
        panel1.Controls.Add(txtCarsCount);
        panel1.Controls.Add(label2);
        panel1.Controls.Add(txtApellido);
        panel1.Controls.Add(txtNombre);
        panel1.Controls.Add(txtDNI);
        panel1.Controls.Add(txtPersonId);
        panel1.Controls.Add(label6);
        panel1.Controls.Add(label5);
        panel1.Controls.Add(label4);
        panel1.Controls.Add(label3);
        panel1.Controls.Add(lblCarsPrice);
        panel1.Controls.Add(dgvPersonCars);
        panel1.Controls.Add(btnDeletePerson);
        panel1.Controls.Add(btnSavePerson);
        panel1.Controls.Add(btnNewPerson);
        panel1.Controls.Add(dgvPersons);
        panel1.Controls.Add(label1);
        panel1.Location = new Point(12, 12);
        panel1.Name = "panel1";
        panel1.Padding = new Padding(10);
        panel1.Size = new Size(535, 490);
        panel1.TabIndex = 0;
        // 
        // txtCarsCount
        // 
        txtCarsCount.Location = new Point(419, 414);
        txtCarsCount.Name = "txtCarsCount";
        txtCarsCount.ReadOnly = true;
        txtCarsCount.Size = new Size(100, 25);
        txtCarsCount.TabIndex = 16;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(419, 393);
        label2.Name = "label2";
        label2.Size = new Size(99, 18);
        label2.TabIndex = 15;
        label2.Text = "Cantidad autos";
        // 
        // txtApellido
        // 
        txtApellido.Location = new Point(221, 414);
        txtApellido.Name = "txtApellido";
        txtApellido.Size = new Size(100, 25);
        txtApellido.TabIndex = 14;
        // 
        // txtNombre
        // 
        txtNombre.Location = new Point(221, 379);
        txtNombre.Name = "txtNombre";
        txtNombre.Size = new Size(100, 25);
        txtNombre.TabIndex = 13;
        // 
        // txtDNI
        // 
        txtDNI.Location = new Point(48, 414);
        txtDNI.Name = "txtDNI";
        txtDNI.Size = new Size(100, 25);
        txtDNI.TabIndex = 12;
        // 
        // txtPersonId
        // 
        txtPersonId.Location = new Point(48, 379);
        txtPersonId.Name = "txtPersonId";
        txtPersonId.ReadOnly = true;
        txtPersonId.Size = new Size(100, 25);
        txtPersonId.TabIndex = 11;
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.Location = new Point(154, 417);
        label6.Name = "label6";
        label6.Size = new Size(61, 18);
        label6.TabIndex = 10;
        label6.Text = "Apellido";
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new Point(156, 386);
        label5.Name = "label5";
        label5.Size = new Size(59, 18);
        label5.TabIndex = 9;
        label5.Text = "Nombre";
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(11, 417);
        label4.Name = "label4";
        label4.Size = new Size(31, 18);
        label4.TabIndex = 8;
        label4.Text = "DNI";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(13, 386);
        label3.Name = "label3";
        label3.Size = new Size(20, 18);
        label3.TabIndex = 7;
        label3.Text = "Id";
        // 
        // lblCarsPrice
        // 
        lblCarsPrice.Font = new Font("Calibri", 22F);
        lblCarsPrice.Location = new Point(11, 445);
        lblCarsPrice.Name = "lblCarsPrice";
        lblCarsPrice.Size = new Size(214, 37);
        lblCarsPrice.TabIndex = 6;
        lblCarsPrice.Text = "Total";
        lblCarsPrice.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // dgvPersonCars
        // 
        dgvPersonCars.AllowUserToAddRows = false;
        dgvPersonCars.AllowUserToDeleteRows = false;
        dgvPersonCars.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvPersonCars.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvPersonCars.Location = new Point(11, 246);
        dgvPersonCars.Name = "dgvPersonCars";
        dgvPersonCars.ReadOnly = true;
        dgvPersonCars.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvPersonCars.Size = new Size(509, 127);
        dgvPersonCars.TabIndex = 5;
        // 
        // btnDeletePerson
        // 
        btnDeletePerson.AutoSize = true;
        btnDeletePerson.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        btnDeletePerson.Location = new Point(451, 445);
        btnDeletePerson.Name = "btnDeletePerson";
        btnDeletePerson.Size = new Size(69, 28);
        btnDeletePerson.TabIndex = 4;
        btnDeletePerson.Text = "Eliminar";
        btnDeletePerson.UseVisualStyleBackColor = true;
        btnDeletePerson.Click += DeletePersonButton_Click;
        // 
        // btnSavePerson
        // 
        btnSavePerson.AutoSize = true;
        btnSavePerson.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        btnSavePerson.Location = new Point(378, 445);
        btnSavePerson.Name = "btnSavePerson";
        btnSavePerson.Size = new Size(67, 28);
        btnSavePerson.TabIndex = 3;
        btnSavePerson.Text = "Guardar";
        btnSavePerson.UseVisualStyleBackColor = true;
        btnSavePerson.Click += SavePersonButton_Click;
        // 
        // btnNewPerson
        // 
        btnNewPerson.AutoSize = true;
        btnNewPerson.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        btnNewPerson.Location = new Point(313, 445);
        btnNewPerson.Name = "btnNewPerson";
        btnNewPerson.Size = new Size(59, 28);
        btnNewPerson.TabIndex = 2;
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
        dgvPersons.Location = new Point(13, 50);
        dgvPersons.Name = "dgvPersons";
        dgvPersons.ReadOnly = true;
        dgvPersons.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvPersons.Size = new Size(506, 190);
        dgvPersons.TabIndex = 1;
        dgvPersons.SelectionChanged += PersonsDataGridView_SelectionChanged;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new Font("Calibri", 22F);
        label1.Location = new Point(13, 10);
        label1.Name = "label1";
        label1.Size = new Size(126, 37);
        label1.TabIndex = 0;
        label1.Text = "Personas";
        // 
        // panel2
        // 
        panel2.BackColor = Color.White;
        panel2.BorderStyle = BorderStyle.FixedSingle;
        panel2.Controls.Add(txtModelo);
        panel2.Controls.Add(txtPrecio);
        panel2.Controls.Add(txtAño);
        panel2.Controls.Add(label14);
        panel2.Controls.Add(label11);
        panel2.Controls.Add(txtMarca);
        panel2.Controls.Add(txtPatente);
        panel2.Controls.Add(txtCarId);
        panel2.Controls.Add(label7);
        panel2.Controls.Add(label8);
        panel2.Controls.Add(label9);
        panel2.Controls.Add(label10);
        panel2.Controls.Add(btnDeleteCar);
        panel2.Controls.Add(btnSaveCar);
        panel2.Controls.Add(btnNewCar);
        panel2.Controls.Add(dgvAvailableCars);
        panel2.Controls.Add(label12);
        panel2.Location = new Point(709, 12);
        panel2.Name = "panel2";
        panel2.Padding = new Padding(10);
        panel2.Size = new Size(528, 490);
        panel2.TabIndex = 1;
        // 
        // txtModelo
        // 
        txtModelo.Location = new Point(245, 414);
        txtModelo.Name = "txtModelo";
        txtModelo.Size = new Size(100, 25);
        txtModelo.TabIndex = 20;
        // 
        // txtPrecio
        // 
        txtPrecio.Location = new Point(413, 414);
        txtPrecio.Name = "txtPrecio";
        txtPrecio.Size = new Size(100, 25);
        txtPrecio.TabIndex = 19;
        // 
        // txtAño
        // 
        txtAño.Location = new Point(413, 383);
        txtAño.Name = "txtAño";
        txtAño.Size = new Size(100, 25);
        txtAño.TabIndex = 18;
        // 
        // label14
        // 
        label14.AutoSize = true;
        label14.Location = new Point(351, 386);
        label14.Name = "label14";
        label14.Size = new Size(33, 18);
        label14.TabIndex = 17;
        label14.Text = "Año";
        // 
        // label11
        // 
        label11.AutoSize = true;
        label11.Location = new Point(351, 417);
        label11.Name = "label11";
        label11.Size = new Size(47, 18);
        label11.TabIndex = 16;
        label11.Text = "Precio";
        // 
        // txtMarca
        // 
        txtMarca.Location = new Point(245, 383);
        txtMarca.Name = "txtMarca";
        txtMarca.Size = new Size(100, 25);
        txtMarca.TabIndex = 13;
        // 
        // txtPatente
        // 
        txtPatente.Location = new Point(77, 414);
        txtPatente.Name = "txtPatente";
        txtPatente.Size = new Size(100, 25);
        txtPatente.TabIndex = 12;
        // 
        // txtCarId
        // 
        txtCarId.Location = new Point(77, 383);
        txtCarId.Name = "txtCarId";
        txtCarId.ReadOnly = true;
        txtCarId.Size = new Size(100, 25);
        txtCarId.TabIndex = 11;
        // 
        // label7
        // 
        label7.AutoSize = true;
        label7.Location = new Point(183, 417);
        label7.Name = "label7";
        label7.Size = new Size(56, 18);
        label7.TabIndex = 10;
        label7.Text = "Modelo";
        // 
        // label8
        // 
        label8.AutoSize = true;
        label8.Location = new Point(182, 386);
        label8.Name = "label8";
        label8.Size = new Size(45, 18);
        label8.TabIndex = 9;
        label8.Text = "Marca";
        // 
        // label9
        // 
        label9.AutoSize = true;
        label9.Location = new Point(14, 417);
        label9.Name = "label9";
        label9.Size = new Size(57, 18);
        label9.TabIndex = 8;
        label9.Text = "Patente";
        // 
        // label10
        // 
        label10.AutoSize = true;
        label10.Location = new Point(14, 386);
        label10.Name = "label10";
        label10.Size = new Size(20, 18);
        label10.TabIndex = 7;
        label10.Text = "Id";
        // 
        // btnDeleteCar
        // 
        btnDeleteCar.AutoSize = true;
        btnDeleteCar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        btnDeleteCar.Location = new Point(443, 445);
        btnDeleteCar.Name = "btnDeleteCar";
        btnDeleteCar.Size = new Size(69, 28);
        btnDeleteCar.TabIndex = 4;
        btnDeleteCar.Text = "Eliminar";
        btnDeleteCar.UseVisualStyleBackColor = true;
        btnDeleteCar.Click += DeleteCarButton_Click;
        // 
        // btnSaveCar
        // 
        btnSaveCar.AutoSize = true;
        btnSaveCar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        btnSaveCar.Location = new Point(370, 445);
        btnSaveCar.Name = "btnSaveCar";
        btnSaveCar.Size = new Size(67, 28);
        btnSaveCar.TabIndex = 3;
        btnSaveCar.Text = "Guardar";
        btnSaveCar.UseVisualStyleBackColor = true;
        btnSaveCar.Click += SaveCarButton_Click;
        // 
        // btnNewCar
        // 
        btnNewCar.AutoSize = true;
        btnNewCar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        btnNewCar.Location = new Point(305, 445);
        btnNewCar.Name = "btnNewCar";
        btnNewCar.Size = new Size(59, 28);
        btnNewCar.TabIndex = 2;
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
        dgvAvailableCars.Location = new Point(13, 50);
        dgvAvailableCars.Name = "dgvAvailableCars";
        dgvAvailableCars.ReadOnly = true;
        dgvAvailableCars.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvAvailableCars.Size = new Size(499, 323);
        dgvAvailableCars.TabIndex = 1;
        // 
        // label12
        // 
        label12.AutoSize = true;
        label12.Font = new Font("Calibri", 22F);
        label12.Location = new Point(13, 10);
        label12.Name = "label12";
        label12.Size = new Size(235, 37);
        label12.TabIndex = 0;
        label12.Text = "Autos disponibles";
        // 
        // btnAssignCar
        // 
        btnAssignCar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        btnAssignCar.Location = new Point(553, 297);
        btnAssignCar.Name = "btnAssignCar";
        btnAssignCar.Size = new Size(150, 30);
        btnAssignCar.TabIndex = 15;
        btnAssignCar.Text = "← Asignar auto";
        btnAssignCar.TextImageRelation = TextImageRelation.TextBeforeImage;
        btnAssignCar.UseVisualStyleBackColor = true;
        btnAssignCar.Click += AssignCarButton_Click;
        // 
        // btnRemoveCar
        // 
        btnRemoveCar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        btnRemoveCar.Location = new Point(553, 333);
        btnRemoveCar.Name = "btnRemoveCar";
        btnRemoveCar.Size = new Size(150, 30);
        btnRemoveCar.TabIndex = 16;
        btnRemoveCar.Text = "Desasignar auto →";
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
        dgvAssignedCars.Location = new Point(234, 508);
        dgvAssignedCars.Name = "dgvAssignedCars";
        dgvAssignedCars.ReadOnly = true;
        dgvAssignedCars.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvAssignedCars.Size = new Size(1003, 150);
        dgvAssignedCars.TabIndex = 17;
        // 
        // label13
        // 
        label13.AutoSize = true;
        label13.Font = new Font("Calibri", 22F);
        label13.Location = new Point(12, 564);
        label13.Name = "label13";
        label13.Size = new Size(216, 37);
        label13.TabIndex = 18;
        label13.Text = "Autos asignados";
        // 
        // ViewForm
        // 
        AutoScaleDimensions = new SizeF(8F, 18F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.Control;
        ClientSize = new Size(1247, 668);
        Controls.Add(label13);
        Controls.Add(dgvAssignedCars);
        Controls.Add(btnRemoveCar);
        Controls.Add(btnAssignCar);
        Controls.Add(panel2);
        Controls.Add(panel1);
        Font = new Font("Calibri", 11F);
        Margin = new Padding(4);
        Name = "ViewForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Integrador";
        panel1.ResumeLayout(false);
        panel1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvPersonCars).EndInit();
        ((System.ComponentModel.ISupportInitialize)dgvPersons).EndInit();
        panel2.ResumeLayout(false);
        panel2.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvAvailableCars).EndInit();
        ((System.ComponentModel.ISupportInitialize)dgvAssignedCars).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    internal Panel panel1;
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
    internal Panel panel2;
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
}
