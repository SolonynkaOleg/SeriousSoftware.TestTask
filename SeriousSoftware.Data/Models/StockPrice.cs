namespace SeriousSoftware.Data.Models
{
    public class StockPrice
    {
        public int Id { get; set; }
        /// <summary>
        /// The trading volume of the symbol in the given time period.
        /// </summary>
        public decimal Volume { get; set; }

        /// <summary>
        /// The volume weighted average price.
        /// </summary>
        public decimal VolumeWeighetAvgPrice { get; set; }

        /// <summary>
        /// The open price for the symbol in the given time period.
        /// </summary>
        public decimal Open { get; set; }

        /// <summary>
        /// The close price for the symbol in the given time period.
        /// </summary>
        public decimal Close { get; set; }

        /// <summary>
        /// The highest price for the symbol in the given time period.
        /// </summary>
        public decimal High { get; set; }

        /// <summary>
        /// The lowest price for the symbol in the given time period.
        /// </summary>
        public decimal Low { get; set; }

        /// <summary>
        /// The Unix Msec timestamp for the start of the aggregate window.
        /// </summary>
        public long TimeStamp { get; set; }

        /// <summary>
        /// The number of transactions in the aggregate window.
        /// </summary>
        public int TransactionsCount { get; set; }
    }
}
