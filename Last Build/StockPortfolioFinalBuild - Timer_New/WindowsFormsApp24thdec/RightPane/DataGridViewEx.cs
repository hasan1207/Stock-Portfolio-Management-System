using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp24thdec.RightPane
{
    
    public partial class DataGridViewEx : DataGridView
    {
        private List<double> colWidths;
        private List<string> colNames;
        private List<string> colFormats;
        private List<DataGridViewContentAlignment> colAlignments;
        private List<string> colToolTips;

        public List<double> ColWidths
        {
            get { return colWidths; }
            set { colWidths = value; }
        }

        public List<string> ColNames
        {
            get { return colNames; }
            set { colNames = value; }
        }

        public List<string> ColFormats
        {
            get { return colFormats; }
            set
            {
                colFormats = value;
            }
        }

        public List<DataGridViewContentAlignment> ColAlignments
        {
            get { return colAlignments; }
            set { colAlignments = value; }
        }

        public List<string> ColToolTips
        {
            get { return colToolTips; }
            set { colToolTips = value; }
        }
        public DataGridViewEx()
        {
            InitializeComponent();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();

            //this.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = UIColor.DarkColor;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0,10,0,10);
            this.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            //dataGridViewCellStyle2.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle2.BackColor = UIColor.LightColor;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DefaultCellStyle = dataGridViewCellStyle2;
            this.EnableHeadersVisualStyles = false;
            //this.Location = new System.Drawing.Point(22, 106);
            //this.Name = "dataGridView1";
            this.RowHeadersVisible = false;
            this.RowHeadersWidth = 51;
            this.RowTemplate.Height = 30;
            this.Size = new System.Drawing.Size(958, 537);
            this.TabIndex = 4;


            this.BackgroundColor = UIColor.LightColor;
            this.GridColor = UIColor.DarkestColor;

            this.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            //this.EnableHeadersVisualStyles = false;


            this.AllowUserToAddRows = false;
            this.ReadOnly = true;


            this.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.AllowUserToResizeRows = false;

            //this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //this.EnableHeadersVisualStyles = false;
            //this.ColumnHeadersDefaultCellStyle.SelectionBackColor = this.ColumnHeadersDefaultCellStyle.BackColor;

            Type dgvType = this.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            pi.SetValue(this, true, null);
        }
    }
}
