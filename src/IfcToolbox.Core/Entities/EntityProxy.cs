using IfcToolbox.Core.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Metadata;

namespace IfcToolbox.Core.Entities
{
    public sealed class EntityProxy : IEquatable<EntityProxy>, IEntityProxy
    {
        //Proxy class for entity props fast compare
        public EntityProxy(IPersistEntity entity)
        {
            LoadFullProps(entity);
        }

        public ExpressType ExpressType { get; set; }
        public IList<object> Properties { get; set; }
        public IList<string> PropertyNames { get; set; }
        public IPersistEntity Entity { get; set; }

        public bool Equals(EntityProxy other)
        {
            if (other == null) return false;
            if (this.ExpressType != other.ExpressType)
                return false;
            if (this.PropertyNames.Count != other.PropertyNames.Count)
                return false;
            if (this.ExpressType.ExpressNameUpper == "IFCSIUNIT")
                return false;
            for (int i = 0; i < this.PropertyNames.Count; i++)
                if (this.PropertyNames[i] != other.PropertyNames[i])
                    return false;
            for (int i = 0; i < this.Properties.Count; i++)
            {
                if (this.Properties[i] == null && other.Properties[i] == null)
                    continue;
                if (this.Properties[i] == null || other.Properties[i] == null)
                    return false;
                if (!this.Properties[i].Equals(other.Properties[i]))
                    return false;
            }
            return true;
        }
        public override bool Equals(object obj)
        {
            return (obj is EntityProxy) && this.Equals(obj as EntityProxy);
        }
        public override int GetHashCode()
        {
            //return HashCodeGenerator.AdditionHashCode<object>(Properties);
            return HashCodeGenerator.OrderIndependentHashCode<object>(Properties);
        }

        private void LoadFullProps(IPersistEntity entity)
        {
            Entity = entity;
            ExpressType = entity.ExpressType;
            Properties = new List<object>();
            PropertyNames = new List<string>();

            var pInfos = ExpressType.Properties.Values.Where(p => p.EntityAttribute != null && p.EntityAttribute.Order > 0).Select(p => p.PropertyInfo);
            foreach (var pInfo in pInfos)
            {
                var pVal = pInfo.GetValue(entity);
                if (pVal == null)
                    continue;

                if (pVal is IOptionalItemSet optSet && !optSet.Initialized)
                    continue;

                if (pVal is IList itemSet)
                {
                    for (int i = 0; i < itemSet.Count; i++)
                    {
                        var item = itemSet[i];
                        if (item == null)
                            continue;
                        if (item is IList nestedItemSet)
                        {
                            for (int j = 0; j < nestedItemSet.Count; j++)
                            {
                                var nestedItem = nestedItemSet[j];
                                if (nestedItem == null)
                                    continue;
                                Properties.Add(nestedItem);
                                PropertyNames.Add(pInfo.Name);
                            }
                            continue;
                        }
                        Properties.Add(item);
                        PropertyNames.Add(pInfo.Name);
                    }
                    continue;
                }
                Properties.Add(pVal);
                PropertyNames.Add(pInfo.Name);
            }
        }
    }
}
