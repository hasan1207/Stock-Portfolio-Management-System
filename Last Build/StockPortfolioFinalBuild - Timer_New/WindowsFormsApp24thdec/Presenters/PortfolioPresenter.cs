using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp24thdec.RightPane.PortfolioPane;
using Services;
using System.Data;
using static WindowsFormsApp24thdec.Models.MasterDataSet;
using System.Windows.Forms;

namespace WindowsFormsApp24thdec.Presenters
{
    public class PortfolioPresenter
    {
        private IPortfolioPane portfolioPaneView;
        private PortfolioServices portfolioServices;

        private StockDataCacheServices stockDataCacheServices;

        public PortfolioPresenter(IPortfolioPane portfolioPaneView)
        {
            this.portfolioPaneView = portfolioPaneView;
            this.portfolioServices = PortfolioServices.Instance;

            portfolioServices.SubscribePortfolioChanged(PortChanged);


            this.stockDataCacheServices = StockDataCacheServices.Instance;
            this.stockDataCacheServices.SubscribeProgressStarted(ProgressStarted);
            this.stockDataCacheServices.SubscribeProgressCompleted(ProgressCompleted);

        }

        public void ProgressStarted(object sender, EventArgs e)
        {
            portfolioPaneView.DisableImportButton();
        }

        public void ProgressCompleted(object sender, EventArgs e)
        {
            portfolioPaneView.EnableImportButton();
        }

        public void PortChanged(object sender, EventArgs e)
        {
            FetchData();
        }

        public void FetchData()
        {
            (DataTable, DataTable) tables = portfolioServices.ReturnPortfolioTable();

            this.portfolioPaneView.LoadGridView(tables.Item1,tables.Item2);
            this.portfolioPaneView.ClearSearch();

        }



        public void ImportPortfolioList()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult res = openFileDialog.ShowDialog();

            if (res == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                this.portfolioServices.ImportPortfolioList(fileName);

            }

            FetchData();

        }
    }
}
