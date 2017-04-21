using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SolarSystem.Core
{
    //simple representation of math solar object
    public abstract class AbstractObject
    {
        //main data
        protected double _radius = 0;
        protected double _tilt = 0;
        protected double _N1 = 0;
        protected double _N2 = 0;
        protected double _i1 = 0;
        protected double _i2 = 0;
        protected double _w1 = 0;
        protected double _w2 = 0;
        protected double _a1 = 0;
        protected double _a2 = 0;
        protected double _e1 = 0;
        protected double _e2 = 0;
        protected double _M1 = 0;
        protected double _M2 = 0;
        protected double _period = 0;
        protected double _x = 0;
        protected double _y = 0;
        protected double _z = 0;
        protected double _roll = 0;
        protected Objects _centerOfOrbit;
        protected Objects _objectType;

        //protected in constructor
        protected abstract void initialize();

        /// <summary>
        /// returns radius
        /// </summary>
        /// <returns></returns>
        public double radius()
        {
            return _radius;
        }

        /// <summary>
        /// sets radius
        /// </summary>
        /// <param name="radius"></param>
        public void setRadius(double radius)
        {
            _radius = radius;
        }

        /// <summary>
        /// returns tilt
        /// </summary>
        /// <returns></returns>
        public double tilt()
        {
            return _tilt;
        }

        /// <summary>
        /// sets tilt
        /// </summary>
        /// <param name="tilt"></param>
        public void setTilt(double tilt)
        {

        }

        /// <summary>
        /// returns roll
        /// </summary>
        /// <returns></returns>
        public double roll()
        {
            return _roll;
        }

        /// <summary>
        /// sets roll
        /// </summary>
        /// <param name="roll"></param>
        public void setRoll(double roll)
        {
            _roll = roll;
        }

        /// <summary>
        /// returns x cord
        /// </summary>
        /// <returns></returns>
        public double x()
        {
            return _x;
        }

        /// <summary>
        /// sets x cord
        /// </summary>
        /// <param name="x"></param>
        public void setX(double x)
        {
            _x = x;
        }

        /// <summary>
        /// returns y cord
        /// </summary>
        /// <returns></returns>
        public double y()
        {
            return _y;
        }

        /// <summary>
        /// sets y cord
        /// </summary>
        /// <param name="y"></param>
        public void setY(double y)
        {
            _y = y;
        }

        /// <summary>
        /// returns z cord
        /// </summary>
        /// <returns></returns>
        public double z()
        {
            return _z;
        }

        /// <summary>
        /// sets z cord
        /// </summary>
        /// <param name="z"></param>
        public void setZ(double z)
        {
            _z = z;
        }

        /// <summary>
        /// returns n1 atribute
        /// </summary>
        /// <returns></returns>
        public double N1()
        {
            return _N1;
        }

        /// <summary>
        /// returns n2 atribute
        /// </summary>
        /// <returns></returns>
        public double N2()
        {
            return _N2;
        }

        /// <summary>
        /// returns i1 atribute
        /// </summary>
        /// <returns></returns>
        public double i1()
        {
            return _i1;
        }

        /// <summary>
        /// returns i2 atribute
        /// </summary>
        /// <returns></returns>
        public double i2()
        {
            return _i2;
        }

        /// <summary>
        /// returns w1 atribute
        /// </summary>
        /// <returns></returns>
        public double w1()
        {
            return _w1;
        }

        /// <summary>
        /// return w2 atribute
        /// </summary>
        /// <returns></returns>
        public double w2()
        {
            return _w2;
        }

        /// <summary>
        /// returns a1 atribute
        /// </summary>
        /// <returns></returns>
        public double a1()
        {
            return _a1;
        }

        /// <summary>
        /// returns a2 atribute
        /// </summary>
        /// <returns></returns>
        public double a2()
        {
            return _a2;
        }

        /// <summary>
        /// returns e1 atribute
        /// </summary>
        /// <returns></returns>
        public double e1()
        {
            return _e1;
        }

        /// <summary>
        /// returns e2 atribute
        /// </summary>
        /// <returns></returns>
        public double e2()
        {
            return _e2;
        }

        /// <summary>
        /// returns m1 atribute
        /// </summary>
        /// <returns></returns>
        public double M1()
        {
            return _M1;
        }

        /// <summary>
        /// returns m2 atribute
        /// </summary>
        /// <returns></returns>
        public double M2()
        {
            return _M2;
        }

        /// <summary>
        /// returns object period
        /// </summary>
        /// <returns></returns>
        public double period()
        {
            return _period;
        }

        /// <summary>
        /// returns object orbit center
        /// </summary>
        /// <returns></returns>
        public Objects centerOfOrbit()
        {
            return _centerOfOrbit;
        }

        /// <summary>
        /// returns object type
        /// </summary>
        public Objects objectType()
        {
            return _objectType;
        }
    }
}
