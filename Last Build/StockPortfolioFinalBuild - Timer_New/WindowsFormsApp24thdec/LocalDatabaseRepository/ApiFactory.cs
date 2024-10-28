using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YahooFinanceRepository;

namespace LocalDatabaseRepository
{
    public static class ApiFactory
    {
        private static IStockApi apiAccess;
        public static IStockApi GetApiAccess()
        {

            if (apiAccess == null)
            {
                apiAccess = new YahooStockApi();
            }

            return apiAccess;
        }
    }
}
