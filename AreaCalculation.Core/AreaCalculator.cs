﻿using System.Reflection;

namespace AreaCalculation.Core
{
    public class AreaCalculator
    {
        private readonly IFigure _figure;
        public AreaCalculator()
        {

        }

        public IEnumerable<FigureClassInfo> GetFigures()
        {
            IEnumerable<Type> figureTypes = FindFigureTypes();
            if (!figureTypes.Any())
            {
                return Enumerable.Empty<FigureClassInfo>();
            }
            return figureTypes.Select(x => new FigureClassInfo(x));
        }

        private static IEnumerable<Type> FindFigureTypes()
        {
            var found = AppDomain.CurrentDomain.GetAssemblies()
                                   .SelectMany(x => x.GetTypes())
                                   .Where(t => typeof(IFigure).IsAssignableFrom(t) && t.IsClass);
            return found ?? Enumerable.Empty<Type>();
        }
    }
}
