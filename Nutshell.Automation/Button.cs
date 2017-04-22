using System;
using System.ComponentModel;
using System.Diagnostics;
using Nutshell.Aspects.Events;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Communication.Data;
using Nutshell.Extensions;
using Nutshell.Messaging.Models;
using PostSharp.Extensibility;

namespace Nutshell.Automation
{
        /// <summary>
        /// 按钮
        /// </summary>
        public class Button : Device
        {
                public Button(string id)
                        : base(id)
                {
			
		}

                public bool? State { get; private set; }

                [MustNotEqualNull]
                private Messager<bool> _messager;

                public Button SetMessager([MustNotEqualNull]Messager<bool> messager)
                {
                        Trace.Assert(_messager != null);

                        _messager = messager;
                        _messager.DataChanged += (obj, args) =>
                        {
                                State = args.Value;

                                if (!args.Value.HasValue)
                                {
                                        return;
                                }

                                switch (args.Value.Value)
                                {
                                        case true:
                                                OnPressed(EventArgs.Empty);
                                                break;

                                        case false:
                                                OnRaised(EventArgs.Empty);
                                                break;
                                }
                        };

                        return this;
                }

		public void Press()
                {
			var message = new ValueMessageModel<bool>
			{
				Id = Guid.NewGuid().ToString(),
				Category = Id,
				Value = true
			};
			_messager.ToLowerSender.Send(message);
		}

                public void Raise()
                {
			var message = new ValueMessageModel<bool>
			{
				Id = Guid.NewGuid().ToString(),
				Category = Id,
				Value = false
			};
			_messager.ToLowerSender.Send(message);
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