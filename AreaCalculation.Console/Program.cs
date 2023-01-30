using AreaCalculation.Core;

namespace AreaCalculation.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle(-18);
            Console.WriteLine(circle.CalculateTheArea());

            Triangle triangle = new Triangle(14, 5, 8);
            Console.WriteLine(triangle.CalculateTheArea());
        }
    }
}