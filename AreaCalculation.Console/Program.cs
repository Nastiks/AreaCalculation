using AreaCalculation.Core;
using AreaCalculation.Core.Figures;

namespace AreaCalculation.ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Available figures:");
            var figures = AreaCalculator.GetFigures();

            string print = string.Join(Environment.NewLine, figures
                .Select((x, index) => 
                string.Format("{0}: {1}, args: {2}", index + 1, x.Name, string.Join(", ", 
                x.Arguments.Select(x => string.Format("{0} - {1}", 
                x.Name, x.ParameterType.Name))))));

            Console.WriteLine(print);
            Console.WriteLine("Enter figure number:");
            int selected = int.Parse(Console.ReadLine()!) - 1;
            var selectedFigure = figures.Skip(selected).First();

            List<object> arguments = new();
            foreach (var item in selectedFigure.Arguments)
            {
                Console.WriteLine("Enter argument '{0}' (Type: {1}):", item.Name, item.ParameterType.Name);
                string input = Console.ReadLine()!.Replace('.',',');
                object argument = Convert.ChangeType(input, item.ParameterType);
                arguments.Add(argument);
            }

            IFigure figure = selectedFigure.Create(arguments.ToArray());
            Console.WriteLine("Area of '{0}': {1}", selectedFigure.Name, figure.Area);
        }
    }
}