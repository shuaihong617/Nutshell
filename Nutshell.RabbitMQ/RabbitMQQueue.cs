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

using System.Diagnostics;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Data;
using Nutshell.Data.Models;
using Nutshell.RabbitMQ.Models;
using Nutshell.Storaging;

namespace Nutshell.RabbitMQ
{
	/// <summary>
	///         RabbitMQ认证数据模型接口
	/// </summary>
	public class RabbitMQQueue : StorableObject
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

	        public override void Load(IIdentityModel model)
	        {
	                base.Load(model);

	                var subModel = model as RabbitMQQueueModel;
                        Trace.Assert(subModel != null);

                        Name = subModel.Name;
                        IsDurable = subModel.IsDurable;
                        IsExclusive = subModel.IsExclusive;
                        IsAutoDelete = subModel.IsAutoDelete;
                }		
	}
}