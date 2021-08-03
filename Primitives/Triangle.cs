using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weatherwane
{
    class Triangle : Primitive
    {
        public Vec3d A;
        public Vec3d B;
        public Triangle(string name, Vec3d C, Vec3d A, Vec3d B,
            Material material, bool moving) : base(name, C, material, moving)
        {
            this.A = A;
            this.B = B;
        }

        public override void RotateOY(Vec3d C, double teta)
        {
            this.A.RotateOY(C, teta);
            this.B.RotateOY(C, teta);
            this.C.RotateOY(C, teta);
        }
    }
}