using System;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Data.Models;
using PostSharp.Aspects;
using PostSharp.Reflection;

namespace Nutshell.Data.Aspects.Locations.Contracts
{
        public class MustModelIdNotEqualNullOrEmptyAttribute : MustNotEqualNullAttribute,ILocationValidationAspect<IDataModel>
        {
                protected override string GetErrorMessage()
                {
                        return "Value {2} must have a non-zero value.";
                }
                public Exception ValidateValue(IDataModel value, string locationName, LocationKind locationKind)
                {
                        if (value.Id.IsNotNullOrEmpty())
                        {
                                return new ArgumentException();
                        }
                        return null;
                }
        }
}
