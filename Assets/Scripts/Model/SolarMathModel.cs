using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SolarSystem.Core;
using SolarSystem.MathObjects;
using System;
using SolarSystem.Controller;
using SolarSystem.Objects3D;

namespace SolarSystem.Model
{
    //represents base solar system model
    public static class SolarMathModel
    {
        //time vars
        private static int year = Values.year;
        private static int month = Values.month;
        private static int day = Values.day;
        private static int hours = 0;
        private static int minutes = 0;
        private static float seconds = 0;

        //date
        private static DateTime solarTime = new DateTime(year, month, day);

        //dt
        private static float deltaTime = 0;

        // Time scale formula based on http://www.stjarnhimlen.se/comp/ppcomp.html
        private static double startD;
        private static double oldTimeD;
        private static double currentTimeD;
        private static double deltaTimeD = 0;
        private static double daysPerFrame = 0;
        private static double daysPerFrameScale = 0;
        private static float planetScale = 0;
        private static bool focusedScaling = false;
        private static int focusedMinimumScale = 20;
        private static double actualScale = 0;
        private static double ultraSpeed = 1.0;
        /*private static float ultraSpeedStep = 2.0f;
        private static double ultraSpeedMax = 64.0;*/
        private const float saturnRingScale = 1.95f;
        private const float uranusRingScale = 1.75f;

        //save
        private static double savedDaysPerFrameScale = 0;

        //inner and outer radius
        private static double saturnRingInnerRadius = 0;
        private static double saturnRingOuterRadius = 0;
        private static double uranusRingInnerRadius = 0;
        private static double uranusRingOuterRadius = 0;

        //3d container
        private static SolarObjectsContainer solarSystemObjects;

        //solar view
        private static OrbitController cameraController = null;

        //orbit controller
        public static OrbitController CameraController
        {
            get
            {
                return cameraController;
            }
        }

        static SolarMathModel()
        {
            solarSystemObjects = new SolarObjectsContainer();

            //calculating start time
            startD = 367 * year - 7.0f * (year + (month + 9.0f) / 12.0f) / 4.0f + 275.0f * month / 9.0f + day - 730530.0f;
            startD += calculateUT(hours, minutes, seconds);
            oldTimeD = startD;
            currentTimeD = startD;

            //calcualting saturn and uranus rings
            var saturn = AbstractObjectsContainer.solarObject(Objects.Saturn);

            if (saturn != null)
            {
                saturnRingOuterRadius = saturn.radius() + Values.saturnOuterRadius;
                saturnRingInnerRadius = saturn.radius() + 6.630;
            }

            var uranus = AbstractObjectsContainer.solarObject(Objects.Uranus);

            if (uranus != null)
            {
                uranusRingOuterRadius = uranus.radius() + Values.uranusOuterRadius;
                uranusRingInnerRadius = uranus.radius() + 2.0;
            }

            cameraController = Camera.main.gameObject.GetComponent<OrbitController>();
        }

        //get list of 3d objects
        public static List<Interfaces.IVisualSolarObject> objects3D()
        {
            return solarSystemObjects.objects();
        }

        //get container
        public static SolarObjectsContainer container3D()
        {
            return solarSystemObjects;
        }

        //helpers
        private static float calculateTimeScale(int year, int month, int day)
        {
            return 367.0f * year - 7.0f * (year + (month + 9.0f) / 12.0f) / 4.0f + 275.0f * month / 9.0f + day - 730530.0f;
        }

        private static float calculateUT(int h, int m, float s)
        {
            return (h + m / 60.0f + s / 3600.0f) / 24.0f;
        }

        /// <summary>
        /// Next time calculation
        /// </summary>
        /// <param name="obj"></param>
        public static void advanceTime(Objects obj)
        {
            var solarObject = AbstractObjectsContainer.solarObject(obj);

            if (obj == Objects.SolarSystemView)
                daysPerFrame = daysPerFrameScale;
            else if (obj == Objects.Mercury || obj == Objects.Venus)
                daysPerFrame = daysPerFrameScale * solarObject.period() / 25000.0;
            else
                daysPerFrame = daysPerFrameScale * solarObject.period() / 100.0;

            //add solar time
            solarTime = solarTime.AddMilliseconds(deltaTime * 1000.0f * daysPerFrame * ultraSpeed);

            //save helpers values
            hours = solarTime.Hour;
            minutes = solarTime.Minute;
            seconds = solarTime.Second;
            year = solarTime.Year;
            month = solarTime.Month;
            day = solarTime.Day;

            //Advance the time in days
            oldTimeD = currentTimeD;

            //update currentTimeD
            currentTimeD = calculateTimeScale(year, month, day);
            currentTimeD += calculateUT(hours, minutes, seconds);

            //get deltaD
            deltaTimeD = currentTimeD - oldTimeD;
        }

        /// <summary>
        /// Returns objects outer radius
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static float outerRadius(Objects obj)
        {
            double outerRadius = Values.solarDistance;

            switch (obj)
            {
                case Objects.Mercury:
                    outerRadius += ObjectsValues.Mercury.radius;
                    break;

                case Objects.Venus:
                    outerRadius += ObjectsValues.Venus.radius;
                    break;

                case Objects.Earth:
                    outerRadius += ObjectsValues.Earth.radius;
                    break;

                case Objects.Mars:
                    outerRadius += ObjectsValues.Mars.radius;
                    break;

                case Objects.Jupiter:
                    outerRadius += ObjectsValues.Jupiter.radius;
                    break;

                case Objects.Neptune:
                    outerRadius += ObjectsValues.Neptune.radius;
                    break;

                case Objects.Saturn:
                    outerRadius += ObjectsValues.Saturn.radius + Values.saturnOuterRadius;
                    break;

                case Objects.Uranus:
                    outerRadius += ObjectsValues.Uranus.radius + Values.uranusOuterRadius;
                    break;

                case Objects.Moon:
                    outerRadius += ObjectsValues.Moon.radius;
                    break;

                case Objects.Pluto:
                    outerRadius += ObjectsValues.Pluto.radius;
                    break;

                case Objects.Sun:
                    outerRadius = ObjectsValues.Sun.radius / 100.0;
                    break;

                default:
                    break;
            }

            return (float)outerRadius;
        }

        /// <summary>
        /// Sets math solar objects scale
        /// </summary>
        /// <param name="scale"></param>
        /// <returns></returns>
        public static float objectsScale(float scale, bool focused)
        {
            // Save actual scale
            if (!focused)
                actualScale = scale;

            // Limit minimum scaling in focus mode to avoid jitter caused by rounding errors
            if (scale <= focusedMinimumScale && (focusedScaling || focused))
                planetScale = focusedMinimumScale;
            else
                planetScale = (float)actualScale;

            return planetScale;
        }

        /// <summary>
        /// Change objects scale
        /// </summary>
        /// <param name="scale"></param>
        /// <param name="focused"></param>
        public static void changeObjectsScale(float scale, bool focused)
        {
            if (!focused)
                actualScale = scale;

            if (scale <= focusedMinimumScale && (focusedScaling || focused))
                planetScale = focusedMinimumScale;
            else
                planetScale = (float)actualScale;
        }

        /// <summary>
        /// Checks math object scaling
        /// </summary>
        /// <param name="obj"></param>
        public static void checkObjectScaling(Objects obj)
        {
            if (obj != Objects.SolarSystemView)
            {
                // Limit minimum scaling in focus mode to avoid jitter caused by rounding errors
                if (actualScale <= focusedMinimumScale)
                {
                    planetScale = focusedMinimumScale;
                    changeObjectsScale(focusedMinimumScale, true);
                }

                focusedScaling = true;
            }
            else if (focusedScaling == true)
            {
                // Restore normal scaling
                focusedScaling = false;
                changeObjectsScale((float)actualScale, false);
            }
        }

        /// <summary>
        /// Real time solar object position calculating
        /// </summary>
        /// <param name="obj"></param>
        public static void calculateObjectPosition(Objects obj)
        {
            //get planet
            var solarObj = AbstractObjectsContainer.solarObject(obj);

            //object exists
            if (solarObj != null)
            {
                //calculation only for solar system planets
                switch (obj)
                {
                    case Objects.Sun:
                        break;

                    case Objects.Mercury:
                    case Objects.Earth:
                    case Objects.Venus:
                    case Objects.Mars:
                    case Objects.Jupiter:
                    case Objects.Saturn:
                    case Objects.Uranus:
                    case Objects.Neptune:
                    case Objects.Pluto:
                    case Objects.Moon:

                        // Calculate the planet orbital elements from the current time in days
                        var N = (solarObj.N1() + solarObj.N2() * currentTimeD) * Math.PI / 180;
                        var iPlanet = (solarObj.i1() + solarObj.i2() * currentTimeD) * Math.PI / 180;
                        var w = (solarObj.w1() + solarObj.w2() * currentTimeD) * Math.PI / 180;
                        var a = solarObj.a1() + solarObj.a2() * currentTimeD;
                        var e = solarObj.e1() + solarObj.e2() * currentTimeD;
                        var M = (solarObj.M1() + solarObj.M2() * currentTimeD) * Math.PI / 180;
                        var E = M + e * Math.Sin(M) * (1.0 + e * Math.Cos(M));

                        var xv = a * (Math.Cos(E) - e);
                        var yv = a * (Math.Sqrt(1.0 - e * e) * Math.Sin(E));
                        var v = Math.Atan2(yv, xv);

                        // Calculate the distance (radius)
                        var r = Math.Sqrt(xv * xv + yv * yv);

                        // From http://www.davidcolarusso.com/astro/
                        // Modified to compensate for the right handed coordinate system of OpenGL
                        var xh = r * (Math.Cos(N) * Math.Cos(v + w) - Math.Sin(N) * Math.Sin(v + w) * Math.Cos(iPlanet));
                        var zh = -r * (Math.Sin(N) * Math.Cos(v + w) + Math.Cos(N) * Math.Sin(v + w) * Math.Cos(iPlanet));
                        var yh = r * (Math.Sin(w + v) * Math.Sin(iPlanet));

                        // Apply the position offset from the center of orbit to the bodies
                        Objects centerOfOrbit = solarObj.centerOfOrbit();
                        var centerObj = AbstractObjectsContainer.solarObject(centerOfOrbit);

                        solarObj.setX(centerObj.x() + xh * Values.auScale);
                        solarObj.setY(centerObj.y() + yh * Values.auScale);
                        solarObj.setZ(centerObj.z() + zh * Values.auScale);
                        break;

                    default:
                        break;
                }

                //roll
                solarObj.setRoll((solarObj.roll() + deltaTimeD / solarObj.period() * 360.0));

                //recalculation to 3D objects
                Interfaces.IVisualSolarObject visualObj = solarSystemObjects.getObject(obj);

                if (visualObj != null)
                {
                    visualObj.getTransform().position = new Vector3((float)solarObj.x(), (float)solarObj.y(), (float)solarObj.z());
                    visualObj.getTransform().rotation = Quaternion.AngleAxis(-(float)solarObj.tilt(), Values.tiltAxis) * Quaternion.AngleAxis((float)solarObj.roll(), Values.rollAxis);
                }
            }
            else
            {
                //rings calculation
                switch (obj)
                {
                    case Objects.SaturnRing:

                        //saturn ring 3d
                        var saturnRing = solarSystemObjects.getObject(obj);

                        //saturn
                        var saturn = saturnRing.buddy();

                        if (saturnRing != null && saturn != null)
                        {
                            //calculate data
                            var scale = (float)(saturnRingInnerRadius + saturnRingOuterRadius) / saturnRingScale;
                            var roll = saturn.getTransform().rotation.y / 10.0f;

                            //set data
                            saturnRing.getTransform().position = saturn.getTransform().position;
                            saturnRing.getTransform().rotation = saturn.getTransform().rotation;
                            saturnRing.getTransform().localScale = new Vector3(scale, scale, scale);
                        }

                        break;

                    case Objects.UranusRing:

                        //uranus ring 3d
                        var uranusRing = solarSystemObjects.getObject(obj);

                        //uranus
                        var uranus = uranusRing.buddy();

                        if (uranus != null && uranusRing != null)
                        {
                            //calculate data
                            var scale = (float)(uranusRingInnerRadius + uranusRingOuterRadius) / uranusRingScale;
                            var roll = uranus.getTransform().rotation.y / 10.0f;

                            //set data
                            uranusRing.getTransform().position = uranus.getTransform().position;
                            uranusRing.getTransform().rotation = uranus.getTransform().rotation;
                            uranusRing.getTransform().localScale = new Vector3(scale, scale, scale);
                        }

                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Sets solar system scale
        /// </summary>
        /// <param name="scale"></param>
        /// <param name="focused"></param>
        public static void changeSolarSystemScale(float scale, bool focused = false)
        {
            changeObjectsScale(scale, focused);

            var scaling = planetScale;

            foreach (var planet in solarSystemObjects.objects())
            {
                var type = planet.objectType();
                var s = 0.0f;

                switch (type)
                {
                    case Objects.Sun:
                        s = SolarParser.parseSolarObjectsRadius(type) * scaling / 80.0f;
                        planet.getTransform().localScale = new Vector3(s, s, s);
                        break;

                    case Objects.Mercury:
                    case Objects.Venus:
                    case Objects.Earth:
                    case Objects.Mars:
                    case Objects.Jupiter:
                    case Objects.Saturn:
                    case Objects.Uranus:
                    case Objects.Neptune:
                    case Objects.Pluto:
                    case Objects.Moon:
                        s = SolarParser.parseSolarObjectsRadius(type) * scaling;
                        planet.getTransform().localScale = new Vector3(s, s, s);
                        break;

                    case Objects.SaturnRing:
                        saturnRingOuterRadius = saturnRingOuterRadius * scaling;
                        saturnRingInnerRadius = saturnRingInnerRadius * scaling;
                        break;

                    case Objects.UranusRing:
                        uranusRingInnerRadius = uranusRingInnerRadius * scaling;
                        uranusRingOuterRadius = uranusRingOuterRadius * scaling;
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Sets current solar system speed
        /// </summary>
        /// <param name="speed"></param>
        public static void setSolarSystemSpeed(float speed)
        {
            daysPerFrameScale = speed;
        }

        /// <summary>
        /// Returns solar speed
        /// </summary>
        /// <returns></returns>
        public static double solarSpeed()
        {
            return daysPerFrameScale;
        }

        /// <summary>
        /// Stops math model
        /// </summary>
        public static void stopModel()
        {
            if (daysPerFrameScale != 0)
                savedDaysPerFrameScale = daysPerFrameScale;

            setSolarSystemSpeed(0);
        }

        /// <summary>
        /// Resumes math model
        /// </summary>
        public static void resumeModel()
        {
            if (savedDaysPerFrameScale != 0)
                setSolarSystemSpeed((float)savedDaysPerFrameScale);
        }

        /// <summary>
        /// Returns current solar date
        /// </summary>
        /// <returns></returns>
        public static DateTime date()
        {
            return solarTime;
        }

        /// <summary>
        /// Sets current frame delta time
        /// </summary>
        /// <param name="dt"></param>
        public static void setDeltaTime(float dt)
        {
            deltaTime = dt;
        }

        /// <summary>
        /// Calculates addition limit
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        private static float calculateZoomLimit(Objects obj, float limit)
        {
            var finalLimit = limit;

            switch (obj)
            {
                case Objects.Sun:
                    finalLimit = cameraController.DefaultZoomLimit;
                    break;

                case Objects.Mercury:
                    finalLimit *= 2.0f;
                    break;

                case Objects.Jupiter:
                    finalLimit /= 1.5f;
                    break;

                case Objects.Pluto:
                    finalLimit *= 1.5f;
                    break;

                default:
                    break;
            }

            return finalLimit;
        }

        /// <summary>
        /// Calculates zoom limit for object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static float calculateZoomLimit(Objects obj)
        {
            var solarObjRadius = SolarParser.parseSolarObjectsRadius(obj);
            var zoomLimit = planetScale * solarObjRadius * 4.0f;

            //empiric calculations
            return calculateZoomLimit(obj, zoomLimit);
        }

        /// <summary>
        /// Returns default view pos of solar object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Vector3 viewPositionOfObject(Objects obj)
        {
            var solarObj = solarSystemObjects.getObject(obj);
            var pos = Vector3.zero;

            if (solarObj != null)
            {
                var solarObjPos = solarObj.getTransform().position;

                //vector on object
                var onSolarObject = solarObjPos - cameraController.Camera.transform.position;

                //get dist
                var dist = onSolarObject.magnitude;

                //calculate need dist to camera
                var limit = calculateZoomLimit(obj);
                var needDist = dist - limit;

                if (needDist <= 0)
                    needDist = limit - dist;

                //get position
                var onTargetLimit = onSolarObject.normalized * needDist;

                //get need cam pos
                pos = onTargetLimit + cameraController.Camera.transform.position;
            }

            return pos;
        }
    }
}
