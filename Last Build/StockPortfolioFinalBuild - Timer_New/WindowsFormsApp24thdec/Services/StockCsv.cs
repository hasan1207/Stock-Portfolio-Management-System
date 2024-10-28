using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class StockCsv
    {
        private string companyName;
        private string industry;
        private string symbol;
        private string series;
        private string isinCode;

        public string CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }

        public string Industry
        {
            get { return industry; }
            set { industry = value; }
        }

        public string Symbol
        {
            get { return symbol; }
            set { symbol = value; }
        }

        public string Series
        {
            get { return series; }
            set { series = value; }
        }

        public string IsinCode
        {
            get { return isinCode; }
            set { isinCode = value; }
        }

    }
}
