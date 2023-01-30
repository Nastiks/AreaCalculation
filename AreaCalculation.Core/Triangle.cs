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
        public double FirstSide { get;}
        public double SecondSide { get;}
        public double ThirdSide { get;}
        public double Area => CalculateArea();
        private double CalculateArea()
        {
            double semiPerimeter = (FirstSide + SecondSide + ThirdSide) / 2;
            return Math.Sqrt(semiPerimeter * (semiPerimeter - FirstSide) * (semiPerimeter - SecondSide) * (semiPerimeter - ThirdSide));
        }
    }
}
