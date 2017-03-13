using PostSharp.Aspects;
using PostSharp.Patterns.Contracts;
using PostSharp.Reflection;
using System;
using System.IO;

namespace Nutshell.IO.Aspects.Locations.Contracts
{
        public sealed class MustFileExistAttribute : LocationContractAttribute,
                ILocationValidationAspect<string>
        {
                public Exception ValidateValue(string value, string name, LocationKind locationKind)
                {
                        if (File.Exists(value))
                        {
                                return null;
                        }

                        switch (locationKind)
                        {
                                case LocationKind.Parameter:
                                        return new ArgumentException("参数" + name + "当前值" + value + "所指定的文件不存在.");

                                default:
                                        return null;
                        }
                }
        }
}