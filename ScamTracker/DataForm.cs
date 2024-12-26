using System.Data;
using ScamTracker.Functions;
using ScamTracker.Model.Wallets;

namespace ScamTracker
{
    public partial class DataForm : Form
    {
        private DataGridView dataGridView;
        private DataTable dataTable;
        public DataForm(List<TransactionData> data, string title)
        {
            InitializeComponent();
            this.Text = title;
            this.Size = new Size(800, 600);

            dataGridView = new DataGridView // DataGridView oluştur
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            this.Controls.Add(dataGridView);
            BindDataToGrid(data);
        }

        private void BindDataToGrid(List<TransactionData> data)
        {
            dataTable = new DataTable();
            dataTable.Columns.Add("Hash", typeof(string));
            dataTable.Columns.Add("Tarih (UTC +0)", typeof(string));
            dataTable.Columns.Add("Gönderen", typeof(string));
            dataTable.Columns.Add("Alıcı", typeof(string));
            dataTable.Columns.Add("Tutar", typeof(decimal));
            dataTable.Columns.Add("Bakiye", typeof(string));

            foreach (var item in data)
            {
                dataTable.Rows.Add(item.Hash.ToString(), Functions.OtherFuncs.ConvertUnixTimestampToDateTime(item.Block_Timestamp).ToString(), item.From.ToString(), item.To.ToString(), item.Direction == 1 ? -1 * AmountConverter.ConvertToDecimal(item.Amount, item.Decimals) : AmountConverter.ConvertToDecimal(item.Amount, item.Decimals), item.Balance.ToString());
            }

            dataGridView.DataSource = dataTable; 
        }

        private void btnToExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Dosyası (*.xlsx)|*.xlsx";
                saveFileDialog.Title = "Excel Dosyasını Kaydet";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Functions.OtherFuncs.ExportDataTableToExcel(dataTable, saveFileDialog.FileName);
                }
            }
        }
    }
}
