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

using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Data;
using Nutshell.RabbitMQ.Models;
using Nutshell.Storaging;

namespace Nutshell.RabbitMQ
{
	/// <summary>
	///         RabbitMQ认证数据模型接口
	/// </summary>
	public class RabbitMQQueue : StorableObject,IStorable<RabbitMQQueueModel>
	{
		/// <summary>
		///         获取或设置名称
		/// </summary>
		/// <value>名称</value>
		[MustNotEqualNullOrEmpty]
		public string Name { get; set; }

		/// <summary>
		///         获取或设置路由键
		/// </summary>
		/// <value>路由键</value>
		[MustNotEqualNull]
		public string RoutingKey { get; set; }

		/// <summary>
		///         获取或设置是否持久化
		/// </summary>
		/// <value>是否持久化</value>
		public bool IsDurable { get; set; }
		
		/// <summary>
		///         获取或设置是否私有
		/// </summary>
		/// <value>是否私有</value>
		public bool IsExclusive { get; private set; }

		/// <summary>
		///         获取或设置是否自动删除
		/// </summary>
		/// <value>是否自动删除</value>
		public bool IsAutoDelete { get; set; }

		/// <summary>
		///         从数据模型加载数据
		/// </summary>
		/// <param name="model">读取数据的源数据模型，该数据模型不能为空引用</param>
		public void Load(RabbitMQQueueModel model)
		{
			base.Load(model);

			Name = model.Name;
			RoutingKey = model.RoutingKey;
			IsDurable = model.IsDurable;
			IsExclusive = model.IsExclusive;
			IsAutoDelete = model.IsAutoDelete;
		}

		/// <summary>
		///         保存数据到数据模型
		/// </summary>
		/// <param name="model">写入数据的目的数据模型，该数据模型不能为空引用</param>
		public void Save(RabbitMQQueueModel model)
		{
			throw new System.NotImplementedException();
		}
	}
}