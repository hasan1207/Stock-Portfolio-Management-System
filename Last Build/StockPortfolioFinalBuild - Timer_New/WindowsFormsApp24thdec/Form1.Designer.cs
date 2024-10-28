namespace WindowsFormsApp24thdec
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.rightPane1 = new WindowsFormsApp24thdec.RightPane.RightPane();
            this.navPane1 = new WindowsFormsApp24thdec.NavigationPane.NavPane();
            this.SuspendLayout();
            // 
            // rightPane1
            // 
            this.rightPane1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.rightPane1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightPane1.Location = new System.Drawing.Point(319, 0);
            this.rightPane1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rightPane1.Name = "rightPane1";
            this.rightPane1.Size = new System.Drawing.Size(1581, 953);
            this.rightPane1.TabIndex = 5;
            this.rightPane1.Load += new System.EventHandler(this.rightPane1_Load);
            // 
            // navPane1
            // 
            this.navPane1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(232)))), ((int)(((byte)(234)))));
            this.navPane1.Dock = System.Windows.Forms.DockStyle.Left;
            this.navPane1.Location = new System.Drawing.Point(0, 0);
            this.navPane1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.navPane1.Name = "navPane1";
            this.navPane1.Size = new System.Drawing.Size(319, 953);
            this.navPane1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1900, 953);
            this.Controls.Add(this.rightPane1);
            this.Controls.Add(this.navPane1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1918, 1000);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private NavigationPane.NavPane navPane1;
        private RightPane.RightPane rightPane1;
    }
}

