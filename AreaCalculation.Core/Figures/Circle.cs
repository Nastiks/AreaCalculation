namespace AreaCalculation.Core.Figures
{
    public class Circle : IFigure
    {
        public Circle(double radius)
        {
            if (Validate(radius))
            {
                Radius = radius;
            }
        }
        public double Radius { get; }
        public double Area => CalculateArea();
        private double CalculateArea()
        {
            return Math.PI + Math.Pow(Radius, 2);
        }
        private static bool Validate (double radius)
        {
            return radius > 0 ? true : throw new ArgumentOutOfRangeException(nameof(radius)); ;
        }
    }
}