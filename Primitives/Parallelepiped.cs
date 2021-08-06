using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weatherwane
{
    class Parallelepiped : Primitive
    {
        public Vec3d C;
        public Vec3d E;
        public Parallelepiped(string name, Material material, bool moving, 
            Vec3d C, Vec3d E) : base(name, material, moving)
        {
            this.C = C;
            this.E = E;
        }

        public override void RotateOY(Vec3d turn_point, double teta)
        {
            this.C.RotateOY(turn_point, teta);
            this.E.RotateOY(turn_point, teta);
        }

        public override void intersectRay(Vec3d camera_point, Vec3d view_direction, ref double t1ret, ref double t2ret)
        {
            double t1, t2;
            double tnear = Double.NegativeInfinity;
            double tfar = Double.PositiveInfinity;

            if (Math.Abs(view_direction.x) < 0.001)
            {
                if (camera_point.x < this.C.x || camera_point.x > this.E.x)
                {
                    t1ret = Double.PositiveInfinity;
                    t2ret = Double.NegativeInfinity;
                    return;
                }

            }
            else
            {

                t1 = (this.C.x - camera_point.x) / view_direction.x;
                t2 = (this.E.x - camera_point.x) / view_direction.x;
                if (t1 > t2)
                {
                    double tmp = t1;
                    t1 = t2;
                    t2 = tmp;
                }
                if (t1 > tnear) tnear = t1;
                if (t2 < tfar) tfar = t2;
                if (tnear > tfar)
                {
                    t1ret = Double.PositiveInfinity;
                    t2ret = Double.NegativeInfinity;
                    return;
                }
                if (tfar < 0)
                {
                    t1ret = Double.PositiveInfinity;
                    t2ret = Double.NegativeInfinity;
                    return;
                }
            }

            if (Math.Abs(view_direction.y) < 0.001)
            {
                if (camera_point.y < this.C.y || camera_point.y > this.E.y)
                {
                    t1ret = Double.PositiveInfinity;
                    t2ret = Double.NegativeInfinity;
                    return;
                }
            }
            else
            {

                t1 = (this.C.y - camera_point.y) / view_direction.y;
                t2 = (this.E.y - camera_point.y) / view_direction.y;
                if (t1 > t2)
                {
                    double tmp = t1;
                    t1 = t2;
                    t2 = tmp;
                }
                if (t1 > tnear) tnear = t1;
                if (t2 < tfar) tfar = t2;
                if (tnear > tfar)
                {
                    t1ret = Double.PositiveInfinity;
                    t2ret = Double.NegativeInfinity;
                    return;
                }
                if (tfar < 0)
                {
                    t1ret = Double.PositiveInfinity;
                    t2ret = Double.NegativeInfinity;
                    return;
                }
            }
            if (Math.Abs(view_direction.z) < 0.001)
            {
                if (camera_point.z < this.C.z || camera_point.z > this.E.z)
                {
                    t1ret = Double.PositiveInfinity;
                    t2ret = Double.NegativeInfinity;
                    return;
                }
            }
            else
            {

                t1 = (this.C.z - camera_point.z) / view_direction.z;
                t2 = (this.E.z - camera_point.z) / view_direction.z;
                if (t1 > t2)
                {
                    double tmp = t1;
                    t1 = t2;
                    t2 = tmp;
                }
                if (t1 > tnear) tnear = t1;
                if (t2 < tfar) tfar = t2;
                if (tnear > tfar)
                {
                    t1ret = Double.PositiveInfinity;
                    t2ret = Double.NegativeInfinity;
                    return;
                }
                if (tfar < 0)
                {
                    t1ret = Double.PositiveInfinity;
                    t2ret = Double.NegativeInfinity;
                    return;
                }
            }
            t1ret = tnear;
            t2ret = tfar;
        }

        public override Vec3d findNormal(Vec3d P)
        {
            Vec3d size = this.E - this.C;
            Vec3d C = this.E + this.C;
            C = C * 0.5;


            Vec3d localPoint = P - C;
            Vec3d normal = new Vec3d(1, 0, 0);

            normal.x = normal.x * Math.Sign(localPoint.x);
            double distance = Math.Abs(size.x - Math.Abs(localPoint.x));
            double min = distance;

            distance = Math.Abs(size.y - Math.Abs(localPoint.y));

            if (distance < min)
            {
                min = distance;

                normal = new Vec3d(0, 1, 0);

                normal.y = normal.y * Math.Sign(localPoint.y);

            }
            distance = Math.Abs(size.z - Math.Abs(localPoint.z));
            if (distance < min)
            {
                min = distance;
                normal = new Vec3d(0, 0, 1);

                normal.z = normal.z * Math.Sign(localPoint.z);
            }
            return normal;

        }
    }
}