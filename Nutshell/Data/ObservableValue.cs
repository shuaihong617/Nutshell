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

using System;
using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Extensions;

namespace Nutshell.Data
{
	/// <summary>
	///         跟踪值更新前后变化的对象
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class ObservableValue<T> where T : struct
	{
		/// <summary>
		///         初始化<see cref="ObservableNullableValue{T}" />的新实例.
		/// </summary>
		/// <param name="value">The value.</param>
		public ObservableValue(T value = default(T))
		{
			Value = value;
		}

		#region 字段

	        #endregion 字段

		/// <summary>
		///         获取或设置值
		/// </summary>
		/// <value>值</value>
		[NotifyPropertyValueChanged]
		public T Value { get; private set; }

	        public ObservableValue<T> SetValue(T value)
	        {
	                Value = value;
                        OnValueChanged(new ValueEventArgs<T>(value));
                        return this;
	        } 

		#region 事件

		/// <summary>
		///         Occurs when [opened].
		/// </summary>
		public event EventHandler<ValueEventArgs<T>> ValueChanged;

		/// <summary>
		///         引发 <see cref="E:Opened" /> 事件.
		/// </summary>
		/// <param name="e">The <see cref="ValueChangedEventArgs{T}" /> Itance containing the event data.</param>
		protected virtual void OnValueChanged(ValueEventArgs<T> e)
		{
			e.Raise(this, ref ValueChanged);
		}

		#endregion 事件
	}
}