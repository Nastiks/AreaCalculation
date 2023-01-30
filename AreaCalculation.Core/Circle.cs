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

        public bool CheckForExistence()
        {
            bool rightCircle = Raduis > 0;
            return rightCircle;
        }
        public double CalculateTheArea()
        {
            if(CheckForExistence())
            {
                Area = Math.Round(Area = Math.PI + Math.Pow(Raduis, 2), 2);
                return Area;
            }
            else
            {
                throw new Exception($"It is impossible to calculate the area of a circle whose radius is {Raduis}!");
            }
        } 
    }
}