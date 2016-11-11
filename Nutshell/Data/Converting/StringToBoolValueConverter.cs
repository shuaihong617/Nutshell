namespace Nutshell.Data.Converting
{
        public class StringToBoolConverter : Converter<string, bool>
        {
                private StringToBoolConverter()
                {
                }

                #region 单例

                /// <summary>
                ///         单例
                /// </summary>
                public static readonly StringToBoolConverter Itance = new StringToBoolConverter();

                #endregion

                public override bool Convert(string source)
                {
                        return bool.Parse(source);
                }
        }
}
