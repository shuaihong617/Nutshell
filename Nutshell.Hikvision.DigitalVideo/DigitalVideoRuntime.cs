// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2014-10-16
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2014-10-17
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 武汉九鼎科达科技有限公司. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System.Runtime.InteropServices;
using Nutshell.Components;
using Nutshell.Hikvision.DigitalVideo.SDK;

namespace Nutshell.Hikvision.DigitalVideo
{
        /// <summary>
        ///         海康威视摄像机运行环境
        /// </summary>
        public class DigitalVideoRuntime : Runtime
        {
                protected DigitalVideoRuntime()
                        :base("海康威视数字视频设备运行环境")
                {
                        
                }

                #region 单例

                /// <summary>
                ///         单例
                /// </summary>
                public static readonly DigitalVideoRuntime Instance = new DigitalVideoRuntime();

                #endregion

                #region 方法

                protected override bool StartCore()
                {
                        if (!OfficalAPI.NET_DVR_Init())
                        {
                                return false;
                        }


			//GlobalLoger.Info("摄像机运行环境创建" + (IsCreated ? "成功" : "失败, 错误代码" + HikvisionSDK.NET_DVR_GetLastError()));


			OfficalAPI.NET_DVR_SetConnectTime(3000, 1);
			OfficalAPI.NET_DVR_SetReconnect(500, 0);
                        OfficalAPI.NET_DVR_SetRecvTimeOut(3000);
                        
                        return true;
                }

                protected override bool StopCore()
                {
                        //GlobalLoger.Info("摄像机运行环境清理" + (!IsCreated ? "成功" : "失败, 错误代码" + HikvisionSDK.NET_DVR_GetLastError()));

                        return OfficalAPI.NET_DVR_Cleanup();
                }
                
                #endregion

                
        }
}