namespace RayTracer
{
    //This is a light-weight (pardon the pun!) immutable class. It could be a struct
    public class Intersection
    {
        public PhysicalObject Thing { get; private set; }
        public Ray Ray { get; private set; }
        public double Dist { get; private set; }

        public Intersection(PhysicalObject thing, Ray ray, double dist)
        {
            Thing = thing;
            Ray = ray;
            Dist = dist;
        }
    }
}
