using System.Collections.Generic;
using UnityEngine;
using SolarSystem.Interfaces;

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

            //create objects from enum
            for (int i = 0; i < 11; ++i)
            {
                Core.Objects obj = (Core.Objects)i;

                //try to load from resources
                var loadedObject = Resources.Load<GameObject>(obj.ToString());

                if (loadedObject)
                {
                    var visualObject = loadedObject.GetComponent<IVisualSolarObject>();

                    if (visualObject != null)
                        visualObjects.Add(visualObject);
                }
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
        public IVisualSolarObject getObject(Core.Objects obj)
        {
            IVisualSolarObject searchedObject = null;

            searchedObject = visualObjects.Find(delegate (IVisualSolarObject visualObject) {
                return visualObject.objectType() == obj;
            });

            return searchedObject;
        }
    }
}
