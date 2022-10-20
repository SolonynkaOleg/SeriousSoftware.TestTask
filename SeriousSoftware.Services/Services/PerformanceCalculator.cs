using SeriousSoftware.Services.Models;

namespace SeriousSoftware.Services
{
    public class PerformanceCalculator : IPerformanceCalculator
    {
        public List<StockPerformance> CalculatePerformance(List<PriceModel> prices)
        {
            var firstPrice = prices[0];

            return prices.Select(x => new StockPerformance { 
                Performance = (x.Price - firstPrice.Price) / firstPrice.Price * 100, 
                Date = x.Time 
            }).ToList();
        }
    }
}
