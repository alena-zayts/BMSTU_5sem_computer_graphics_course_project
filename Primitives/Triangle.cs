using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weatherwane
{
    class Triangle : Primitive
    {
        public Vec3 A;
        public Vec3 B;
        public Vec3 C;
        public Vec3 normal;

        public Triangle(string name, Material material, bool moving, 
            Vec3 A, Vec3 B, Vec3 C) : base(name, material, moving)
        {
            this.A = A;
            this.B = B;
            this.C = C;
 
            this.normal = Vec3.VecMultiplication(this.A - this.C, this.B - this.C).Normalize();
        }

        public override void RotateOY(Vec3 turn_point, double teta)
        {
            Vec3 zero = new Vec3(0, 0, 0);
            this.normal.RotateOY(zero, teta);

            this.A.RotateOY(turn_point, teta);
            this.B.RotateOY(turn_point, teta);
            this.C.RotateOY(turn_point, teta);
        }

        public override void intersectRay(Vec3 camera_point, Vec3 view_vector, ref double t1, ref double t2)
        {
            // векторы двух граней
            Vec3 edge1 = this.A - this.C;
            Vec3 edge2 = this.B - this.C;

            Vec3 pvec = Vec3.VecMultiplication(view_vector, edge2);
            double det = Vec3.ScalarMultiplication(edge1, pvec);

            // Луч параллелен пло кости
            if (det < 1e-8 && det > -1e-8)
            {
                t1 = Double.PositiveInfinity;
                t2 = t1;
                return;
            }

            double inv_det = 1.0 / det;
            Vec3 tvec = camera_point - this.C;

            // вычисляем и проверяем границы u
            double u = Vec3.ScalarMultiplication(tvec, pvec) * inv_det;
            if (u < 0.0 || u > 1.0)
            {
                t1 = Double.PositiveInfinity;
                t2 = t1;
                return;
            }

            // вычисляем и проверяем границы v
            Vec3 qvec = Vec3.VecMultiplication(tvec, edge1);
            double v = Vec3.ScalarMultiplication(view_vector, qvec) * inv_det;
            if (v < 0 || u + v > 1)
            {
                t1 = Double.PositiveInfinity;
                t2 = t1;
                return;
            }

            t1 = Vec3.ScalarMultiplication(edge2, qvec) * inv_det;
            t2 = t1;
        }

        public override Vec3 findNormal(Vec3 _)
        {
            return this.normal;
        }
    }
}