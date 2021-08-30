using System.Collections.Generic;
using Xbim.Common;

namespace IfcToolbox.Core.Entities
{
    public interface IEntityReferences
    {
        IPersistEntity Instance { get; set; }
        HashSet<IPersistEntity> References { get; set; }

        void MergeReferences(IEnumerable<IPersistEntity> others);
    }
}
