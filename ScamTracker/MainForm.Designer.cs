namespace ScamTracker
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
            panel1 = new Panel();
            label1 = new Label();
            btn_Baslat = new Button();
            textBox1 = new TextBox();
            lblResult = new Label();
            progressBar1 = new ProgressBar();
            panel2 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btn_Baslat);
            panel1.Controls.Add(textBox1);
            panel1.Location = new Point(33, 64);
            panel1.Name = "panel1";
            panel1.Size = new Size(315, 123);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 11);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 3;
            label1.Text = "TXID";
            // 
            // btn_Baslat
            // 
            btn_Baslat.Location = new Point(171, 33);
            btn_Baslat.Name = "btn_Baslat";
            btn_Baslat.Size = new Size(119, 76);
            btn_Baslat.TabIndex = 2;
            btn_Baslat.Text = "BAŞLAT";
            btn_Baslat.UseVisualStyleBackColor = true;
            btn_Baslat.Click += btn_Baslat_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(16, 33);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "TXID Giriniz";
            textBox1.Size = new Size(149, 76);
            textBox1.TabIndex = 0;
            textBox1.Text = "5dbef34819b94491918fbfde9fd83e3a1c755c363f48dafc1178c16e65a86ac5";
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(371, 14);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(0, 15);
            lblResult.TabIndex = 1;
            // 
            // progressBar1
            // 
            progressBar1.Dock = DockStyle.Bottom;
            progressBar1.Location = new Point(0, 405);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(950, 23);
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.TabIndex = 3;
            progressBar1.Visible = false;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.InactiveBorder;
            panel2.Controls.Add(lblResult);
            panel2.Location = new Point(12, 50);
            panel2.Name = "panel2";
            panel2.Size = new Size(938, 152);
            panel2.TabIndex = 4;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(950, 428);
            Controls.Add(progressBar1);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "MainForm";
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Scam Tracker";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox textBox1;
        private Button btn_Baslat;
        private Label label1;
        private Label lblResult;
        private ProgressBar progressBar1;
        private Panel panel2;
    }
}
