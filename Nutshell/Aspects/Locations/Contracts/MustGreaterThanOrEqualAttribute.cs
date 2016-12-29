using System;
using PostSharp.Aspects;
using PostSharp.Patterns.Contracts;
using PostSharp.Reflection;

namespace Nutshell.Aspects.Locations.Contracts
{
        public sealed class MustGreaterThanOrEqualAttribute : LocationContractAttribute,
                ILocationValidationAspect<int>
        {
                public MustGreaterThanOrEqualAttribute(int compare)
                {
                        _intCompare = compare;
                }

                private readonly int _intCompare;

                protected override string GetErrorMessage()
                {
                        return "Value {2} must have a non-zero value.";
                }

                public Exception ValidateValue(int value, string name, LocationKind locationKind)
                {
                        if (value <= _intCompare)
                                return CreateArgumentOutOfRangeException(value, name, locationKind);
                        return null;
                }

                
        }
}
