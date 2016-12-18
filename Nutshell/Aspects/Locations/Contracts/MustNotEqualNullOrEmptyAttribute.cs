using System;
using PostSharp.Aspects;
using PostSharp.Patterns.Contracts;
using PostSharp.Reflection;

namespace Nutshell.Aspects.Locations.Contracts
{
        public class MustNotEqualNullOrEmptyAttribute : LocationContractAttribute,ILocationValidationAspect<string>
        {
                protected override string GetErrorMessage()
                {
                        return "Value {2} must have a non-zero value.";
                }

                public virtual Exception ValidateValue(object value, string name, LocationKind locationKind)
                {
                        return value == null ? new ArgumentNullException(name) : null;
                }

                public Exception ValidateValue(string value, string locationName, LocationKind locationKind)
                {
                        return value.IsNullOrEmpty() ? new ArgumentNullException(locationName) : null;
                }
        }
}
