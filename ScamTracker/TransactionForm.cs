using ScamTracker.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScamTracker
{
    public partial class panelTransactionForm : Form
    {
        public panelTransactionForm(string hash, DateTime tarih, string gonderen, string alici, string tutar, string tokenName, Panel panelMain, Label label, int x, int y)
        {
            InitializeComponent();

            this.Text = "Detaylar";
            this.Size = new Size(500, 300);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Location = new Point(x, y);
            this.MaximizeBox = false;
            this.BackColor = Color.Black;

            Panel mainPanel = new Panel() {
                Size = new Size(480, 257),
                Location = new Point(2, 2),
                BackColor = Color.White,
            };
           
            Label hashLabel = new Label
            {
                AutoSize = true,
                Font = new Font("Arial", 10),
                ForeColor = Color.Blue,
                Text = $"Hash: {HashValidator.GetShortenedHash(hash)}",
                Location = new Point(20, 20),
                Cursor = Cursors.Hand
            };
            hashLabel.Click += (sender, e) =>
            {
                OpenBrowser($"https://tronscan.org/#/transaction/{hash}");
            };
            mainPanel.Controls.Add(hashLabel);

            Label tarihLabel = new Label
            {
                AutoSize = true,
                Font = new Font("Arial", 10),
                Text = $"Tarih: {tarih} UTC",
                Location = new Point(20, 50),
            };
            mainPanel.Controls.Add(tarihLabel);

            Label gonderenLabel = new Label
            {
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Underline),
                ForeColor = Color.Blue,
                Text = $"Gönderen: {gonderen}",
                Location = new Point(20, 80),
                Cursor = Cursors.Hand
            };
            gonderenLabel.Click += (sender, e) =>
            {
                OpenBrowser($"https://tronscan.org/#/address/{gonderen}");
            };
            mainPanel.Controls.Add(gonderenLabel);

            Label aliciLabel = new Label
            {
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Underline),
                ForeColor = Color.Blue,
                Text = $"Alıcı: {alici}",
                Location = new Point(20, 110),
                Cursor = Cursors.Hand
            };
            aliciLabel.Click += (sender, e) =>
            {
                OpenBrowser($"https://tronscan.org/#/address/{alici}");
            };
            mainPanel.Controls.Add(aliciLabel);

            Label tutarLabel = new Label
            {
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Underline),
                Text = $"Tutar: {tutar} {tokenName}",
                Location = new Point(20, 140),

            };
            mainPanel.Controls.Add(tutarLabel);

            Button trackButton = new Button
            {
                Text = "Takip Et",
                Size = new Size(100, 30),
                Location = new Point(80, 200)
            };
            trackButton.Click += (sender, e) =>
            {
                bool isVisible = MainForm.Instance.ProgressBarPublic.Visible;
                if (!isVisible)
                {
                    if (!label.Text.StartsWith("Takip edildi"))
                    {
                        MainForm.Instance.ProgressBarPublic.Visible = true;
                        GetTransaction(hash, alici, panelMain, label);
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Daha önce takip ettiniz! Okları rengine göre takip edin");
                    }
                }
                else
                {
                    MessageBox.Show("İşlem devam ediyor!");
                }
            };
            mainPanel.Controls.Add(trackButton);

            Button closeButton = new Button
            {
                Text = "Kapat",
                Size = new Size(100, 30),
                Location = new Point(320, 200)
            };
            closeButton.Click += (sender, e) => this.Close();
            mainPanel.Controls.Add(closeButton);

            this.Controls.Add(mainPanel);
        }

        private void OpenBrowser(string url)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Tarayıcı açılamadı: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetTransaction(string hash, string toaddress, Panel panelMain, Label label)
        {
            Random random = new Random();
            int lastControl = Functions.OtherFuncs.LastFormControls(panelMain);
            int width = 40;
            int height = lastControl - label.Bottom + 30;
            int locX = label.Left;
            int locY = label.Bottom;
            string direction = "down";
            Color color = ContrastingColor.GenerateRandomColor();
            Panel arrow = Functions.OtherFuncs.CreateArrowPanel(locX + random.Next(1, label.Width), locY, width, height, color, direction);
            panelMain.Controls.Add(arrow);
            AccountTransactions accountTransactions = new AccountTransactions();
            _ = accountTransactions.GetWalletTransactions(hash, toaddress, panelMain, color, direction, locX, locY);
            label.Text = $"Takip edildi\n{label.Text}"; 
        }
    }
}
