using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SolarSystem.Core
{
    /// <summary>
    /// Simple representation of math solar object
    /// </summary>
    public abstract class AbstractObject
    {
        //main data
        protected double radius = 0;
        protected double tilt = 0;
        protected double n1 = 0;
        protected double n2 = 0;
        protected double i1 = 0;
        protected double i2 = 0;
        protected double w1 = 0;
        protected double w2 = 0;
        protected double a1 = 0;
        protected double a2 = 0;
        protected double e1 = 0;
        protected double e2 = 0;
        protected double m1 = 0;
        protected double m2 = 0;
        protected double period = 0;
        protected double x = 0;
        protected double y = 0;
        protected double z = 0;
        protected double roll = 0;
        protected Objects centerOfOrbit;
        protected Objects objectType;

        //protected in constructor
        protected abstract void Initialize();

        public AbstractObject()
        {
            Initialize();
        }

        /// <summary>
        /// returns radius
        /// </summary>
        /// <returns></returns>
        public double Radius()
        {
            return radius;
        }

        /// <summary>
        /// sets radius
        /// </summary>
        /// <param name="radius"></param>
        public void SetRadius(double radius)
        {
            this.radius = radius;
        }

        /// <summary>
        /// returns tilt
        /// </summary>
        /// <returns></returns>
        public double Tilt()
        {
            return tilt;
        }

        /// <summary>
        /// sets tilt
        /// </summary>
        /// <param name="tilt"></param>
        public void SetTilt(double tilt)
        {

        }

        /// <summary>
        /// returns roll
        /// </summary>
        /// <returns></returns>
        public double Roll()
        {
            return roll;
        }

        /// <summary>
        /// sets roll
        /// </summary>
        /// <param name="roll"></param>
        public void SetRoll(double roll)
        {
            this.roll = roll;
        }

        /// <summary>
        /// returns x cord
        /// </summary>
        /// <returns></returns>
        public double X()
        {
            return x;
        }

        /// <summary>
        /// sets x cord
        /// </summary>
        /// <param name="x"></param>
        public void SetX(double x)
        {
            this.x = x;
        }

        /// <summary>
        /// returns y cord
        /// </summary>
        /// <returns></returns>
        public double Y()
        {
            return y;
        }

        /// <summary>
        /// sets y cord
        /// </summary>
        /// <param name="y"></param>
        public void SetY(double y)
        {
            this.y = y;
        }

        /// <summary>
        /// returns z cord
        /// </summary>
        /// <returns></returns>
        public double Z()
        {
            return z;
        }

        /// <summary>
        /// sets z cord
        /// </summary>
        /// <param name="z"></param>
        public void SetZ(double z)
        {
            this.z = z;
        }

        /// <summary>
        /// returns n1 atribute
        /// </summary>
        /// <returns></returns>
        public double N1()
        {
            return n1;
        }

        /// <summary>
        /// returns n2 atribute
        /// </summary>
        /// <returns></returns>
        public double N2()
        {
            return n2;
        }

        /// <summary>
        /// returns i1 atribute
        /// </summary>
        /// <returns></returns>
        public double I1()
        {
            return i1;
        }

        /// <summary>
        /// returns i2 atribute
        /// </summary>
        /// <returns></returns>
        public double I2()
        {
            return i2;
        }

        /// <summary>
        /// returns w1 atribute
        /// </summary>
        /// <returns></returns>
        public double W1()
        {
            return w1;
        }

        /// <summary>
        /// return w2 atribute
        /// </summary>
        /// <returns></returns>
        public double W2()
        {
            return w2;
        }

        /// <summary>
        /// returns a1 atribute
        /// </summary>
        /// <returns></returns>
        public double A1()
        {
            return a1;
        }

        /// <summary>
        /// returns a2 atribute
        /// </summary>
        /// <returns></returns>
        public double A2()
        {
            return a2;
        }

        /// <summary>
        /// returns e1 atribute
        /// </summary>
        /// <returns></returns>
        public double E1()
        {
            return e1;
        }

        /// <summary>
        /// returns e2 atribute
        /// </summary>
        /// <returns></returns>
        public double E2()
        {
            return e2;
        }

        /// <summary>
        /// returns m1 atribute
        /// </summary>
        /// <returns></returns>
        public double M1()
        {
            return m1;
        }

        /// <summary>
        /// returns m2 atribute
        /// </summary>
        /// <returns></returns>
        public double M2()
        {
            return m2;
        }

        /// <summary>
        /// returns object period
        /// </summary>
        /// <returns></returns>
        public double Period()
        {
            return period;
        }

        /// <summary>
        /// returns object orbit center
        /// </summary>
        /// <returns></returns>
        public Objects CenterOfOrbit()
        {
            return centerOfOrbit;
        }

        /// <summary>
        /// returns object type
        /// </summary>
        public Objects ObjectType()
        {
            return objectType;
        }
    }
}
