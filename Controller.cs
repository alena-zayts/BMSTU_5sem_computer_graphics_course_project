using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Timers;
using System.Diagnostics;

namespace Weatherwane
{
    class Controller
    {
        private Scene scene;
        private RayTracer rayTracer;
        private LoadScene loaderScene;
        private SaveScene saverScene;
        private CameraManager cameraManager;

        private PictureBox imgBox; // Будет сожержать само изображение.
        private Bitmap tmp;
        private Bitmap[] arrBitmap;
        private bool on;
        private int currImgIndex;

        private int picturesNum;
        private bool reverse;
        private System.Timers.Timer timer; // Частота кадров.
        private bool createArray;


        public Controller(int canvasWidth, int canvasHeight)
        {
            this.scene = new Scene(canvasWidth, canvasHeight);
            this.rayTracer = new RayTracer(this.scene);
            this.loaderScene = new LoadScene();
            this.saverScene = new SaveScene();
            this.cameraManager = new CameraManager();

            this.currImgIndex = 0;
            this.on = false;


            // Timer
            timer = new System.Timers.Timer();
            timer.Elapsed += OnTimedEvent;
        }

        public void render(ref PictureBox canvas, ref TextBox textBoxTime)
        {
            // возврат к начальному состоянию
            if (this.picturesNum > 0 & currImgIndex > 1)
            {
                double cur_angle = (this.currImgIndex - 1) * 360 / this.picturesNum;
                Vec3 turnPoint = new Vec3(0, 48.5, 0);

                for (int j = 0; j < scene.sceneObjects.Count; j++)
                {
                    if (scene.sceneObjects[j].moving)
                    {
                        scene.sceneObjects[j].RotateOY(turnPoint, cur_angle);
                    }
                }

                currImgIndex = 0;
            }

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            tmp = rayTracer.render();

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}.{2:00}", ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            textBoxTime.Text = elapsedTime;

            canvas.Image = tmp;
        }

        public void dynamic_render(ref PictureBox canvas, ref ProgressBar progressBar, ref TextBox textBoxTime)
        {
            this.imgBox = canvas;

            if (createArray)
            {
                this.arrBitmap = null;
                this.arrBitmap = new Bitmap[this.picturesNum];
                this.currImgIndex = 0;


                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                createArrayBitmap(ref canvas, ref progressBar);

                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}.{2:00}", ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                textBoxTime.Text = elapsedTime;
            }

            if (!on)
            {
                timer.Start();
                on = true;
            }
        }

        public void createArrayBitmap(ref PictureBox canvas, ref ProgressBar progressBar)
        {
            Vec3 turnPoint = new Vec3(0, 48.5, 0);
            double angle = 360 / picturesNum;

            progressBar.Maximum = picturesNum;

            for (int i = 0; i < picturesNum; i++)
            {

                tmp = new Bitmap(rayTracer.render());
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

        public void UpdateParams(bool reverse, int speed, bool createArray, int picturesNum, bool BF_model, double coef, bool drawBackground, int numThreads, int recursion_depth)
        {
            this.reverse = reverse;
            this.picturesNum = picturesNum;
            this.timer.Interval = speed;
            this.createArray = createArray;

            this.rayTracer.UpdateParams(drawBackground, numThreads, recursion_depth, BF_model, coef);
        }

        public void turnXCamera(double angle)
        {
            Camera tmp_camera = this.scene.camera;
            this.cameraManager.turnXCamera(ref tmp_camera, angle);
            this.scene.camera = tmp_camera;
        }

        public void turnYCamera(double angle)
        {
            Camera tmp_camera = this.scene.camera;
            this.cameraManager.turnYCamera(ref tmp_camera, angle);
            this.scene.camera = tmp_camera;
        }

        public void turnZCamera(double angle)
        {
            Camera tmp_camera = this.scene.camera;
            this.cameraManager.turnZCamera(ref tmp_camera, angle);
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

        public void stopRender()
        {
            if (on)
            { 
                on = false;
                timer.Stop();
            }
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine(currImgIndex);
            if (!reverse)
            {
                if (currImgIndex >= arrBitmap.Count())
                    currImgIndex = 0;

                imgBox.Image = arrBitmap[currImgIndex];
                currImgIndex++;
            }
            else
            {
                if (currImgIndex < 0)
                    currImgIndex = arrBitmap.Count() - 1;

                imgBox.Image = arrBitmap[currImgIndex];
                currImgIndex--;
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

        public void changeLight(string name, Vec3 position, double intensity)
        {
            for (int i = 0; i < this.scene.lights.Count; i++)
            {
                if (this.scene.lights[i].name == name)
                {
                    if (this.scene.lights[i].ltype == LightType.Directional)
                        this.scene.lights[i].position = position.Normalize();
                    else
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

        public void addLight(Vec3 position, double intensity)
        {
            this.scene.AddLightPoint(position, intensity);
        }

        public void deleteLight(string name)
        {
            this.scene.RemoveLightPoint(name);
        }

        public void updatePrimitive(string name, Vec3 color, double specular, double reflective)
        {
            for (int i = 0; i < this.scene.sceneObjects.Count; i++)
            {
                if (this.scene.sceneObjects[i].name == name)
                {
                    this.scene.sceneObjects[i].name = name;
                    this.scene.sceneObjects[i].material.update(color, specular, reflective);
                }
            }
        }

        public Camera getCamera()
        {
            return this.scene.camera;
        }
    }
}