﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SolarSystem.Objects3D;

namespace SolarSystem.Core
{
    //main solar system interface
    public static class SolarBuilder
    {
        /// <summary>
        /// Create simple planet 3D
        /// </summary>
        /// <returns></returns>
        public static GameObject CreatePlanet()
        {
            //new obj
            var planet = new GameObject();

            CreateSphere(planet);

            //add renderer
            var renderer = planet.AddComponent<MeshRenderer>();
            renderer.material = Resources.Load<Material>("Materials/PlanetMaterial");

            //add script
            planet.AddComponent<Object3D>();

            //add collider
            planet.AddComponent<SphereCollider>();

            return planet;
        }

        /// <summary>
        /// Create solar system's sun
        /// </summary>
        /// <returns></returns>
        public static GameObject CreateSun()
        {
            //new obj
            var sun = new GameObject();

            CreateSphere(sun);

            //add renderer
            var renderer = sun.AddComponent<MeshRenderer>();
            renderer.material = Resources.Load<Material>("Materials/SunMaterial");

            sun.AddComponent<Object3D>();
            sun.AddComponent<SphereCollider>();

            return sun;
        }

        /// <summary>
        /// Creates planets ring
        /// </summary>
        /// <returns></returns>
        public static GameObject CreateRing()
        {
            //new ring
            var ring = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Ring")) as GameObject;

            ring.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/RingMaterial");
            ring.AddComponent<Object3D>();

            return ring;
        }

        /// <summary>
        /// Creates simple sphere
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static void CreateSphere(GameObject obj)
        {
            //add filter + Create sphere mesh
            MeshFilter filter = obj.AddComponent<MeshFilter>();
            Mesh mesh = filter.mesh;
            mesh.Clear();

            float radius = PlanetSettings.radius;
            int nbLong = PlanetSettings.slices;
            int nbLat = PlanetSettings.rings;

            #region Vertices
            Vector3[] vertices = new Vector3[(nbLong + 1) * nbLat + 2];
            float _pi = Mathf.PI;
            float _2pi = _pi * 2f;

            vertices[0] = Vector3.up * radius;
            for (int lat = 0; lat < nbLat; lat++)
            {
                float a1 = _pi * (float)(lat + 1) / (nbLat + 1);
                float sin1 = Mathf.Sin(a1);
                float cos1 = Mathf.Cos(a1);

                for (int lon = 0; lon <= nbLong; lon++)
                {
                    float a2 = _2pi * (float)(lon == nbLong ? 0 : lon) / nbLong;
                    float sin2 = Mathf.Sin(a2);
                    float cos2 = Mathf.Cos(a2);

                    vertices[lon + lat * (nbLong + 1) + 1] = new Vector3(sin1 * cos2, cos1, sin1 * sin2) * radius;
                }
            }
            vertices[vertices.Length - 1] = Vector3.up * -radius;
            #endregion

            #region Normales		
            Vector3[] normales = new Vector3[vertices.Length];
            for (int n = 0; n < vertices.Length; n++)
                normales[n] = vertices[n].normalized;
            #endregion

            #region UVs
            Vector2[] uvs = new Vector2[vertices.Length];
            uvs[0] = Vector2.up;
            uvs[uvs.Length - 1] = Vector2.zero;
            for (int lat = 0; lat < nbLat; lat++)
                for (int lon = 0; lon <= nbLong; lon++)
                    uvs[lon + lat * (nbLong + 1) + 1] = new Vector2((float)lon / nbLong, 1f - (float)(lat + 1) / (nbLat + 1));
            #endregion

            #region Triangles
            int nbFaces = vertices.Length;
            int nbTriangles = nbFaces * 2;
            int nbIndexes = nbTriangles * 3;
            int[] triangles = new int[nbIndexes];

            //Top Cap
            int i = 0;
            for (int lon = 0; lon < nbLong; lon++)
            {
                triangles[i++] = lon + 2;
                triangles[i++] = lon + 1;
                triangles[i++] = 0;
            }

            //Middle
            for (int lat = 0; lat < nbLat - 1; lat++)
            {
                for (int lon = 0; lon < nbLong; lon++)
                {
                    int current = lon + lat * (nbLong + 1) + 1;
                    int next = current + nbLong + 1;

                    triangles[i++] = current;
                    triangles[i++] = current + 1;
                    triangles[i++] = next + 1;

                    triangles[i++] = current;
                    triangles[i++] = next + 1;
                    triangles[i++] = next;
                }
            }

            //Bottom Cap
            for (int lon = 0; lon < nbLong; lon++)
            {
                triangles[i++] = vertices.Length - 1;
                triangles[i++] = vertices.Length - (lon + 2) - 1;
                triangles[i++] = vertices.Length - (lon + 1) - 1;
            }
            #endregion

            mesh.vertices = vertices;
            mesh.normals = normales;
            mesh.uv = uvs;
            mesh.triangles = triangles;

            mesh.RecalculateBounds();
        }
    }
}
