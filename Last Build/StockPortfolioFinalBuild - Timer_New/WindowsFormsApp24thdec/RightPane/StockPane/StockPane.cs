using WindowsFormsApp24thdec.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WindowsFormsApp24thdec.Models.MasterDataSet;
using System.IO;
using System.Net;


using TL;

using System.Web;
using System.Net.Mail;
using System.Runtime.InteropServices;
using Services;
using System.Diagnostics;
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ToolTip = System.Windows.Forms.ToolTip;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace WindowsFormsApp24thdec.RightPane.StockPane
{
    public partial class StockPane : UserControl, IStockPane
    {
        private StockStudyPresenter presenter;
        private CrossoverDataGaugePainter crossoverPainter;
        private FiftyTwoWeekDataGaugePainter fiftyTwoWeekPainter;
        //private Logger logger;

        private string currSelectedStock;



        private readonly Color defaultColor = SystemColors.GrayText;
        private readonly string defaultText = "Enter text here";
        private bool isDefaultText = true;

        private bool formLoaded = false;

        private bool editShown = true;

        public StockPane()
        {
            InitializeComponent();
            presenter = new StockStudyPresenter(this);



            this.dataGridView1.ColNames = new List<string> { "A/I", "P", "Industry", "Symbol", "CMP", "Buy/Sell", "Buy/Sell 20/50 EMA", "50/200 MA", "52w Lo/Hi", "Debt/Eq. %", "EPS 12M", "P/B", "PE 12M", "50 D AVG", "200 D AVG", "52w Low", "52w High", "Last Update" };
            this.dataGridView1.ColFormats = new List<string> { "", "", "", "", "c", "", "", "", "", "#,##0.0", "#,##0.00", "#,##0.00", "#,##0.00", "#,##0.00", "#,##0.00", "#,##0.00", "#,##0.00", "yyyy'-'MM'-'dd HH:mm" };
            this.dataGridView1.ColAlignments = new List<DataGridViewContentAlignment> { DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter,  DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleLeft };
            this.dataGridView1.ColToolTips = new List<string> { "Active/Inactive", "Portfolio Stock", "Industry in which Company operates", "Symbol", "Current Market Price", "Buy/Sell Signal", "Buy/Sell Signal based on 50 and 200 Day Moving Average", "50/200 Day Moving Average", "52 Week Low/High", "Debt to Equity Ratio", "Earnings Per Share TTM", "Price to Book Ratio", "Price to Earnings TTM", "", "", "", "", "Last Update Date" };

            this.dataGridView1.CellPainting += dataGridView1_CellPainting;
            this.dataGridView1.ColWidths = new List<double> { 0.050, 0.050, 0.15, 0.115, 0.09, 0.08, 0.08, 0.15, 0.15, 0.1, 0.1, 0.1, 0.1, 0, 0, 0, 0, 0.14 };

            this.crossoverPainter = new CrossoverDataGaugePainter();
            this.fiftyTwoWeekPainter = new FiftyTwoWeekDataGaugePainter();
            //this.logger = Logger.Instance;

            txt_search.ForeColor = defaultColor;
            txt_search.Text = defaultText;

            txt_search.Enter += txtBox_Enter;
            txt_search.Leave += txtBox_Leave;

            //InitializeToolbar();
        }



        private void txtBox_Enter(object sender, EventArgs e)
        {
            if (txt_search.Text == "Search Industry or Symbol")
            {
                txt_search.Font = new Font("Segoe UI Variable Display", 10, FontStyle.Regular);
                txt_search.Text = "";
                txt_search.ForeColor = Color.Black;
            }
        }

        private void txtBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_search.Text))
            {
                txt_search.Font = new Font("Segoe UI Variable Display", 10, FontStyle.Regular);
                txt_search.Text = "Search Industry or Symbol";
                txt_search.ForeColor = Color.Gray;
            }
        }

        private void PropertyGrid1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.Red), propertyGrid1.ClientRectangle);
        }

        private void btn_import_Click(object sender, EventArgs e)
        {
            presenter.ImportStockList();


        }

        public void DisableImportButton()
        {
            btn_import.Invoke((MethodInvoker)(() => btn_import.Enabled = false));
        }

        public void EnableImportButton()
        {
            btn_import.Invoke((MethodInvoker)(() => btn_import.Enabled = true));
        }

        public void LoadGridView(DataTable table)
        {
            if (dataGridView1.InvokeRequired)
            {
                dataGridView1.BeginInvoke((Action)delegate { LoadGridViewHelper(table); });
            }
            else
            {
                LoadGridViewHelper(table);
            }
        }

        private void LoadGridViewHelper(DataTable table)
        {
            this.dataGridView1.DataSource = table;

            this.dataGridView1.Columns["fifty_day_average"].Visible = false;
            this.dataGridView1.Columns["two_hundred_day_average"].Visible = false;

            this.dataGridView1.Columns["fifty_two_week_low"].Visible = false;
            this.dataGridView1.Columns["fifty_two_week_high"].Visible = false;

            this.dataGridView1.Columns["buy_sell_latest_20_50"].Frozen = true;

            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].DefaultCellStyle.Format = dataGridView1.ColFormats[i];
                dataGridView1.Columns[i].DefaultCellStyle.Alignment = dataGridView1.ColAlignments[i];
                dataGridView1.Columns[i].HeaderCell.Value = dataGridView1.ColNames[i];
                dataGridView1.Columns[i].ToolTipText = dataGridView1.ColToolTips[i];

                dataGridView1.Columns[i].HeaderCell.Style.Alignment = dataGridView1.ColAlignments[i];
            }
            Logger.Instance.WriteToLogFile(LoggerFlags.Information, "Stock Pane DataGridView Loaded");

        }

        private void StockPane_Load(object sender, EventArgs e)
        {
            presenter.FetchData();
            presenter.FetchTime();
            Logger.Instance.WriteToLogFile(LoggerFlags.Information, "Stock Pane Loaded");

            this.formLoaded = true;

        }

        

        private void StockPane_Resize(object sender, EventArgs e)
        {

            dataGridView1.Size = new Size(2 * (this.ClientSize.Width / 3) - (2 * 40 / 3) + 100, this.ClientSize.Height - 90);
            int client = this.ClientSize.Width;
            btn_import.Location = new System.Drawing.Point(client - 20 - btn_import.Width, 14);
            btn_tview.Size = new Size(44, 44);
            btn_tview.Location = new Point(btn_import.Location.X - btn_tview.Width - 20, 14);
            btn_screener.Size = new Size(44, 44);
            btn_screener.Location = new Point(btn_tview.Location.X - btn_screener.Width - 20, 14);
            propertyGrid1.Size = new Size(dataGridView1.Width / 2 - 130, dataGridView1.Height);
            propertyGrid1.Location = new Point(dataGridView1.Location.X + dataGridView1.Width, dataGridView1.Location.Y);
            
            propertyGrid1.PropertySort = PropertySort.Categorized;
            propertyGrid1.ForeColor = Color.Green;
            propertyGrid1.CategoryForeColor = Color.Black;
            propertyGrid1.CategorySplitterColor = UIColor.EvenDarkerColor;
            propertyGrid1.LineColor = UIColor.DarkColor;
            propertyGrid1.CategorySplitterColor = UIColor.DarkestColor;
            propertyGrid1.ViewBorderColor = UIColor.DarkestColor;
            propertyGrid1.ViewBackColor = UIColor.LightColor;
            pnl_border.Size = new Size(dataGridView1.Width + propertyGrid1.Width, 5);



            ToolTip myToolTip = new ToolTip();
            myToolTip.SetToolTip(btn_screener, "Open stock in Screener.com");
            myToolTip.SetToolTip(btn_tview, "Open stock in TradingView.com");
            myToolTip.SetToolTip(btn_import, "Perform an Import Operation");

            txt_search.Location = new Point(btn_screener.Location.X - 200, lbl_stockHeader.Location.Y + 10);

            txt_search.Size = new Size(165, 26);
            txt_search.Font = new Font("Segoe UI Variable Display", 10, System.Drawing.FontStyle.Regular);

            txt_search.Font = new Font("Segoe UI Variable Display", 10, FontStyle.Regular);
            txt_search.Text = "Search Industry or Symbol";
            txt_search.ForeColor = Color.Gray;

            btn_timer.Padding = new Padding(0);
            btn_timer.Size = new Size(52, 25);
            btn_timer.Location = new Point(txt_search.Location.X - btn_timer.Width - 20, lbl_stockHeader.Location.Y + 10);

            txt_timer.Location = new Point(btn_timer.Location.X - txt_timer.Width + 1, lbl_stockHeader.Location.Y + 10);

            txt_timer.Size = new Size(52, 26);
            txt_timer.Font = new Font("Segoe UI Variable Display", 10, FontStyle.Regular);
            //txt_timer.ForeColor = Color.Gray;
            txt_timer.Enabled = false;

            lbl_timer.Location = new Point(txt_timer.Location.X - lbl_timer.Width - 6, lbl_stockHeader.Location.Y + 14);


        }















        private void label1_Click(object sender, EventArgs e)
        {
            txt_search.Focus();
        }

        private void TextBox1_Enter(object sender, EventArgs e)
        {
            if (txt_search.Text == "Enter your search term")
            {
                txt_search.Text = "";
                txt_search.ForeColor = Color.Black;
            }
        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_search.Text))
            {
                txt_search.Text = "Enter your search term";
                txt_search.ForeColor = Color.Gray;
            }
        }




        private void dataGridView1_Resize(object sender, EventArgs e)
        {
            int width = (sender as DataGridView).Width;
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].Width = (int)((double)width * dataGridView1.ColWidths[i]) - 2;
            }

            for (int i = 1; i < dataGridView1.ColumnCount; i++)
                dataGridView1.Columns[i].ReadOnly = true;

            
            pnl_border.Location = new Point(dataGridView1.Location.X, dataGridView1.Location.Y + dataGridView1.Height);

            pnl_border.BackColor = UIColor.DarkestColor;

        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];


                bool val = Convert.ToBoolean(row.Cells["portfolio_stock"].Value);
                if (val)
                {
                    row.Cells["active"].ReadOnly = true;
                }
                else
                {
                    row.Cells["active"].Value = !Convert.ToBoolean(row.Cells["active"].EditedFormattedValue);
                    this.dataGridView1.RefreshEdit();
                    presenter.ChangeActive((string)row.Cells[3].Value, (bool)row.Cells[0].Value);
                }
            }
        }


        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dataGridView1.ClearSelection();
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {


            try {

                if (dataGridView1.SelectedCells.Count > 0)
                {

                    dataGridView1.CurrentRow.Selected = true;

                    string value = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[3].Value.ToString();
                    this.currSelectedStock = value;
                    presenter.SelectionChanged(value);
                }
            }
            catch(System.Data.DeletedRowInaccessibleException ex)
            {
                return;
            }
        }


        public void BindPropertyGrid(StockDetails sd)
        {
            propertyGrid1.SelectedObject = sd;
        }


        private void dataGridView1_CellPainting(object sender, System.Windows.Forms.DataGridViewCellPaintingEventArgs e)
        {
            if((this.dataGridView1.Columns["crossover"].Index == e.ColumnIndex && e.RowIndex >= 0) ||
                (this.dataGridView1.Columns["fifty_two_low_high"].Index == e.ColumnIndex && e.RowIndex >= 0))
            {
                using (
                    Brush gridBrush = new SolidBrush(this.dataGridView1.GridColor),
                    backColorBrush = new SolidBrush(e.CellStyle.BackColor))
                {
                    using (Pen gridLinePen = new Pen(gridBrush))
                    {

                        e.Graphics.FillRectangle(backColorBrush, e.CellBounds);


                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left,
                            e.CellBounds.Bottom - 1, e.CellBounds.Right - 1,
                            e.CellBounds.Bottom - 1);
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1,
                            e.CellBounds.Top, e.CellBounds.Right - 1,
                            e.CellBounds.Bottom);

                    }
                }
            }
            

            if (this.dataGridView1.Columns["crossover"].Index == e.ColumnIndex && e.RowIndex >= 0)
            {
                object fifty_day_average = dataGridView1["fifty_day_average", e.RowIndex].Value;
                object two_hundred_day_average = dataGridView1["two_hundred_day_average", e.RowIndex].Value;

                if (fifty_day_average != DBNull.Value && two_hundred_day_average != DBNull.Value)
                {
                    float[] levels = { (float)fifty_day_average, (float)two_hundred_day_average };
                    crossoverPainter.SetLevels(levels);
                    string[] levelLabels = { "50", "200" };
                    crossoverPainter.SetLevelLabels(levelLabels);
                    crossoverPainter.SetValue((float)((decimal)dataGridView1["current_price", e.RowIndex].Value));
                    crossoverPainter.Paint(e.Graphics, e.CellBounds);

                    e.Handled = true;
                }

            }



            if (this.dataGridView1.Columns["fifty_two_low_high"].Index == e.ColumnIndex && e.RowIndex >= 0)
            {

                object fifty_two_week_low = dataGridView1["fifty_two_week_low", e.RowIndex].Value;
                object fifty_two_week_high = dataGridView1["fifty_two_week_high", e.RowIndex].Value;

                if (fifty_two_week_low != DBNull.Value && fifty_two_week_high != DBNull.Value)
                {
                    float[] levels = { (float)fifty_two_week_low, (float)fifty_two_week_high };
                    fiftyTwoWeekPainter.SetLevels(levels);
                    string[] levelLabels = { "Lo", "Hi" };
                    fiftyTwoWeekPainter.SetLevelLabels(levelLabels);
                    fiftyTwoWeekPainter.SetValue((float)((decimal)dataGridView1["current_price", e.RowIndex].Value));
                    fiftyTwoWeekPainter.Paint(e.Graphics, e.CellBounds);

                    e.Handled = true;
                }

            }


            


        }



        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            


            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                if (row.Selected)
                {
                    e.CellStyle.SelectionBackColor = SystemColors.Highlight;
                    e.CellStyle.SelectionForeColor = SystemColors.HighlightText;
                }
                else
                {
                    e.CellStyle.BackColor = dataGridView1.DefaultCellStyle.BackColor;
                    e.CellStyle.ForeColor = dataGridView1.DefaultCellStyle.ForeColor;
                }

                // Set the background color of the custom painted columns to the same blue color as the other columns
                if (e.ColumnIndex == 7 || e.ColumnIndex == 8)
                {
                    if (row.Selected)
                    {
                        e.CellStyle.BackColor = SystemColors.Highlight;
                        e.CellStyle.ForeColor = SystemColors.HighlightText;
                    }
                    else
                    {
                        e.CellStyle.BackColor = dataGridView1.DefaultCellStyle.BackColor;
                        e.CellStyle.ForeColor = dataGridView1.DefaultCellStyle.ForeColor;
                    }
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
                else if ((string)e.Value == "BUY")
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

        public void RefreshData()
        {
            presenter.FetchData();
        }

        private void btn_tview_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.tradingview.com/chart/O3tF7YmY/?symbol=NSE:" + this.currSelectedStock);
        }

        private void btn_screener_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.screener.in/company/" + this.currSelectedStock + "/");
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            
            var prop = e.ChangedItem.PropertyDescriptor;
            var obj = e.ChangedItem.Value;

            var floatFormatAttr = prop.Attributes.OfType<FloatFormatAttribute>().FirstOrDefault();
            if (floatFormatAttr != null && prop.PropertyType == typeof(float))
            {
                var format = floatFormatAttr.Format;
                var floatValue = (float)prop.GetValue(obj);
                prop.SetValue(obj, float.Parse(floatValue.ToString(format)));
            }
        }

        


        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            if (txt_search.Text == "Search Industry or Symbol")
                return;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool found = false;



                if (row.Cells["symbol"].Value != null && row.Cells["industry"].Value != null && (row.Cells["symbol"].Value.ToString().ToLower().Contains(txt_search.Text.ToLower())) || (row.Cells["industry"].Value.ToString().ToLower().Contains(txt_search.Text.ToLower())))
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

        
        public void FetchTime(string num)
        {
            txt_timer.Text = num;
        }

        private void txt_timer_Leave(object sender, EventArgs e)
        {
            if (txt_timer.Text == "")
                presenter.FetchTime();
        }

        private void btn_timer_Click(object sender, EventArgs e)
        {
            if (editShown)
                editShown = false;
            else
                editShown = true;

            if (!editShown)
            {
                //txt_timer.ForeColor = Color.Black;
                btn_timer.Text = "SET";
                txt_timer.Enabled = true;
                //btn_timer.BackColor = Color.White;
                btn_timer.BackColor = Color.LightCoral;
            }

            else
            {
                //txt_timer.ForeColor = Color.Gray;
                btn_timer.Text = "EDIT";
                txt_timer.Enabled = false;
                //btn_timer.BackColor = SystemColors.Control;
                
                btn_timer.BackColor = SystemColors.GradientActiveCaption;
                //earlier it was ActiveCaption, a bit darker
            }

            if (editShown)
            {
                int val;
                if (int.TryParse(txt_timer.Text, out val))
                {
                    if(val < 1)
                    {
                        presenter.FetchTime();
                        MessageBox.Show("Interval cannot be smaller than 1 minute!");
                        return;
                    }
                    presenter.SetTimer(val.ToString());
                }
                else
                {
                    presenter.FetchTime();
                    MessageBox.Show("Invalid Interval!");
                    return;
                }
            }
                
        }
    }

    
}








