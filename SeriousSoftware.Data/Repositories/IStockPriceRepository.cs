using SeriousSoftware.Data.Models;

namespace SeriousSoftware.Data.Repositories
{
    public interface IStockPriceRepository
    {
        public List<StockPrice> GetStockPrices();
        public void Save(List<StockPrice> stockPrices);
    }
}
