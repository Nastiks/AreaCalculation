using System.Reflection;

namespace AreaCalculation.Core
{
    public class FigureClassInfo
    {
        public FigureClassInfo(Type figureClassType)
        {
            if (figureClassType is null)
            {
                throw new ArgumentNullException(nameof(figureClassType));
            }

            FigureClassType = figureClassType;
            Name = figureClassType.Name;
            IEnumerable<ConstructorInfo> ctors = figureClassType.GetConstructors();
            if(ctors.Count() > 1)
            {
                ctors = TakeOneByAttribute(ctors);
                if (!ctors.Any())
                {
                    throw new Exception($"{figureClassType.FullName} contains a more than one constructor. " +
                        $"You can mark required constructor with {nameof(FigureConstructorAttribute)} attribute.");
                }
            }
            var ctor = ctors.First();
            Arguments = ctor.GetParameters();
        }
        private IEnumerable<ConstructorInfo> TakeOneByAttribute(IEnumerable<ConstructorInfo> ctors)
        {
            foreach (var ctor in ctors)
            {
                if (ctor.GetCustomAttribute<FigureConstructorAttribute>() != null)
                {
                    return new ConstructorInfo[] { ctor };
                }
            }
            return Enumerable.Empty<ConstructorInfo>();
        }
        public string Name { get; }
        public IEnumerable<ParameterInfo> Arguments { get; }
        public Type FigureClassType { get; }
        public IFigure Create(params object[] args)
        {
            if (args.Length != Arguments.Count())
            {
                throw new TargetParameterCountException();
            }
            IFigure result = (IFigure)Activator.CreateInstance(FigureClassType, args)!;
            return result;
        }
    }
}
