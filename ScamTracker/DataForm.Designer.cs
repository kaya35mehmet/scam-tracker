namespace ScamTracker
{
    partial class DataForm
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
            dataGridView1 = new DataGridView();
            btnToExcel = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(322, 114);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(8, 8);
            dataGridView1.TabIndex = 0;
            // 
            // btnToExcel
            // 
            btnToExcel.Location = new Point(1, 0);
            btnToExcel.Name = "btnToExcel";
            btnToExcel.Size = new Size(75, 23);
            btnToExcel.TabIndex = 1;
            btnToExcel.Text = "Excele Kaydet";
            btnToExcel.UseVisualStyleBackColor = true;
            btnToExcel.Click += btnToExcel_Click;
            // 
            // DataForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnToExcel);
            Controls.Add(dataGridView1);
            Name = "DataForm";
            Text = "DataForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btnToExcel;
    }
}