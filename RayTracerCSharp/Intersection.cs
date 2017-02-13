namespace RayTracer
{
    public class Intersection
    {
        public SceneObject Thing { get; private set; }
        public Ray Ray { get; private set; }
        public double Dist { get; private set; }

        public Intersection(SceneObject thing, Ray ray, double dist)
        {
            Thing = thing;
            Ray = ray;
            Dist = dist;
        }
    }
}
