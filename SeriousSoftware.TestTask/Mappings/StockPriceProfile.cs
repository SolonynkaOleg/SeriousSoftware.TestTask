using AutoMapper;
using SeriousSoftware.Data.Models;
using SeriousSoftware.Services.ExternalAPIs;

namespace SeriousSoftware.WepApi.Mappings
{
    public class StockPriceProfile : Profile
    {
        public StockPriceProfile()
        {
            CreateMap<PolygonResult, StockPrice>();
        }
    }
}
