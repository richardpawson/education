using System;

namespace RayTracer
{
    static class StandardSurfaces
    {
        // Only works with X-Z plane.
        public static readonly SurfaceTexture CheckerBoard =
            new SurfaceTexture(
                pos => ((Math.Floor(pos.Z) + Math.Floor(pos.X)) % 2 != 0)
                                    ? new Color(1, 1, 1)
                                    : new Color(0, 0, 0),
                pos => new Color(1, 1, 1),
                pos => ((Math.Floor(pos.Z) + Math.Floor(pos.X)) % 2 != 0)
                                    ? .1
                                    : .7,
                150);

        public static readonly SurfaceTexture Shiny =
            new SurfaceTexture(
               pos => new Color(1, 1, 1),
               pos => new Color(.5, .5, .5),
               pos => .6,
               50);

        public static readonly SurfaceTexture Matt =
    new SurfaceTexture(
       pos => new Color(1, 1, 1),
       pos => new Color(0, 0, 0),
       pos => 0,
       50);
    }
}
