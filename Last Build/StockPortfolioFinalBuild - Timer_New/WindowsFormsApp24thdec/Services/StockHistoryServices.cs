using LocalDatabaseRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using YahooFinanceRepository;
using static WindowsFormsApp24thdec.Models.MasterDataSet;

namespace Services
{
    public sealed class StockHistoryServices
    {
        private static StockHistoryServices instance = null;
        private IStockApi stockApi = null;
        private BackgroundWorker asyncWorker;
        private IDataAccess dataAccess;
        private System.Threading.Timer threadTimer = null;
        private int refreshPeriod = 1;
        private Stock_HistoryDataTable stockHistoryTable;

        private Stock_HistoryDataTable histDt;

        private StockDataCacheServices dataCacheServices;
        private Stock_History_Max_TimestampDataTable stock_History_Max_TimestampTable;

        private event ProgressChangedEventHandler HistoryProgressChanged;
        private event EventHandler HistoryProgressStarted;
        private event EventHandler HistoryProgressCompleted;

        private Logger logger;

        private bool isHistoryUpdating = false;


        

        public bool IsHistoryUpdating
        {
            get { return isHistoryUpdating; }
        }
        public static StockHistoryServices Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StockHistoryServices();
                }
                return instance;
            }
        }

        public StockHistoryServices()
        {
            this.dataAccess = DatabaseFactory.GetDataAccess();
            this.stockHistoryTable = new Stock_HistoryDataTable();

            this.histDt = new Stock_HistoryDataTable();






            dataCacheServices = StockDataCacheServices.Instance;

            this.stock_History_Max_TimestampTable = new Stock_History_Max_TimestampDataTable();
            this.dataAccess.GetStockHistoryMaxTimeStamp(this.stock_History_Max_TimestampTable);

            this.logger = Logger.Instance;
            if (DateTime.Now > DateTime.Now.Date + new TimeSpan(16, 0, 0) || DateTime.Now < DateTime.Now.Date + new TimeSpan(9, 0, 0))
            {
                threadTimer = new System.Threading.Timer(TimerProc, null, Timeout.Infinite, Timeout.Infinite);
                StartTimer();
            }

        }

        ~StockHistoryServices()
        {
            int index = 0;
            if(threadTimer != null)
                threadTimer.Dispose();
            while (isHistoryUpdating)
            {
                asyncWorker.WorkerSupportsCancellation = true;
                asyncWorker.CancelAsync();
                index++;
                Console.WriteLine(index.ToString());
            }
            
            if(asyncWorker != null)
                asyncWorker.Dispose();
        }

        private void TimerProc(object state)
        {
            this.RefreshStockHistoryAsync();
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

        public Stock_HistoryDataTable GetStockHistoryDataTable()
        {
            return stockHistoryTable;
        }

        public void RefreshStockHistoryAsync()
        {
            asyncWorker = new BackgroundWorker();
            asyncWorker.WorkerSupportsCancellation = true;
            asyncWorker.WorkerReportsProgress = true;
            
            asyncWorker.DoWork += asyncWorker_DoWork;
            asyncWorker.ProgressChanged += asyncWorker_ProgressChanged;
            asyncWorker.RunWorkerCompleted += asyncWorker_RunWorkerCompleted;
            asyncWorker.RunWorkerAsync(true);
        }

        

        private void asyncWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 0)
            {
                StopTimer();
                isHistoryUpdating = true;
                HistoryProgressStarted?.Invoke(this, e);

            }
            HistoryProgressChanged?.Invoke(this, e);
        }

        private void asyncWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker thread = sender as BackgroundWorker;

            int progress = 0;
            ProgressChangedEventArgs pa = new ProgressChangedEventArgs(progress, null);
            thread.ReportProgress(progress, "");
            

            
            decimal i = 0;

            System.DateTime checkDate = DateTime.MinValue.Date;

            stockApi = ApiFactory.GetApiAccess();
            StockData sd = null;


            StockDataTable table = dataCacheServices.GetStockDataTable();



            DataView dv = new DataView(table);
            dv.RowFilter = "active = 1";

            this.histDt.Clear();
            foreach (DataRowView row in dv)
            {
                try
                {
                    if (thread.CancellationPending)
                    {
                        isHistoryUpdating = false;
                        MessageBox.Show("About to be cancelled");
                        break;
                    }
                    i += 1;

                    int num = dv.Count;
                    progress = (int)((decimal)(i / num) * 100.0m);

                    this.stockHistoryTable.Clear();
                    string symbol = row["symbol"].ToString() + ".NS";

                    int stockId = (int)row["stock_id"];
                    System.DateTime maxDate = new DateTime(2000, 1, 1);
                    DataRow r1 = stock_History_Max_TimestampTable.AsEnumerable().SingleOrDefault(r => r.Field<int>("stock_id") == stockId);
                    thread.ReportProgress(progress, symbol);
                    if (r1 == null)
                    {

                        stockApi.SetStockData(symbol, "1d", "1y");

                    }
                    else
                    {


                        maxDate = ((System.DateTime)r1["max_timestamp"]).Date;

                        if (checkDate != DateTime.MinValue.Date)
                        {

                            if (checkDate == maxDate)
                                continue;
                        }

                        int days = (DateTime.Now.Date - maxDate).Days;
                        string api_days = days.ToString() + "d";
                        stockApi.SetStockData(symbol, "1d", api_days);

                    }


                    sd = stockApi.GetStockData();



                    if(sd.Data != null)
                    {
                        if (sd.Data.Rows.Count > 0)
                        {
                            if (checkDate == DateTime.MinValue.Date)
                            {
                                checkDate = ((System.DateTime)sd.Data.Rows[sd.Data.Rows.Count - 1]["timestamp"]).Date;

                            }

                            foreach (DataRow row2 in sd.Data.Rows)
                            {
                                System.DateTime apiDate = ((System.DateTime)row2["timestamp"]).Date;
                                if (apiDate > maxDate)
                                {
                                    DataRow histRow = stockHistoryTable.NewRow();
                                    histRow["stock_id"] = stockId;
                                    histRow["timestamp"] = apiDate;
                                    histRow["op"] = row2["Open"];
                                    histRow["hi"] = row2["High"];
                                    histRow["lo"] = row2["Low"];
                                    histRow["cl"] = row2["Close"];
                                    histRow["volume"] = row2["Volume"];

                                    this.stockHistoryTable.Rows.Add(histRow);
                                }


                            }

                            if (this.stockHistoryTable.Rows.Count > 0)
                            {
                                System.DateTime maxTimestamp = (System.DateTime)this.stockHistoryTable.Compute("MAX(timestamp)", "");
                                if (r1 == null)
                                {
                                    r1 = stock_History_Max_TimestampTable.NewRow();
                                    r1["stock_id"] = stockId;
                                    r1["max_timestamp"] = maxTimestamp;

                                    this.stock_History_Max_TimestampTable.Rows.Add(r1);
                                }
                                else
                                {
                                    r1["stock_id"] = stockId;
                                    r1["max_timestamp"] = maxTimestamp;
                                }
                            }
                        }
                    }
                    

                    this.dataAccess.UpdateStockHistoryMaxTimeStampTable(this.stock_History_Max_TimestampTable);



                    foreach(DataRow r in this.stockHistoryTable.Rows )
                    {
                        histDt.Rows.Add(r.ItemArray);
                    }

                }
                catch(System.Net.WebException ex)
                {
                    if(ex.Status == System.Net.WebExceptionStatus.ConnectFailure)
                    {
                        return;
                    }
                }
                catch(Exception ex)
                {
                    Logger.Instance.WriteToLogFile(LoggerFlags.Error, (string)ex.Message);

                }


            }

            Logger.Instance.WriteToLogFile(LoggerFlags.Information, "History import completed.");



            if(this.histDt != null)
            {
                if(this.histDt.Rows.Count > 0)
                {
                    this.dataAccess.UpdateStockHistoryTable(this.histDt);
                }
            }

        }

        

        private void asyncWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            StartTimer();
            isHistoryUpdating = false;
            HistoryProgressCompleted?.Invoke(this, null);
        }


        public void SubscribeHistoryProgressStarted(EventHandler started)
        {
            HistoryProgressStarted += started;
        }

        public void SubscribeHistoryProgressChanged(ProgressChangedEventHandler pe)
        {
            HistoryProgressChanged += pe;
        }

        public void SubscribeHistoryProgressCompleted(EventHandler started)
        {
            HistoryProgressCompleted += started;
        }

    }
}
