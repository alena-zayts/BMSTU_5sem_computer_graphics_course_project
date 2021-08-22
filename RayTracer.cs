using System;
using System.Drawing;
using System.Threading;


namespace Weatherwane
{
    // вспомогательный класс для распараллеливания
    class Limits
    {
        public int width;
        public int height;
        public int start_x;
        public int start_y;

        public Limits(int width, int height, int start_x, int start_y)
        {
            this.width = width;
            this.height = height;
            this.start_x = start_x;
            this.start_y = start_y;
        }
    }

    class RayTracer
    {
        private Bitmap bmp;
        private Scene scene;

        private bool BF_model;
        private double coef;
        private bool drawBackground;
        private int recursion_depth;
        private int numThreads;

        private int viewport_width = 1;
        private int viewport_height = 1;
        private int projection_plane_d = 1;


        private Color[,] buffer;

        public RayTracer(Scene scene)
        {
            this.scene = scene;
            this.bmp = new Bitmap(scene.canvasWidth, scene.canvasHeight);
            this.buffer = new Color[scene.canvasWidth, scene.canvasHeight];
        }

        private double FindIntensity(Vec3 P, Vec3 N, Vec3 V, double specular)
        {
            // N, V поступают единичными
            double intensity = 0;

            foreach (var light in scene.lights)
            {
                // фоновая составляющая
                if (light.ltype == LightTypes.Ambient)
                    intensity += light.intensity;
                else
                {
                    Vec3 light_vector;
                    double t_max;

                    if (light.ltype == LightTypes.Point) // точечный источник
                    {
                        light_vector = light.position - P;
                        t_max = 1.0;
                    }
                    else // направленный источник
                    {
                        light_vector = light.position;
                        t_max = Double.PositiveInfinity;
                    }

                    // проверка на нахождение в тени
                    double shadow_t = Double.PositiveInfinity;
                    Primitive shadow_object = null;

                    ClosestIntersection(ref shadow_object, ref shadow_t, P, light_vector, 0.001, t_max);
                    if (shadow_object != null)
                        continue;

                    light_vector = light_vector.Normalize();

                    // Диффузная составляющая
                    double NL = Vec3.ScalarMultiplication(N, light_vector);
                    if (NL > 0)
                        intensity += light.intensity * NL;


                    // Зеркальная составляющая
                    // по модели Фонга
                    if (!BF_model)
                    {
                        Vec3 R = ReflectRay(light_vector, N); // возвращает единичный вектор
                        double RV = Vec3.ScalarMultiplication(R, V);

                        if (RV > 0)
                            intensity += light.intensity * Math.Pow(RV, specular);
                    }
                    // по модели Блинна-Фонга
                    else
                    {
                        Vec3 H = (light_vector + V);
                        double HN = Vec3.ScalarMultiplication(H, N);

                        if (HN > 0)
                            intensity += light.intensity * Math.Pow(HN / Vec3.Length(H), specular * coef);
                    }
                }
            }
            return intensity;
        }

        private Vec3 TraceRay(Vec3 camera_position, Vec3 view_vector, double t_min, double t_max, int depth, int x, int y)
        {
            // view_vector поступает единичным
            double closest_t = Double.PositiveInfinity;
            Primitive closest_object = null;

            ClosestIntersection(ref closest_object, ref closest_t, camera_position, view_vector, t_min, t_max);

            if (closest_object == null)
            {
                if (drawBackground)
                    return scene.background[x + scene.canvasWidth / 2, y  + scene.canvasHeight / 2];
                else
                    return new Vec3(0, 0, 0);
            }

            Vec3 intersection_point = camera_position + closest_t * view_vector;
            Vec3 N = closest_object.findNormal(intersection_point); // возвращает единичныЙ вектор 

            double intensity = FindIntensity(intersection_point, N, -view_vector, closest_object.material.specular);
            Vec3 currentColor = intensity * closest_object.material.color * (1 - closest_object.material.reflective);

            if (depth <= 0 || closest_object.material.reflective <= 0)
                return currentColor;

            Vec3 reflected_vector = ReflectRay(-view_vector, N); // возвращает единичныЙ вектор 
            Vec3 reflectedColor = TraceRay(intersection_point, reflected_vector, 0.01, Double.PositiveInfinity, depth - 1, x, y);

            currentColor += reflectedColor * closest_object.material.reflective;

            return currentColor;
        }

        private void ClosestIntersection(ref Primitive closest_object, ref double closest_t, Vec3 camera_position, Vec3 view_vector, double t_min, double t_max)
        {

            double t1 = 0;
            double t2 = 0;

            for (int i = 0; i < this.scene.primitives.Count; i++)
            {
                this.scene.primitives[i].intersectRay(camera_position, view_vector, ref t1, ref t2);

                if (t1 < closest_t && t_min < t1 && t1 < t_max)
                {
                    closest_t = t1;
                    closest_object = this.scene.primitives[i];
                }
                if (t2 < closest_t && t_min < t2 && t2 < t_max)
                {
                    closest_t = t2;
                    closest_object = this.scene.primitives[i];
                }
            }
        }

        private Vec3 ReflectRay(Vec3 L, Vec3 N)
        {
            // N, V поступают единичными
            double LN = Vec3.ScalarMultiplication(L, N);
            Vec3 R = -L + 2 * LN * N;
            return R;
        }


        private void SetPixel(int x, int y, Color color)
        {
            int x_ = scene.canvasWidth / 2 + x;
            int y_ = scene.canvasHeight / 2 - y - 1;

            if (x_ < 0 || x_ >= scene.canvasWidth || y_ < 0 || y_ >= scene.canvasHeight)
            {
                return;
            }

            this.buffer[x_, y_] = color;
        }

        private Color CountColor(Vec3 color)
        {
            int color_x = Math.Min(255, Math.Max(0, (int)color.x));
            int color_y = Math.Min(255, Math.Max(0, (int)color.y));
            int color_z = Math.Min(255, Math.Max(0, (int)color.z));
            return Color.FromArgb(color_x, color_y, color_z);
        }

        private Vec3 ProjectPixel(int x, int y)
        {
            return new Vec3(x * (double)viewport_width / scene.canvasWidth, y * (double)viewport_height / scene.canvasHeight, projection_plane_d);
        }

        public void UpdateParams(bool drawSceneBackground, int numThreads, int recursion_depth, bool BF_model, double coef)
        {
            this.recursion_depth = recursion_depth;
            this.drawBackground = drawSceneBackground;
            this.BF_model = BF_model;
            this.coef = coef;
            this.numThreads = numThreads;
        }

        public Bitmap render()
        {
            Thread[] threads = new Thread[numThreads];
            for (int i = 0; i < numThreads; i++)
            {
                Limits p = new Limits(scene.canvasWidth / numThreads, scene.canvasHeight, -scene.canvasWidth / 2 + scene.canvasWidth / numThreads * i, -scene.canvasHeight / 2);
                threads[i] = new Thread(rendering);
                threads[i].Start(p);
            }
            foreach (Thread thread in threads)
            {
                thread.Join();
            }


            for (int i = 0; i < scene.canvasWidth; i++)
                for (int j = 0; j < scene.canvasHeight; j++)
                    this.bmp.SetPixel(i, j, buffer[i, j]);

            return this.bmp;
        }

        private void rendering(object obj)
        {
            Limits p = (Limits)obj;
            Camera camera = scene.camera;
            Vec3 view_vector = null;
            Vec3 color = null;
            for (int x = p.start_x; x < p.start_x + p.width; x++)
            {
                for (int y = p.start_y; y < p.start_y + p.height; y++)
                {
                    view_vector = (ProjectPixel(x, y) * camera.rotation_mtrx).Normalize();
                    color = TraceRay(camera.position, view_vector, projection_plane_d, Double.PositiveInfinity, recursion_depth, x, y);
                    SetPixel(x, y, CountColor(color));

                }
            }
        }
    }
}
