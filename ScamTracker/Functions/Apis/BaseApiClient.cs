using Newtonsoft.Json;

public abstract class BaseApiClient
{
    protected readonly HttpClient _client;

    public BaseApiClient()
    {
        _client = new HttpClient();
    }

    public async Task<T> GetAsync<T>(string url, int maxRetryAttempts = 10, int delayMilliseconds = 5000)
    {
        int retryAttempts = 0;

        while (true)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseData = await response.Content.ReadAsStringAsync();

                if (responseData.Contains("internal server error"))
                {
                    throw new Exception("Internal server error detected in response data.");
                }

                T result = JsonConvert.DeserializeObject<T>(responseData);
                return result;
            }
            catch (Exception ex)
            {
                retryAttempts++;
                
                if (retryAttempts >= maxRetryAttempts)
                {
                    throw new Exception($"Failed after {maxRetryAttempts} attempts. Last error: {ex.Message}");
                }

                await Task.Delay(delayMilliseconds);
            }
        }
    }
}