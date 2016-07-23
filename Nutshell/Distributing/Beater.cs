using System.Diagnostics;
using Nutshell.Components;
using Nutshell.Data.Models;
using Nutshell.Distributing.Models;
using Nutshell.Messaging;

namespace Nutshell.Distributing
{
        public abstract class Beater : Worker
        {
                protected Beater(IdentityObject parent, string id = "心跳", int interval = 3000)
                        : base(parent, id)
                {
                        SendLooper = new Looper(this, "发送循环", Send, interval);
                }

                public SendSite<StringMessage> SendSite { get; protected set; }

                public Looper SendLooper { get; private set; }

                public StringMessage Message { get; private set; }

                public override void Load(IStorableModel model)
                {
                        model.MustNotNull();

                        base.Load(model);

                        Message = new StringMessage(Id);


                        var beaterModel = model as BeaterModel;
                        Trace.Assert(beaterModel != null);

                        SendLooper.Load(beaterModel.SendLooperModel);
                }

                private void Send()
                {
                        if (SendSite != null)
                        {
                                SendSite.Send(Message);
                        }
                }

                protected override bool StartCore()
                {
                        return SendSite.Start() && SendLooper.Start();
                }

                protected override bool StopCore()
                {
                        return SendLooper.Stop() && SendSite.Stop();
                }
        }
}
