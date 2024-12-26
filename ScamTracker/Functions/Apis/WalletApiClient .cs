using ScamTracker.Model.Wallets;

namespace ScamTracker.Functions.Apis
{
    public class WalletApiClient : BaseApiClient
    {
        private const string BaseUrl = "https://apilist.tronscanapi.com/api/transfer/trc20";

        public async Task<List<TransactionData>> GetWalletInfoAsync(
            string address,
            int start = 0,
            int limit = 50,
            int direction = 0)
        {
            string trc20Id = "TR7NHqjeKQxGTCi8q8ZY4pL8otSzgjLj6t";
            string url = $"{BaseUrl}?address={address}&trc20Id={trc20Id}&start={start}&limit={limit}&direction={direction}&reverse=true&db_version=1&start_timestamp=&end_timestamp=";

            var data = await GetAsync<model.Wallets.WalletTransaction>(url);
            return data.Data;
        }
    }
}