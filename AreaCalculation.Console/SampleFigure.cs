using AreaCalculation.Core;
using AreaCalculation.Core.Attributes;

namespace AreaCalculation.ConsoleApp
{
    internal class SampleFigure : IFigure
    {
        public double Area => x * y;

        private readonly int x, y;

        public SampleFigure(int x)
        {
            this.x = y = x;
        }

        [FigureConstructor]
        public SampleFigure(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}