using ScamTracker.Model.Transactions;

namespace ScamTracker.Functions.Apis
{
    public class TransactionApiClient : BaseApiClient
    {
        private const string BaseUrl = "https://apilist.tronscanapi.com/api/transaction-info";

        public async Task<Transaction> GetTransactionInfoAsync(string hash)
        {
            string url = $"{BaseUrl}?hash={hash}";
            return await GetAsync<Transaction>(url);
        }
    }
}
