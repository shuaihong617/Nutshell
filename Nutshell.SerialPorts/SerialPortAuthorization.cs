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
using System.IO.Ports;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Communication;
using Nutshell.SerialPorts.Models;
using Nutshell.Storaging;

namespace Nutshell.SerialPorts
{
	/// <summary>
	///         SerialPort连接授权
	/// </summary>
	public class SerialPortAuthorization : StorableObject, IStorable<SerialPortAuthorizationModel>
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
		[MustBetweenOrEqual(EthernetPortNumberExtensions.MinimumRecommendPortNumber,
			EthernetPortNumberExtensions.MaximumAvailablePortNumber)]
		public int BaudRate { get; private set; }

		/// <summary>
		/// 获取校验模式
		/// </summary>
		/// <value>校验模式</value>
		[MustNotEqualNullOrEmpty]
		public Parity Parity { get; private set; }

		/// <summary>
		/// 获取数据位
		/// </summary>
		/// <value>数据位</value>
		[MustNotEqualNullOrEmpty]
		public int DataBits { get; private set; }

                /// <summary>
		/// 获取数据位
		/// </summary>
		/// <value>数据位</value>
		[MustNotEqualNullOrEmpty]
                public int StopBits { get; private set; }

                /// <summary>
		/// 获取数据位
		/// </summary>
		/// <value>数据位</value>
		[MustNotEqualNullOrEmpty]
                public int HandShake { get; private set; }

                /// <summary>
                ///         从数据模型加载数据
                /// </summary>
                /// <param name="model">读取数据的源数据模型，该数据模型不能为空引用</param>
                public void Load(SerialPortAuthorizationModel model)
		{
			base.Load(model);

			PortName = model.PortName;
			BaudRate = (int)model.BaudRate;
		}

		/// <summary>
		///         保存数据到数据模型
		/// </summary>
		/// <param name="model">写入数据的目的数据模型，该数据模型不能为空引用</param>
		public void Save(SerialPortAuthorizationModel model)
		{
			throw new NotImplementedException();
		}
	}
}