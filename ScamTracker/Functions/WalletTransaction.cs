using ScamTracker.Functions.Apis;
using ScamTracker.Model.Wallets;
using System;

namespace ScamTracker.Functions
{
    public class WalletTransaction
    {
        public static async Task<List<TransactionData>> GetDataAsync(string hash, string toaddress, Panel panelMain, Color color, string direction, int locX = 10, int locY = 10)
        {
            var client2 = new WalletApiClient();

            List<TransactionData> walletDataListData = new List<TransactionData>();
            TransactionData outtransaction = new TransactionData();
            bool hasDuplicateBlockTimestamp = false;

            hasDuplicateBlockTimestamp = await DataAnalyze(toaddress, panelMain, locX, client2, walletDataListData, outtransaction, hasDuplicateBlockTimestamp);

            walletDataListData.Reverse();
            CalculateBalance(walletDataListData);

            TransactionData targetdata = walletDataListData.First(x => x.Hash == hash);
            int targetindex = walletDataListData.IndexOf(targetdata);
            decimal targetamount = AmountConverter.ConvertToDecimal(targetdata.Amount, targetdata.Decimals);
            decimal targetbalance = targetindex == 0 ? 0 : walletDataListData[targetindex - 1].Balance;
            decimal sumAmount = 0;

            List<TransactionData> TransactionDataList = new List<TransactionData>();
            DefinitionTargetWallets(walletDataListData, targetindex, targetamount, ref targetbalance, ref sumAmount, TransactionDataList);

            int transactionDataListCount = TransactionDataList.Count;
            outtransaction = TransactionDataList.First();
            DynamicLabel dynamicLabel = new DynamicLabel();
            Label newlabel = dynamicLabel.Create(walletDataListData, outtransaction, panelMain, locX, locY, false, transactionDataListCount, color, direction);
            bool isRight = TransactionDataList.Count > 1;
            direction = "down";


            if (isRight)
            {
                AddLabel(panelMain, color, direction, walletDataListData, TransactionDataList, ref transactionDataListCount, ref newlabel, isRight);
            }
            else
            {
                newlabel.Text = $"Takip edildi\n{newlabel.Text}";
                Panel arrow = OtherFuncs.CreateArrowPanel(newlabel.Right - (newlabel.Width / 2), newlabel.Bottom, 30, 40, color, "down");
                panelMain.Controls.Add(arrow);
            }
            return TransactionDataList;
        }

        private static async Task<bool> DataAnalyze(string toaddress, Panel panelMain, int locX, WalletApiClient client2, List<TransactionData> walletDataListData, TransactionData outtransaction, bool hasDuplicateBlockTimestamp)
        {
            for (int i = 0; ; i++)
            {
                try
                {
                    await Task.Delay(300);
                    List<TransactionData> walletDatas = await client2.GetWalletInfoAsync(address: toaddress, start: i * 50, limit: 50, direction: 0);
                    walletDataListData.AddRange(walletDatas);
                    hasDuplicateBlockTimestamp = walletDatas
                                                       .GroupBy(w => w.Block_Timestamp)
                                                       .Any(g => g.Count() > 2);

                    if (walletDatas.Count < 50)
                    {
                        break;
                    }

                    if (hasDuplicateBlockTimestamp)
                    {
                        await ExchangeControl(toaddress, panelMain, outtransaction, locX);
                        MainForm.Instance.ProgressBarPublic.Visible = false;
                        break;
                    }

                    if (walletDatas.Count > 10000)
                    {
                        await ExchangeControl(toaddress, panelMain, outtransaction, locX);
                        MainForm.Instance.ProgressBarPublic.Visible = false;
                        break;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            return hasDuplicateBlockTimestamp;
        }

        private static void AddLabel(Panel panelMain, Color color, string direction, List<TransactionData> walletDataListData, List<TransactionData> TransactionDataList, ref int transactionDataListCount, ref Label newlabel, bool isRight)
        {
            for (int i = 1; i < TransactionDataList.Count; i++)
            {
                TransactionData outtransactionSub = TransactionDataList[i];
                DynamicLabel subdynamicLabel = new DynamicLabel();
                newlabel = subdynamicLabel.Create(walletDataListData, outtransactionSub, panelMain, newlabel.Right + 10, newlabel.Top, isRight, --transactionDataListCount, color, direction);

                PictureBox pictureBoxSub = new PictureBox();
                pictureBoxSub.Image = Image.FromFile("../../../assets/line.png");
                pictureBoxSub.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxSub.Size = new System.Drawing.Size(30, 10);
                pictureBoxSub.Location = new Point(newlabel.Left - 30, newlabel.Top + (newlabel.Height / 2));
                panelMain.Controls.Add(pictureBoxSub);
            }
        }

        private static void DefinitionTargetWallets(List<TransactionData> walletDataListData, int targetindex, decimal targetamount, ref decimal targetbalance, ref decimal sumAmount, List<TransactionData> TransactionDataList)
        {
            for (int i = targetindex + 1; i < walletDataListData.Count; i++) //hedef paranın gönderildiği cüzdanlar tespit ediliyor
            {
                if (walletDataListData[i].Direction == 1)
                {
                    if ((i + 1) == walletDataListData.Count)
                    {
                        break;
                    }
                    else
                    {
                        decimal amnt = AmountConverter.ConvertToDecimal(walletDataListData[i].Amount, walletDataListData[i].Decimals);
                        targetbalance = targetbalance - amnt;

                        if (targetbalance <= 0)
                        {
                            sumAmount += amnt;
                            if (amnt > 0)
                            {
                                TransactionDataList.Add(walletDataListData[i]);
                            }
                            if (sumAmount >= targetamount)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        private static void CalculateBalance(List<TransactionData> walletDataListData)
        {
            for (int i = 0; i < walletDataListData.Count; i++)  //balance hesaplaması yapılıyor
            {
                int k = i == 0 ? 0 : i - 1;
                decimal amountt = AmountConverter.ConvertToDecimal(walletDataListData[i].Amount, walletDataListData[i].Decimals);
                walletDataListData[i].Balance = walletDataListData[i].Direction == 2 ? walletDataListData[k].Balance + amountt : walletDataListData[k].Balance - amountt;
            }
        }

        private static async Task ExchangeControl(string toaddress, Panel panel, TransactionData outtransaction, int locX)
        {
            AccountTransactions accountTransactions = new AccountTransactions();
            TronAccount account = await accountTransactions.GetAccountInfoAsync<TronAccount>(toaddress);
            outtransaction.Hash = "Exchange";
            outtransaction.To = toaddress;
            outtransaction.Token_Name = account.AddressTag;
            string text = $"Para {account.AddressTag + " isimli" ?? "KİMLİĞİ BELİRSİZ bir"} Exchange Firmasına Ulaştı!\nBir önceki işlemin bilgilerini {account.AddressTag} firmasından talep ediniz. \nAdres: {toaddress}";

            int yOffset = 10;
            int spacing = 10;

            Label dynamicLabel = new Label
            {
                Text = text,
                AutoSize = true,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(8),
                BackColor = Color.DarkRed,
                ForeColor = Color.White,
                Name = toaddress
            };

            int currentY = yOffset;
            foreach (Control control in panel.Controls)
            {
                currentY = Math.Max(currentY, control.Bottom + spacing);
            }

            dynamicLabel.Location = new Point(locX, currentY);
            panel.Controls.Add(dynamicLabel);
        }
    }
}