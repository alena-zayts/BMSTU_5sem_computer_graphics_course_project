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
        public Material material;
        public bool moving;

        public Primitive(string name, Material material, bool moving)
        {
            this.name = name;
            this.material = material;
            this.moving = moving;
        }

        public virtual void RotateOY(Vec3 turn_point, double teta)
        {
            
        }

        public virtual void intersectRay(Vec3 camera_point, Vec3 view_vector, ref double t1, ref double t2)
        {

        }

        public virtual Vec3 findNormal(Vec3 P)
        {
            return null;
        }
    }
}
