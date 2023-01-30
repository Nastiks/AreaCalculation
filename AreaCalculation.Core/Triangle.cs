namespace AreaCalculation.Core
{
    public class Triangle : IRightFigure
    {
        public Triangle(double firstSide, double secondSide, double thirdSide)
        {
            bool isСorrect = firstSide + secondSide > thirdSide &&
                             firstSide + thirdSide > secondSide &&
                             secondSide + thirdSide > firstSide;
            if (!isСorrect)
            {
                throw new ArgumentException("The specified triangle is incorrect");
            }

            FirstSide = firstSide;
            SecondSide = secondSide;
            ThirdSide = thirdSide;
        }
        public double FirstSide { get; set; }
        public double SecondSide { get; set; }
        public double ThirdSide { get; set; }
        public double Area { get; set; }
        public double CalculateArea()
        {
            double semiPerimeter = (FirstSide + SecondSide + ThirdSide) / 2;
            Area = Math.Sqrt(semiPerimeter * (semiPerimeter - FirstSide) * (semiPerimeter - SecondSide) * (semiPerimeter - ThirdSide));
            Area = Math.Round(Area, 2);
            return Area;
        }
    }
}
