using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SolarSystem.Interfaces
{
    //base interface for any 3d solar object
    public interface IVisualSolarObject
    {
        /// <summary>
        /// Sets core object type
        /// </summary>
        /// <param name="objectType"></param>
        void SetSolarType(Core.Objects objectType);

        /// <summary>
        /// Returns solar object typeS
        /// </summary>
        /// <returns></returns>
        Core.Objects ObjectType();

        /// <summary>
        /// Sets buddy for another solar object
        /// </summary>
        /// <param name="buddy"></param>
        void SetBuddy(IVisualSolarObject buddy);

        /// <summary>
        /// Returns object's buddy object
        /// </summary>
        /// <returns></returns>
        IVisualSolarObject Buddy();

        /// <summary>
        /// Returns gameobject of object
        /// </summary>
        /// <returns></returns>
        GameObject GetGameObject();

        /// <summary>
        /// Returns object transform
        /// </summary>
        /// <returns></returns>
        Transform GetTransform();

        /// <summary>
        /// Returns renderer
        /// </summary>
        /// <returns></returns>
        MeshRenderer GetRenderer();
    }
}
