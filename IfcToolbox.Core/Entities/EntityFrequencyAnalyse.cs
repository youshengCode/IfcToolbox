using Serilog;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;

namespace IfcToolbox.Core.Entities
{
    public class EntityFrequencyAnalyse
    {
        public HashSet<IEntityFrequency> EntityFrequencies { get; set; } = new HashSet<IEntityFrequency>();
        private HashSet<string> EntityNames { get; set; } = new HashSet<string>();

        public void AddOccurences(IEnumerable<IPersistEntity> entities)
        {
            foreach (var entity in entities)
            {
                var entityName = entity.ExpressType.Type.Name;
                // Use entityNames for avoid the Linq.Any perf effect.
                if (EntityNames.Contains(entityName))
                    EntityFrequencies.First(x => x.EntityName == entityName).Occurences++;
                else
                {
                    EntityNames.Add(entityName);
                    EntityFrequencies.Add(new EntityFrequency { EntityName = entityName, ExpressType = entity.ExpressType, Occurences = 1 });
                }
            }
        }

        public void Sort(bool isDescending = true)
        {
            if (isDescending)
                EntityFrequencies = new HashSet<IEntityFrequency>(EntityFrequencies.ToList().OrderByDescending(x => x.Occurences));
            else
                EntityFrequencies = new HashSet<IEntityFrequency>(EntityFrequencies.ToList().OrderBy(x => x.Occurences));
        }

        public void IgnoreLessThan(int min)
        {
            EntityFrequencies = new HashSet<IEntityFrequency>(EntityFrequencies.Where(x => x.Occurences >= min).ToList());
        }

        public void LogDetails(bool logFrequency = false, bool logProps = false, bool logTypes = false)
        {
            foreach (var frequency in EntityFrequencies)
            {
                if (logFrequency)
                {
                    Log.Information("{@name} : {@occurences}", frequency.EntityName, frequency.Occurences);
                    if (logProps)
                    {
                        foreach (var subType in frequency.ExpressType.NonAbstractSubTypes)
                            Log.Information($"Sub -->  {subType.Name}");
                        if (frequency.ExpressType.SuperType != null)
                            Log.Information($"Super -->  {frequency.ExpressType.SuperType.Name}");
                    }
                    if (logTypes)
                        if (frequency.ExpressType.Properties != null)
                            foreach (var property in frequency.ExpressType.Properties)
                                Log.Information($"Properties -->  {property.Value.Name}");
                }
            }
            int sum = 0;
            foreach (var item in EntityFrequencies)
                sum += item.Occurences;
            Log.Information("Total entity {@sum} found in {@count} types.", sum, EntityFrequencies.Count);
        }
    }
}
