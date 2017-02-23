using System;
using PostSharp.Aspects;
using PostSharp.Patterns.Contracts;
using PostSharp.Reflection;

namespace Nutshell.Aspects.Locations.Contracts
{
        public class MustAssignableFromAttribute : LocationContractAttribute,ILocationValidationAspect<object>
        {
                public MustAssignableFromAttribute(Type type)
                {
                        _type = type;
                }

                private readonly Type _type;

                public Exception ValidateValue([MustNotEqualNull]object value, string name, LocationKind locationKind)
                {
                        if (!value.GetType().IsAssignableFrom(_type))
                                return CreateArgumentOutOfRangeException(value, name, locationKind);
                        return null;
                }
        }
}
