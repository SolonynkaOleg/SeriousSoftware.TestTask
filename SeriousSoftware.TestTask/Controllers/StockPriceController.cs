using Microsoft.AspNetCore.Mvc;
using SeriousSoftware.Data.Repositories;
using AutoMapper;
using SeriousSoftware.Data.Models;
using SeriousSoftware.Services.ExternalAPIs;
using SeriousSoftware.Services;

namespace SeriousSoftware.WepApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StockPriceController : ControllerBase
    {
        private readonly ILogger<StockPriceController> _logger;
        private readonly IStockPriceRepository _stockPriceRepository;
        private readonly IMapper _mapper;
        private readonly IPolygonApi _polygonApi;
        private readonly IPerformanceCalculator _performanceCalculator;

        public StockPriceController(ILogger<StockPriceController> logger, 
            IStockPriceRepository stockPriceRepository,
            IPolygonApi polygonApi,
            IPerformanceCalculator performanceCalculator,
            IMapper mapper)
        {
            _logger = logger;
            _stockPriceRepository = stockPriceRepository;
            _mapper = mapper;
            _polygonApi = polygonApi;
            _performanceCalculator = performanceCalculator;
        }

        [HttpGet("GetPolygonStockData/{symbol}")]
        public async Task<ActionResult> GetPolygonStockData(string symbol, [FromQuery]DateTime start, [FromQuery] DateTime end)
        {
            return Ok(await _polygonApi.GetStockPrices(symbol, start, end));
        }

        [HttpPost("StoreStockPrices/{symbol}")]
        public async Task<ActionResult> Store(string symbol, [FromQuery] DateTime start, [FromQuery] DateTime end)
        {
            var prices = await _polygonApi.GetStockPrices(symbol, start, end);

            if (prices == null) return BadRequest();

            _stockPriceRepository.Save(prices.PolygonResults.Select(p => _mapper.Map<StockPrice>(p)).ToList());

            return Ok();
        }

        [HttpGet("CalculatePerformance/{symbol}")]
        public async Task<ActionResult> CalculatePerformance(string symbol, [FromQuery] DateTime start, [FromQuery] DateTime end)
        {
            var prices = await _polygonApi.GetStockPrices(symbol, start, end);

            if (prices == null) return BadRequest();

            var priceModelList = prices.PolygonResults.Select(r => new Services.Models.PriceModel { Price = r.Close, Time = DateTimeOffset.FromUnixTimeMilliseconds(r.TimeStamp) }).ToList();
            var performance = _performanceCalculator.CalculatePerformance(priceModelList);

            return Ok(performance);
        }
    }
}