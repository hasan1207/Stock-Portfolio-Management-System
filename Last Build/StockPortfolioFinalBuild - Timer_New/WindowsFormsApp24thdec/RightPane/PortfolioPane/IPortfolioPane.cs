using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp24thdec.RightPane.PortfolioPane
{
    public interface IPortfolioPane
    {

        void LoadGridView(DataTable table,DataTable total);

        void ClearSearch();


        void EnableImportButton();
        void DisableImportButton();
    }
}
