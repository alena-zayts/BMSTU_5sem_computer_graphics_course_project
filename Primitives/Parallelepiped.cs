using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weatherwane
{
    class Parallelepiped : Primitive
    {
        public Vec3d E;
        public Parallelepiped(string name, Vec3d C, Vec3d E,
            Material material, bool moving) : base(name, C, material, moving)
        {
            this.E = E;
        }

        public override void RotateOY(Vec3d C, double teta)
        {
            this.C.RotateOY(C, teta);
            this.E.RotateOY(C, teta);
        }
    }
}