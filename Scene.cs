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

        public void AddSphere(string name, Vec3d C, double r, Vec3d color, double specular, double reflective, bool moving)
        {
            sceneObjects.Add(new Sphere(name, C, r, color, specular, reflective, moving));
        }
        public void AddCylinder(string name, Vec3d C, Vec3d V, double r, double maxm, Vec3d color, double specular, double reflective, bool moving)
        {
            Cylinder cylinder = new Cylinder(name, C, V, r, maxm, color, specular, reflective, moving);
            sceneObjects.Add(cylinder);
            AddDiskPlane(name, new Vec3d(C), -V, r, color, specular, reflective, moving);
            AddDiskPlane(name, C + V * maxm, new Vec3d(V), r, color, specular, reflective, moving);
        }

        public void AddParallelepiped(string name, Vec3d C, Vec3d E, Vec3d color, double specular, double reflective, bool moving)
        {
            sceneObjects.Add(new Parallelepiped(name, C, E, color, specular, reflective, moving));
        }

        public void AddTrianglePyramid(string name, Vec3d P, Vec3d A, Vec3d B, Vec3d C, Vec3d color, double specular, double reflective, bool moving)
        {
            AddTriangle(name, new Vec3d(P), new Vec3d(A), new Vec3d(B), color, specular, reflective, moving);
            AddTriangle(name, new Vec3d(P), new Vec3d(B), new Vec3d(C), color, specular, reflective, moving);
            AddTriangle(name, new Vec3d(P), new Vec3d(C), new Vec3d(A), color, specular, reflective, moving);
            AddTriangle(name, new Vec3d(A), new Vec3d(B), new Vec3d(C), color, specular, reflective, moving);
            sceneObjects.Add(new TrianglePyramid(name, P, A, B, C, color, specular, reflective, moving));
        }

        public void AddTriangle(string name, Vec3d P, Vec3d A, Vec3d B, Vec3d color, double specular, double reflective, bool moving)
        {
            sceneObjects.Add(new Triangle(name, P, A, B, color, specular, reflective, moving));
        }

        public void AddPlane(string name, Vec3d C, Vec3d V, Vec3d color, double specular, double reflective, bool moving)
        {
            sceneObjects.Add(new Plane(name, C, V, color, specular, reflective, moving));
        }

        public void AddDiskPlane(string name, Vec3d C, Vec3d V, double r, Vec3d color, double specular, double reflective, bool moving)
        {
            sceneObjects.Add(new DiskPlane(name, C, V, r, color, specular, reflective, moving));
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