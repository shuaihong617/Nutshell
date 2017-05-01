// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2017-04-21
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2017-04-21
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳.. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

namespace Nutshell.Components
{
	/// <summary>
	///         可变限位
	/// </summary>
	public class VariableLimiter : Limiter
	{
		/// <summary>
		///         Gets a value indicating whether this instance is over.
		/// </summary>
		/// <value><c>true</c> if this instance is over; otherwise, <c>false</c>.</value>
		public double Offset { get; private set; }

		public override void SetParcticeValue(double value)
		{
			base.SetParcticeValue(value + Offset);
		}

		public void SetOffset(double offset)
		{
			Offset = offset;
		}
	}
}
