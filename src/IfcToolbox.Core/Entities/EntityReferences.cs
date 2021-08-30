using System.Collections.Generic;
using Xbim.Common;

namespace IfcToolbox.Core.Entities
{
    public class EntityReferences: IEntityReferences
    {
        public IPersistEntity Instance { get; set; }
        public HashSet<IPersistEntity> References { get; set; }

        public void MergeReferences(IEnumerable<IPersistEntity> others)
        {
            References.UnionWith(others);
        }
    }
}
