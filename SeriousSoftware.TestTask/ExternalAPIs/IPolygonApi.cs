namespace SeriousSoftware.TestTask.ExternalAPIs
{
    public interface IPolygonApi
    {
        public Task<PolygonDataResponse> GetStockPrices(string symbol);
    }
}
