using System;

namespace Nutshell.Net
{
        public class MacAddress
        {
                public MacAddress(ulong address)
                {
                        _address = address;
                }

                public MacAddress(uint addressHigh32Bit, uint addressLow32Bit)
                        : this(((ulong) addressHigh32Bit << 32) + addressLow32Bit)
                {
                }

                private readonly ulong _address;

                /// <summary>
                ///         返回表示当前对象的字符串。
                /// </summary>
                /// <returns>
                ///         表示当前对象的字符串。
                /// </returns>
                public override string ToString()
                {
                        var bytes = BitConverter.GetBytes(_address);
                        return BitConverter.ToString(bytes);
                }
        }
}
