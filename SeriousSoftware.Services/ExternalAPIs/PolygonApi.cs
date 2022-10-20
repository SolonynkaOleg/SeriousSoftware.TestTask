using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SeriousSoftware.Services.ExternalAPIs;

namespace SeriousSoftware.Services.ExternalAPIs
{
    public class PolygonApi : IPolygonApi
    {
        private HttpClient _client;
        private PolygonApiSettings _settings;
        public PolygonApi(HttpClient client, IOptions<PolygonApiSettings> apiOptions)
        {
            _client = client;
            _settings = apiOptions.Value;
            _client.BaseAddress = new Uri(_settings.Url);
        }

        public async Task<PolygonDataResponse> GetStockPrices(string symbol, DateTime start, DateTime end)
        {
            var response = await _client.GetAsync($"aggs/ticker/{symbol}/range/1/day/{start:yyyy-MM-dd}/{end:yyyy-MM-dd}?adjusted=true&sort=asc&limit=120&apiKey={_settings.ApiKey}");
            return JsonConvert.DeserializeObject<PolygonDataResponse>(await response.Content.ReadAsStringAsync());
        }
    }
}
