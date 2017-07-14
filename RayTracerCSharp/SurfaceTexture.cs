using System;
using System.Windows.Media.Media3D;

namespace RayTracer
{
    public class SurfaceTexture
    {
        //Func is an example of 'functional programming'
        //Here it allows the exact behaviour of the Diffuse, Specular, and Reflect functions to be set up externally
        //when each type of surface is created.
        public Func<Vector3D, Color> Diffuse { get; private set; }
        public Func<Vector3D, Color> Specular { get; private set; }
        public Func<Vector3D, double> Reflect { get; private set; }
        public double Roughness { get; private set; }

        public SurfaceTexture(Func<Vector3D, Color> diffuse, 
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
