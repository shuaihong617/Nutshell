using PostSharp.Aspects;
using PostSharp.Patterns.Contracts;
using PostSharp.Reflection;
using System;

namespace Nutshell.Aspects.Locations.Contracts
{
        public class MustNotEqualAttribute : LocationContractAttribute, ILocationValidationAspect<object>
        {
                public MustNotEqualAttribute(object compare)
                {
                        _compare = compare;
                }

                private readonly object _compare;

                public Exception ValidateValue(object value, string locationName, LocationKind locationKind)
                {
                        return Equals(value, _compare)
                                ? new ArgumentException($"{locationKind.ToChineseString()}{locationName}的值不能赋值为{_compare}")
                                : null;
                }
        }
}