// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2016-12-27
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2016-12-29
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************


using Nutshell.Components.Models;
using Nutshell.Data;

namespace Nutshell.Components
{
        /// <summary>
        /// 可连接组件接口
        /// </summary>
        public interface IConnectableComponent : IComponent, IStorable<IConnectableComponentModel>
        {
                /// <summary>
                /// 获取连接状态
                /// </summary>
                /// <value>连接状态</value>
                ConnectState ConnectState { get; }

                /// <summary>
                /// 获取连接工作者，连接工作者负责组件的连接\断开
                /// </summary>
                /// <value>连接工作者</value>
                IConnectWorker ConnectWorker { get; }

		/// <summary>
		/// 获取守护工作者，守护工作者负责组件的在线检测、断线重连
		/// </summary>
		/// <value>守护工作者</value>
		ISurviveLooper SurviveLooper { get; }

		/// <summary>
		/// 连接
		/// </summary>
		/// <returns>操作结果</returns>
		IResult StartConnect();

		/// <summary>
		///  断开连接
		/// </summary>
		/// <returns>操作结果</returns>
		IResult StopConnect();


		/// <summary>
		///  测试是否守护
		/// </summary>
		/// <returns>操作结果</returns>
		IResult IsSurvive();

		/// <summary>
		/// 连接
		/// </summary>
		/// <returns>操作结果</returns>
		IResult StartSurvive();

		/// <summary>
		///  断开连接
		/// </summary>
		/// <returns>操作结果</returns>
		IResult StopSurvive();
	}
}
