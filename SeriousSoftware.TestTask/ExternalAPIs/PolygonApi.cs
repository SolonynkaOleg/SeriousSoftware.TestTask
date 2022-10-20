using Newtonsoft.Json;

namespace SeriousSoftware.TestTask.ExternalAPIs
{
    public class PolygonApi : IPolygonApi
    {
        private readonly IConfiguration _configuration;
        public PolygonApi(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<PolygonDataResponse> GetStockPrices(string symbol)
        {
            var QUERY_URL = $"https://api.polygon.io/v2/aggs/ticker/{symbol}/range/1/day/2022-10-06/2022-10-13?adjusted=true&sort=asc&limit=120&apiKey={_configuration["Polygon:ApiKey"]}";
            var queryUri = new Uri(QUERY_URL);

            using (var client = new HttpClient())
            {
                var message = await client.GetAsync(queryUri);
                return JsonConvert.DeserializeObject<PolygonDataResponse>(await message.Content.ReadAsStringAsync());
            }
        }
}
