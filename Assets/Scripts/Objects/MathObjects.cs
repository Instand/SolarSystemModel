﻿using SolarSystem.Core;

namespace SolarSystem.MathObjects
{
    namespace Stars
    {
        //Sun the center of solar sytem
        public sealed class Sun : AbstractObject
        {
            //in constructor
            protected override void Initialize()
            {
                radius = ObjectsValues.Sun.radius;
                tilt = ObjectsValues.Sun.tilt;
                n1 = Values.zero;
                n2 = Values.zero;
                i1 = Values.zero;
                i2 = Values.zero;
                w1 = Values.zero;
                w2 = Values.zero;
                a1 = Values.zero;
                a2 = Values.zero;
                e1 = Values.zero;
                e2 = Values.zero;
                m1 = Values.zero;
                m2 = Values.zero;
                period = ObjectsValues.Sun.period;
                centerOfOrbit = Objects.Sun;
                objectType = Objects.Sun;
            }
        }
    }

    namespace Planets
    {
        //mercury
        public sealed class Mercury : AbstractObject
        {
            //in constructor
            protected override void Initialize()
            {
                radius = ObjectsValues.Mercury.radius;
                tilt = ObjectsValues.Mercury.tilt;
                n1 = ObjectsValues.Mercury.N1;
                n2 = ObjectsValues.Mercury.N2;
                i1 = ObjectsValues.Mercury.i1;
                i2 = ObjectsValues.Mercury.i2;
                w1 = ObjectsValues.Mercury.w1;
                w2 = ObjectsValues.Mercury.w2;
                a1 = ObjectsValues.Mercury.a1;
                a2 = ObjectsValues.Mercury.a2;
                e1 = ObjectsValues.Mercury.e1;
                e2 = ObjectsValues.Mercury.e2;
                m1 = ObjectsValues.Mercury.M1;
                m2 = ObjectsValues.Mercury.M2;
                period = ObjectsValues.Mercury.period;
                centerOfOrbit = Objects.Sun;
                objectType = Objects.Mercury;
            }
        }

        //venus
        public sealed class Venus : AbstractObject
        {
            //in constructor
            protected override void Initialize()
            {
                radius = ObjectsValues.Venus.radius;
                tilt = ObjectsValues.Venus.tilt;
                n1 = ObjectsValues.Venus.N1;
                n2 = ObjectsValues.Venus.N2;
                i1 = ObjectsValues.Venus.i1;
                i2 = ObjectsValues.Venus.i2;
                w1 = ObjectsValues.Venus.w1;
                w2 = ObjectsValues.Venus.w2;
                a1 = ObjectsValues.Venus.a1;
                a2 = ObjectsValues.Venus.a2;
                e1 = ObjectsValues.Venus.e1;
                e2 = ObjectsValues.Venus.e2;
                m1 = ObjectsValues.Venus.M1;
                m2 = ObjectsValues.Venus.M2;
                period = ObjectsValues.Venus.period;
                centerOfOrbit = Objects.Sun;
                objectType = Objects.Venus;
            }
        }

        //earth
        public sealed class Earth : AbstractObject
        {
            //in constructor
            protected override void Initialize()
            {
                radius = ObjectsValues.Earth.radius;
                tilt = ObjectsValues.Earth.tilt;
                n1 = ObjectsValues.Earth.N1;
                n2 = ObjectsValues.Earth.N2;
                i1 = ObjectsValues.Earth.i1;
                i2 = ObjectsValues.Earth.i2;
                w1 = ObjectsValues.Earth.w1;
                w2 = ObjectsValues.Earth.w2;
                a1 = ObjectsValues.Earth.a1;
                a2 = ObjectsValues.Earth.a2;
                e1 = ObjectsValues.Earth.e1;
                e2 = ObjectsValues.Earth.e2;
                m1 = ObjectsValues.Earth.M1;
                m2 = ObjectsValues.Earth.M2;
                period = ObjectsValues.Earth.period;
                centerOfOrbit = Objects.Sun;
                objectType = Objects.Earth;
            }
        }

        //mars
        public sealed class Mars : AbstractObject
        {
            //in constructor
            protected override void Initialize()
            {
                radius = ObjectsValues.Mars.radius;
                tilt = ObjectsValues.Mars.tilt;
                n1 = ObjectsValues.Mars.N1;
                n2 = ObjectsValues.Mars.N2;
                i1 = ObjectsValues.Mars.i1;
                i2 = ObjectsValues.Mars.i2;
                w1 = ObjectsValues.Mars.w1;
                w2 = ObjectsValues.Mars.w2;
                a1 = ObjectsValues.Mars.a1;
                a2 = ObjectsValues.Mars.a2;
                e1 = ObjectsValues.Mars.e1;
                e2 = ObjectsValues.Mars.e2;
                m1 = ObjectsValues.Mars.M1;
                m2 = ObjectsValues.Mars.M2;
                period = ObjectsValues.Mars.period;
                centerOfOrbit = Objects.Sun;
                objectType = Objects.Mars;
            }
        }

        //jupiter
        public sealed class Jupiter : AbstractObject
        {
            //in constructor
            protected override void Initialize()
            {
                radius = ObjectsValues.Jupiter.radius;
                tilt = ObjectsValues.Jupiter.tilt;
                n1 = ObjectsValues.Jupiter.N1;
                n2 = ObjectsValues.Jupiter.N2;
                i1 = ObjectsValues.Jupiter.i1;
                i2 = ObjectsValues.Jupiter.i2;
                w1 = ObjectsValues.Jupiter.w1;
                w2 = ObjectsValues.Jupiter.w2;
                a1 = ObjectsValues.Jupiter.a1;
                a2 = ObjectsValues.Jupiter.a2;
                e1 = ObjectsValues.Jupiter.e1;
                e2 = ObjectsValues.Jupiter.e2;
                m1 = ObjectsValues.Jupiter.M1;
                m2 = ObjectsValues.Jupiter.M2;
                period = ObjectsValues.Jupiter.period;
                centerOfOrbit = Objects.Sun;
                objectType = Objects.Jupiter;
            }
        }

        //saturn
        public sealed class Saturn : AbstractObject
        {
            //in constructor
            protected override void Initialize()
            {
                radius = ObjectsValues.Saturn.radius;
                tilt = ObjectsValues.Saturn.tilt;
                n1 = ObjectsValues.Saturn.N1;
                n2 = ObjectsValues.Saturn.N2;
                i1 = ObjectsValues.Saturn.i1;
                i2 = ObjectsValues.Saturn.i2;
                w1 = ObjectsValues.Saturn.w1;
                w2 = ObjectsValues.Saturn.w2;
                a1 = ObjectsValues.Saturn.a1;
                a2 = ObjectsValues.Saturn.a2;
                e1 = ObjectsValues.Saturn.e1;
                e2 = ObjectsValues.Saturn.e2;
                m1 = ObjectsValues.Saturn.M1;
                m2 = ObjectsValues.Saturn.M2;
                period = ObjectsValues.Saturn.period;
                centerOfOrbit = Objects.Sun;
                objectType = Objects.Saturn;
            }
        }

        //uranus
        public sealed class Uranus : AbstractObject
        {
            //in constructor
            protected override void Initialize()
            {
                radius = ObjectsValues.Uranus.radius;
                tilt = ObjectsValues.Uranus.tilt;
                n1 = ObjectsValues.Uranus.N1;
                n2 = ObjectsValues.Uranus.N2;
                i1 = ObjectsValues.Uranus.i1;
                i2 = ObjectsValues.Uranus.i2;
                w1 = ObjectsValues.Uranus.w1;
                w2 = ObjectsValues.Uranus.w2;
                a1 = ObjectsValues.Uranus.a1;
                a2 = ObjectsValues.Uranus.a2;
                e1 = ObjectsValues.Uranus.e1;
                e2 = ObjectsValues.Uranus.e2;
                m1 = ObjectsValues.Uranus.M1;
                m2 = ObjectsValues.Uranus.M2;
                period = ObjectsValues.Uranus.period;
                centerOfOrbit = Objects.Sun;
                objectType = Objects.Uranus;
            }
        }

        //neptune
        public sealed class Neptune : AbstractObject
        {
            //in constructor
            protected override void Initialize()
            {
                radius = ObjectsValues.Neptune.radius;
                tilt = ObjectsValues.Neptune.tilt;
                n1 = ObjectsValues.Neptune.N1;
                n2 = ObjectsValues.Neptune.N2;
                i1 = ObjectsValues.Neptune.i1;
                i2 = ObjectsValues.Neptune.i2;
                w1 = ObjectsValues.Neptune.w1;
                w2 = ObjectsValues.Neptune.w2;
                a1 = ObjectsValues.Neptune.a1;
                a2 = ObjectsValues.Neptune.a2;
                e1 = ObjectsValues.Neptune.e1;
                e2 = ObjectsValues.Neptune.e2;
                m1 = ObjectsValues.Neptune.M1;
                m2 = ObjectsValues.Neptune.M2;
                period = ObjectsValues.Neptune.period;
                centerOfOrbit = Objects.Sun;
                objectType = Objects.Neptune;
            }
        }
    }

    namespace DwarfPlanets
    {
        //pluto
        public sealed class Pluto : AbstractObject
        {
            //in constructor
            protected override void Initialize()
            {
                radius = ObjectsValues.Pluto.radius;
                tilt = ObjectsValues.Pluto.tilt;
                n1 = ObjectsValues.Pluto.N1;
                n2 = ObjectsValues.Pluto.N2;
                i1 = ObjectsValues.Pluto.i1;
                i2 = ObjectsValues.Pluto.i2;
                w1 = ObjectsValues.Pluto.w1;
                w2 = ObjectsValues.Pluto.w2;
                a1 = ObjectsValues.Pluto.a1;
                a2 = ObjectsValues.Pluto.a2;
                e1 = ObjectsValues.Pluto.e1;
                e2 = ObjectsValues.Pluto.e2;
                m1 = ObjectsValues.Pluto.M1;
                m2 = ObjectsValues.Pluto.M2;
                period = ObjectsValues.Pluto.period;
                centerOfOrbit = Objects.Sun;
                objectType = Objects.Pluto;
            }
        }
    }

    namespace Moons
    {
        //moon
        public sealed class Moon : AbstractObject
        {
            //in constructor
            protected override void Initialize()
            {
                radius = ObjectsValues.Moon.radius;
                tilt = ObjectsValues.Moon.tilt;
                n1 = ObjectsValues.Moon.N1;
                n2 = ObjectsValues.Moon.N2;
                i1 = ObjectsValues.Moon.i1;
                i2 = ObjectsValues.Moon.i2;
                w1 = ObjectsValues.Moon.w1;
                w2 = ObjectsValues.Moon.w2;
                a1 = ObjectsValues.Moon.a1;
                a2 = ObjectsValues.Moon.a2;
                e1 = ObjectsValues.Moon.e1;
                e2 = ObjectsValues.Moon.e2;
                m1 = ObjectsValues.Moon.M1;
                m2 = ObjectsValues.Moon.M2;
                period = ObjectsValues.Moon.period;
                centerOfOrbit = Objects.Earth;
                objectType = Objects.Moon;
            }
        }
    }
}
