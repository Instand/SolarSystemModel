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
    }
}
