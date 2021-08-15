using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weatherwane
{
    class Camera
    {
        public Vec3 position;
        public Vec3 angle;
        public double[,] rotation;

        public Camera()
        {
            this.position = new Vec3(0, 0, 0);
            this.angle = new Vec3(0, 0, 0);
            this.rotation = new double[4, 4] { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };
        }

    }
}
