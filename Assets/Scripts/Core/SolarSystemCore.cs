using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//core of solar system project
namespace SolarSystem.Core
{
    //stores different values for code help
    public static class Values
    {
        public const int zero = 0;
        public const int solarDistance = 2600000;
        public const float auScale = 149597.870700f;
        public const float saturnOuterRadius = 120.700f;
        public const float uranusOuterRadius = 40.0f;
        public const float startSize = 1800;
        public const float startSpeed = 1000000.0f;

        //time scale values
        public const int year = 2000;
        public const int month = 1;
        public const int day = 1;

        //vector values
        public static readonly Vector3 rollAxis = new Vector3(0, 1, 0);
        public static readonly Vector3 tiltAxis = new Vector3(0, 0, 1);
    }

    //solar system object type
    public enum ObjectType
    {
        SolarSystemBody,
        Planet,
        DwarfPlanet,
        Moon,
        Ring,
        Star,
        Asteroid,
        Galaxy
    }

    //enum of all solar objects
    //add new if you need
    public enum Objects
    {
        Sun,
        Mercury,
        Venus,
        Earth,
        Mars,
        Jupiter,
        Saturn,
        Uranus,
        Neptune,
        Moon,
        Pluto,

        //add here
        SaturnRing,
        UranusRing,
        EarthCloud,

        //calculate number
        SolarSystemView
    };

    //stores default camera settings
    public static class CameraSettings
    {
        //camera up vector
        public static readonly Vector3 defaultUp = new Vector3(0, 1, 0);

        //default position
        public static readonly Vector3 defaultCameraPosition = new Vector3(Values.solarDistance, Values.solarDistance, Values.solarDistance);

        //near plane/far plane settings
        public const float nearPlane = 2500000.0f;
        public const float farPlane = 20000000.0f;

        //fov
        public const int fieldOfView = 60;
    }

    //for planet class
    public static class PlanetSettings
    {
        public const float radius = 1.0f;
        public const bool generateTangents = true;
        public const int rings = 64;
        public const int slices = 64;
    }

    //planets math values
    public static class ObjectsValues
    {
        // Planet Data
        // radius - planet radius
        // tilt - planet axis angle
        // N1/2 - longitude of the ascending node
        // i1/2 - inclination to the ecliptic (plane of the Earth's orbit)
        // w1/2 - argument of perihelion
        // a1/2 - semi-major axis, or mean distance from Sun
        // e1/2 - eccentricity (0=circle, 0-1=ellipse, 1=parabola)
        // M1/2 - mean anomaly (0 at perihelion; increases uniformly with time)
        // period - sidereal rotation period
        // centerOfOrbit - the planet in the center of the orbit
        // (orbital elements based on http://www.stjarnhimlen.se/comp/ppcomp.html)

        //sun values
        public static class Sun
        {
            public const double radius = 694.439;
            public const double tilt = 63.87;
            public const double period = 25.05;
        }

        //mercury values
        public static class Mercury
        {
            public const double radius = 2.433722;
            public const double tilt = 0.04;
            public const double N1 = 48.3313;
            public const double N2 = 0.0000324587;
            public const double i1 = 7.0047;
            public const double i2 = 0.0000000500;
            public const double w1 = 29.1241;
            public const double w2 = 0.0000101444;
            public const double a1 = 0.387098;
            public const double a2 = 0;
            public const double e1 = 0.205635;
            public const double e2 = 0.000000000559;
            public const double M1 = 168.6562;
            public const double M2 = 4.0923344368;
            public const double period = 58.646;
            public const Objects centerOfOrbit = Objects.Sun;
        }

        //venus values
        public static class Venus
        {
            public const double radius = 6.046079;
            public const double tilt = 177.36;
            public const double N1 = 76.6799;
            public const double N2 = 0.0000246590;
            public const double i1 = 3.3946;
            public const double i2 = 0.0000000275;
            public const double w1 = 54.8910;
            public const double w2 = 0.0000138374;
            public const double a1 = 0.723330;
            public const double a2 = 0;
            public const double e1 = 0.006773;
            public const double e2 = -0.000000001302;
            public const double M1 = 48.0052;
            public const double M2 = 1.6021302244;
            public const double period = 243.0185;
            public const Objects centerOfOrbit = Objects.Sun;
        }

        //earth values
        public static class Earth
        {
            public const double radius = 6.371;
            public const double tilt = 25.44;
            public const double N1 = 174.873;
            public const double N2 = 0;
            public const double i1 = 0.00005;
            public const double i2 = 0;
            public const double w1 = 102.94719;
            public const double w2 = 0;
            public const double a1 = 1;
            public const double a2 = 0;
            public const double e1 = 0.01671022;
            public const double e2 = 0;
            public const double M1 = 357.529;
            public const double M2 = 0.985608;
            public const double period = 0.997;
            public const Objects centerOfOrbit = Objects.Sun;
        }

        //mars values
        public static class Mars
        {
            public const double radius = 3.389372;
            public const double tilt = 25.19;
            public const double N1 = 49.5574;
            public const double N2 = 0.0000211081;
            public const double i1 = 1.8497;
            public const double i2 = -0.0000000178;
            public const double w1 = 286.5016;
            public const double w2 = 0.0000292961;
            public const double a1 = 1.523688;
            public const double a2 = 0;
            public const double e1 = 0.093405;
            public const double e2 = 0.000000002516;
            public const double M1 = 18.6021;
            public const double M2 = 0.5240207766;
            public const double period = 1.025957;
            public const Objects centerOfOrbit = Objects.Sun;
        }

        //jupiter values
        public static class Jupiter
        {
            public const double radius = 71.41254;
            public const double tilt = 3.13;
            public const double N1 = 100.4542;
            public const double N2 = 0.0000276854;
            public const double i1 = 1.3030;
            public const double i2 = -0.0000001557;
            public const double w1 = 273.8777;
            public const double w2 = 0.0000164505;
            public const double a1 = 5.20256;
            public const double a2 = 0;
            public const double e1 = 0.048498;
            public const double e2 = 0.000000004469;
            public const double M1 = 19.8950;
            public const double M2 = 0.0830853001;
            public const double period = 0.4135;
            public const Objects centerOfOrbit = Objects.Sun;
        }

        //saturn values
        public static class Saturn
        {
            public const double radius = 60.19958;
            public const double tilt = 26.73;
            public const double N1 = 113.6634;
            public const double N2 = 0.0000238980;
            public const double i1 = 2.4886;
            public const double i2 = -0.0000001081;
            public const double w1 = 339.3939;
            public const double w2 = 0.0000297661;
            public const double a1 = 9.55475;
            public const double a2 = 0;
            public const double e1 = 0.055546;
            public const double e2 = -0.000000009499;
            public const double M1 = 316.9670;
            public const double M2 = 0.0334442282;
            public const double period = 0.4395;
            public const Objects centerOfOrbit = Objects.Sun;
        }

        //uranus values
        public static class Uranus
        {
            public const double radius = 25.5286;
            public const double tilt = 97.77;
            public const double N1 = 74.0005;
            public const double N2 = 0.000013978;
            public const double i1 = 0.7733;
            public const double i2 = 0.000000019;
            public const double w1 = 96.6612;
            public const double w2 = 0.000030565;
            public const double a1 = 19.18171;
            public const double a2 = -0.0000000155;
            public const double e1 = 0.047318;
            public const double e2 = 0.00000000745;
            public const double M1 = 142.5905;
            public const double M2 = 0.011725806;
            public const double period = 0.71833;
            public const Objects centerOfOrbit = Objects.Sun;
        }
        
        //neptune values
        public static class Neptune
        {
            public const double radius = 24.73859;
            public const double tilt = 28.32;
            public const double N1 = 131.7806;
            public const double N2 = 0.000030173;
            public const double i1 = 1.7700;
            public const double i2 = -0.000000255;
            public const double w1 = 272.8461;
            public const double w2 = 0.000006027;
            public const double a1 = 30.05826;
            public const double a2 = 0.00000003313;
            public const double e1 = 0.008606;
            public const double e2 = 0.00000000215;
            public const double M1 = 260.2471;
            public const double M2 = 0.005995147;
            public const double period = 0.6713;
            public const Objects centerOfOrbit = Objects.Sun;
        }

        //pluto values
        public static class Pluto
        {
            public const double radius = 1.187;            //radius
            public const double tilt = 120.00;
            public const double N1 = 110.30347;            //longitude
            public const double N2 = 0;
            public const double i1 = 17.14175;             //inclination
            public const double i2 = 0;
            public const double w1 = 113.834;              //perihelion
            public const double w2 = 0;
            public const double a1 = 39.48168677;          //semi-major axis
            public const double a2 = 0;
            public const double e1 = 0.24880766;           //eccentricity
            public const double e2 = 0;
            public const double M1 = 14.53;                //mean anomaly
            public const double M2 = 0;
            public const double period = 6.387230;         //siderial rotation period
            public const Objects centerOfOrbit = Objects.Sun;
        }

        //moon values
        public static class Moon
        {
            public const double radius = 1.5424;
            public const double tilt = 28.32;
            public const double N1 = 125.1228;
            public const double N2 = -0.0529538083;
            public const double i1 = 5.1454;
            public const double i2 = 0;
            public const double w1 = 318.0634;
            public const double w2 = 0.1643573223;
            public const double a1 = 0.273;
            public const double a2 = 0;
            public const double e1 = 0.054900;
            public const double e2 = 0;
            public const double M1 = 115.3654;
            public const double M2 = 13.0649929509;
            public const double period = 27.321582;
            public const Objects centerOfOrbit = Objects.Earth;
        }
    }
}
