using AutoMapper;
using SeriousSoftware.TestTask.Storage.Models;

namespace SeriousSoftware.TestTask.Mappings
{
    public class StockPriceProfile : Profile
    {
        public StockPriceProfile()
        {
            CreateMap<PolygonResult, StockPrice>();
        }
    }
}
