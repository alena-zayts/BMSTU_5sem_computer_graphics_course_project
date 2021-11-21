using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;
using System.Diagnostics;
using System.IO;


namespace Weatherwane
{
    class Controller
    {
        private Scene scene;
        private RayTracer rayTracer;
        private SceneManager sceneManager;

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
            this.sceneManager = new SceneManager();

            this.currImgIndex = 0;
            this.on = false;


            // Timer
            timer = new System.Timers.Timer();
            timer.Elapsed += OnTimedEvent;
            this.count_time();
        }

        public void render(ref PictureBox canvas, ref TextBox textBoxTime)
        {
            // возврат к начальному состоянию
            if (this.picturesNum > 0 & currImgIndex > 1)
            {
                double cur_angle = (this.currImgIndex - 1) * 360 / this.picturesNum;
                Vec3 turnPoint = new Vec3(0, 48.5, 0);

                for (int j = 0; j < scene.primitives.Count; j++)
                {
                    if (scene.primitives[j].moving)
                    {
                        scene.primitives[j].RotateOY(turnPoint, cur_angle);
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

                createArrayBitmap(ref progressBar);

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

        private void createArrayBitmap(ref ProgressBar progressBar)
        {
            Vec3 turnPoint = new Vec3(0, 48.5, 0);
            double angle = 360 / picturesNum;

            progressBar.Maximum = picturesNum;

            for (int i = 0; i < picturesNum; i++)
            {

                tmp = new Bitmap(rayTracer.render());
                arrBitmap[i] = tmp;

                for (int j = 0; j < scene.primitives.Count; j++)
                {
                    if (scene.primitives[j].moving)
                    {
                        scene.primitives[j].RotateOY(turnPoint, angle);
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
            this.scene.camera.turnX(angle);
        }

        public void turnYCamera(double angle)
        {
            this.scene.camera.turnY(angle);
        }

        public void turnZCamera(double angle)
        {
            this.scene.camera.turnZ(angle);
        }

        public void moveCamera(Vec3 d)
        {
            this.scene.camera.move(d);
        }

        public void loadScene(string filename)
        {
            this.sceneManager.loadScene(filename, ref this.scene);
        }

        public void saveScene(string filename)
        {
            this.sceneManager.saveScene(filename, this.scene);
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

        public List<Primitive> getPrimitives()
        {
            return this.scene.primitives;
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

        public void updateLight(string name, double intensity, Vec3 position = null)
        {
            for (int i = 0; i < this.scene.lights.Count; i++)
            {
                if (this.scene.lights[i].name == name)
                {
                    this.scene.lights[i].update(intensity, position);
                    return;
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

        public void addLight(Vec3 position, double intensity, LightTypes ltype)
        {
            this.scene.AddLight(position, intensity, ltype);
        }

        public void deleteLight(string name)
        {
            this.scene.RemoveLight(name);
        }

        public void updatePrimitive(string name, Vec3 color, double specular, double reflective)
        {
            for (int i = 0; i < this.scene.primitives.Count; i++)
            {
                if (this.scene.primitives[i].name == name)
                {
                    this.scene.primitives[i].name = name;
                    this.scene.primitives[i].material.update(color, specular, reflective);
                }
            }
        }

        public Camera getCamera()
        {
            return this.scene.camera;
        }

        public void count_time()
        {
            int n_repeats = 8;
            int n_objects = 35;
            int lp_amount = 8;
            string fileout_name = @"C:\Users\alena\Desktop\BMSTU_5sem_analysis_of_algorithms\lab4\report\inc\img\time.txt";
            FileInfo f = new FileInfo(fileout_name);
            using (FileStream fs = f.Open(FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read))
            {
                using (StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8))
                {
                    for (int i = 5; i <= n_objects; i += 5)
                    {
                        Console.WriteLine(String.Format("################  N_OBJECTS: {0}", i));

                        string filename = String.Format(@"C:\Users\alena\Desktop\BMSTU_5sem_analysis_of_algorithms\lab4\last_course\Weatherwane\meta\test{0}.json", i);
                        this.loadScene(filename);

                        // последователльный
                        TimeSpan total_time = new TimeSpan(0, 0, 0);

                        for (int j = 0; j < n_repeats; j++)
                        {
                            Stopwatch stopWatch = new Stopwatch();
                            stopWatch.Start();
                            tmp = rayTracer.render_simple();
                            stopWatch.Stop();
                            TimeSpan ts = stopWatch.Elapsed;
                            total_time = total_time.Add(ts);

                        }
                        double middle_time = total_time.TotalSeconds / n_repeats;
                        Console.WriteLine(String.Format("basic: middle_time {0}", middle_time));
                        sw.Write(middle_time);
                        sw.Write(" ");


                        // parallelized
                        total_time = new TimeSpan(0, 0, 0);

                        for (int num_threads = 1; num_threads <= 4 * lp_amount; num_threads *= 2)
                        {
                            rayTracer.numThreads = num_threads;
                            total_time = new TimeSpan(0, 0, 0);

                            for (int j = 0; j < n_repeats; j++)
                            {
                                Stopwatch stopWatch = new Stopwatch();
                                stopWatch.Start();
                                tmp = rayTracer.render_parallelized();
                                stopWatch.Stop();
                                TimeSpan ts = stopWatch.Elapsed;
                                total_time = total_time.Add(ts);

                            }

                            middle_time = total_time.TotalSeconds / n_repeats;
                            Console.WriteLine(String.Format("parallelized: num_threads {0}, middle_time {1}", num_threads, middle_time));
                            sw.Write(middle_time);
                            sw.Write(" ");
                        }
                        sw.Write(middle_time);
                        sw.WriteLine();
                    }
                }
            }
        }
    }
}