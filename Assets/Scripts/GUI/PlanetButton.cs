using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SolarSystem.Interfaces;

namespace SolarSystem.GUI
{
    /// <summary>
    /// Stores IVisualSolarObject
    /// </summary>
    public class PlanetButton : MonoBehaviour
    {
        /// <summary>
        /// IVisualSolarObject which represents button
        /// </summary>
        public IVisualSolarObject SolarObject
        {
            get;
            set;
        }
    }
}
