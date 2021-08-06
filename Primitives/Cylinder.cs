using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weatherwane
{
    class Cylinder : Primitive
    {
        public Vec3d V;
        public double radius;
        public double maxm;
        public Cylinder(string name, Vec3d C, Vec3d V, double radius, double maxm,
            Material material, bool moving) : base (name, C, material, moving)
        {
            this.V = V;
            this.radius = radius;
            this.maxm = maxm;
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

            double d_d = Vec3d.ScalarMultiplication(D, D);
            double d_co = Vec3d.ScalarMultiplication(D, CO);
            double co_co = Vec3d.ScalarMultiplication(CO, CO);
            double d_v = Vec3d.ScalarMultiplication(D, this.V);
            double co_v = Vec3d.ScalarMultiplication(CO, this.V);

            double a = d_d - d_v * d_v;
            double b = 2 * (d_co - d_v * co_v);
            double c = co_co - co_v * co_v - this.radius * this.radius;


            double discriminant = b * b - 4 * a * c;

            if (discriminant < 0)
            {
                t1 = Double.PositiveInfinity;
                t2 = Double.PositiveInfinity;
                return;
            }

            t1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
            t2 = (-b - Math.Sqrt(discriminant)) / (2 * a);


            double m1 = d_v * t1 + co_v;
            double m2 = d_v * t2 + co_v;

            if (m1 < 0 || m1 > this.maxm)
            {
                t1 = Double.PositiveInfinity;
            }
            if (m2 < 0 || m2 > this.maxm)
            {
                t2 = Double.PositiveInfinity;
            }
        }
    }
}
