namespace AreaCalculation.Core.Figures
{
    public class Triangle : IFigure
    {
        public Triangle(double firstSide, double secondSide, double thirdSide)
        {
            if (Validate(firstSide, secondSide, thirdSide) &&
                CheckExistence(firstSide, secondSide, thirdSide))
            {
                FirstSide = firstSide;
                SecondSide = secondSide;
                ThirdSide = thirdSide;
            }
        }
        public double FirstSide { get; }
        public double SecondSide { get; }
        public double ThirdSide { get; }
        public double Area => CalculateArea();
        public bool IsRight => DetermineRightTriangle();
        private double CalculateArea()
        {
            double semiPerimeter = CalculatePerimeter() / 2;
            return Math.Sqrt(semiPerimeter * (semiPerimeter - FirstSide) * (semiPerimeter - SecondSide) * (semiPerimeter - ThirdSide));
        }
        private bool DetermineRightTriangle()
        {
            double maxSide = Math.Max(FirstSide, Math.Max(SecondSide, ThirdSide));
            double minSide = Math.Min(FirstSide, Math.Min(SecondSide, ThirdSide));
            double averageSide = CalculatePerimeter() - maxSide - minSide;
            return maxSide == Math.Sqrt(Math.Pow(averageSide, 2) + Math.Pow(minSide, 2));
        }

        private double CalculatePerimeter()
        {
            return FirstSide + SecondSide + ThirdSide;
        }
        private static bool Validate(double firstSide, double secondSide, double thirdSide)
        {
            bool isValid = firstSide > 0 && secondSide > 0 && thirdSide > 0;
            return isValid ? isValid : throw new ArgumentOutOfRangeException("The sides of the triangle cannot be less than or equal to zero.");
        }
        private static bool CheckExistence(double firstSide, double secondSide, double thirdSide)
        {
            bool isСorrect = firstSide + secondSide > thirdSide &&
                             firstSide + thirdSide > secondSide &&
                             secondSide + thirdSide > firstSide;
            return isСorrect ? isСorrect : throw new ArgumentException("The specified triangle is incorrect"); ;
        }
    }
}
