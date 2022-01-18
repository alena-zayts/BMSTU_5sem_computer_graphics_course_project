using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weatherwane
{
    class Material
    {
        public Vec3 color;
        public double specular;
        public double reflective;

        public Material(Vec3 color, double specular, double reflective)
        {
            this.color = color;
            this.specular = specular;
            this.reflective = reflective;
        }

        public void update(Vec3 color, double specular, double reflective)
        {
            this.color = color;
            this.specular = specular;
            this.reflective = reflective;
        }
    }
}
