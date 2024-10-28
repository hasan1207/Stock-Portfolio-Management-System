using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalDatabaseRepository
{
    public static class DatabaseFactory
    {
        private static IDataAccess dataAccess;
        public static IDataAccess GetDataAccess()
        {
            
            if(dataAccess == null)
            {
                dataAccess = new SqlDataAccess();
            }
            
            return dataAccess;
        }
    }
}
