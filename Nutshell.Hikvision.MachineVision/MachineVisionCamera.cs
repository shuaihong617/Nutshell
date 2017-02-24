// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2014-08-28
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2014-10-15
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************


using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using Nutshell.Automation.Vision;
using Nutshell.Components;
using Nutshell.Data.Models;
using Nutshell.Drawing.Imaging;
using Nutshell.Extensions;
using Nutshell.Hardware.Vision.Hikvision.MachineVision.Models;
using Nutshell.Hardware.Vision.Hikvision.MachineVision.SDK;
using Nutshell.Logging.KernelLogging;

namespace Nutshell.Hardware.Vision.Hikvision.MachineVision
{
        /// <summary>
        ///         海康威视机器视觉摄像机
        /// </summary>
        public class MachineVisionCamera : NetworkCamera
        {
                public MachineVisionCamera(string id = null, string ipAddress = "192.168.1.1")
                        : base( id, 1280, 960, Drawing.Imaging.PixelFormat.Rgb24, ipAddress)
                {
                        //_captureLooper = new Looper(this, "采集循环",ThreadPriority.Highest,20,Capture);

                        _exceptionCallback = ExceptionCallBack;
                }

                #region 常量

                #endregion

                #region 字段

                /// <summary>
                ///         播放通道
                /// </summary>
                private IntPtr _handle;

                private MVDeviceInformation _deviceInfo;


                /// <summary>
                ///         图像缓冲区指针
                /// </summary>
                private IntPtr _captureBufferPtr = IntPtr.Zero;

                /// <summary>
                ///         预备采集图像字节计数
                /// </summary>
                private const int CaptureBufferBytesCount = 1024*1024*24;


                private MVFrameOutInformation _mvFrameOutInfo;

                private readonly Looper _captureLooper;

                private readonly MVOfficialAPI.ExceptionCallbackFunction _exceptionCallback;

                #endregion

                #region 方法

                public override void Load(IDataModel model)
                {
                        base.Load(model);

                        var cameraModel = model as IMachineVisionCameraModel;
                        Trace.Assert(cameraModel != null);
                }

                

                private void ExceptionCallBack(MVExceptionType mvExceptionType, IntPtr user)
                {
                        this.Info("发生异常");
                        switch (mvExceptionType)
                        {
                                case MVExceptionType.以太网设备断开连接:
                                        this.Warn("摄像机断开连接");

					throw new NotImplementedException();
                                        //Stop();
                                        //Start();
                                        break;
                        }
                }

                public bool IsAccessible()
                {
                        return MVOfficialAPI.IsDeviceAccessible(_handle,ref _deviceInfo, AccessMode.独占权限);
                }

                #endregion
        }
}