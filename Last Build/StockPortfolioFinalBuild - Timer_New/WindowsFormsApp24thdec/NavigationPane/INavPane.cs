using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp24thdec.NavigationPane
{
    public interface INavPane
    {
        void SetUpdateProgress(int progress, string message);

        void HideProgressBar();

        void ShowProgressBar();
    }
}
