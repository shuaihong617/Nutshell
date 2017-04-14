using System;
using System.ComponentModel;
using System.Diagnostics;
using Nutshell.Aspects.Events;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Communication;
using Nutshell.Data;
using Nutshell.Extensions;
using Nutshell.Messaging.Models;
using Nutshell.Messaging.Xml.Models;

namespace Nutshell.Automation.MicroDevices
{
        /// <summary>
        ///         传感器
        /// </summary>
        public class Sensor<T> : Device where T : struct
        {
                public Sensor(string id)
                        : base(id)
                {
			_state.ValueChanged += (obj, args) =>
			{
				if (!args.Value.HasValue)
				{
					return;
				}

				State = args.Value.Value;

				if (DataResponseSender != null)
				{
					var message = new XmlValueMessageModel<T>
					{
						Id = Guid.NewGuid().ToString(),
						Category = Id,
						Value = State
					};
					DataResponseSender.Send(message);
				}
			};
		}

		protected readonly ObservableNullable<T> _state = new ObservableNullable<T>();

		[NotifyPropertyValueChanged]
		public T State { get; private set; }

		[MustNotEqualNull]
		public ISender<IValueMessageModel<T>> DataResponseSender { get; private set; }


		public Sensor<T> SetDataResponseSender([MustNotEqualNull] ISender<IValueMessageModel<T>> sender)
		{
			Trace.Assert(DataResponseSender == null);

			DataResponseSender = sender;
			
			return this;
		}

		#region 事件

		/// <summary>
		///         Occurs when [opened].
		/// </summary>
		[Description("数据更新事件")]
		public event EventHandler<EventArgs> ValueChanged;

		/// <summary>
		///         引发<see cref="E:Opened" />事件
		/// </summary>
		/// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
		protected virtual void OnValueChanged(EventArgs e)
		{
			e.Raise(this, ref ValueChanged);
		}

		#endregion
	}
}