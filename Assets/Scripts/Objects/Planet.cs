using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SolarSystem.Interfaces;
using SolarSystem.Core;

namespace SolarSystem.Objects3D
{
    //base planet behaviour
    public class Planet : MonoBehaviour, IVisualSolarObject
    {
        [SerializeField]
        private Objects solarType;
        private IVisualSolarObject buddyObject = null;
        private GameObject baseObject = null;
        private Transform baseTransform = null;

        //hash and setup
        private void Awake()
        {
            baseObject = gameObject;
            baseTransform = transform;
        }

        /// <summary>
        /// Returns object's buddy object
        /// </summary>
        /// <returns></returns>
        public IVisualSolarObject buddy()
        {
            return buddyObject;
        }

        /// <summary>
        /// Returns object solar type
        /// </summary>
        /// <returns></returns>
        public Objects objectType()
        {
            return solarType;
        }

        /// <summary>
        /// Sets object buddy
        /// </summary>
        /// <param name="buddy"></param>
        public void setBuddy(IVisualSolarObject buddy)
        {
            buddyObject = buddy;
        }

        /// <summary>
        /// Sets object type
        /// </summary>
        /// <param name="objectType"></param>
        public void setSolarType(Objects objectType)
        {
            solarType = objectType;
        }

        /// <summary>
        /// Returns gameobject
        /// </summary>
        /// <returns></returns>
        public GameObject getGameObject()
        {
            return baseObject;
        }

        /// <summary>
        /// Returns transform
        /// </summary>
        /// <returns></returns>
        public Transform getTransform()
        {
            return baseTransform;
        }
    }
}
