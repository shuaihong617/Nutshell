using PostSharp.Aspects;
using PostSharp.Patterns.Contracts;
using PostSharp.Reflection;
using System;

namespace Nutshell.Aspects.Locations.Contracts
{
        public sealed class MustBetweenAttribute : LocationContractAttribute,
                ILocationValidationAspect<int>
        {
                public MustBetweenAttribute(int min, int max)
                {
                        _min = min;
                        _max = max;
                }

                private readonly int _min;
                private readonly int _max;

                public Exception ValidateValue(int value, string name, LocationKind locationKind)
                {
                        if (value < _min || value > _max)
                                return new ArgumentException($"{locationKind.ToChineseString()}{name}的值必须大于{_min}且小于{_max}");
                        return null;
                }
        }
}