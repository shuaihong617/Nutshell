using System;
using System.Diagnostics;
using PostSharp.Aspects;
using PostSharp.Patterns.Contracts;
using PostSharp.Reflection;

namespace Nutshell.Aspects.Locations.Contracts
{
        public class MustNotEqualNullAttribute : LocationContractAttribute,ILocationValidationAspect<object>
        {

                public Exception ValidateValue(object value, string locationName, LocationKind locationKind)
                {
                        Trace.WriteLine("name :" + locationName);
                        Trace.WriteLine("locationKind :" + locationKind);

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
                        return value == null
                                ? new ArgumentException(kind + locationName + "的值不能为空引用")
                                : null;
                }
        }
}
