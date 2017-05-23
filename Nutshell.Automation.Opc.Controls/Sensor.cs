// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2017-05-23
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2017-05-23
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Diagnostics;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Extensions;

namespace Nutshell.Automation.Opc.Controls
{
        /// <summary>
        /// 传感器
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class Sensor<T> : Device where T : struct
        {
                /// <summary>
                /// 初始化<see cref="T:Nutshell.Automation.Device" />的新实例.
                /// </summary>
                /// <param name="id">The identifier.</param>
                public Sensor(string id)
                        : base(id)
                {
                        _valueOpcAccessor.ValueChanged += (obj, args) => Value = args.Value;
                }

                #region 字段

                private T? _value;

                /// <summary>
                /// The _value opc accessor
                /// </summary>
                private readonly OpcAccessor<T> _valueOpcAccessor = new OpcAccessor<T>();

                #endregion


                

                /// <summary>
                /// Gets the value.
                /// </summary>
                /// <value>The value.</value>
                [NotifyPropertyValueChanged]
                public T? Value
                {
                        get { return _value; }
                        private set
                        {
                                if (Equals(value, _value))
                                {
                                        return;
                                }

                                _value = value;
                                OnPropertyChanged();

                                if (!_value.HasValue)
                                {
                                        return;
                                }
                                OnValueChanged(new ValueEventArgs<T>(_value.Value));
                        }
                }

                

                /// <summary>
                /// Sets the value opc item.
                /// </summary>
                /// <param name="opcItem">The opc item.</param>
                /// <returns>Sensor&lt;T&gt;.</returns>
                public Sensor<T> SetValueOpcItem([MustNotEqualNull] OpcItem opcItem)
                {
                        _valueOpcAccessor.SetSource(opcItem);
                        return this;
                }

                /// <summary>
                /// Clears this instance.
                /// </summary>
                public void Clear()
                {
                        Value = null;
                }

                #region 事件

                /// <summary>
                /// Occurs when [opened].
                /// </summary>
                [Description("数据更新事件")]
                public event EventHandler<ValueEventArgs<T>> ValueChanged;

                /// <summary>
                /// 引发<see cref="E:Opened" />事件
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
                protected virtual void OnValueChanged(ValueEventArgs<T> e)
                {
                        e.Raise(this, ref ValueChanged);
                }

                #endregion
        }
}