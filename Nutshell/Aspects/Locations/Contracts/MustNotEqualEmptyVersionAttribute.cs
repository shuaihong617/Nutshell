using System;
using System.Diagnostics;
using PostSharp.Aspects;
using PostSharp.Patterns.Contracts;
using PostSharp.Reflection;

namespace Nutshell.Aspects.Locations.Contracts
{
        public class MustNotEqualEmptyVersionAttribute : LocationContractAttribute,ILocationValidationAspect<Version>
        {

                public Exception ValidateValue(Version value, string locationName, LocationKind locationKind)
                {
                        return value == new Version()
                                ? new ArgumentException(locationKind.ToChineseString() + locationName + "的值不能赋值为空版本")
                                : null;
                }
        }
}
