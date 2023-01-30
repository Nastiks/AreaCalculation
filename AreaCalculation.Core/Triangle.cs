namespace AreaCalculation.Core
{
    public class Triangle : IFigure
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
        public double FirstSide { get;}
        public double SecondSide { get;}
        public double ThirdSide { get;}
        public double Area => CalculateArea();
        public bool IsRightTriangle => DetermineRightTriangle();
        private double CalculateArea()
        {
            double semiPerimeter = (FirstSide + SecondSide + ThirdSide) / 2;
            return Math.Sqrt(semiPerimeter * (semiPerimeter - FirstSide) * (semiPerimeter - SecondSide) * (semiPerimeter - ThirdSide));
        }
        
        public bool DetermineRightTriangle()
        {
            double maxSide = Math.Max(FirstSide, Math.Max(SecondSide, ThirdSide));
            double minSide = Math.Min(FirstSide, Math.Min(SecondSide, ThirdSide));
            double averageSide = (FirstSide + SecondSide + ThirdSide) - maxSide - minSide;
            if (maxSide == Math.Sqrt((Math.Pow(averageSide, 2)) + (Math.Pow(minSide, 2))))
            {
                return true;
            }
            return false;
        }
    }
}
