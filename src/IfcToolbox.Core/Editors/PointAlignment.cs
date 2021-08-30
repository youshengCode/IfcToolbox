using IfcToolbox.Core.Geo;
using IfcToolbox.Core.Utilities;
using Serilog;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;

namespace IfcToolbox.Core.Editors
{
    public class PointAlignment
    {
        public static void AlignCoordinates_Ifc4(IModel model, bool alignWorldCoordinates, bool alignProjectCoordinates,
            IGeoPlacement worldPlacement, IEnumerable<IGeoPlacement> projectPlacements, bool logDetail)
        {
            var ifcProject = model.Instances.OfType<Xbim.Ifc4.Interfaces.IIfcProject>().ToList().FirstOrDefault();
            if (alignWorldCoordinates)
            {
                var projectContext = GetPresentationContext(ifcProject);
                var worldCoordinateSys = projectContext.WorldCoordinateSystem;
                AlignPlacement(worldCoordinateSys, worldPlacement, model, logDetail);
            }
            if (alignProjectCoordinates)
            {
                var ifcSites = ifcProject.Sites;
                foreach (var ifcSite in ifcSites)
                {
                    if (projectPlacements.Select(p => p.RefEntityLable).Contains(ifcSite.EntityLabel))
                    {
                        var ifcObjectPlacement = (Xbim.Ifc4.Interfaces.IIfcLocalPlacement)ifcSite.ObjectPlacement;
                        var ifcAxis2Placement = ifcObjectPlacement.RelativePlacement;
                        var projectPlacement = projectPlacements.Where(p => p.RefEntityLable == ifcSite.EntityLabel).FirstOrDefault();
                        AlignPlacement(ifcAxis2Placement, projectPlacement, model, logDetail);
                    }
                }
            }
        }
        public static void AlignCoordinates_Ifc2x3(IModel model, bool alignWorldCoordinates, bool alignProjectCoordinates,
            IGeoPlacement worldPlacement, IEnumerable<IGeoPlacement> projectPlacements, bool logDetail)
        {
            var ifcProject = model.Instances.OfType<Xbim.Ifc2x3.Interfaces.IIfcProject>().ToList().FirstOrDefault();
            if (alignWorldCoordinates)
            {
                var projectContext = GetPresentationContext(ifcProject);
                var worldCoordinateSys = projectContext.WorldCoordinateSystem;
                AlignPlacement(worldCoordinateSys, worldPlacement, model, logDetail);
            }
            if (alignProjectCoordinates)
            {
                var ifcSites = model.Instances.OfType<Xbim.Ifc2x3.Interfaces.IIfcSite>().ToList();
                foreach (var ifcSite in ifcSites)
                {
                    if (projectPlacements.Select(p => p.RefEntityLable).Contains(ifcSite.EntityLabel))
                    {
                        var ifcObjectPlacement = (Xbim.Ifc2x3.Interfaces.IIfcLocalPlacement)ifcSite.ObjectPlacement;
                        var ifcAxis2Placement = ifcObjectPlacement.RelativePlacement;
                        var projectPlacement = projectPlacements.Where(p => p.RefEntityLable == ifcSite.EntityLabel).FirstOrDefault();
                        AlignPlacement(ifcAxis2Placement, projectPlacement, model, logDetail);
                    }
                }
            }
        }

        private static void AlignPlacement(Xbim.Ifc4.Interfaces.IIfcAxis2Placement axis2Placement, IGeoPlacement refPlacement, IModel model, bool logDetail)
        {
            var placement = GeoFactory.CreateGeoPlacement(axis2Placement);
            if (!placement.Equals(refPlacement))
            {
                if (placement.LocationXYZ != refPlacement.LocationXYZ)
                {
                    var point = PointFactory.CreatePoint_Ifc4(model, refPlacement.LocationXYZ);
                    if (axis2Placement is Xbim.Ifc4.Interfaces.IIfcAxis2Placement3D placement3D)
                        placement3D.Location = point;
                    else if (axis2Placement is Xbim.Ifc4.Interfaces.IIfcAxis2Placement2D placement2D)
                        placement2D.Location = point;
                }
                if (placement.RotationX != refPlacement.RotationX)
                {
                    var refDirection = PointFactory.CreateDirection_Ifc4(model, refPlacement.RotationX);
                    if (axis2Placement is Xbim.Ifc4.Interfaces.IIfcAxis2Placement3D placement3D)
                        placement3D.RefDirection = refDirection;
                    else if (axis2Placement is Xbim.Ifc4.Interfaces.IIfcAxis2Placement2D placement2D)
                        placement2D.RefDirection = refDirection;
                }
                if (placement.RotationZ != refPlacement.RotationZ)
                {
                    var axis = PointFactory.CreateDirection_Ifc4(model, refPlacement.RotationZ);
                    if (axis2Placement is Xbim.Ifc4.Interfaces.IIfcAxis2Placement3D placement3D)
                        placement3D.Axis = axis;
                }
                if (logDetail)
                {
                    Marslogger.Mark($"#{axis2Placement.EntityLabel} location updated.");
                    Log.Information("IfcAxis2Placement: {@obj}", GeoFactory.CreateGeoPlacement(axis2Placement));
                }
            }
        }
        private static void AlignPlacement(Xbim.Ifc2x3.Interfaces.IIfcAxis2Placement axis2Placement, IGeoPlacement refPlacement, IModel model, bool logDetail)
        {
            var placement = GeoFactory.CreateGeoPlacement(axis2Placement);
            if (!placement.Equals(refPlacement))
            {
                if (placement.LocationXYZ != refPlacement.LocationXYZ)
                {
                    var point = PointFactory.CreatePoint_Ifc2x3(model, refPlacement.LocationXYZ);
                    if (axis2Placement is Xbim.Ifc2x3.Interfaces.IIfcAxis2Placement3D placement3D)
                        placement3D.Location = point;
                    else if (axis2Placement is Xbim.Ifc2x3.Interfaces.IIfcAxis2Placement2D placement2D)
                        placement2D.Location = point;
                }
                if (placement.RotationX != refPlacement.RotationX)
                {
                    var refDirection = PointFactory.CreateDirection_Ifc2x3(model, refPlacement.RotationX);
                    if (axis2Placement is Xbim.Ifc2x3.Interfaces.IIfcAxis2Placement3D placement3D)
                        placement3D.RefDirection = refDirection;
                    else if (axis2Placement is Xbim.Ifc2x3.Interfaces.IIfcAxis2Placement2D placement2D)
                        placement2D.RefDirection = refDirection;
                }
                if (placement.RotationZ != refPlacement.RotationZ)
                {
                    var axis = PointFactory.CreateDirection_Ifc2x3(model, refPlacement.RotationZ);
                    if (axis2Placement is Xbim.Ifc2x3.Interfaces.IIfcAxis2Placement3D placement3D)
                        placement3D.Axis = axis;
                }
                if (logDetail)
                {
                    Marslogger.Mark($"#{axis2Placement.EntityLabel} location updated.");
                    Log.Information("IfcAxis2Placement: {@obj}", GeoFactory.CreateGeoPlacement(axis2Placement));
                }
            }
        }

        private static Xbim.Ifc4.Interfaces.IIfcGeometricRepresentationContext GetPresentationContext(Xbim.Ifc4.Interfaces.IIfcProject project)
        {
            //includes also inherited SubContexts (not necessary for this application)
            var allCtx = project.RepresentationContexts.
                OfType<Xbim.Ifc4.Interfaces.IIfcGeometricRepresentationContext>();
            if (allCtx != null)
            {
                //avoid subs (unneccessary overhead)
                var noSubCtx = allCtx.Where(ctx => ctx.ExpressType.ToString() != "IfcGeometricRepresentationSubContext").ToList();
                if (noSubCtx != null)
                {
                    //get only the context for model
                    var projectCtx = noSubCtx.Where(a => a.ContextType == "Model").SingleOrDefault();
                    return projectCtx;
                }
            }
            return null;
        }
        private static Xbim.Ifc2x3.Interfaces.IIfcGeometricRepresentationContext GetPresentationContext(Xbim.Ifc2x3.Interfaces.IIfcProject project)
        {
            //includes also inherited SubContexts (not necessary for this application)
            var allCtx = project.RepresentationContexts.
                OfType<Xbim.Ifc2x3.Interfaces.IIfcGeometricRepresentationContext>();
            if (allCtx != null)
            {
                //avoid subs (unneccessary overhead)
                var noSubCtx = allCtx.Where(ctx => ctx.ExpressType.ToString() != "IfcGeometricRepresentationSubContext").ToList();
                if (noSubCtx != null)
                {
                    //get only the context for model
                    var projectCtx = noSubCtx.Where(a => a.ContextType == "Model").SingleOrDefault();
                    return projectCtx;
                }
            }
            return null;
        }
    }
}
