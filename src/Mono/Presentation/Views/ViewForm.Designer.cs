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
        CantidadAutosTextBox = new TextBox();
        label2 = new Label();
        ApellidoTextBox = new TextBox();
        NombreTextBox = new TextBox();
        DniTextBox = new TextBox();
        IdPersonaTextBox = new TextBox();
        label6 = new Label();
        label5 = new Label();
        label4 = new Label();
        label3 = new Label();
        ValorTotalAutosLabel = new Label();
        PersonCarsDGV = new DataGridView();
        EliminarPersonaButton = new Button();
        GuardarPersonaButton = new Button();
        NewPersonButton = new Button();
        PersonsDGV = new DataGridView();
        label1 = new Label();
        panel2 = new Panel();
        PrecioTextBox = new TextBox();
        AñoTextBox = new TextBox();
        label14 = new Label();
        label11 = new Label();
        ModeloTextBox = new TextBox();
        MarcaTextBox = new TextBox();
        PatenteTextBox = new TextBox();
        IdAutoTextBox = new TextBox();
        label7 = new Label();
        label8 = new Label();
        label9 = new Label();
        label10 = new Label();
        EliminarAutoButton = new Button();
        GuardarAutoButton = new Button();
        NewCarButton = new Button();
        AvailableCarsDGV = new DataGridView();
        label12 = new Label();
        AsignarAutoButton = new Button();
        QuitarAutoButton = new Button();
        AssignedCarsDGV = new DataGridView();
        label13 = new Label();
        panel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)PersonCarsDGV).BeginInit();
        ((System.ComponentModel.ISupportInitialize)PersonsDGV).BeginInit();
        panel2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)AvailableCarsDGV).BeginInit();
        ((System.ComponentModel.ISupportInitialize)AssignedCarsDGV).BeginInit();
        SuspendLayout();
        // 
        // panel1
        // 
        panel1.BackColor = Color.White;
        panel1.BorderStyle = BorderStyle.FixedSingle;
        panel1.Controls.Add(CantidadAutosTextBox);
        panel1.Controls.Add(label2);
        panel1.Controls.Add(ApellidoTextBox);
        panel1.Controls.Add(NombreTextBox);
        panel1.Controls.Add(DniTextBox);
        panel1.Controls.Add(IdPersonaTextBox);
        panel1.Controls.Add(label6);
        panel1.Controls.Add(label5);
        panel1.Controls.Add(label4);
        panel1.Controls.Add(label3);
        panel1.Controls.Add(ValorTotalAutosLabel);
        panel1.Controls.Add(PersonCarsDGV);
        panel1.Controls.Add(EliminarPersonaButton);
        panel1.Controls.Add(GuardarPersonaButton);
        panel1.Controls.Add(NewPersonButton);
        panel1.Controls.Add(PersonsDGV);
        panel1.Controls.Add(label1);
        panel1.Location = new Point(12, 12);
        panel1.Name = "panel1";
        panel1.Padding = new Padding(10);
        panel1.Size = new Size(535, 490);
        panel1.TabIndex = 0;
        // 
        // CantidadAutosTextBox
        // 
        CantidadAutosTextBox.Location = new Point(419, 414);
        CantidadAutosTextBox.Name = "CantidadAutosTextBox";
        CantidadAutosTextBox.ReadOnly = true;
        CantidadAutosTextBox.Size = new Size(100, 25);
        CantidadAutosTextBox.TabIndex = 16;
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
        // ApellidoTextBox
        // 
        ApellidoTextBox.Location = new Point(221, 414);
        ApellidoTextBox.Name = "ApellidoTextBox";
        ApellidoTextBox.Size = new Size(100, 25);
        ApellidoTextBox.TabIndex = 14;
        // 
        // NombreTextBox
        // 
        NombreTextBox.Location = new Point(221, 379);
        NombreTextBox.Name = "NombreTextBox";
        NombreTextBox.Size = new Size(100, 25);
        NombreTextBox.TabIndex = 13;
        // 
        // DniTextBox
        // 
        DniTextBox.Location = new Point(48, 414);
        DniTextBox.Name = "DniTextBox";
        DniTextBox.Size = new Size(100, 25);
        DniTextBox.TabIndex = 12;
        // 
        // IdPersonaTextBox
        // 
        IdPersonaTextBox.Location = new Point(48, 379);
        IdPersonaTextBox.Name = "IdPersonaTextBox";
        IdPersonaTextBox.ReadOnly = true;
        IdPersonaTextBox.Size = new Size(100, 25);
        IdPersonaTextBox.TabIndex = 11;
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
        // ValorTotalAutosLabel
        // 
        ValorTotalAutosLabel.Font = new Font("Calibri", 22F);
        ValorTotalAutosLabel.Location = new Point(11, 445);
        ValorTotalAutosLabel.Name = "ValorTotalAutosLabel";
        ValorTotalAutosLabel.Size = new Size(214, 37);
        ValorTotalAutosLabel.TabIndex = 6;
        ValorTotalAutosLabel.Text = "Total";
        ValorTotalAutosLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // AutosPersonaDGV
        // 
        PersonCarsDGV.AllowUserToAddRows = false;
        PersonCarsDGV.AllowUserToDeleteRows = false;
        PersonCarsDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        PersonCarsDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        PersonCarsDGV.Location = new Point(11, 246);
        PersonCarsDGV.Name = "AutosPersonaDGV";
        PersonCarsDGV.ReadOnly = true;
        PersonCarsDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        PersonCarsDGV.Size = new Size(506, 127);
        PersonCarsDGV.TabIndex = 5;
        // 
        // EliminarPersonaButton
        // 
        EliminarPersonaButton.AutoSize = true;
        EliminarPersonaButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        EliminarPersonaButton.Location = new Point(451, 445);
        EliminarPersonaButton.Name = "EliminarPersonaButton";
        EliminarPersonaButton.Size = new Size(69, 28);
        EliminarPersonaButton.TabIndex = 4;
        EliminarPersonaButton.Text = "Eliminar";
        EliminarPersonaButton.UseVisualStyleBackColor = true;
        EliminarPersonaButton.Click += DeletePersonButton_Click;
        // 
        // GuardarPersonaButton
        // 
        GuardarPersonaButton.AutoSize = true;
        GuardarPersonaButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        GuardarPersonaButton.Location = new Point(378, 445);
        GuardarPersonaButton.Name = "GuardarPersonaButton";
        GuardarPersonaButton.Size = new Size(67, 28);
        GuardarPersonaButton.TabIndex = 3;
        GuardarPersonaButton.Text = "Guardar";
        GuardarPersonaButton.UseVisualStyleBackColor = true;
        GuardarPersonaButton.Click += SavePersonButton_Click;
        // 
        // NuevoPersonaButton
        // 
        NewPersonButton.AutoSize = true;
        NewPersonButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        NewPersonButton.Location = new Point(313, 445);
        NewPersonButton.Name = "NuevoPersonaButton";
        NewPersonButton.Size = new Size(59, 28);
        NewPersonButton.TabIndex = 2;
        NewPersonButton.Text = "Nuevo";
        NewPersonButton.UseVisualStyleBackColor = true;
        NewPersonButton.Click += NewPersonButton_Click;
        // 
        // PersonasDGV
        // 
        PersonsDGV.AllowUserToAddRows = false;
        PersonsDGV.AllowUserToDeleteRows = false;
        PersonsDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        PersonsDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        PersonsDGV.Location = new Point(13, 50);
        PersonsDGV.Name = "PersonasDGV";
        PersonsDGV.ReadOnly = true;
        PersonsDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        PersonsDGV.Size = new Size(506, 190);
        PersonsDGV.TabIndex = 1;
        PersonsDGV.SelectionChanged += PersonsDataGridView_SelectionChanged;
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
        panel2.Controls.Add(PrecioTextBox);
        panel2.Controls.Add(AñoTextBox);
        panel2.Controls.Add(label14);
        panel2.Controls.Add(label11);
        panel2.Controls.Add(ModeloTextBox);
        panel2.Controls.Add(MarcaTextBox);
        panel2.Controls.Add(PatenteTextBox);
        panel2.Controls.Add(IdAutoTextBox);
        panel2.Controls.Add(label7);
        panel2.Controls.Add(label8);
        panel2.Controls.Add(label9);
        panel2.Controls.Add(label10);
        panel2.Controls.Add(EliminarAutoButton);
        panel2.Controls.Add(GuardarAutoButton);
        panel2.Controls.Add(NewCarButton);
        panel2.Controls.Add(AvailableCarsDGV);
        panel2.Controls.Add(label12);
        panel2.Location = new Point(709, 12);
        panel2.Name = "panel2";
        panel2.Padding = new Padding(10);
        panel2.Size = new Size(528, 490);
        panel2.TabIndex = 1;
        // 
        // PrecioTextBox
        // 
        PrecioTextBox.Location = new Point(413, 414);
        PrecioTextBox.Name = "PrecioTextBox";
        PrecioTextBox.Size = new Size(100, 25);
        PrecioTextBox.TabIndex = 19;
        // 
        // AñoTextBox
        // 
        AñoTextBox.Location = new Point(413, 383);
        AñoTextBox.Name = "AñoTextBox";
        AñoTextBox.Size = new Size(100, 25);
        AñoTextBox.TabIndex = 18;
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
        // ModeloTextBox
        // 
        ModeloTextBox.Location = new Point(245, 414);
        ModeloTextBox.Name = "ModeloTextBox";
        ModeloTextBox.Size = new Size(100, 25);
        ModeloTextBox.TabIndex = 14;
        // 
        // MarcaTextBox
        // 
        MarcaTextBox.Location = new Point(245, 383);
        MarcaTextBox.Name = "MarcaTextBox";
        MarcaTextBox.Size = new Size(100, 25);
        MarcaTextBox.TabIndex = 13;
        // 
        // PatenteTextBox
        // 
        PatenteTextBox.Location = new Point(77, 414);
        PatenteTextBox.Name = "PatenteTextBox";
        PatenteTextBox.Size = new Size(100, 25);
        PatenteTextBox.TabIndex = 12;
        // 
        // IdAutoTextBox
        // 
        IdAutoTextBox.Location = new Point(77, 383);
        IdAutoTextBox.Name = "IdAutoTextBox";
        IdAutoTextBox.ReadOnly = true;
        IdAutoTextBox.Size = new Size(100, 25);
        IdAutoTextBox.TabIndex = 11;
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
        // EliminarAutoButton
        // 
        EliminarAutoButton.AutoSize = true;
        EliminarAutoButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        EliminarAutoButton.Location = new Point(443, 445);
        EliminarAutoButton.Name = "EliminarAutoButton";
        EliminarAutoButton.Size = new Size(69, 28);
        EliminarAutoButton.TabIndex = 4;
        EliminarAutoButton.Text = "Eliminar";
        EliminarAutoButton.UseVisualStyleBackColor = true;
        EliminarAutoButton.Click += DeleteCarButton_Click;
        // 
        // GuardarAutoButton
        // 
        GuardarAutoButton.AutoSize = true;
        GuardarAutoButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        GuardarAutoButton.Location = new Point(370, 445);
        GuardarAutoButton.Name = "GuardarAutoButton";
        GuardarAutoButton.Size = new Size(67, 28);
        GuardarAutoButton.TabIndex = 3;
        GuardarAutoButton.Text = "Guardar";
        GuardarAutoButton.UseVisualStyleBackColor = true;
        GuardarAutoButton.Click += SaveCarButton_Click;
        // 
        // NuevoAutoButton
        // 
        NewCarButton.AutoSize = true;
        NewCarButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        NewCarButton.Location = new Point(305, 445);
        NewCarButton.Name = "NuevoAutoButton";
        NewCarButton.Size = new Size(59, 28);
        NewCarButton.TabIndex = 2;
        NewCarButton.Text = "Nuevo";
        NewCarButton.UseVisualStyleBackColor = true;
        NewCarButton.Click += NewCarButton_Click;
        // 
        // AutosDisponiblesDGV
        // 
        AvailableCarsDGV.AllowUserToAddRows = false;
        AvailableCarsDGV.AllowUserToDeleteRows = false;
        AvailableCarsDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        AvailableCarsDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        AvailableCarsDGV.Location = new Point(13, 50);
        AvailableCarsDGV.Name = "AutosDisponiblesDGV";
        AvailableCarsDGV.ReadOnly = true;
        AvailableCarsDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        AvailableCarsDGV.Size = new Size(499, 323);
        AvailableCarsDGV.TabIndex = 1;
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
        // AsignarAutoButton
        // 
        AsignarAutoButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        AsignarAutoButton.Location = new Point(553, 297);
        AsignarAutoButton.Name = "AsignarAutoButton";
        AsignarAutoButton.Size = new Size(150, 30);
        AsignarAutoButton.TabIndex = 15;
        AsignarAutoButton.Text = "← Asignar auto";
        AsignarAutoButton.TextImageRelation = TextImageRelation.TextBeforeImage;
        AsignarAutoButton.UseVisualStyleBackColor = true;
        AsignarAutoButton.Click += AssignCarButton_Click;
        // 
        // QuitarAutoButton
        // 
        QuitarAutoButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        QuitarAutoButton.Location = new Point(553, 333);
        QuitarAutoButton.Name = "QuitarAutoButton";
        QuitarAutoButton.Size = new Size(150, 30);
        QuitarAutoButton.TabIndex = 16;
        QuitarAutoButton.Text = "Desasignar auto →";
        QuitarAutoButton.TextImageRelation = TextImageRelation.ImageBeforeText;
        QuitarAutoButton.UseVisualStyleBackColor = true;
        QuitarAutoButton.Click += RemoveCarButton_Click;
        // 
        // AutosAsignadosDGV
        // 
        AssignedCarsDGV.AllowUserToAddRows = false;
        AssignedCarsDGV.AllowUserToDeleteRows = false;
        AssignedCarsDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        AssignedCarsDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        AssignedCarsDGV.Location = new Point(234, 508);
        AssignedCarsDGV.Name = "AutosAsignadosDGV";
        AssignedCarsDGV.ReadOnly = true;
        AssignedCarsDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        AssignedCarsDGV.Size = new Size(1003, 150);
        AssignedCarsDGV.TabIndex = 17;
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
        Controls.Add(AssignedCarsDGV);
        Controls.Add(QuitarAutoButton);
        Controls.Add(AsignarAutoButton);
        Controls.Add(panel2);
        Controls.Add(panel1);
        Font = new Font("Calibri", 11F);
        Margin = new Padding(4);
        Name = "ViewForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Integrador";
        panel1.ResumeLayout(false);
        panel1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)PersonCarsDGV).EndInit();
        ((System.ComponentModel.ISupportInitialize)PersonsDGV).EndInit();
        panel2.ResumeLayout(false);
        panel2.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)AvailableCarsDGV).EndInit();
        ((System.ComponentModel.ISupportInitialize)AssignedCarsDGV).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    internal Panel panel1;
    internal Label label1;
    internal DataGridView PersonsDGV;
    internal Button EliminarPersonaButton;
    internal Button GuardarPersonaButton;
    internal Button NewPersonButton;
    internal DataGridView PersonCarsDGV;
    internal Label ValorTotalAutosLabel;
    internal Label label6;
    internal Label label5;
    internal Label label4;
    internal Label label3;
    internal TextBox ApellidoTextBox;
    internal TextBox NombreTextBox;
    internal TextBox DniTextBox;
    internal TextBox IdPersonaTextBox;
    internal Panel panel2;
    internal TextBox ModeloTextBox;
    internal TextBox MarcaTextBox;
    internal TextBox PatenteTextBox;
    internal TextBox IdAutoTextBox;
    internal Label label7;
    internal Label label8;
    internal Label label9;
    internal Label label10;
    internal Button EliminarAutoButton;
    internal Button GuardarAutoButton;
    internal Button NewCarButton;
    internal DataGridView AvailableCarsDGV;
    internal Label label12;
    internal Label label11;
    internal Button AsignarAutoButton;
    internal Button QuitarAutoButton;
    internal DataGridView AssignedCarsDGV;
    internal Label label13;
    internal TextBox AñoTextBox;
    internal Label label14;
    internal TextBox PrecioTextBox;
    internal TextBox CantidadAutosTextBox;
    internal Label label2;
}
