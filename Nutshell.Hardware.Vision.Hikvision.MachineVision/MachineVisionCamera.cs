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
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using Nutshell.Components;
using Nutshell.Data.Models;
using Nutshell.Drawing.Imaging;
using Nutshell.Hardware.Vision.Hikvision.MachineVision.Models;
using Nutshell.Hardware.Vision.Hikvision.MachineVision.SDK;
using Nutshell.Hardware.Vision.Mvsion.SDK;
using Nutshell.Log;

namespace Nutshell.Hardware.Vision.Hikvision.MachineVision
{
        /// <summary>
        ///         海康威视摄像机
        /// </summary>
        public class MachineVisionCamera : GigeCamera
        {
                public MachineVisionCamera(IdentityObject parent, string id = "", string ipAddress = "192.168.1.1")
                        : base(parent, id, 1280, 960, PixelFormat.Rgb24, ipAddress)
                {
                        _captureLooper = new Looper(this, "采集循环", Capture, 32);

                        _exceptionCallback = ExceptionCallBack;
                }

                #region 常量

                #endregion

                #region 字段

                /// <summary>
                ///         播放通道
                /// </summary>
                private IntPtr _handle;

                private DeviceInfo _deviceInfo;


                /// <summary>
                ///         图像缓冲区指针
                /// </summary>
                private IntPtr _captureBufferPtr = IntPtr.Zero;

                /// <summary>
                ///         预备采集图像字节计数
                /// </summary>
                private const int CaptureBufferBytesCount = 1024*1024*24;


                private FrameOutInfo _frameOutInfo;

                private readonly Looper _captureLooper;

                private readonly API.ExceptionCallbackFunction _exceptionCallback;

                #endregion

                #region 方法

                public override void Load(IStorableModel model)
                {
                        base.Load(model);

                        var cameraModel = model as MachineVisionCameraModel;
                        Trace.Assert(cameraModel != null);
                }

                protected override sealed bool ConnectCore()
                {
                        _deviceInfo =
                                MachineVisionRuntime.Instance.DeviceInfos.FirstOrDefault(
                                        i => Equals(i.GigeDeviceInfo.GetCurrentIpAddress(), IPAddress));

                        if (_deviceInfo.MajorVer == 0)
                        {
                                this.WarnFail("枚举摄像机", "未刷新到摄像机信息");
                                return false;
                        }

                        ErrorCode error = API.CreateHandle(ref _handle, ref _deviceInfo);
                        if (error != ErrorCode.MV_OK)
                        {
                                this.WarnFail("CreateHandle", error);
                                return false;
                        }
                        this.InfoSuccess("CreateHandle");

                        API.RegisterExceptionCallBack(_handle, _exceptionCallback, IntPtr.Zero);

                        error = API.OpenDevice(_handle, AccessMode.控制权限);
                        if (error != ErrorCode.MV_OK)
                        {
                                this.WarnFail("OpenDevice", error);
                                return false;
                        }
                        this.InfoSuccess("OpenDevice");

                        return true;
                }

                private void ExceptionCallBack(ExceptionType exceptionType, IntPtr user)
                {
                        switch (exceptionType)
                        {
                                case ExceptionType.以太网设备断开连接:
                                        this.Warn("摄像机断开连接");

                                        Stop();
                                        Start();
                                        break;
                        }
                }

                protected override sealed bool DisconnectCore()
                {
                        ErrorCode error = API.CloseDevice(_handle);
                        if (error != ErrorCode.MV_OK)
                        {
                                this.WarnFail("CloseDevice", error);
                                return false;
                        }
                        this.InfoSuccess("CloseDevice");

                        error = API.DestroyHandle(_handle);
                        if (error != ErrorCode.MV_OK)
                        {
                                this.WarnFail("DestroyHandle", error);
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

                        ErrorCode error = API.StartGrabbing(_handle);
                        if (error != ErrorCode.MV_OK)
                        {
                                this.WarnFail("StartGrabbing", error);
                                return false;
                        }
                        this.InfoSuccess("StartGrabbing");

                        return _captureLooper.Start();
                }

                protected override bool StopCaptureCore()
                {
                        _captureLooper.Stop();

                        API.StopGrabbing(_handle);

                        return true;
                }

                private int i;

                protected override sealed Bitmap CaptureCore()
                {
                        if (!IsEnable || !IsStarted || !IsConnected || !IsStartCaptured)
                        {
                                Trace.WriteLine("!IsEnable || !IsStarted || !IsConnected || !IsStartCaptured Failed");
                                return null;
                        }

                        Bitmap bitmap = BitmapPool.EnterWrite();
                        if (bitmap == null)
                        {
                                Trace.WriteLine("BitmapPool.Instance.EnterWrite Failed");
                                return null;
                        }

                        //ErrorCode error = API.GetOneFrame(_handle, _captureBufferPtr, CaptureBufferBytesCount,
                        //        ref _frameOutInfo);
                        ErrorCode error = API.GetOneFrame(_handle, bitmap.Buffer, bitmap.BufferLength,
                                ref _frameOutInfo);
                        if (error != ErrorCode.MV_OK)
                        {
                                this.WarnFail("GetOneFrame", error);
                                BitmapPool.ExitWrite(bitmap);
                                return bitmap;
                        }
                        //this.InfoSuccess("GetOneFrame");

                        //bitmap.CopyFrom(_captureBufferPtr);

                        //bitmap.Clear((byte)128,(byte)128,(byte)128);

                        i++;

                        //bitmap.Save("c:\\Camera\\" + i + ".bmp");

                        BitmapPool.ExitWrite(bitmap);
                        return bitmap;
                }

                #endregion
        }
}