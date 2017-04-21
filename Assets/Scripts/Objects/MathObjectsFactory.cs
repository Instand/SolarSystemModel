using SolarSystem.Core;

namespace SolarSystem
{
    //simple factory
    public static class MathObjectsFactory
    {
        /// <summary>
        /// Creates solar objects
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T create<T>() where T : AbstractObject, new()
        {
            return new T();
        }
    }
}
