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
        public Triangle(string name, Vec3d C, Vec3d A, Vec3d B,
            Material material, bool moving) : base(name, C, material, moving)
        {
            this.A = A;
            this.B = B;
        }

        public override void RotateOY(Vec3d C, double teta)
        {
            this.A.RotateOY(C, teta);
            this.B.RotateOY(C, teta);
            this.C.RotateOY(C, teta);
        }

        public override void intersectRay(Vec3d O, Vec3d D, ref double t1, ref double t2)
        {
            Vec3d e1 = this.A - this.C;
            Vec3d e2 = this.B - this.C;

            Vec3d pvec = new Vec3d(D.y * e2.z - D.z * e2.y, D.z * e2.x - D.x * e2.z, D.x * e2.y - D.y * e2.x);
            double det = Vec3d.ScalarMultiplication(e1, pvec);

            // Луч параллелен плоскости
            if (det < 1e-8 && det > -1e-8)
            {
                t1 = Double.PositiveInfinity;
                t2 = t1;
                return;
            }

            double inv_det = 1 / det;
            Vec3d tvec = O - this.C;
            double u = Vec3d.ScalarMultiplication(tvec, pvec) * inv_det;
            if (u < 0 || u > 1)
            {
                t1 = Double.PositiveInfinity;
                t2 = t1;
                return;
            }
            Vec3d qvec = new Vec3d(tvec.y * e1.z - tvec.z * e1.y, tvec.z * e1.x - tvec.x * e1.z, tvec.x * e1.y - tvec.y * e1.x);

            double v = Vec3d.ScalarMultiplication(D, qvec) * inv_det;

            if (v < 0 || u + v > 1)
            {
                t1 = Double.PositiveInfinity;
                t2 = t1;
                return;
            }

            t1 = Vec3d.ScalarMultiplication(e2, qvec) * inv_det;
            t2 = t1;
        }

        public override Vec3d findNormal(Vec3d _)
        {
            Vec3d e1 = this.A - this.C;
            Vec3d e2 = this.B - this.C;
            Vec3d normal = new Vec3d(e1.y * e2.z - e1.z * e2.y, e1.z * e2.x - e1.x * e2.z, e1.x * e2.y - e1.y * e2.x);
            double len_n = Vec3d.Length(normal);
            normal = normal / len_n;
            return normal;
        }
    }
}