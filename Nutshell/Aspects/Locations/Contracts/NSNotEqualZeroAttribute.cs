using System;
using PostSharp.Aspects;
using PostSharp.Patterns.Contracts;
using PostSharp.Reflection;

namespace Nutshell.Aspects.Locations.Contracts
{
        public class NSNotEqualZeroAttribute : LocationContractAttribute,
                ILocationValidationAspect<int>,
                ILocationValidationAspect<uint>
        {

                protected override string GetErrorMessage()
                {
                        return "Value {2} must have a non-zero value.";
                }

                public Exception ValidateValue(int value, string name, LocationKind locationKind)
                {
                        if (value == 0)
                                return CreateArgumentOutOfRangeException(value, name, locationKind);
                        return null;
                }

                public Exception ValidateValue(uint value, string name, LocationKind locationKind)
                {
                        if (value == 0)
                                return CreateArgumentOutOfRangeException(value, name, locationKind);
                        return null;
                }
        }
}
