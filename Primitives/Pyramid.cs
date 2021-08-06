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
        public Vec3d D;
        public Vec3d P;
        public Pyramid(string name, Vec3d P, Vec3d A, Vec3d B, Vec3d C, Vec3d D,
            Material material, bool moving) : base(name, C, material, moving)
        {
            this.A = A;
            this.B = B;
            this.D = D;
            this.P = P;
        }
        public override void RotateOY(Vec3d C, double teta)
        {
            this.A.RotateOY(C, teta);
            this.B.RotateOY(C, teta);
            this.C.RotateOY(C, teta);
            this.D.RotateOY(C, teta);
            this.P.RotateOY(C, teta);
        }

        public override void intersectRay(Vec3d O, Vec3d D, ref double t1, ref double t2)
        {

        }

        public override Vec3d findNormal(Vec3d P)
        {
            Vec3d N = P - this.C;
            return N;
        }
    }
}
