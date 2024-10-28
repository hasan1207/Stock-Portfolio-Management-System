using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Models;
using static WindowsFormsApp24thdec.Models.MasterDataSet;

namespace LocalDatabaseRepository
{
    public interface IDataAccess
    {
        void UpdateStockDataCache(StockDataTable table);

        void RefreshStockDataCache(StockDataTable table);

        void UpdatePortfolioDataTable(PortfolioDataTable table);

        void GetPortfolioDataTable(PortfolioDataTable table, int user_id, int broker_id);

        void GetStockHistory(Stock_HistoryDataTable table, int stock_id);

        void GetStockHistoryMaxTimeStamp(Stock_History_Max_TimestampDataTable table);

        void UpdateStockHistoryTable(Stock_HistoryDataTable table);

        void UpdateStockHistoryMaxTimeStampTable(Stock_History_Max_TimestampDataTable table);

        void GetStockRsiTable(Stock_RsiDataTable table);

        void GetStockHistoryView(Stock_HistoryViewDataTable table, int stockId);
    }
}
