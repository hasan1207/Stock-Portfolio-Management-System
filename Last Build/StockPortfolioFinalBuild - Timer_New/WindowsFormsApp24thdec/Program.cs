using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LocalDatabaseRepository;
using Services;

namespace WindowsFormsApp24thdec
{


    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //create singletons
            object obj1 = DatabaseFactory.GetDataAccess();

            object obj2 = StockDataCacheServices.Instance;
            object obj3 = StockHistoryServices.Instance;

            object obj4 = PortfolioServices.Instance;
            object obj5 = StockStudyServices.Instance;
            object obj6 = HistoricalServices.Instance;
            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }


    public static class UIColor
    {
        public static Color EvenDarkerColor = Color.FromArgb(255, 150, 150, 150);
        public static Color DarkestColor = Color.FromArgb(255, 218, 217, 219);
        public static Color DarkerColor = Color.FromArgb(255, 228, 227, 229);
        public static Color DarkColor = Color.FromArgb(255, 233, 232, 234);
        public static Color LightColor = Color.FromArgb(255, 246, 246, 248);

        public static Color LightRed = Color.FromArgb(255, 238, 144, 144);
    }
}
