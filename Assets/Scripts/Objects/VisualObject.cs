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
        void setSolarType(Core.Objects objectType);

        /// <summary>
        /// Returns solar object typeS
        /// </summary>
        /// <returns></returns>
        Core.Objects objectType();

        /// <summary>
        /// Sets buddy for another solar object
        /// </summary>
        /// <param name="buddy"></param>
        void setBuddy(IVisualSolarObject buddy);

        /// <summary>
        /// Returns object's buddy object
        /// </summary>
        /// <returns></returns>
        IVisualSolarObject buddy();

        /// <summary>
        /// Returns gameobject of object
        /// </summary>
        /// <returns></returns>
        GameObject getGameObject();

        /// <summary>
        /// Returns object transform
        /// </summary>
        /// <returns></returns>
        Transform getTransform();

        /// <summary>
        /// Returns renderer
        /// </summary>
        /// <returns></returns>
        MeshRenderer getRenderer();
    }
}
