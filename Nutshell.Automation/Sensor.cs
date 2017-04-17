using System;
using System.ComponentModel;
using System.Diagnostics;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Communication.Data;
using Nutshell.Extensions;

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

                public T? Value { get; private set; }

                [MustNotEqualNull]
                private Messager<T> _messager;

                public Sensor<T> SetMessager([MustNotEqualNull] Messager<T> messager)
                {
                        Trace.Assert(_messager != null);

                        _messager = messager;
                        _messager.DataChanged += (obj, args) =>
                        {
                                Value = args.Value;

                                if (!args.Value.HasValue)
                                {
                                        return;
                                }
                                OnValueChanged(new ValueEventArgs<T>(args.Value.Value));
                        };

                        return this;
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