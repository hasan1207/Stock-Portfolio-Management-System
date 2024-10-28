using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TL;

namespace Services
{
    public enum LoggerFlags
    {
        Information,
        Warning,
        Error
    }

    public sealed class Logger
    {
        private static Logger instance = null;
        private string fileDirectory;
        private FileStream fs;
        private StreamWriter sw;

        public static Logger Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Logger();
                }
                return instance;
            }
        }

        public Logger()
        {
            //try
            //{
            //    this.fileDirectory = "C:\\Users\\HasanH\\source\\repos\\WindowsFormsApp24thdecWithActiveList\\";
            //    this.fs = new FileStream(this.fileDirectory + "logger.log", FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            //    this.sw = new StreamWriter(this.fs);
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            
        }

        ~Logger()
        {
            //this.sw.WriteLine("Logger Closed");
            //this.sw.Flush();

            //this.sw.Close();
            //this.fs.Close();
        }

        public void WriteToLogFile(LoggerFlags flag, string message)
        {
            ////this.fileDirectory = "C:\\Users\\HasanH\\source\\repos\\WindowsFormsApp24thdecWithLogger\\";
            ////this.fs = new FileStream(this.fileDirectory + "logger.log", FileMode.Append, FileAccess.Write, FileShare.Read);
            ////this.sw = new StreamWriter(this.fs);

            //this.sw.WriteLine(DateTime.Now.ToString("yyyy'-'MM'-'dd HH:mm:ss") + ", " + flag.ToString() + ", " + message);
            //this.sw.Flush();

            ////this.sw.Close();
            ////this.fs.Close();
        }
    }
}
