using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weatherwane
{
    class Vec3
    {
        public double x, y, z;
        
        public Vec3()
        {
            this.x = 0;
            this.y = 0;
            this.z = 0;
        }
        public Vec3(Vec3 vec)
        {
            this.x = vec.x;
            this.y = vec.y;
            this.z = vec.z;
        }
        public Vec3(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Vec3 operator +(Vec3 v1, Vec3 v2)
        {
            return new Vec3 { x = v1.x + v2.x, y = v1.y + v2.y, z = v1.z + v2.z };
        }

        public static Vec3 operator / (Vec3 v1, double k)
        {
            return new Vec3 { x = v1.x / k, y = v1.y / k, z = v1.z / k };
        }

        public static Vec3 operator -(Vec3 v1, Vec3 v2)
        {
            return new Vec3 { x = v1.x - v2.x, y = v1.y - v2.y, z = v1.z - v2.z };
        }
        public static Vec3 operator -(Vec3 v)
        {
            return new Vec3 { x = -v.x, y = -v.y, z = -v.z };
        }

        public static Vec3 operator *(Vec3 v, double k)
        {
            return new Vec3 { x = v.x * k, y = v.y * k, z = v.z * k };
        }

        public static Vec3 operator *(Vec3 v, double[,] mtr)
        {
            double[] tmp = new double[4] { v.x, v.y, v.z, 1 };
            double[] result = new double[4] { 0, 0, 0, 0 };

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    result[i] += tmp[j] * mtr[i, j];
                }
            }

            return new Vec3 { x = result[0], y = result[1], z = result[2] };
        }
        public static Vec3 operator *(double k, Vec3 v)
        {
            return new Vec3 { x = v.x * k, y = v.y * k, z = v.z * k };
        }

        public static double operator *(Vec3 a, Vec3 b)
        {
            return a.x* b.x + a.y * b.y + a.z * b.z;
        }

        public static double ScalarMultiplication(Vec3 a, Vec3 b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z;
        }

        public static Vec3 VecMultiplication(Vec3 a, Vec3 b)
        {
            Vec3 result = new Vec3();
            result.x = a.y * b.z - a.z * b.y;
            result.y = a.z * b.x - a.x * b.z;
            result.z = a.x * b.y - a.y * b.x;
            return result;

        }

        public static double Length(Vec3 vec)
        {
            return Math.Sqrt(vec.x * vec.x + vec.y*vec.y + vec.z * vec.z);
        }

        public Vec3 Normalize()
        {
            double length_vec = Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z);
            return new Vec3(this.x / length_vec, this.y / length_vec, this.z / length_vec);
        }

        public void RotateOY(Vec3 C, double teta)
        {

            double d = teta * Math.PI / 180;
            double tmp_x;
            tmp_x = C.x + (this.x - C.x) * Math.Cos(d) + (this.z - C.z) * Math.Sin(d);
            this.z = C.z - (this.x - C.x) * Math.Sin(d) + (this.z - C.z) * Math.Cos(d);
            this.x = tmp_x;
        }
    }
}
