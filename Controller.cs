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

        private int n;
        private bool reverse;
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


        public void render(ref PictureBox canvas, bool drawBackground, int numThreads, ref TextBox textBoxTime, int recursion_depth)
        {
            if (this.n > 0 & currImgIndex > 1)
            {
                double cur_angle = (this.currImgIndex - 1) * 360 / this.n;
                Vec3d turnPoint = new Vec3d(0, 48.5, 0);

                for (int j = 0; j < scene.sceneObjects.Count; j++)
                {
                    if (scene.sceneObjects[j].moving)
                    {
                        scene.sceneObjects[j].RotateOY(turnPoint, cur_angle);
                    }
                }

                currImgIndex = 0;
            }

            rayTracer.scene = this.scene;

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            tmp = rayTracer.render(drawBackground, numThreads, recursion_depth);

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}.{2:00}",
                ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            textBoxTime.Text = elapsedTime;

            canvas.Image = tmp;
        }

        public void dynamic_render(ref PictureBox canvas, bool drawSea, ref ProgressBar progressBar, bool reverse, int speed, int numThreads, ref TextBox textBoxTime, bool createArray, int n, int recursion_depth)
        {
            this.n = n;
            this.timer.Interval = speed;
            this.imgBox = canvas;
            this.reverse = reverse;

            if (createArray)
            {
                this.arrBitmap = null;
                this.arrBitmap = new Bitmap[n];
                this.currImgIndex = 0;
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                createArrayBitmap(ref canvas, drawSea, ref progressBar, numThreads, recursion_depth);
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}.{2:00}",
                    ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                textBoxTime.Text = elapsedTime;
            }

            if (!on)
            {
                timer.Start();
                on = true;
            }
        }

        public void changeParams(bool reverse, int speed)
        {
            this.timer.Interval = speed;
            this.reverse = reverse;
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

        public void createArrayBitmap(ref PictureBox canvas, bool drawBackground, ref ProgressBar progressBar, int numThreads, int recursion_depth)
        {
            Vec3d turnPoint = new Vec3d(0, 48.5, 0);
            double angle = 360 / n;

            progressBar.Maximum = n;

            for (int i = 0; i < n; i++)
            {

                tmp = new Bitmap(rayTracer.render(drawBackground, numThreads, recursion_depth));
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