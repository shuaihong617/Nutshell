// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-01-05
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-01-05
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Data;
using Nutshell.RabbitMQ.Models;
using Nutshell.RabbitMQ.Models.Xml;
using Nutshell.RabbitMQ.SDK;
using Nutshell.Storaging;

namespace Nutshell.RabbitMQ
{
	/// <summary>
	///         RabbitMQ交换机
	/// </summary>
	public class RabbitMQExchange : StorableObject, IStorable<XmlRabbitMQExchangeModel>
	{
		/// <summary>
		///         获取或设置名称
		/// </summary>
		/// <value>名称</value>
		[MustNotEqualNullOrEmpty]
		public string Name { get; private set; }

		/// <summary>
		///         获取或设置交换类型
		/// </summary>
		/// <value>交换类型</value>
		public ExchangeType ExchangeType { get; private set; }

		/// <summary>
		///         获取或设置是否持久化
		/// </summary>
		/// <value>是否持久化</value>
		public bool IsDurable { get; private set; }

		/// <summary>
		///         获取或设置是否自动删除
		/// </summary>
		/// <value>是否自动删除</value>
		public bool IsAutoDelete { get; private set; }

		/// <summary>
		///         从数据模型加载数据
		/// </summary>
		/// <param name="model">读取数据的源数据模型，该数据模型不能为空引用</param>
		public void Load(XmlRabbitMQExchangeModel model)
		{
			base.Load(model);

			Name = model.Name;
			ExchangeType = model.ExchangeType;
			IsDurable = model.IsDurable;
			IsAutoDelete = model.IsAutoDelete;
		}

		/// <summary>
		///         保存数据到数据模型
		/// </summary>
		/// <param name="model">写入数据的目的数据模型，该数据模型不能为空引用</param>
		public void Save(XmlRabbitMQExchangeModel model)
		{
			throw new NotImplementedException();
		}
	}
}