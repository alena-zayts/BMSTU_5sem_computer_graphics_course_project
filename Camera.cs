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
        public double[,] rotation_mtrx;

        public Camera()
        {
            this.position = new Vec3(0, 0, 0);
            this.angle = new Vec3(0, 0, 0);
            this.rotation_mtrx = new double[4, 4] { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };
        }
        private double[,] multMatrix(double[,] A, double[,] B)
        {
            double[,] result = new double[4, 4] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 4; k++)
                        result[i, j] += A[i, k] * B[k, j];
                }

            }
            return result;
        }

        public void turnX(double angle)
        {
            double[,] RMtr = new double[4, 4] { { 1, 0, 0, 0 },
                                                { 0, Math.Cos(angle * Math.PI / 180), -Math.Sin(angle * Math.PI / 180), 0 },
                                                { 0, Math.Sin(angle * Math.PI / 180), Math.Cos(angle * Math.PI / 180), 0 },
                                                { 0, 0, 0, 1 } };
            double[,] tmp = multMatrix(this.rotation_mtrx, RMtr);
            this.rotation_mtrx = tmp;
            this.angle.x += angle;
        }
        public void turnY(double angle)
        {
            double[,] RMtr = new double[4, 4] { { Math.Cos(angle * Math.PI / 180), 0, -Math.Sin(angle * Math.PI / 180), 0 },
                                                { 0, 1, 0, 0 },
                                                { Math.Sin(angle * Math.PI / 180), 0, Math.Cos(angle * Math.PI / 180), 0 },
                                                { 0, 0, 0, 1 } };
            double[,] tmp = multMatrix(this.rotation_mtrx, RMtr);
            this.rotation_mtrx = tmp;
            this.angle.y += angle;
        }
        public void turnZ(double angle)
        {
            double[,] RMtr = new double[4, 4] { { Math.Cos(angle * Math.PI / 180), -Math.Sin(angle * Math.PI / 180), 0, 0 },
                                                { Math.Sin(angle * Math.PI / 180), Math.Cos(angle * Math.PI / 180), 0, 0 },
                                                { 0, 0, 1, 0 },
                                                { 0, 0, 0, 1 } };

            double[,] tmp = multMatrix(this.rotation_mtrx, RMtr);
            this.rotation_mtrx = tmp;
            this.angle.z += angle;
        }

        public void move(Vec3 d)
        {
            this.position += d;
        }

    }
}
