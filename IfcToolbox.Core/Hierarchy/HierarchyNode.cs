using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace IfcToolbox.Core.Hierarchy
{
    public class HierarchyNode
    {
        public HierarchyNode() { }

        public HierarchyNode(string name, string id, string description = null, bool isComposition = false, bool isTypeGroup = false)
        {
            Name = name;
            Id = id;
            Description = description;
            IsComposition = isComposition;
            IsTypeGroup = isTypeGroup;
        }

        public HierarchyNode(string name, bool isComposition = false)
        {
            Name = name;
            IsComposition = isComposition;
        }

        public string Name { get; set; }
        public string Id { get; set; }
        public string Description { get; set; } = null;
        public bool IsComposition { get; set; }
        public bool IsTypeGroup { get; set; } = false;
        public object Value { get; set; }
        public ObservableCollection<HierarchyNode> Children { get; set; } = new ObservableCollection<HierarchyNode>();

        public string ParentId { get; set; } // For the root node, the parentId is null.
        public void AddParentId(string parentId)
        {
            ParentId = parentId;
        }

        public string Show(bool showParentId = false, int level = 0)
        {
            var sb = new StringBuilder();
            if (level == 0)
                sb.Append("\n");
            string compositionText = null;
            if (IsComposition)
                compositionText += "<< Compo";
            if (showParentId)
                compositionText += " _↑ " + ParentId;

            if (Description != null)
                sb.Append($"{GetIndent(level)}#{Id} = [{Description}] \"{Name}\" {compositionText}").Append("\n");
            else
                sb.Append($"{GetIndent(level)}#{Id} = \"{Name}\" {compositionText}").Append("\n");

            if (Children.Any())
                foreach (var child in Children)
                    sb.Append($"{child.Show(showParentId, level + 1)}");
            return sb.ToString();

            static string GetIndent(int level)
            {
                var indent = "";
                for (int i = 0; i < level; i++)
                    indent += "|  ";
                return indent;
            }
        }
    }
}
