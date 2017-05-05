using System;
using System.ComponentModel;
using System.Diagnostics;
using Nutshell.Aspects.Events;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Communication;
using Nutshell.Communication.Data;
using Nutshell.Extensions;
using Nutshell.Messaging.Models;

namespace Nutshell.Automation
{
	/// <summary>
	///         信号灯
	/// </summary>
	public class Lamp : Device
	{
		public Lamp(string id)
			: base(id)
		{
		}

                public bool? State { get; private set; }

                [MustNotEqualNull]
                private ISender<MultiStringKeyValuePairsMessageModel> _sender;

		private IReceiver<ValueMessageModel<bool>> _receiver; 

                public Lamp SetReceiver([MustNotEqualNull]IReceiver<ValueMessageModel<bool>> receiver)
                {
			Trace.Assert(_receiver == null);

	                _receiver = receiver;
			_receiver.Received += (obj, args) =>
			{
				State = args.Value.Value;

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

			return this;
                }

                public void TurnOn()
		{
			var message = new MultiStringKeyValuePairsMessageModel()
			{
				Id = Guid.NewGuid().ToString(),
			};
			message.Add($"{Id}控制", true);
			_sender.Send(message);
		}

		public void TurnOff()
		{
			var message = new MultiStringKeyValuePairsMessageModel()
			{
				Id = Guid.NewGuid().ToString(),
			};
			message.Add($"{Id}控制", false);
			_sender.Send(message);
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