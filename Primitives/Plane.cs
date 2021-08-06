using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weatherwane
{
    class Plane : Primitive
    {
        
        public Vec3d V;
        public Plane(string name, Vec3d C, Vec3d V, Material material, bool moving) : base (name, C, material, moving)
        {
            this.V = V;
        }

        public override void RotateOY(Vec3d C, double teta)
        {
            Vec3d zero = new Vec3d(0, 0, 0);
            this.C.RotateOY(C, teta);
            this.V.RotateOY(zero, teta);
        }

        public override void intersectRay(Vec3d O, Vec3d D, ref double t1, ref double t2)
        {
            Vec3d CO = O - this.C;

            double d_v = Vec3d.ScalarMultiplication(D, this.V);
            double co_v = Vec3d.ScalarMultiplication(CO, this.V);

            if (d_v < 0 || d_v > 0)
            {
                t1 = -co_v / d_v;
                if (t1 < 0)
                    t1 = Double.PositiveInfinity;

            }
            else
            {
                t1 = Double.PositiveInfinity;
            }
            t2 = t1;
        }

        public override Vec3d findNormal(Vec3d _)
        {
            return this.V;
        }
    }

    class DiskPlane : Plane
    {
        public double r;
        public DiskPlane(string name, Vec3d C, Vec3d V, double r, Material material, bool moving) : base(name, C, V, material, moving)
        {
            this.r = r;
        }

        public override void intersectRay(Vec3d O, Vec3d D, ref double t1, ref double t2)
        {
            Plane tmp = new Plane("", this.C, this.V, this.material, this.moving);
            tmp.intersectRay(O, D, ref t1, ref t2);

            if (t1 != Double.PositiveInfinity)
            {
                Vec3d P = O + D * t1;
                Vec3d v = P - this.C;
                double d2 = Vec3d.ScalarMultiplication(v, v);
                if (Math.Sqrt(d2) > r)
                    t1 = Double.PositiveInfinity;
            }
            else
            {
                t1 = Double.PositiveInfinity;
            }
            t2 = t1;
        }

        public override Vec3d findNormal(Vec3d _)
        {
            return this.V;
        }
    }
}
