using Microsoft.AspNetCore.Mvc;
using SeriousSoftware.TestTask;
using System.Net;
using Newtonsoft.Json;
using SeriousSoftware.TestTask.Storage.Repositories;
using AutoMapper;
using SeriousSoftware.TestTask.Storage.Models;
using SeriousSoftware.TestTask.ExternalAPIs;

namespace SeriousSoftware.TestTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IStockPriceRepository _stockPriceRepository;
        private readonly IMapper _mapper;
        private readonly IPolygonApi _polygonApi;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, 
            IStockPriceRepository stockPriceRepository,
            IPolygonApi polygonApi,
            IMapper mapper)
        {
            _logger = logger;
            _stockPriceRepository = stockPriceRepository;
            _mapper = mapper;
            _polygonApi = polygonApi;
        }

        [HttpGet("GetStockData")]
        public ActionResult GetStockData()
        {
            string QUERY_URL = "https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol=IBM&interval=5min&apikey=demo";
            Uri queryUri = new Uri(QUERY_URL);

            using (WebClient client = new WebClient())
            {
                // -------------------------------------------------------------------------
                // if using .NET Framework (System.Web.Script.Serialization)

                //JavaScriptSerializer js = new JavaScriptSerializer();
                
                //var json_data = JsonSerializer.Deserialize(client.DownloadString(queryUri), typeof(object));

                //// -------------------------------------------------------------------------
                //// if using .NET Core (System.Text.Json)
                //// using .NET Core libraries to parse JSON is more complicated. For an informative blog post
                //// https://devblogs.microsoft.com/dotnet/try-the-new-system-text-json-apis/

                //dynamic json_data = JsonSerializer.Deserialize<Dictionary<string, dynamic>>(client.DownloadString(queryUri));

                // -------------------------------------------------------------------------

                // do something with the json_data
            }

            return Ok();
        }

        [HttpGet("GetPolygonStockData/{symbol}")]
        public async Task<ActionResult> GetPolygonStockData(string symbol)
        {
            return Ok(await _polygonApi.GetStockPrices(symbol));
        }

        [HttpPost("StoreStockPrices/{symbol}")]
        public async Task<ActionResult> Store(string symbol)
        {
            var prices = await _polygonApi.GetStockPrices(symbol);

            if (prices == null) return BadRequest();

            _stockPriceRepository.Save(prices.PolygonResults.Select(p => _mapper.Map<StockPrice>(p)).ToList());

            return Ok();
        }

        [HttpGet("CalculatePerformance/{symbol}")]
        public async Task<ActionResult> CalculatePerformance(string symbol)
        {
            var prices = await _polygonApi.GetStockPrices(symbol);

            if (prices == null) return BadRequest();


        }
    }
}