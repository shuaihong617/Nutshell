using System;
using System.ComponentModel;
using System.Diagnostics;
using Nutshell.Aspects.Events;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Extensions;

namespace Nutshell.Automation.Opc.Controls
{
        /// <summary>
        ///         气缸
        /// </summary>
        public abstract class Cylinder : Device
        {
                protected Cylinder(string id)
                        : base(id)
                {
                }


                #region 字段

                private CylinderState? _state;

                private readonly OpcAccessor<bool> _controlOpcAccessor = new OpcAccessor<bool>();

                #endregion

                


                [NotifyPropertyValueChanged]
                public CylinderState? State
                {
                        get { return _state; }
                        protected set
                        {
                                if (value == _state)
                                {
                                        return;
                                }

                                _state = value;
                                OnPropertyValueChanged();

                                if (!_state.HasValue)
                                {
                                        return;
                                }

                                switch (_state.Value)
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
                        }
                }

                

                public Cylinder SetControlOpcItem([MustNotEqualNull] OpcItem opcItem)
                {
                        _controlOpcAccessor.SetSource(opcItem);
                        return this;
                }


                public void Open()
                {
                        _controlOpcAccessor.RemoteWrite(true);
                }

                public void Close()
                {
			_controlOpcAccessor.RemoteWrite(false);
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