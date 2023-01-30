using AreaCalculation.Core;
using AreaCalculation.Core.Figures;

namespace AreaCalculation.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle(5);
            Console.WriteLine(circle.Area);

            Triangle triangle = new Triangle(10, 9, 8);
            Console.WriteLine(triangle.Area);
            Console.WriteLine(triangle.IsRight);

            AreaCalculator areaCalculator = new AreaCalculator();
            var figures = areaCalculator.GetFigures();
            foreach (var item in figures)
            {
                Console.WriteLine(item.Name);
            }
            var figureInfo = figures.First(x => x.Name == "Circle");
            Console.WriteLine(figureInfo.Arguments.Count());
            foreach (var item in figureInfo.Arguments)
            {
                Console.WriteLine(item.ParameterType);
            }
            var figure = figureInfo.Create(5);
            Console.WriteLine(figure.Area);
        }
    }
}