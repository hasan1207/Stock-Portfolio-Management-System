using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using System.Data;
using static WindowsFormsApp24thdec.Models.MasterDataSet;
using WindowsFormsApp24thdec.Models;
using WindowsFormsApp24thdec.Models.MasterDataSetTableAdapters;

namespace LocalDatabaseRepository
{
    public class SqlDataAccess : IDataAccess
    {
        public string _connectionString;
        public SqlDataAccess()
        {
            
        }


        public void UpdateStockDataCache(StockDataTable table)
        {
            try
            {
                StockTableAdapter stockTableAdapter = new StockTableAdapter();
                stockTableAdapter.Update(table);
                table.AcceptChanges();
            }
            catch(Exception ex)
            {
                MessageBox.Show("There was an error in updating the Stock table");
            }
        }


        public void RefreshStockDataCache(StockDataTable table)
        {
            StockTableAdapter stockTableAdapter = new StockTableAdapter();
            
            stockTableAdapter.Fill(table);

        }

        public void UpdatePortfolioDataTable(PortfolioDataTable table)
        {
            PortfolioTableAdapter portfolioTableAdapter = new PortfolioTableAdapter();
            portfolioTableAdapter.Update(table);
            table.AcceptChanges();
        }

        public void GetPortfolioDataTable(PortfolioDataTable table, int user_id, int broker_id)
        {
            PortfolioTableAdapter portfolioTableAdapter = new PortfolioTableAdapter();
            portfolioTableAdapter.Fill(table, user_id, broker_id);
        }


        public void GetStockHistory(Stock_HistoryDataTable table, int stock_id)
        {
            Stock_HistoryTableAdapter stockHistoryTableAdapter = new Stock_HistoryTableAdapter();
            stockHistoryTableAdapter.Fill(table, stock_id);
        }

        public void GetStockHistoryMaxTimeStamp(Stock_History_Max_TimestampDataTable table)
        {
            Stock_History_Max_TimestampTableAdapter stock_History_Max_TimestampTableAdapter = new Stock_History_Max_TimestampTableAdapter();
            stock_History_Max_TimestampTableAdapter.Fill(table);

        }

        
        public void UpdateStockHistoryTable(Stock_HistoryDataTable table)
        {
            try
            {
                Stock_HistoryTableAdapter stockHistoryTableAdapter = new Stock_HistoryTableAdapter();
                this._connectionString = stockHistoryTableAdapter.Connection.ConnectionString;
                stockHistoryTableAdapter.Update(table);
                table.AcceptChanges();


                using (var conn = new SqlConnection(_connectionString))
                {
                    using (var cmd = new SqlCommand("RunProc", conn) { CommandType = CommandType.StoredProcedure })
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        public void UpdateStockHistoryMaxTimeStampTable(Stock_History_Max_TimestampDataTable table)
        {
            Stock_History_Max_TimestampTableAdapter stock_History_Max_TimestampTableAdapter = new Stock_History_Max_TimestampTableAdapter();
            stock_History_Max_TimestampTableAdapter.Update(table);
            table.AcceptChanges();
        }


        public void GetStockRsiTable(Stock_RsiDataTable table)
        {
            Stock_RsiTableAdapter stock_RsiTableAdapter = new Stock_RsiTableAdapter();
            stock_RsiTableAdapter.Fill(table);
        }

        public void GetStockHistoryView(Stock_HistoryViewDataTable table, int stockId)
        {
            Stock_HistoryViewTableAdapter stock_HistoryViewTableAdapter = new Stock_HistoryViewTableAdapter();
            stock_HistoryViewTableAdapter.Fill(table, stockId);
        }

    }
}
