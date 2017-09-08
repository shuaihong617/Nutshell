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
using System.IO.Ports;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Communication;
using Nutshell.Data.Models;
using Nutshell.SerialPorts.Models;
using Nutshell.Storaging;

namespace Nutshell.SerialPorts
{
	/// <summary>
	///         SerialPort连接授权
	/// </summary>
	public class SerialPortAuthorization : StorableObject
	{
		/// <summary>
		/// 获取端口名称
		/// </summary>
		/// <value>端口名称</value>
		/// <remarks>localhost或ip地址</remarks>
		[MustNotEqualNullOrEmpty]
		public string PortName { get; private set; }

		/// <summary>
		/// 获取端口
		/// </summary>
		/// <value>端口</value>
		[MustGreaterThan(0)]
		public int BaudRate { get; private set; }

		/// <summary>
		/// 获取校验模式
		/// </summary>
		/// <value>校验模式</value>
		public Parity Parity { get; private set; }

		/// <summary>
		/// 获取数据位
		/// </summary>
		/// <value>数据位</value>
		public int DataBits { get; private set; }

                /// <summary>
		/// 获取数据位
		/// </summary>
		/// <value>数据位</value>
                public StopBits StopBits { get; private set; }

                /// <summary>
		/// 获取数据位
		/// </summary>
		/// <value>数据位</value>
                public Handshake HandShake { get; private set; }

                /// <summary>
                /// 从数据模型加载数据
                /// </summary>
                /// <param name="model">读取数据的源数据模型，该数据模型不能为空引用</param>
                public override void Load(IIdentityModel model)
	        {
	                base.Load(model);

                        var subModel = model as SerialPortAuthorizationModel;
                        Trace.Assert(subModel != null);

                        PortName = subModel.PortName;
                        BaudRate = subModel.BaudRate;
                }
	}
}