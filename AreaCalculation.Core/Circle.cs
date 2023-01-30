namespace AreaCalculation
{
    public class Circle
    {
        public Circle(double raduis)
        {
            Raduis = raduis;
        }
        public double Raduis { get; set; }
        public double Area { get; set; }

        public double CalculateTheArea(double raduis)
        {
            Area = raduis != 0 ? Math.Round(Area = Math.PI + Math.Pow(Raduis, 2), 2) : default;
            return Area;
        } 
    }
}