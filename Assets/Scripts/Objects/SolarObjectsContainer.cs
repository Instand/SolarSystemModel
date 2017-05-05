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

            var count = (int)Objects.SaturnRing;

            //create sun
            var sun = SolarBuilder.createSun();
            var sunObj = sun.GetComponent<IVisualSolarObject>();

            if (sunObj != null)
            {
                sunObj.setSolarType(Objects.Sun);
                sun.name = Objects.Sun.ToString();

                //renderer
                sunObj.getRenderer().material.mainTexture = Resources.Load<Texture2D>("Textures/sunmap");

                //add sun to container
                visualObjects.Add(sunObj);
            }

            //create objects from enum
            for (int i = 1; i < count; ++i)
            {
                Objects obj = (Objects)i;

                //create planets
                var planet = SolarBuilder.createPlanet();
                var visualObj = planet.GetComponent<IVisualSolarObject>();

                if (visualObj != null)
                {
                    visualObj.setSolarType(obj);
                    planet.name = obj.ToString();

                    //config renderer
                    rendererTexture(visualObj);

                    //add planet to container
                    visualObjects.Add(visualObj);
                }
            }

            //create rings
            var saturnRing = SolarBuilder.createRing();
            var saturnRingInterface = saturnRing.GetComponent<IVisualSolarObject>();

            if (saturnRingInterface != null)
            {
                saturnRingInterface.setSolarType(Objects.SaturnRing);
                saturnRing.name = Objects.SaturnRing.ToString();

                //buddy
                var saturn = getObject(Objects.Saturn);

                if (saturn != null)
                    saturnRingInterface.setBuddy(saturn);

                //config renderer + add object
                rendererTexture(saturnRingInterface);
                visualObjects.Add(saturnRingInterface);
            }
        }

        /// <summary>
        /// Returns all 3d objectd
        /// </summary>
        /// <returns></returns>
        public List<IVisualSolarObject> objects()
        {
            return visualObjects;
        }

        /// <summary>
        /// Returns visual object from obj
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public IVisualSolarObject getObject(Objects obj)
        {
            IVisualSolarObject searchedObject = null;

            searchedObject = visualObjects.Find(delegate (IVisualSolarObject visualObject) {
                return visualObject.objectType() == obj;
            });

            return searchedObject;
        }

        /// <summary>
        /// Sets texture for each planet
        /// </summary>
        /// <param name="obj"></param>
        private void rendererTexture(IVisualSolarObject obj)
        {
            var renderer = obj.getRenderer();

            switch(obj.objectType())
            {
                case Objects.Earth:
                    renderer.material.mainTexture = Resources.Load<Texture2D>("Textures/earthmap");
                    break;

                case Objects.Mercury:
                    renderer.material.mainTexture = Resources.Load<Texture2D>("Textures/mercurymap");
                    break;

                case Objects.Venus:
                    renderer.material.mainTexture = Resources.Load<Texture2D>("Textures/venusmap");
                    break;

                case Objects.Mars:
                    renderer.material.mainTexture = Resources.Load<Texture2D>("Textures/marsmap");
                    break;

                case Objects.Jupiter:
                    renderer.material.mainTexture = Resources.Load<Texture2D>("Textures/jupitermap");
                    break;

                case Objects.Saturn:
                    renderer.material.mainTexture = Resources.Load<Texture2D>("Textures/saturnmap");
                    break;

                case Objects.Uranus:
                    renderer.material.mainTexture = Resources.Load<Texture2D>("Textures/uranusmap");
                    break;

                case Objects.Neptune:
                    renderer.material.mainTexture = Resources.Load<Texture2D>("Textures/neptunemap");
                    break;

                case Objects.Pluto:
                    renderer.material.mainTexture = Resources.Load<Texture2D>("Textures/plutomap");
                    break;

                case Objects.Moon:
                    renderer.material.mainTexture = Resources.Load<Texture2D>("Textures/moonmap");
                    break;

                case Objects.SaturnRing:
                    renderer.material.mainTexture = Resources.Load<Texture2D>("Textures/saturnring");
                    break;

                default:
                    break;
            }
        }
    }
}
