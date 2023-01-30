namespace AreaCalculation.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle(15);
            Console.WriteLine(circle.CalculateTheArea(circle.Raduis));
        }
    }
}