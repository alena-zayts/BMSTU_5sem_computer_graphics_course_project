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

        public Triangle(string name, Material material, bool moving, 
            Vec3d A, Vec3d B, Vec3d C) : base(name, material, moving)
        {
            this.A = A;
            this.B = B;
            this.C = C;
        }

        public override void RotateOY(Vec3d turn_point, double teta)
        {
            this.A.RotateOY(turn_point, teta);
            this.B.RotateOY(turn_point, teta);
            this.C.RotateOY(turn_point, teta);
        }

        public override void intersectRay(Vec3d camera_point, Vec3d view_vector, ref double t1, ref double t2)
        {
            Vec3d e1 = this.A - this.C;
            Vec3d e2 = this.B - this.C;

            Vec3d pvec = new Vec3d(view_vector.y * e2.z - view_vector.z * e2.y, view_vector.z * e2.x - view_vector.x * e2.z, view_vector.x * e2.y - view_vector.y * e2.x);
            double det = Vec3d.ScalarMultiplication(e1, pvec);

            // Луч параллелен пло
            // кости
            if (det < 1e-8 && det > -1e-8)
            {
                t1 = Double.PositiveInfinity;
                t2 = t1;
                return;
            }

            double inv_det = 1 / det;
            Vec3d tvec = camera_point - this.C;
            double u = Vec3d.ScalarMultiplication(tvec, pvec) * inv_det;
            if (u < 0 || u > 1)
            {
                t1 = Double.PositiveInfinity;
                t2 = t1;
                return;
            }
            Vec3d qvec = new Vec3d(tvec.y * e1.z - tvec.z * e1.y, tvec.z * e1.x - tvec.x * e1.z, tvec.x * e1.y - tvec.y * e1.x);

            double v = Vec3d.ScalarMultiplication(view_vector, qvec) * inv_det;

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