using ClosedXML.Excel;
using ScamTracker.Model.Wallets;
using System.Data;
using System.Drawing;

namespace ScamTracker.Functions
{
    public class OtherFuncs
    {
        public static void DisplayTable(List<TransactionData> data, Panel panel)
        {
            DataGridView dataGridView = new DataGridView
            {
                Margin = new Padding(top: 500, left: 0, right: 0, bottom: 0),
                Dock = DockStyle.Fill, // Panelin tamamını kaplar
                DataSource = data, // Listeyi tabloya bağlar
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, // Sütunları eşit dağıtır
                ReadOnly = true, // Tablonun sadece okunabilir olmasını sağlar
                AllowUserToAddRows = false // Boş satır eklemeyi engeller
            };

            // DataGridView'i panelin içine ekle
            panel.Controls.Clear(); // Panelin içini temizle
            panel.Controls.Add(dataGridView);
        }

        public static DateTime ConvertUnixTimestampToDateTime(long unixTimestampMillis)
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddMilliseconds(unixTimestampMillis);
        }

        public static void ExportDataTableToExcel(DataTable dataTable, string filePath)
        {
            try
            {
                // Yeni bir Excel dosyası oluştur
                using (var workbook = new XLWorkbook())
                {
                    // Çalışma sayfası oluştur
                    var worksheet = workbook.Worksheets.Add("Transactions");

                    // Sütun başlıklarını ekle
                    for (int col = 0; col < dataTable.Columns.Count; col++)
                    {
                        worksheet.Cell(1, col + 1).Value = dataTable.Columns[col].ColumnName;
                    }

                    // Hücre verilerini ekle
                    for (int row = 0; row < dataTable.Rows.Count; row++)
                    {
                        for (int col = 0; col < dataTable.Columns.Count; col++)
                        {
                            worksheet.Cell(row + 2, col + 1).Value = dataTable.Rows[row][col]?.ToString() ?? string.Empty;
                        }
                    }

                    // Tarih formatını ayarla (örnek için Tarih sütununu ele alalım)
                    worksheet.Column(2).Style.DateFormat.Format = "yyyy-MM-dd HH:mm:ss"; // 2. sütun "Tarih (UTC +0)" sütununa denk geliyor

                    // Sayısal sütunlar için biçimlendirme (Tutar sütunu)
                    worksheet.Column(5).Style.NumberFormat.Format = "#,##0.00"; // 5. sütun "Tutar" sütunu

                    // Otomatik sütun genişliği
                    worksheet.Columns().AdjustToContents();

                    // Dosyayı kaydet
                    workbook.SaveAs(filePath);
                }

                MessageBox.Show("Excel dosyası başarıyla kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static int LastFormControls(Panel panel)
        {
            int currentY = 10;
            foreach (System.Windows.Forms.Control control in panel.Controls) 
            {
                 currentY = Math.Max(currentY, control.Bottom + 10); 
            }
            return currentY;
        }

        //public static bool IsBelowLabel(Panel panel, Label currentLabel)
        //{
        //    foreach (System.Windows.Forms.Control control in panel.Controls)
        //    {
        //        if (control is Label otherLabel && otherLabel != currentLabel)
        //        {
        //            // Altında olup olmadığını kontrol et
        //            bool isBelow =
        //                otherLabel.Top > currentLabel.Bottom && // Diğer label, mevcut label'in altında
        //                otherLabel.Left < currentLabel.Right && // Aynı dikey seviyede çakışıyor
        //                otherLabel.Right > currentLabel.Left;   // Aynı dikey seviyede çakışıyor

        //            if (isBelow)
        //            {
        //                return true;
        //            }
        //        }
        //    }
        //    return false;
        //}

        //public static bool IsAboveLabel(Panel panel, Label currentLabel)
        //{
        //    foreach (System.Windows.Forms.Control control in panel.Controls)
        //    {
        //        if (control is Label otherLabel && otherLabel != currentLabel)
        //        {
        //            // Tam üstünde olup olmadığını kontrol et
        //            bool isDirectlyAbove =
        //                otherLabel.Bottom == currentLabel.Top && // Tam üstünde olmalı
        //                otherLabel.Left == currentLabel.Left &&  // Sol kenar hizalı olmalı
        //                otherLabel.Right == currentLabel.Right;  // Sağ kenar hizalı olmalı

        //            if (isDirectlyAbove)
        //            {
        //                return true;
        //            }
        //        }
        //    }
        //    return false;
        //}

        //public static bool IsRightLabel(Panel panel, Label currentLabel)
        //{
        //    foreach (System.Windows.Forms.Control control in panel.Controls)
        //    {
        //        if (control is Label otherLabel && otherLabel != currentLabel)
        //        {
        //            // Sağında olup olmadığını kontrol et
        //            bool isToTheRight =
        //                otherLabel.Left > currentLabel.Right && // Diğer label, mevcut label'in sağında
        //                otherLabel.Top < currentLabel.Bottom && // Aynı yatay seviyede
        //                otherLabel.Bottom > currentLabel.Top;   // Aynı yatay seviyede

        //            if (isToTheRight)
        //            {
        //                return true;
        //            }
        //        }
        //    }
        //    return false;
        //}

        public static Panel CreateArrowPanel(int x, int y, int width, int height, Color color, string direction = "down")
        {
            Panel arrowPanel = new Panel
            {
                Location = new System.Drawing.Point(x, y),
                Size = new Size(width, height),
                BackColor = System.Drawing.Color.Transparent
            };

            arrowPanel.Paint += (s, e) =>
            {
                Graphics g = e.Graphics;
                Pen pen = new Pen(color, 8);
                pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;

                System.Drawing.Point startPoint = new System.Drawing.Point(0, arrowPanel.Height / 4);
                System.Drawing.Point endPoint = new System.Drawing.Point(arrowPanel.Width, arrowPanel.Height / 4);

                if (direction == "left")
                {
                    startPoint = new System.Drawing.Point(arrowPanel.Width, arrowPanel.Height / 2);
                    endPoint = new System.Drawing.Point(0, arrowPanel.Height / 2);
                }
                else if (direction == "up")
                {
                    startPoint = new System.Drawing.Point(arrowPanel.Width / 2, arrowPanel.Height);
                    endPoint = new System.Drawing.Point(arrowPanel.Width / 2, 0);
                }
                else if (direction == "down")
                {
                    startPoint = new System.Drawing.Point(arrowPanel.Width / 4, 0);
                    endPoint = new System.Drawing.Point(arrowPanel.Width / 4, arrowPanel.Height);
                }

                g.DrawLine(pen, startPoint, endPoint);
            };

            return arrowPanel;
        }

    }
}
