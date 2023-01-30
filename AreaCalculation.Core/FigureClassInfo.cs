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
            if (!typeof(IFigure).IsAssignableFrom(figureClassType))
            {
                throw new TypeLoadException(string.Format("Type {0} must be inherited from {1}", 
                    figureClassType, typeof(IFigure).FullName));
            }

            FigureClassType = figureClassType;
            IEnumerable<ConstructorInfo> ctors = figureClassType.GetConstructors();
            ConstructorInfo? ctor;
            if (ctors.Count() > 1)
            {
                ctor = FindOneByAttribute(ctors);
                if (ctor == null)
                {
                    throw new Exception($"{figureClassType.FullName} contains a more than one constructor. " +
                        $"You can mark required constructor with {nameof(FigureConstructorAttribute)} attribute.");
                }
            }
            else
            {
                ctor = ctors.First();
            }
            Arguments = ctor.GetParameters();
        }

        public string Name => FigureClassType.Name;
        public Type FigureClassType { get; }
        public IEnumerable<ParameterInfo> Arguments { get; }

        private static ConstructorInfo? FindOneByAttribute(IEnumerable<ConstructorInfo> ctors)
        {
            ConstructorInfo? found = null;
            foreach (var ctor in ctors)
            {
                var current = ctor.GetCustomAttribute<FigureConstructorAttribute>();
                if (current != null)
                {
                    if (found != null)
                    {
                        throw new Exception(string.Format("{0} cannot be more than one in the class.",
                            nameof(FigureConstructorAttribute)));
                    }
                    found = ctor;
                }
            }
            return found;
        }

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
