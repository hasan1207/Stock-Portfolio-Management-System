using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TL;
using WindowsFormsApp24thdec.Presenters;
using WindowsFormsApp24thdec.RightPane;
using WindowsFormsApp24thdec.RightPane.HistoricPane;
using WindowsFormsApp24thdec.RightPane.PortfolioPane;
using WindowsFormsApp24thdec.RightPane.StockPane;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp24thdec.NavigationPane
{
    public partial class NavPane : UserControl, INavPane
    {
        public delegate void PaneChangedEventHandler(object sender, EventArgs e);   
        public event PaneChangedEventHandler PaneChanged;
        private NavPanePresenter presenter;
        public NavPane()
        {
            InitializeComponent();
            presenter = new NavPanePresenter(this);
 
            btn_portfolio.BackColor = UIColor.LightColor;
            panel2.Height = (int)(btn_portfolio.Size.Height * 0.8);
            panel2.Location = new System.Drawing.Point(0, btn_portfolio.Location.Y + (btn_portfolio.Size.Height / 2) - (panel2.Size.Height / 2));

            SetProgressBarVisibility(false);
        }

        protected virtual void OnPaneChanged(PaneEventArgs e)
        {
            PaneChanged?.Invoke(this, e);
        }

        public void PaneChangedMethod(object sender, EventArgs e)
        {
            string btnName = (e as PaneEventArgs).Name;
            if(btnName == "Portfolio")
            {
                btn_portfolio.BackColor = UIColor.LightColor;
                btn_stock.BackColor = UIColor.DarkColor;
                btn_historical.BackColor = UIColor.DarkColor;
            }
            else if(btnName == "Stock Study")
            {
                btn_portfolio.BackColor = UIColor.DarkColor;
                btn_stock.BackColor = UIColor.LightColor;
                btn_historical.BackColor = UIColor.DarkColor;
            }
            else
            {
                btn_portfolio.BackColor = UIColor.DarkColor;
                btn_stock.BackColor = UIColor.DarkColor;
                btn_historical.BackColor = UIColor.LightColor;
            }

        }

        private void NavPane_Resize(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point((this.ClientSize.Width / 2) - (pictureBox1.Width / 2),
            pictureBox1.Location.Y);
            lbl_user.Location = new Point((this.ClientSize.Width / 2) - (lbl_user.Width / 2),
                  lbl_user.Location.Y);
        }

        private void button_clicked(object sender, EventArgs e)
        {
            System.Windows.Forms.Button btn = sender as System.Windows.Forms.Button;

            panel2.Height = (int)(btn.Size.Height * 0.2);
            int start = btn.Location.Y + (btn.Size.Height/2) - (panel2.Size.Height/2);
            panel2.Location = new System.Drawing.Point(0, start);

            for(int i = 0; i < ((btn.Size.Height * 0.6)/6); i++)
            {
                panel2.Location = new System.Drawing.Point(0,panel2.Location.Y - 3);
                panel2.Height += 6;
                this.Refresh();
                Thread.Sleep(1);
            }

            OnPaneChanged(new PaneEventArgs(btn.Text));
        }

        public void SetUpdateProgress(int progress, string message)
        {
            if (progressBar1.InvokeRequired)
            {
                progressBar1.BeginInvoke((Action)delegate { SetUpdateProgressHelper(progress, message); });
            }
            else
            {
                SetUpdateProgressHelper(progress, message);
            }
        }

        private void SetUpdateProgressHelper(int progress, string message)
        {
            progressBar1.Value = progress;
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
    }

    
    public class PaneEventArgs : EventArgs
    {
        public string Name { get; set; }

        public PaneEventArgs(string name)
        {
            Name = name;
        }
    }
    

}
