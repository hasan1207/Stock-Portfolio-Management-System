using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp24thdec;

namespace Services
{
    public class CrossoverDataGaugePainter : DataGaugePainter
    {
        protected override Color GetBorderColor()
        {
            return (levels[0] <= levels[1]) ? Color.DarkRed : Color.DarkGreen;
        }

        

        protected override Color GetBrushColor()
        {
            return (levels[0] <= levels[1]) ? UIColor.LightRed : Color.LightGreen;
        }


    }
}
