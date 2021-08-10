using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weatherwane
{
    class Triangle : Primitive
    {
        public Vec3d A;
        public Vec3d B;
        public Vec3d C;
        public Vec3d normal;

        public Triangle(string name, Material material, bool moving, 
            Vec3d A, Vec3d B, Vec3d C) : base(name, material, moving)
        {
            this.A = A;
            this.B = B;
            this.C = C;
 
            this.normal = Vec3d.VecMultiplication(this.A - this.C, this.B - this.C).Normalize();
        }

        public override void RotateOY(Vec3d turn_point, double teta)
        {
            Vec3d zero = new Vec3d(0, 0, 0);
            this.normal.RotateOY(zero, teta);

            this.A.RotateOY(turn_point, teta);
            this.B.RotateOY(turn_point, teta);
            this.C.RotateOY(turn_point, teta);
        }

        public override void intersectRay(Vec3d camera_point, Vec3d view_vector, ref double t1, ref double t2)
        {
            // векторы двух граней
            Vec3d edge1 = this.A - this.C;
            Vec3d edge2 = this.B - this.C;

            Vec3d pvec = Vec3d.VecMultiplication(view_vector, edge2);
            double det = Vec3d.ScalarMultiplication(edge1, pvec);

            // Луч параллелен пло кости
            if (det < 1e-8 && det > -1e-8)
            {
                t1 = Double.PositiveInfinity;
                t2 = t1;
                return;
            }

            double inv_det = 1.0 / det;
            Vec3d tvec = camera_point - this.C;

            // вычисляем и проверяем границы u
            double u = Vec3d.ScalarMultiplication(tvec, pvec) * inv_det;
            if (u < 0.0 || u > 1.0)
            {
                t1 = Double.PositiveInfinity;
                t2 = t1;
                return;
            }

            // вычисляем и проверяем границы v
            Vec3d qvec = Vec3d.VecMultiplication(tvec, edge1);
            double v = Vec3d.ScalarMultiplication(view_vector, qvec) * inv_det;
            if (v < 0 || u + v > 1)
            {
                t1 = Double.PositiveInfinity;
                t2 = t1;
                return;
            }

            t1 = Vec3d.ScalarMultiplication(edge2, qvec) * inv_det;
            t2 = t1;
        }

        public override Vec3d findNormal(Vec3d _)
        {
            return this.normal;
        }
    }
}