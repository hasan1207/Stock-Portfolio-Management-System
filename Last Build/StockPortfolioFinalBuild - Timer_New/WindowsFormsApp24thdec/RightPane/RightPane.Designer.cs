namespace WindowsFormsApp24thdec.RightPane
{
    partial class RightPane
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.stockPane1 = new WindowsFormsApp24thdec.RightPane.StockPane.StockPane();
            this.portfolioPane1 = new WindowsFormsApp24thdec.RightPane.PortfolioPane.PortfolioPane();
            this.historicPane1 = new WindowsFormsApp24thdec.RightPane.HistoricPane.HistoricPane();
            this.SuspendLayout();
            // 
            // stockPane1
            // 
            this.stockPane1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stockPane1.Location = new System.Drawing.Point(0, 0);
            this.stockPane1.Name = "stockPane1";
            this.stockPane1.Size = new System.Drawing.Size(1032, 589);
            this.stockPane1.TabIndex = 2;
            // 
            // portfolioPane1
            // 
            this.portfolioPane1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.portfolioPane1.Location = new System.Drawing.Point(0, 0);
            this.portfolioPane1.Name = "portfolioPane1";
            this.portfolioPane1.Size = new System.Drawing.Size(1032, 589);
            this.portfolioPane1.TabIndex = 1;
            // 
            // historicPane1
            // 
            this.historicPane1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.historicPane1.Location = new System.Drawing.Point(0, 0);
            this.historicPane1.Name = "historicPane1";
            this.historicPane1.Size = new System.Drawing.Size(1032, 589);
            this.historicPane1.TabIndex = 0;
            // 
            // RightPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.Controls.Add(this.historicPane1);
            this.Controls.Add(this.stockPane1);
            this.Controls.Add(this.portfolioPane1);
            this.Name = "RightPane";
            this.Size = new System.Drawing.Size(1032, 589);
            this.ResumeLayout(false);

        }

        #endregion

        private HistoricPane.HistoricPane historicPane1;
        private PortfolioPane.PortfolioPane portfolioPane1;
        private StockPane.StockPane stockPane1;
    }
}
