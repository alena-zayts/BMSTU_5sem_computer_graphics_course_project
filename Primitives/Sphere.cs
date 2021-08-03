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
        public double radius;
        public Sphere(string name, Vec3d C, double r, Material material, bool moving) : base (name, C, material, moving)
        {
            this.radius = r;   
        }
    }
}
