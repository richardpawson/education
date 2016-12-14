using System;

namespace RayTracer
{

    static class Surfaces
    {
        // Only works with X-Z plane.
        public static readonly Surface CheckerBoard =
            new Surface()
            {
                Diffuse = pos => ((Math.Floor(pos.Z) + Math.Floor(pos.X)) % 2 != 0)
                                    ? new Color(1, 1, 1)
                                    : new Color(0, 0, 0),
                Specular = pos => new Color(1, 1, 1),
                Reflect = pos => ((Math.Floor(pos.Z) + Math.Floor(pos.X)) % 2 != 0)
                                    ? .1
                                    : .7,
                Roughness = 150
            };


        public static readonly Surface Shiny =
            new Surface()
            {
                Diffuse = pos => new Color(1, 1, 1),
                Specular = pos => new Color(.5, .5, .5),
                Reflect = pos => .6,
                Roughness = 50
            };
    }

}
