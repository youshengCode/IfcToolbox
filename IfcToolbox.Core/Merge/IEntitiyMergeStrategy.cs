using Xbim.Common;

namespace IfcToolbox.Core.Merge
{
    public interface IEntitiyMergeStrategy
    {
        void Merge(IModel model, bool logDetail);
    }
}
