using System.Text;

namespace Nutshell.NewLand.Commanding
{
        public class Command
        {
                public const byte EnterSettingRequestChar = (byte)'$';

                public const byte EnterSettingResponseChar = (byte)'@';

                public const byte ExitSettingRequestChar = (byte)'%';

                public const byte ExitSettingResponseChar = (byte)'^';

                public const byte CommonRequestHeadChar = (byte)'#';

                public const byte SuccessedResponseHeadChar = (byte)'!';

                public const byte FailedResponseHeadChar = (byte)'?';

                public const byte CommonTailChar = (byte)';';

                public const byte QueryResultLeadChar = (byte)'&';

                public const byte QueryResultHeadChar = (byte)'{';

                public const byte QueryResultTailChar = (byte)'}';

                public const byte QueryResultSeparateChar = (byte)'|';

                public byte[] Buffer { get; protected set; }

        }
}
