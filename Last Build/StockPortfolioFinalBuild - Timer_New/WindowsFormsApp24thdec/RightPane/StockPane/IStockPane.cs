using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WindowsFormsApp24thdec.Models.MasterDataSet;

namespace WindowsFormsApp24thdec.RightPane.StockPane
{
    public interface IStockPane
    {
        void DisableImportButton();

        void EnableImportButton();
        void LoadGridView(DataTable table);

        void BindPropertyGrid(StockDetails sd);

        void ClearSearch();

        void FetchTime(string num);
    }
}
