using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PortfolioModel
    {
        private string stockName;
        private int stockQuantity;
        private decimal avgBuyPrice;
        private decimal investedValue;

        public string StockName
        {
            get { return stockName; }
            set { stockName = value; }
        }

        public int StockQuantity
        {
            get { return stockQuantity; }
            set { stockQuantity = value; }
        }

        public decimal AvgBuyPrice
        {
            get { return avgBuyPrice; }
            set { avgBuyPrice = value; }
        }

        public decimal InvestedValue
        {
            get { return investedValue; }
            set { investedValue = value; }
        }
    }
}
