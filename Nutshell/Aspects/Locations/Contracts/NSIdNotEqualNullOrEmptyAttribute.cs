using System;
using PostSharp.Aspects;
using PostSharp.Patterns.Contracts;
using PostSharp.Reflection;

namespace Nutshell.Aspects.Locations.Contracts
{
        public class NSIdNotEqualNullOrEmptyAttribute : LocationContractAttribute,ILocationValidationAspect<IIdentityObject>
        {
                protected override string GetErrorMessage()
                {
                        return "Value {2} must have a non-zero value.";
                }
                public Exception ValidateValue([NSNotEqualNull]IIdentityObject value, string locationName, LocationKind locationKind)
                {
                        if (value.Id.IsNotNullOrEmpty())
                        {
                                return new ArgumentException();
                        }
                        return null;
                }
        }
}
