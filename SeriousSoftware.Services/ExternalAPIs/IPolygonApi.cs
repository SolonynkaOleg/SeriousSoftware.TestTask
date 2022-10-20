namespace SeriousSoftware.Services.ExternalAPIs
{
    public interface IPolygonApi
    {
        public Task<PolygonDataResponse> GetStockPrices(string symbol, DateTime start, DateTime end);
    }
}
