using Newtonsoft.Json;

namespace SeriousSoftware.Services.ExternalAPIs
{
    public class PolygonDataResponse
    {
        /// <summary>
        /// The exchange symbol that this item is traded under.
        /// </summary>
        [JsonProperty("ticker")]
        public string Ticker { get; set; }

        /// <summary>
        /// The number of aggregates (minute or day) used to generate the response.
        /// </summary>
        [JsonProperty("queryCount")]
        public int QueryCount { get; set; }

        /// <summary>
        /// The total number of results for this request.
        /// </summary>
        [JsonProperty("resultsCount")]
        public int ResultsCount { get; set; }

        /// <summary>
        /// Whether or not this response was adjusted for splits.
        /// </summary>
        [JsonProperty("adjusted")]
        public bool Adjusted { get; set; }

        [JsonProperty("results")]
        public List<PolygonResult> PolygonResults { get; set; }
    }

    public class PolygonResult
    {
        /// <summary>
        /// The trading volume of the symbol in the given time period.
        /// </summary>
        [JsonProperty("v")]
        public decimal Volume { get; set; }

        /// <summary>
        /// The volume weighted average price.
        /// </summary>
        [JsonProperty("vw")]
        public decimal VolumeWeightedAvgPrice { get; set; }

        /// <summary>
        /// The open price for the symbol in the given time period.
        /// </summary>
        [JsonProperty("o")]
        public decimal Open { get; set; }

        /// <summary>
        /// The close price for the symbol in the given time period.
        /// </summary>
        [JsonProperty("c")]
        public decimal Close { get; set; }

        /// <summary>
        /// The highest price for the symbol in the given time period.
        /// </summary>
        [JsonProperty("h")]
        public decimal High { get; set; }

        /// <summary>
        /// The lowest price for the symbol in the given time period.
        /// </summary>
        [JsonProperty("l")]
        public decimal Low { get; set; }

        /// <summary>
        /// The Unix Msec timestamp for the start of the aggregate window.
        /// </summary>
        [JsonProperty("t")]
        public long TimeStamp { get; set; }

        /// <summary>
        /// The number of transactions in the aggregate window.
        /// </summary>
        [JsonProperty("n")]
        public int TransactionsCount { get; set; }
    }
}
