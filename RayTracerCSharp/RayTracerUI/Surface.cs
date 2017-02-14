using System;
using System.Windows.Media.Media3D;

namespace RayTracer
{
    public class Surface
    {
        //Func is an example of 'functional programming'
        //It allows 
        public Func<Vector3D, Color> Diffuse { get; private set; }
        public Func<Vector3D, Color> Specular { get; private set; }
        public Func<Vector3D, double> Reflect { get; private set; }
        public double Roughness { get; private set; }

        public Surface(Func<Vector3D, Color> diffuse, 
            Func<Vector3D, Color> specular,
            Func<Vector3D, double> reflect,
            double roughness)
        {
            Diffuse = diffuse;
            Specular = specular;
            Reflect = reflect;
            Roughness = roughness;
        }
    }

}
