using System.Collections.Generic;
using System.Text;

namespace Nutshell.NewLand.Commanding
{
        public class ExitSettingResponseCommond : NewLandCommand
        {
                public ExitSettingResponseCommond()
                {
                        Buffer = new byte[4];
                        for (var i = 0; i < Buffer.Length; i++)
                        {
                                Buffer[i] = ExitSettingResponseChar;
                        }
                }
        }
}
