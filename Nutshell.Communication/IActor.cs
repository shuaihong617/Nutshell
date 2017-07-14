// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2016-12-17
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2016-12-17
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using Nutshell.Messaging.Models;
using Nutshell.Serializing;

namespace Nutshell.Communication
{
	/// <summary>
	///         发送器和接收器基础接口
	/// </summary>
	public interface IActor<T> where T : Message
	{
		ISerializer<T> Serializer { get; }

		IActor<T> BindBus(Bus bus);
	}
}
