using System.Collections.Generic;
using System.Linq;

namespace IfcToolbox.Core.Hierarchy
{
    /// <summary>
    /// Arborescences 
    /// Used for splitter UI load
    /// </summary>
    public class SpatialTrees
    {
        public List<HierarchyNode> FullNodes { get; set; } = new List<HierarchyNode>();
        public List<HierarchyNode> TypedNodes { get; set; } = new List<HierarchyNode>();
        public List<HierarchyNode> SiteNodes { get; set; } = new List<HierarchyNode>();
        public List<HierarchyNode> BuildingNodes { get; set; } = new List<HierarchyNode>();
        public List<HierarchyNode> LevelNodes { get; set; } = new List<HierarchyNode>();

    }

    public static class SpatialTreesExtention
    {
        public static SpatialTrees MergeTypeNodes(this IEnumerable<SpatialTrees> trees)
        {
            if (!trees.Any())
                return null;
            var self = trees.FirstOrDefault();
            for (int i = 1; i < trees.Count(); i++)
                self = self.MergeTypeNodes(trees.ToList()[i]);
            return self;
        }

        public static SpatialTrees MergeTypeNodes(this SpatialTrees self, IEnumerable<SpatialTrees> others)
        {
            foreach (var other in others)
                self = self.MergeTypeNodes(other);
            return self;
        }

        public static SpatialTrees MergeTypeNodes(this SpatialTrees self, SpatialTrees other)
        {
            if (other.TypedNodes.Any())
                foreach (var typedNode in other.TypedNodes)
                    if (!self.TypedNodes.Where(x => x.Name == typedNode.Name).Any())
                        self.TypedNodes.Add(typedNode);
            return self;
        }
    }

}
