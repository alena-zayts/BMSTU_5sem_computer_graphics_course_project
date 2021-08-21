using System.Collections.Generic;
using System.Drawing;

namespace Weatherwane
{
    class Scene
    {
        public int canvasWidth { get; private set; }
        public int canvasHeight { get; private set; }
        public Vec3[,] background;

        public Camera camera { get; set; }
        public List<Primitive> primitives { get; set; }
        public List<Light> lights { get; set; }

        private int countPointLights = 0;
        private int countDirectionalLights = 0;
        private Bitmap bmpBackground = new Bitmap(@"C:\msys64\home\alena\last_course\Weatherwane\meta\nebo.png", true);

        public Scene(int canvasWidth, int canvasHeight)
        {
            this.canvasWidth = canvasWidth;
            this.canvasHeight = canvasHeight;
            background = new Vec3[canvasWidth, canvasHeight];
            convertBackground(this.bmpBackground, canvasWidth, canvasHeight);

            camera = new Camera();
            primitives = new List<Primitive>();
            lights = new List<Light>();
        }

        private void convertBackground(Bitmap bmpBackground, int canvasWidth, int canvasHeight)
        {
            for (int i = 0; i < canvasWidth; i++)
            {
                for (int j = 0; j < canvasHeight; j++)
                {
                    Color color = bmpBackground.GetPixel(i, j);

                    this.background[i, canvasHeight - j - 1] = new Vec3(color.R, color.G, color.B);
                }
            }
        }

        private void UpdateLightsName()
        {
            int p = 1;
            int d = 1;
            for (int i = 0; i < lights.Count; i++)
            {
                if (lights[i].ltype == LightTypes.Point)
                {
                    lights[i].name = "точечный_" + ++p;
                }
                else if (lights[i].ltype == LightTypes.Directional)
                {
                    lights[i].name = "направленный_" + ++d;
                }
            }
        }

        public void AddSphere(string name, Material material, bool moving, Vec3 centre, double radius)
        {
            primitives.Add(new Sphere(name, material, moving, centre, radius));
        }
        public void AddCylinder(string name, Material material, bool moving, Vec3 centre, Vec3 V, double radius, double height)
        {
            Cylinder cylinder = new Cylinder(name, material, moving, centre, V, radius, height);
            primitives.Add(cylinder);
            AddDiskPlane(name, material, moving, new Vec3(centre), -V, radius);
            AddDiskPlane(name, material, moving, centre + V * height, new Vec3(V), radius);
        }

        public void AddParallelepiped(string name, Material material, bool moving, double xl, double xr, double yu, double yd, double zf, double zn)
        {
            Vec3 A = new Vec3(xl, yd, zn);
            Vec3 B = new Vec3(xl, yd, zf);
            Vec3 C = new Vec3(xr, yd, zf);
            Vec3 D = new Vec3(xr, yd, zn);

            Vec3 E = new Vec3(xl, yu, zn);
            Vec3 F = new Vec3(xl, yu, zf);
            Vec3 G = new Vec3(xr, yu, zf);
            Vec3 H = new Vec3(xr, yu, zn);

            // down
            AddTriangle(name, material, moving, new Vec3(A), new Vec3(B), new Vec3(C));
            AddTriangle(name, material, moving, new Vec3(A), new Vec3(C), new Vec3(D));
            //up
            AddTriangle(name, material, moving, new Vec3(E), new Vec3(F), new Vec3(G));
            AddTriangle(name, material, moving, new Vec3(E), new Vec3(G), new Vec3(H));
            //left
            AddTriangle(name, material, moving, new Vec3(A), new Vec3(E), new Vec3(F));
            AddTriangle(name, material, moving, new Vec3(A), new Vec3(F), new Vec3(B));
            //right
            AddTriangle(name, material, moving, new Vec3(D), new Vec3(H), new Vec3(G));
            AddTriangle(name, material, moving, new Vec3(D), new Vec3(G), new Vec3(C));
            //near
            AddTriangle(name, material, moving, new Vec3(A), new Vec3(E), new Vec3(H));
            AddTriangle(name, material, moving, new Vec3(A), new Vec3(H), new Vec3(D));
            //far
            AddTriangle(name, material, moving, new Vec3(B), new Vec3(G), new Vec3(F));
            AddTriangle(name, material, moving, new Vec3(B), new Vec3(C), new Vec3(G));

            primitives.Add(new Parallelepiped(name, material, moving, xl, xr, yu, yd, zf, zn));
        }

        public void AddPyramid(string name, Material material, bool moving, Vec3 P, Vec3 A, Vec3 B, Vec3 C, Vec3 D)
        {

            AddTriangle(name, material, moving, new Vec3(P), new Vec3(A), new Vec3(B));
            AddTriangle(name, material, moving, new Vec3(P), new Vec3(B), new Vec3(C));
            AddTriangle(name, material, moving, new Vec3(P), new Vec3(C), new Vec3(D));
            AddTriangle(name, material, moving, new Vec3(P), new Vec3(D), new Vec3(A));
            AddTriangle(name, material, moving, new Vec3(A), new Vec3(B), new Vec3(D));
            AddTriangle(name, material, moving, new Vec3(B), new Vec3(C), new Vec3(D));
            primitives.Add(new Pyramid(name, material, moving, P, A, B, C, D));
        }

        private void AddTriangle(string name, Material material, bool moving, Vec3 P, Vec3 A, Vec3 B)
        {
            primitives.Add(new Triangle(name, material, moving, P, A, B));
        }

        public void AddPlane(string name, Material material, bool moving, Vec3 C, Vec3 V)
        {
            primitives.Add(new Plane(name, material, moving, C, V));
        }

        private void AddDiskPlane(string name, Material material, bool moving, Vec3 C, Vec3 V, double radius)
        {
            primitives.Add(new DiskPlane(name, material, moving, C, V, radius));
        }

        public void AddLight(Vec3 position, double intensity, LightTypes ltype)
        {
            if (ltype == LightTypes.Point)
            {
                countPointLights += 1;
                lights.Add(new Light("точечный_" + (countPointLights + 1), LightTypes.Point, position, intensity));
            }
            else if (ltype == LightTypes.Directional)
            {
                countDirectionalLights += 1;
                lights.Add(new Light("направленный_" + (countDirectionalLights + 1), LightTypes.Directional, position, intensity));
            }
        }

        public void RemoveLight(string name)
        {
            for (int i = 0; i < lights.Count; i++)
            {
                if (lights[i].name == name)
                {
                    if (lights[i].ltype == LightTypes.Point)
                    {
                        countPointLights -= 1;
                    }
                    else
                    {
                        countDirectionalLights -= 1;
                    }
                    lights.RemoveRange(i, 1);
                    UpdateLightsName();
                    return;
                }
            }

        }
    }
}