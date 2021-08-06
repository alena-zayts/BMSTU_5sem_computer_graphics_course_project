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
        public bool moving;
        public Material material;

        public Primitive(string name, Vec3d C, Material material, bool moving)
        {
            this.name = name;
            this.C = C;
            this.moving = moving;
            this.material = material;
        }

        public virtual void RotateOY(Vec3d C, double teta)
        {
            this.C.RotateOY(C, teta);
        }

        public virtual void intersectRay(Vec3d O, Vec3d D, ref double t1, ref double t2)
        {

        }

        public virtual Vec3d findNormal(Vec3d P)
        {
            return null;
        }
    }
}
