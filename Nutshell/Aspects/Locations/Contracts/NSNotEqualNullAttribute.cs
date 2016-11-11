using System;
using PostSharp.Aspects;
using PostSharp.Patterns.Contracts;
using PostSharp.Reflection;

namespace Nutshell.Aspects.Locations.Contracts
{
        public class NSNotEqualNullAttribute : LocationContractAttribute,ILocationValidationAspect<object>
        {
                protected override string GetErrorMessage()
                {
                        return "Value {2} must have a non-zero value.";
                }

                public virtual Exception ValidateValue(object value, string name, LocationKind locationKind)
                {
                        return value == null ? new ArgumentNullException(name) : null;
                }
        }
}
