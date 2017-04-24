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
        public class ObservableNullableValue<T> where T : struct
        {
		/// <summary>
		/// 初始化<see cref="ObservableNullableValue{T}" />的新实例.
		/// </summary>
		public ObservableNullableValue()
		{
			Data = null;
		}

		/// <summary>
		/// 初始化<see cref="ObservableNullableValue{T}" />的新实例.
		/// </summary>
		/// <param name="data">The value.</param>
		public ObservableNullableValue(T data)
                {
                        Data = data;
                }

                #region 字段

                #endregion 字段

                /// <summary>
                ///         获取或设置值
                /// </summary>
                /// <value>值</value>
                [NotifyPropertyValueChanged]
                public T? Data { get; private set; }


                public void SetData(T? value)
                {
                        if (Equals(Data, value))
                        {
                               return; 
                        }

                        Data = value;
                        OnDataChanged(new ValueEventArgs<T?>(value));
                }

                #region 事件

                /// <summary>
                ///         当值改变时发生.
                /// </summary>
                public event EventHandler<ValueEventArgs<T?>> DataChanged;

                /// <summary>
                ///         引发 <see cref="E:ValueChanged" /> 事件.
                /// </summary>
                /// <param name="e">The <see cref="ValueChangedEventArgs{T}" /> Itance containing the event data.</param>
                protected virtual void OnDataChanged(ValueEventArgs<T?> e)
                {
                        e.Raise(this, ref DataChanged);
                }

                #endregion 事件
        }
}