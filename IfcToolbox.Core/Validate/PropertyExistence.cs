using IfcToolbox.Core.Hierarchy;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using Xbim.Ifc;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace IfcToolbox.Core.Validate
{
    public class PropertyExistence
    {
        public static IList<DataTable> AnalyseProperties(IfcStore model, IList<HierarchyNode> nodes,
            string demiliter = ".", string existPlaceholder = "Exist",
            string columnId = "Global ID", string columnName = "Name")
        {
            IList<DataTable> dataTables = new List<DataTable>();
            var ifcProducts = model.Instances.OfType<IfcProduct>();
            var productGroups = ifcProducts.GroupBy(x => x.ObjectType).Select(x => x.ToList());

            foreach (var classNode in nodes)
            {
                var classTable = InitDataTable(classNode, demiliter, columnId, columnName);
                classTable.TableName = classNode.Name;
                foreach (var productGroup in productGroups)
                {
                    string entityName = GetEntityNameFromType(productGroup.FirstOrDefault().GetType().ToString());
                    if (classNode.Name == entityName)
                        foreach (var ifcProduct in productGroup)
                            CountExistInPsetAndQto(ifcProduct, classTable, existPlaceholder, columnId, columnName);
                }
                dataTables.Add(classTable);
            }

            return dataTables;

            string GetEntityNameFromType(string str)
            {
                Regex regex = new Regex(@"(?=.)\w+$");
                return regex.Match(str).Value;
            }
        }

        private static DataTable InitDataTable(HierarchyNode classNode, string demiliter = ".",
            string columnId = "Global ID", string columnName = "Name")
        {
            var classTable = ConvertToDataTable(classNode, demiliter);
            var colID = new DataColumn(columnId, typeof(string));
            classTable.Columns.Add(colID);
            colID.SetOrdinal(0);
            var colName = new DataColumn(columnName, typeof(string));
            classTable.Columns.Add(colName);
            colName.SetOrdinal(0);
            return classTable;
        }
        private static void CountExistInPsetAndQto(IfcProduct ifcProduct, DataTable dataTable, string existPlaceholder = "Exist",
            string columnId = "Global ID", string columnName = "Name")
        {
            var ifcPropertySets = ifcProduct.IsDefinedBy
                .Where(r => r.RelatingPropertyDefinition is IIfcPropertySet)
                .Select(r => ((IIfcPropertySet)r.RelatingPropertyDefinition));

            var ifcElementQuantities = ifcProduct.IsDefinedBy
                .Where(r => r.RelatingPropertyDefinition is IIfcElementQuantity)
                .Select(r => ((IIfcElementQuantity)r.RelatingPropertyDefinition));

            var row = dataTable.NewRow();

            foreach (var ifcPropertySet in ifcPropertySets)
            {
                List<IIfcProperty> ifcProperties = new List<IIfcProperty>();
                // Remove duplication
                foreach (var ifcProperty in ifcPropertySet.HasProperties)
                    if (!ifcProperties.Any(p => p.Name == ifcProperty.Name))
                        ifcProperties.Add(ifcProperty);

                foreach (var ifcProperty in ifcProperties)
                    foreach (DataColumn column in dataTable.Columns)
                        if (column.ColumnName == ifcPropertySet.Name + "." + ifcProperty.Name)
                            row[column.ColumnName] = existPlaceholder;
            }
            foreach (var ifcElementQuantity in ifcElementQuantities)
            {
                List<IIfcPhysicalQuantity> ifcQuantities = new List<IIfcPhysicalQuantity>();
                // Remove duplication
                foreach (var ifcQuantity in ifcElementQuantity.Quantities)
                    if (!ifcQuantities.Any(p => p.Name == ifcQuantity.Name))
                        ifcQuantities.Add(ifcQuantity);

                foreach (var ifcQuantity in ifcQuantities)
                    foreach (DataColumn column in dataTable.Columns)
                        if (column.ColumnName == ifcElementQuantity.Name + "." + ifcQuantity.Name)
                            row[column.ColumnName] = existPlaceholder;
            }

            row[columnId] = ifcProduct.GlobalId;
            row[columnName] = ifcProduct.Name;
            dataTable.Rows.Add(row);
        }

        private static DataTable ConvertToDataTable(HierarchyNode node, string demiliter = ".")
        {
            var dataTable = new DataTable();
            IList<HierarchyNode> propCollection = RestructureNodeWithPsetAndPropName(node, demiliter);
            foreach (var prop in propCollection)
            {
                var dataColumn = new DataColumn(prop.Name, typeof(string));
                dataTable.Columns.Add(dataColumn);
            }
            return dataTable;
        }
        private static List<HierarchyNode> RestructureNodeWithPsetAndPropName(HierarchyNode node, string demiliter = ".", HierarchyNode parentNode = null)
        {
            List<HierarchyNode> result = new List<HierarchyNode>();
            if (node.IsComposition)
            {
                foreach (var child in node.Children)
                    result.AddRange(RestructureNodeWithPsetAndPropName(child, demiliter, node));
            }
            else
            {
                if (parentNode != null)
                {
                    node.Name = parentNode.Name + demiliter + node.Name;
                    result.Add(node);
                }
            }
            return result;
        }
    }
}
