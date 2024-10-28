using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 The YahooStockData class and its composite classes exist within the YahooFinanciApi namespace.
 They are used by the YahooStockApi class to retrieve and store Stock Data from the Yahoo Stock API
 
 The attribute and the property names must NEVER be changed

*/

namespace YahooFinanceRepository
{
    public class YahooStockData
    {
        private Chart chart;
        public Chart Chart
        {
            get { return chart; }
            set { chart = value; }
        }
    }

    public class Chart
    {
        private List<Result> result;
        private object error;


        public List<Result> Result
        {
            get { return result; }
            set { result = value; }
        }

        public object Error
        {
            get { return error; }
            set { error = value; }
        }


    }

    public class Result
    {
        private Meta meta;
        private List<int> timestamp;
        private Indicators indicators;

        public Meta Meta
        {
            get { return meta; }
            set { meta = value; }
        }

        public List<int> Timestamp
        {
            get { return timestamp; }
            set
            {
                timestamp = value;
            }
        }

        public Indicators Indicators
        {
            get { return indicators; }
            set
            {
                indicators = value;
            }
        }
    }

    public class Meta
    {
        private string currency;
        private string symbol;
        private string exchangeName;
        private string instrumentType;
        private int firstTradeDate;
        private int regularMarketTime;
        private int gmtoffset;
        private string timezone;
        private string exchangeTimezoneName;
        private decimal regularMarketPrice;
        private decimal chartPreviousClose;
        private decimal? previousClose;
        private int scale;
        private int priceHint;
        private CurrentTradingPeriod currentTradingPeriod;
        private List<List<TPeriod>> tradingPeriods;
        private string dataGranularity;
        private string range;
        private List<string> validRanges;

        public string Currency
        {
            get { return currency; }
            set
            {
                currency = value;
            }
        }

        public string Symbol
        {
            get { return symbol; }
            set
            {
                symbol = value;
            }
        }

        public string ExchangeName
        {
            get { return exchangeName; }
            set
            {
                exchangeName = value;
            }
        }

        public string InstrumentType
        {
            get { return instrumentType; }
            set
            {
                instrumentType = value;
            }
        }

        public int FirstTradeDate
        {
            get { return firstTradeDate; }
            set
            {
                firstTradeDate = value;
            }
        }

        public int RegularMarketTime
        {
            get { return regularMarketTime; }
            set { regularMarketTime = value; }
        }

        public int Gmtoffset
        {
            get { return gmtoffset; }
            set { gmtoffset = value; }
        }

        public string Timezone
        {
            get { return timezone; }
            set
            {
                timezone = value;
            }
        }

        public string ExchangeTimezoneName
        {
            get { return exchangeTimezoneName; }
            set
            {
                exchangeTimezoneName = value;
            }
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

        public decimal? PreviousClose
        {
            get { return previousClose; }
            set { previousClose = value; }
        }

        public int Scale
        {
            get { return scale; }
            set { scale = value; }
        }

        public int PriceHint
        {
            get { return priceHint; }
            set { priceHint = value; }
        }

        public CurrentTradingPeriod CurrentTradingPeriod
        {
            get { return currentTradingPeriod; }
            set { currentTradingPeriod = value; }
        }

        public List<List<TPeriod>> TradingPeriods
        {
            get { return tradingPeriods; }
            set
            {
                tradingPeriods = value;
            }
        }

        public string DataGranularity
        {
            get { return dataGranularity; }
            set
            {
                dataGranularity = value;
            }
        }

        public string Range
        {
            get { return range; }
            set
            {
                range = value;
            }
        }

        public List<string> ValidRanges
        {
            get { return validRanges; }
            set
            {
                validRanges = value;
            }
        }

    }

    public class Indicators
    {
        private List<Quote> quote;

        public List<Quote> Quote
        {
            get { return quote; }
            set
            {
                quote = value;
            }
        }
    }

    public class CurrentTradingPeriod
    {
        private Pre pre;
        private Regular regular;
        private Post post;

        public Pre Pre
        {
            get { return pre; }
            set { pre = value; }
        }

        public Regular Regular
        {
            get { return regular; }
            set { regular = value; }
        }

        public Post Post
        {
            get { return post; }
            set { post = value; }
        }


    }

    public class TPeriod
    {
        private string timezone;
        private int end;
        private int start;
        private int gmtoffset;

        public string Timezone
        {
            get { return timezone; }
            set { timezone = value; }
        }

        public int End
        {
            get { return end; }
            set { end = value; }
        }

        public int Start
        {
            get { return start; }
            set { start = value; }
        }

        public int Gmtoffset
        {
            get { return gmtoffset; }
            set { gmtoffset = value; }
        }

    }

    public class Pre : TPeriod
    {

    }

    public class Regular : TPeriod
    {

    }

    public class Post : TPeriod
    {

    }

    public class Quote
    {
        private List<decimal?> low;
        private List<decimal?> open;
        private List<int?> volume;
        private List<decimal?> close;
        private List<decimal?> high;

        public List<decimal?> Low
        {
            get { return low; }
            set { low = value; }
        }

        public List<decimal?> Open
        {
            get { return open; }
            set { open = value; }
        }

        public List<int?> Volume
        {
            get { return volume; }
            set { volume = value; }
        }

        public List<decimal?> Close
        {
            get { return close; }
            set { close = value; }
        }

        public List<decimal?> High
        {
            get { return high; }
            set { high = value; }
        }
    }

}
