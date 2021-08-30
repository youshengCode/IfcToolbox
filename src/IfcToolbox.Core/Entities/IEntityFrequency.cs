using Xbim.Common.Metadata;

namespace IfcToolbox.Core.Entities
{
    public interface IEntityFrequency
    {
        string EntityName { get; set; }
        ExpressType ExpressType { get; set; }
        int Occurences { get; set; }
    }
}
