using CsvHelper;
using CsvHelper.Configuration;
using IfcToolbox.Core.Utilities;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace IfcToolbox.Tools.Helper
{
    public static class CsvExtensions
    {
        public static DataTable ToDataTable<T>(this IEnumerable<T> elements)
        {
            DataTable table = new DataTable();
            if(!elements.Any())
                return table;
            var props = ReflectionUtility.DictionaryFromType(elements.First());
            foreach (var propName in props.Keys)
                table.Columns.Add(new DataColumn(propName));
            foreach (var element in elements)
            {
                DataRow row = table.NewRow();
                var valueDic = ReflectionUtility.DictionaryFromType(element);
                row.ItemArray = valueDic.Values.ToArray();
                table.Rows.Add(row);
            }
            Marslogger.Action($"DataTable created with {table.Rows.Count} lines of content.", "DataTable Generation");
            return table;
        }

        public static void SaveAsCsv(this DataTable table, string finalFile, string delimiter = ",")
        {
            StringWriter csvString = new StringWriter();
            CsvConfiguration config = new CsvConfiguration(CultureInfo.CurrentCulture);
            config.Delimiter = delimiter;
            using (var csv = new CsvWriter(csvString, CultureInfo.CurrentCulture))
            {
                foreach (DataColumn column in table.Columns)
                    csv.WriteField(column.ColumnName);
                csv.NextRecord();
                foreach (DataRow row in table.Rows)
                {
                    for (var i = 0; i < table.Columns.Count; i++)
                        csv.WriteField(row[i]);
                    csv.NextRecord();
                }
            }
            File.WriteAllText(finalFile, csvString.ToString(), Encoding.UTF8);
            Marslogger.Action("Generate csv file completed.", Path.GetFileName(finalFile));
        }
    }
}
