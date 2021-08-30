using IfcToolbox.Core.Analyse;
using System.Linq;
using Xbim.Ifc;
using Xunit;

namespace IfcToolbox.Tests
{
    public class EntityReverseTests
    {
        [Theory]
        [InlineData(18, 7)]
        [InlineData(7, 2)]
        public void EntityReverseShouldPass(int index, int expected)
        {
            using (var store = IfcStore.Open(LocalFiles.Ifc4_WallElementedCase))
            {
                var entity = store.Instances[index];
                var refs = new EntityReverser().GetReversedEntities(store, entity);
                Assert.True(refs.Count() == 1);
                Assert.True(refs.First().Value.First().EntityLabel == expected);
            }
        }

        [Theory]
        [InlineData(378, 372)]
        [InlineData(220, 208)]
        public void EntityReverseShouldContain(int index, int refLabel)
        {
            using (var store = IfcStore.Open(LocalFiles.Ifc4_WallElementedCase))
            {
                var entity = store.Instances[index];
                var entityRef = store.Instances[refLabel];
                var refs = new EntityReverser().GetReversedEntities(store, entity).SelectMany(x => x.Value);
                Assert.Contains(entityRef, refs);
            }
        }

    }
}
