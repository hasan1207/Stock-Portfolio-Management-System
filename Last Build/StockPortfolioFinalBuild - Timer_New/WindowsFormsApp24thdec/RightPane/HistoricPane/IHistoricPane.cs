using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp24thdec.RightPane.HistoricPane
{
    public interface IHistoricPane
    {
        void SetUpdateProgress(int progress, string message);

        void ShowProgressBar();

        void HideProgressBar();

        void LoadStockGridView(DataTable table);

        void LoadOhlcGrid(DataTable table);

        void ClearSearch();
    }
}
