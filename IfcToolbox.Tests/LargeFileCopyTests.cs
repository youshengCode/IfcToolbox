using IfcToolbox.Core.Utilities;
using System.IO;
using Xbim.Common;
using Xbim.Common.Metadata;
using Xbim.Ifc;
using Xbim.IO;
using Xbim.IO.Memory;
using Xunit;

namespace IfcToolbox.Tests
{
    public class LargeFileCopyTests
    {
        [Fact]
        public static void InsertCopyTest_Ifc2x3()
        {
            var filePath = LocalFiles.Ifc2x3_SampleCastle;
            var outputFolder = LocalFiles.TestOutputFolder;
            string copyFile = ConsoleFile.GetOutputFileName(filePath, outputFolder, "_Copy");
            using (var source = MemoryModel.OpenRead(filePath))
            {
                PropertyTranformDelegate propTransform = delegate (ExpressMetaProperty prop, object toCopy)
                {
                    var value = prop.PropertyInfo.GetValue(toCopy, null);
                    return value;
                };
                using (var target = new MemoryModel(new Xbim.Ifc2x3.EntityFactoryIfc2x3()))
                {
                    using (var cache = source.BeginInverseCaching())
                    using (var txn = target.BeginTransaction("Inserting copies"))
                    {
                        var map = new XbimInstanceHandleMap(source, target);
                        foreach (var item in source.Instances)
                        {
                            target.InsertCopy(item, map, propTransform, true, true);
                        }
                        txn.Commit();
                    }
                    using (var outFile = File.Create(copyFile))
                    {
                        target.SaveAsStep21(outFile);
                        outFile.Close();
                    }
                }
            }
        }

        [Fact]
        public static void InsertCopyTest()
        {
            var filePath = LocalFiles.Ifc2x3_SampleCastle;
            var outputFolder = LocalFiles.TestOutputFolder;
            string copyFile = ConsoleFile.GetOutputFileName(filePath, outputFolder, "_Copy");
            using (var model = IfcStore.Open(filePath))
            {
                using (var iModel = IfcStore.Create(((IModel)model).SchemaVersion, XbimStoreType.EsentDatabase))
                {
                    using (var cache = model.BeginInverseCaching())
                    using (var txn = iModel.BeginTransaction("InsertCopy with caching"))
                    {
                        var map = new XbimInstanceHandleMap(model, iModel);
                        if (model.SchemaVersion == Xbim.Common.Step21.XbimSchemaVersion.Ifc4 || model.SchemaVersion == Xbim.Common.Step21.XbimSchemaVersion.Ifc4x1)
                            iModel.InsertCopy(model.Instances.OfType<Xbim.Ifc4.Kernel.IfcProduct>(),
                                    true, false, map);
                        else if (model.SchemaVersion == Xbim.Common.Step21.XbimSchemaVersion.Ifc2X3)
                            iModel.InsertCopy(model.Instances.OfType<Xbim.Ifc2x3.Kernel.IfcProduct>(),
                                    true, false, map);
                        txn.Commit();
                    }
                    iModel.SaveAs(copyFile);
                }
            }
        }
    }
}
