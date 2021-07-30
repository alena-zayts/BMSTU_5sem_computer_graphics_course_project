using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weatherwane
{
    class Primitive
    {
        public string name;
        public Vec3d C;
        public Vec3d color;
        public double specular;
        public double reflective;
        public bool moving;
         
        public Primitive(string name, Vec3d C, Vec3d color, double specular, double reflective, bool moving)
        {
            this.name = name;
            this.C = C;
            this.color = color;
            this.specular = specular;
            this.reflective = reflective;
            this.moving = moving;
        }

        public virtual void RotateOY(Vec3d C, double teta)
        {
            this.C.RotateOY(C, teta);
        }
    }
}
