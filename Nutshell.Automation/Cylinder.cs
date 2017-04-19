using System;
using System.ComponentModel;
using System.Diagnostics;
using Nutshell.Aspects.Events;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Communication;
using Nutshell.Communication.Data;
using Nutshell.Extensions;
using Nutshell.Messaging.Models;
using Nutshell.Messaging.Xml.Models;

namespace Nutshell.Automation
{
        /// <summary>
        ///         气缸
        /// </summary>
        public class Cylinder : Device
        {
                public Cylinder(string id)
                        : base(id)
                {
                }

                [MustNotEqualNull] private IReceiver<IValueMessageModel<byte>> _stateReceiver;

                [MustNotEqualNull] private ISender<IValueMessageModel<bool>> _controlSender;


                [NotifyPropertyValueChanged]
                public CylinderState? State { get; private set; }

                public Cylinder SetStateReceiver([MustNotEqualNull] IReceiver<IValueMessageModel<byte>> receiver)
                {
                        Trace.Assert(_stateReceiver == null);

                        _stateReceiver = receiver;
                        _stateReceiver.ReceiveSuccessed += (obj, args) =>
                        {
                                State = (CylinderState) args.Value.Value;

                                switch (State)
                                {
                                        case CylinderState.正在开启:
                                                OnOpening(EventArgs.Empty);
                                                break;

                                        case CylinderState.开启完成:
                                                OnOpenCompleted(EventArgs.Empty);
                                                break;

                                        case CylinderState.正在关闭:
                                                OnClosing(EventArgs.Empty);
                                                break;

                                        case CylinderState.关闭完成:
                                                OnCloseCompleted(EventArgs.Empty);
                                                break;
                                }
                        };

                        return this;
                }

                public Cylinder SetControlSender([MustNotEqualNull] ISender<IValueMessageModel<bool>> sender)
                {
                        Trace.Assert(_stateReceiver == null);

                        _controlSender = sender;
                        return this;
                }


                public void Open()
                {
                        var message = new XmlValueMessageModel<bool>
                        {
                                Id = Guid.NewGuid().ToString(),
                                Category = Id,
                                Value = true
                        };
                        _controlSender.Send(message);
                }

                public void Close()
                {
                        var message = new XmlValueMessageModel<bool>
                        {
                                Id = Guid.NewGuid().ToString(),
                                Category = Id,
                                Value = false
                        };
                        _controlSender.Send(message);
                }

                #region 事件

                /// <summary>
                ///         Occurs when [opened].
                /// </summary>
                [Description("正在开启事件")]
                [LogEventInvokeHandler]
                public event EventHandler<EventArgs> Opening;

                /// <summary>
                ///         引发<see cref="E:Opening" />事件
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
                protected virtual void OnOpening(EventArgs e)
                {
                        e.Raise(this, ref Opening);
                }

                /// <summary>
                ///         Occurs when [opened].
                /// </summary>
                [Description("正在关闭事件")]
                [LogEventInvokeHandler]
                public event EventHandler<EventArgs> Closing;

                /// <summary>
                ///         引发<see cref="E:Opened" />事件
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
                protected virtual void OnClosing(EventArgs e)
                {
                        e.Raise(this, ref Closing);
                }

                /// <summary>
                ///         Occurs when [opened].
                /// </summary>
                [Description("开启完成事件")]
                [LogEventInvokeHandler]
                public event EventHandler<EventArgs> OpenCompleted;

                /// <summary>
                ///         引发<see cref="E:Opened" />事件
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
                protected virtual void OnOpenCompleted(EventArgs e)
                {
                        e.Raise(this, ref OpenCompleted);
                }

                /// <summary>
                ///         Occurs when [opened].
                /// </summary>
                [Description("关闭完成事件")]
                [LogEventInvokeHandler]
                public event EventHandler<EventArgs> CloseCompleted;

                /// <summary>
                ///         引发<see cref="E:Opened" />事件
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
                protected virtual void OnCloseCompleted(EventArgs e)
                {
                        e.Raise(this, ref CloseCompleted);
                }

                #endregion 事件
        }
}