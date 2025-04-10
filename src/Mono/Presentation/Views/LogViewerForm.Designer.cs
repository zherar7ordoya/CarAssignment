namespace Integrador.Presentation.Views
{
    partial class LogViewerForm
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
            dgvLogs = new DataGridView();
            txtBuscar = new TextBox();
            cmbNivel = new ComboBox();
            dateTimePicker1 = new DateTimePicker();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvLogs).BeginInit();
            SuspendLayout();
            // 
            // dgvLogs
            // 
            dgvLogs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLogs.Location = new Point(12, 12);
            dgvLogs.Name = "dgvLogs";
            dgvLogs.Size = new Size(240, 150);
            dgvLogs.TabIndex = 0;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(422, 63);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(100, 23);
            txtBuscar.TabIndex = 1;
            txtBuscar.TextChanged += TextBoxBuscar_TextChanged;
            // 
            // cmbNivel
            // 
            cmbNivel.FormattingEnabled = true;
            cmbNivel.Items.AddRange(new object[] { "Info", "Error", "Todos" });
            cmbNivel.Location = new Point(430, 157);
            cmbNivel.Name = "cmbNivel";
            cmbNivel.Size = new Size(121, 23);
            cmbNivel.TabIndex = 2;
            cmbNivel.SelectedIndexChanged += ComboBoxNivel_SelectedIndexChanged;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(419, 267);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(331, 375);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // LogViewerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(dateTimePicker1);
            Controls.Add(cmbNivel);
            Controls.Add(txtBuscar);
            Controls.Add(dgvLogs);
            Name = "LogViewerForm";
            Text = "LogViewerForm";
            ((System.ComponentModel.ISupportInitialize)dgvLogs).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvLogs;
        private TextBox txtBuscar;
        private ComboBox cmbNivel;
        private DateTimePicker dateTimePicker1;
        private Button button1;
    }
}