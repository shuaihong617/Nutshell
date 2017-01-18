using System;
using PostSharp.Aspects;
using PostSharp.Patterns.Contracts;
using PostSharp.Reflection;

namespace Nutshell.Aspects.Locations.Contracts
{
        public sealed class MustBetweenOrEqualAttribute : LocationContractAttribute,
                ILocationValidationAspect<int>
        {
                public MustBetweenOrEqualAttribute(int min, int max)
                {
                        _min = min;
                        _max = max;
                }

                private readonly int _min;
                private readonly int _max;

                public Exception ValidateValue(int value, string name, LocationKind locationKind)
                {
                        if (value < _min || value > _max)
                                return new ArgumentException("参数" + name + "必须大于" + _min + "且小于" + _max);
                        return null;
                }

                
        }
}
