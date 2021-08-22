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
        public Vec3 centre;
        public double radius;
        public Sphere(string name, Material material, bool moving, Vec3 centre, double r) : base (name, material, moving)
        {
            this.centre = centre;
            this.radius = r;   
        }

        public override void RotateOY(Vec3 turn_point, double teta)
        {
            this.centre.RotateOY(turn_point, teta);
        }

        public override void intersectRay(Vec3 O, Vec3 view_vector, ref double t1, ref double t2)
        {
            Vec3 CO = O - this.centre;

            double a = Vec3.ScalarMultiplication(view_vector, view_vector);
            double b = 2 * Vec3.ScalarMultiplication(CO, view_vector);
            double c = Vec3.ScalarMultiplication(CO, CO) - this.radius * this.radius;


            double discriminant = b * b - 4 * a * c;

            // нет пересечений
            if (discriminant < 0)
            {
                t1 = Double.PositiveInfinity;
                t2 = Double.PositiveInfinity;
                return;
            }
            double discriminant_sqrt = Math.Sqrt(discriminant);

            t1 = (-b + discriminant_sqrt) / (2 * a);
            t2 = (-b - discriminant_sqrt) / (2 * a);
        }

        public override Vec3 findNormal(Vec3 P)
        {
            Vec3 N = P - this.centre;
            return N;
        }
    }
}
