using System.Text;

namespace StockMarket
{
    public class Stock
    {
        private decimal marketCapitalization;

        public Stock(string companyName, string director, decimal pricePerShare, int totalNumberOfShares)
        {
            CompanyName = companyName;
            Director = director;
            PricePerShare = pricePerShare;
            TotalNumberOfShares = totalNumberOfShares;
            MarketCapitalization = pricePerShare * totalNumberOfShares;
        }



        ////    • CompanyName: string
        //   • Director: string
        //   • PricePerShare: decimal
        //    • TotalNumberOfShares: int
        //   • MarketCapitalization: decimal
        //The constructor of the Stock class should receive the CompanyName, Director, PricePerShare, and the TotalNumberOfShares.
        //  MarketCapitalization is a calculated property between PricePerShare and a TotalNumberOfShares. 
        public string CompanyName { get; set; }
        public string Director { get; set; }
        public decimal PricePerShare { get; set; }
        public int TotalNumberOfShares { get; set; }
        public decimal MarketCapitalization { get; set; }


        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($" Company: {CompanyName}");   
            result.AppendLine($"Director: {Director}");   
            result.AppendLine($"Price per share: ${PricePerShare}");   
            result.AppendLine($"Market capitalization: ${MarketCapitalization}");   

            return result.ToString().Trim();
        }
        
    }
}
