using System.Windows.Forms;

namespace WindowsFormsApp24thdec.RightPane.PortfolioPane
{
    partial class PortfolioPane
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbl_portfolioHeader = new System.Windows.Forms.Label();
            this.pnl_border = new System.Windows.Forms.Panel();
            this.dataGridViewTotal = new WindowsFormsApp24thdec.RightPane.DataGridViewEx();
            this.dataGridView1 = new WindowsFormsApp24thdec.RightPane.DataGridViewEx();
            this.btn_tview = new System.Windows.Forms.Button();
            this.btn_screener = new System.Windows.Forms.Button();
            this.btn_import = new System.Windows.Forms.Button();
            this.txt_search = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_portfolioHeader
            // 
            this.lbl_portfolioHeader.AutoSize = true;
            this.lbl_portfolioHeader.Font = new System.Drawing.Font("Calibri", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_portfolioHeader.Location = new System.Drawing.Point(20, 20);
            this.lbl_portfolioHeader.Name = "lbl_portfolioHeader";
            this.lbl_portfolioHeader.Size = new System.Drawing.Size(189, 40);
            this.lbl_portfolioHeader.TabIndex = 5;
            this.lbl_portfolioHeader.Text = "My Portfolio";
            // 
            // pnl_border
            // 
            this.pnl_border.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(217)))), ((int)(((byte)(219)))));
            this.pnl_border.Location = new System.Drawing.Point(20, 583);
            this.pnl_border.Name = "pnl_border";
            this.pnl_border.Size = new System.Drawing.Size(957, 7);
            this.pnl_border.TabIndex = 7;
            // 
            // dataGridViewTotal
            // 
            this.dataGridViewTotal.AllowUserToAddRows = false;
            this.dataGridViewTotal.AllowUserToResizeRows = false;
            this.dataGridViewTotal.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.dataGridViewTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewTotal.ColAlignments = null;
            this.dataGridViewTotal.ColFormats = null;
            this.dataGridViewTotal.ColNames = null;
            this.dataGridViewTotal.ColToolTips = null;
            this.dataGridViewTotal.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(232)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTotal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTotal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTotal.ColumnHeadersVisible = false;
            this.dataGridViewTotal.ColWidths = null;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTotal.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTotal.EnableHeadersVisualStyles = false;
            this.dataGridViewTotal.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(217)))), ((int)(((byte)(219)))));
            this.dataGridViewTotal.Location = new System.Drawing.Point(20, 596);
            this.dataGridViewTotal.Name = "dataGridViewTotal";
            this.dataGridViewTotal.ReadOnly = true;
            this.dataGridViewTotal.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridViewTotal.RowHeadersVisible = false;
            this.dataGridViewTotal.RowHeadersWidth = 51;
            this.dataGridViewTotal.RowTemplate.Height = 30;
            this.dataGridViewTotal.Size = new System.Drawing.Size(957, 54);
            this.dataGridViewTotal.TabIndex = 4;
            this.dataGridViewTotal.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewTotal_CellFormatting);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColAlignments = null;
            this.dataGridView1.ColFormats = null;
            this.dataGridView1.ColNames = null;
            this.dataGridView1.ColToolTips = null;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(232)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColWidths = null;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(217)))), ((int)(((byte)(219)))));
            this.dataGridView1.Location = new System.Drawing.Point(20, 90);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(957, 491);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.dataGridView1.Resize += new System.EventHandler(this.dataGridView1_Resize);
            // 
            // btn_tview
            // 
            this.btn_tview.FlatAppearance.BorderSize = 0;
            this.btn_tview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_tview.Image = global::WindowsFormsApp24thdec.Properties.Resources._7644688__1_3;
            this.btn_tview.Location = new System.Drawing.Point(637, 37);
            this.btn_tview.Name = "btn_tview";
            this.btn_tview.Size = new System.Drawing.Size(75, 23);
            this.btn_tview.TabIndex = 17;
            this.btn_tview.UseVisualStyleBackColor = true;
            this.btn_tview.Click += new System.EventHandler(this.btn_tview_Click);
            // 
            // btn_screener
            // 
            this.btn_screener.FlatAppearance.BorderSize = 0;
            this.btn_screener.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_screener.Image = global::WindowsFormsApp24thdec.Properties.Resources.Capture___Coloured___Cropped__2_1;
            this.btn_screener.Location = new System.Drawing.Point(460, 35);
            this.btn_screener.Name = "btn_screener";
            this.btn_screener.Size = new System.Drawing.Size(75, 23);
            this.btn_screener.TabIndex = 16;
            this.btn_screener.UseVisualStyleBackColor = true;
            this.btn_screener.Click += new System.EventHandler(this.btn_screener_Click);
            // 
            // btn_import
            // 
            this.btn_import.FlatAppearance.BorderSize = 0;
            this.btn_import.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_import.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_import.Image = global::WindowsFormsApp24thdec.Properties.Resources.import1;
            this.btn_import.Location = new System.Drawing.Point(848, 20);
            this.btn_import.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(163, 52);
            this.btn_import.TabIndex = 6;
            this.btn_import.Text = "Import";
            this.btn_import.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_import.UseVisualStyleBackColor = true;
            this.btn_import.Click += new System.EventHandler(this.btn_import_Click);
            // 
            // txt_search
            // 
            this.txt_search.BackColor = System.Drawing.SystemColors.Window;
            this.txt_search.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_search.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_search.Location = new System.Drawing.Point(266, 38);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(100, 34);
            this.txt_search.TabIndex = 18;
            this.txt_search.TextChanged += new System.EventHandler(this.txt_search_TextChanged);
            this.txt_search.Enter += new System.EventHandler(this.txt_search_Enter);
            this.txt_search.Leave += new System.EventHandler(this.txt_search_Leave);
            // 
            // PortfolioPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txt_search);
            this.Controls.Add(this.btn_tview);
            this.Controls.Add(this.btn_screener);
            this.Controls.Add(this.pnl_border);
            this.Controls.Add(this.dataGridViewTotal);
            this.Controls.Add(this.btn_import);
            this.Controls.Add(this.lbl_portfolioHeader);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PortfolioPane";
            this.Size = new System.Drawing.Size(1032, 668);
            this.Load += new System.EventHandler(this.PortfolioPane_Load);
            this.Resize += new System.EventHandler(this.PortfolioPane_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label lbl_portfolioHeader;
        private DataGridViewEx dataGridViewTotal;
        private DataGridViewEx dataGridView1;
        private Button btn_import;
        private Panel pnl_border;
        private Button btn_screener;
        private Button btn_tview;
        private TextBox txt_search;
    }
}
