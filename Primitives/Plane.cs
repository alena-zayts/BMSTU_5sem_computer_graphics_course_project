using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weatherwane
{
    class Plane : Primitive
    {
        
        public Vec3d V;
        public Plane(string name, Vec3d C, Vec3d V, Material material, bool moving) : base (name, C, material, moving)
        {
            this.V = V;
        }

        public override void RotateOY(Vec3d C, double teta)
        {
            this.C.RotateOY(C, teta);
            this.V.RotateOY(C, teta);
        }
    }

    class DiskPlane : Primitive
    {

        public Vec3d V;
        public double r;
        public DiskPlane(string name, Vec3d C, Vec3d V, double r, Material material, bool moving) : base(name, C, material, moving)
        {
            this.V = V;
            this.r = r;
        }
        public override void RotateOY(Vec3d C, double teta)
        {
            Vec3d zero = new Vec3d(0, 0, 0);
            this.C.RotateOY(C, teta);
            this.V.RotateOY(zero, teta);
        }
    }
}
