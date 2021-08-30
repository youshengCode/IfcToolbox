using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Metadata;

namespace IfcToolbox.Core.Entities
{
    public interface IEntityProxy
    {
        IPersistEntity Entity { get; set; }
        ExpressType ExpressType { get; set; }
        IList<object> Properties { get; set; }
        IList<string> PropertyNames { get; set; }

        bool Equals(EntityProxy other);
        bool Equals(object obj);
        int GetHashCode();
    }
}