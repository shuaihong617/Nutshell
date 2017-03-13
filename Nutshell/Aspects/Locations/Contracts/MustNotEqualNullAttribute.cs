using PostSharp.Aspects;
using PostSharp.Patterns.Contracts;
using PostSharp.Reflection;
using System;

namespace Nutshell.Aspects.Locations.Contracts
{
        public class MustNotEqualNullAttribute : LocationContractAttribute, ILocationValidationAspect<object>
        {
                public Exception ValidateValue(object value, string locationName, LocationKind locationKind)
                {
                        return value == null
                                ? new ArgumentException($"{locationKind.ToChineseString()}{locationName}的值不能赋值为null.")
                                : null;
                }
        }
}