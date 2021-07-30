using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Timers;

namespace Weatherwane
{
    class Controller
    {
        private Scene scene;
        private RayTracer rayTracer;
        private LoadScene loaderScene;
        private SaveScene saverScene;
        private CameraManager cameraManager;

        private int n = 36;
        private int currImgIndex;
        private bool on;
        private System.Timers.Timer timer; // Частота кадров.
        private PictureBox imgBox; // Будет сожержать само изображение.
        private Bitmap tmp;
        private Bitmap[] arrBitmap;

        public Controller(int canvasWidth, int canvasHeight)
        {
            this.scene = new Scene(canvasWidth, canvasHeight);
            this.rayTracer = new RayTracer(this.scene);
            this.loaderScene = new LoadScene();
            this.saverScene = new SaveScene();
            this.cameraManager = new CameraManager();


            this.arrBitmap = new Bitmap[n];
            this.currImgIndex = 0;
            this.on = false;


            // Timer
            timer = new System.Timers.Timer(150);
            timer.Elapsed += OnTimedEvent;
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


        public void render(ref PictureBox canvas, bool drawBackground)
        {
            rayTracer.scene = this.scene;
            tmp = rayTracer.render(drawBackground);
        
            canvas.Image = tmp;
        }

        public void dynamic_render(ref PictureBox canvas, bool drawBackground, ref ProgressBar progressBar)
        {
            if (!on)
            {
                this.imgBox = canvas;
                createArrayBitmap(ref canvas, drawBackground, ref progressBar);
                timer.Start();
                on = true;
            }
            else
            {
                on = false;
                timer.Stop();
            }

        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            if (currImgIndex >= arrBitmap.Count())
                currImgIndex = 0;

            Console.WriteLine(currImgIndex + "  " + arrBitmap.Count());
            imgBox.Image = arrBitmap[currImgIndex];

            currImgIndex++;
        }

        public void createArrayBitmap(ref PictureBox canvas, bool drawBackground, ref ProgressBar progressBar)
        {
            Primitive a;
            Vec3d turnPoint = new Vec3d(0, 48.5, 0);
            double angle = 360 / n;

            progressBar.Maximum = n;

            for (int i = 0; i < n; i++)
            {

                tmp = new Bitmap(rayTracer.render(drawBackground));
                arrBitmap[i] = tmp;

                for (int j = 0; j < scene.sceneObjects.Count; j++)
                {
                    if (scene.sceneObjects[j].moving)
                    {
                        scene.sceneObjects[j].RotateOY(turnPoint, angle);
                    }
                }
                progressBar.Value = i + 1;
            }
        }

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
                }
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

        public Camera getCamera()
        {
            return this.scene.camera;
        }
    }
}