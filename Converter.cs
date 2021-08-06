﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Weatherwane
{
    class Converter
    {
        [JsonProperty("camera")]
        private Camera camera;

        [JsonProperty("spheres")]
        private Sphere[] spheres;

        [JsonProperty("cylinders")]
        private Cylinder[] cylinders;

        [JsonProperty("quadPyramids")]
        private Pyramid[] pyramids;

        [JsonProperty("parallelepipeds")]
        private Parallelepiped[] parallelepipeds;

        [JsonProperty("plane")]
        private Plane[] planes;

        [JsonProperty("lights")]
        private Light[] lights;


        
        public void SceneObjectToJson(Scene scene)
        {
            this.camera = scene.camera;

            List<Sphere> spheres = new List<Sphere>();
            List<Cylinder> cylinders = new List<Cylinder>();
            List<Pyramid> pyramids = new List<Pyramid>();
            List<Parallelepiped> parallelepipeds = new List<Parallelepiped>();
            List<Plane> planes = new List<Plane>();

            for (int i = 0; i < scene.sceneObjects.Count; i++)
            {
                if (scene.sceneObjects[i] is Sphere)
                    spheres.Add((Sphere)scene.sceneObjects[i]);

                else if (scene.sceneObjects[i] is Cylinder)
                    cylinders.Add((Cylinder)scene.sceneObjects[i]);

                else if (scene.sceneObjects[i] is Pyramid)
                    pyramids.Add((Pyramid)scene.sceneObjects[i]);

                else if (scene.sceneObjects[i] is Parallelepiped)
                    parallelepipeds.Add((Parallelepiped)scene.sceneObjects[i]);

                else if (scene.sceneObjects[i] is Plane)
                    planes.Add((Plane)scene.sceneObjects[i]);
            }

            this.spheres = spheres.ToArray();
            this.cylinders = cylinders.ToArray();
            this.pyramids = pyramids.ToArray();
            this.parallelepipeds = parallelepipeds.ToArray();
            this.planes = planes.ToArray();

            this.lights = scene.lights.ToArray();

        }
        public void JsonToSceneObject(ref Scene scene)
        {
            scene.camera = this.camera;

            scene.sceneObjects.Clear();

            for (int i = 0; i < this.spheres.Length; i++)
                scene.AddSphere(this.spheres[i].name, this.spheres[i].material, this.spheres[i].moving, this.spheres[i].centre, this.spheres[i].radius);

            for (int i = 0; i < this.cylinders.Length; i++)
                scene.AddCylinder(this.cylinders[i].name, this.cylinders[i].material, this.cylinders[i].moving, this.cylinders[i].centre, this.cylinders[i].V, this.cylinders[i].radius, this.cylinders[i].height);

            for (int i = 0; i < this.pyramids.Length; i++)
                scene.AddPyramid(this.pyramids[i].name, this.pyramids[i].material, this.pyramids[i].moving, this.pyramids[i].P, this.pyramids[i].A, this.pyramids[i].B, this.pyramids[i].C, this.pyramids[i].D);

            for (int i = 0; i < this.parallelepipeds.Length; i++)
                scene.AddParallelepiped(this.parallelepipeds[i].name, this.parallelepipeds[i].material, this.parallelepipeds[i].moving, this.parallelepipeds[i].C, this.parallelepipeds[i].E);

            for (int i = 0; i < this.planes.Length; i++)
                scene.AddPlane(this.planes[i].name, this.planes[i].material, this.parallelepipeds[i].moving, this.planes[i].C, this.planes[i].V);

            scene.lights.Clear();

            for (int i = 0; i < this.lights.Length; i++)
                scene.lights.Add(this.lights[i]);

        }
    }
}
