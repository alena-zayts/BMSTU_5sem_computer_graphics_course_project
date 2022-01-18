using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weatherwane
{
    class Pyramid : Primitive
    {
        public Vec3 A;
        public Vec3 B;
        public Vec3 C;
        public Vec3 D;
        public Vec3 P;
        public Pyramid(string name, Material material, bool moving, 
            Vec3 P, Vec3 A, Vec3 B, Vec3 C, Vec3 D) : base(name, material, moving)
        {
            this.A = A;
            this.B = B;
            this.C = C;
            this.D = D;
            this.P = P;
        }
        public override void RotateOY(Vec3 turn_point, double teta)
        {

        }

        public override void intersectRay(Vec3 camera_point, Vec3 view_vector, ref double t1, ref double t2)
        {

        }

        public override Vec3 findNormal(Vec3 P)
        {
            return null;
        }
    }
}
