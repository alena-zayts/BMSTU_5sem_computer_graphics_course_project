using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weatherwane
{
    class Cylinder : Primitive
    {
        public Vec3d V;
        public double radius;
        public double maxm;
        public Cylinder(string name, Vec3d C, Vec3d V, double radius, double maxm,
            Material material, bool moving) : base (name, C, material, moving)
        {
            this.V = V;
            this.radius = radius;
            this.maxm = maxm;
        }

        public override void RotateOY(Vec3d C, double teta)
        {
            Vec3d zero = new Vec3d(0, 0, 0);
            this.C.RotateOY(C, teta);
            this.V.RotateOY(zero, teta);
        }
    }
}
