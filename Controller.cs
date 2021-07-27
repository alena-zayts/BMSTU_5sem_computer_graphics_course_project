using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Weatherwane
{
    // Вспомогательный класс для распараллеливания.
    public class Limit
    {
        public Int32 begin;
        public Int32 end;
        public Bitmap img;
        public Limit(Int32 begin, Int32 end, Bitmap img) { this.begin = begin; this.end = end; this.img = img; }
    }

    class Controller
    {
        private int n = 3;
        private Scene scene;
        private Scene sceneOXYZ;
        private RayTracer rayTracer;
        private RayTracer rayTracerOXYZ;
        private LoadScene loaderScene;
        private SaveScene saverScene;
        private CameraManager cameraManager;

        private Bitmap tmp;
        private Bitmap tmp_axes;
        private Bitmap[] arrBitmap;
        public Controller(int canvasWidth, int canvasHeight)
        {
            this.scene = new Scene(canvasWidth, canvasHeight);
            this.rayTracer = new RayTracer(this.scene);
            this.loaderScene = new LoadScene();
            this.saverScene = new SaveScene();
            this.cameraManager = new CameraManager();


            this.sceneOXYZ = new Scene(canvasWidth, canvasHeight);
            this.sceneOXYZ.lights.RemoveRange(1, 1);
            this.sceneOXYZ.lights[0].intensity = 1;
            this.sceneOXYZ.sceneObjects.Clear();
            this.sceneOXYZ.AddCylinder("OX", new Vec3d(0, 0, 0), new Vec3d(1, 0, 0), 0.05, 500, new Vec3d(255, 0, 0), 0, 0);
            this.sceneOXYZ.AddCylinder("OY", new Vec3d(0, 0, 0), new Vec3d(0, 1, 0), 0.05, 500, new Vec3d(0, 255, 0), 0, 0);
            this.sceneOXYZ.AddCylinder("OZ", new Vec3d(0, 0, 0), new Vec3d(0, 0, 1), 0.05, 500, new Vec3d(0, 0, 255), 0, 0);
            this.rayTracerOXYZ = new RayTracer(this.sceneOXYZ);
            this.arrBitmap = new Bitmap[n];
        }

        public void yawCamera(double angle)
        {
            Camera tmp_camera = this.scene.camera;
            this.cameraManager.yawCamera(ref tmp_camera, angle);
            this.scene.camera = tmp_camera;
        }

        public void pitchCamera(double angle)
        {
            Camera tmp_camera = this.scene.camera;
            this.cameraManager.pitchCamera(ref tmp_camera, angle);
            this.scene.camera = tmp_camera;
        }

        public void rollCamera(double angle)
        {
            Camera tmp_camera = this.scene.camera;
            this.cameraManager.rollCamera(ref tmp_camera, angle);
            this.scene.camera = tmp_camera;
        }

        public void moveCamera(double dx, double dy, double dz)
        {
            Camera tmp_camera = this.scene.camera;
            this.cameraManager.moveCamera(ref tmp_camera, dx, dy, dz);
            this.scene.camera = tmp_camera;
        }

        public void loadScene(string filename)
        {
            this.loaderScene.loadingScene(filename, ref this.scene);
        }

        public void saveScene(string filename)
        {
            this.saverScene.savingScene(filename, this.scene);
        }

        public void AddSphereToScene(string filename)
        {
            this.saverScene.savingScene(filename, this.scene);
        }

        public void AddSphereToScene(string name, Vec3d C, double radius, Vec3d color, double specular, double reflective)
        {
            scene.AddSphere(name, C, radius, color, specular, reflective);
        }
        public void AddCylinderToScene(string name, Vec3d C, Vec3d V, double radius, double maxm, Vec3d color, double specular, double reflective)
        {
            scene.AddCylinder(name, C, V, radius, maxm, color, specular, reflective);
        }

        public void AddTrianglePyramidToScene(string name, Vec3d P, Vec3d A, Vec3d B, Vec3d C, Vec3d color, double specular, double reflective)
        {
            scene.AddTrianglePyramid(name, P, A, B, C, color, specular, reflective);
        }

        public void AddParallelepipedToScene(string name, Vec3d C, Vec3d E, Vec3d color, double specular, double reflective)
        {
            scene.AddParallelepiped(name, C, E, color, specular, reflective);
        }
        public void render(ref PictureBox canvas, bool drawBackground)
        {
            rayTracer.scene = this.scene;
            tmp = rayTracer.render(drawBackground);
            
/*
            this.sceneOXYZ.convertBackgroundReverse(tmp, this.scene.canvasWidth, this.scene.canvasHeight);
            this.sceneOXYZ.camera = this.scene.camera;
            tmp_axes = rayTracerOXYZ.render(true);*/
            canvas.Image = tmp;
        }

        public void dynamic_render(ref PictureBox canvas, bool drawBackground)
        {

            rayTracer.scene = this.scene;
            Primitive a;
            Vec3d turnPoint = new Vec3d(0, 48.5, 0);
            double angle = 360 / n;

            for (int i = 0; i < n; i++)
            {
                
                tmp = rayTracer.render(drawBackground);
                this.sceneOXYZ.convertBackgroundReverse(tmp, this.scene.canvasWidth, this.scene.canvasHeight);
                this.sceneOXYZ.camera = this.scene.camera;
                tmp_axes = rayTracerOXYZ.render(true);
                canvas.Image = tmp;
                arrBitmap.Append(tmp);

                for (int j = 0; j < scene.sceneObjects.Count; j++)
                {
                    a = scene.sceneObjects[j];
                    if (a is Sphere)
                    {
                        TransformPrimitive.RotateOY(ref a.C, ref turnPoint, angle);
                    }
                    else if (a is Cylinder)
                    {
                        continue;
                        //TransformPrimitive.RotateOYCylinder(ref a, ref turnPoint, angle);

                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                canvas.Image = arrBitmap[i];
            }

            for (int i = 0; i < n; i++)
            {
                canvas.Image = arrBitmap[i];
            }

        }

/*        private void createArrayImgBox()
        {
            double angle = 0.04d;
            double h = 0.23;
            DrawScene();

            // Правый шар поднимается.
            while (_scene[2].Center.Y < h)
            {
                Console.WriteLine(_scene[2].Center.Y);
                _scene[2].Center.RotateNegative(1.6, 5, angle);
                DrawScene();
            }
            // Правый шар опускается.
            while (_scene[2].Center.Y - 0.2 > 0.001)
            {
                Console.WriteLine(_scene[2].Center.Y);
                _scene[2].Center.RotatePositive(1.6, 5, angle);
                DrawScene();
            }
            // Левый шар поднимается. 
            while (_scene[0].Center.Y < h)
            {
                Console.WriteLine(_scene[0].Center.Y);
                _scene[0].Center.RotatePositive(-1.6, 5, angle);
                DrawScene();
            }
            // Левый шар опускается. 
            while (_scene[0].Center.Y - 0.2 > 0.001)
            {
                Console.WriteLine(_scene[0].Center.Y);
                _scene[0].Center.RotateNegative(-1.6, 5, angle);
                DrawScene();
            }
        }
        private void DrawScene(int step = 165) // 8 потоков.
        {
            Bitmap img = new Bitmap((int)this.scene.canvasWidth, (int)this.scene.canvasHeight);

            List<Thread> listThread = new List<Thread>();

            for (int i = -(int)this.scene.canvasWidth / 2; i < (int)this.scene.canvasWidth / 2; i += step)
            {
                listThread.Add(new Thread(new ParameterizedThreadStart(FuncVertically)));
                listThread[listThread.Count - 1].Start(new Limit(i, i + step, img));
            }

            // Join — Это метод синхронизации, который блокирует вызывающий поток (то есть поток, который вызывает метод).
            // Используйте этот метод, чтобы убедиться, что поток был завершен.
            // То есть мы не пойдем далее по коду, пока что не выполнятся потоки, вызванные ранее 
            // (то есть те потоки, которые мы джоиним.).
            foreach (var elem in listThread)
            {
                elem.Join();
            }

            _arrayBitmap.Add(img);

        }*/



        public List<Primitive> getSceneObjects()
        {
            return this.scene.sceneObjects;
        }

        public void getLight(string name, ref Light light)
        {
            for (int i = 0; i < this.scene.lights.Count; i++)
            {
                if (this.scene.lights[i].name == name)
                {
                    light = this.scene.lights[i];
                    break;
                }
            }
        }

        public void changeLight(string name, Vec3d position, double intensity)
        {
            for (int i = 0; i < this.scene.lights.Count; i++)
            {
                if (this.scene.lights[i].name == name)
                {
                    this.scene.lights[i].position = position;
                    this.scene.lights[i].intensity = intensity;
                    break;
                }
            }
        }
        public void changeLight(string name, double intensity)
        {
            for (int i = 0; i < this.scene.lights.Count; i++)
            {
                if (this.scene.lights[i].name == name)
                {
                    this.scene.lights[i].intensity = intensity;
                    break;
                }
            }
        }

        public List<string> getLightsName()
        {

            List<string> lightsName = new List<string>();
            for (int i = 0; i < this.scene.lights.Count; i++)
            {
                lightsName.Add(this.scene.lights[i].name);
            }
            return lightsName;
        }

        public void addLight(Vec3d position, double intensity)
        {
            this.scene.AddLightPoint(position, intensity);
        }

        public void deleteLight(string name)
        {
            this.scene.RemoveLightPoint(name);
        }

        public void updatePrimitive(string name, Vec3d color, double specular, double reflective)
        {
            for (int i = 0; i < this.scene.sceneObjects.Count; i++)
            {
                if (this.scene.sceneObjects[i].name == name)
                {
                    this.scene.sceneObjects[i].name = name;
                    this.scene.sceneObjects[i].color = color;
                    this.scene.sceneObjects[i].specular = specular;
                    this.scene.sceneObjects[i].reflective = reflective;
                    break;
                }
            }
        }

        public void updateSphere(string oldname, string newname, Vec3d C, double r, Vec3d color, double specular, double reflective)
        {
            int index = -1;
            
            for (int i = 0; i < this.scene.sceneObjects.Count; i++)
            {
                if (this.scene.sceneObjects[i].name == oldname)
                {
                    index = i;
                    break;
                }  
            }
            if (index != -1)
            {
                Sphere tmp = (Sphere)this.scene.sceneObjects[index];
                tmp.name = newname;
                tmp.C = C;
                tmp.radius = r;
                tmp.color = color;
                tmp.specular = specular;
                tmp.reflective = reflective;
                this.scene.sceneObjects[index] = tmp;
            }
        }

        public void updateBasePlane(Vec3d color, double specular, double reflective)
        {

            for (int i = 0; i < this.scene.sceneObjects.Count; i++)
            {
                if (this.scene.sceneObjects[i].name == "плоскость основания")
                {
                    this.scene.sceneObjects[i].color = color;
                    this.scene.sceneObjects[i].specular = specular;
                    this.scene.sceneObjects[i].reflective = reflective;
                    break;
                }
            }
        }

        public void updateParallelepiped(string oldname, string newname, Vec3d C, Vec3d E, Vec3d color, double specular, double reflective)
        {
            int index = -1;

            for (int i = 0; i < this.scene.sceneObjects.Count; i++)
            {
                if (this.scene.sceneObjects[i].name == oldname)
                {
                    index = i;
                    break;
                }
            }
            if (index != -1)
            {
                Parallelepiped tmp = (Parallelepiped)this.scene.sceneObjects[index];
                tmp.name = newname;
                tmp.C = C;
                tmp.E = E;
                tmp.color = color;
                tmp.specular = specular;
                tmp.reflective = reflective;
                this.scene.sceneObjects[index] = tmp;
            }
        }

        public void updateTrianglePyramid(string oldname, string newname, Vec3d P, Vec3d A, Vec3d B, Vec3d C, Vec3d color, double specular, double reflective)
        {

            for (int i = 0; i < this.scene.sceneObjects.Count; i++)
            {
                if (this.scene.sceneObjects[i].name == oldname)
                {
                    this.scene.sceneObjects.RemoveRange(i, 1);
                    i--;
                }
            }
            this.scene.AddTrianglePyramid(newname, P, A, B, C, color, specular, reflective);
        }

        public void updateCylinder(string oldname, string newname, Vec3d C, Vec3d V, double r, double maxm, Vec3d color, double specular, double reflective)
        {

            for (int i = 0; i < this.scene.sceneObjects.Count; i++)
            {
                if (this.scene.sceneObjects[i].name == oldname)
                {
                    this.scene.sceneObjects.RemoveRange(i, 1);
                    i--;
                }
            }
            this.scene.AddCylinder(newname, C, V, r, maxm, color, specular, reflective);
        }

        public void deletePrimitive(string name)
        {

            for (int i = 0; i < this.scene.sceneObjects.Count; i++)
            {
                if (this.scene.sceneObjects[i].name == name)
                {
                    this.scene.sceneObjects.RemoveRange(i, 1);
                    i--;
                }
            }
        }

        public Camera getCamera()
        {
            return this.scene.camera;
        }

        public void clearScene()
        {
            for (int i = 0; i < this.scene.sceneObjects.Count; i++)
            {
                if (this.scene.sceneObjects[i] is Plane)
                {
                    continue;
                }
                this.scene.sceneObjects.RemoveRange(i, 1);
                i--;
            }
        }
    }
}