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
            dgvLogEntries = new DataGridView();
            txtText = new TextBox();
            cmbLevel = new ComboBox();
            dtpDate = new DateTimePicker();
            btnFilter = new Button();
            lblSelect = new Label();
            lblText = new Label();
            lblLevel = new Label();
            lblDate = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvLogEntries).BeginInit();
            SuspendLayout();
            // 
            // dgvLogEntries
            // 
            dgvLogEntries.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLogEntries.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLogEntries.Location = new Point(13, 15);
            dgvLogEntries.Margin = new Padding(5, 4, 5, 4);
            dgvLogEntries.Name = "dgvLogEntries";
            dgvLogEntries.Size = new Size(889, 200);
            dgvLogEntries.TabIndex = 0;
            // 
            // txtText
            // 
            txtText.Location = new Point(346, 261);
            txtText.Margin = new Padding(5, 4, 5, 4);
            txtText.Name = "txtText";
            txtText.Size = new Size(113, 27);
            txtText.TabIndex = 1;
            txtText.TextChanged += TextBoxText_TextChanged;
            // 
            // cmbLevel
            // 
            cmbLevel.FormattingEnabled = true;
            cmbLevel.Location = new Point(573, 260);
            cmbLevel.Margin = new Padding(5, 4, 5, 4);
            cmbLevel.Name = "cmbLevel";
            cmbLevel.Size = new Size(113, 28);
            cmbLevel.TabIndex = 2;
            cmbLevel.SelectedIndexChanged += ComboBoxLevel_SelectedIndexChanged;
            // 
            // dtpDate
            // 
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Location = new Point(789, 257);
            dtpDate.Margin = new Padding(5, 4, 5, 4);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(113, 27);
            dtpDate.TabIndex = 3;
            dtpDate.ValueChanged += DateTimePickerDate_ValueChanged;
            // 
            // btnFilter
            // 
            btnFilter.Location = new Point(405, 329);
            btnFilter.Margin = new Padding(5, 4, 5, 4);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(85, 29);
            btnFilter.TabIndex = 4;
            btnFilter.Text = "Filtrar";
            btnFilter.UseVisualStyleBackColor = true;
            // 
            // lblSelect
            // 
            lblSelect.AutoSize = true;
            lblSelect.Location = new Point(13, 259);
            lblSelect.Margin = new Padding(5, 0, 5, 0);
            lblSelect.Name = "lblSelect";
            lblSelect.Size = new Size(214, 20);
            lblSelect.TabIndex = 5;
            lblSelect.Text = "Seleccione criterios de filtrado:";
            // 
            // lblText
            // 
            lblText.AutoSize = true;
            lblText.Location = new Point(297, 264);
            lblText.Name = "lblText";
            lblText.Size = new Size(45, 20);
            lblText.TabIndex = 6;
            lblText.Text = "Texto";
            // 
            // lblLevel
            // 
            lblLevel.AutoSize = true;
            lblLevel.Location = new Point(525, 264);
            lblLevel.Name = "lblLevel";
            lblLevel.Size = new Size(43, 20);
            lblLevel.TabIndex = 7;
            lblLevel.Text = "Nivel";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(738, 264);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(47, 20);
            lblDate.TabIndex = 8;
            lblDate.Text = "Fecha";
            // 
            // LogViewerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(915, 387);
            Controls.Add(lblDate);
            Controls.Add(lblLevel);
            Controls.Add(lblText);
            Controls.Add(lblSelect);
            Controls.Add(btnFilter);
            Controls.Add(dtpDate);
            Controls.Add(cmbLevel);
            Controls.Add(txtText);
            Controls.Add(dgvLogEntries);
            Font = new Font("Segoe UI", 11F);
            Margin = new Padding(5, 4, 5, 4);
            Name = "LogViewerForm";
            Text = "LogViewerForm";
            ((System.ComponentModel.ISupportInitialize)dgvLogEntries).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvLogEntries;
        private TextBox txtText;
        private ComboBox cmbLevel;
        private DateTimePicker dtpDate;
        private Button btnFilter;
        private Label lblSelect;
        private Label lblText;
        private Label lblLevel;
        private Label lblDate;
    }
}