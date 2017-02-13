using System;

namespace RayTracer
{

    static class StandardSurfaces
    {
        // Only works with X-Z plane.
        public static readonly Surface CheckerBoard =
            new Surface(
                pos => ((Math.Floor(pos.Z) + Math.Floor(pos.X)) % 2 != 0)
                                    ? new Color(1, 1, 1)
                                    : new Color(0, 0, 0),
                pos => new Color(1, 1, 1),
                pos => ((Math.Floor(pos.Z) + Math.Floor(pos.X)) % 2 != 0)
                                    ? .1
                                    : .7,
                150);


        public static readonly Surface Shiny =
            new Surface(
               pos => new Color(1, 1, 1),
               pos => new Color(.5, .5, .5),
               pos => .6,
               50);
    }

}
