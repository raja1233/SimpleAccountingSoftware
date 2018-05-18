using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace SDN.Common
{
   public class DataGridTableCollection
    {
        public static DataTable GridLines(int colCount, int rowCount)
        {
            DataTable table = new DataTable();
            DataColumn col;
            DataRow row;
            for (int i = 0; i < colCount; i++)
            {
                col = new DataColumn();
                col.ColumnName = "Col" + i.ToString();
                table.Columns.Add(col);


            }
            if (colCount > 0 && rowCount > 0)
            {
                for (int i = 0; i < rowCount; i++)
                {
                    row = table.NewRow();
                    for (int j = 0; j < colCount; j++)
                    {
                        row[j] = "";
                    }
                    table.Rows.Add(row);
                }
            }
            //List<DataTable> lst = new List<DataTable>();
            //lst.Add(table);
            return table;
        }
        public static DataTable GridLinesForm(int colCount, int rowCount)
        {
            DataTable table = new DataTable();
            DataColumn col;
            DataRow row;
            for (int i = 0; i < colCount; i++)
            {
                col = new DataColumn();
                col.ColumnName = "Col" + i.ToString();
                table.Columns.Add(col);


            }
            if (colCount > 0 && rowCount > 0)
            {
                for (int i = 0; i < rowCount; i++)
                {
                    row = table.NewRow();
                    for (int j = 0; j < colCount; j++)
                    {
                        row[j] = "";
                    }
                    row[0] = (i+1).ToString();
                    table.Rows.Add(row);
                }
            }
            //List<DataTable> lst = new List<DataTable>();
            //lst.Add(table);
            return table;
        }

    }
}
