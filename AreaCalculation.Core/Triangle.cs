namespace AreaCalculation.Core
{
    public class Triangle : IRightFigure
    {
        public Triangle(double firstSide, double secondSide, double thirdSide)
        {
            FirstSide= firstSide;
            SecondSide= secondSide;
            ThirdSide= thirdSide;
        }
        public double FirstSide { get; set; }
        public double SecondSide { get; set; }
        public double ThirdSide { get; set; }
        public double Area { get; set; }

        public bool CheckForExistence()
        {
            bool rightTriangle = FirstSide + SecondSide > ThirdSide &&
                                 FirstSide + ThirdSide > SecondSide &&
                                 SecondSide + ThirdSide > FirstSide;
            return rightTriangle;
        }
        public double CalculateTheArea()
        {
            if (CheckForExistence())
            {
                double semiPerimeter = (FirstSide + SecondSide + ThirdSide) / 2;
                Area = Math.Sqrt(semiPerimeter * (semiPerimeter - FirstSide) * (semiPerimeter - SecondSide) * (semiPerimeter - SecondSide));
                return Area;
            }
            else
            {
                throw new Exception("It is impossible to calculate the area of a triangle that does not exist!");
            }
        }
    }
}
