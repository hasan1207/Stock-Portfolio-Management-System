using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using YahooFinanceRepository;
using System.Collections;
using LocalDatabaseRepository;
using System.Data;
using static WindowsFormsApp24thdec.Models.MasterDataSet;
using System.ComponentModel;

namespace Services
{
    public sealed class StockStudyServices
    {
        private static StockStudyServices instance = null;

        private event EventHandler StockChanged;

        public static StockStudyServices Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StockStudyServices();
                }
                return instance;
            }
        }

        private StockStudyServices()
        {
            StockDataCacheServices.Instance.SubscribeProgressCompleted(StockDataCacheUpdated);
        }

        public void ImportStockList(string fileName)
        {

            List<StockCsv> list = new List<StockCsv>();


            string[] rawCsv = System.IO.File.ReadAllLines(fileName);

            PropertyInfo[] propInfo = typeof(StockCsv).GetProperties();

            try
            {
                for (int i = 1; i < rawCsv.Length; i++)
                {
                    StockCsv stockCsv = new StockCsv();

                    string[] split_arr = rawCsv[i].Split('\t');
   
                    if (split_arr[0][0] == '"' && split_arr[0][split_arr[0].Length - 1] == '"')
                    {
                        split_arr[0] = split_arr[0].Substring(1);

                        split_arr[0] = split_arr[0].Remove(split_arr[0].IndexOf('"'));

                    }
                    if (split_arr[0][split_arr[0].Length - 1] == ',')
                        split_arr[0] = split_arr[0].Remove(split_arr[0].LastIndexOf(','));

                    if (split_arr[1][0] == '"' && split_arr[1][split_arr[1].Length - 1] == '"')
                    {
                        split_arr[1] = split_arr[1].Substring(1);
                        split_arr[1] = split_arr[1].Remove(split_arr[1].IndexOf('"'));
                    }

                    for (int j = 0; j < split_arr.Length; j++)
                    {
                        propInfo[j].SetValue(stockCsv, split_arr[j]);
                    }
                    list.Add(stockCsv);
                }

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Improper csv file format. Try again.");
                return;
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Improper csv file format. Try again.");
                return;
            }
            catch(IndexOutOfRangeException ex)
            {
                MessageBox.Show("Improper csv file format. Try again.");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wrong file format. Try again.");
                return;
            }


            StockDataCacheServices.Instance.ImportStockList(list);
        }

        public DataTable ReturnStockTable()
        {
            
            DataTable stockTable = new DataTable();


            try
            {
                StockDataTable stockCache = GetStockDataTable();

                DataView dv = new DataView(stockCache);

                dv.Sort = "active desc, portfolio_stock desc, industry asc, symbol asc";
                stockTable = dv.ToTable(true, "active", "portfolio_stock", "industry", "symbol", "current_price", "buy_sell_latest", "buy_sell_latest_20_50", "crossover", "fifty_two_low_high", "debt_to_equity", "eps_trailing_12m", "price_to_book", "trailing_pe", "fifty_day_average", "two_hundred_day_average", "fifty_two_week_low", "fifty_two_week_high", "last_update");


                List<DataColumn> columns = new List<DataColumn>(stockTable.Columns.Cast<DataColumn>());
                foreach (DataColumn column in columns)
                {
                    column.ReadOnly = false;
                }
            }
            catch (Exception ex)
            {

            }
            return stockTable;

        }



        

        public StockDataTable GetStockDataTable()
        {
            return StockDataCacheServices.Instance.GetStockDataTable();
        }


        private void StockDataCacheUpdated(object sender, EventArgs e)
        {
            StockChanged?.Invoke(this, null);
        }

        public void SubscribeStockChanged(EventHandler eh)
        {
            StockChanged += eh;
        }




        public void SubscribeProgressChanged(ProgressChangedEventHandler pe)
        {
            StockDataCacheServices.Instance.SubscribeProgressChanged(pe);
        }

        public StockDetails GetStockDetails(string symbol)
        {
            StockDetails sd = new StockDetails();
            int stockId = StockDataCacheServices.Instance.GetStockID(symbol);

            DataRow dr = StockDataCacheServices.Instance.GetStockRow(stockId);
            if (dr != null)
            {
                sd.Series = dr["series"] == DBNull.Value ? "" : dr["series"].ToString();
                sd.IsinCode = dr["isin_code"] == DBNull.Value ? "" : dr["isin_code"].ToString();

                sd.Industry = dr["industry"] == DBNull.Value ? "" : dr["industry"].ToString();
                sd.StockName = dr["stock_name"] == DBNull.Value ? "" : dr["stock_name"].ToString();
                sd.CurrentPrice = dr["current_price"] == DBNull.Value ? 0.0m : (decimal)dr["current_price"];

                sd.DebtToEquity = dr["debt_to_equity"] == DBNull.Value ? 0.0f : (float)dr["debt_to_equity"];
                sd.TrailingPe = dr["trailing_pe"] == DBNull.Value ? 0.0f : (float)dr["trailing_pe"];
                sd.EpsTrailing12Months = dr["eps_trailing_12m"] == DBNull.Value ? 0.0f : (float)dr["eps_trailing_12m"];
                sd.EpsForward = dr["eps_forward"] == DBNull.Value ? 0.0f : (float)dr["eps_forward"];
                sd.EpsCurrentYear = dr["eps_current_year"] == DBNull.Value ? 0.0f : (float)dr["eps_current_year"];
                sd.BookValue = dr["book_value"] == DBNull.Value ? 0.0f : (float)dr["book_value"];
                sd.FiftyDayAverage = dr["fifty_day_average"] == DBNull.Value ? 0.0f : (float)dr["fifty_day_average"];
                sd.TwoHundredDayAverage = dr["two_hundred_day_average"] == DBNull.Value ? 0.0f : (float)dr["two_hundred_day_average"];
                sd.MarketCap = dr["market_cap"] == DBNull.Value ? 0.0m : (decimal)dr["market_cap"];
                sd.ForwardPe = dr["forward_pe"] == DBNull.Value ? 0.0f : (float)dr["forward_pe"];
                sd.PriceToBook = dr["price_to_book"] == DBNull.Value ? 0.0f : (float)dr["price_to_book"];

                sd.FiftyTwoWeekLow = dr["fifty_two_week_low"] == DBNull.Value ? 0.0f : (float)dr["fifty_two_week_low"];
                sd.FiftyTwoWeekHigh = dr["fifty_two_week_high"] == DBNull.Value ? 0.0f : (float)dr["fifty_two_week_high"];
            }
            return sd;
        }
    }
}
