using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

/*
 * The YahooStockApi class exists within the YahooFinanceApi namespace. 
 * This class is responsible for implementing the IStockApi interface 
   and actually sets and retrieves Stock and Summary Data from the Yahoo Stock API
 * 
 * */

namespace YahooFinanceRepository
{
    public class YahooStockApi : IStockApi
    {
        private string url = null;
        private YahooStockData yahooStockData = null;
        private YahooSummaryData yahooSummaryData = null;
        private YahooResponseData yahooResponseData = null;


        public void SetStockData(string stockId, string interval, string range)
        {

            url = "https://query1.finance.yahoo.com/v8/finance/chart/" + stockId + "?interval=" + interval + "&range=" + range;

            using (var wc = new WebClient())
            {
                string rawData = wc.DownloadString(url);
                //Console.WriteLine(rawData);


                //this.yahooStockData = JsonConvert.DeserializeObject<YahooStockData>(rawData);
                JsonSerializerOptions lower = new JsonSerializerOptions();
                lower.PropertyNameCaseInsensitive = true;
                this.yahooStockData = JsonSerializer.Deserialize<YahooStockData>(rawData,lower);
            }


        }

        //public void SetSummaryData(string stockId)
        //{
        //    url = "https://query1.finance.yahoo.com/v10/finance/quoteSummary/" + stockId + "?modules=financialData";
        //    //url = "https://query1.finance.yahoo.com/v6/finance/quoteSummary/" + stockId + "?modules=financialData";
        //    //url = "https://query1.finance.yahoo.com/v10/finance/quoteSummary/" + stockId + "?modules=financialData";
        //    //https://query1.finance.yahoo.com/v10/finance/quoteSummary/SHRIRAMFIN.NS?modules=financialData
        //    using (var wc = new WebClient())
        //    {
        //        string rawData = wc.DownloadString(url);
        //        //this.yahooSummaryData = JsonConvert.DeserializeObject<YahooSummaryData>(rawData);
        //        JsonSerializerOptions lower = new JsonSerializerOptions();
        //        lower.PropertyNameCaseInsensitive = true;
        //        this.yahooSummaryData = JsonSerializer.Deserialize<YahooSummaryData>(rawData, lower);
        //    }
        //}

        public void SetSummaryData(string stockId)
        {
            url = "https://query1.finance.yahoo.com/v10/finance/quoteSummary/" + stockId + "?modules=financialData";
            //url = "https://query1.finance.yahoo.com/v6/finance/quoteSummary/" + stockId + "?modules=financialData";
            //url = "https://query1.finance.yahoo.com/v10/finance/quoteSummary/" + stockId + "?modules=financialData";
            //https://query1.finance.yahoo.com/v10/finance/quoteSummary/SHRIRAMFIN.NS?modules=financialData
            using (var wc = new WebClient())
            {
                //wc.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");
                string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes("hasan07122002@gmail.com:Hasan2002"));
                wc.Headers[HttpRequestHeader.Authorization] = string.Format("Basic {0}", credentials);
                string rawData = wc.DownloadString(url);
                //this.yahooSummaryData = JsonConvert.DeserializeObject<YahooSummaryData>(rawData);
                JsonSerializerOptions lower = new JsonSerializerOptions();
                lower.PropertyNameCaseInsensitive = true;
                this.yahooSummaryData = JsonSerializer.Deserialize<YahooSummaryData>(rawData, lower);
            }
        }



        //public void SetResponseData(string stockId)
        //{
        //    url = "https://query1.finance.yahoo.com/v7/finance/quote?symbols=" + stockId;
        //    using (var wc = new WebClient())
        //    {
        //        string rawData = wc.DownloadString(url);
        //        JsonSerializerOptions lower = new JsonSerializerOptions();
        //        lower.PropertyNameCaseInsensitive = true;
        //        this.yahooResponseData = JsonSerializer.Deserialize<YahooResponseData>(rawData, lower);
        //    }
        //}



        //public void SetResponseData(string stockId)
        //{
        //    url = "https://query1.finance.yahoo.com/v7/finance/quote?symbols=" + stockId;
        //    //using (var wc = new WebClient())
        //    //{
        //    //    string rawData = wc.DownloadString(url);
        //    //    JsonSerializerOptions lower = new JsonSerializerOptions();
        //    //    lower.PropertyNameCaseInsensitive = true;
        //    //    this.yahooResponseData = JsonSerializer.Deserialize<YahooResponseData>(rawData, lower);
        //    //}


        //    string crumb = null;
        //    using (var wc = new WebClient())
        //    {
        //        wc.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");

        //        string html = wc.DownloadString(url);
        //        Match match = Regex.Match(html, "root\\.App\\.main = (.*);", RegexOptions.Multiline);

        //        if (match.Success)
        //        {
        //            string json = match.Groups[1].Value;
        //            dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
        //            crumb = data.context.dispatcher.stores.CrumbStore.crumb;
        //        }
        //    }

        //    if (crumb != null)
        //    {
        //        string apiurl = $"https://query1.finance.yahoo.com/v7/finance/quote?symbols=GOOG,AAPL&crumb={crumb}";
        //        using (var wc = new WebClient())
        //        {
        //            wc.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");
        //            string rawData = wc.DownloadString(apiurl);
        //            // process the response data as needed
        //        }
        //    }
        //    else
        //    {
        //        // handle case where crumb could not be obtained
        //    }
        //}


        public void SetResponseData(string stockId)
        {
            string crumb = "";
            string cookie = "";
            using (var wc = new WebClient())
            {
                wc.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");
                wc.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
                //string htmlData = wc.DownloadString("https://finance.yahoo.com/quote/GOOG/");
                string htmlData = wc.DownloadString("https://query1.finance.yahoo.com/v7/finance/quote?symbols=" + stockId);
                int crumbIndex = htmlData.IndexOf("CrumbStore") + 22;
                int crumbLength = htmlData.IndexOf("\"", crumbIndex) - crumbIndex;
                crumb = htmlData.Substring(crumbIndex, crumbLength);
                cookie = wc.ResponseHeaders["Set-Cookie"];
            }

            url = "https://query1.finance.yahoo.com/v7/finance/quote?symbols=" + stockId;
            using (var wc = new WebClient())
            {
                wc.Headers.Add(HttpRequestHeader.Cookie, cookie);
                wc.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");
                wc.Headers.Add("Accept", "application/json");
                wc.Headers.Add("X-Requested-With", "XMLHttpRequest");
                wc.Headers.Add("X-Crumb", crumb);
                string rawData = wc.DownloadString(url);
                JsonSerializerOptions lower = new JsonSerializerOptions();
                lower.PropertyNameCaseInsensitive = true;
                this.yahooResponseData = JsonSerializer.Deserialize<YahooResponseData>(rawData, lower);
            }
        }

        //public void SetResponseData(string stockId)
        //{
        //    url = "https://query1.finance.yahoo.com/v6/finance/quote?symbols=" + stockId;
        //    using (var wc = new WebClient())
        //    {
        //        //wc.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");
        //        string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes("hasan07122002@gmail.com:Hasan2002"));
        //        wc.Headers[HttpRequestHeader.Authorization] = string.Format("Basic {0}", credentials);
        //        string rawData = wc.DownloadString(url);
        //        JsonSerializerOptions options = new JsonSerializerOptions();
        //        options.PropertyNameCaseInsensitive = true;
        //        this.yahooResponseData = JsonSerializer.Deserialize<YahooResponseData>(rawData, options);
        //    }
        //}

        public StockData GetStockData()
        {
            StockData sd = new StockData();
            if (this.YahooStockData == null || this.YahooStockData.Chart.Result == null)
            {
                return sd;
            }

            sd.Symbol = this.YahooStockData.Chart.Result.First().Meta.Symbol;
            sd.Currency = this.YahooStockData.Chart.Result.First().Meta.Currency;
            sd.ExchangeName = this.YahooStockData.Chart.Result.First().Meta.ExchangeName;
            sd.RegularMarketPrice = this.YahooStockData.Chart.Result.First().Meta.RegularMarketPrice;
            sd.ChartPreviousClose = this.YahooStockData.Chart.Result.First().Meta.ChartPreviousClose;
            sd.Interval = this.YahooStockData.Chart.Result.First().Meta.DataGranularity;
            sd.DateRange = this.YahooStockData.Chart.Result.First().Meta.Range;
            //sd.Data = DataUtility.ListToTable(DataUtility.Create_2dlist(this));


            //string[] colNames = { "timestamp", "open", "high", "low", "close", "volume" };
            string[] colNames = { "Timestamp", "Open", "High", "Low", "Close", "Volume" };

            DateTime date;
            int t;
            List<System.DateTime> dates = new List<System.DateTime>();
            for (int i = 0; i < this.YahooStockData.Chart.Result[0].Timestamp.Count; i++)
            {
                date = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                t = this.YahooStockData.Chart.Result[0].Timestamp[i];
                dates.Add(date.AddSeconds(t));
            }

            //object[] lists = {this.YahooStockData.Chart.Result[0].Timestamp,
            //    this.YahooStockData.Chart.Result[0].Indicators.Quote[0].Open,
            //    this.YahooStockData.Chart.Result[0].Indicators.Quote[0].High,
            //    this.YahooStockData.Chart.Result[0].Indicators.Quote[0].Low,
            //    this.YahooStockData.Chart.Result[0].Indicators.Quote[0].Close,
            //    this.YahooStockData.Chart.Result[0].Indicators.Quote[0].Volume};

            object[] lists = {dates,
                this.YahooStockData.Chart.Result[0].Indicators.Quote[0].Open,
                this.YahooStockData.Chart.Result[0].Indicators.Quote[0].High,
                this.YahooStockData.Chart.Result[0].Indicators.Quote[0].Low,
                this.YahooStockData.Chart.Result[0].Indicators.Quote[0].Close,
                this.YahooStockData.Chart.Result[0].Indicators.Quote[0].Volume};

            sd.Data = DataUtility.CreateDataTable(colNames, lists);

            //sd.Data = DataUtility.CreateDataTable(this.YahooStockData.Chart.Result[0].Timestamp,
            //    this.YahooStockData.Chart.Result[0].Indicators.Quote[0].Open,
            //    this.YahooStockData.Chart.Result[0].Indicators.Quote[0].High,
            //    this.YahooStockData.Chart.Result[0].Indicators.Quote[0].Low,
            //    this.YahooStockData.Chart.Result[0].Indicators.Quote[0].Close,
            //    this.YahooStockData.Chart.Result[0].Indicators.Quote[0].Volume);

            return sd;

        }

        public SummaryData GetSummaryData()
        {
            SummaryData sd = new SummaryData();
            if (this.YahooSummaryData == null || this.YahooSummaryData.QuoteSummary.Result == null)
                return sd;

            sd.CurrentPrice = this.YahooSummaryData.QuoteSummary.Result.First().FinancialData.CurrentPrice.Raw;
            sd.RecommendationAndMean = this.YahooSummaryData.QuoteSummary.Result.First().FinancialData.RecommendationMean.Raw;
            sd.NumberOfAnalysts = (long)this.YahooSummaryData.QuoteSummary.Result.First().FinancialData.NumberOfAnalystOpinions.Raw;
            //sd.DebtToEquity = (this.YahooSummaryData.QuoteSummary.Result.First().FinancialData.DebtToEquity.Raw) / 100;
            sd.DebtToEquity = (this.YahooSummaryData.QuoteSummary.Result.First().FinancialData.DebtToEquity.Raw);
            sd.ReturnOnEquity = this.YahooSummaryData.QuoteSummary.Result.First().FinancialData.ReturnOnEquity.Raw;
            sd.FreeCashFlow = (long)this.YahooSummaryData.QuoteSummary.Result.First().FinancialData.FreeCashFlow.Raw;
            sd.ProfitMargins = this.YahooSummaryData.QuoteSummary.Result.First().FinancialData.ProfitMargins.Raw;

            return sd;
        }

        public ResponseData GetResponseData()
        {
            ResponseData resp = new ResponseData();
            //if (this.YahooResponseData == null)
            //    return resp;
            if (this.YahooResponseData.quoteResponse.result == null || this.YahooResponseData == null)
                return resp;
            resp.TrailingPE = (decimal) this.YahooResponseData.quoteResponse.result[0].trailingPE;
            resp.EpsTrailingTwelveMonths = (decimal)this.YahooResponseData.quoteResponse.result[0].epsTrailingTwelveMonths;
            resp.EpsForward = (decimal)this.YahooResponseData.quoteResponse.result[0].epsForward;
            resp.EpsCurrentYear = (decimal)this.YahooResponseData.quoteResponse.result[0].epsCurrentYear;
            resp.BookValue = (decimal)this.YahooResponseData.quoteResponse.result[0].bookValue;
            resp.FiftyDayAverage = (decimal)this.YahooResponseData.quoteResponse.result[0].fiftyDayAverage;
            resp.TwoHundredDayAverage = (decimal)this.YahooResponseData.quoteResponse.result[0].twoHundredDayAverage;
            resp.MarketCap = (decimal)this.YahooResponseData.quoteResponse.result[0].marketCap;
            resp.ForwardPE = (decimal)this.YahooResponseData.quoteResponse.result[0].forwardPE;
            resp.PriceToBook = (decimal)this.YahooResponseData.quoteResponse.result[0].priceToBook;

            resp.FiftyTwoWeekLow = (decimal)this.YahooResponseData.quoteResponse.result[0].fiftyTwoWeekLow;
            resp.FiftyTwoWeekHigh = (decimal)this.YahooResponseData.quoteResponse.result[0].fiftyTwoWeekHigh;

            return resp;

            //this.YahooResponseData.quoteResponse.result[0].

        }

        public YahooStockApi()
        {

        }
        public YahooStockApi(string stockId, string interval, string range)
        {
            this.SetStockData(stockId, interval, range);
        }
        public YahooStockApi(string stockId)
        {
            this.SetSummaryData(stockId);
        }

        public YahooStockData YahooStockData
        {
            get { return this.yahooStockData; }
            set { this.yahooStockData = value; }
        }

        public YahooSummaryData YahooSummaryData
        {
            get { return this.yahooSummaryData; }
            set { this.yahooSummaryData = value; }
        }

        public YahooResponseData YahooResponseData
        {
            get { return this.yahooResponseData; }
            set { this.yahooResponseData = value; }
        }



    }
}
