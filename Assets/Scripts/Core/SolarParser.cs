using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SolarSystem.Core
{
    //parse solar values
    public static class SolarParser
    {
        /// <summary>
        /// Returns radius from obj
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static float parseSolarObjectsRadius(Objects obj)
        {
            float radius = 0;

            switch (obj)
            {
                case Objects.Sun:
                    radius = (float)ObjectsValues.Sun.radius;
                    break;

                case Objects.Mercury:
                    radius = (float)ObjectsValues.Mercury.radius;
                    break;

                case Objects.Venus:
                    radius = (float)ObjectsValues.Venus.radius;
                    break;

                case Objects.Earth:
                    radius = (float)ObjectsValues.Earth.radius;
                    break;

                case Objects.Mars:
                    radius = (float)ObjectsValues.Mars.radius;
                    break;

                case Objects.Jupiter:
                    radius = (float)ObjectsValues.Jupiter.radius;
                    break;

                case Objects.Saturn:
                    radius = (float)ObjectsValues.Saturn.radius;
                    break;

                case Objects.Uranus:
                    radius = (float)ObjectsValues.Uranus.radius;
                    break;

                case Objects.Neptune:
                    radius = (float)ObjectsValues.Neptune.radius;
                    break;

                case Objects.Pluto:
                    radius = (float)ObjectsValues.Pluto.radius;
                    break;

                case Objects.Moon:
                    radius = (float)ObjectsValues.Moon.radius;
                    break;

                default:
                    break;
            }

            return radius;
        }
    }
}
