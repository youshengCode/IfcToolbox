using System;
using System.Data;

namespace IfcToolbox.Core.Validate
{
    public class PropertyExistenceCount
    {
        public static int GetEntitiesCount(DataTable dataTable)
        {
            return dataTable.Rows.Count;
        }

        public static int GetPropertiesCount(DataTable dataTable)
        {
            return dataTable.Columns.Count - 2;
        }

        public static double GetExistencePercentage(DataTable dataTable)
        {
            int emptyCount = 0;
            foreach (DataRow row in dataTable.Rows)
                foreach (var item in row.ItemArray)
                    if (item.ToString() == string.Empty)
                        emptyCount++;
            var emptyPercentage = (double)emptyCount / (dataTable.Rows.Count * (dataTable.Columns.Count - 2));
            return Math.Round((1 - emptyPercentage) * 100, 2);
        }
    }
}
