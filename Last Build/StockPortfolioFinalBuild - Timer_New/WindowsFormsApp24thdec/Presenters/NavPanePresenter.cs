using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp24thdec.NavigationPane;

namespace WindowsFormsApp24thdec.Presenters
{
    public class NavPanePresenter
    {
        INavPane navPaneView;
        private StockDataCacheServices stockDataCacheServices;

        public NavPanePresenter(INavPane navPane)
        {
            this.navPaneView = navPane;
            this.stockDataCacheServices = StockDataCacheServices.Instance;
            this.stockDataCacheServices.SubscribeProgressStarted(ProgressStarted);
            this.stockDataCacheServices.SubscribeProgressChanged(ProgressChanged);
            this.stockDataCacheServices.SubscribeProgressCompleted(ProgressCompleted);
        }

        public void ProgressStarted(object sender, EventArgs e)
        {
            navPaneView.ShowProgressBar();
        }

        public void ProgressChanged(object sender, ProgressChangedEventArgs pa)
        {
            navPaneView.SetUpdateProgress(pa.ProgressPercentage, pa.UserState.ToString());
        }

        public void ProgressCompleted(object sender, EventArgs e)
        {
            navPaneView.HideProgressBar();
        }
    }
}
