using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LocalDatabaseRepository;
using YahooFinanceRepository;
using static WindowsFormsApp24thdec.Models.MasterDataSet;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using WindowsFormsApp24thdec.Properties;


namespace Services
{
    public sealed class StockDataCacheServices
    {
        private BackgroundWorker asyncWorker;
        private System.Threading.Timer threadTimer = null;
        //private int refreshPeriod = 3;
        private int refreshPeriod = Settings.Default.TimerVal;

        private static StockDataCacheServices instance = null;
        private StockDataTable stockDataCache;
        private IDataAccess dataAccess;
        private IStockApi stockApi;

        private event EventHandler ProgressStarted;
        private event ProgressChangedEventHandler ProgressChanged;
        private event EventHandler ProgressCompleted;


        private bool isCacheUpdating = false;

        public bool IsCacheUpdating
        {
            get { return isCacheUpdating; }
        }

        public static StockDataCacheServices Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StockDataCacheServices();
                }
                return instance;
            }
        }

        private StockDataCacheServices()
        {
            this.dataAccess = DatabaseFactory.GetDataAccess();
            //this.stockApi = ApiFactory.GetApiAccess();
            this.stockDataCache = new StockDataTable();
            this.dataAccess.RefreshStockDataCache(this.stockDataCache);

            threadTimer = new System.Threading.Timer(TimerProc, null, Timeout.Infinite, Timeout.Infinite);


            StartTimer();
        }

        ~StockDataCacheServices()
        {
            Settings.Default.TimerVal = this.refreshPeriod;
            Settings.Default.Save();

            if (this.threadTimer != null)
                threadTimer.Dispose();
            int index = 0;
            while (isCacheUpdating)
            {
                //next line is new 25thfeb
                asyncWorker.WorkerSupportsCancellation = true;
                asyncWorker.CancelAsync();
                index++;
                Console.WriteLine(index.ToString());
            }
            
            if(asyncWorker != null)
                asyncWorker.Dispose();
        }


        public void ChangeTimer(string num)
        {
            float f = float.Parse(num);
            int val = (int)Math.Floor(f);
            if (val == this.refreshPeriod)
                return;
            this.refreshPeriod = val;
            StartTimer();
            if(val == 1)
                MessageBox.Show("Update Interval has been set to " + val + " minute");
            else
                MessageBox.Show("Update Interval has been set to " + val + " minutes");

        }
        private void TimerProc(object state)
        {
            //this.RefreshCurrentPriceAsync();
            this.RefreshAllAsync();
        }

        private void StartTimer()
        {
            int minutes = DateTime.Now.Minute;
            int seconds = DateTime.Now.Second;
            int adjust = (refreshPeriod * 60) - ((minutes * 60 + seconds) % (refreshPeriod * 60));
            this.threadTimer.Change(adjust * 1000, refreshPeriod * 60 * 1000);
        }

        private void StopTimer()
        {
            this.threadTimer.Change(Timeout.Infinite, Timeout.Infinite);
        }



        public StockDataTable GetStockDataTable()
        {
            return stockDataCache;
        }

        public void ImportStockList(List<StockCsv> csvList)
        {
            List<string> csv_sym = new List<string>();

            foreach (StockCsv csv in csvList)
            {
                csv_sym.Add(csv.Symbol);
                bool symbolExists;
                PropertyInfo[] prop = csv.GetType().GetProperties();
                DataRow dr = stockDataCache.AsEnumerable().SingleOrDefault(r => r.Field<string>("symbol") == csv.Symbol);
                symbolExists = (dr != null);
                if (!symbolExists)
                    dr = stockDataCache.NewRow();

                for (int j = 0; j < prop.Length; j++)
                {
                    dr[j + 1] = prop[j].GetValue(csv, null);
                }
                dr["active"] = false;
                if (!symbolExists)
                    stockDataCache.Rows.Add(dr);
            }



            for (int i = 0; i < stockDataCache.Rows.Count; i++)
            {
                if (!csv_sym.Contains(stockDataCache.Rows[i]["symbol"]))
                {
                    stockDataCache.Rows[i].Delete();
                }

            }

            RefreshAllAsync();



        }

        public async void RefreshCompleted()
        {
            this.dataAccess.UpdateStockDataCache(this.stockDataCache);

        }

        public void ChangeActiveState(string symbol, bool state)
        {
            DataRow row = stockDataCache.AsEnumerable().SingleOrDefault(r => r.Field<string>("symbol") == symbol);
            if (row != null)
            {
                row["active"] = state;
            }
            this.dataAccess.UpdateStockDataCache(this.stockDataCache);
        }

        public void RefreshCurrentPriceAsync()
        {
            asyncWorker = new BackgroundWorker();
            asyncWorker.WorkerSupportsCancellation = true;
            
            asyncWorker.WorkerReportsProgress= true;

            asyncWorker.DoWork += asyncWorker_DoWork;
            asyncWorker.ProgressChanged += asyncWorker_ProgressChanged;
            asyncWorker.RunWorkerCompleted += asyncWorker_RunWorkerCompleted;
            asyncWorker.RunWorkerAsync(true);
        }




        

        private void asyncWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker thread = sender as BackgroundWorker;
            bool current_price_only = (bool) e.Argument;

            int progress = 0;
            ProgressChangedEventArgs pa = new ProgressChangedEventArgs(progress, null);
            thread.ReportProgress(progress, "");


            stockApi = ApiFactory.GetApiAccess();
            SummaryData sd = null;
            ResponseData rd = null;
            decimal i = 0;
            DataView dv = new DataView(stockDataCache);
            dv.RowFilter = "active = 1 or portfolio_stock = 1";

            foreach (DataRowView r in dv)
            {
                try
                {

                    if (thread.CancellationPending)
                    {
                        isCacheUpdating = false;
                        MessageBox.Show("About to be cancelled");
                        break;
                    }
                    string symbol = r["symbol"].ToString() + ".NS";

                    i += 1;

                    progress = (int)((decimal)(i / dv.Count) * 100.0m);


                    stockApi.SetSummaryData(symbol);
                    sd = stockApi.GetSummaryData();
                    if (!current_price_only)
                    {

                        stockApi.SetResponseData(symbol);
                        rd = stockApi.GetResponseData();
                    }

                    r["current_price"] = sd.CurrentPrice;
                    r["last_update"] = DateTime.Now;
                    if (!current_price_only)
                    {
                        r["debt_to_equity"] = sd.DebtToEquity;
                        r["trailing_pe"] = rd.TrailingPE;
                        r["eps_trailing_12m"] = rd.EpsTrailingTwelveMonths;
                        r["eps_forward"] = rd.EpsForward;
                        r["eps_current_year"] = rd.EpsCurrentYear;
                        r["book_value"] = rd.BookValue;
                        r["fifty_day_average"] = rd.FiftyDayAverage;
                        r["two_hundred_day_average"] = rd.TwoHundredDayAverage;
                        r["market_cap"] = rd.MarketCap;
                        r["forward_pe"] = rd.ForwardPE;
                        r["price_to_book"] = rd.PriceToBook;



                        r["fifty_two_week_low"] = rd.FiftyTwoWeekLow;
                        r["fifty_two_week_high"] = rd.FiftyTwoWeekHigh;


                    }

                    Logger.Instance.WriteToLogFile(LoggerFlags.Information, (string)r["symbol"]);
                    thread.ReportProgress(progress, symbol);
                }
                catch (System.Net.WebException ex)
                {
                    if (ex.Status == System.Net.WebExceptionStatus.ConnectFailure)
                    {
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Logger.Instance.WriteToLogFile(LoggerFlags.Error, (string)ex.Message);
                }
            }


        }
        private void asyncWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {


            if (e.ProgressPercentage == 0)
            {
                StopTimer();
                isCacheUpdating = true;
                ProgressStarted?.Invoke(this, e);
            }
                

            ProgressChanged?.Invoke(this, e);
        }
        private void asyncWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.dataAccess.UpdateStockDataCache(this.stockDataCache);

            StartTimer();
            isCacheUpdating = false;
            ProgressCompleted?.Invoke(this, null);
        }

        


        public void RefreshAllAsync()
        {
            asyncWorker = new BackgroundWorker();
            asyncWorker.WorkerReportsProgress = true;

            asyncWorker.DoWork += asyncWorker_DoWork;
            asyncWorker.ProgressChanged += asyncWorker_ProgressChanged;
            asyncWorker.RunWorkerCompleted += asyncWorker_RunWorkerCompleted;
            asyncWorker.RunWorkerAsync(false);
        }

        public void SubscribeProgressStarted(EventHandler started)
        {
            ProgressStarted += started;
        }

        public void SubscribeProgressChanged(ProgressChangedEventHandler pe)
        {
            ProgressChanged += pe;
        }

        public void SubscribeProgressCompleted(EventHandler completed)
        {
            ProgressCompleted += completed;
        }

        public (decimal,bool) GetStockCurrentPrice(int stock_id)
        {


            DataRow row;
            try
            {
                row = stockDataCache.AsEnumerable().SingleOrDefault(r => r.Field<int>("stock_id") == stock_id);
            }
            catch(Exception ex)
            {
                return (0, false);
            }
            if(row != null)
            {

                return row["current_price"] == DBNull.Value ? (0.0m, true) : ((decimal)row["current_price"], true);
            }
            else
            {
                return (0,false);
            }
        }

        public int GetStockID(string symbol)
        {
            DataRow row = stockDataCache.AsEnumerable().SingleOrDefault(r => r.Field<string>("symbol") == symbol);

            return (row == null) ? (0) : ((int)row["stock_id"]);
        }

        public DataRow GetStockRow(int stockId)
        {
            DataRow row = stockDataCache.AsEnumerable().SingleOrDefault(r => r.Field<int>("stock_id") == stockId);
            return row;

        }


        public int FetchTimeInterval()
        {
            return this.refreshPeriod;
        }
    }
}
