namespace Nutshell.Serializing.Binary
{
        public class CheckMemberAttribute : MemberAttribute
        {
                public int BeginPostion { get; private set; }

                public int EndLength { get; private set; }
        }
}