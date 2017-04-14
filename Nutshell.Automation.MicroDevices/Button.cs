using System;
using System.ComponentModel;
using System.Diagnostics;
using Nutshell.Aspects.Events;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Communication;
using Nutshell.Extensions;
using Nutshell.Messaging.Models;
using Nutshell.Messaging.Xml.Models;

namespace Nutshell.Automation.MicroDevices
{
        /// <summary>
        /// 按钮
        /// </summary>
        public class Button : DualStateDualControlDevice
        {
                public Button(string id)
                        : base(id)
                {
			_state.ValueChanged += (obj, args) =>
			{
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
		}

		public void Press()
                {
			var message = new XmlValueMessageModel<bool>
			{
				Id = Guid.NewGuid().ToString(),
				Category = Id,
				Value = true
			};
			CommandSender.Send(message);
		}

                public void Raise()
                {
			var message = new XmlValueMessageModel<bool>
			{
				Id = Guid.NewGuid().ToString(),
				Category = Id,
				Value = false
			};
			CommandSender.Send(message);
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