using AreaCalculation.Core;

namespace AreaCalculation.ConsoleApp
{
    internal class SampleFigure2 : IFigure
    {
        public double Area => x * x;

        private readonly int x;

        public SampleFigure2(int x)
        {
            this.x = x;
        }
    }
}