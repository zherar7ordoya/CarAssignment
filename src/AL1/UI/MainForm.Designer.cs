namespace UI
{
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
            label1 = new Label();
            txtTask = new TextBox();
            btnAdd = new Button();
            lstTasks = new ListBox();
            btnComplete = new Button();
            btnDelete = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(348, 15);
            label1.Name = "label1";
            label1.Size = new Size(162, 20);
            label1.TabIndex = 0;
            label1.Text = "Descripción de la tarea";
            // 
            // txtTask
            // 
            txtTask.Location = new Point(12, 12);
            txtTask.Name = "txtTask";
            txtTask.Size = new Size(330, 27);
            txtTask.TabIndex = 1;
            // 
            // btnAdd
            // 
            btnAdd.AutoSize = true;
            btnAdd.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAdd.Location = new Point(348, 267);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(241, 30);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Agregar una nueva tarea a la lista";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += BtnAdd_Click;
            // 
            // lstTasks
            // 
            lstTasks.FormattingEnabled = true;
            lstTasks.Location = new Point(12, 45);
            lstTasks.Name = "lstTasks";
            lstTasks.Size = new Size(330, 324);
            lstTasks.TabIndex = 3;
            // 
            // btnComplete
            // 
            btnComplete.AutoSize = true;
            btnComplete.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnComplete.Location = new Point(348, 339);
            btnComplete.Name = "btnComplete";
            btnComplete.Size = new Size(257, 30);
            btnComplete.TabIndex = 4;
            btnComplete.Text = "Marcar una tarea como completada";
            btnComplete.UseVisualStyleBackColor = true;
            btnComplete.Click += BtnComplete_Click;
            // 
            // btnDelete
            // 
            btnDelete.AutoSize = true;
            btnDelete.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnDelete.Location = new Point(348, 303);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(229, 30);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Eliminar una tarea seleccionada";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += BtnDelete_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(613, 388);
            Controls.Add(btnDelete);
            Controls.Add(btnComplete);
            Controls.Add(lstTasks);
            Controls.Add(btnAdd);
            Controls.Add(txtTask);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 11F);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtTask;
        private Button btnAdd;
        private ListBox lstTasks;
        private Button btnComplete;
        private Button btnDelete;
    }
}
