namespace Nutshell.Data.Converting
{
        public abstract class Converter<TSource, TTarget> : IConverter<TSource, TTarget>
        {
                public abstract TTarget Convert(TSource source);
        }
}