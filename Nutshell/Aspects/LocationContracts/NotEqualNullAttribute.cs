using System;
using PostSharp.Aspects;
using PostSharp.Patterns.Contracts;
using PostSharp.Reflection;

namespace Nutshell.Aspects.LocationContracts
{
        public class NotEqualNullAttribute : LocationContractAttribute,
                ILocationValidationAspect<object>
        {
                protected override string GetErrorMessage()
                {
                        return "Value {2} must have a non-zero value.";
                }

                public Exception ValidateValue(object value, string name, LocationKind locationKind)
                {
                        if (value == null)
                                return CreateArgumentNullException(value, name, locationKind);
                        return null;
                }

                
        }
}
