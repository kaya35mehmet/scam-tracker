using ScamTracker.Functions.Apis;
using ScamTracker.Model.Wallets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ScamTracker.Functions
{
    public class AccountTransactions
    {
        public  async  Task<T> GetAccountInfoAsync<T>(string hash)
        {
            AccountService service = new AccountService();
            T account = await service.GetAccountDataAsync<T>(hash);
            return account;
        }

        public async Task GetWalletTransactions(string hash, string toaddress, Panel panelMain, Color color, string direction, int locX = 10, int locY = 10)
        {
            List<TransactionData> transactionData = await WalletTransaction.GetDataAsync(hash, toaddress, panelMain, color, direction, locX, locY);

            string transactionDataHash = transactionData[0].Hash;
            string transactionDataTo = transactionData[0].To;

            if (transactionData.Count == 1)
            {
                for (; ; )
                {
                    transactionData = await WalletTransaction.GetDataAsync(transactionDataHash, transactionDataTo, panelMain, color, direction, locX, locY);

                    if (transactionData.Count > 1)
                    {
                        MainForm.Instance.ProgressBarPublic.Visible = false;
                        break;
                    }
                    else
                    {
                        transactionDataHash = transactionData[0].Hash;
                        transactionDataTo = transactionData[0].To;
                    }
                }
            }
            else
            {
                MainForm.Instance.ProgressBarPublic.Visible = false;
            }
        }
    }
}
