using SolarSystem.Core;

namespace SolarSystem.MathObjects
{
    public static class MathObjectsFactory
    {
        /// <summary>
        /// Creates solar objects
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Create<T>() where T : AbstractObject, new()
        {
            return new T();
        }
    }
}
