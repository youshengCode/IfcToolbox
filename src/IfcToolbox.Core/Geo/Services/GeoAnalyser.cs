using IfcToolbox.Core.Analyse;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Ifc;
using Xbim.Ifc4.Interfaces;

namespace IfcToolbox.Core.Geo
{
    public class GeoAnalyser
    {
        /// <summary>
        /// Support IFC 2x3 and IFC 4 at the same time
        /// </summary>
        /// <param name="model"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static IGeoReference GetGeoReference(IfcStore model, bool logDetail = false)
        {
            var ifcProject = EntityReader.GetIfcProject(model);
            var ifcSites = ifcProject.Sites.ToList();
            var ifcBuildings = model.Instances.OfType<IIfcBuilding>().ToList();
            var ifcMapConversion = model.Instances.OfType<IIfcMapConversion>();
            var rootProduct = EntityReader.GetRootProducts(model);
            var pset_MapConversion = EntityReader.GetPropertySetWithName(model, "MapConversion");
            var pset_ProjectedCRS = EntityReader.GetPropertySetWithName(model, "ProjectedCRS");

            IGeoReference reference = GeoFactory.CreateGeoReference();
            if (ifcSites != null)
                foreach (var ifcSite in ifcSites)
                    reference.PostalAddress.Add(GetPostalAddress(ifcSite));
            if (ifcBuildings != null)
                foreach (var ifcBuilding in ifcBuildings)
                    reference.PostalAddress.Add(GetPostalAddress(ifcBuilding));

            foreach (var ifcSite in ifcSites)
                reference.GeodeticCoordinates.Add(GetGeodeticCoordinates(ifcSite));

            if (ifcSites != null)
                foreach (var ifcSite in ifcSites)
                    if (rootProduct.Contains(ifcSite))
                        reference.ProjectCoordinates.Add(GetProjectCoordinates(ifcSite));

            reference.WorldCoordinates = GetWorldCoordinates(ifcProject);

            if (model.SchemaVersion != Xbim.Common.Step21.XbimSchemaVersion.Ifc2X3)
                reference.MapConvensionCRS = GetMapConvensionCRS(ifcProject, ifcMapConversion);
            else // PropertySets for georeferencing in Ifc2X3
            {
                if (pset_MapConversion != null && pset_ProjectedCRS != null)
                    reference.MapConvensionCRS = GetMapConvensionCRS_Pset(pset_MapConversion, pset_ProjectedCRS, ifcProject, ifcSites, ifcBuildings);
                else
                    reference.MapConvensionCRS = GetMapConvensionCRS(ifcProject, null);
            }

            reference.RemoveUncompleted();
            if (logDetail)
            {
                Log.Information("PostalAddress: {@obj}", reference.PostalAddress);
                Log.Information("GeodeticCoordinates: {@obj}", reference.GeodeticCoordinates);
                Log.Information("ProjectCoordinates: {@obj}", reference.ProjectCoordinates);
                Log.Information("WorldCoordinates: {@obj}", reference.WorldCoordinates);
                Log.Information("MapConvensionCRS: {@obj}", reference.MapConvensionCRS);
            }
            return reference;
        }

        #region Private Methodes for get GeoInfo in details
        private static IPostalAddress GetPostalAddress(IIfcSpatialStructureElement spatialElement)
        {
            var geoInfo = GeoFactory.CreatePostalAddress();
            try
            {
                geoInfo.Reference_Object = EntityReader.GetInfo(spatialElement);
                IIfcPostalAddress address = null;
                if (spatialElement is IIfcSite)
                    address = (spatialElement as IIfcSite).SiteAddress;
                else
                    address = (spatialElement as IIfcBuilding).BuildingAddress;

                if (address != null)
                {
                    geoInfo.IsComplet = true;
                    geoInfo.AddressLines = new List<string>();
                    geoInfo.Instance_Object = EntityReader.GetInfo(address);
                    var alines = address.AddressLines;
                    if (alines != null)
                        foreach (var a in alines)
                            geoInfo.AddressLines.Add(a);

                    geoInfo.Postalcode = (address.PostalCode.HasValue) ? address.PostalCode.ToString() : null;
                    geoInfo.Town = (address.Town.HasValue) ? address.Town.ToString() : null;
                    geoInfo.Region = (address.Region.HasValue) ? address.Region.ToString() : null;
                    geoInfo.Country = (address.Country.HasValue) ? address.Country.ToString() : null;
                }
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
            }
            return geoInfo;
        }
        private static IGeodeticCoordinates GetGeodeticCoordinates(IIfcSite site)
        {
            var geoInfo = GeoFactory.CreateGeodeticCoordinates();
            try
            {
                geoInfo.Reference_Object = EntityReader.GetInfo(site);
                if (site.RefLatitude.HasValue || site.RefLongitude.HasValue)
                {
                    geoInfo.Latitude = site.RefLatitude.Value.AsDouble;
                    geoInfo.Longitude = site.RefLongitude.Value.AsDouble;
                    geoInfo.IsComplet = true;
                }
                geoInfo.Elevation = site.RefElevation.Value;
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
            }
            return geoInfo;
        }
        private static IProjectCoordinates GetProjectCoordinates(IIfcProduct product)
        {
            var geoInfo = GeoFactory.CreateProjectCoordinates();
            try
            {
                var objectPlacement = (IIfcLocalPlacement)product.ObjectPlacement;
                var axis2Placement = objectPlacement.RelativePlacement;

                geoInfo.Reference_Object = EntityReader.GetInfo(product);
                geoInfo.Instance_Object = EntityReader.GetInfo(axis2Placement);

                geoInfo.Placement = GeoFactory.CreateGeoPlacement(axis2Placement);
                geoInfo.IsComplet = true;
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
            }
            return geoInfo;
        }
        private static IWorldCoordinates GetWorldCoordinates(IIfcProject project)
        {
            var geoInfo = GeoFactory.CreateWorldCoordinates();
            try
            {
                var projectCtx = EntityReader.GetPresentationContext(project);
                geoInfo.Reference_Object = EntityReader.GetInfo(project);
                geoInfo.Instance_Object = EntityReader.GetInfo(projectCtx);

                //variable for the WorldCoordinatesystem attribute
                var axis2Placement = projectCtx.WorldCoordinateSystem;
                geoInfo.Placement = GeoFactory.CreateGeoPlacement(axis2Placement);

                //variable for the TrueNorth attribute
                var direction = projectCtx.TrueNorth;
                geoInfo.TrueNorthXY = new List<double>();
                if (direction != null)
                {
                    geoInfo.TrueNorthXY.Add(direction.DirectionRatios[0]);
                    geoInfo.TrueNorthXY.Add(direction.DirectionRatios[1]);
                }
                else
                {
                    //if omitted, default values (see IFC schema for IfcGeometricRepresentationContext):
                    geoInfo.TrueNorthXY.Add(0);
                    geoInfo.TrueNorthXY.Add(1);
                }
                geoInfo.IsComplet = true;
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
            }
            return geoInfo;
        }
        private static IMapConvensionCRS GetMapConvensionCRS(IIfcProject project, IEnumerable<IIfcMapConversion> mapConversions)
        {
            var geoInfo = GeoFactory.CreateMapConvensionCRS();
            try
            {
                geoInfo.Reference_Object = EntityReader.GetInfo(project);
                var projectCtx = EntityReader.GetPresentationContext(project);
                IIfcMapConversion map = null;
                if (mapConversions != null)
                    map = mapConversions.Where(m => m.SourceCRS == projectCtx).ToList().FirstOrDefault();

                if (map != null)
                {
                    geoInfo.Instance_Object = EntityReader.GetInfo(map);
                    geoInfo.Eastings = map.Eastings;
                    geoInfo.Northings = map.Northings;
                    geoInfo.OrthogonalHeight = map.OrthogonalHeight;

                    if (map.XAxisAbscissa.HasValue && map.XAxisOrdinate.HasValue)
                    {
                        geoInfo.XAxisOrdinate = map.XAxisOrdinate.Value;
                        geoInfo.XAxisAbscissa = map.XAxisAbscissa.Value;
                    }

                    geoInfo.Scale = (map.Scale.HasValue) ? map.Scale.Value : 1;

                    var mapCRS = (IIfcProjectedCRS)map.TargetCRS;
                    if (mapCRS != null)
                    {
                        geoInfo.CRS_Name = (mapCRS.Name != null) ? mapCRS.Name.ToString() : null;
                        geoInfo.CRS_Description = (mapCRS.Description != null) ? mapCRS.Description.ToString() : null;
                        geoInfo.CRS_GeodeticDatum = (mapCRS.GeodeticDatum != null) ? mapCRS.GeodeticDatum.ToString() : null;
                        geoInfo.CRS_VerticalDatum = (mapCRS.VerticalDatum != null) ? mapCRS.VerticalDatum.ToString() : null;
                        geoInfo.CRS_ProjectionName = (mapCRS.MapProjection != null) ? mapCRS.MapProjection.ToString() : null;
                        geoInfo.CRS_ProjectionZone = (mapCRS.MapZone != null) ? mapCRS.MapZone.ToString() : null;
                    }

                    geoInfo.IsComplet = true;
                }
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
            }
            return geoInfo;
        }
        private static IMapConvensionCRS GetMapConvensionCRS_Pset(IIfcPropertySet psetMap, IIfcPropertySet psetCrs, IIfcProject ifcProject, IList<IIfcSite> ifcSites, IList<IIfcBuilding> ifcBuildings)
        {
            var geoInfo = GeoFactory.CreateMapConvensionCRS();
            try
            {
                foreach (var pset in psetMap.DefinesOccurrence)
                {
                    var relObj = pset.RelatedObjects;
                    if (relObj.Contains(ifcProject))
                    {
                        geoInfo.Reference_Object = EntityReader.GetInfo(ifcProject);
                        break;
                    }

                    foreach (var ifcSite in ifcSites)
                        if (relObj.Contains(ifcSite))
                        {
                            geoInfo.Reference_Object = EntityReader.GetInfo(ifcSite);
                            break;
                        }
                    if (geoInfo.Reference_Object != null)
                        break;

                    foreach (var ifcBuilding in ifcBuildings)
                        if (relObj.Contains(ifcBuilding))
                        {
                            geoInfo.Reference_Object = EntityReader.GetInfo(ifcBuilding);
                            break;
                        }
                    if (geoInfo.Reference_Object != null)
                        break;

                    if (geoInfo.Reference_Object == null)
                    {
                        geoInfo.Reference_Object = EntityReader.GetInfo(relObj.FirstOrDefault());
                        break;
                    }
                }

                geoInfo.Instance_Object = EntityReader.GetInfo(psetMap);

                var prop = (psetMap.HasProperties.Where(p => p.Name == "Eastings").SingleOrDefault() as IIfcPropertySingleValue);
                var propVal = prop.NominalValue;
                var vall = propVal.Value;

                var sd = double.TryParse(vall.ToString(), out double asas);

                geoInfo.Eastings = EntityReader.GetPropValueToDouble(psetMap, "Eastings");
                geoInfo.Northings = EntityReader.GetPropValueToDouble(psetMap, "Northings");
                geoInfo.OrthogonalHeight = EntityReader.GetPropValueToDouble(psetMap, "OrthogonalHeight");

                geoInfo.XAxisAbscissa = EntityReader.GetPropValueToDouble(psetMap, "XAxisAbscissa");
                geoInfo.XAxisOrdinate = EntityReader.GetPropValueToDouble(psetMap, "XAxisOrdinate");

                geoInfo.Scale = EntityReader.GetPropValueToDouble(psetMap, "Scale");

                geoInfo.CRS_Name = EntityReader.GetPropValueToString(psetCrs, "Name");
                geoInfo.CRS_Description = EntityReader.GetPropValueToString(psetCrs, "Description");
                geoInfo.CRS_GeodeticDatum = EntityReader.GetPropValueToString(psetCrs, "GeodeticDatum");
                geoInfo.CRS_VerticalDatum = EntityReader.GetPropValueToString(psetCrs, "VerticalDatum");
                geoInfo.CRS_ProjectionName = EntityReader.GetPropValueToString(psetCrs, "MapProjection");
                geoInfo.CRS_ProjectionZone = EntityReader.GetPropValueToString(psetCrs, "MapZone");

                geoInfo.IsComplet = true;
            }

            catch (Exception e)
            {
                Log.Error(e.Message);
            }
            return geoInfo;
        }
        #endregion
    }
}
