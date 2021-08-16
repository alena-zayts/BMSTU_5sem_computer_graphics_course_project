using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weatherwane
{
    class Cylinder : Primitive
    {
        public Vec3 centre;
        public Vec3 V;
        public double radius;
        public double height;
        public Cylinder(string name, Material material, bool moving, 
            Vec3 centre, Vec3 V, double radius, double height) : base (name, material, moving)
        {
            this.centre = centre;
            this.V = V;
            this.radius = radius;
            this.height = height;
        }

        public override void RotateOY(Vec3 turn_point, double teta)
        {
            Vec3 zero_point = new Vec3(0, 0, 0);
            this.V.RotateOY(zero_point, teta);

            this.centre.RotateOY(turn_point, teta);
        }

        public override void intersectRay(Vec3 O, Vec3 view_direction, ref double t1, ref double t2)
        {
            Vec3 CO = O - this.centre;

            double d_d = Vec3.ScalarMultiplication(view_direction, view_direction);
            double d_v = Vec3.ScalarMultiplication(view_direction, this.V);
            double co_d = Vec3.ScalarMultiplication(CO, view_direction);
            double co_v = Vec3.ScalarMultiplication(CO, this.V);
            double co_co = Vec3.ScalarMultiplication(CO, CO);


            double a = d_d - d_v * d_v;
            double b = 2 * (co_d - co_v * d_v);
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


            double h1 = d_v * t1 + co_v;
            double h2 = d_v * t2 + co_v;

            if (h1 < 0 || h1 > this.height)
            {
                t1 = Double.PositiveInfinity;
            }
            if (h2 < 0 || h2 > this.height)
            {
                t2 = Double.PositiveInfinity;
            }
        }
        public override Vec3 findNormal(Vec3 P)
        {
            double zn = Vec3.ScalarMultiplication(V, V);

            Vec3 CP = P - centre;
            double ch = Vec3.ScalarMultiplication(V, CP);

            double t = ch / zn;

            Vec3 inters_point = t * V + centre;

            Vec3 N = P - inters_point;

            return N;
        }
    }
}
