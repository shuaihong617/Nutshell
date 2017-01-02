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
using Nutshell.Components;
using Nutshell.Data.Models;
using Nutshell.Drawing.Imaging;
using Nutshell.Hardware.Vision.Hikvision.MachineVision.Models;
using Nutshell.Hardware.Vision.Hikvision.MachineVision.SDK;
using Nutshell.Log;

namespace Nutshell.Hardware.Vision.Hikvision.MachineVision
{
        /// <summary>
        ///         海康威视机器视觉摄像机
        /// </summary>
        public class MachineVisionCamera : NetworkCamera
        {
                public MachineVisionCamera(IdentityObject parent, string id = null, string ipAddress = "192.168.1.1")
                        : base(parent, id, 1280, 960, Drawing.Imaging.PixelFormat.Rgb24, ipAddress)
                {
                        _captureLooper = new Looper(this, "采集循环",ThreadPriority.Highest,20,Capture);

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

                protected override sealed bool ConnectCore()
                {
                        _deviceInfo =
                                MachineVisionRuntime.Itance.DeviceInfos.FirstOrDefault(
                                        i => Equals(i.GigeDeviceInfo.GetCurrentIpAddress(), IPAddress));

                        if (_deviceInfo.MajorVer == 0)
                        {
                                this.WarnFail("枚举摄像机", "未枚举到摄像机信息");
                                return false;
                        }

                        MVErrorCode mvError = MVOfficialAPI.CreateHandle(ref _handle, ref _deviceInfo);
                        if (mvError != MVErrorCode.MV_OK)
                        {
                                this.WarnFail("CreateHandle", mvError);
                                return false;
                        }
                        this.InfoSuccess("CreateHandle");

                        if (!MVOfficialAPI.RegisterExceptionCallBack(_handle, _exceptionCallback, IntPtr.Zero))
                        {
                                this.WarnFail("RegisterExceptionCallBack", mvError);
                                return false;
                        }
                        

                        mvError = MVOfficialAPI.OpenDevice(_handle, AccessMode.控制权限);
                        if (mvError != MVErrorCode.MV_OK)
                        {
                                this.WarnFail("OpenDevice", mvError);
                                return false;
                        }
                        this.InfoSuccess("OpenDevice");

                        return true;
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

                protected override sealed bool DisconnectCore()
                {
                        MVErrorCode mvError = MVOfficialAPI.CloseDevice(_handle);
                        if (mvError != MVErrorCode.MV_OK)
                        {
                                this.WarnFail("CloseDevice", mvError);
                                return false;
                        }
                        this.InfoSuccess("CloseDevice");

                        mvError = MVOfficialAPI.DestroyHandle(_handle);
                        if (mvError != MVErrorCode.MV_OK)
                        {
                                this.WarnFail("DestroyHandle", mvError);
                                return false;
                        }
                        this.InfoSuccess("DestroyHandle");

                        return true;
                }

                protected override sealed bool StartCaptureCore()
                {
                        CreateBitmapPool();

                        if (_captureBufferPtr == IntPtr.Zero)
                        {
                                _captureBufferPtr = Marshal.AllocHGlobal(CaptureBufferBytesCount);
                        }

                        MVErrorCode mvError = MVOfficialAPI.StartGrabbing(_handle);
                        if (mvError != MVErrorCode.MV_OK)
                        {
                                this.WarnFail("StartGrabbing", mvError);
                                return false;
                        }
                        this.InfoSuccess("StartGrabbing");

			throw new NotImplementedException();
                        //return _captureLooper.Start();
                }

                protected override bool StopCaptureCore()
                {
			throw new NotImplementedException();
			//_captureLooper.Stop();

			MVOfficialAPI.StopGrabbing(_handle);

                        return true;
                }

                protected override sealed Bitmap CaptureCore()
                {
			throw new NotImplementedException();
			//
			//if (!IsEnable || !IsStarted || !IsConnected || !IsStartCaptured)
   //                     {
   //                             Trace.WriteLine("!IsEnable || !IsStarted || !IsConnected || !IsStartCaptured Failed");
   //                             return null;
   //                     }

                        Bitmap bitmap = Buffers.WriteLock();

                        MVErrorCode mvError = MVOfficialAPI.GetOneFrame(_handle, bitmap.Buffer, bitmap.BufferLength,
                                ref _mvFrameOutInfo);
                        if (mvError != MVErrorCode.MV_OK)
                        {
                                //this.WarnFail("GetOneFrame", error);
                                Buffers.WriteUnlock(bitmap);
                                return null;
                        }
                        //this.InfoSuccess("GetOneFrame");
                        Buffers.WriteUnlock(bitmap);

                        var stamp = bitmap.TimeStampChain as CaptureTimeStampChain;
                        if (stamp != null)
                        {
                                stamp.CaptureTime = DateTime.Now;
                        }

                        return bitmap;
                }

                public bool IsAccessible()
                {
                        return MVOfficialAPI.IsDeviceAccessible(_handle,ref _deviceInfo, AccessMode.独占权限);
                }

                #endregion
        }
}