using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weatherwane
{
    class Plane : Primitive
    {
        public Vec3d C;
        public Vec3d V;
        public Plane(string name, Material material, bool moving, Vec3d C, Vec3d V) : base (name, material, moving)
        {
            this.C = C;
            this.V = V;
        }

        public override void RotateOY(Vec3d turn_point, double teta)
        {
            Vec3d zero = new Vec3d(0, 0, 0);
            this.V.RotateOY(zero, teta);

            this.C.RotateOY(turn_point, teta);
        }

        public override void intersectRay(Vec3d O, Vec3d view_vector, ref double t1, ref double t2)
        {
            Vec3d OC = this.C - O;

            double v_d = Vec3d.ScalarMultiplication(this.V, view_vector);
            double v_oc = Vec3d.ScalarMultiplication(this.V, OC);

            if (v_d < 0 || v_d > 0)
            {
                t1 = v_oc / v_d;
                // пересечение за камерой
                if (t1 < 0)
                    t1 = Double.PositiveInfinity;

            }
            // пересечений нет
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
        public DiskPlane(string name, Material material, bool moving, Vec3d C, Vec3d V, double r) : base(name, material, moving, C, V)
        {
            this.r = r;
        }

        public override void RotateOY(Vec3d turn_point, double teta)
        {
            Vec3d zero = new Vec3d(0, 0, 0);
            this.V.RotateOY(zero, teta);

            this.C.RotateOY(turn_point, teta);
        }

        public override void intersectRay(Vec3d O, Vec3d view_vector, ref double t1, ref double t2)
        {
            Plane tmp = new Plane("", this.material, this.moving, this.C, this.V);
            tmp.intersectRay(O, view_vector, ref t1, ref t2);

            if (t1 != Double.PositiveInfinity)
            {
                Vec3d intersection_point = O + view_vector * t1;
                Vec3d dist = intersection_point - this.C;
                double d2 = Vec3d.ScalarMultiplication(dist, dist);
                if (Math.Sqrt(d2) > r)
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
