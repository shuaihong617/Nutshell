using Nutshell.Components;
using Nutshell.Messaging;

namespace Nutshell.Distributing
{
        public class Loger : Dispatcher
        {
                protected Loger(IdentityObject parent, string id = "心跳")
                        : base(parent, id)
                {
                }

                public SendSite<StringMessage> SendSite { get; protected set; }


                private void Log()
                {
                        if (SendSite != null)
                        {
                                //SendSite.Send(_message);
                        }
                }

                protected override bool StartCore()
                {
                        return SendSite.Start();
                }

                protected override bool StopCore()
                {
                        return SendSite.Stop();
                }
        }
}
