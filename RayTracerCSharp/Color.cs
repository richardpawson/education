using System;

namespace RayTracer
{
    public class Color
    {
        private double R, G, B; 
        //Constructors
        public Color(double r, double g, double b) { R = r; G = g; B = b; }
        public Color(string str)
        {
            string[] nums = str.Split(',');
            if (nums.Length != 3) throw new ArgumentException();
            R = double.Parse(nums[0]);
            G = double.Parse(nums[1]);
            B = double.Parse(nums[2]);
        }

        //static methods or properties belong to the class, not an instance of it.
        //They are invoked on the class itself e.g. myBackground = Color.Background
        public static readonly Color Background = new Color(0, 0, 0);
        public static readonly Color DefaultColor = new Color(0, 0, 0);

        // 'operators' allow use of  +,-,*, instead of conventional method signatures
        // like 'add(...), subtract(...)'. They are static and hence must take two parameters
        public static Color operator *(double n, Color v)
        {
            return new Color(n * v.R, n * v.G, n * v.B);
        }
        public static Color operator *(Color v1, Color v2)
        {
            return new Color(v1.R * v2.R, v1.G * v2.G, v1.B * v2.B);
        }
        public static Color operator +(Color v1, Color v2)
        {
            return new Color(v1.R + v2.R, v1.G + v2.G, v1.B + v2.B);
        }
        public static Color operator -(Color v1, Color v2)
        {
            return new Color(v1.R - v2.R, v1.G - v2.G, v1.B - v2.B);
        }

        public double Legalize(double d)
        {
            return d > 1 ? 1 : d; // means: 'if d > 1 return 1, else return d'
        }

        //Use of namespace to qualify which Color class is being used:
        //this one, or the standard System.Drawing Color class
        internal System.Drawing.Color ToDrawingColor()
        {
            return System.Drawing.Color.FromArgb((int)(Legalize(R) * 255), (int)(Legalize(G) * 255), (int)(Legalize(B) * 255));
        }
    }
}
