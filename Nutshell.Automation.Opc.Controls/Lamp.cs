using System;
using System.ComponentModel;
using Nutshell.Aspects.Events;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Extensions;

namespace Nutshell.Automation.Opc.Controls
{
        /// <summary>
        ///         信号灯
        /// </summary>
        public class Lamp : Device
        {
                public Lamp(string id)
                        : base(id)
                {
                        _stateOpcAccessor.ValueChanged += (obj, args) => State = args.Value;
                }

                #region 字段

                private bool? _state;

                private readonly OpcAccessor<bool> _stateOpcAccessor = new OpcAccessor<bool>();

                private readonly OpcAccessor<bool> _controlOpcAccessor = new OpcAccessor<bool>();

                #endregion

                public bool? State
                {
                        get { return _state; }
                        private set
                        {
                                if (value == _state)
                                {
                                        return;
                                }

                                _state = value;
                                OnPropertyChanged();

                                if (!_state.HasValue)
                                {
                                        return;
                                }

                                if (_state.Value)
                                {
                                        OnOpened(EventArgs.Empty);
                                }
                                else
                                {
                                        OnClosed(EventArgs.Empty);
                                }
                        }
                }


                public Lamp SetStateOpcItem([MustNotEqualNull] OpcItem opcItem)
                {
                        _stateOpcAccessor.SetSource(opcItem);
                        return this;
                }

                public Lamp SetControlOpcItem([MustNotEqualNull] OpcItem opcItem)
                {
                        _controlOpcAccessor.SetSource(opcItem);
                        return this;
                }

                public void TurnOn()
                {
                        _controlOpcAccessor.RemoteWrite(true);
                }

                public void TurnOff()
                {
                        _controlOpcAccessor.RemoteWrite(false);
                }

                #region 事件

                /// <summary>
                ///         Occurs when [opened].
                /// </summary>
                [Description("打开事件")]
                [LogEventInvokeHandler]
                public event EventHandler<EventArgs> Opened;

                /// <summary>
                ///         引发<see cref="E:Opened" />事件
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
                protected virtual void OnOpened(EventArgs e)
                {
                        e.Raise(this, ref Opened);
                }

                /// <summary>
                ///         Occurs when [opened].
                /// </summary>
                [Description("关闭事件")]
                [LogEventInvokeHandler]
                public event EventHandler<EventArgs> Closed;

                /// <summary>
                ///         引发<see cref="E:Opened" />事件
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
                protected virtual void OnClosed(EventArgs e)
                {
                        e.Raise(this, ref Closed);
                }

                #endregion 事件
        }
}