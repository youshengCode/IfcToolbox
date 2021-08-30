using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Ifc4.Interfaces;

namespace IfcToolbox.Core.Hierarchy
{
    public class HierarchyReader
    {
        /// <summary>
        /// GetFullHierarchy
        /// </summary>
        public static HierarchyNode GetFullHierarchy(IModel model, bool organiseProductByType = true, bool ifcSpaceAsType = true)
        {
            return GetFullHierarchy(model.Instances.FirstOrDefault<IIfcProject>(), organiseProductByType, ifcSpaceAsType);
        }
        private static HierarchyNode GetFullHierarchy(IIfcObjectDefinition objectDef, bool organiseProductByType = true, bool ifcSpaceAsType = true)
        {
            if (objectDef == null)
                return null;
            var node = new HierarchyNode(GetProductName(objectDef), objectDef.EntityLabel.ToString(), objectDef.GetType().Name, true);
            //only spatial elements can contain building elements
            var spatialElement = objectDef as IIfcSpatialStructureElement;
            if (spatialElement != null)
            {
                //using IfcRelContainedInSpatialElement to get contained elements
                var containedElements = spatialElement.ContainsElements.SelectMany(rel => rel.RelatedElements).ToList();
                if (ifcSpaceAsType)
                    containedElements.AddRange(GetIfcProductsInIfcSpace(objectDef));

                if (organiseProductByType)
                {
                    var groups = containedElements.GroupBy(x => x.ExpressType.Name);
                    foreach (var group in groups)
                    {
                        var typeNode = new HierarchyNode(group.Key, group.Key + spatialElement.EntityLabel.ToString(), GetEntityCountText(group), true, organiseProductByType);
                        foreach (var product in group.ToList())
                        {
                            var childNode = new HierarchyNode(GetProductName(product), product.EntityLabel.ToString(), product.GetType().Name);
                            childNode.AddParentId(typeNode.Id);
                            typeNode.Children.Add(childNode);
                        }
                        typeNode.AddParentId(node.Id);
                        node.Children.Add(typeNode);
                    }
                }
                else
                {
                    foreach (var element in containedElements)
                    {
                        var childNode = new HierarchyNode(GetProductName(element), element.EntityLabel.ToString(), element.GetType().Name);
                        childNode.AddParentId(node.Id);
                        node.Children.Add(childNode);
                    }
                }
            }
            //using IfcRelAggregares to get spatial decomposition of spatial structure elements
            foreach (var item in objectDef.IsDecomposedBy.SelectMany(r => r.RelatedObjects))
            {
                if (ifcSpaceAsType)
                    if (item is IIfcSpace)
                        continue;

                var nextLevelNode = GetFullHierarchy(item, organiseProductByType, ifcSpaceAsType);
                if (nextLevelNode != null)
                {
                    nextLevelNode.AddParentId(node.Id);
                    node.Children.Add(nextLevelNode);
                }
            }
            return node;
        }

        /// <summary>
        /// GetTypedHierarchy
        /// </summary>
        public static HierarchyNode GetTypedHierarchy(IModel model, bool includeIfcSpace = false)
        {
            var project = model.Instances.FirstOrDefault<IIfcProject>();
            var projectNode = new HierarchyNode(project.ExpressType.Name, project.ExpressType.Name, null, true);
            var products = model.Instances.OfType<IIfcProduct>().Where(x => !(x is IIfcSpatialStructureElement));
            var groups = products.GroupBy(x => x.ExpressType.Name);
            foreach (var group in groups)
            {
                if (!group.ToList().Any())
                    continue;
                var node = new HierarchyNode(group.Key, group.Key, GetEntityCountText(group), true, true);
                var subGroups = group.ToList()
                    .Where(x => x.ObjectType != null)
                    .GroupBy(x => x.ObjectType.Value);
                if (!subGroups.Any())
                    continue;
                foreach (var subGroup in subGroups)
                {
                    var subNode = new HierarchyNode(subGroup.Key, subGroup.Key, GetEntityCountText(subGroup));
                    subNode.AddParentId(node.Id);
                    node.Children.Add(subNode);
                }
                node.AddParentId(projectNode.Id);
                projectNode.Children.Add(node);
            }
            if (includeIfcSpace)
            {
                var ifcSpaces = model.Instances.OfType<IIfcSpace>();
                if (ifcSpaces.Any())
                {
                    var firstSpace = ifcSpaces.First();
                    var node = new HierarchyNode(firstSpace.ExpressType.Name, firstSpace.ExpressType.Name, GetEntityCountText(ifcSpaces), true, true);
                    foreach (var ifcSpace in ifcSpaces)
                    {
                        var subNode = new HierarchyNode(ifcSpace.LongName, ifcSpace.LongName);
                        subNode.AddParentId(node.Id);
                        node.Children.Add(subNode);
                    }
                    node.AddParentId(projectNode.Id);
                    projectNode.Children.Add(node);
                }
            }
            return projectNode;
        }

        /// <summary>
        /// GetSpatialHierarchy
        /// </summary>
        public static HierarchyNode GetSpatialHierarchy(IModel model, string terminalEntityLabel = null)
        {
            return GetSpatialHierarchy(model.Instances.FirstOrDefault<IIfcProject>(), terminalEntityLabel);
        }
        private static HierarchyNode GetSpatialHierarchy(IIfcObjectDefinition objectDef, string terminalEntityLabel = null)
        {
            if (objectDef == null)
                return null;
            var isComposition = terminalEntityLabel != objectDef.ExpressType.ExpressName;
            var node = new HierarchyNode(GetProductName(objectDef), objectDef.EntityLabel.ToString(), objectDef.GetType().Name, isComposition);

            if (terminalEntityLabel != objectDef.ExpressType.ExpressName)
            {
                foreach (var item in objectDef.IsDecomposedBy.SelectMany(r => r.RelatedObjects))
                {
                    var nextLevelNode = GetSpatialHierarchy(item, terminalEntityLabel);
                    if (nextLevelNode != null)
                    {
                        nextLevelNode.AddParentId(node.Id);
                        node.Children.Add(nextLevelNode);
                    }
                }
            }
            return node;
        }

        private static string GetEntityCountText<T>(IEnumerable<T> enumerable)
        {
            string countText = enumerable.Count() > 1 ? $"{enumerable.Count()} entities" : $"{enumerable.Count()} entity";
            return countText;
        }
        private static string GetProductName(IIfcRoot product)
        {
            var name = product.Name;
            if (string.IsNullOrEmpty(name))
            {
                name = product.ExpressType.Name.Replace("Ifc", "");
            }
            return name;
        }
        private static List<IIfcProduct> GetIfcProductsInIfcSpace(IIfcObjectDefinition objectDef)
        {
            List<IIfcProduct> collection = new List<IIfcProduct>();
            foreach (var item in objectDef.IsDecomposedBy.SelectMany(r => r.RelatedObjects))
            {
                if (item is IIfcSpace spaceElement)
                    if (spaceElement != null)
                    {
                        var containedElements = spaceElement.ContainsElements.SelectMany(rel => rel.RelatedElements);
                        collection.AddRange(containedElements);
                    }
            }
            return collection;
        }
    }

}
