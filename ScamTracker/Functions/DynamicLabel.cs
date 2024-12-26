using ScamTracker.Model.Wallets;

namespace ScamTracker.Functions
{
    public class DynamicLabel
    {
        public Label Create(List<TransactionData> data, TransactionData transaction, Panel panel, int xOffset, int yOffset, bool isRight, int name, Color color, string directions)
        {
            string text = $"Hash: {HashValidator.GetShortenedHash(transaction.Hash)}\n" +
                          $"Tarih: {OtherFuncs.ConvertUnixTimestampToDateTime(transaction.Block_Timestamp)} UTC\n" +
                          $"Gönderen : {HashValidator.GetShortenedHash(transaction.From)}\n" +
                          $"Alıcı : {HashValidator.GetShortenedHash(transaction.To)}\n" +
                          $"Tutar: {AmountConverter.ConvertToDecimal(transaction.Amount, transaction.Decimals)} {transaction.Token_Name}";

            int spacing = 10; 

            Label dynamicLabel = new Label
            {
                Text = text, AutoSize = true,  BorderStyle = BorderStyle.FixedSingle, Padding = new Padding(8), BackColor = color, ForeColor = ContrastingColor.GetContrastingColor(color),  Name = $"{name}",
            };
            
            dynamicLabel.MouseClick += (s, e) =>
            {
                if (e.Button == MouseButtons.Right) 
                {
                    panelTransactionForm transactionForm = new panelTransactionForm(transaction.Hash,
                         OtherFuncs.ConvertUnixTimestampToDateTime(transaction.Block_Timestamp), transaction.From, transaction.To, AmountConverter.ConvertToDecimal(transaction.Amount, transaction.Decimals).ToString(), transaction.Token_Name, panel, dynamicLabel, dynamicLabel.Top, dynamicLabel.Right);
                    transactionForm.ShowDialog();
                }
                else
                {
                    var dataForm = new DataForm(data, $"{transaction.From} adresli cüzdan işlemleri");
                    dataForm.Show();
                }
            };
           
            int currentX = xOffset;
            int currentY = yOffset;

            if (!isRight)
            {
                foreach (Control control in panel.Controls)
                {
                    currentY = Math.Max(currentY, control.Bottom + spacing);
                }
            }

            dynamicLabel.Location = new Point(currentX, currentY);
            panel.Controls.Add(dynamicLabel);
            return dynamicLabel;
        }
    }
}
