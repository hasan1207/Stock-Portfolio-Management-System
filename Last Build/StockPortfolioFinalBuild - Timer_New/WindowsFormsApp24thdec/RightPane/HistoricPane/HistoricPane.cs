using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp24thdec.Presenters;

namespace WindowsFormsApp24thdec.RightPane.HistoricPane
{
    public partial class HistoricPane : UserControl, IHistoricPane
    {
        private HistoricDataPresenter presenter;
        public HistoricPane()
        {
            InitializeComponent();
            presenter = new HistoricDataPresenter(this);
            this.dataGridViewEx1.ColNames = new List<string> { "Symbol", "RSI", "Stock ID", "Active" };
            this.dataGridViewEx1.ColWidths = new List<double> { 0.50, 0.30, 0, 0.20 };
            this.dataGridViewEx1.ColAlignments = new List<DataGridViewContentAlignment> { DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter };
            this.dataGridViewEx1.ColFormats = new List<string> { "", "#,##0.0", "", "" };
            this.dataGridViewEx2.ColNames = new List<string> { "Stock ID", "TS", "Open", "High", "Low", "Close", "Vol" };
            this.dataGridViewEx2.ColWidths = new List<double> { 0, 0.2, 0.16, 0.16, 0.16, 0.16, 0.16 };
            this.dataGridViewEx2.ColAlignments = new List<DataGridViewContentAlignment> { DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight };
            this.dataGridViewEx2.ColFormats = new List<string> { "", "", "c", "c", "c", "c", "#,##0" };



            SetProgressBarVisibility(false);
        }

        public void SetUpdateProgress(int progress, string message)
        {
            if(progress <= 100)
                progressBar1.Invoke((MethodInvoker)(() => progressBar1.Value = progress));
        }

        public void HideProgressBar()
        {
            if (progressBar1.InvokeRequired)
            {
                progressBar1.BeginInvoke((Action)delegate { SetProgressBarVisibility(false); });
            }
            else
            {
                SetProgressBarVisibility(false);
            }
        }

        public void ShowProgressBar()
        {
            if (progressBar1.InvokeRequired)
            {
                progressBar1.BeginInvoke((Action)delegate { SetProgressBarVisibility(true); });
            }
            else
            {
                SetProgressBarVisibility(true);
            }
        }

        private void SetProgressBarVisibility(bool visible)
        {
            progressBar1.Visible = visible;
        }

        public void LoadStockGridView(DataTable table)
        {
            if (dataGridViewEx1.InvokeRequired)
            {
                dataGridViewEx1.BeginInvoke((Action)delegate { LoadStockGridViewHelper(table); });
            }
            else
            {
                LoadStockGridViewHelper(table);
            }
        }

        public void LoadStockGridViewHelper(DataTable table)
        {
            dataGridViewEx1.DataSource = table;
            dataGridViewEx1.Columns["stock_id"].Visible = false;

            for(int i = 0; i < dataGridViewEx1.ColumnCount; i++)
            {
                dataGridViewEx1.Columns[i].DefaultCellStyle.Format = dataGridViewEx1.ColFormats[i];
                dataGridViewEx1.Columns[i].DefaultCellStyle.Alignment = dataGridViewEx1.ColAlignments[i];
                dataGridViewEx1.Columns[i].HeaderCell.Value = dataGridViewEx1.ColNames[i];
                dataGridViewEx1.Columns[i].HeaderCell.Style.Alignment = dataGridViewEx1.ColAlignments[i];

            }
        }

        private void HistoricPane_Load(object sender, EventArgs e)
        {
            presenter.FetchData();
        }

        private void dataGridViewEx1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewEx1 != null && dataGridViewEx1.Rows.Count > 0 && dataGridViewEx1.Columns.Count > 0)
            {
                if (dataGridViewEx1.SelectedCells.Count > 0)
                {

                    dataGridViewEx1.CurrentRow.Selected = true;

                    int value = (int)dataGridViewEx1.Rows[dataGridViewEx1.SelectedCells[0].RowIndex].Cells["stock_id"].Value;
                    presenter.SelectionChanged(value);
                }
            }
            
        }

        public void LoadOhlcGrid(DataTable table)
        {
            if (dataGridViewEx2.InvokeRequired)
            {
                dataGridViewEx2.BeginInvoke((Action)delegate { LoadOhlcGridViewHelper(table); });
            }
            else
            {
                LoadOhlcGridViewHelper(table);
            }
        }

        public void LoadOhlcGridViewHelper(DataTable table)
        {
            dataGridViewEx2.DataSource = table;
            dataGridViewEx2.Columns["stock_id"].Visible = false;

            for(int i = 0; i < dataGridViewEx2.ColumnCount; i++)
            {
                dataGridViewEx2.Columns[i].DefaultCellStyle.Format = dataGridViewEx2.ColFormats[i];
                dataGridViewEx2.Columns[i].DefaultCellStyle.Alignment = dataGridViewEx2.ColAlignments[i];
                dataGridViewEx2.Columns[i].HeaderCell.Value = dataGridViewEx2.ColNames[i];
                dataGridViewEx2.Columns[i].HeaderCell.Style.Alignment = dataGridViewEx2.ColAlignments[i];
            }
        }

        private void HistoricPane_Resize(object sender, EventArgs e)
        {
            dataGridViewEx1.Size = new Size((this.ClientSize.Width / 4) - (40 / 4), this.ClientSize.Height - 90);
            dataGridViewEx2.Size = new Size((dataGridViewEx1.Width * 3) - (3 * (40 / 4)), this.ClientSize.Height - 90);
            dataGridViewEx2.Location = new Point(this.ClientSize.Width - 20 - dataGridViewEx2.Width, dataGridViewEx1.Location.Y);
            progressBar1.Location = new Point(dataGridViewEx2.Location.X + dataGridViewEx2.Width - progressBar1.Width, dataGridViewEx2.Location.Y - 40);
            pnl_grid1.Size = new Size(dataGridViewEx1.Width, 5);
            pnl_grid1.Location = new Point(dataGridViewEx1.Location.X, dataGridViewEx1.Location.Y + dataGridViewEx1.Height);

            pnl_grid2.Size = new Size(dataGridViewEx2.Width, 5);
            pnl_grid2.Location = new Point(dataGridViewEx2.Location.X, dataGridViewEx2.Location.Y + dataGridViewEx2.Height);
            txt_search.Location = new Point(827, 26);
            txt_search.Size = new Size(165, 26);

            txt_search.Text = "Search Industry or Symbol";
            txt_search.Font = new Font("Segoe UI Variable Display", 10, FontStyle.Regular);

            txt_search.ForeColor = Color.Gray;
        }

        private void dataGridViewEx1_Resize(object sender, EventArgs e)
        {
            int width = (sender as DataGridView).Width;
            for (int i = 0; i < dataGridViewEx1.ColumnCount; i++)
            {

                dataGridViewEx1.Columns[i].Width = (int)((double)width * dataGridViewEx1.ColWidths[i]) - 9;
            }
        }

        private void dataGridViewEx2_Resize(object sender, EventArgs e)
        {
            int client_width = (sender as DataGridView).Width;
            for (int i = 0; i < dataGridViewEx2.ColumnCount; i++)
            {
                dataGridViewEx2.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridViewEx2.Columns[i].Width = (int)((double)client_width * dataGridViewEx2.ColWidths[i]) - 3;
            }
        }

        public void RefreshData()
        {
            presenter.FetchData();
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
            foreach (DataGridViewRow row in dataGridViewEx1.Rows)
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
                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dataGridViewEx1.DataSource];
                        currencyManager1.SuspendBinding();
                        row.Visible = false;
                        currencyManager1.ResumeBinding();
                    }
                }
                else
                {
                    if (!row.Visible)
                    {
                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dataGridViewEx1.DataSource];
                        currencyManager1.SuspendBinding();
                        row.Visible = true;
                        currencyManager1.ResumeBinding();
                    }
                }
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

        private void txt_search_Enter(object sender, EventArgs e)
        {
            if (txt_search.Text == "Search Industry or Symbol")
            {
                txt_search.Font = new Font("Segoe UI Variable Display", 10, FontStyle.Regular);
                txt_search.Text = "";
                txt_search.ForeColor = Color.Black;
            }
        }
    }
}
