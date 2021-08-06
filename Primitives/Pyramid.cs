using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weatherwane
{
    class Pyramid : Primitive
    {
        public Vec3d A;
        public Vec3d B;
        public Vec3d C;
        public Vec3d D;
        public Vec3d P;
        public Pyramid(string name, Material material, bool moving, 
            Vec3d P, Vec3d A, Vec3d B, Vec3d C, Vec3d D) : base(name, material, moving)
        {
            this.A = A;
            this.B = B;
            this.C = C;
            this.D = D;
            this.P = P;
        }
        public override void RotateOY(Vec3d turn_point, double teta)
        {

        }

        public override void intersectRay(Vec3d camera_point, Vec3d view_vector, ref double t1, ref double t2)
        {

        }

        public override Vec3d findNormal(Vec3d P)
        {
            return null;
        }
    }
}
