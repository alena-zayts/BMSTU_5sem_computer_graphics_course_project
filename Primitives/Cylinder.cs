using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weatherwane
{
    class Cylinder : Primitive
    {
        public Vec3d centre;
        public Vec3d V;
        public double radius;
        public double height;
        public Cylinder(string name, Material material, bool moving, 
            Vec3d centre, Vec3d V, double radius, double height) : base (name, material, moving)
        {
            this.centre = centre;
            this.V = V;
            this.radius = radius;
            this.height = height;
        }

        public override void RotateOY(Vec3d turn_point, double teta)
        {
            Vec3d zero_point = new Vec3d(0, 0, 0);
            this.V.RotateOY(zero_point, teta);

            this.centre.RotateOY(turn_point, teta);
        }

        public override void intersectRay(Vec3d camera_point, Vec3d view_direction, ref double t1, ref double t2)
        {
            Vec3d CO = camera_point - this.centre;

            double d_d = Vec3d.ScalarMultiplication(view_direction, view_direction);
            double d_co = Vec3d.ScalarMultiplication(view_direction, CO);
            double co_co = Vec3d.ScalarMultiplication(CO, CO);
            double d_v = Vec3d.ScalarMultiplication(view_direction, this.V);
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

            if (m1 < 0 || m1 > this.height)
            {
                t1 = Double.PositiveInfinity;
            }
            if (m2 < 0 || m2 > this.height)
            {
                t2 = Double.PositiveInfinity;
            }
        }
    }
}
