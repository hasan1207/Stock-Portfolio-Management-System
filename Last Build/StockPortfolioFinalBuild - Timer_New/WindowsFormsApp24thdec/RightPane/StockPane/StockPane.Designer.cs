namespace WindowsFormsApp24thdec.RightPane.StockPane
{
    partial class StockPane
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbl_stockHeader = new System.Windows.Forms.Label();
            this.pnl_border = new System.Windows.Forms.Panel();
            this.btn_screener = new System.Windows.Forms.Button();
            this.btn_tview = new System.Windows.Forms.Button();
            this.btn_import = new System.Windows.Forms.Button();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.txt_timer = new System.Windows.Forms.TextBox();
            this.btn_timer = new System.Windows.Forms.Button();
            this.propertyGrid1 = new WindowsFormsApp24thdec.RightPane.PropertyGridEx();
            this.dataGridView1 = new WindowsFormsApp24thdec.RightPane.DataGridViewEx();
            this.lbl_timer = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_stockHeader
            // 
            this.lbl_stockHeader.AutoSize = true;
            this.lbl_stockHeader.Font = new System.Drawing.Font("Calibri", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_stockHeader.Location = new System.Drawing.Point(20, 20);
            this.lbl_stockHeader.Name = "lbl_stockHeader";
            this.lbl_stockHeader.Size = new System.Drawing.Size(178, 40);
            this.lbl_stockHeader.TabIndex = 7;
            this.lbl_stockHeader.Text = "Stock Study";
            // 
            // pnl_border
            // 
            this.pnl_border.Location = new System.Drawing.Point(190, 638);
            this.pnl_border.Name = "pnl_border";
            this.pnl_border.Size = new System.Drawing.Size(607, 16);
            this.pnl_border.TabIndex = 13;
            // 
            // btn_screener
            // 
            this.btn_screener.FlatAppearance.BorderSize = 0;
            this.btn_screener.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_screener.Image = global::WindowsFormsApp24thdec.Properties.Resources.Capture___Coloured___Cropped__2_;
            this.btn_screener.Location = new System.Drawing.Point(685, 35);
            this.btn_screener.Name = "btn_screener";
            this.btn_screener.Size = new System.Drawing.Size(75, 23);
            this.btn_screener.TabIndex = 15;
            this.btn_screener.UseVisualStyleBackColor = true;
            this.btn_screener.Click += new System.EventHandler(this.btn_screener_Click);
            // 
            // btn_tview
            // 
            this.btn_tview.FlatAppearance.BorderSize = 0;
            this.btn_tview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_tview.Image = global::WindowsFormsApp24thdec.Properties.Resources._7644688__1_2;
            this.btn_tview.Location = new System.Drawing.Point(919, 20);
            this.btn_tview.Name = "btn_tview";
            this.btn_tview.Size = new System.Drawing.Size(75, 23);
            this.btn_tview.TabIndex = 14;
            this.btn_tview.UseVisualStyleBackColor = true;
            this.btn_tview.Click += new System.EventHandler(this.btn_tview_Click);
            // 
            // btn_import
            // 
            this.btn_import.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_import.FlatAppearance.BorderSize = 0;
            this.btn_import.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_import.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_import.Image = global::WindowsFormsApp24thdec.Properties.Resources.import1;
            this.btn_import.Location = new System.Drawing.Point(257, 20);
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(162, 52);
            this.btn_import.TabIndex = 8;
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
            this.txt_search.Location = new System.Drawing.Point(209, 156);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(100, 34);
            this.txt_search.TabIndex = 16;
            this.txt_search.TextChanged += new System.EventHandler(this.txt_search_TextChanged);
            // 
            // txt_timer
            // 
            this.txt_timer.BackColor = System.Drawing.SystemColors.Window;
            this.txt_timer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_timer.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_timer.Location = new System.Drawing.Point(427, 165);
            this.txt_timer.Name = "txt_timer";
            this.txt_timer.Size = new System.Drawing.Size(100, 34);
            this.txt_timer.TabIndex = 17;
            this.txt_timer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_timer.Leave += new System.EventHandler(this.txt_timer_Leave);
            // 
            // btn_timer
            // 
            this.btn_timer.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btn_timer.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btn_timer.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ScrollBar;
            this.btn_timer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_timer.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_timer.Location = new System.Drawing.Point(523, 175);
            this.btn_timer.Name = "btn_timer";
            this.btn_timer.Size = new System.Drawing.Size(75, 23);
            this.btn_timer.TabIndex = 18;
            this.btn_timer.Text = "EDIT";
            this.btn_timer.UseVisualStyleBackColor = false;
            this.btn_timer.Click += new System.EventHandler(this.btn_timer_Click);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.BackColor = System.Drawing.SystemColors.Control;
            this.propertyGrid1.CommandsBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.propertyGrid1.Font = new System.Drawing.Font("Segoe UI Variable Display", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.propertyGrid1.HelpVisible = false;
            this.propertyGrid1.LargeButtons = true;
            this.propertyGrid1.Location = new System.Drawing.Point(787, 300);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(130, 130);
            this.propertyGrid1.TabIndex = 11;
            this.propertyGrid1.ToolbarVisible = false;
            this.propertyGrid1.ViewBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.propertyGrid1.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid1_PropertyValueChanged);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(232)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColWidths = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(217)))), ((int)(((byte)(219)))));
            this.dataGridView1.Location = new System.Drawing.Point(20, 90);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(958, 537);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.dataGridView1.Resize += new System.EventHandler(this.dataGridView1_Resize);
            // 
            // lbl_timer
            // 
            this.lbl_timer.AutoSize = true;
            this.lbl_timer.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_timer.Location = new System.Drawing.Point(482, 68);
            this.lbl_timer.Name = "lbl_timer";
            this.lbl_timer.Size = new System.Drawing.Size(135, 21);
            this.lbl_timer.TabIndex = 19;
            this.lbl_timer.Text = "UPDATE INTERVAL";
            // 
            // StockPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_timer);
            this.Controls.Add(this.btn_timer);
            this.Controls.Add(this.txt_timer);
            this.Controls.Add(this.txt_search);
            this.Controls.Add(this.btn_screener);
            this.Controls.Add(this.btn_tview);
            this.Controls.Add(this.pnl_border);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_import);
            this.Controls.Add(this.lbl_stockHeader);
            this.Name = "StockPane";
            this.Size = new System.Drawing.Size(1032, 668);
            this.Load += new System.EventHandler(this.StockPane_Load);
            this.Resize += new System.EventHandler(this.StockPane_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_import;
        private System.Windows.Forms.Label lbl_stockHeader;
        private DataGridViewEx dataGridView1;
        private System.Windows.Forms.Panel pnl_border;
        private System.Windows.Forms.Button btn_tview;
        private System.Windows.Forms.Button btn_screener;
        private PropertyGridEx propertyGrid1;
        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.TextBox txt_timer;
        private System.Windows.Forms.Button btn_timer;
        private System.Windows.Forms.Label lbl_timer;
    }
}
