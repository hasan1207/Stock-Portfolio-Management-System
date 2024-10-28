using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp24thdec.RightPane
{
    //public partial class PropertyGridEx : UserControl
    //{
    //    public PropertyGridEx()
    //    {
    //        InitializeComponent();
    //    }
    //}


    //public partial class PropertyGridEx : PropertyGrid
    //{
    //    private Color _backColor = Color.Red;

    //    public PropertyGridEx()
    //    {
    //        SetStyle(ControlStyles.UserPaint, true);
    //    }

    //    public Color BackColor
    //    {
    //        get { return _backColor; }
    //        set
    //        {
    //            if (_backColor != value)
    //            {
    //                _backColor = value;
    //                Invalidate();
    //            }
    //        }
    //    }

    //protected override void WndProc(ref Message m)
    //{
    //    base.WndProc(ref m);
    //    if (m.Msg == 0x000F) // WM_PAINT
    //    {
    //        using (var g = Graphics.FromHwnd(Handle))
    //        {
    //            g.Clear(_backColor);
    //        }
    //    }
    //}


    //public PropertyGridEx()
    //{
    //    this.ViewForeColor = Color.FromArgb(1, 0, 0);
    //}
    ////---
    //private bool _readOnly;
    //public bool ReadOnly
    //{
    //    get { return _readOnly; }
    //    set
    //    {
    //        _readOnly = value;
    //        this.SetObjectAsReadOnly(this.SelectedObject, _readOnly);
    //    }
    //}
    ////---
    //protected override void OnSelectedObjectsChanged(EventArgs e)
    //{
    //    this.SetObjectAsReadOnly(this.SelectedObject, this._readOnly);
    //    base.OnSelectedObjectsChanged(e);
    //}
    ////---
    //private void SetObjectAsReadOnly(object selectedObject, bool isReadOnly)
    //{
    //    if (this.SelectedObject != null)
    //    {
    //        TypeDescriptor.AddAttributes(this.SelectedObject, new Attribute[] { new ReadOnlyAttribute(_readOnly) });
    //        this.Refresh();
    //    }
    //}


    //    public PropertyGridEx()
    //    {
    //        PropertyGridView = new PropertyGridExView(this);
    //    }

    //    public Color BackColor
    //    {
    //        get { return PropertyGridView.BackColor; }
    //        set { PropertyGridView.BackColor = value; }
    //    }

    //    public new PropertyGridExView PropertyGridView { get; }
    //}

    //public class PropertyGridExView : PropertyGrid.PropertyGridView
    //{
    //    public PropertyGridExView(PropertyGrid owner) : base(owner)
    //    {
    //    }

    //    public override void Paint(PaintEventArgs pevent)
    //    {
    //        // Fill the background with the custom color
    //        pevent.Graphics.Clear(BackColor);

    //        // Call the base Paint method to draw the rest of the control
    //        base.Paint(pevent);
    //    }
    //}



    //public PropertyGridEx()
    //{
    //    SetStyle(ControlStyles.Opaque, true);
    //}

    //protected override void WndProc(ref Message m)
    //{
    //    if (m.Msg == 0x14 /* WM_ERASEBKGND */)
    //    {
    //        using (var brush = new SolidBrush(Color.Red))
    //        {
    //            var g = Graphics.FromHdc(m.WParam);
    //            g.FillRectangle(brush, ClientRectangle);
    //            g.Dispose();
    //        }
    //        m.Result = IntPtr.Zero;
    //        return;
    //    }
    //    base.WndProc(ref m);
    //}
    //}


    public partial class PropertyGridEx : PropertyGrid
    {
        public PropertyGridEx()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.Opaque | ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), ClientRectangle);
        }

        //private void propertyGrid1_DrawItem(object sender, DrawItemEventArgs e)
        //{
        //    e.DrawBackground();
        //    e.DrawFocusRectangle();

        //    var labelFont = new Font(Font.FontFamily, Font.Size, FontStyle.Bold);
        //    var valueFont = new Font(Font.FontFamily, Font.Size, FontStyle.Regular);

        //    var prop = this.SelectedGridItem.PropertyDescriptor;
        //    var label = prop != null ? prop.DisplayName : this.SelectedGridItem.Label;

        //    var labelBounds = e.Bounds;
        //    labelBounds.Width = (int)(e.Graphics.MeasureString(label, labelFont).Width + 0.5);
        //    var valueBounds = e.Bounds;
        //    valueBounds.X = labelBounds.Right + 2;
        //    valueBounds.Width -= labelBounds.Width + 2;

        //    TextRenderer.DrawText(e.Graphics, label, labelFont, labelBounds, e.ForeColor, e.BackColor,
        //        TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
        //    TextRenderer.DrawText(e.Graphics, e.SubItem.Value?.ToString() ?? string.Empty, valueFont, valueBounds, e.ForeColor,
        //        e.BackColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
        //}

        
    }
}


