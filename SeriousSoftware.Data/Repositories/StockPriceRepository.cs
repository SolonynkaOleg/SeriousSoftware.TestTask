using SeriousSoftware.Data.Models;

namespace SeriousSoftware.Data.Repositories
{
    public class StockPriceRepository : IStockPriceRepository
    {
        public List<StockPrice> GetStockPrices()
        {
            using (var context = new StocksInMemoryDbContext())
            {
                return context.StockPrices.ToList();
            }
        }

        public void Save(List<StockPrice> stockPrices)
        {
            using(var context = new StocksInMemoryDbContext())
            {
                context.StockPrices.AddRange(stockPrices);
                context.SaveChanges();
            }
        }
    }
}
