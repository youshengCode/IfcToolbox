using System.Collections.Generic;
using System.Linq;
using Xbim.Common;

namespace IfcToolbox.Core.Merge
{
    /// <summary>
    /// Merge strategy RE - Reverse Entities
    /// </summary>
    public class MergeStrategyRE : EntityMergeStrategy, IEntitiyMergeStrategy
    {
        public void Merge(IModel model, bool logDetail)
        {
            var entities = model.Instances.OfType<IPersistEntity>();
            MergeRecrusive(model, entities, logDetail);
        }

        private void MergeRecrusive(IModel model, IEnumerable<IPersistEntity> entities, bool logDetail, bool fromTerminal = true)
        {
            var relatedEntities = MergeEntities(model, entities, logDetail, fromTerminal);
            if (relatedEntities.Any())
                MergeRecrusive(model, relatedEntities, logDetail, false);
        }
    }
}
