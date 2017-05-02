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

using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Automation;
using Nutshell.Automation.Vision;
using Nutshell.Data;
using Nutshell.Drawing.Imaging;
using Nutshell.Extensions;
using Nutshell.Hikvision.MachineVision.SDK;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using Nutshell.Hikvision.MachineVision.Models;
using Nutshell.IO.Aspects.Locations.Contracts;
using Nutshell.Serializing.Xml;
using Nutshell.Storaging;
using Nutshell.Storaging.Xml;

namespace Nutshell.Hikvision.MachineVision
{
        /// <summary>
        ///         海康威视机器视觉摄像机
        /// </summary>
        public partial class MachineVisionCamera : NetworkCamera, IStorable<MachineVisionCameraModel>
        {
                public MachineVisionCamera(string id = "", string ipAddress = "0.0.0.0")
                        : base(id, 1280, 960, PixelFormat.Rgb24, ipAddress)
                {
                }

                #region 字段

                /// <summary>
                ///         设备句柄
                /// </summary>
                private IntPtr _handle = IntPtr.Zero;

                private DeviceInformation _deviceInformation;

                private FrameOutInformation _frameOutInformation;

                #endregion 字段

                #region 属性

                [MustNotEqual(UserSet.Default)]
                public UserSet UserSet { get; private set; } = UserSet.UserSet1;

                [MustBetween(OfficialApi.MinStreamChannelPacketSize, OfficialApi.MaxStreamChannelPacketSize)]
                public int StreamChannelPacketSize { get; private set; } = OfficialApi.DefaultStreamChannelPacketSize;

                #endregion 属性

                #region 方法

                #region 存储

                public static MachineVisionCamera  Load([MustFileExist]string fileName)
                {
                        var bytes = XmlStorager.Instance.Load(fileName);
                        var model = XmlSerializer<MachineVisionCameraModel>.Instance.Deserialize(bytes);

                        var camera = new MachineVisionCamera();

                        camera.Load(model);

                        return camera;
                }

                /// <summary>
                ///         从数据模型加载数据
                /// </summary>
                /// <param name="model">读取数据的源数据模型，该数据模型不能为null</param>
                public void Load(MachineVisionCameraModel model)
                {
                        base.Load(model);

                        UserSet = model.UserSet;
                        StreamChannelPacketSize = model.StreamChannelPacketSize;

                        Debug.WriteLine(UserSet);
                        Debug.WriteLine(StreamChannelPacketSize);
                }

                /// <summary>
                ///         保存数据到数据模型
                /// </summary>
                /// <param name="model">写入数据的目的数据模型，该数据模型不能为null</param>
                public void Save(MachineVisionCameraModel model)
                {
                        throw new NotImplementedException();
                }

                #endregion 存储

                protected override sealed bool StartConnectCore()
                {
                        if (!base.StartConnectCore())
                        {
                                return false;
                        }

                        Debug.Assert(!Equals(IPAddress, IPAddress.Any));

                        var installedMachineVisionCamera = MachineVisionRuntime.Instance.InstalledMachineVisionCameras.FirstOrDefault(
                                i => Equals(i.IPAddress, IPAddress));

                        if (installedMachineVisionCamera == null)
                        {
                                this.Warn("未检测到摄像机");
                                return false;
                        }

                        _deviceInformation = installedMachineVisionCamera.DeviceInformation;

                        var errorCode = CreateHandle();
                        if (errorCode != ErrorCode.MV_OK)
                        {
                                return false;
                        }

                        errorCode = OpenDevice();
                        if (errorCode != ErrorCode.MV_OK)
                        {
                                return false;
                        }

                        //AdjustSCPSPacketSize();

                        //SetDefaultUserSet(UserSet.UserSet1);
                        //SetCurrentUserSet(UserSet.UserSet1);
                        //LoadCurrentUserSet();

                        return true;
                }

                protected override sealed bool StopConnectCore()
                {
                        var errorCode = CloseDevice();
                        if (errorCode != ErrorCode.MV_OK)
                        {
                                return false;
                        }

                        errorCode = DestroyHandle();
                        if (errorCode != ErrorCode.MV_OK)
                        {
                                return false;
                        }

                        return base.StopConnectCore();
                }

                public bool IsAccessible()
                {
                        return IsDeviceAccessible();
                }

                protected override sealed bool StartDispatchCore()
                {
                        if (!base.StartDispatchCore())
                        {
                                return false;
                        }

                        var errorCode = StartGrabbing();
                        if (errorCode != ErrorCode.MV_OK)
                        {
                                return false;
                        }
                        return true;
                }

                protected override sealed bool StopDispatchCore()
                {
                        StopGrabbing();

                        return base.StopDispatchCore();
                }

                protected override sealed ValueResult<Bitmap> CaptureCore()
                {
                        if (ConnectState != ConnectState.Connected
                                || DispatchState != DispatchState.Established)
                        {
                                return ValueResult<Bitmap>.Failed;
                        }

                        var bitmap = Pool.WriteLock();

                        ErrorCode error = GetOneFrame(bitmap);

                        if (error != ErrorCode.MV_OK)
                        {
                                Pool.WriteUnlock(bitmap);
                                return ValueResult<Bitmap>.Failed;
                        }

                        Pool.WriteUnlock(bitmap);

                        //BitmapStorager.Save(bitmap, DateTime.Now.ToChineseLongFileName() + ".bmp");

                        bitmap.TimeStamps["CaptureTime"] = DateTime.Now;

                        var result = new ValueResult<Bitmap>(bitmap);

                        OnCaptureSuccessed(new ValueEventArgs<Bitmap>(bitmap));

                        return result;
                }

                #endregion 方法

                #region 扩展API

                private bool IsDeviceAccessible()
                {
                        Debug.Assert(_handle == IntPtr.Zero);

                        var isAccessible = OfficialApi.IsDeviceAccessible(_handle, ref _deviceInformation, AccessMode.独占权限);

                        this.InfoSuccessWithDescription(isAccessible);

                        return isAccessible;
                }

                private ErrorCode CreateHandle()
                {
                        Debug.Assert(_handle == IntPtr.Zero);

                        var errorCode = OfficialApi.CreateHandle(ref _handle, ref _deviceInformation);
                        if (errorCode != ErrorCode.MV_OK)
                        {
                                this.ErrorFailWithReason(errorCode);
                        }
                        else
                        {
                                Debug.Assert(_handle != IntPtr.Zero);

                                this.InfoSuccess();
                        }
                        return errorCode;
                }

                private ErrorCode DestroyHandle()
                {
                        Debug.Assert(_handle != IntPtr.Zero);

                        var errorCode = OfficialApi.DestroyHandle(_handle);
                        if (errorCode != ErrorCode.MV_OK)
                        {
                                this.ErrorFailWithReason(errorCode);
                        }
                        else
                        {
                                this.InfoSuccess();
                        }

                        _handle = IntPtr.Zero;

                        return errorCode;
                }

                private ErrorCode OpenDevice()
                {
                        Debug.Assert(_handle != IntPtr.Zero);

                        var errorCode = OfficialApi.OpenDevice(_handle, AccessMode.独占权限);
                        if (errorCode != ErrorCode.MV_OK)
                        {
                                this.ErrorFailWithReason(errorCode);
                        }
                        else
                        {
                                this.InfoSuccess();
                        }
                        return errorCode;
                }

                private ErrorCode CloseDevice()
                {
                        Debug.Assert(_handle != IntPtr.Zero);

                        var errorCode = OfficialApi.CloseDevice(_handle);
                        if (errorCode != ErrorCode.MV_OK)
                        {
                                this.ErrorFailWithReason(errorCode);
                        }
                        else
                        {
                                this.InfoSuccess();
                        }
                        return errorCode;
                }

                private ErrorCode StartGrabbing()
                {
                        Debug.Assert(_handle != IntPtr.Zero);

                        var errorCode = OfficialApi.StartGrabbing(_handle);
                        if (errorCode != ErrorCode.MV_OK)
                        {
                                this.ErrorFailWithReason(errorCode);
                        }
                        else
                        {
                                this.InfoSuccess();
                        }
                        return errorCode;
                }

                private ErrorCode StopGrabbing()
                {
                        Debug.Assert(_handle != IntPtr.Zero);

                        var errorCode = OfficialApi.StopGrabbing(_handle);
                        if (errorCode != ErrorCode.MV_OK)
                        {
                                this.ErrorFailWithReason(errorCode);
                        }
                        else
                        {
                                this.InfoSuccess();
                        }
                        return errorCode;
                }

                private ErrorCode GetOneFrame(Bitmap bitmap)
                {
                        Debug.Assert(_handle != IntPtr.Zero);

                        var errorCode = OfficialApi.GetOneFrame(_handle, bitmap.Buffer, bitmap.BufferLength,
                                ref _frameOutInformation);

                        switch (errorCode)
                        {
                                case ErrorCode.MV_OK:
                                        return errorCode;

                                case ErrorCode.MV_E_NODATA:
                                        return errorCode;

                                default:
                                        this.ErrorFailWithReason(errorCode);
                                        return errorCode;
                        }
                }

                #region 万能接口

                private ErrorCode SetIntValue(string strValue, uint value)
                {
                        Debug.Assert(_handle != IntPtr.Zero);
                        return OfficialApi.SetIntValue(_handle, strValue, value);
                }

                private ErrorCode SetEnumValue(CommondType commond, uint value)
                {
                        Debug.Assert(_handle != IntPtr.Zero);
                        return OfficialApi.SetEnumValue(_handle, commond.ToString(), value);
                }

                private ErrorCode SetCommandValue(CommondType commond)
                {
                        Debug.Assert(_handle != IntPtr.Zero);
                        return OfficialApi.SetCommandValue(_handle, commond.ToString());
                }

                #endregion 万能接口

                #region UserSet相关

                private ErrorCode SetDefaultUserSet(UserSet userSet)
                {
                        var errorCode = SetEnumValue(CommondType.UserSetDefault, (uint)userSet);
                        if (errorCode != ErrorCode.MV_OK)
                        {
                                this.ErrorFailWithReason(errorCode);
                        }
                        else
                        {
                                this.InfoSuccess();
                        }
                        return errorCode;
                }

                private ErrorCode SetCurrentUserSet(UserSet userSet)
                {
                        var errorCode = SetEnumValue(CommondType.UserSetSelecter, (uint)userSet);
                        if (errorCode != ErrorCode.MV_OK)
                        {
                                this.ErrorFailWithReason(errorCode);
                        }
                        else
                        {
                                this.InfoSuccess();
                        }
                        return errorCode;
                }

                private ErrorCode LoadCurrentUserSet()
                {
                        var errorCode = SetCommandValue(CommondType.UserSetLoad);
                        if (errorCode != ErrorCode.MV_OK)
                        {
                                this.ErrorFailWithReason(errorCode);
                        }
                        else
                        {
                                this.InfoSuccess();
                        }
                        return errorCode;
                }

                #endregion UserSet相关

                #region GIGE独有接口

                private ErrorCode AdjustSCPSPacketSize()
                {
                        IntValue packetSize = new IntValue();

                        var errorCode = GetGevSCPSPacketSize(ref packetSize);
                        if (errorCode != ErrorCode.MV_OK)
                        {
                                return errorCode;
                        }

                        errorCode = SetGevSCPSPacketSize((uint)StreamChannelPacketSize);
                        if (errorCode != ErrorCode.MV_OK)
                        {
                                return errorCode;
                        }

                        this.InfoSuccess();

                        return errorCode;
                }

                private ErrorCode GetGevSCPSPacketSize(ref IntValue value)
                {
                        Debug.Assert(_handle != IntPtr.Zero);

                        var errorCode = OfficialApi.GetGevSCPSPacketSize(_handle, ref value);
                        if (errorCode != ErrorCode.MV_OK)
                        {
                                this.ErrorFailWithReason(errorCode);
                        }
                        else
                        {
                                this.InfoSuccessWithDescription(value);
                        }
                        return errorCode;
                }

                private ErrorCode SetGevSCPSPacketSize(uint value = 8164)
                {
                        Debug.Assert(_handle != IntPtr.Zero);

                        var errorCode = OfficialApi.SetGevSCPSPacketSize(_handle, value);
                        if (errorCode != ErrorCode.MV_OK)
                        {
                                this.ErrorFailWithReason(errorCode);
                        }
                        else
                        {
                                this.InfoSuccess();
                        }
                        return errorCode;
                }

                #endregion GIGE独有接口

                #endregion 扩展API
        }
}