using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooFinanceRepository
{
    public interface IStockApi
    {
        void SetStockData(string stockId, string interval, string range);
        void SetSummaryData(string stockId);

        void SetResponseData(string stockId);

        StockData GetStockData();
        SummaryData GetSummaryData();

        ResponseData GetResponseData();

    }

}
