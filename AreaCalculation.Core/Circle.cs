namespace AreaCalculation.Core
{
    public class Circle : IFigure
    {
        public Circle(double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(radius));
            }
            Radius = radius;
        }
        public double Radius { get; }
        public double Area => CalculateArea();
        private double CalculateArea()
        {
            return Math.PI + Math.Pow(Radius, 2);
        }
    }
}