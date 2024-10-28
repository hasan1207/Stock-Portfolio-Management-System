using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YahooFinanceRepository;
using LocalDatabaseRepository;
using Models;
using System.Collections;
using Services;
using WindowsFormsApp24thdec.Presenters;
using System.Diagnostics;

namespace WindowsFormsApp24thdec.RightPane.PortfolioPane
{
    public partial class PortfolioPane : UserControl, IPortfolioPane
    {
        private PortfolioPresenter presenter;
        //private Logger logger;

        private string currSelectedStock;

        public PortfolioPane()
        {
            InitializeComponent();
            presenter = new PortfolioPresenter(this);
            this.dataGridView1.ColNames = new List<string> { "Symbol", "Qty.", "Avg Buy Price", "Current Price", "Invested Value", "Current Value", "Profit & Loss", "% Change", "Buy/Sell", "Buy/Sell 20/50 EMA" };
            this.dataGridView1.ColFormats = new List<string> { "", "#,###", "c", "c", "c0", "c0", "c0", "#,##0.00", "", "", "" };
            this.dataGridView1.ColAlignments = new List<DataGridViewContentAlignment> { DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter };

            this.dataGridView1.ColWidths = new List<double> { 0.14, 0.10, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.08, 0.08 };
        }




        public void DisableImportButton()
        {
            btn_import.Invoke((MethodInvoker)(() => btn_import.Enabled = false));
        }

        public void EnableImportButton()
        {
            btn_import.Invoke((MethodInvoker)(() => btn_import.Enabled = true));
        }

        private void PortfolioPane_Load(object sender, EventArgs e)
        {
            RefreshData();
            Logger.Instance.WriteToLogFile(LoggerFlags.Information, "Portfolio Pane Loaded");
        }


        public void LoadGridView(DataTable table, DataTable total)
        {
            if (dataGridView1.InvokeRequired)
            {
                dataGridView1.BeginInvoke((Action)delegate { LoadGridViewHelper(table, total); });
            }
            else
            {
                LoadGridViewHelper(table, total);
            }
        }

        private void LoadGridViewHelper(DataTable table, DataTable total)
        {
            this.dataGridView1.DataSource = table;
            this.dataGridViewTotal.DataSource = total;


            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].DefaultCellStyle.Format = dataGridView1.ColFormats[i];
                dataGridView1.Columns[i].DefaultCellStyle.Alignment = dataGridView1.ColAlignments[i];
                dataGridView1.Columns[i].HeaderCell.Value = dataGridView1.ColNames[i];
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

                dataGridView1.Columns[i].HeaderCell.Style.Alignment = dataGridView1.ColAlignments[i];
            }

            
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            
            dataGridViewCellStyle1.BackColor = UIColor.DarkColor;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 12.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = this.dataGridViewTotal.DefaultCellStyle.BackColor;
            dataGridViewCellStyle1.SelectionForeColor = this.dataGridViewTotal.DefaultCellStyle.ForeColor;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dataGridViewTotal.DefaultCellStyle = dataGridViewCellStyle1;


            dataGridViewTotal.RowTemplate.Height = 40;
            for (int i = 0; i < dataGridViewTotal.ColumnCount; i++)
            {
                dataGridViewTotal.Columns[i].DefaultCellStyle.Format = dataGridView1.Columns[i + 4].DefaultCellStyle.Format;
                dataGridViewTotal.Columns[i].DefaultCellStyle.Alignment = dataGridView1.Columns[i + 4].DefaultCellStyle.Alignment;

            }
            Logger.Instance.WriteToLogFile(LoggerFlags.Information, "Portfolio Pane DataGridView Loaded");
        }




        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.ClearSelection();
            
        }

        public void RefreshData()
        {
            presenter.FetchData();
        }
        

        private void PortfolioPane_Resize(object sender, EventArgs e)
        {
            this.SuspendLayout();

            dataGridViewTotal.Size = new Size(this.ClientSize.Width - 40, 41);
            dataGridView1.Size = new Size(this.ClientSize.Width - 30, this.ClientSize.Height - 80 - dataGridViewTotal.Height - 10);
            
            btn_import.Location = new System.Drawing.Point(this.ClientSize.Width - 20 - btn_import.Width, 14);
            btn_tview.Location = new Point(btn_import.Location.X - btn_tview.Width - 20, 14);
            btn_screener.Location = new Point(btn_tview.Location.X - btn_screener.Width - 20, 14);


            btn_tview.Size = new Size(44, 44);
            btn_screener.Size = new Size(44, 44);

            pnl_border.Size = new Size(dataGridView1.Width, 5);
            pnl_border.Location = new Point(dataGridView1.Location.X, dataGridView1.Location.Y + dataGridView1.Height);
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridViewTotal.Location = new System.Drawing.Point(dataGridView1.Location.X + dataGridView1.Columns[0].Width + dataGridView1.Columns[1].Width + dataGridView1.Columns[2].Width + dataGridView1.Columns[3].Width, dataGridView1.Location.Y + dataGridView1.Height + pnl_border.Height);
            }



            txt_search.Location = new Point(btn_screener.Location.X - 200, lbl_portfolioHeader.Location.Y + 10);
            txt_search.Size = new Size(165, 26);

            txt_search.Text = "Search Industry or Symbol";
            txt_search.Font = new Font("Segoe UI Variable Display", 10, FontStyle.Regular);
            
            txt_search.ForeColor = Color.Gray;

            ToolTip myToolTip = new ToolTip();
            myToolTip.SetToolTip(btn_screener, "Open stock in Screener.com");
            myToolTip.SetToolTip(btn_tview, "Open stock in TradingView.com");
            myToolTip.SetToolTip(btn_import, "Perform an Import Operation");
            this.ResumeLayout();
        }

        private void btn_import_Click(object sender, EventArgs e)
        {
            presenter.ImportPortfolioList();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (this.dataGridView1.Columns[e.ColumnIndex].Name == "profit_loss" || this.dataGridView1.Columns[e.ColumnIndex].Name == "percent_change")
            {
                if ((decimal)e.Value > 0.0m)
                {
                    e.CellStyle.ForeColor = Color.Green;
                }
                else
                {
                    e.CellStyle.ForeColor = Color.Red;
                }


            }

            if (this.dataGridView1.Columns[e.ColumnIndex].Name == "buy_sell_latest" || this.dataGridView1.Columns[e.ColumnIndex].Name == "buy_sell_latest_20_50")
            {
                if (e.Value == DBNull.Value)
                    return;
                if ((string)e.Value == "SELL")
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                }
                else if((string)e.Value == "BUY")
                {
                    e.CellStyle.ForeColor = Color.Green;
                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                }
                else
                {
                    e.CellStyle.ForeColor = UIColor.EvenDarkerColor;
                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Regular);
                }


            }


        }

        private void dataGridView1_Resize(object sender, EventArgs e)
        {
            
            int client_width = this.ClientSize.Width;
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].Width = (int)((double)client_width * dataGridView1.ColWidths[i]) - 5; 
            }
            for (int i = 0; i < dataGridViewTotal.ColumnCount; i++)
            {
                dataGridViewTotal.Columns[i].Width = dataGridView1.Columns[i + 4].Width;
            }
        }

        private void dataGridViewTotal_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridViewTotal.Columns[e.ColumnIndex].Name == "profit_loss" || this.dataGridViewTotal.Columns[e.ColumnIndex].Name == "percent_change")
            {
                if ((decimal)e.Value > 0.0m)
                {
                    e.CellStyle.ForeColor = Color.Green;
                }
                else
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                dataGridView1.CurrentRow.Selected = true;

                this.currSelectedStock = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].Value.ToString();
            }
        }

        private void btn_tview_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.tradingview.com/chart/O3tF7YmY/?symbol=NSE:" + this.currSelectedStock);
        }

        private void btn_screener_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.screener.in/company/" + this.currSelectedStock + "/");
        }


        public void ClearSearch()
        {
            if (txt_search.InvokeRequired)
            {
                txt_search.Invoke(new MethodInvoker(() => ClearSearch()));
            }
            else
            {
                if (txt_search.Focused)
                {
                    txt_search.Text = "";
                }
                else
                {
                    txt_search.Font = new Font("Segoe UI Variable Display", 10, FontStyle.Regular);
                    txt_search.Text = "Search Industry or Symbol";
                    txt_search.ForeColor = Color.Gray;
                }
            }
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            if (txt_search.Text == "Search Industry or Symbol")
                return;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool found = false;

                if (row.Cells["symbol"].Value != null && row.Cells["symbol"].Value.ToString().ToLower().Contains(txt_search.Text.ToLower()))
                {
                    found = true;

                }
                if (!found)
                {
                    if (row.Visible)
                    {
                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                        currencyManager1.SuspendBinding();
                        row.Visible = false;
                        currencyManager1.ResumeBinding();
                    }
                }
                else
                {
                    if (!row.Visible)
                    {
                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                        currencyManager1.SuspendBinding();
                        row.Visible = true;
                        currencyManager1.ResumeBinding();
                    }
                }
            }
        }

        private void txt_search_Enter(object sender, EventArgs e)
        {
            if (txt_search.Text == "Search Industry or Symbol")
            {
                txt_search.Font = new Font("Segoe UI Variable Display", 10, FontStyle.Regular);
                txt_search.Text = "";
                txt_search.ForeColor = Color.Black;
            }
        }

        private void txt_search_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_search.Text))
            {
                txt_search.Font = new Font("Segoe UI Variable Display", 10, FontStyle.Regular);
                txt_search.Text = "Search Industry or Symbol";
                txt_search.ForeColor = Color.Gray;
            }
        }
    }
}
