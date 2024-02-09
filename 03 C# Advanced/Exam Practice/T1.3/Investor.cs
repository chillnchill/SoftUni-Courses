using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            Portfolio = new List<Stock>();
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
        }

        public List<Stock> Portfolio { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }

        public int Count { get { return Portfolio.Count; } }
       
        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && MoneyToInvest >= stock.PricePerShare)
            {
                MoneyToInvest -= stock.PricePerShare;
                Portfolio.Add(stock);
            }
            return;
        }

        public string SellStock(string companyName, decimal sellPrice)
        {

            Stock company = Portfolio.FirstOrDefault(n => n.CompanyName == companyName);

            if (company == null)
            {
                return $"{companyName} does not exist.";
            }
            else
            {
                decimal price = company.PricePerShare;
                if (price < sellPrice)
                {
                    MoneyToInvest += price;
                    Portfolio.Remove(company);
                    return $"{companyName} was sold.";

                }
                else
                {
                    return $"Cannot sell {companyName}.";
                }

            }
        }

        public Stock FindStock(string companyName)
        {
            Stock company = Portfolio.FirstOrDefault(n => n.CompanyName == companyName);
            return company;
        }

        public Stock FindBiggestCompany()
        {

            Stock company = Portfolio.OrderByDescending(m => m.MarketCapitalization)
                .FirstOrDefault();
            return company;
            
        }

        public string InvestorInformation()
        {
            StringBuilder info = new StringBuilder();

            info.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");

            List<Stock> stocks = Portfolio.ToList();

            foreach (var stock in stocks)
            {
                info.Append(stock);
            }
            return info.ToString().Trim();
            
        }
    }
}
