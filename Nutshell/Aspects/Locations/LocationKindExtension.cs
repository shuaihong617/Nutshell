using PostSharp.Reflection;
using System;

namespace Nutshell.Aspects.Locations
{
        public static class LocationKindExtension
        {
                public static string ToChineseString(this LocationKind locationKind)
                {
                        switch (locationKind)
                        {
                                case LocationKind.Parameter:
                                        return "参数";

                                case LocationKind.Property:
                                        return "属性";

                                case LocationKind.Field:
                                        return "字段";

                                case LocationKind.ReturnValue:
                                        return "返回值";

                                default:
                                        throw new ArgumentException("未知的LocationKind类型");
                        }
                }
        }
}