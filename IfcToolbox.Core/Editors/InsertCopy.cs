using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc;
using Xbim.IO;

namespace IfcToolbox.Core.Editors
{
    public class InsertCopy
    {
        /// <summary>
        /// SaveAs contain Transaction, need to out of other Transactions.
        /// </summary>
        public static void SaveAs(IfcStore model, string filePath, bool deleteOld = true, bool keepLabel = false)
        {
            using (var iModel = IfcStore.Create(GetEditorCredentials(), ((IModel)model).SchemaVersion, XbimStoreType.EsentDatabase))
            {
                using (var cache = model.BeginInverseCaching())
                using (var txn = iModel.BeginTransaction("InsertCopy with caching"))
                {
                    var map = new XbimInstanceHandleMap(model, iModel);
                    if (deleteOld)
                    {
                        if (model.SchemaVersion == Xbim.Common.Step21.XbimSchemaVersion.Ifc4 || model.SchemaVersion == Xbim.Common.Step21.XbimSchemaVersion.Ifc4x1)
                            iModel.InsertCopy(model.Instances.OfType<Xbim.Ifc4.Kernel.IfcProduct>(),
                                    true, keepLabel, map);
                        else if (model.SchemaVersion == Xbim.Common.Step21.XbimSchemaVersion.Ifc2X3)
                            iModel.InsertCopy(model.Instances.OfType<Xbim.Ifc2x3.Kernel.IfcProduct>(),
                                    true, keepLabel, map);
                    }
                    else
                    {
                        foreach (var instance in model.Instances)
                            iModel.InsertCopy(instance, map, SemanticFilter.GetAll(), true, keepLabel);
                    }
                    txn.Commit();
                }
                UpdateHeader(model, iModel);
                iModel.SaveAs(filePath);
            }
        }

        public static void CopyProducts(IfcStore model, string filePath, IEnumerable<Xbim.Ifc4.Interfaces.IIfcProduct> products, bool keepLabel = false)
        {
            using (var iModel = IfcStore.Create(GetEditorCredentials(), ((IModel)model).SchemaVersion, XbimStoreType.EsentDatabase))
            {
                using (model.BeginEntityCaching())
                using (model.BeginInverseCaching())
                using (var txn = iModel.BeginTransaction("InsertCopy with IfcProducts"))
                {
                    var map = new XbimInstanceHandleMap(model, iModel);
                    iModel.InsertCopy(products, true, keepLabel, map);
                    txn.Commit();
                }
                UpdateHeader(model, iModel);
                iModel.SaveAs(filePath);
            }
        }

        public static void CopyOnlyProperties(IfcStore model, string filePath, bool keepLabel = false)
        {
            using (var iModel = IfcStore.Create(GetEditorCredentials(), ((IModel)model).SchemaVersion, XbimStoreType.EsentDatabase))
            {
                using (model.BeginEntityCaching())
                using (model.BeginInverseCaching())
                using (var txn = iModel.BeginTransaction("InsertCopy without geometry"))
                {
                    var map = new XbimInstanceHandleMap(model, iModel);
                    iModel.InsertCopy(model.Instances.OfType<Xbim.Ifc4.Interfaces.IIfcProduct>(), false, keepLabel, map);
                    txn.Commit();
                }
                UpdateHeader(model, iModel);
                iModel.SaveAs(filePath);
            }
        }

        private static void UpdateHeader(IfcStore source, IfcStore target)
        {
            target.Header.FileDescription = source.Header.FileDescription;
            target.Header.FileName = source.Header.FileName;
            target.Header.FileSchema = source.Header.FileSchema;
            target.Header.FileName.OriginatingSystem = source.Header.FileName.OriginatingSystem;
        }

        private static XbimEditorCredentials GetEditorCredentials()
        {
            return new XbimEditorCredentials
            {
                ApplicationDevelopersName = "BIM Mars",
                ApplicationFullName = "IFC Toolbox",
                ApplicationIdentifier = "Ifc.Toolbox",
                ApplicationVersion = "1.2.0",
                EditorsFamilyName = Environment.UserName,
            };
        }

    }
}
