using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Weatherwane
{
    class Scene
    {
        public int canvasWidth { get; private set; }
        public int canvasHeight { get; private set; }
        public Bitmap bmpBackground = new Bitmap(@"C:\msys64\home\alena\last_course\nebo.png", true);
        public Vec3d[,] background;

        public Camera camera { get; set; }
        public List<Primitive> sceneObjects { get; set; }
        public List<Light> lights { get; set; }
        public int countPointLights = 0;

        public void convertBackground(Bitmap bmpBackground, int canvasWidth, int canvasHeight)
        {
            for (int i = 0; i < canvasWidth; i++)
            {
                for (int j = 0; j < canvasHeight; j++)
                {
                    Color color = bmpBackground.GetPixel(i, j);

                    this.background[i, canvasHeight - j - 1] = new Vec3d(color.R, color.G, color.B);
                }
            }
        }
        public Scene(int canvasWidth, int canvasHeight)
        {
            this.canvasWidth = canvasWidth;
            this.canvasHeight = canvasHeight;
            background = new Vec3d[canvasWidth, canvasHeight];
            convertBackground(this.bmpBackground, canvasWidth, canvasHeight);

            camera = new Camera();
            sceneObjects = new List<Primitive>();
            lights = new List<Light>();
        }

        public void AddSphere(string name, Material material, bool moving, Vec3d centre, double radius)
        {
            sceneObjects.Add(new Sphere(name, material, moving, centre, radius));
        }
        public void AddCylinder(string name, Material material, bool moving, Vec3d centre, Vec3d V, double radius, double height)
        {
            Cylinder cylinder = new Cylinder(name, material, moving, centre, V, radius, height);
            sceneObjects.Add(cylinder);
            AddDiskPlane(name, material, moving, new Vec3d(centre), -V, radius);
            AddDiskPlane(name, material, moving, centre + V * height, new Vec3d(V), radius);
        }

        public void AddParallelepiped(string name, Material material, bool moving, double xl, double xr, double yu, double yd, double zf, double zn)
        {
            Vec3d A = new Vec3d(xl, yd, zn);
            Vec3d B = new Vec3d(xl, yd, zf);
            Vec3d C = new Vec3d(xr, yd, zf);
            Vec3d D = new Vec3d(xr, yd, zn);

            Vec3d E = new Vec3d(xl, yu, zn);
            Vec3d F = new Vec3d(xl, yu, zf);
            Vec3d G = new Vec3d(xr, yu, zf);
            Vec3d H = new Vec3d(xr, yu, zn);

            // down
            AddTriangle(name, material, moving, new Vec3d(A), new Vec3d(B), new Vec3d(C));
            AddTriangle(name, material, moving, new Vec3d(A), new Vec3d(C), new Vec3d(D));
            //up
            AddTriangle(name, material, moving, new Vec3d(E), new Vec3d(F), new Vec3d(G));
            AddTriangle(name, material, moving, new Vec3d(E), new Vec3d(G), new Vec3d(H));
            //left
            AddTriangle(name, material, moving, new Vec3d(A), new Vec3d(E), new Vec3d(F));
            AddTriangle(name, material, moving, new Vec3d(A), new Vec3d(F), new Vec3d(B));
            //right
            AddTriangle(name, material, moving, new Vec3d(D), new Vec3d(H), new Vec3d(G));
            AddTriangle(name, material, moving, new Vec3d(D), new Vec3d(G), new Vec3d(C));
            //near
            AddTriangle(name, material, moving, new Vec3d(A), new Vec3d(E), new Vec3d(H));
            AddTriangle(name, material, moving, new Vec3d(A), new Vec3d(H), new Vec3d(D));
            //far
            AddTriangle(name, material, moving, new Vec3d(B), new Vec3d(G), new Vec3d(F));
            AddTriangle(name, material, moving, new Vec3d(B), new Vec3d(C), new Vec3d(G));

            sceneObjects.Add(new Parallelepiped(name, material, moving, xl, xr, yu, yd, zf, zn));
        }

        public void AddPyramid(string name, Material material, bool moving, Vec3d P, Vec3d A, Vec3d B, Vec3d C, Vec3d D)
        {

            AddTriangle(name, material, moving, new Vec3d(P), new Vec3d(A), new Vec3d(B));
            AddTriangle(name, material, moving, new Vec3d(P), new Vec3d(B), new Vec3d(C));
            AddTriangle(name, material, moving, new Vec3d(P), new Vec3d(C), new Vec3d(D));
            AddTriangle(name, material, moving, new Vec3d(P), new Vec3d(D), new Vec3d(A));
            AddTriangle(name, material, moving, new Vec3d(A), new Vec3d(B), new Vec3d(D));
            AddTriangle(name, material, moving, new Vec3d(B), new Vec3d(C), new Vec3d(D));
            sceneObjects.Add(new Pyramid(name, material, moving, P, A, B, C, D));
        }

        public void AddTriangle(string name, Material material, bool moving, Vec3d P, Vec3d A, Vec3d B)
        {
            sceneObjects.Add(new Triangle(name, material, moving, P, A, B));
        }

        public void AddPlane(string name, Material material, bool moving, Vec3d C, Vec3d V)
        {
            sceneObjects.Add(new Plane(name, material, moving, C, V));
        }

        public void AddDiskPlane(string name, Material material, bool moving, Vec3d C, Vec3d V, double radius)
        {
            sceneObjects.Add(new DiskPlane(name, material, moving, C, V, radius));
        }

        public void AddLightPoint(Vec3d position, double intensity)
        {
            countPointLights += 1;
            lights.Add(new Light("точечный_" + countPointLights, LightType.Point, position, intensity));
        }

        public void UpdateLightPointName()
        {
            int j = 1;
            for (int i = 0; i < lights.Count; i++)
            {
                if (lights[i].ltype == LightType.Point)
                {
                    lights[i].name = "точечный_" + j;
                    j++;
                }
            }
        }

        public void RemoveLightPoint(string name)
        {
            for (int i = 0; i < lights.Count; i++)
            {
                if (lights[i].name == name)
                {
                    lights.RemoveRange(i, 1);
                    break;
                }
            }
            countPointLights -= 1;
            UpdateLightPointName();
        }
    }
}