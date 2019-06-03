using System.Collections.Generic;
using UnityEngine;
using SolarSystem.Core;

namespace SolarSystem.MathObjects
{
    using SolarMathObjects = List<AbstractObject>;

    /// <summary>
    /// Stores all math objects
    /// </summary>
    public static class AbstractObjectsContainer
    {
        //main storage field
        private static SolarMathObjects container;

        static AbstractObjectsContainer()
        {
            container = new SolarMathObjects();

            //Create and add math objects
            container.Add(MathObjectsFactory.Create<Stars.Sun>());
            container.Add(MathObjectsFactory.Create<Planets.Mercury>());
            container.Add(MathObjectsFactory.Create<Planets.Venus>());
            container.Add(MathObjectsFactory.Create<Planets.Earth>());
            container.Add(MathObjectsFactory.Create<Planets.Mars>());
            container.Add(MathObjectsFactory.Create<Planets.Jupiter>());
            container.Add(MathObjectsFactory.Create<Planets.Saturn>());
            container.Add(MathObjectsFactory.Create<Planets.Uranus>());
            container.Add(MathObjectsFactory.Create<Planets.Neptune>());
            container.Add(MathObjectsFactory.Create<DwarfPlanets.Pluto>());
            container.Add(MathObjectsFactory.Create<Moons.Moon>());
        }

        /// <summary>
        /// Returns abstract object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static AbstractObject SolarObject(Objects obj)
        {
            AbstractObject searchedObject = null;

            searchedObject = container.Find(
                delegate(AbstractObject o)
                {
                    return o.ObjectType() == obj;
                });

            return searchedObject;
        }

        /// <summary>
        /// Returns all abstract math objects
        /// </summary>
        /// <returns></returns>
        public static SolarMathObjects SolarObjects()
        {
            return container;
        }
    }
}
