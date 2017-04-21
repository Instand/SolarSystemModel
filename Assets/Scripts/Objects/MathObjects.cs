using SolarSystem.Core;

namespace SolarSystem.MathObjects
{
    namespace Stars
    {
        //Sun the center of solar sytem
        public sealed class Sun : AbstractObject
        {
            //in constructor
            protected override void initialize()
            {
                _radius = ObjectsValues.Sun.radius;
                _tilt = ObjectsValues.Sun.tilt;
                _N1 = Values.zero;
                _N2 = Values.zero;
                _i1 = Values.zero;
                _i2 = Values.zero;
                _w1 = Values.zero;
                _w2 = Values.zero;
                _a1 = Values.zero;
                _a2 = Values.zero;
                _e1 = Values.zero;
                _e2 = Values.zero;
                _M1 = Values.zero;
                _M2 = Values.zero;
                _period = ObjectsValues.Sun.period;
                _centerOfOrbit = Objects.Sun;
                _objectType = Objects.Sun;
            }
        }
    }

    namespace Planets
    {
        //mercury
        public sealed class Mercury : AbstractObject
        {
            //in constructor
            protected override void initialize()
            {
                _radius = ObjectsValues.Mercury.radius;
                _tilt = ObjectsValues.Mercury.tilt;
                _N1 = ObjectsValues.Mercury.N1;
                _N2 = ObjectsValues.Mercury.N2;
                _i1 = ObjectsValues.Mercury.i1;
                _i2 = ObjectsValues.Mercury.i2;
                _w1 = ObjectsValues.Mercury.w1;
                _w2 = ObjectsValues.Mercury.w2;
                _a1 = ObjectsValues.Mercury.a1;
                _a2 = ObjectsValues.Mercury.a2;
                _e1 = ObjectsValues.Mercury.e1;
                _e2 = ObjectsValues.Mercury.e2;
                _M1 = ObjectsValues.Mercury.M1;
                _M2 = ObjectsValues.Mercury.M2;
                _period = ObjectsValues.Mercury.period;
                _centerOfOrbit = Objects.Sun;
                _objectType = Objects.Sun;
            }
        }

        //venus
        public sealed class Venus : AbstractObject
        {
            //in constructor
            protected override void initialize()
            {
                _radius = ObjectsValues.Venus.radius;
                _tilt = ObjectsValues.Venus.tilt;
                _N1 = ObjectsValues.Venus.N1;
                _N2 = ObjectsValues.Venus.N2;
                _i1 = ObjectsValues.Venus.i1;
                _i2 = ObjectsValues.Venus.i2;
                _w1 = ObjectsValues.Venus.w1;
                _w2 = ObjectsValues.Venus.w2;
                _a1 = ObjectsValues.Venus.a1;
                _a2 = ObjectsValues.Venus.a2;
                _e1 = ObjectsValues.Venus.e1;
                _e2 = ObjectsValues.Venus.e2;
                _M1 = ObjectsValues.Venus.M1;
                _M2 = ObjectsValues.Venus.M2;
                _period = ObjectsValues.Venus.period;
                _centerOfOrbit = Objects.Sun;
                _objectType = Objects.Sun;
            }
        }

        //earth
        public sealed class Earth : AbstractObject
        {
            //in constructor
            protected override void initialize()
            {
                _radius = ObjectsValues.Earth.radius;
                _tilt = ObjectsValues.Earth.tilt;
                _N1 = ObjectsValues.Earth.N1;
                _N2 = ObjectsValues.Earth.N2;
                _i1 = ObjectsValues.Earth.i1;
                _i2 = ObjectsValues.Earth.i2;
                _w1 = ObjectsValues.Earth.w1;
                _w2 = ObjectsValues.Earth.w2;
                _a1 = ObjectsValues.Earth.a1;
                _a2 = ObjectsValues.Earth.a2;
                _e1 = ObjectsValues.Earth.e1;
                _e2 = ObjectsValues.Earth.e2;
                _M1 = ObjectsValues.Earth.M1;
                _M2 = ObjectsValues.Earth.M2;
                _period = ObjectsValues.Earth.period;
                _centerOfOrbit = Objects.Sun;
                _objectType = Objects.Sun;
            }
        }

        //mars
        public sealed class Mars : AbstractObject
        {
            //in constructor
            protected override void initialize()
            {
                _radius = ObjectsValues.Mars.radius;
                _tilt = ObjectsValues.Mars.tilt;
                _N1 = ObjectsValues.Mars.N1;
                _N2 = ObjectsValues.Mars.N2;
                _i1 = ObjectsValues.Mars.i1;
                _i2 = ObjectsValues.Mars.i2;
                _w1 = ObjectsValues.Mars.w1;
                _w2 = ObjectsValues.Mars.w2;
                _a1 = ObjectsValues.Mars.a1;
                _a2 = ObjectsValues.Mars.a2;
                _e1 = ObjectsValues.Mars.e1;
                _e2 = ObjectsValues.Mars.e2;
                _M1 = ObjectsValues.Mars.M1;
                _M2 = ObjectsValues.Mars.M2;
                _period = ObjectsValues.Mars.period;
                _centerOfOrbit = Objects.Sun;
                _objectType = Objects.Sun;
            }
        }

        //jupiter
        public sealed class Jupiter : AbstractObject
        {
            //in constructor
            protected override void initialize()
            {
                _radius = ObjectsValues.Jupiter.radius;
                _tilt = ObjectsValues.Jupiter.tilt;
                _N1 = ObjectsValues.Jupiter.N1;
                _N2 = ObjectsValues.Jupiter.N2;
                _i1 = ObjectsValues.Jupiter.i1;
                _i2 = ObjectsValues.Jupiter.i2;
                _w1 = ObjectsValues.Jupiter.w1;
                _w2 = ObjectsValues.Jupiter.w2;
                _a1 = ObjectsValues.Jupiter.a1;
                _a2 = ObjectsValues.Jupiter.a2;
                _e1 = ObjectsValues.Jupiter.e1;
                _e2 = ObjectsValues.Jupiter.e2;
                _M1 = ObjectsValues.Jupiter.M1;
                _M2 = ObjectsValues.Jupiter.M2;
                _period = ObjectsValues.Jupiter.period;
                _centerOfOrbit = Objects.Sun;
                _objectType = Objects.Sun;
            }
        }

        //saturn
        public sealed class Saturn : AbstractObject
        {
            //in constructor
            protected override void initialize()
            {
                _radius = ObjectsValues.Saturn.radius;
                _tilt = ObjectsValues.Saturn.tilt;
                _N1 = ObjectsValues.Saturn.N1;
                _N2 = ObjectsValues.Saturn.N2;
                _i1 = ObjectsValues.Saturn.i1;
                _i2 = ObjectsValues.Saturn.i2;
                _w1 = ObjectsValues.Saturn.w1;
                _w2 = ObjectsValues.Saturn.w2;
                _a1 = ObjectsValues.Saturn.a1;
                _a2 = ObjectsValues.Saturn.a2;
                _e1 = ObjectsValues.Saturn.e1;
                _e2 = ObjectsValues.Saturn.e2;
                _M1 = ObjectsValues.Saturn.M1;
                _M2 = ObjectsValues.Saturn.M2;
                _period = ObjectsValues.Saturn.period;
                _centerOfOrbit = Objects.Sun;
                _objectType = Objects.Sun;
            }
        }

        //uranus
        public sealed class Uranus : AbstractObject
        {
            //in constructor
            protected override void initialize()
            {
                _radius = ObjectsValues.Uranus.radius;
                _tilt = ObjectsValues.Uranus.tilt;
                _N1 = ObjectsValues.Uranus.N1;
                _N2 = ObjectsValues.Uranus.N2;
                _i1 = ObjectsValues.Uranus.i1;
                _i2 = ObjectsValues.Uranus.i2;
                _w1 = ObjectsValues.Uranus.w1;
                _w2 = ObjectsValues.Uranus.w2;
                _a1 = ObjectsValues.Uranus.a1;
                _a2 = ObjectsValues.Uranus.a2;
                _e1 = ObjectsValues.Uranus.e1;
                _e2 = ObjectsValues.Uranus.e2;
                _M1 = ObjectsValues.Uranus.M1;
                _M2 = ObjectsValues.Uranus.M2;
                _period = ObjectsValues.Uranus.period;
                _centerOfOrbit = Objects.Sun;
                _objectType = Objects.Sun;
            }
        }

        //neptune
        public sealed class Neptune : AbstractObject
        {
            //in constructor
            protected override void initialize()
            {
                _radius = ObjectsValues.Neptune.radius;
                _tilt = ObjectsValues.Neptune.tilt;
                _N1 = ObjectsValues.Neptune.N1;
                _N2 = ObjectsValues.Neptune.N2;
                _i1 = ObjectsValues.Neptune.i1;
                _i2 = ObjectsValues.Neptune.i2;
                _w1 = ObjectsValues.Neptune.w1;
                _w2 = ObjectsValues.Neptune.w2;
                _a1 = ObjectsValues.Neptune.a1;
                _a2 = ObjectsValues.Neptune.a2;
                _e1 = ObjectsValues.Neptune.e1;
                _e2 = ObjectsValues.Neptune.e2;
                _M1 = ObjectsValues.Neptune.M1;
                _M2 = ObjectsValues.Neptune.M2;
                _period = ObjectsValues.Neptune.period;
                _centerOfOrbit = Objects.Sun;
                _objectType = Objects.Sun;
            }
        }
    }

    namespace DwarfPlanets
    {
        //pluto
        public sealed class Pluto : AbstractObject
        {
            //in constructor
            protected override void initialize()
            {
                _radius = ObjectsValues.Pluto.radius;
                _tilt = ObjectsValues.Pluto.tilt;
                _N1 = ObjectsValues.Pluto.N1;
                _N2 = ObjectsValues.Pluto.N2;
                _i1 = ObjectsValues.Pluto.i1;
                _i2 = ObjectsValues.Pluto.i2;
                _w1 = ObjectsValues.Pluto.w1;
                _w2 = ObjectsValues.Pluto.w2;
                _a1 = ObjectsValues.Pluto.a1;
                _a2 = ObjectsValues.Pluto.a2;
                _e1 = ObjectsValues.Pluto.e1;
                _e2 = ObjectsValues.Pluto.e2;
                _M1 = ObjectsValues.Pluto.M1;
                _M2 = ObjectsValues.Pluto.M2;
                _period = ObjectsValues.Pluto.period;
                _centerOfOrbit = Objects.Sun;
                _objectType = Objects.Sun;
            }
        }
    }

    namespace Moons
    {
        //moon
        public sealed class Moon : AbstractObject
        {
            //in constructor
            protected override void initialize()
            {
                _radius = ObjectsValues.Moon.radius;
                _tilt = ObjectsValues.Moon.tilt;
                _N1 = ObjectsValues.Moon.N1;
                _N2 = ObjectsValues.Moon.N2;
                _i1 = ObjectsValues.Moon.i1;
                _i2 = ObjectsValues.Moon.i2;
                _w1 = ObjectsValues.Moon.w1;
                _w2 = ObjectsValues.Moon.w2;
                _a1 = ObjectsValues.Moon.a1;
                _a2 = ObjectsValues.Moon.a2;
                _e1 = ObjectsValues.Moon.e1;
                _e2 = ObjectsValues.Moon.e2;
                _M1 = ObjectsValues.Moon.M1;
                _M2 = ObjectsValues.Moon.M2;
                _period = ObjectsValues.Moon.period;
                _centerOfOrbit = Objects.Earth;
                _objectType = Objects.Earth;
            }
        }
    }
}
