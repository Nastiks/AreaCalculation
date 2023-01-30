using AreaCalculation.Core;

namespace AreaCalculation.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle(15);
            Console.WriteLine(circle.CalculateArea());

            Triangle triangle = new Triangle(10, 9, 8);
            Console.WriteLine(triangle.CalculateArea());
        }
    }
}