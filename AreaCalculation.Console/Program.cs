using AreaCalculation.Core;

namespace AreaCalculation.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle(5);
            Console.WriteLine(circle.Area);

            Triangle triangle = new Triangle(10, 9, 8);
            Console.WriteLine(triangle.Area);
            Console.WriteLine(triangle.IsRightTriangle);
        }
    }
}