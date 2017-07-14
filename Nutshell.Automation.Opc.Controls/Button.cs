using System;
using System.ComponentModel;
using System.Diagnostics;
using Nutshell.Aspects.Events;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Extensions;

namespace Nutshell.Automation.Opc.Controls
{
        /// <summary>
        /// 按钮
        /// </summary>
        public class Button : Device
        {
                public Button(string id)
                        : base(id)
                {
                        _stateOpcAccessor.ValueChanged += (obj, args) => State = args.Value;
                }

                #region 字段

                private bool? _state;

                private readonly OpcAccessor<bool> _stateOpcAccessor = new OpcAccessor<bool>();


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
                                OnPropertyValueChanged();

                                if (!_state.HasValue)
                                {
                                        return;
                                }

                                if (_state.Value)
                                {
                                        OnPressed(EventArgs.Empty);
                                }
                                else
                                {
                                        OnRaised(EventArgs.Empty);
                                }
                        }
                }


                public Button SetStateOpcItem([MustNotEqualNull]OpcItem opcItem)
                {
                        _stateOpcAccessor.SetSource(opcItem);
                        return this;
                }

		public void Press()
                {
			_stateOpcAccessor.RemoteWrite(true);
		}

                public void Raise()
                {
                        _stateOpcAccessor.RemoteWrite(false);
                }

		#region 事件

		/// <summary>
		///         Occurs when [opened].
		/// </summary>
		[Description("按下事件")]
		[LogEventInvokeHandler]
		public event EventHandler<EventArgs> Pressed;

                /// <summary>
                ///         引发<see cref="E:Opened" />事件
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
                protected virtual void OnPressed(EventArgs e)
                {
                        e.Raise(this, ref Pressed);
                }

		/// <summary>
		///         Occurs when [opened].
		/// </summary>
		[Description("弹起事件")]
		[LogEventInvokeHandler]
		public event EventHandler<EventArgs> Raised;

                /// <summary>
                ///         引发<see cref="E:Opened" />事件
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
                protected virtual void OnRaised(EventArgs e)
                {
                        e.Raise(this, ref Raised);
                }

                #endregion 事件
        }
}