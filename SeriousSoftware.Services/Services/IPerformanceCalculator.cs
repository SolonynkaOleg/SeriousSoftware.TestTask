using SeriousSoftware.Services.Models;

namespace SeriousSoftware.Services
{
    public interface IPerformanceCalculator
    {
        public List<StockPerformance> CalculatePerformance(List<PriceModel> prices);
    }
}
