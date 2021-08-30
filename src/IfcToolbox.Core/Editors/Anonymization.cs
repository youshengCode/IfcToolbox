using IfcToolbox.Core.Analyse;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace IfcToolbox.Core.Editors
{
    public class Anonymization
    {
        #region User Info Related
        // Mandatory process for anonyme other User Info related entity
        public static void AnonymeOwnerHistory(IModel model)
        {
            var entitiesRemove = new List<IPersistEntity>();
            entitiesRemove.AddRange(model.Instances.OfType<IIfcOwnerHistory>());
            foreach (var entity in entitiesRemove)
                model.Delete(entity);
        }
        public static void AnonymeAddressInfo(IModel model, bool removePostalAddress = true, bool removeTelecomAddress = true)
        {
            var entitiesRemove = new List<IPersistEntity>();
            if (removePostalAddress)
                entitiesRemove.AddRange(model.Instances.OfType<IIfcPostalAddress>());
            if (removeTelecomAddress)
                entitiesRemove.AddRange(model.Instances.OfType<IIfcTelecomAddress>());
            foreach (var entity in entitiesRemove)
                model.Delete(entity);
        }
        public static void AnonymeAuthorInfo(IModel model, bool removeActorRole = true, bool removePerson = true, bool removeOrganization = true, bool removePersonAndOrganization = true)
        {
            var entitiesRemove = new List<IPersistEntity>();
            if (removeActorRole)
                entitiesRemove.AddRange(model.Instances.OfType<IIfcActorRole>());
            if (removePerson)
                entitiesRemove.AddRange(model.Instances.OfType<IIfcPerson>());
            if (removeOrganization)
                entitiesRemove.AddRange(model.Instances.OfType<IIfcOrganization>());
            if (removePersonAndOrganization)
                entitiesRemove.AddRange(model.Instances.OfType<IIfcPersonAndOrganization>());
            foreach (var entity in entitiesRemove)
                model.Delete(entity);
        }
        public static void AnonymeApplicationInfo(IModel model, bool removeApplication = true)
        {
            var entitiesRemove = new List<IPersistEntity>();
            if (removeApplication)
                entitiesRemove.AddRange(model.Instances.OfType<IIfcApplication>());
            foreach (var entity in entitiesRemove)
                model.Delete(entity);
        }
        public static void AnonymeFileName(IModel model, bool clearHeaderFileName = true)
        {
            if (clearHeaderFileName)
            {
                model.Header.FileName.AuthorizationMailingAddress = null;
                model.Header.FileName.AuthorizationName = null;
                model.Header.FileName.AuthorName = null;
                model.Header.FileName.Name = null;
                model.Header.FileName.Organization = null;
                model.Header.FileName.OriginatingSystem = null;
                model.Header.FileName.PreprocessorVersion = null;
                model.Header.FileName.TimeStamp = null;
            }
        }
        #endregion

        #region Product Info Related
        public static void AnonymeProduct(IModel model, IEnumerable<AnonymeRule> rules, 
            bool inName = true, bool inObjectType = true, bool inTypeProps = true, bool inProductProps = true)
        {
            foreach (var rule in rules)
            {
                var typeProducts = model.Instances.OfType<IIfcProduct>()
                .Where(x => !(x is IIfcSpatialStructureElement))
                .Where(x => x.ExpressType.ExpressNameUpper == rule.ExpressTypeName.ToUpper());
                if (!typeProducts.Any())
                    continue;
                AnonymeProductInfo(typeProducts, rule.Keyword, rule.Replacement, inName, inObjectType, inTypeProps, inProductProps);
            }
        }
        private static void AnonymeProductInfo(IEnumerable<IIfcProduct> ifcProducts, string keyWord, string replacement,
            bool inName = true, bool inObjectType = true, bool inTypeProps = true, bool inProductProps = true)
        {
            foreach (var item in ifcProducts)
            {
                if (inName)
                    if (item.Name.ToString().Contains(keyWord))
                        item.Name = item.Name.ToString().Replace(keyWord, replacement);

                if (inObjectType)
                    if (item.ObjectType.ToString().Contains(keyWord))
                        item.ObjectType = item.ObjectType.ToString().Replace(keyWord, replacement);

                if (inTypeProps)
                {
                    var typeProps = PropertiesReader.GetTypeProperties(item)
                        .Where(x => x.NominalValue.ToString().Contains(keyWord));
                    foreach (var typeProp in typeProps)
                        PropertySingleValueReplace(typeProp, keyWord, replacement);
                }

                if (inProductProps)
                {
                    var relatedProps = PropertiesReader.GetAllProperties(item).
                        Where(x => x.NominalValue.ToString().Contains(keyWord));
                    foreach (var relatedProp in relatedProps)
                        PropertySingleValueReplace(relatedProp, keyWord, replacement);
                }
            }
        }
        private static void PropertySingleValueReplace(IIfcPropertySingleValue prop, string keyWord, string replacement)
        {
            if (prop.NominalValue is IfcLabel)
                prop.NominalValue = new IfcLabel(prop.NominalValue.ToString().Replace(keyWord, replacement));
            else if (prop.NominalValue is IfcText)
                prop.NominalValue = new IfcText(prop.NominalValue.ToString().Replace(keyWord, replacement));
        }
        #endregion
    }
}
