using IfcToolbox.Core.Extensions;
using System.Linq;
using Xbim.Common;

namespace IfcToolbox.Core.Merge
{
    /// <summary>
    /// Merge strategy OR - Only Resources Layer
    /// </summary>
    public class MergeStrategyOR : EntityMergeStrategy, IEntitiyMergeStrategy
    {
        public void Merge(IModel model, bool logDetail)
        {
            var filtedEntities = model.Instances.OfType<IPersistEntity>().Where(x => !x.HasReference());
            var filtedTypes = filtedEntities.GroupBy(x => x.ExpressType);
            foreach (var filtedType in filtedTypes)
                MergeGlobalType(model, filtedType.ToList(), logDetail);
        }
    }
}
