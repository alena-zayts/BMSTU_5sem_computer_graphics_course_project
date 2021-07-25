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


        public void convertBackgroundReverse(Bitmap bmpBackground, int canvasWidth, int canvasHeight)
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

        public void convertBackground(Bitmap bmpBackground, int canvasWidth, int canvasHeight)
        {
            for (int i = 0; i < canvasWidth; i++)
            {
                for (int j = 0; j < canvasHeight; j++)
                {
                    Color color = bmpBackground.GetPixel(i, j);
                    
                    this.background[i, j] = new Vec3d(color.R, color.G, color.B);
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

             sceneObjects.Add(new Sphere("сфера_1", new Vec3d(0, 0, 0), 0.9, new Vec3d(234, 237, 230), 1000, 0.6));
                 sceneObjects.Add(new Sphere("сфера_2", new Vec3d(4.1, 0, 0), 0.9, new Vec3d(234, 237, 230), 1000, 0.6));
                 sceneObjects.Add(new Sphere("сфера_3", new Vec3d(0, 4.1, 0), 0.9, new Vec3d(234, 237, 230), 1000, 0.6));
                 sceneObjects.Add(new Sphere("сфера_4", new Vec3d(4.1, 4.1, 0), 0.9, new Vec3d(234, 237, 230), 1000, 0.6));
                 sceneObjects.Add(new Sphere("сфера_5", new Vec3d(0, 0, 4.1), 0.9, new Vec3d(234, 237, 230), 1000, 0));
                 sceneObjects.Add(new Sphere("сфера_6", new Vec3d(4.1, 0, 4.1), 0.9, new Vec3d(234, 237, 230), 1000, 0.6));
                 sceneObjects.Add(new Sphere("сфера_7", new Vec3d(0, 4.1, 4.1), 0.9, new Vec3d(234, 237, 230), 1000, 0.6));
                 sceneObjects.Add(new Sphere("сфера_8", new Vec3d(4.1, 4.1, 4.1), 0.9, new Vec3d(234, 237, 230), 1000, 0.6));
                 sceneObjects.Add(new Sphere("сфера_9", new Vec3d(2.05, 2.05, 2.05), 0.9, new Vec3d(234, 237, 230), 1000, 0.6));

                 sceneObjects.Add(new Cylinder("цилиндр_1", new Vec3d(0, 0, 0), new Vec3d(1, 0, 0), 0.165, 4.1, new Vec3d(234, 237, 230), 300, 0));
                 sceneObjects.Add(new Cylinder("цилиндр_2", new Vec3d(0, 0, 0), new Vec3d(0, 1, 0), 0.165, 4.1, new Vec3d(234, 237, 230), 300, 0));
                 sceneObjects.Add(new Cylinder("цилиндр_2", new Vec3d(0, 0, 0), new Vec3d(0, 0, 1), 0.165, 4.1, new Vec3d(234, 237, 230), 300, 0));
                 sceneObjects.Add(new Cylinder("цилиндр_3", new Vec3d(4.1, 0, 0), new Vec3d(0, 0, 1), 0.165, 4.1, new Vec3d(234, 237, 230), 300, 0));
                 sceneObjects.Add(new Cylinder("цилиндр_4", new Vec3d(4.1, 0, 0), new Vec3d(0, 1, 0), 0.165, 4.1, new Vec3d(234, 237, 230), 300, 0));
                 sceneObjects.Add(new Cylinder("цилиндр_5", new Vec3d(0, 4.1, 0), new Vec3d(1, 0, 0), 0.165, 4.1, new Vec3d(234, 237, 230), 300, 0));
                 sceneObjects.Add(new Cylinder("цилиндр_6", new Vec3d(0, 4.1, 0), new Vec3d(0, 0, 1), 0.165, 4.1, new Vec3d(234, 237, 230), 300, 0));
                 sceneObjects.Add(new Cylinder("цилиндр_7", new Vec3d(4.1, 4.1, 0), new Vec3d(0, 0, 1), 0.165, 4.1, new Vec3d(234, 237, 230), 300, 0));
                 sceneObjects.Add(new Cylinder("цилиндр_8",new Vec3d(0, 4.1, 4.1), new Vec3d(1, 0, 0), 0.165, 4.1, new Vec3d(234, 237, 230), 300, 0));
                 sceneObjects.Add(new Cylinder("цилиндр_9", new Vec3d(0, 0, 4.1), new Vec3d(1, 0, 0), 0.165, 4.1, new Vec3d(234, 237, 230), 300, 0));
                 sceneObjects.Add(new Cylinder("цилиндр_10", new Vec3d(0, 0, 4.1), new Vec3d(0, 1, 0), 0.165, 4.1, new Vec3d(234, 237, 230), 300, 0));
                 sceneObjects.Add(new Cylinder("цилиндр_11", new Vec3d(4.1, 0, 4.1), new Vec3d(0, 1, 0), 0.165, 4.1, new Vec3d(234, 237, 230), 300, 0));

                 Cylinder firstdiagonal = new Cylinder("цилиндр_13", new Vec3d(0, 0, 0), new Vec3d(1, 0, 0), 0.165, 4.1 * Math.Sqrt(3), new Vec3d(234, 237, 230), 300, 0);
                 TransformPrimitive.RotationOYVector(ref firstdiagonal.V, -35);
                 TransformPrimitive.RotationOZVector(ref firstdiagonal.V, 45);

                 Cylinder seconddiagonal = new Cylinder("цилиндр_14", new Vec3d(0, 0, 4.1), new Vec3d(1, 0, 0), 0.165, 4.1 * Math.Sqrt(3), new Vec3d(234, 237, 230), 300, 0);
                 TransformPrimitive.RotationOYVector(ref seconddiagonal.V, 35);
                 TransformPrimitive.RotationOZVector(ref seconddiagonal.V, 45);

                 Cylinder thirddiagonal = new Cylinder("цилиндр_15", new Vec3d(0, 4.1, 4.1), new Vec3d(1, 0, 0), 0.165, 4.1 * Math.Sqrt(3), new Vec3d(234, 237, 230), 300, 0);
                 TransformPrimitive.RotationOYVector(ref thirddiagonal.V, 35);
                 TransformPrimitive.RotationOZVector(ref thirddiagonal.V, -45);

            Cylinder fourthdiagonal = new Cylinder("цилиндр_16", new Vec3d(0, 4.1, 0), new Vec3d(1, 0, 0), 0.165, 4.1 * Math.Sqrt(3), new Vec3d(234, 237, 230), 300, 0);
            TransformPrimitive.RotationOYVector(ref fourthdiagonal.V, -35);
            TransformPrimitive.RotationOZVector(ref fourthdiagonal.V, -45);

            sceneObjects.Add(firstdiagonal);
             sceneObjects.Add(seconddiagonal);
             sceneObjects.Add(thirddiagonal);
            sceneObjects.Add(fourthdiagonal);


            for (int i = 0; i < sceneObjects.Count; i++)
              {


                 // TransformPrimitive.RotationOXVector(ref sceneObjects[i].C, 45);
                  TransformPrimitive.RotationOZVector(ref sceneObjects[i].C, 45);
                  TransformPrimitive.RotationOXVector(ref sceneObjects[i].C, 30);

                  TransformPrimitive.MoveVector(ref sceneObjects[i].C, 0, 3.4, 0);



                  if (sceneObjects[i] is Cylinder)
                  {
                      Cylinder tmp = (Cylinder)sceneObjects[i];


                     // TransformPrimitive.RotationOXVector(ref tmp.V, 45);
                      TransformPrimitive.RotationOZVector(ref tmp.V, 45);
                      TransformPrimitive.RotationOXVector(ref tmp.V, 30);


                      //TransformPrimitive.MoveVector(ref tmp.V, 0, 1, 0);
                      sceneObjects[i] = tmp;
                  }
              }


             AddCylinder("цилиндр_17", new Vec3d(0, 0, 3.55), new Vec3d(0, 1, 0), 1.3, 0.45, new Vec3d(234, 237, 230), 1000, 0);
               //sceneObjects.Add(new Sphere(new Vec3d(1, 4, 1), 2, new Vec3d(0, 255, 0), 1, 0));

            // sceneObjects.Add(new Cylinder(new Vec3d(0, 0, 5), new Vec3d(0, 1, 0), 2, 3, new Vec3d(0, 0, 255), 1, 0));
            // sceneObjects.Add(new Parallelepiped(new Vec3d(-2, 3, 7), new Vec3d(0, 6, -2), new Vec3d(255, 0, 0), 1, 0));

            //  sceneObjects.Add(new TrianglePyramid(new Vec3d(2, 2, 4), new Vec3d(0, 0, 0), new Vec3d(4, 0, 0), new Vec3d(0, 4, 0), new Vec3d(255, 255, 0), 1, 0.6));

            //sceneObjects.Add(new Parallelepiped("земля", new Vec3d(-100, -0.1, -100), new Vec3d(100, 0, 100), new Vec3d(0, 255, 0), 1, 0));
            //  sceneObjects.Add(new Cylinder("цилиндр_1", new Vec3d(0, 0, 0), new Vec3d(1, 0, 0), 0.1, 25, new Vec3d(255, 0, 0), 0, 0));
            //  sceneObjects.Add(new Cylinder("цилиндр_2", new Vec3d(0, 0, 0), new Vec3d(0, 1, 0), 0.1, 25, new Vec3d(0, 255, 0), 0, 0));
            //   sceneObjects.Add(new Cylinder("цилиндр_3", new Vec3d(0, 0, 0), new Vec3d(0, 0, 1), 0.1, 25, new Vec3d(0, 0, 255), 0, 0));

            //  sceneObjects.Add(new Cone("dd", new Vec3d(2, 2, 1), new Vec3d(0, -1, 0), Math.Tan(30 * Math.PI/ 180), 0, 4,  new Vec3d(255, 1, 0), 1, 0.5));

            sceneObjects.Add(new Plane("плоскость основания", new Vec3d(0, 0, 0), new Vec3d(0, 1, 0), new Vec3d(234, 237, 230), 1, 0));


            // AddCylinder("dd",new Vec3d(0, 1, 2), new Vec3d(0, 1, 0), 0.5, 2, new Vec3d(0, 255, 255), 1, 0);
            //  AddDiskPlane("dd", new Vec3d(0, 0, 0), new Vec3d(0, -1, 0), 0.5, new Vec3d(0, 255, 255), 1, 0);
            //   sceneObjects.Add(new Sphere("земля", new Vec3d(0, -5000, 0), 5000, new Vec3d(0, 255, 0), 0.5, 0));

            // sceneObjects.Add(new Cylinder(new Vec3d(0, 0, 0), new Vec3d(1, 0, 0), 0.5, 1000, new Vec3d(0, 0, 255), 1, 0));
            // sceneObjects.Add(new Cylinder(new Vec3d(0, 0, 0), new Vec3d(0, 1, 0), 0.5, 1000, new Vec3d(0, 255, 255), 1, 0));
            //  sceneObjects.Add(new Cylinder(new Vec3d(0, 0, 0), new Vec3d(0, 0, 1), 0.5, 1000, new Vec3d(255, 0, 0), 1, 0));

            //  sceneObjects.Add(new Triangle(new Vec3d(2, 2, 4), new Vec3d(0, 4, 0), new Vec3d(4, 4, 0), new Vec3d(255, 255, 0), 1, 0));
            //  sceneObjects.Add(new Triangle(new Vec3d(2, 2, 4), new Vec3d(4, 0, 0), new Vec3d(4, 4, 0), new Vec3d(255, 255, 0), 1, 0));
            //   sceneObjects.Add(new Triangle(new Vec3d(2, 2, 4), new Vec3d(0, 0, 0), new Vec3d(0, 4, 0), new Vec3d(255, 255, 0), 1, 0));
            //   sceneObjects.Add(new Triangle(new Vec3d(2, 2, 4), new Vec3d(0, 0, 0), new Vec3d(4, 0, 0), new Vec3d(255, 255, 0), 1, 0));

            // sceneObjects.Add(new Triangle(new Vec3d(0, 0, 0), new Vec3d(0, 4, 0), new Vec3d(4, 4, 0), new Vec3d(255, 255, 0), 1, 0));
            //   sceneObjects.Add(new Triangle(new Vec3d(0, 0, 0), new Vec3d(4, 0, 0), new Vec3d(4, 4, 0), new Vec3d(255, 255, 0), 1, 0));
            //sceneObjects.Add(new QuadPyramid(new Vec3d(2, 2, 4), new Vec3d(0, 0, 0), new Vec3d(4, 0, 0), new Vec3d(4, 4, 0), new Vec3d(0, 4, 0), new Vec3d(255, 255, 0), 1, 0.6));
            //      lights = new List<Light>();
            // sceneObjects.Add(new Parallelepiped(new Vec3d(0, -0.1, 0), new Vec3d(4, 0, 4), new Vec3d(255, 0, 0), 1, 0));

            lights.Add(new Light("фоновое освещение", LightType.Ambient, new Vec3d(0, 0, 0), 0.2));
            //lights.Add(new Light("точечный_1", LightType.Point, new Vec3d(2, 1, 0), 0));
            //   lights.Add(new Light(LightType.Point, new Vec3d(-5, 1, -1), 0.3));
            //  lights.Add(new Light(LightType.Point, new Vec3d(0, 1, 15), 0.5));

            // sceneObjects.Add(new Triangle("a1", new Vec3d(1, 0, -1), new Vec3d(1, 0, 1), new Vec3d(0, 3, 0), new Vec3d(0, 0, 255), 1, 0));

            // sceneObjects.Add(new Triangle("a2", new Vec3d(0, 0, 2), new Vec3d(0, 3, 2), new Vec3d(0, 3, 2), new Vec3d(0, 0, 255), 0, 1));

            //sceneObjects.Add(new Triangle("a3", new Vec3d(0, 0, 2), new Vec3d(4, 0, 2), new Vec3d(0, 3, 2), new Vec3d(0, 0, 255), 0, 1));

            //sceneObjects.Add(new Triangle("a4", new Vec3d(0, 0, 2), new Vec3d(4, 0, 2), new Vec3d(0, 3, 2), new Vec3d(0, 0, 255), 0, 1));

           // AddTrianglePyramid("a1", new Vec3d(1, 1, 0), new Vec3d(1, 1, 1), new Vec3d(1, 1, 2), new Vec3d(1, 1, 3), new Vec3d(0, 0, 255), 0, 1);

          //  AddQuadPyramid("a2", new Vec3d(2, 2, 0), new Vec3d(2, 1, 1), new Vec3d(2, 2, 2), new Vec3d(2, 2, 3), new Vec3d(2, 2, 4), new Vec3d(0, 0, 255), 0, 1);
            //AddTrianglePyramid("a3", new Vec3d(3, 3, 0), new Vec3d(3, 3, 1), new Vec3d(3, 3,  2), new Vec3d(3, 3, 3), new Vec3d(0, 0, 255), 0, 1);

           // AddQuadPyramid("a4", new Vec3d(4, 4, 0), new Vec3d(4, 4, 1), new Vec3d(4, 4, 2), new Vec3d(4, 4, 3), new Vec3d(4, 4, 4), new Vec3d(0, 0, 255), 0, 1);
            //AddTrianglePyramid("a1", new Vec3d(1, 1, 0), new Vec3d(1, 1, 1), new Vec3d(1, 1, 2), new Vec3d(1, 1, 3), new Vec3d(0, 0, 255), 0, 1);
            lights.Add(new Light("направленный (Солнце)", LightType.Directional, new Vec3d(1, 0, 0), 0.2));
        }

        public void AddSphere(string name, Vec3d C, double r, Vec3d color, double specular, double reflective)
        {
            sceneObjects.Add(new Sphere(name, C, r, color, specular, reflective));
        }
        public void AddCylinder(string name, Vec3d C, Vec3d V, double r, double maxm, Vec3d color, double specular, double reflective)
        {
            Cylinder cylinder = new Cylinder(name, C, V, r, maxm, color, specular, reflective);
            sceneObjects.Add(cylinder);
            AddDiskPlane(cylinder.name, cylinder.C, -cylinder.V, cylinder.radius, cylinder.color, cylinder.specular, cylinder.reflective);
            AddDiskPlane(cylinder.name, cylinder.C + cylinder.V * maxm, cylinder.V, cylinder.radius, cylinder.color, cylinder.specular, cylinder.reflective);
        }

        public void AddParallelepiped(string name, Vec3d C, Vec3d E, Vec3d color, double specular, double reflective)
        {
            sceneObjects.Add(new Parallelepiped(name, C, E, color, specular, reflective));
        }

        public void AddTrianglePyramid(string name, Vec3d P, Vec3d A, Vec3d B, Vec3d C, Vec3d color, double specular, double reflective)
        {
            AddTriangle(name, P, A, B, color, specular, reflective);
            AddTriangle(name, P, B, C, color, specular, reflective);
            AddTriangle(name, P, C, A, color, specular, reflective);
            AddTriangle(name, A, B, C, color, specular, reflective);
            sceneObjects.Add(new TrianglePyramid(name, P, A, B, C, color, specular, reflective));
        }

        public void AddTriangle(string name, Vec3d P, Vec3d A, Vec3d B, Vec3d color, double specular, double reflective)
        {
            sceneObjects.Add(new Triangle(name, P, A, B, color, specular, reflective));
        }

        public void AddPlane(string name, Vec3d C, Vec3d V, Vec3d color, double specular, double reflective)
        {
            sceneObjects.Add(new Plane(name, C, V, color, specular, reflective));
        }

        public void AddDiskPlane(string name, Vec3d C, Vec3d V, double r, Vec3d color, double specular, double reflective)
        {
            sceneObjects.Add(new DiskPlane(name, C, V, r, color, specular, reflective));
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

        public void ChangeLightIntensity(string name, double intensity)
        {
            for (int i = 0; i < lights.Count; i++)
            {
                if (lights[i].name == name)
                {
                    lights[i].intensity = intensity;
                    break;
                }
            }
        }

        public void ChangeLightPosition(string name, Vec3d position)
        {
            for (int i = 0; i < lights.Count; i++)
            {
                if (lights[i].name == name)
                {
                    lights[i].position = position;
                    break;
                }
            }
        }
    }
}