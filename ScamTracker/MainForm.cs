using ScamTracker.Functions;
using ScamTracker.Functions.Apis;
using ScamTracker.Model.Transactions;
using System.Text;

namespace ScamTracker
{
    public partial class MainForm : Form
    {
        public static MainForm Instance { get; private set; }
        public ProgressBar ProgressBarPublic => progressBar1;
        private Color titleBarColor = Color.CadetBlue;
        private Color titleTextColor = Color.White;
        private Rectangle closeButtonRect;
        private Image? closeIcon;
        private bool isDragging = false;
        private Point dragStartPoint;
        private Panel panel;
        private Panel panelMain;
        private Point lastMousePos;

        public MainForm()
        {
            InitializeComponent();
            Instance = this;
            this.MaximizedBounds = Screen.GetWorkingArea(this);
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializePanels();
        }

        private void InitializePanels()
        {
            panel = new Panel
            {
                AutoScroll = true,
                BackColor = Color.White,
                Location = new Point(10, panel1.Height + 100),
                Size = new Size(Screen.PrimaryScreen.Bounds.Width - 20, Screen.PrimaryScreen.Bounds.Height - (panel1.Height + 50)),
            };

            panelMain = new Panel
            {
                Size = new Size(Screen.PrimaryScreen.Bounds.Width - 20, Screen.PrimaryScreen.Bounds.Height - (panel1.Height + 50)) * 8,
                BackColor = Color.White,
                AutoScroll = true,
            };

            panelMain.MouseDown += PanelMain_MouseDown;
            panelMain.MouseMove += PanelMain_MouseMove;
            panelMain.MouseUp += PanelMain_MouseUp;

            panel.Controls.Add(panelMain);
            this.Controls.Add(panel);
            closeIcon = Image.FromFile("../../../assets/close.png");
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawTitleBar(e.Graphics);
        }

        private void PanelMain_MouseDown(object? sender, MouseEventArgs e)
        {
            isDragging = true;
            lastMousePos = e.Location;
        }

        private void PanelMain_MouseMove(object? sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                var dx = e.X - lastMousePos.X;
                var dy = e.Y - lastMousePos.Y;
                panel.AutoScrollPosition = new Point(-panel.AutoScrollPosition.X - dx, -panel.AutoScrollPosition.Y - dy);
            }
        }

        private void PanelMain_MouseUp(object? sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Y < 40)
            {
                isDragging = true;
                dragStartPoint = e.Location;
            }

            if (closeButtonRect.Contains(e.Location))
            {
                this.Close();
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (isDragging)
            {
                this.Location = new Point(
                    this.Left + e.X - dragStartPoint.X,
                    this.Top + e.Y - dragStartPoint.Y
                );
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            isDragging = false;
        }

        private async void btn_Baslat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Lütfen TXID girin!");
                return;
            }

            btn_Baslat.Text = "Ýþlem Yapýlýyor";
            btn_Baslat.Enabled = false;

            await GetTransaction();

            btn_Baslat.Text = "PNG KAYDET";
            btn_Baslat.Click -= btn_Baslat_Click;
            btn_Baslat.Click += SaveAsPng;
            btn_Baslat.Enabled = true;
        }

        private void SaveAsPng(object? sender, EventArgs e)
        {
            using SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PNG Files (*.png)|*.png",
                DefaultExt = "png",
                AddExtension = true,
                Title = "PNG Olarak Kaydet"
            };

            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

            Bitmap bitmap = new Bitmap(panelMain.Width, panelMain.Height);
            panelMain.DrawToBitmap(bitmap, new Rectangle(0, 0, panelMain.Width, panelMain.Height));
            bitmap.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);

            MessageBox.Show("PNG dosyasý baþarýyla kaydedildi: " + saveFileDialog.FileName);
        }

        private void DrawTitleBar(Graphics g)
        {
            using Brush brush = new SolidBrush(titleBarColor);
            g.FillRectangle(brush, 0, 0, this.Width, 40);

            string titleText = "SCAM TRACKER";
            using Font font = new Font("Segoe UI", 14, FontStyle.Bold);
            using Brush textBrush = new SolidBrush(titleTextColor);
            {
                SizeF textSize = g.MeasureString(titleText, font);
                float textX = (this.Width - textSize.Width) / 2;
                g.DrawString(titleText, font, textBrush, textX, 10);
            }

            closeButtonRect = new Rectangle(this.Width - 40, 5, 30, 30);
            using Brush closeBrush = new SolidBrush(Color.Red);
            g.FillRectangle(closeBrush, closeButtonRect);

            if (closeIcon != null)
            {
                Image resizedIcon = new Bitmap(closeIcon, new Size(20, 20));
                int x = closeButtonRect.X + (closeButtonRect.Width - resizedIcon.Width) / 2;
                int y = closeButtonRect.Y + (closeButtonRect.Height - resizedIcon.Height) / 2;
                g.DrawImage(resizedIcon, x, y);
            }
        }

        private async Task GetTransaction()
        {
            try
            {
                progressBar1.Visible = true;
                string hash = textBox1.Text;

                if (!HashValidator.IsValidHash(hash))
                {
                    MessageBox.Show("TXID deðeri yanlýþ!");
                    return;
                }

                var client = new TransactionApiClient();
                Transaction transaction = await client.GetTransactionInfoAsync(hash);

                if (transaction.Hash == null)
                {
                    MessageBox.Show("Ýþlem bulunamadý! TXID kontrolü gerekiyor!");
                    return;
                }

                string toAddress = GetMainTransaction(transaction);
                Color color = ContrastingColor.GenerateRandomColor();
                AccountTransactions accountTransactions = new AccountTransactions();
                await accountTransactions.GetWalletTransactions(hash, toAddress, panelMain, color, "down", 10, 10);
            }
            finally
            {
                progressBar1.Visible = false;
            }
        }

        private string GetMainTransaction(Transaction transaction)
        {
            var info = transaction.Trc20TransferInfo[0];
            decimal convertedAmount = AmountConverter.ConvertToDecimal(info.Amount_Str, info.Decimals);

            lblResult.Text = new StringBuilder()
                .AppendLine("TAKÝP EDÝLECEK ÝÞLEMÝN DETAYLARI")
                .AppendLine($"Hash: {transaction.Hash}")
                .AppendLine($"Tarih: {Functions.OtherFuncs.ConvertUnixTimestampToDateTime(transaction.Timestamp)} UTC")
                .AppendLine($"Gönderen: {info.From_Address}")
                .AppendLine($"Alýcý: {info.To_Address}")
                .AppendLine($"Tutar: {convertedAmount} {info.Name}")
                .ToString();

            lblResult.BorderStyle = BorderStyle.FixedSingle;
            lblResult.Padding = Padding.Add(new Padding(8), new Padding(8));
            lblResult.BackColor = Color.WhiteSmoke;

            return info.To_Address;
        }
    }
}
