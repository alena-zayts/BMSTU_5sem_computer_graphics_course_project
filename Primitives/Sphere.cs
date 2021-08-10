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
        public Vec3d centre;
        public double radius;
        public Sphere(string name, Material material, bool moving, Vec3d centre, double r) : base (name, material, moving)
        {
            this.centre = centre;
            this.radius = r;   
        }

        public override void RotateOY(Vec3d turn_point, double teta)
        {
            this.centre.RotateOY(turn_point, teta);
        }

        public override void intersectRay(Vec3d O, Vec3d view_vector, ref double t1, ref double t2)
        {
            Vec3d CO = O - this.centre;

            double a = Vec3d.ScalarMultiplication(view_vector, view_vector);
            double b = 2 * Vec3d.ScalarMultiplication(CO, view_vector);
            double c = Vec3d.ScalarMultiplication(CO, CO) - this.radius * this.radius;


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

        public override Vec3d findNormal(Vec3d P)
        {
            Vec3d N = P - this.centre;
            return N;
        }
    }
}
