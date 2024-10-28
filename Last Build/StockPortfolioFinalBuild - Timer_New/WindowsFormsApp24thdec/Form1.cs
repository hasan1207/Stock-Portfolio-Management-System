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
using LocalDatabaseRepository;
using Services;
using System.Threading;
using System.Timers;
using System.Globalization;
using static WindowsFormsApp24thdec.Models.MasterDataSet;


//new code
using Services;
namespace WindowsFormsApp24thdec
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            navPane1.PaneChanged += rightPane1.PaneChangedMethod;
            navPane1.PaneChanged += navPane1.PaneChangedMethod;
            //navPane1.PaneChanged += PaneChangedMethod;
            //this.AutoScaleDimensions = new System.Drawing.Size(12, 12);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            //navPane1.HideProgressBar();

            CultureInfo languageculture = new CultureInfo("en-IN");
            Thread.CurrentThread.CurrentCulture = languageculture;
            this.Text = "Stock Portfolio Management System";

            //this.ControlBox = false;

            
            
        }

        private void rightPane1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //later
            //StockDataCacheServices.Instance.RefreshAllAsync();
            //StockHistoryServices.Instance.RefreshStockHistoryAsync();
            //Stock_RsiDataTable table = HistoricalServices.Instance.ReturnStockRsiTable();
        }


        /*
        public void PaneChangedMethod(object sender, EventArgs e)
        {
            //lbl_btnVal.Text = (e as PaneEventArgs).Name;
            string paneName = (e as PaneEventArgs).Name;
            MessageBox.Show(paneName);

        }
        */


        /*
        private void btn_disp_Click(object sender, EventArgs e)
        {
            YahooStockApi ys = new YahooStockApi("infy.ns", "5m", "50m");
            StockData sd = ys.GetStockData();
            lbl_val.Text = sd.Currency;
            dataGridView1.DataSource = sd.Data;
        }
        */



        ////test 6/1/23
        //private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    if (StockDataCacheServices.Instance.IsCacheUpdating)
        //    {
        //        MessageBox.Show("Stock Data Cache is currently updating. Please wait until update finishes.","Alert!",MessageBoxButtons.OK,MessageBoxIcon.Stop);
        //    }
        //    else
        //    {
        //        //Application.Exit();
        //    }
        //}


    }


}
