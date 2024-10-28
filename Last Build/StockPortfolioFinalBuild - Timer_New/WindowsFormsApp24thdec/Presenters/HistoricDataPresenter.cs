using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp24thdec.RightPane.HistoricPane;
using static WindowsFormsApp24thdec.Models.MasterDataSet;

namespace WindowsFormsApp24thdec.Presenters
{
    public class HistoricDataPresenter
    {
        private IHistoricPane historicPane;
        private StockHistoryServices historyServices;
        private HistoricalServices historicalServices;
        private int currSelectedStockId;

        public HistoricDataPresenter(IHistoricPane historicPane)
        {
            this.historicPane = historicPane;
            this.historyServices = StockHistoryServices.Instance;
            historyServices.SubscribeHistoryProgressStarted(HistoryProgressStarted);
            historyServices.SubscribeHistoryProgressChanged(HistoryProgressChanged);
            historyServices.SubscribeHistoryProgressCompleted(HistoryProgressCompleted);
            this.historicalServices = HistoricalServices.Instance;
        }

        public void HistChangedHandler(object sender, EventArgs e)
        {
            this.SelectionChanged(this.currSelectedStockId);
        }
        public void HistoryProgressChanged(object sender, ProgressChangedEventArgs pe)
        {
            historicPane.SetUpdateProgress(pe.ProgressPercentage, pe.UserState.ToString());
        }

        public void HistoryProgressStarted(object sender, EventArgs pe)
        {
            historicPane.ShowProgressBar();
        }

        public void HistoryProgressCompleted(object sender, EventArgs pe)
        {
            historicPane.HideProgressBar();
        }

        public void FetchData()
        {
            Stock_RsiDataTable table = historicalServices.ReturnStockRsiTable();
            this.historicPane.LoadStockGridView(table);
            this.historicPane.ClearSearch();
        }

        public void SelectionChanged(int stockId)
        {
            this.currSelectedStockId = stockId;
            Stock_HistoryViewDataTable table = historicalServices.ReturnStockHistoryViewTable(stockId);
            this.historicPane.LoadOhlcGrid(table);
        }
    }
}
