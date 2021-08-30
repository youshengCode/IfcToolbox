using System;
using System.Collections.Generic;

namespace IfcToolbox.Core.Geo
{
    public class GeoPlacement : IEquatable<IGeoPlacement>, IGeoPlacement
    {
        public IList<double> LocationXYZ { get; set; }
        public IList<double> RotationX { get; set; }
        public IList<double> RotationZ { get; set; }
        public bool GeoReferencing { get; set; }
        public int RefEntityLable { get; set; }

        public GeoPlacement(List<double> locationXYZ, List<double> rotationX, List<double> rotationZ, int refEntityLable = 0)
        {
            if (locationXYZ != null)
                LocationXYZ = locationXYZ;
            else
                LocationXYZ = new List<double> { 0, 0, 0 };
            if (rotationX != null)
                RotationX = rotationX;
            //else
            //    RotationX = new List<double> { 1, 0, 0 };
            if (rotationZ != null)
                RotationZ = rotationZ;
            //else
            //    RotationZ = new List<double> { 0, 0, 1 };
            if (refEntityLable != 0)
                RefEntityLable = refEntityLable;
        }
        public GeoPlacement(Xbim.Ifc4.Interfaces.IIfcAxis2Placement plcm)
        {
            if (plcm is Xbim.Ifc4.Interfaces.IIfcAxis2Placement3D)
            {
                var plcm3D = (Xbim.Ifc4.Interfaces.IIfcAxis2Placement3D)plcm;

                //must be given, if IfcAxis2Placment3D exists
                this.LocationXYZ = new List<double>
                    {
                        plcm3D.Location.X,
                        plcm3D.Location.Y,
                        plcm3D.Location.Z,
                    };

                this.RotationX = new List<double>();
                if (plcm3D.RefDirection != null)
                {
                    this.RotationX.Add(plcm3D.RefDirection.DirectionRatios[0]);
                    this.RotationX.Add(plcm3D.RefDirection.DirectionRatios[1]);
                    this.RotationX.Add(plcm3D.RefDirection.DirectionRatios[2]);
                }
                else  //if omitted, default values (see IFC schema for IfcAxis2Placment3D)
                {
                    this.RotationX.Add(1);
                    this.RotationX.Add(0);
                    this.RotationX.Add(0);
                }

                this.RotationZ = new List<double>();
                if (plcm3D.Axis != null)
                {
                    this.RotationZ.Add(plcm3D.Axis.DirectionRatios[0]);
                    this.RotationZ.Add(plcm3D.Axis.DirectionRatios[1]);
                    this.RotationZ.Add(plcm3D.Axis.DirectionRatios[2]);
                }
                else  //if omitted, default values (see IFC schema for IfcAxis2Placment3D)
                {
                    this.RotationZ.Add(0);
                    this.RotationZ.Add(0);
                    this.RotationZ.Add(1);
                }

                if ((plcm3D.Location.X > 0) || (plcm3D.Location.Y > 0) || (plcm3D.Location.Z > 0))
                {
                    //by definition: ONLY in this case there could be an georeferencing
                    this.GeoReferencing = true;
                }
                else
                {
                    this.GeoReferencing = false;
                }
            }

            if (plcm is Xbim.Ifc4.Interfaces.IIfcAxis2Placement2D)
            {
                var plcm2D = (Xbim.Ifc4.Interfaces.IIfcAxis2Placement2D)plcm;

                //must be given, if IfcAxis2Placment2D exists
                this.LocationXYZ = new List<double>
                    {
                        plcm2D.Location.X,
                        plcm2D.Location.Y,
                    };

                this.RotationX = new List<double>();

                if (plcm2D.RefDirection != null)

                {
                    this.RotationX.Add(plcm2D.RefDirection.DirectionRatios[0]);
                    this.RotationX.Add(plcm2D.RefDirection.DirectionRatios[1]);
                }
                else  //if omitted, default values (see IFC schema for IfcAxis2Placment2D)
                {
                    this.RotationX.Add(1);
                    this.RotationX.Add(0);
                }

                if ((plcm2D.Location.X > 0) || (plcm2D.Location.Y > 0))
                {
                    //by definition: ONLY in this case there could be an georeferencing
                    this.GeoReferencing = true;
                }
                else
                {
                    this.GeoReferencing = false;
                }
            }
        }
        public GeoPlacement(Xbim.Ifc2x3.Interfaces.IIfcAxis2Placement plcm)
        {
            if (plcm is Xbim.Ifc2x3.Interfaces.IIfcAxis2Placement3D)
            {
                var plcm3D = (Xbim.Ifc2x3.Interfaces.IIfcAxis2Placement3D)plcm;

                //must be given, if IfcAxis2Placment3D exists
                this.LocationXYZ = new List<double>
                    {
                        plcm3D.Location.Coordinates[0],
                        plcm3D.Location.Coordinates[1],
                        plcm3D.Location.Coordinates[2],
                    };

                this.RotationX = new List<double>();
                if (plcm3D.RefDirection != null)
                {
                    this.RotationX.Add(plcm3D.RefDirection.DirectionRatios[0]);
                    this.RotationX.Add(plcm3D.RefDirection.DirectionRatios[1]);
                    this.RotationX.Add(plcm3D.RefDirection.DirectionRatios[2]);
                }
                else  //if omitted, default values (see IFC schema for IfcAxis2Placment3D)
                {
                    this.RotationX.Add(1);
                    this.RotationX.Add(0);
                    this.RotationX.Add(0);
                }

                this.RotationZ = new List<double>();
                if (plcm3D.Axis != null)
                {
                    this.RotationZ.Add(plcm3D.Axis.DirectionRatios[0]);
                    this.RotationZ.Add(plcm3D.Axis.DirectionRatios[1]);
                    this.RotationZ.Add(plcm3D.Axis.DirectionRatios[2]);
                }
                else  //if omitted, default values (see IFC schema for IfcAxis2Placment3D)
                {
                    this.RotationZ.Add(0);
                    this.RotationZ.Add(0);
                    this.RotationZ.Add(1);
                }

                if ((plcm3D.Location.Coordinates[0] > 0) || (plcm3D.Location.Coordinates[1] > 0) || (plcm3D.Location.Coordinates[2] > 0))
                {
                    //by definition: ONLY in this case there could be an georeferencing
                    this.GeoReferencing = true;
                }
                else
                {
                    this.GeoReferencing = false;
                }
            }

            if (plcm is Xbim.Ifc2x3.Interfaces.IIfcAxis2Placement2D)
            {
                var plcm2D = (Xbim.Ifc2x3.Interfaces.IIfcAxis2Placement2D)plcm;

                //must be given, if IfcAxis2Placment2D exists
                this.LocationXYZ = new List<double>
                    {
                        plcm2D.Location.Coordinates[0],
                        plcm2D.Location.Coordinates[1],
                    };

                this.RotationX = new List<double>();

                if (plcm2D.RefDirection != null)

                {
                    this.RotationX.Add(plcm2D.RefDirection.DirectionRatios[0]);
                    this.RotationX.Add(plcm2D.RefDirection.DirectionRatios[1]);
                }
                else  //if omitted, default values (see IFC schema for IfcAxis2Placment2D)
                {
                    this.RotationX.Add(1);
                    this.RotationX.Add(0);
                }

                if ((plcm2D.Location.Coordinates[0] > 0) || (plcm2D.Location.Coordinates[1] > 0))
                {
                    //by definition: ONLY in this case there could be an georeferencing
                    this.GeoReferencing = true;
                }
                else
                {
                    this.GeoReferencing = false;
                }
            }
        }

        public bool Equals(IGeoPlacement other)
        {
            if (other == null)
                return false;
            if (LocationXYZ == other.LocationXYZ &&
                RotationX == other.RotationX &&
                RotationZ == other.RotationZ)
                return true;
            else
                return false;
        }
    }
}
