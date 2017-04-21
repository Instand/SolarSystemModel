using System.Collections.Generic;
using UnityEngine;
using SolarSystem.Core;
using SolarSystem.MathObjects;

namespace SolarSystem.MathObjects
{
    using SolarMathObjects = List<AbstractObject>;
    
    //stores all math objects
    public static class AbstractObjectsContainer
    {
        //main storage field
        private static SolarMathObjects container;

        static AbstractObjectsContainer()
        {
            container = new List<AbstractObject>();

            //create and add math objects
            container.Add(MathObjectsFactory.create<Stars.Sun>());
            container.Add(MathObjectsFactory.create<Planets.Mercury>());
            container.Add(MathObjectsFactory.create<Planets.Venus>());
            container.Add(MathObjectsFactory.create<Planets.Earth>());
            container.Add(MathObjectsFactory.create<Planets.Mars>());
            container.Add(MathObjectsFactory.create<Planets.Jupiter>());
            container.Add(MathObjectsFactory.create<Planets.Saturn>());
            container.Add(MathObjectsFactory.create<Planets.Uranus>());
            container.Add(MathObjectsFactory.create<Planets.Neptune>());
            container.Add(MathObjectsFactory.create<DwarfPlanets.Pluto>());
            container.Add(MathObjectsFactory.create<Moons.Moon>());
        }

        /// <summary>
        /// Returns abstract object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static AbstractObject solarObject(Objects obj)
        {
            AbstractObject searchedObject = null;

            searchedObject = container.Find(
                delegate(AbstractObject o)
                {
                    return o.objectType() == obj;
                });

            return searchedObject;
        }

        /// <summary>
        /// Returns all abstract math objects
        /// </summary>
        /// <returns></returns>
        public static SolarMathObjects solarObjects()
        {
            return container;
        }
    }
}
