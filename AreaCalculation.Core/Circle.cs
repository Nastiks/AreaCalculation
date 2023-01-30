namespace AreaCalculation.Core
{
    public class Circle : IRightFigure
    {
        public Circle(double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(radius));
            }
            Radius = radius;
        }
        public double Radius { get; set; }
        public double Area { get; set; }
        public double CalculateArea()
        {
            Area = Math.Round(Area = Math.PI + Math.Pow(Radius, 2), 2);
            return Area;
        }
    }
}