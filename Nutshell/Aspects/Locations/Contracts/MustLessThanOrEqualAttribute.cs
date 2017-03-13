using PostSharp.Aspects;
using PostSharp.Patterns.Contracts;
using PostSharp.Reflection;
using System;

namespace Nutshell.Aspects.Locations.Contracts
{
        public sealed class MustLessThanOrEqualAttribute : LocationContractAttribute,
                ILocationValidationAspect<int>
        {
                public MustLessThanOrEqualAttribute(int compare)
                {
                        _intCompare = compare;
                }

                private readonly int _intCompare;

                public Exception ValidateValue(int value, string name, LocationKind locationKind)
                {
                        return value <= _intCompare
                                ? null
                                : new ArgumentException(locationKind.ToChineseString() + name + "的值必须小于或等于" + _intCompare);
                }
        }
}