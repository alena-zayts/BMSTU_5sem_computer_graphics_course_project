using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weatherwane
{
    class Parallelepiped : Primitive
    {
        public double xl, xr;
        public double yu, yd;
        public double zf, zn;

        public Parallelepiped(string name, Material material, bool moving, 
            double xl, double xr, double yu, double yd, double zf, double zn) : base(name, material, moving)
        {
            this.xl = xl;
            this.xr = xr;
            this.yu = yu;
            this.yd = yd;
            this.zf = zf;
            this.zn = zn;
        }

        public override void RotateOY(Vec3 turn_point, double teta)
        {

        }

        public override void intersectRay(Vec3 camera_point, Vec3 view_direction, ref double t1ret, ref double t2ret)
        { 

        }

        public override Vec3 findNormal(Vec3 P)
        {
            return null;
        }
    }
}