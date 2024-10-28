using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp24thdec;

namespace Services
{
    public class FiftyTwoWeekDataGaugePainter : DataGaugePainter
    {
        protected override Color GetBorderColor()
        {
            return Color.Black;
        }



        protected override Color GetBrushColor()
        {
            return UIColor.DarkestColor;
        }
    }
}
