// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2014-10-16
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2014-10-16
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System;

namespace Nutshell
{
        /// <summary>
        /// 带数据的返回值
        /// </summary>
        public class ValueResult<T> : Result
        {
                /// <summary>
                ///         初始化<see cref="ValueEventArgs{T}" />的新实例.
                /// </summary>
                /// <param name="value">The result.</param>
                public ValueResult(T value)
			:base(true)
                {
                        Value = value;
                }

		/// <summary>
		///         初始化<see cref="ValueEventArgs{T}" />的新实例.
		/// </summary>
		private ValueResult()
			: base(false)
		{
		}
		/// <summary>
		///         数据
		/// </summary>
		public T Value { get; private set; }

		public new static readonly ValueResult<T> Failed = new ValueResult<T>(); 
        }
}