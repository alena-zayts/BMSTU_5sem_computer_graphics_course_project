using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weatherwane
{
    class TrianglePyramid : Primitive
    {
        public Vec3d A;
        public Vec3d B;
        public Vec3d P;
        public TrianglePyramid(string name, Vec3d P, Vec3d A, Vec3d B, Vec3d C,
            Material material, bool moving) : base(name, C, material, moving)
        {
            this.A = A;
            this.B = B;
            this.P = P;
        }
        public override void RotateOY(Vec3d C, double teta)
        {
            this.A.RotateOY(C, teta);
            this.B.RotateOY(C, teta);
            this.C.RotateOY(C, teta);
            this.P.RotateOY(C, teta);
        }
    }
}