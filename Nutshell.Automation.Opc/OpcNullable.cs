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
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Data;

namespace Nutshell.Automation.Opc
{
	/// <summary>
	///         跟踪值更新前后变化的对象
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class OpcNullable<T> : ObservableNullable<T> where T : struct
	{
		/// <summary>
		///         初始化<see cref="OpcNullable{T}" />的新实例.
		/// </summary>
		/// <param name="parent">The parent.</param>
		/// <param name="id">The item.</param>
		/// <param name="opcItem">The opc item.</param>
		public OpcNullable([MustNotEqualNull] IdentityObject parent,
			[MustNotEqualNull] string id,
			[MustNotEqualNull] OpcItem opcItem)
			: base(parent, id)
		{
			_opcItem = opcItem;

			_opcItem.ReadSuccessed += (obj, args) => { Value = ConvertFrom(args.Value, _opcItem.TypeCode); };
			_opcItem.ReadFailed += (obj, args) => { Value = null; };
		}

		private readonly OpcItem _opcItem;

		public void RemoteWrite(T t)
		{
			_opcItem.RemoteWrite(t);
		}

		public void RemoteRead()
		{
			var result = _opcItem.RemoteRead();
			Value = ConvertFrom(result, _opcItem.TypeCode);
		}

		private T? ConvertFrom(object value, TypeCode typeCode)
		{
			throw new NotImplementedException();
			//return null;
		}
	}
}