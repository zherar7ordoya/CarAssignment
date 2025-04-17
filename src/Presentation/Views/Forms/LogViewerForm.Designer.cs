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
            dgvLogEntries.Location = new Point(13, 13);
            dgvLogEntries.Margin = new Padding(4);
            dgvLogEntries.Name = "dgvLogEntries";
            dgvLogEntries.Size = new Size(889, 180);
            dgvLogEntries.TabIndex = 0;
            // 
            // txtText
            // 
            txtText.Location = new Point(346, 235);
            txtText.Margin = new Padding(4);
            txtText.Name = "txtText";
            txtText.Size = new Size(113, 25);
            txtText.TabIndex = 1;
            txtText.TextChanged += TextBoxText_TextChanged;
            // 
            // cmbLevel
            // 
            cmbLevel.FormattingEnabled = true;
            cmbLevel.Location = new Point(573, 234);
            cmbLevel.Margin = new Padding(4);
            cmbLevel.Name = "cmbLevel";
            cmbLevel.Size = new Size(113, 26);
            cmbLevel.TabIndex = 2;
            cmbLevel.SelectedIndexChanged += ComboBoxLevel_SelectedIndexChanged;
            // 
            // dtpDate
            // 
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Location = new Point(789, 232);
            dtpDate.Margin = new Padding(4);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(113, 25);
            dtpDate.TabIndex = 3;
            dtpDate.ValueChanged += DateTimePickerDate_ValueChanged;
            // 
            // btnFilter
            // 
            btnFilter.Location = new Point(404, 296);
            btnFilter.Margin = new Padding(4);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(85, 27);
            btnFilter.TabIndex = 4;
            btnFilter.Text = "Filtrar";
            btnFilter.UseVisualStyleBackColor = true;
            // 
            // lblSelect
            // 
            lblSelect.AutoSize = true;
            lblSelect.Location = new Point(13, 233);
            lblSelect.Margin = new Padding(4, 0, 4, 0);
            lblSelect.Name = "lblSelect";
            lblSelect.Size = new Size(241, 22);
            lblSelect.TabIndex = 5;
            lblSelect.Text = "Seleccione criterios de filtrado:";
            // 
            // lblText
            // 
            lblText.AutoSize = true;
            lblText.Location = new Point(297, 238);
            lblText.Name = "lblText";
            lblText.Size = new Size(42, 18);
            lblText.TabIndex = 6;
            lblText.Text = "Texto";
            // 
            // lblLevel
            // 
            lblLevel.AutoSize = true;
            lblLevel.Location = new Point(525, 237);
            lblLevel.Name = "lblLevel";
            lblLevel.Size = new Size(41, 18);
            lblLevel.TabIndex = 7;
            lblLevel.Text = "Nivel";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(738, 237);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(44, 18);
            lblDate.TabIndex = 8;
            lblDate.Text = "Fecha";
            // 
            // LogViewerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(915, 348);
            Controls.Add(lblDate);
            Controls.Add(lblLevel);
            Controls.Add(lblText);
            Controls.Add(lblSelect);
            Controls.Add(btnFilter);
            Controls.Add(dtpDate);
            Controls.Add(cmbLevel);
            Controls.Add(txtText);
            Controls.Add(dgvLogEntries);
            Margin = new Padding(4);
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