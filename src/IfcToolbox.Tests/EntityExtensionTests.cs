using IfcToolbox.Core.Entities;
using IfcToolbox.Core.Extensions;
using Xbim.Ifc;
using Xunit;

namespace IfcToolbox.Tests
{
    public class EntityExtensionTests
    {
        [Theory]
        [InlineData(11, 14)] // Location with refs
        [InlineData(124, 139)] // 3D Points
        public void EntityPropsEqualityShouldPass(int index1, int index2)
        {
            using (var store = IfcStore.Open(LocalFiles.Ifc4_CubeAdvancedBrep))
            {
                var point1 = store.Instances[index1];
                var point2 = store.Instances[index2];

                Assert.True(point1.PropertiesEquals(point2));
            }
        }

        [Theory]
        [InlineData(11, true)] // Location with refs
        [InlineData(124, false)] // 3D Points
        public void EntityHasReferencesShouldPass(int index, bool expected)
        {
            using (var store = IfcStore.Open(LocalFiles.Ifc4_CubeAdvancedBrep))
            {
                var entity = store.Instances[index];
                Assert.True(entity.HasReference() == expected);
            }
        }

        [Theory]
        [InlineData(378, 403)] // 3D Points
        [InlineData(18, 19)] // 3D Points
        public void EntityProxyShouldEqual(int index1, int index2)
        {
            using (var store = IfcStore.Open(LocalFiles.Ifc4_CubeAdvancedBrep))
            {
                var point1 = new EntityProxy(store.Instances[index1]);
                var point2 = new EntityProxy(store.Instances[index2]);

                Assert.True(point1.Equals(point2));
            }
        }
    }
}