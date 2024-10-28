using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp24thdec.RightPane.StockPane;
using Services;
using YahooFinanceRepository;
using System.Data;
using static WindowsFormsApp24thdec.Models.MasterDataSet;
using System.ComponentModel;

namespace WindowsFormsApp24thdec.Presenters
{
    public class StockStudyPresenter
    {
        private IStockPane stockPaneView;
        private StockStudyServices stockStudyServices;

        private StockDataCacheServices dataCacheServices;


        public StockStudyPresenter(IStockPane stockPaneView)
        {
            this.stockPaneView = stockPaneView;
            this.stockStudyServices = StockStudyServices.Instance;
            this.dataCacheServices = StockDataCacheServices.Instance;
            this.dataCacheServices.SubscribeProgressCompleted(ProgressEnded);

            this.dataCacheServices.SubscribeProgressStarted(ProgressStarted);
            stockStudyServices.SubscribeStockChanged(StockChanged);


        }

        public void ProgressEnded(object sender, EventArgs e)
        {
            stockPaneView.EnableImportButton();
        }

        public void ProgressStarted(object sender, EventArgs e)
        {
            stockPaneView.DisableImportButton();
        }

        public void StockChanged(object sender, EventArgs e)
        {
            FetchData();
        }


        public void ImportStockList()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult res = openFileDialog.ShowDialog();

            if(res == DialogResult.OK)
            {
                if (dataCacheServices.IsCacheUpdating)
                {
                    MessageBox.Show("Stock data is updating right now. Repeat import process after update completion.","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    string fileName = openFileDialog.FileName;
                    this.stockStudyServices.ImportStockList(fileName);
                }
                
            }

        }

        public void FetchData()
        {
            DataTable table = this.stockStudyServices.ReturnStockTable();
            this.stockPaneView.LoadGridView(table);

            this.stockPaneView.ClearSearch();
        }



        public void SelectionChanged(string symbol)
        {
            StockDetails sd = this.stockStudyServices.GetStockDetails(symbol);

            this.stockPaneView.BindPropertyGrid(sd);
        }

        public void ChangeActive(string symbol, bool state)
        {
            this.dataCacheServices.ChangeActiveState(symbol, state);
        }


        public void SetTimer(string num)
        {
            this.dataCacheServices.ChangeTimer(num);
        }

        public void FetchTime()
        {
            int num = this.dataCacheServices.FetchTimeInterval();
            this.stockPaneView.FetchTime(num.ToString());
        }
    }
}
