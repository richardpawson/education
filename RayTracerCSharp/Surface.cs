using System;
using System.Windows.Media.Media3D;

namespace RayTracer
{
    class Surface
    {
        public Func<Vector3D, Color> Diffuse;
        public Func<Vector3D, Color> Specular;
        public Func<Vector3D, double> Reflect;
        public double Roughness;
    }

}
