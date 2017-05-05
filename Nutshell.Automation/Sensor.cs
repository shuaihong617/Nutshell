using System;
using System.ComponentModel;
using System.Diagnostics;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Communication;
using Nutshell.Communication.Data;
using Nutshell.Extensions;
using Nutshell.Messaging.Models;

namespace Nutshell.Automation
{
        /// <summary>
        ///         传感器
        /// </summary>
        public class Sensor<T> : Device where T : struct
        {
                public Sensor(string id)
                        : base(id)
                {
                }

		[NotifyPropertyValueChanged]
                public T? Value { get; private set; }

                [MustNotEqualNull]
                private IReceiver<ValueMessageModel<T>> _receiver;

                public Sensor<T> SetReceiver([MustNotEqualNull] IReceiver<ValueMessageModel<T>> receiver)
                {
                        Trace.Assert(_receiver != null);

                        _receiver = receiver;
                        _receiver.Received += (obj, args) =>
                        {
                                Value = args.Value.Value;
                                OnValueChanged(new ValueEventArgs<T>(args.Value.Value));
                        };

                        return this;
                }

	        public void Clear()
	        {
		        Value = null;
	        }

                #region 事件

                /// <summary>
                ///         Occurs when [opened].
                /// </summary>
                [Description("数据更新事件")]
                public event EventHandler<ValueEventArgs<T>> ValueChanged;

                /// <summary>
                ///         引发<see cref="E:Opened" />事件
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
                protected virtual void OnValueChanged(ValueEventArgs<T> e)
                {
                        e.Raise(this, ref ValueChanged);
                }

                #endregion
        }
}