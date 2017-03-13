using PostSharp.Aspects;
using PostSharp.Patterns.Contracts;
using PostSharp.Reflection;
using System;

namespace Nutshell.Aspects.Locations.Contracts
{
        public sealed class MustLessThanAttribute : LocationContractAttribute,
                ILocationValidationAspect<int>, ILocationValidationAspect<double>
        {
                public MustLessThanAttribute(int compare)
                {
                        _intCompare = compare;
                }

                public MustLessThanAttribute(double compare)
                {
                        _doubleCompare = compare;
                }

                private readonly int _intCompare;

                private readonly double _doubleCompare;

                public Exception ValidateValue(int value, string locationName, LocationKind locationKind)
                {
                        return value > _intCompare
                                ? null
                                : new ArgumentException(locationKind.ToChineseString() + locationName + "的值必须大于" + _intCompare);
                }

                /// <summary>
                /// Validates the value being assigned to the location to which the current aspect has been applied.
                /// </summary>
                /// <param name="value">Value being applied to the location.</param><param name="locationName">Name of the location.</param><param name="locationKind">Location kind (<see cref="F:PostSharp.Reflection.LocationKind.Field"/>, <see cref="F:PostSharp.Reflection.LocationKind.Property"/>, or
                ///             <see cref="F:PostSharp.Reflection.LocationKind.Parameter"/>).
                ///             </param>
                /// <returns>
                /// The <see cref="T:System.Exception"/> to be thrown, or <c>null</c> if no exception needs to be thrown.
                /// </returns>
                public Exception ValidateValue(double value, string locationName, LocationKind locationKind)
                {
                        return value > _doubleCompare
                                ? null
                                : new ArgumentException(locationKind.ToChineseString() + locationName + "的值必须大于" + _doubleCompare);
                }
        }
}