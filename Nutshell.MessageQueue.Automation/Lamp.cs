using System;
using System.ComponentModel;
using Nutshell.Aspects.Events;
using Nutshell.Extensions;
using Nutshell.Messaging.Xml.Models;

namespace Nutshell.Automation.MicroDevices
{
	/// <summary>
	///         电灯
	/// </summary>
	public class Lamp : DualStateDualControlDevice
	{
		public Lamp(string id)
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
						OnOpened(EventArgs.Empty);
						break;

					case false:
						OnClosed(EventArgs.Empty);
						break;
				}
			};
		}

		public void TurnOn()
		{
			var message = new XmlValueMessageModel<bool>
			{
				Id = Guid.NewGuid().ToString(),
				Category = Id,
				Value = true
			};
			CommandSender.Send(message);
		}

		public void TurnOff()
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