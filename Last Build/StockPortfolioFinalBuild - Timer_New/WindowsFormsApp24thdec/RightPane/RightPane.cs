using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp24thdec.NavigationPane;
using YahooFinanceRepository;

namespace WindowsFormsApp24thdec.RightPane
{
    public partial class RightPane : UserControl
    {
        public delegate void PortfolioSelectedEventHandler(object sender, EventArgs e);
        public event PortfolioSelectedEventHandler PortfolioSelected;
        public RightPane()
        {
            InitializeComponent();
            historicPane1.Hide();
            portfolioPane1.Show();
            stockPane1.Hide();
            portfolioPane1.RefreshData();

        }

        public void PaneChangedMethod(object sender, EventArgs e)
        {
            this.SuspendLayout();
            string paneName = (e as PaneEventArgs).Name;
            if (paneName == "Portfolio")
            {
                historicPane1.Hide();
                portfolioPane1.Show();
                stockPane1.Hide();
                portfolioPane1.RefreshData();
            }
            else if (paneName == "Stock Study")
            {
                historicPane1.Hide();
                portfolioPane1.Hide();
                stockPane1.Show();
                stockPane1.RefreshData();
            }
            else
            {
                historicPane1.Show();
                portfolioPane1.Hide();
                stockPane1.Hide();

                historicPane1.RefreshData();
            }

            //if (paneName == "Portfolio")
            //{
            //    historicPane1.Hide();
            //    portfolioPane1.Show();
            //    stockPane1.Hide();
            //    portfolioPane1.RefreshData();
            //}
            //else if (paneName == "Stock Study")
            //{
            //    historicPane1.Hide();
            //    stockPane1.Show();
            //    portfolioPane1.Hide();
            //    stockPane1.RefreshData();
            //}
            //else
            //{
            //    portfolioPane1.Hide();
            //    historicPane1.Show();
            //    stockPane1.Hide();

            //    historicPane1.RefreshData();
            //}


            //if (paneName == "Portfolio")
            //{
            //    portfolioPane1.Show();
            //    //portfolioPane1.BringToFront();

            //    historicPane1.Hide();
            //    stockPane1.Hide();

            //    portfolioPane1.RefreshData();
            //}
            //else if (paneName == "Stock Study")
            //{
            //    stockPane1.Show();
            //    //stockPane1.BringToFront();

            //    historicPane1.Hide();
            //    portfolioPane1.Hide();

            //    stockPane1.RefreshData();
            //}
            //else
            //{
            //    historicPane1.Show();
            //    //historicPane1.BringToFront();

            //    portfolioPane1.Hide();
            //    stockPane1.Hide();

            //    historicPane1.RefreshData();
            //}
            this.ResumeLayout();
        }

    }
}
