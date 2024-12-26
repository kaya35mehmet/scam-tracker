using Newtonsoft.Json;

namespace ScamTracker.Functions.Apis
{
    public class AccountService
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public async Task<T> GetAccountDataAsync<T>(string address)
        {
            string url = $"https://apilist.tronscanapi.com/api/accountv2?address={address}";
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string jsonResponse = await response.Content.ReadAsStringAsync();

            T account = JsonConvert.DeserializeObject<T>(jsonResponse);
            return account;

        }
    }
}
