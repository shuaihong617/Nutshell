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
using System.Diagnostics;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Communication;
using Nutshell.Data;
using Nutshell.Data.Models;
using Nutshell.RabbitMQ.Models;
using Nutshell.Sockets;
using Nutshell.Storaging;

namespace Nutshell.RabbitMQ
{
	/// <summary>
	///         RabbitMQ连接授权
	/// </summary>
	public class RabbitMQAuthorization : StorableObject
	{
		/// <summary>
		/// 获取主机名称
		/// </summary>
		/// <value>主机名称</value>
		/// <remarks>localhost或ip地址</remarks>
		[MustNotEqualNullOrEmpty]
		public string HostName { get; private set; }

		/// <summary>
		/// 获取端口
		/// </summary>
		/// <value>端口</value>
		[MustBetweenOrEqual(PortNumberExtensions.MinimumRecommendPortNumber,
			PortNumberExtensions.MaximumAvailablePortNumber)]
		public int PortNumber { get; private set; }

		/// <summary>
		/// 获取用户名称
		/// </summary>
		/// <value>用户名称</value>
		[MustNotEqualNullOrEmpty]
		public string UserName { get; private set; }

		/// <summary>
		/// 获取用户密码
		/// </summary>
		/// <value>用户密码</value>
		[MustNotEqualNullOrEmpty]
		public string Password { get; private set; }

		/// <summary>
		///         从数据模型加载数据
		/// </summary>
		/// <param name="model">读取数据的源数据模型，该数据模型不能为空引用</param>
	        public override void Load(IIdentityModel model)
	        {
	                base.Load(model);

	                var subModel = model as RabbitMQAuthorizationModel;
                        Trace.Assert(subModel != null);

                        HostName = subModel.HostName;
                        PortNumber = subModel.PortNumber;
                        UserName = subModel.UserName;
                        Password = subModel.Password;
                }

	        /// <summary>
		///         保存数据到数据模型
		/// </summary>
		/// <param name="model">写入数据的目的数据模型，该数据模型不能为空引用</param>
		public void Save(RabbitMQAuthorizationModel model)
		{
			throw new NotImplementedException();
		}
	}
}