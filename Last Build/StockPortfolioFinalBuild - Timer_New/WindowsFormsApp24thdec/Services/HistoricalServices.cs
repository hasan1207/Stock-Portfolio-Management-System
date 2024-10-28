using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YahooFinanceRepository;
using LocalDatabaseRepository;
using System.Data;
using WindowsFormsApp24thdec.Models.MasterDataSetTableAdapters;
using Models;
using static WindowsFormsApp24thdec.Models.MasterDataSet;

namespace Services
{
    public sealed class HistoricalServices
    {
        private static HistoricalServices instance = null;
        private IStockApi api = null;
        private IDataAccess dataAccess;

        public Stock_RsiDataTable stock_RsiTable;
        public Stock_HistoryViewDataTable historyViewTable;
        private event EventHandler HistChanged;
        private StockHistoryServices stockHistoryServices;
        public static HistoricalServices Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HistoricalServices();
                }
                return instance;
            }
        }

        public HistoricalServices()
        {
            this.stock_RsiTable = new Stock_RsiDataTable();
            this.historyViewTable = new Stock_HistoryViewDataTable();
            this.dataAccess = DatabaseFactory.GetDataAccess();
            this.dataAccess.GetStockRsiTable(this.stock_RsiTable);

            stockHistoryServices = StockHistoryServices.Instance;
            stockHistoryServices.SubscribeHistoryProgressCompleted(HistoricDataUpdated);
        }


        private void HistoricDataUpdated(object sender, EventArgs e)
        {
            HistChanged?.Invoke(this, e);
        }

        public void SubscribeHistoricDataChanged(EventHandler eh)
        {
            HistChanged += eh;
        }
        public Stock_RsiDataTable ReturnStockRsiTable()
        {
            this.dataAccess.GetStockRsiTable(this.stock_RsiTable);
            return this.stock_RsiTable;
        }

        public Stock_HistoryViewDataTable ReturnStockHistoryViewTable(int stockId)
        {
            this.dataAccess.GetStockHistoryView(this.historyViewTable, stockId);
            return this.historyViewTable;
        }

    }
}
