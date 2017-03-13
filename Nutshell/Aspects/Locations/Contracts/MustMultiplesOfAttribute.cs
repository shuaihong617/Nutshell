using PostSharp.Aspects;
using PostSharp.Patterns.Contracts;
using PostSharp.Reflection;
using System;

namespace Nutshell.Aspects.Locations.Contracts
{
        public sealed class MustMultiplesOfAttribute : LocationContractAttribute,
                ILocationValidationAspect<int>
        {
                public MustMultiplesOfAttribute(int mod)
                {
                        _mod = mod;
                }

                private readonly int _mod;

                public Exception ValidateValue(int value, string locationName, LocationKind locationKind)
                {
                        return value % _mod == 0
                                ? null
                                : new ArgumentException($"{locationKind.ToChineseString()}{locationName}的值必须是{_mod}的倍数");
                }
        }
}