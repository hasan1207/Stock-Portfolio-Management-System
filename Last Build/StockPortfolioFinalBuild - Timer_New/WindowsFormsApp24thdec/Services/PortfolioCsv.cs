using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PortfolioCsv
    {
        private string instrument;
        private int quantity;
        private decimal avgCost;
        private decimal ltp;
        private decimal currVal;
        private decimal profitLoss;
        private decimal netChange;
        private decimal dayChange;

        public string Instrument
        {
            get { return instrument; }
            set { instrument = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public decimal AvgCost
        {
            get { return avgCost; }
            set
            {
                avgCost = value;
            }
        }

        public decimal Ltp
        {
            get { return ltp; }
            set
            {
                ltp = value;
            }
        }

        public decimal CurrVal
        {
            get { return currVal; }
            set
            {
                currVal = value;
            }
        }

        public decimal ProfitLoss
        {
            get { return profitLoss; }
            set
            {
                profitLoss = value;
            }
        }

        public decimal NetChange
        {
            get { return netChange; }
            set
            {
                netChange = value;
            }
        }

        public decimal DayChange
        {
            get { return dayChange; }
            set
            {
                dayChange = value;
            }
        }
    }
}
