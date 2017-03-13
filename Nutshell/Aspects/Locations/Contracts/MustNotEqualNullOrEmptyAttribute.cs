using PostSharp.Aspects;
using PostSharp.Patterns.Contracts;
using PostSharp.Reflection;
using System;

namespace Nutshell.Aspects.Locations.Contracts
{
        public class MustNotEqualNullOrEmptyAttribute : LocationContractAttribute, ILocationValidationAspect<string>
        {
                public Exception ValidateValue(string value, string locationName, LocationKind locationKind)
                {
                        //Trace.WriteLine("name :" + locationName);
                        //Trace.WriteLine("locationKind :" + locationKind);

                        // Trace.WriteLine("MustNotEqualNullOrEmpty " + value + " " + locationName);

                        var kind = string.Empty;
                        switch (locationKind)
                        {
                                case LocationKind.Parameter:
                                        kind = "参数";
                                        break;

                                case LocationKind.Property:
                                        kind = "属性";
                                        break;

                                case LocationKind.Field:
                                        kind = "字段";
                                        break;

                                case LocationKind.ReturnValue:
                                        kind = "返回值";
                                        break;
                        }
                        return string.IsNullOrEmpty(value)
                                ? new ArgumentException(kind + locationName + "的值不能为空引用或空字符串")
                                : null;
                }
        }
}