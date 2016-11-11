using System;
using PostSharp.Aspects;
using PostSharp.Patterns.Contracts;
using PostSharp.Reflection;

namespace Nutshell.Aspects.Locations.Contracts
{
        public class AssignableFromAttribute : LocationContractAttribute,ILocationValidationAspect<object>
        {
                public AssignableFromAttribute(Type type)
                {
                        _type = type;
                }

                private readonly Type _type;

                protected override string GetErrorMessage()
                {
                        return "Value {2} must have a non-zero value.";
                }

                public Exception ValidateValue([NSNotEqualNull]object value, string name, LocationKind locationKind)
                {
                        if (!value.GetType().IsAssignableFrom(_type))
                                return CreateArgumentOutOfRangeException(value, name, locationKind);
                        return null;
                }
        }
}
