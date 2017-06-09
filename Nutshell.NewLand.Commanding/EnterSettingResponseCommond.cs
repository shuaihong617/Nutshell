using System.Text;

namespace Nutshell.NewLand.Commanding
{
        public class EnterSettingResponseCommond:Command
        {
                public EnterSettingResponseCommond()
                {
                        Buffer = new byte[4];
                        for (var i = 0; i < Buffer.Length; i++)
                        {
                                Buffer[i] = EnterSettingResponseChar;
                        }
                }
        }
}
