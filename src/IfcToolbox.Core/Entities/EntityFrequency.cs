using Xbim.Common.Metadata;

namespace IfcToolbox.Core.Entities
{
    public class EntityFrequency : IEntityFrequency
    {
        public string EntityName { get; set; } = null;
        public int Occurences { get; set; } = 0;
        public ExpressType ExpressType { get; set; }
    }
}
