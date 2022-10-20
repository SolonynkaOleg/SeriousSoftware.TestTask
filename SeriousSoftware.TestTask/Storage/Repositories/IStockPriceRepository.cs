using SeriousSoftware.TestTask.Storage.Models;

namespace SeriousSoftware.TestTask.Storage.Repositories
{
    public interface IStockPriceRepository
    {
        public List<StockPrice> GetStockPrices();
        public void Save(List<StockPrice> stockPrices);
    }
}
