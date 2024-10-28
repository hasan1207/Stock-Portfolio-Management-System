namespace WindowsFormsApp24thdec.NavigationPane
{
    partial class NavPane
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_user = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_historical = new System.Windows.Forms.Button();
            this.btn_stock = new System.Windows.Forms.Button();
            this.btn_portfolio = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(232)))), ((int)(((byte)(234)))));
            this.panel1.Controls.Add(this.lbl_user);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(447, 178);
            this.panel1.TabIndex = 0;
            // 
            // lbl_user
            // 
            this.lbl_user.AutoSize = true;
            this.lbl_user.Font = new System.Drawing.Font("Segoe UI Variable Display", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_user.Location = new System.Drawing.Point(109, 132);
            this.lbl_user.Name = "lbl_user";
            this.lbl_user.Size = new System.Drawing.Size(195, 37);
            this.lbl_user.TabIndex = 1;
            this.lbl_user.Text = "Hasan Hafeez";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApp24thdec.Properties.Resources.user__3_;
            this.pictureBox1.Location = new System.Drawing.Point(155, 21);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(107, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel2.Location = new System.Drawing.Point(0, 210);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(8, 16);
            this.panel2.TabIndex = 2;
            // 
            // btn_historical
            // 
            this.btn_historical.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_historical.FlatAppearance.BorderSize = 0;
            this.btn_historical.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_historical.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_historical.Image = global::WindowsFormsApp24thdec.Properties.Resources.history__2_;
            this.btn_historical.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_historical.Location = new System.Drawing.Point(0, 338);
            this.btn_historical.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_historical.Name = "btn_historical";
            this.btn_historical.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btn_historical.Size = new System.Drawing.Size(447, 80);
            this.btn_historical.TabIndex = 1;
            this.btn_historical.Text = "Historical Data";
            this.btn_historical.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_historical.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_historical.UseVisualStyleBackColor = true;
            this.btn_historical.Click += new System.EventHandler(this.button_clicked);
            // 
            // btn_stock
            // 
            this.btn_stock.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_stock.FlatAppearance.BorderSize = 0;
            this.btn_stock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_stock.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_stock.Image = global::WindowsFormsApp24thdec.Properties.Resources.stock_market__5_;
            this.btn_stock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_stock.Location = new System.Drawing.Point(0, 258);
            this.btn_stock.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_stock.Name = "btn_stock";
            this.btn_stock.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btn_stock.Size = new System.Drawing.Size(447, 80);
            this.btn_stock.TabIndex = 1;
            this.btn_stock.Text = "Stock Study";
            this.btn_stock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_stock.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_stock.UseVisualStyleBackColor = true;
            this.btn_stock.Click += new System.EventHandler(this.button_clicked);
            // 
            // btn_portfolio
            // 
            this.btn_portfolio.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_portfolio.FlatAppearance.BorderSize = 0;
            this.btn_portfolio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_portfolio.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_portfolio.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_portfolio.Image = global::WindowsFormsApp24thdec.Properties.Resources.portfolio__4_;
            this.btn_portfolio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_portfolio.Location = new System.Drawing.Point(0, 178);
            this.btn_portfolio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_portfolio.Name = "btn_portfolio";
            this.btn_portfolio.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btn_portfolio.Size = new System.Drawing.Size(447, 80);
            this.btn_portfolio.TabIndex = 1;
            this.btn_portfolio.Text = "Portfolio";
            this.btn_portfolio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_portfolio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_portfolio.UseVisualStyleBackColor = false;
            this.btn_portfolio.Click += new System.EventHandler(this.button_clicked);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 575);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(447, 15);
            this.progressBar1.TabIndex = 3;
            // 
            // NavPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(232)))), ((int)(((byte)(234)))));
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btn_historical);
            this.Controls.Add(this.btn_stock);
            this.Controls.Add(this.btn_portfolio);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "NavPane";
            this.Size = new System.Drawing.Size(447, 590);
            this.Resize += new System.EventHandler(this.NavPane_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_user;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_portfolio;
        private System.Windows.Forms.Button btn_stock;
        private System.Windows.Forms.Button btn_historical;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}
