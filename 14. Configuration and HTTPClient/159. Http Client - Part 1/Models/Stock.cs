namespace _159._Http_Client___Part_1_2_3.Models
{
    public class Stock
    {
        public string? StockSymbol { get; set; }
        public double CurrentPrice { get; set; }

        public double LowestPrice { get; set; }

        public double HighestPrice { get; set; }

        // I.e. the starting Price
        public double OpenPrice { get; set; }
    }
}
