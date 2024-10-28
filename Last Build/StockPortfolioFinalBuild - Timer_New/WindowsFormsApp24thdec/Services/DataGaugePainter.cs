using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public abstract class DataGaugePainter
    {
        protected float[] levels;
        protected float value;
        protected string[] levelLabels;
        protected Color borderColor;
        protected Color brushColor;
        private int count = 0;
        //private Logger logger;

        
        public DataGaugePainter()
        {
            //this.logger = Logger.Instance;
        }

        protected abstract Color GetBorderColor();
        protected abstract Color GetBrushColor();
        public void SetLevels(float[] arr)
        {
            this.levels = arr;

        }

        public void SetValue(float val)
        {
            this.value = val;
        }

        public void SetLevelLabels(string[] arr)
        {
            levelLabels = arr;
        }

        public void Paint(System.Drawing.Graphics g, Rectangle bounds)
        {
            Color penColor = this.GetBorderColor();
            Color brushColor = this.GetBrushColor();

            Dictionary<string, float> dict = new Dictionary<string, float>();
            for(int i = 0; i < levels.Length; i++)
            {
                dict.Add(levelLabels[i], levels[i]);
            }
            dict.Add("T", value);

            var sortedDict = from entry in dict orderby entry.Value ascending select entry;

            dict = sortedDict.ToDictionary(pair => pair.Key, pair => pair.Value);

            string[] arr = new string[levelLabels.Length + 1];
            int j = 0;
            foreach (KeyValuePair<string, float> entry in dict)
            {
                // do something with entry.Value or entry.Key
                arr[j++] = entry.Key;
            }
            Rectangle rect = new Rectangle(bounds.X + 10, bounds.Y + (bounds.Height / 2) - 3, bounds.Width - 22, 6);
            using (SolidBrush rectBrush = new SolidBrush(brushColor))
            {
                g.FillRectangle(rectBrush, rect);

            }

            Brush rectBorderBrush = new SolidBrush(penColor);
            Pen rectLinePen = new Pen(rectBorderBrush);
            g.DrawRectangle(rectLinePen, rect);

            int[] labelXPositions = new int[dict.Count];
            labelXPositions[0] = rect.X;
            labelXPositions[dict.Count - 1] = rect.X + rect.Width;

            float percentage;
            for(int i = 1; i < dict.Count - 1; i++)
            {
                percentage = ((dict.ElementAt(i).Value - dict.ElementAt(0).Value) / (dict.ElementAt(dict.Count - 1).Value - dict.ElementAt(0).Value));
                Point start = new Point(rect.Location.X + (int)(percentage * rect.Width), rect.Location.Y);
                Point end = new Point(rect.Location.X + (int)(percentage * rect.Width), rect.Location.Y + rect.Height);
                g.DrawLine(rectLinePen, start, end);
                labelXPositions[i] = start.X;
            }
            rectBorderBrush.Dispose();
            rectLinePen.Dispose();


            

            Pen linePen = new Pen(Color.Black);
            Font font = new Font(SystemFonts.DefaultFont.FontFamily, 6, FontStyle.Regular);
            for (int i = 0; i < labelXPositions.Length; i++)
            {
                SizeF labelSize = new SizeF();
                labelSize = g.MeasureString(dict.ElementAt(i).Key, font);
                int yStart = i % 2 == 0 ? rect.Y + rect.Height + 3 : rect.Y - (int)labelSize.Height;
                if (dict.ElementAt(i).Key == "T")
                {
                    yStart++;
                    g.DrawLine(linePen, new Point(labelXPositions[i], yStart), new Point(labelXPositions[i] - 3, yStart + 3));
                    g.DrawLine(linePen, new Point(labelXPositions[i], yStart), new Point(labelXPositions[i] + 3, yStart + 3));
                    g.DrawLine(linePen, new Point(labelXPositions[i] - 3, yStart + 3), new Point(labelXPositions[i], yStart + 6));
                    g.DrawLine(linePen, new Point(labelXPositions[i] + 3, yStart + 3), new Point(labelXPositions[i], yStart + 6));

                }
                else
                {

                    g.DrawString((String)dict.ElementAt(i).Key, font, Brushes.Black,labelXPositions[i] - (labelSize.Width / 2) + 1, yStart);
                }
            }
            linePen.Dispose();

            Logger.Instance.WriteToLogFile(LoggerFlags.Information, "Cell" + ++count + " has been painted");
        }


    }
}
