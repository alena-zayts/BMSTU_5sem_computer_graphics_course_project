using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weatherwane
{
    class Sphere : Primitive
    {
        public double radius;
        public Sphere(string name, Vec3d C, double r, Material material, bool moving) : base (name, C, material, moving)
        {
            this.radius = r;   
        }
        public override void intersectRay(Vec3d O, Vec3d D, ref double t1, ref double t2)
        {
            Vec3d CO = O - this.C;

            double a = Vec3d.ScalarMultiplication(D, D);
            double b = 2 * Vec3d.ScalarMultiplication(CO, D);
            double c = Vec3d.ScalarMultiplication(CO, CO) - this.radius * this.radius;


            double discriminant = b * b - 4 * a * c;

            if (discriminant < 0)
            {
                t1 = Double.PositiveInfinity;
                t2 = Double.PositiveInfinity;
                return;
            }

            t1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
            t2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
        }

        public override Vec3d findNormal(Vec3d P)
        {
            Vec3d N = P - this.C;
            return N;
        }
    }
}
