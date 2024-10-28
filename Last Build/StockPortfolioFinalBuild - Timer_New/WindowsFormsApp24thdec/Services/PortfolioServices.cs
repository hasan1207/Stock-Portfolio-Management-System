using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using LocalDatabaseRepository;
using System.Reflection;
using System.Windows.Forms;
using static WindowsFormsApp24thdec.Models.MasterDataSet;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Principal;
using System.Runtime.CompilerServices;

namespace Services
{
    public sealed class PortfolioServices
    {

        private static PortfolioServices instance = null;
        private IDataAccess data;
        private PortfolioDataTable portfolioDataTable;
        private DataTable portfolioDataTotal;
        private StockDataCacheServices stockDataCacheServices;

        private bool portfolioListNeedsUpdated = false;
        public bool PortfolioListNeedsUpdated
        {
            get { return portfolioListNeedsUpdated; }
            set { portfolioListNeedsUpdated = value;}
        }

        private event EventHandler PortfolioChanged;



        public static PortfolioServices Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PortfolioServices();
                }
                return instance;
            }
        }



        private PortfolioServices()
        {
            this.data = DatabaseFactory.GetDataAccess();
            this.portfolioDataTable = new PortfolioDataTable();
            this.portfolioDataTotal = new DataTable();
            portfolioDataTotal.Columns.Add("invested_value", typeof(decimal));
            portfolioDataTotal.Columns.Add("current_value", typeof(decimal));
            portfolioDataTotal.Columns.Add("profit_loss", typeof(decimal));
            portfolioDataTotal.Columns.Add("percent_change", typeof(decimal));

            stockDataCacheServices = StockDataCacheServices.Instance;
            stockDataCacheServices.SubscribeProgressCompleted(StockDataCacheUpdated);

            
        }


        public (DataTable, DataTable) ReturnPortfolioTable()
        {
            this.data.GetPortfolioDataTable(portfolioDataTable, 1, 1);
            RefreshPortfolioDataTable();
            DataTable portTable;
            DataTable portTotal;
            DataView dv = new DataView(portfolioDataTable);

            dv.Sort = "percent_change desc";
            portTable = dv.ToTable(true, "symbol", "stock_quantity", "avg_buy_price", "current_price", "invested_value", "current_value", "profit_loss", "percent_change", "buy_sell_latest", "buy_sell_latest_20_50");

            DataView dv_total = new DataView(portfolioDataTotal);
            portTotal = dv_total.ToTable(true, "invested_value", "current_value", "profit_loss", "percent_change");

            return (portTable,portTotal);
            
        }


        private void StockDataCacheUpdated(object sender, EventArgs e)
        {
            PortfolioChanged?.Invoke(this, null);
        }


        public void SubscribePortfolioChanged(EventHandler eh)
        {
            PortfolioChanged += eh;
        }


        




        public void RefreshPortfolioDataTable()
        {

            List<DataColumn> columns = new List<DataColumn>(portfolioDataTable.Columns.Cast<DataColumn>());
            foreach (DataColumn column in columns)
            {
                column.ReadOnly = false;
            }

            (decimal, bool) curr_price;
            decimal inv_total = 0.0m;
            decimal curr_total = 0.0m;
            decimal profit_loss_total = 0.0m;
            decimal percent_change_total = 0.0m;

            List<DataRow> rowsToUpdate = new List<DataRow>();
            foreach (DataRow row in portfolioDataTable.Rows)
            {
                int stock_id = (int)row["stock_id"];
                int quantity = (int)row["stock_quantity"];
                System.Single invested_val = (System.Single)row["invested_value"];
                decimal curr_val = 0.0m;
                decimal profit_loss = 0.0m;

                curr_price = stockDataCacheServices.GetStockCurrentPrice(stock_id);

                if (curr_price.Item2)
                {
                    row["current_price"] = curr_price.Item1;
                    row["current_value"] = (decimal)(curr_price.Item1 * quantity);
                    curr_val = (decimal)row["current_value"];
                    profit_loss = (decimal)(curr_val - (decimal)invested_val);
                    row["profit_loss"] = profit_loss;
                    row["percent_change"] = (profit_loss / (decimal)invested_val) * 100.0m;

                    rowsToUpdate.Add(row); // add the updated row to the list

                }
                else
                {
                    continue;
                }
            }

            object sum = portfolioDataTable.Compute("SUM(invested_value)", string.Empty);
            object curr = portfolioDataTable.Compute("SUM(current_value)", string.Empty);
            object plt = portfolioDataTable.Compute("SUM(profit_loss)", string.Empty);


            inv_total = sum == DBNull.Value ? 0.0m : (decimal)((float)sum);
            curr_total = curr == DBNull.Value ? 0.0m : (decimal)curr;
            profit_loss_total = plt == DBNull.Value ? 0.0m : (decimal)plt;


            if (inv_total > 0)
                percent_change_total += (profit_loss_total / inv_total) * 100.0m;
            else
                percent_change_total += 0.0m;


            this.portfolioDataTotal.Rows.Clear();
            DataRow r = this.portfolioDataTotal.NewRow();
            
            r["invested_value"] = inv_total;
            r["current_value"] = curr_total;
            r["profit_loss"] = profit_loss_total;
            r["percent_change"] = percent_change_total;

            this.portfolioDataTotal.Rows.Add(r);

        }



        public void ImportPortfolioList(string fileName)
        {
            List<PortfolioCsv> list = new List<PortfolioCsv>();
            try
            {
                //string[] rawCsv = System.IO.File.ReadAllLines(fileName);
            }
            catch(Exception e)
            {
                MessageBox.Show("The CSV file is currently open. Please close it");
                return;
            }
            string[] rawCsv = System.IO.File.ReadAllLines(fileName);

            //Type type = typeof(PortfolioCsv);

            PortfolioCsv csv = new PortfolioCsv();
            PropertyInfo[] propInfo = typeof(PortfolioCsv).GetProperties();
            //Type[] types = new Type[propInfo.Length] { Type.GetType(csv.Instrument), Convert.ToString(Type.GetType(csv.Quantity)),  };
            string sym = "";

            try
            {
                for (int i = 1; i < rawCsv.Length; i++)
                {
                    PortfolioCsv portfolioCsv = new PortfolioCsv();
                    string[] split_arr = rawCsv[i].Split(',');

                    sym += "'" + split_arr[0] + "', ";
                    portfolioCsv.Instrument = split_arr[0];
                    portfolioCsv.Quantity = int.Parse(split_arr[1]);
                    portfolioCsv.AvgCost = Decimal.Parse(split_arr[2]);
                    portfolioCsv.Ltp = Decimal.Parse(split_arr[3]);
                    portfolioCsv.CurrVal = Decimal.Parse(split_arr[4]);
                    portfolioCsv.ProfitLoss = Decimal.Parse(split_arr[5]);
                    portfolioCsv.NetChange = Decimal.Parse(split_arr[6]);
                    portfolioCsv.DayChange = Decimal.Parse(split_arr[7]);
                    list.Add(portfolioCsv);
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
            catch(Exception ex)
            {
                MessageBox.Show("Wrong file format. Try again.");
                return;
            }
            

            int stockId;
            int user_id = 1;
            int broker_id = 1;

            //for deletion purposes, create a list of strings to hold all symbols/instruments contained in the CSV
            List<string> csv_sym = new List<string>();
            foreach (PortfolioCsv port in list)
            {
                string instrument = port.Instrument;
                csv_sym.Add(instrument);
                decimal avgPrice = port.AvgCost;
                DataRow row = portfolioDataTable.AsEnumerable().SingleOrDefault(r => r.Field<string>("symbol") == instrument);
                stockId = stockDataCacheServices.GetStockID(instrument);
                if (stockId == 0)
                    continue;
                
                
                if (row != null)
                {
                    row["symbol"] = instrument;
                    row["stock_id"] = stockId;
                    row["broker_id"] = broker_id;
                    row["user_id"] = user_id;
                    //int existing_quantity = (int)row["stock_quantity"];
                    row["stock_quantity"] = port.Quantity;
                    row["avg_buy_price"] = avgPrice;
                }
                else
                {
                    DataRow r = portfolioDataTable.NewRow();
                    r["symbol"] = instrument;
                    r["stock_id"] = stockId;
                    r["broker_id"] = broker_id;
                    r["user_id"] = user_id;
                    r["stock_quantity"] = port.Quantity;
                    r["avg_buy_price"] = avgPrice;
                    portfolioDataTable.Rows.Add(r);
                }
            }


            for (int i = 0; i < portfolioDataTable.Rows.Count; i++)
            {
                if (!csv_sym.Contains(portfolioDataTable.Rows[i]["symbol"]))
                {
                    portfolioDataTable.Rows[i].Delete();
                }

            }

            for(int i = 0; i < portfolioDataTable.Rows.Count; i++)
            {
                if (portfolioDataTable.Rows[i].RowState == DataRowState.Deleted)
                {
                    continue;
                }
                stockDataCacheServices.ChangeActiveState((string)portfolioDataTable.Rows[i]["symbol"], true);
            }
            this.data.UpdatePortfolioDataTable(this.portfolioDataTable);
            
        }


        




    }
}
