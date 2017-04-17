using System;
using System.ComponentModel;
using System.Diagnostics;
using Nutshell.Aspects.Events;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Communication.Data;
using Nutshell.Extensions;
using Nutshell.Messaging.Xml.Models;

namespace Nutshell.Automation
{
	/// <summary>
	///         电灯
	/// </summary>
	public class Lamp : Device
	{
		public Lamp(string id)
			: base(id)
		{
		}

                public bool? State { get; private set; }

                [MustNotEqualNull]
                private Messager<bool> _messager;

                public Lamp SetMessager([MustNotEqualNull]Messager<bool> messager)
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
			var message = new XmlValueMessageModel<bool>
			{
				Id = Guid.NewGuid().ToString(),
				Category = Id,
				Value = true
			};
			_messager.ToLowerSender.Send(message);
		}

		public void TurnOff()
		{
			var message = new XmlValueMessageModel<bool>
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