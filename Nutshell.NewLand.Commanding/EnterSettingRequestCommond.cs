using System.Text;

namespace Nutshell.NewLand.Commanding
{
        public class EnterSettingRequestCommond:Command
        {
                public EnterSettingRequestCommond()
                {
                        Buffer = new byte[4];
                        for (var i = 0; i < Buffer.Length; i++)
                        {
                                Buffer[i] = EnterSettingRequestChar;
                        }
                }
        }
}
