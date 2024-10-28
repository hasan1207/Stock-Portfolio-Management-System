using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooFinanceRepository
{

    public class StockData
    {
        private string currency;
        private string symbol;
        private string exchangeName;
        private decimal regularMarketPrice;
        private decimal chartPreviousClose;
        private string interval;
        private string dateRange;
        private DataTable data;


        public string Currency
        {
            get { return currency; }
            set { currency = value; }
        }

        public string Symbol
        {
            get { return symbol; }
            set { symbol = value; }
        }

        public string ExchangeName
        {
            get { return exchangeName; }
            set { exchangeName = value; }
        }

        public decimal RegularMarketPrice
        {
            get { return regularMarketPrice; }
            set { regularMarketPrice = value; }
        }

        public decimal ChartPreviousClose
        {
            get { return chartPreviousClose; }
            set { chartPreviousClose = value; }
        }

        public string Interval
        {
            get { return interval; }
            set { interval = value; }
        }

        public string DateRange
        {
            get { return dateRange; }
            set { dateRange = value; }
        }

        public DataTable Data
        {
            get { return data; }
            set { data = value; }
        }


    }
    public class SummaryData
    {
        private decimal currentPrice;
        private decimal recommendationAndMean;
        private long numberOfAnalysts;
        private decimal debtToEquity;
        private decimal returnOnEquity;
        private long freeCashFlow;
        private decimal profitMargins;

        public decimal CurrentPrice
        {
            get { return currentPrice; }
            set { currentPrice = value; }
        }

        public decimal RecommendationAndMean
        {
            get { return recommendationAndMean; }
            set { recommendationAndMean = value; }
        }

        public long NumberOfAnalysts
        {
            get { return numberOfAnalysts; }
            set { numberOfAnalysts = value; }
        }

        public decimal DebtToEquity
        {
            get { return debtToEquity; }
            set { debtToEquity = value; }
        }

        public decimal ReturnOnEquity
        {
            get { return returnOnEquity; }
            set { returnOnEquity = value; }
        }

        public long FreeCashFlow
        {
            get { return freeCashFlow; }
            set { freeCashFlow = value; }
        }

        public decimal ProfitMargins
        {
            get { return profitMargins; }
            set { profitMargins = value; }
        }


    }

    public class ResponseData
    {
        private decimal trailingPE;
        private decimal epsTrailingTwelveMonths;
        private decimal epsForward;
        private decimal epsCurrentYear;
        private decimal bookValue;
        private decimal fiftyDayAverage;
        private decimal twoHundredDayAverage;
        private decimal marketCap;
        private decimal forwardPE;
        private decimal priceToBook;


        private decimal fiftyTwoWeekLow;
        private decimal fiftyTwoWeekHigh;
        public decimal TrailingPE
        {
            get { return trailingPE; }
            set { trailingPE = value; }
        }

        public decimal EpsTrailingTwelveMonths
        {
            get { return epsTrailingTwelveMonths; }
            set { epsTrailingTwelveMonths = value; }
        }

        public decimal EpsForward
        {
            get { return epsForward; }
            set { epsForward = value; }
        }

        public decimal EpsCurrentYear
        {
            get { return epsCurrentYear; }
            set
            {
                epsCurrentYear = value;
            }
        }

        public decimal BookValue
        {
            get { return bookValue; }
            set
            {
                bookValue = value;
            }
        }

        public decimal FiftyDayAverage
        {
            get { return fiftyDayAverage; }
            set
            {
                fiftyDayAverage = value;
            }
        }

        public decimal TwoHundredDayAverage
        {
            get { return twoHundredDayAverage; }
            set
            {
                twoHundredDayAverage = value;
            }
        }

        public decimal MarketCap
        {
            get { return marketCap; }
            set
            {
                marketCap = value;
            }
        }

        public decimal ForwardPE
        {
            get { return forwardPE; }
            set { forwardPE = value; }
        }

        public decimal PriceToBook
        {
            get { return priceToBook; }
            set
            {
                priceToBook = value;
            }
        }

        public decimal FiftyTwoWeekLow
        {
            get { return fiftyTwoWeekLow; }
            set { fiftyTwoWeekLow = value; }
        }

        public decimal FiftyTwoWeekHigh
        {
            get { return fiftyTwoWeekHigh; }
            set { fiftyTwoWeekHigh = value; }
        }

    }
}
