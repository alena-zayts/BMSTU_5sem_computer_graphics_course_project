using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Threading;


namespace Weatherwane
{
    class RayTracer
    {
        public Bitmap bmp;
        public Scene scene;

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

        private void ClosestIntersection(ref Primitive closest_object, ref double closest_t, Vec3d O, Vec3d D, double t_min, double t_max)
        {

            double t1 = 0;
            double t2 = 0;

            for (int i = 0; i < this.scene.sceneObjects.Count; i++)
            {
                this.scene.sceneObjects[i].intersectRay(O, D, ref t1, ref t2);
                
                if (t1 < closest_t && t_min < t1 && t1 < t_max)
                {
                    closest_t = t1;
                    closest_object = this.scene.sceneObjects[i];
                }
                if (t2 < closest_t && t_min < t2 && t2 < t_max)
                {
                    closest_t = t2;
                    closest_object = this.scene.sceneObjects[i];
                }
            }
        }
        private Vec3d ReflectRay(Vec3d R, Vec3d N)
        {
            double n_dot_r = Vec3d.ScalarMultiplication(N, R);
            Vec3d res = 2 * N * n_dot_r - R;
            return res;
        }


        private Vec3d Vec3dNormalCylinder(Vec3d P, double closest_t, Cylinder cylinder, Vec3d O, Vec3d D)
        {

            Vec3d CO = O - cylinder.centre;


            double d_v = Vec3d.ScalarMultiplication(D, cylinder.V);
            double co_v = Vec3d.ScalarMultiplication(CO, cylinder.V);

            double m = d_v * closest_t + co_v;
            Vec3d normal = P;
            normal = normal - cylinder.centre;
            normal = normal - cylinder.V * m;
            return normal;

        }


        private Vec3d TraceRay(Vec3d O, Vec3d D, double t_min, double t_max, int depth, int x, int y, bool drawSceneBackground)
        {
            double closest_t = Double.PositiveInfinity;
            Primitive closest_object = null;

            ClosestIntersection(ref closest_object, ref closest_t, O, D, t_min, t_max);

            if (closest_object == null)
            {
                if (drawSceneBackground)
                {
                    try
                    {
                        x += 330;
                        y += 330;
                        return scene.background[x, y];
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine("had" + - (y + 329) + "got" + y);
                        return new Vec3d(0, 0, 0);
                    }
                }
                return new Vec3d(0, 0, 0);
            }


            Vec3d P = O + closest_t * D;
            Vec3d N;
            if (closest_object is Cylinder)
                N = Vec3dNormalCylinder(P, closest_t, (Cylinder)closest_object, O, D);
            else
                N = closest_object.findNormal(P);
               


            N /= Vec3d.Length(N); 

            double intensity = ComputeLighting(P, N, -D, closest_object.material.specular);

            Vec3d localColor = intensity * closest_object.material.color; 

            double r = closest_object.material.reflective;

            if (depth <= 0 || r <= 0)
                return localColor;

            Vec3d R = ReflectRay(-D, N);
            Vec3d reflectedColor = TraceRay(P, R, 0.001, Double.PositiveInfinity, depth - 1, x, y, drawSceneBackground);

            Vec3d kLocalColor = (1 - r) * localColor;
            Vec3d rReflectedColor = r * reflectedColor;

            return kLocalColor+rReflectedColor;
        }

        private double ComputeLighting(Vec3d P, Vec3d N, Vec3d V, double specular)
        {
            double intensity = 0;
            List<Light> sceneLight = scene.lights;
            
            for (int i = 0; i < sceneLight.Count; i++)
            {
                if (sceneLight[i].ltype == LightType.Ambient)
                {
                    intensity += sceneLight[i].intensity;
                }
                else
                {
                    Vec3d L;
                    double t_max;
                    if (sceneLight[i].ltype == LightType.Point)
                    {
                        L = sceneLight[i].position - P;
                        t_max = 1;                    
                    }
                    else
                    {
                        L = sceneLight[i].position;
                        t_max = Double.MaxValue;
                    }

                    double shadow_t = Double.PositiveInfinity;
                    Primitive shadow_object = null;
                    ClosestIntersection(ref shadow_object, ref shadow_t, P, L, 0.001, t_max);
                    if (shadow_object != null)
                        continue;

                    double n_dot_l = Vec3d.ScalarMultiplication(N, L);

                    if (n_dot_l > 0)
                    {
                        intensity += sceneLight[i].intensity * n_dot_l / (Vec3d.Length(N) * Vec3d.Length(L));
                    }

                    if (specular != -1) 
                    {

                        Vec3d R = ReflectRay(L, N);
                        double r_dot_v = Vec3d.ScalarMultiplication(R, V);

                        if (r_dot_v > 0)
                        {
                            intensity += sceneLight[i].intensity * Math.Pow(r_dot_v / (Vec3d.Length(R) * Vec3d.Length(V)), specular);
                        }
                    }
                    else
                    {
                        Console.WriteLine("SOSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS");
                    }
                }
            }
            return intensity;
        }
        private void PutPixel(int x, int y, Color color)
        {
            int x_ = scene.canvasWidth / 2 + x;
            int y_ = scene.canvasHeight / 2 - y - 1;

            if (x_ < 0 || x_ >= scene.canvasWidth || y_ < 0 || y_ >= scene.canvasHeight)
            {
                return;
            }

            this.buffer[x_,y_] = color;    
        }

        private Color Clamp(Vec3d color)
        {
            int color_x = Math.Min(255, Math.Max(0, (int)color.x));
            int color_y = Math.Min(255, Math.Max(0, (int)color.y));
            int color_z = Math.Min(255, Math.Max(0, (int)color.z));
            return Color.FromArgb(color_x, color_y, color_z);
        }


        private void rendering(object obj)
        {
            Params p = (Params)obj;
            Camera camera = scene.camera;
            Vec3d D = null;
            Vec3d color = null;
            int recursion_depth = 3;
            for (int x = p.start_x; x < p.start_x + p.width; x++)
            {
                for (int y = p.start_y; y < p.start_y + p.height; y++)
                {
                    D = CanvasToViewport(x, y) * camera.rotation;
                    color = TraceRay(camera.position, D, 1, Double.PositiveInfinity, recursion_depth, x, y, p.drawSceneBackground);
                    PutPixel(x, y, Clamp(color));

                }
            }
            
        }
        public Bitmap render(bool drawSceneBackground, int numThreads)
        {
            Thread[] threads = new Thread[numThreads];
            for (int i = 0; i < numThreads; i++)
            {
                Params p = new Params(scene.canvasWidth / numThreads, scene.canvasHeight, -scene.canvasWidth / 2 + scene.canvasWidth / numThreads * i, -scene.canvasHeight / 2, drawSceneBackground);
                threads[i] = new Thread(rendering);
                threads[i].Start(p);
            }
            foreach (Thread thread in threads)
            {
                thread.Join();
            }

          
            for (int i = 0; i < scene.canvasWidth; i++)
                for (int j = 0; j < scene.canvasHeight; j++)
                    this.bmp.SetPixel(i, j, buffer[i,j]);

            
      
            return this.bmp;
        }


        private Vec3d CanvasToViewport(int x, int y)
        {
            return new Vec3d(x * (double)viewport_width / scene.canvasWidth, y * (double)viewport_height / scene.canvasHeight, projection_plane_d);
        }
    }

    class Params
    {
        public int width;
        public int height;
        public int start_x;
        public int start_y;
        public bool drawSceneBackground;
        public Params(int width, int height, int start_x, int start_y, bool drawSceneBackground)
        {
            this.width = width;
            this.height = height;
            this.start_x = start_x;
            this.start_y = start_y;
            this.drawSceneBackground = drawSceneBackground;
        }
    }
}
