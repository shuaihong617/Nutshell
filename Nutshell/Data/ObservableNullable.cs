// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-05-19
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-05-20
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using Nutshell.Extensions;
using System;
using Nutshell.Aspects.Locations.Propertys;

namespace Nutshell.Data
{
        /// <summary>
        ///         跟踪可空值更新前后变化的对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class ObservableNullable<T> where T : struct
        {
		/// <summary>
		/// 初始化<see cref="ObservableNullable{T}" />的新实例.
		/// </summary>
		public ObservableNullable()
		{
			_value = null;
		}

		/// <summary>
		/// 初始化<see cref="ObservableNullable{T}" />的新实例.
		/// </summary>
		/// <param name="value">The value.</param>
		public ObservableNullable(T value)
                {
                        _value = value;
                }

                #region 字段

                /// <summary>
                ///         值
                /// </summary>
                private T? _value;

                #endregion 字段

                /// <summary>
                ///         获取或设置值
                /// </summary>
                /// <value>值</value>
                [NotifyPropertyValueChanged]
                public T? Value
                {
                        get { return _value; }
                        set
                        {
                                _value = value;
                                OnValueChanged(new ValueEventArgs<T?>(value));
                        }
                }

                #region 事件

                /// <summary>
                ///         Occurs when [opened].
                /// </summary>
                public event EventHandler<ValueEventArgs<T?>> ValueChanged;

                /// <summary>
                ///         引发 <see cref="E:Opened" /> 事件.
                /// </summary>
                /// <param name="e">The <see cref="ValueChangedEventArgs{T}" /> Itance containing the event data.</param>
                protected virtual void OnValueChanged(ValueEventArgs<T?> e)
                {
                        e.Raise(this, ref ValueChanged);
                }

                #endregion 事件
        }
}