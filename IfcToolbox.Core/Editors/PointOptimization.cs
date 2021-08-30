using Serilog;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;

namespace IfcToolbox.Core.Editors
{
    public class PointOptimization
    {
        #region OptimizePoints
        public static Dictionary<IPersistEntity, IPersistEntity> OptimizePoints(IModel model, IEnumerable<Xbim.Ifc4.Interfaces.IIfcCartesianPoint> points, bool withPrecision = true, int precision = 4)
        {
            var groupedEntities = new Dictionary<Xbim.Ifc4.Interfaces.IIfcCartesianPoint, IList<Xbim.Ifc4.Interfaces.IIfcCartesianPoint>>();

            var groups = points.GroupBy(p => new { p.X, p.Y, p.Z, p.Dim });
            foreach (var group in groups)
            {
                var groupList = group.ToList();
                var groupFirst = group.First();
                groupList.Remove(groupFirst);
                groupedEntities.Add(groupFirst, groupList);
            }

            var createdPoints = CreateNewPoints(model, groupedEntities, withPrecision, precision);

            var duplicatedGroups = groupedEntities
              .Where(group => group.Value.Count() > 0)
              .ToDictionary(group => group.Key, group => group.Value);

            var entityMap = new Dictionary<IPersistEntity, IPersistEntity>();
            foreach (var duplicatedGroup in duplicatedGroups)
                foreach (var duplicatedEntity in duplicatedGroup.Value)
                    if (duplicatedEntity.EntityLabel != duplicatedGroup.Key.EntityLabel)
                        entityMap.Add(duplicatedEntity, duplicatedGroup.Key);

            var updatedEntities = points.ToList();
            updatedEntities.AddRange(createdPoints);
            var replacer = new EntityReplacer();
            replacer.ReplaceEntities(model, updatedEntities, entityMap);
            return entityMap;
        }
        public static Dictionary<IPersistEntity, IPersistEntity> OptimizePoints(IModel model, IEnumerable<Xbim.Ifc2x3.Interfaces.IIfcCartesianPoint> points, bool withPrecision = true, int precision = 4)
        {
            var groupedEntities = new Dictionary<Xbim.Ifc2x3.Interfaces.IIfcCartesianPoint, IList<Xbim.Ifc2x3.Interfaces.IIfcCartesianPoint>>();

            List<PointProxy> pointProxyList = new List<PointProxy>();
            foreach (var item in points)
                pointProxyList.Add(new PointProxy(item));
            var groupsProxy = pointProxyList.GroupBy(p => new { p.ProxyX, p.ProxyY, p.ProxyZ, p.ProxyDim });
            foreach (var group in groupsProxy)
            {
                var groupList = group.Select(x => x.OriginalPoint).ToList();
                var groupFirst = group.First().OriginalPoint;
                groupList.Remove(groupFirst);
                groupedEntities.Add(groupFirst, groupList);
            }

            var createdPoints = CreateNewPoints(model, groupedEntities, withPrecision, precision);

            var duplicatedGroups = groupedEntities
              .Where(group => group.Value.Count() > 0)
              .ToDictionary(group => group.Key, group => group.Value);

            var entityMap = new Dictionary<IPersistEntity, IPersistEntity>();
            foreach (var duplicatedGroup in duplicatedGroups)
                foreach (var duplicatedEntity in duplicatedGroup.Value)
                    if (duplicatedEntity.EntityLabel != duplicatedGroup.Key.EntityLabel)
                        entityMap.Add(duplicatedEntity, duplicatedGroup.Key);

            var updatedEntities = points.ToList();
            updatedEntities.AddRange(createdPoints);
            var replacer = new EntityReplacer();
            replacer.ReplaceEntities(model, updatedEntities, entityMap);
            return entityMap;
        }

        private static List<Xbim.Ifc4.Interfaces.IIfcCartesianPoint> CreateNewPoints(IModel model, Dictionary<Xbim.Ifc4.Interfaces.IIfcCartesianPoint, IList<Xbim.Ifc4.Interfaces.IIfcCartesianPoint>> groupedEntities, bool withPrecision, int precision)
        {
            var createdPointsDic = new Dictionary<Xbim.Ifc4.Interfaces.IIfcCartesianPoint, Xbim.Ifc4.Interfaces.IIfcCartesianPoint>();
            if (withPrecision)
            {
                foreach (var point in groupedEntities.Keys)
                    if (PointPrecision.NeedOptimize(point, precision))
                    {
                        var newPoint = PointFactory.CreatePoint(model, point, withPrecision, precision);
                        if (newPoint != null)
                            createdPointsDic.Add(point, newPoint);
                    }
                foreach (var point in createdPointsDic.Keys)
                    if (groupedEntities.ContainsKey(point))
                    {
                        var updatedList = groupedEntities[point];
                        updatedList.Add(point);
                        groupedEntities.Add(createdPointsDic[point], updatedList);
                        groupedEntities.Remove(point);
                    }
            }
            return createdPointsDic.Values.ToList();
        }
        private static List<Xbim.Ifc2x3.Interfaces.IIfcCartesianPoint> CreateNewPoints(IModel model, Dictionary<Xbim.Ifc2x3.Interfaces.IIfcCartesianPoint, IList<Xbim.Ifc2x3.Interfaces.IIfcCartesianPoint>> groupedEntities, bool withPrecision, int precision)
        {
            var createdPointsDic = new Dictionary<Xbim.Ifc2x3.Interfaces.IIfcCartesianPoint, Xbim.Ifc2x3.Interfaces.IIfcCartesianPoint>();
            if (withPrecision)
            {
                foreach (var point in groupedEntities.Keys)
                    if (PointPrecision.NeedOptimize(point, precision))
                    {
                        var newPoint = PointFactory.CreatePoint(model, point, withPrecision, precision);
                        if (newPoint != null)
                            createdPointsDic.Add(point, newPoint);
                    }
                foreach (var point in createdPointsDic.Keys)
                    if (groupedEntities.ContainsKey(point))
                    {
                        var updatedList = groupedEntities[point];
                        updatedList.Add(point);
                        groupedEntities.Add(createdPointsDic[point], updatedList);
                        groupedEntities.Remove(point);
                    }
            }
            return createdPointsDic.Values.ToList();
        }
        #endregion

        #region OptimizePointLists
        public static Dictionary<IPersistEntity, IPersistEntity> OptimizePointLists(IModel model, bool withPrecision = true, int precision = 4)
        {
            var entityMap = new Dictionary<IPersistEntity, IPersistEntity>();
            if (!withPrecision)
                return entityMap;

            List<Xbim.Ifc4.Interfaces.IIfcCartesianPointList> pointLists = model.Instances.OfType<Xbim.Ifc4.Interfaces.IIfcCartesianPointList>().ToList();

            var createdPointLists = new List<Xbim.Ifc4.Interfaces.IIfcCartesianPointList>();
            foreach (var pointList in pointLists)
            {
                List<List<double>> valueTable = GetPointListValue(pointList, precision);
                if (pointList is Xbim.Ifc4.Interfaces.IIfcCartesianPointList3D)
                {
                    var createdPointList = CreatePointList3D(model, valueTable);
                    createdPointLists.Add(createdPointList);
                    entityMap.Add(pointList, createdPointList);
                }
                else if (pointList is Xbim.Ifc4.Interfaces.IIfcCartesianPointList2D)
                {
                    var createdPointList = CreatePointList2D(model, valueTable);
                    createdPointLists.Add(createdPointList);
                    entityMap.Add(pointList, createdPointList);
                }
            }

            pointLists.AddRange(createdPointLists);
            var replacer = new EntityReplacer();
            replacer.ReplaceEntities(model, pointLists, entityMap);
            return entityMap;
        }

        private static Xbim.Ifc4.GeometricModelResource.IfcCartesianPointList3D CreatePointList3D(IModel model, List<List<double>> table)
        {
            Xbim.Ifc4.GeometricModelResource.IfcCartesianPointList3D pointList = model.Instances.New<Xbim.Ifc4.GeometricModelResource.IfcCartesianPointList3D>(cpl =>
            {
                for (int i = 0; i < table.Count; i++)
                {
                    var values = table[i];
                    Xbim.Ifc4.MeasureResource.IfcLengthMeasure[] measures = new Xbim.Ifc4.MeasureResource.IfcLengthMeasure[values.Count];
                    for (int j = 0; j < values.Count; j++)
                        measures[j] = new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(values[j]);
                    cpl.CoordList.GetAt(i).AddRange(measures);
                }
            });
            return pointList;
        }
        private static Xbim.Ifc4.GeometricModelResource.IfcCartesianPointList2D CreatePointList2D(IModel model, List<List<double>> table)
        {
            Xbim.Ifc4.GeometricModelResource.IfcCartesianPointList2D pointList = model.Instances.New<Xbim.Ifc4.GeometricModelResource.IfcCartesianPointList2D>(cpl =>
            {
                for (int i = 0; i < table.Count; i++)
                {
                    var values = table[i];
                    Xbim.Ifc4.MeasureResource.IfcLengthMeasure[] measures = new Xbim.Ifc4.MeasureResource.IfcLengthMeasure[values.Count];
                    for (int j = 0; j < values.Count; j++)
                        measures[j] = new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(values[j]);
                    cpl.CoordList.GetAt(i).AddRange(measures);
                }
            });
            return pointList;
        }

        private static List<List<double>> GetPointListValue(Xbim.Ifc4.Interfaces.IIfcCartesianPointList entite, int precision)
        {
            List<List<double>> table = new List<List<double>>();
            if (entite is Xbim.Ifc4.Interfaces.IIfcCartesianPointList3D pointList3d)
            {
                foreach (var coordList in pointList3d.CoordList)
                {
                    var values = coordList.Select(x => double.Parse(x.Value.ToString())).ToList();
                    table.Add(PointPrecision.Optimize(precision, values));
                }
            }
            else if (entite is Xbim.Ifc4.Interfaces.IIfcCartesianPointList2D pointList2d)
            {
                foreach (var coordList in pointList2d.CoordList)
                {
                    var values = coordList.Select(x => double.Parse(x.Value.ToString())).ToList();
                    table.Add(PointPrecision.Optimize(precision, values));
                }
            }
            return table;
        }

        public static void LogMergeMap(Dictionary<IPersistEntity, IPersistEntity> mergeMap)
        {
            Log.Information($"MergeMap Count: {mergeMap.Count()}");
            foreach (var item in mergeMap)
                Log.Information($"Mapping: {item.Key} --> {item.Value}");
        }
        #endregion
    }
}
