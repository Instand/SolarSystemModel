using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SolarSystem.Interfaces;
using SolarSystem.Core;

namespace SolarSystem.Objects3D
{
    /// <summary>
    /// Represents solar 3d object in space
    /// </summary>
    public class Object3D : MonoBehaviour, IVisualSolarObject
    {
        private Objects solarType;
        private IVisualSolarObject buddyObject = null;
        private GameObject baseObject = null;
        private Transform baseTransform = null;
        private MeshRenderer baseRenderer = null;

        //hash and setup
        private void Awake()
        {
            baseObject = gameObject;
            baseTransform = transform;
            baseRenderer = GetComponent<MeshRenderer>();
        }

        /// <summary>
        /// Returns object's buddy object
        /// </summary>
        /// <returns></returns>
        public IVisualSolarObject Buddy()
        {
            return buddyObject;
        }

        /// <summary>
        /// Returns object solar type
        /// </summary>
        /// <returns></returns>
        public Objects ObjectType()
        {
            return solarType;
        }

        /// <summary>
        /// Sets object buddy
        /// </summary>
        /// <param name="buddy"></param>
        public void SetBuddy(IVisualSolarObject buddy)
        {
            buddyObject = buddy;
        }

        /// <summary>
        /// Sets object type
        /// </summary>
        /// <param name="objectType"></param>
        public void SetSolarType(Objects objectType)
        {
            solarType = objectType;
        }

        /// <summary>
        /// Returns gameobject
        /// </summary>
        /// <returns></returns>
        public GameObject GetGameObject()
        {
            return baseObject;
        }

        /// <summary>
        /// Returns transform
        /// </summary>
        /// <returns></returns>
        public Transform GetTransform()
        {
            return baseTransform;
        }

        /// <summary>
        /// Returns renderer
        /// </summary>
        /// <returns></returns>
        public MeshRenderer GetRenderer()
        {
            return baseRenderer;
        }
    }
}
