namespace InheritanceInCSharp
{
    public abstract class RotatableShape : BaseShape
    {
        protected double orientation = 0;
        public void RotateBy(int degrees)
        {
            orientation = (orientation + degrees) % 360;
        }
    }
}
