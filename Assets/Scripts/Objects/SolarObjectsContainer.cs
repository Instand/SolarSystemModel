using System.Collections.Generic;
using UnityEngine;
using SolarSystem.Interfaces;
using SolarSystem.Core;

namespace SolarSystem.Objects3D
{
    //represents container with 3d objects
    public class SolarObjectsContainer
    {
        //3d objects container
        private List<IVisualSolarObject> visualObjects;

        public SolarObjectsContainer()
        {
            visualObjects = new List<IVisualSolarObject>();

            var count = (int)Core.Objects.SaturnRing;

            //Create sun
            var sun = SolarBuilder.CreateSun();
            var sunObj = sun.GetComponent<IVisualSolarObject>();

            if (sunObj != null)
            {
                sunObj.SetSolarType(Core.Objects.Sun);
                sun.name = Core.Objects.Sun.ToString();

                //renderer
                sunObj.GetRenderer().material.mainTexture = Resources.Load<Texture2D>("Textures/sunmap");

                //add sun to container
                visualObjects.Add(sunObj);
            }

            //Create objects from enum
            for (int i = 1; i < count; ++i)
            {
                Objects obj = (Objects)i;

                //Create planets
                var planet = SolarBuilder.CreatePlanet();
                var visualObj = planet.GetComponent<IVisualSolarObject>();

                if (visualObj != null)
                {
                    visualObj.SetSolarType(obj);
                    planet.name = obj.ToString();

                    //config renderer
                    RendererTexture(visualObj);

                    //add planet to container
                    visualObjects.Add(visualObj);
                }
            }

            //Create saturn ring
            var saturnRing = SolarBuilder.CreateRing();
            var saturnRingInterface = saturnRing.GetComponent<IVisualSolarObject>();

            if (saturnRingInterface != null)
            {
                saturnRingInterface.SetSolarType(Core.Objects.SaturnRing);
                saturnRing.name = Core.Objects.SaturnRing.ToString();

                //buddy
                var saturn = GetObject(Core.Objects.Saturn);

                if (saturn != null)
                    saturnRingInterface.SetBuddy(saturn);

                //config renderer + add object
                RendererTexture(saturnRingInterface);
                visualObjects.Add(saturnRingInterface);
            }

            //Create uranus ring
            var uranusRing = SolarBuilder.CreateRing();
            var uranusRingInterface = uranusRing.GetComponent<IVisualSolarObject>();

            if (uranusRingInterface != null)
            {
                uranusRingInterface.SetSolarType(Core.Objects.UranusRing);
                uranusRing.name = Core.Objects.UranusRing.ToString();

                //buddy
                var uranus = GetObject(Core.Objects.Uranus);

                if (uranus != null)
                    uranusRingInterface.SetBuddy(uranus);

                RendererTexture(uranusRingInterface);
                visualObjects.Add(uranusRingInterface);
            }
        }

        /// <summary>
        /// Returns all 3d objectd
        /// </summary>
        /// <returns></returns>
        public List<IVisualSolarObject> Objects()
        {
            return visualObjects;
        }

        /// <summary>
        /// Returns visual object from obj
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public IVisualSolarObject GetObject(Objects obj)
        {
            IVisualSolarObject searchedObject = null;

            searchedObject = visualObjects.Find(delegate (IVisualSolarObject visualObject) {
                return visualObject.ObjectType() == obj;
            });

            return searchedObject;
        }

        /// <summary>
        /// Sets texture for each planet
        /// </summary>
        /// <param name="obj"></param>
        private void RendererTexture(IVisualSolarObject obj)
        {
            var renderer = obj.GetRenderer();

            switch(obj.ObjectType())
            {
                case Core.Objects.Earth:
                    renderer.material.mainTexture = Resources.Load<Texture2D>("Textures/earthmap");
                    break;

                case Core.Objects.Mercury:
                    renderer.material.mainTexture = Resources.Load<Texture2D>("Textures/mercurymap");
                    break;

                case Core.Objects.Venus:
                    renderer.material.mainTexture = Resources.Load<Texture2D>("Textures/venusmap");
                    break;

                case Core.Objects.Mars:
                    renderer.material.mainTexture = Resources.Load<Texture2D>("Textures/marsmap");
                    break;

                case Core.Objects.Jupiter:
                    renderer.material.mainTexture = Resources.Load<Texture2D>("Textures/jupitermap");
                    break;

                case Core.Objects.Saturn:
                    renderer.material.mainTexture = Resources.Load<Texture2D>("Textures/saturnmap");
                    break;

                case Core.Objects.Uranus:
                    renderer.material.mainTexture = Resources.Load<Texture2D>("Textures/uranusmap");
                    break;

                case Core.Objects.Neptune:
                    renderer.material.mainTexture = Resources.Load<Texture2D>("Textures/neptunemap");
                    break;

                case Core.Objects.Pluto:
                    renderer.material.mainTexture = Resources.Load<Texture2D>("Textures/plutomap");
                    break;

                case Core.Objects.Moon:
                    renderer.material.mainTexture = Resources.Load<Texture2D>("Textures/moonmap");
                    break;

                case Core.Objects.SaturnRing:
                    renderer.material.mainTexture = Resources.Load<Texture2D>("Textures/saturnring");
                    break;

                case Core.Objects.UranusRing:
                    renderer.material.mainTexture = Resources.Load<Texture2D>("Textures/uranusring");
                    break;

                default:
                    break;
            }
        }
    }
}
