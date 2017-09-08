using System.Text;

namespace Nutshell.NewLand.Commanding
{
        public class ExitSettingRequestCommond : NewLandCommand
        {
                public ExitSettingRequestCommond()
                {
                        Buffer = new byte[4];
                        for (var i = 0; i < Buffer.Length; i++)
                        {
                                Buffer[i] = ExitSettingRequestChar;
                        }
                }
        }
}
