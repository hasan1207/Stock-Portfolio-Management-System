using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



/*
 The YahooSummaryData class and its composite classes exist within the YahooFinanciApi namespace.
 They are used by the YahooStockApi class to retrieve and store Summary Data from the Yahoo Stock API
 
 The attribute and the property names must NEVER be changed

*/


namespace YahooFinanceRepository
{

    public class YahooSummaryData
    {
        private QuoteSummary quoteSummary;
        public QuoteSummary QuoteSummary
        {
            get { return quoteSummary; }
            set { quoteSummary = value; }
        }
    }

    public class QuoteSummary
    {
        private List<SummaryResult> result;
        public List<SummaryResult> Result
        {
            get { return result; }
            set { result = value; }
        }

        private object error;
        public object Error
        {
            get { return error; }
            set { error = value; }
        }
    }

    public class SummaryResult
    {
        private FinancialData financialData;
        public FinancialData FinancialData
        {
            get { return financialData; }
            set { financialData = value; }
        }
    }

    public class FinancialData
    {
        private long maxAge;
        public long MaxAge
        {
            get { return maxAge; }
            set { maxAge = value; }
        }

        private CurrentPrice currentPrice;
        public CurrentPrice CurrentPrice
        {
            get { return currentPrice; }
            set { currentPrice = value; }
        }

        private TargetHighPrice targetHighPrice;
        public TargetHighPrice TargetHighPrice
        {
            get { return targetHighPrice; }
            set { targetHighPrice = value; }
        }

        private TargetLowPrice targetLowPrice;
        private TargetMeanPrice targetMeanPrice;

        public TargetLowPrice TargetLowPrice
        {
            get { return targetLowPrice; }
            set { targetLowPrice = value; }
        }

        public TargetMeanPrice TargetMeanPrice
        {
            get { return targetMeanPrice; }
            set { targetMeanPrice = value; }
        }

        private TargetMedianPrice targetMedianPrice;
        private RecommendationMean recommendationMean;
        private string recommendationKey;

        public TargetMedianPrice TargetMedianPrice
        {
            get { return targetMedianPrice; }
            set { targetMedianPrice = value; }
        }

        public RecommendationMean RecommendationMean
        {
            get { return recommendationMean; }
            set { recommendationMean = value; }
        }

        public string RecommendationKey
        {
            get { return recommendationKey; }
            set { recommendationKey = value; }
        }

        private NumberOfAnalystOpinions numberOfAnalystOpinions;

        public NumberOfAnalystOpinions NumberOfAnalystOpinions
        {
            get { return numberOfAnalystOpinions; }
            set { numberOfAnalystOpinions = value; }
        }

        private TotalCash totalCash;
        private TotalCashPerShare totalCashPerShare;
        private Ebitda ebitda;

        public TotalCash TotalCash
        {
            get { return totalCash; }
            set { totalCash = value; }
        }

        public TotalCashPerShare TotalCashPerShare
        {
            get { return totalCashPerShare; }
            set { totalCashPerShare = value; }
        }

        public Ebitda Ebitda
        {
            get { return ebitda; }
            set { ebitda = value; }
        }

        private TotalDebt totalDebt;
        private QuickRatio quickRatio;
        private CurrentRatio currentRatio;
        private TotalRevenue totalRevenue;

        public TotalDebt TotalDebt
        {
            get { return totalDebt; }
            set { totalDebt = value; }
        }

        public QuickRatio QuickRatio
        {
            get { return quickRatio; }
            set { quickRatio = value; }
        }

        public CurrentRatio CurrentRatio
        {
            get { return currentRatio; }
            set { currentRatio = value; }
        }

        public TotalRevenue TotalRevenue
        {
            get { return totalRevenue; }
            set { totalRevenue = value; }
        }

        private DebtToEquity debtToEquity;
        private RevenuePerShare revenuePerShare;
        private ReturnOnAssets returnOnAssets;
        private ReturnOnEquity returnOnEquity;

        public DebtToEquity DebtToEquity
        {
            get { return debtToEquity; }
            set { debtToEquity = value; }

        }

        public RevenuePerShare RevenuePerShare
        {
            get { return revenuePerShare; }
            set { revenuePerShare = value; }

        }

        public ReturnOnAssets ReturnOnAssets
        {
            get { return returnOnAssets; }
            set { returnOnAssets = value; }
        }

        public ReturnOnEquity ReturnOnEquity
        {
            get { return returnOnEquity; }
            set { returnOnEquity = value; }
        }

        private GrossProfits grossProfits;
        private FreeCashFlow freeCashFlow;
        private OperatingCashFlow operatingCashFlow;
        private EarningsGrowth earningsGrowth;
        private RevenueGrowth revenueGrowth;

        public GrossProfits GrossProfits
        {
            get { return grossProfits; }
            set { grossProfits = value; }
        }

        public FreeCashFlow FreeCashFlow
        {
            get { return freeCashFlow; }
            set { freeCashFlow = value; }
        }

        public OperatingCashFlow OperatingCashFlow
        {
            get { return operatingCashFlow; }
            set { operatingCashFlow = value; }

        }

        public EarningsGrowth EarningsGrowth
        {
            get { return earningsGrowth; }
            set { earningsGrowth = value; }

        }

        public RevenueGrowth RevenueGrowth
        {
            get { return revenueGrowth; }
            set { revenueGrowth = value; }

        }

        private GrossMargins grossMargins;
        private EbitdaMargins ebitdaMargins;
        private OperatingMargins operatingMargins;
        private ProfitMargins profitMargins;

        public GrossMargins GrossMargins
        {
            get { return grossMargins; }
            set { grossMargins = value; }

        }

        public EbitdaMargins EbitdaMargins
        {
            get { return ebitdaMargins; }
            set { ebitdaMargins = value; }

        }

        public OperatingMargins OperatingMargins
        {
            get { return operatingMargins; }
            set { operatingMargins = value; }

        }

        public ProfitMargins ProfitMargins
        {
            get { return profitMargins; }
            set { profitMargins = value; }

        }
        private string financialCurrency;
        public string FinancialCurrency
        {
            get { return financialCurrency; }
            set { financialCurrency = value; }
        }

    }

    public class Raw_Fmt
    {
        private decimal raw;
        private string fmt;
        public decimal Raw
        {
            get { return raw; }
            set { raw = value; }
        }
        public string Fmt
        {
            get { return fmt; }
            set { fmt = value; }
        }
    }

    public class Raw_Fmt_LongFmt : Raw_Fmt
    {
        private string longFmt;
        public string LongFmt
        {
            get { return longFmt; }
            set
            {
                longFmt = value;
            }
        }
    }

    public class CurrentPrice : Raw_Fmt
    {
    }

    public class TargetHighPrice : Raw_Fmt
    {
    }

    public class TargetLowPrice : Raw_Fmt
    {
    }

    public class TargetMeanPrice : Raw_Fmt
    {
    }

    public class TargetMedianPrice : Raw_Fmt
    {
    }

    public class RecommendationMean : Raw_Fmt
    {
    }

    public class NumberOfAnalystOpinions : Raw_Fmt_LongFmt
    {
    }

    public class TotalCash : Raw_Fmt_LongFmt
    {
    }

    public class TotalCashPerShare : Raw_Fmt
    {
    }

    public class Ebitda : Raw_Fmt_LongFmt
    {
    }

    public class TotalDebt : Raw_Fmt_LongFmt
    {
    }

    public class QuickRatio : Raw_Fmt
    {
    }

    public class CurrentRatio : Raw_Fmt
    {
    }

    public class TotalRevenue : Raw_Fmt_LongFmt
    {
    }

    public class DebtToEquity : Raw_Fmt
    {
    }
    public class RevenuePerShare : Raw_Fmt
    {
    }

    public class ReturnOnAssets : Raw_Fmt
    {
    }

    public class ReturnOnEquity : Raw_Fmt
    {
    }

    public class GrossProfits : Raw_Fmt_LongFmt
    {
    }

    public class FreeCashFlow : Raw_Fmt_LongFmt
    {
    }

    public class OperatingCashFlow : Raw_Fmt_LongFmt
    {
    }

    public class EarningsGrowth : Raw_Fmt
    {
    }

    public class RevenueGrowth : Raw_Fmt
    {
    }

    public class GrossMargins : Raw_Fmt
    {

    }

    public class EbitdaMargins : Raw_Fmt
    {

    }

    public class OperatingMargins : Raw_Fmt
    {

    }

    public class ProfitMargins : Raw_Fmt
    {

    }

}