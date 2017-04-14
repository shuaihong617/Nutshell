// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2017-03-08
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2017-03-13
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Automation.Opc.Models;
using Nutshell.Data;
using Nutshell.Extensions;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Nutshell.Storaging;

//重命名OpcDAAuto.dll中类名，禁止删除；
using NativeOpcServer = OPCAutomation.OPCServer;

namespace Nutshell.Automation.Opc
{
	/// <summary>
	/// OpcServer
	/// </summary>
	/// <remarks>处于运行模式下时：
	/// 1. 启动时不连接物理Opc服务器
	/// 2. 通过人工写入模拟Opc项值的变化
	/// 3. Opc项写入请求直接完成</remarks>
	public class OpcServer : DispatchableDevice, IStorable<IOpcServerModel>
        {
		/// <summary>
		/// 初始化<see cref="OpcServer"/>的新实例.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="address">The address.</param>
		public OpcServer(string id = "", string address = "")
                        : base(id)
                {
                        if (!string.IsNullOrEmpty(address))
                        {
                                Address = address;
                        }

                        _nativeOpcServer = new NativeOpcServer();
                }

		#region 字段

		/// <summary>
		/// The _native opc server
		/// </summary>
		private readonly NativeOpcServer _nativeOpcServer;

		/// <summary>
		/// The _opc groups
		/// </summary>
		private ReadOnlyCollection<OpcGroup> _opcGroups;

		#endregion 字段

		#region 属性

		/// <summary>
		/// Gets the address.
		/// </summary>
		/// <value>The address.</value>
		[MustNotEqualNullOrEmpty]
                public string Address { get; private set; }

		/// <summary>
		/// Gets or sets the opc groups.
		/// </summary>
		/// <value>The opc groups.</value>
		public ReadOnlyCollection<OpcGroup> OpcGroups
                {
                        get { return _opcGroups; }
                        set
                        {
                                Debug.Assert(_opcGroups == null);
                                Debug.Assert(value != null);

                                _opcGroups = value;

                                foreach (var opcGroup in _opcGroups)
                                {
                                        opcGroup.Parent = this;
                                }
                        }
                }

		#endregion 属性

		/// <summary>
		/// 从数据模型加载数据
		/// </summary>
		/// <param name="model">读取数据的源数据模型，该数据模型不能为空引用</param>
		public void Load([MustNotEqualNull] IOpcServerModel model)
                {
                        base.Load(model);

                        Address = model.Address;
                }

		/// <summary>
		/// 保存数据到数据模型
		/// </summary>
		/// <param name="model">写入数据的目的数据模型，该数据模型不能为空引用</param>
		/// <exception cref="System.NotImplementedException"></exception>
		public void Save(IOpcServerModel model)
                {
                        throw new NotImplementedException();
                }

		/// <summary>
		/// Starts the connect core.
		/// </summary>
		/// <returns>Result.</returns>
		protected override Result StartConnectCore()
                {
                        try
                        {
                                _nativeOpcServer.Connect(Address);
                        }
                        catch (Exception ex)
                        {
                                this.Error(Id + " " + Address + "  连接失败," + ex);
                                return Result.Failed;
                        }

                        this.InfoSuccess($"连接{Address}");

                        return Result.Successed;
                }

		/// <summary>
		/// Stops the connect core.
		/// </summary>
		/// <returns>Result.</returns>
		protected override Result StopConnectCore()
                {
                        try
                        {
                                _nativeOpcServer.Disconnect();
                        }
                        catch (Exception ex)
                        {
                                this.Error(Id + " " + Address + "  断开失败," + ex);
                                return Result.Failed;
                        }

                        this.InfoSuccess("断开" + Address);

                        return Result.Successed;
                }

		/// <summary>
		/// Starts the dispatch core.
		/// </summary>
		/// <returns>Result.</returns>
		protected override Result StartDispatchCore()
                {
                        try
                        {
                                foreach (var group in OpcGroups)
                                {
                                        group.Attach(_nativeOpcServer, Address);
                                };
                        }
                        catch (Exception ex)
                        {
                                this.Error(Address + "  操作失败," + ex);
                        }

                        foreach (var opcGroup in OpcGroups)
                        {
                                foreach (var opcItem in opcGroup.OpcItems)
                                {
                                        opcItem.RemoteRead();
                                }
                        }

                        this.InfoSuccess("Attach" + Address);

                        return Result.Successed;
                }

		/// <summary>
		/// Stops the dispatch core.
		/// </summary>
		/// <returns>Result.</returns>
		protected override Result StopDispatchCore()
                {
                        try
                        {
                                _nativeOpcServer.Disconnect();
                        }
                        catch (Exception ex)
                        {
                                this.Error(Id + " " + Address + "  断开失败," + ex);
                        }

                        this.InfoSuccess("断开" + Address);

                        return Result.Successed;
                }
        }
}