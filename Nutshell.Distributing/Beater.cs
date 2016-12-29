using System.Diagnostics;
using Nutshell.Components;
using Nutshell.Data.Models;
using Nutshell.Distributing.Models;
using Nutshell.Messaging;

namespace Nutshell.Distributing
{
        public abstract class Beater : Dispatcher
        {
                protected Beater(IdentityObject parent, string id = "心跳", int interval = 3000)
                        : base(parent, id)
                {
                        SendLoopDispatcher = new LoopDispatcher(this, "发送循环", interval, Send);
                }

                public SendSite<StringMessage> SendSite { get; protected set; }

                public LoopDispatcher SendLoopDispatcher { get; private set; }

                public StringMessage Message { get; private set; }

                public override void Load(IDataModel model)
                {
                        model.NotNull();

                        base.Load(model);

                        Message = new StringMessage(Id);


                        var beaterModel = model as BeaterModel;
                        Trace.Assert(beaterModel != null);

                        SendLoopDispatcher.Load(beaterModel.SendLooperModel);
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
                        return SendSite.Start() && SendLoopDispatcher.Start();
                }

                protected override bool StopCore()
                {
                        return SendLoopDispatcher.Stop() && SendSite.Stop();
                }
        }
}
