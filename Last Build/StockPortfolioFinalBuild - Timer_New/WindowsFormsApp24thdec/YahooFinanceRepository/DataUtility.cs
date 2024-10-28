using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using YahooFinanceRepository;

namespace YahooFinanceRepository
{
    public static class DataUtility
    {
        
        public static DataTable CreateDataTable(string[] colNames, object[] arr)
        {
            DataTable dt = new DataTable();

            

            int columns = arr.Length, rows = 0, num;
            IEnumerable en;
            IEnumerator it;
            foreach (object row in arr)
            {
                num = 0;
                en = (IEnumerable)row;
                it = en.GetEnumerator();
                while (it.MoveNext())
                    num++;
                if (num > rows)
                    rows = num;
            }



            for (int i = 0; i < columns; i++)
            {
                en = (IEnumerable)arr[i];
                it = en.GetEnumerator();
                it.MoveNext();
                Type type = Type.GetType(it.Current.GetType().ToString());
                dt.Columns.Add(colNames[i], type);
            }

            for (int i = 0; i < rows; i++)
            {
                DataRow row = dt.NewRow();
                for (int j = 0; j < columns; j++)
                {
                    en = (IEnumerable)arr[j];
                    it = en.GetEnumerator();
                    for (int k = 0; k <= i; k++)
                        it.MoveNext();
                    row[j] = it.Current == null ? DBNull.Value : it.Current;
                }
                dt.Rows.Add(row);
            }


            return dt;
        }


        

    }
}
