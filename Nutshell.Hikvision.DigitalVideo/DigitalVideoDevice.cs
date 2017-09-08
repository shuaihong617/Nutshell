// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2014-08-28
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2014-10-15
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 武汉九鼎科达科技有限公司. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************


using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using Nutshell.Automation;
using Nutshell.Automation.Vision;
using Nutshell.Components;
using Nutshell.Data.Models;
using Nutshell.Drawing.Imaging;
using Nutshell.Extensions;
using Nutshell.Hikvision.DigitalVideo.Models;
using Nutshell.Hikvision.DigitalVideo.SDK;

namespace Nutshell.Hikvision.DigitalVideo
{
        /// <summary>
        ///         海康威视摄像机
        /// </summary>
        public class DigitalVideoDevice : NetworkMediaCaptureDevice
        {
		public DigitalVideoDevice(string id, string ipAddress)
                        : base(id, 1920, 1080, PixelFormat.Rgba32, ipAddress)
                {
                        //X64
                        //_clientInfo = new HikvisionSDK.NET_DVR_CLIENTINFO
                        //{
                        //        lChannel = 1,
                        //        lLinkMode = 0x0000,
                        //        sMultiCastIP = "",
                        //        hPlayWnd = IntPtr.Zero
                        //};

                        _previewInfo = new NetDvrPreviewInfo
                        {
                                hPlayWnd = IntPtr.Zero,
                                lChannel = 1,
                                dwStreamType = 0,
                                dwLinkMode = 1,
                                bBlocked = false,
                                byPreviewMode = 0
                        };

                        _realDataCallBack = RealDataSnapCallBack;
                }

                #region 常量

                

                /// <summary>
                ///         无效播放通道
                /// </summary>
                public const int InvalidPlayPort = -1;

                /// <summary>
                ///         无效播放句柄
                /// </summary>
                public const int InvalidRealHandle = -1;

                /// <summary>
                ///         无效用户标识
                /// </summary>
                public const int InvalidUserId = -1;

                #endregion

                #region 字段

                /// <summary>
                ///         播放通道
                /// </summary>
                private int _playPort;

                /// <summary>
                ///         播放句柄
                /// </summary>
                private int _realHandle;

                /// <summary>
                ///         登陆用户标识
                /// </summary>
                private int _userId;

                /// <summary>
                ///         用户指针
                /// </summary>
                private readonly IntPtr _userPtr = new IntPtr();

                //private HikvisionSDK.NET_DVR_CLIENTINFO _clientInfo;
                /// <summary>
                ///         客户端信息结构体, X64平台使用
                /// </summary>
                /// <summary>
                ///         设备信息结构体, X86平台使用
                /// </summary>
                private OfficalAPI.NET_DVR_DEVICEINFO_V30 _deviceInfo;

                /// <summary>
                ///         预览信息结构体
                /// </summary>
                private NetDvrPreviewInfo _previewInfo;

                /// <summary>
                ///         图像缓冲区指针
                /// </summary>
                private IntPtr _capturePtr = IntPtr.Zero;

                /// <summary>
                ///         预备采集图像字节计数
                /// </summary>
                private  int _prepareCaptureBytesCount;

                /// <summary>
                ///         像素缓冲区指针
                /// </summary>
                private  IntPtr _bitmapPtr;

                /// <summary>
                /// 实际采集图像字节计数
                /// </summary>
                private uint _actuallycaptureBytesCount;


                /// <summary>
                ///         实时数据回调函数
                /// </summary>
                private readonly OfficalAPI.REALDATACALLBACK _realDataCallBack;

                private readonly Looper _captureLooper;

	        

	        #endregion

                public DigitalVideoAuthorization Authorization { get; private set; } = new DigitalVideoAuthorization();

                #region 方法

                public override void Load(IIdentityModel model)
                {
                        base.Load(model);

                        var subModel = model as DigitalVideoDeviceModel;
                        Trace.Assert(subModel != null);

                        Authorization.Load(subModel.DigitalVideoAuthorizationModel);
                }

                protected override sealed bool StartConnectCore()
                {
                        for (int i = 0; i < 5; i++)
                        {
                                _userId = OfficalAPI.NET_DVR_Login_V30(IPAddress.ToString(), 
                                        Authorization.PortNumber,
                                        Authorization.UserName,
                                        Authorization.Password,
                                        ref _deviceInfo);
                                if (_userId != InvalidUserId)
                                {
                                        this.Info("NET_DVR_Login_V30调用成功, 用户标识："+ _userId);
                                        return true;
                                }
                        }


                        WarnDvrSdkFailWithReason("NET_DVR_Login_V30");
                        return true;
                }

                protected override sealed bool StopConnectCore()
                {
                        if (_userId < 0)
                        {
                                return true;
                        }

                        if (!OfficalAPI.NET_DVR_Logout_V30(_userId))
                        {
                                WarnDvrSdkFailWithReason("NET_DVR_Logout_V30");
                        }
                        return true;
                }

                protected override bool  StartDispatchCore()
                {
                        //CreateBitmapPool();

                        if (_capturePtr == IntPtr.Zero)
                        {
                                int bitmapBytesCount = Width * Height * PixelFormat.GetBytes();

                                _prepareCaptureBytesCount = bitmapBytesCount + MicrosoftBitmapExtensions.FileHeaderTotalBytes +
						     MicrosoftBitmapExtensions.InfoHeaderTotalBytes;

                                _capturePtr = Marshal.AllocHGlobal(_prepareCaptureBytesCount);

                                unsafe
                                {
                                        var tempPtr = ((byte*)_capturePtr.ToPointer()) + +MicrosoftBitmapExtensions.FileHeaderTotalBytes +
					     MicrosoftBitmapExtensions.InfoHeaderTotalBytes;
                                        _bitmapPtr = new IntPtr(tempPtr);
                                }
                                

                                //_bitmapPtr = _capturePtr + +BitmapExtensions.FileHeaderTotalBytes +
                                //             BitmapExtensions.InfoHeaderTotalBytes;
                        }
                        

                        //X64
                        //RealHandle = HikvisionSDK.NET_DVR_RealPlay_V40(UserId, ref _clientInfo, _realDataSnapCallBack,
                        //        UserPtr, 0);

                        //X86
                        _realHandle = OfficalAPI.NET_DVR_RealPlay_V40(_userId, ref _previewInfo,
                                _realDataCallBack,
                                _userPtr);

                        if (_realHandle == InvalidRealHandle)
                        {
                                WarnDvrSdkFailWithReason("NET_DVR_RealPlay_V40");
                                return false;
                        }
                        this.InfoSuccess("NET_DVR_RealPlay_V40");

                        OfficalAPI.NET_DVR_SetPlayerBufNumber(_realHandle, 3);

                        return _captureLooper.Start();
                }

                protected override bool StopDispatchCore()
                {
                        _captureLooper.Stop();

                        if (_realHandle < 0)
                        {
                                return true;
                        }

                        //停止视频预览
                        if (!OfficalAPI.NET_DVR_StopRealPlay(_realHandle))
                        {
                                WarnDvrSdkFailWithReason("NET_DVR_StopRealPlay");
                                return false;
                        }
                        this.InfoSuccess("NET_DVR_StopRealPlay");

                        _realHandle = InvalidRealHandle;

                        if (_playPort == InvalidPlayPort)
                        {
                                return true;
                        }

                        // 停止解码
                        if (!OfficalAPI.PlayM4_Stop(_playPort))
                        {
                                WarnPlaySdkFailWithReason("PlayM4_Stop");
                                return false;
                        }
                        this.InfoSuccess("PlayM4_Stop");


                        //关闭流, 回收源数据缓冲
                        if (!OfficalAPI.PlayM4_CloseStream(_playPort))
                        {
                                WarnPlaySdkFailWithReason("PlayM4_CloseStream");
                                return false;
                        }
                        this.InfoSuccess("PlayM4_CloseStream");

                        //释放播放库端口号
                        if (!OfficalAPI.PlayM4_FreePort(_playPort))
                        {
                                WarnPlaySdkFailWithReason("PlayM4_FreePort");
                                return false;
                        }
                        this.InfoSuccess("PlayM4_FreePort");

                        _playPort = InvalidPlayPort;

                        return true;
                }

                protected override ValueResult<Bitmap> CaptureCore()
                {
                        if (!IsEnable 
				|| ConnectState != ConnectState.Connected 
				|| DispatchState != DispatchState.Established)
                        {
                                Trace.WriteLine("!IsEnable || !IsStarted || !IsConnected || !IsStartCaptured Failed");
                                return null;
                        }

	                return null;

                        //var bitmap = BitmapPool.EnterWrite();
                        //if (bitmap == null)
                        //{
                        //        Trace.WriteLine("BitmapPool.Instance.EnterWrite Failed");
                        //        return null;
                        //}

                        //bool result = OfficalAPI.PlayM4_GetBMP(_playPort, _capturePtr,
                        //        (uint) _prepareCaptureBytesCount,
                        //        ref _actuallycaptureBytesCount);

                        //if (!result || _actuallycaptureBytesCount == 0)
                        //{
                        //        WarnPlaySdkFailWithReason("PlayM4_GetBMP");

                        //        BitmapPool.ExitWrite(bitmap);
                        //        return bitmap;
                        //}


                        //bitmap.CopyFromVerticalMirror(_bitmapPtr, Width, Height, Region);

                        //BitmapPool.ExitWrite(bitmap);
                        //return bitmap;
                }

                private void RealDataSnapCallBack(Int32 lRealHandle, uint dwDataType, ref byte pBuffer,
                        uint dwBufSize,
                        IntPtr pUser)
                {
                        if (ConnectState != ConnectState.Connected || DispatchState != DispatchState.Established)
                        {
                                return;
                        }

                        bool isSuccess;
                        switch (dwDataType)
                        {
                                case OfficalAPI.NET_DVR_SYSHEAD: // 系统头
                                        isSuccess = OfficalAPI.PlayM4_GetPort(ref _playPort);
                                        if (isSuccess)
                                        {
                                                this.InfoSuccessWithDescription("获取通道", "通道编号" + _playPort);
                                        }
                                        else
                                        {
                                                WarnPlaySdkFailWithReason("获取通道");
                                                //Shutdown();
                                                break;
                                        }

                                        if (dwBufSize > 0)
                                        {
                                                isSuccess = OfficalAPI.PlayM4_SetStreamOpenMode(_playPort,
                                                        OfficalAPI.STREAME_REALTIME);
                                                if (isSuccess)
                                                {
                                                        this.InfoSuccess("设置码流开启模式");
                                                }
                                                else
                                                {
                                                        WarnPlaySdkFailWithReason("设置码流开启模式");
                                                        //Stop();
                                                        break;
                                                }


                                                isSuccess = OfficalAPI.PlayM4_OpenStream(_playPort,
                                                        ref pBuffer,
                                                        dwBufSize,
                                                        (uint) (Width*Height*6));
                                                if (isSuccess)
                                                {
                                                        this.InfoSuccess("开启码流");
                                                }
                                                else
                                                {
                                                        WarnPlaySdkFailWithReason("开启码流失败");

                                                        _playPort = InvalidPlayPort;
                                                        //Stop();
                                                        break;
                                                }

                                                //if (!HikvisionSDK.PlayM4_SetDisplayBuf(_playPort, 5))
                                                //{
                                                //        WarnPlaySdkFailWithReason("设置实时播放缓冲区失败");
                                                //}


                                                //if (!HikvisionSDK.PlayM4_SetOverlayMode(_playPort, 0, 0 /* COLORREF(0)*/))
                                                //{
                                                //        WarnPlaySdkFailWithReason("设置采集模式失败");
                                                //}


                                                isSuccess = OfficalAPI.PlayM4_Play(_playPort, IntPtr.Zero);
                                                if (isSuccess)
                                                {
                                                        this.InfoSuccess("开启解码");
                                                }
                                                else
                                                {
                                                        WarnPlaySdkFailWithReason("开启解码");
                                                        _playPort = -1;

                                                        //Stop();
                                                }
                                        }
                                        break;

                                case OfficalAPI.NET_DVR_STREAMDATA: // video stream data
                                        if (dwBufSize == 0 || _playPort == -1)
                                        {
                                                return;
                                        }

                                        isSuccess = OfficalAPI.PlayM4_InputData(_playPort, ref pBuffer, dwBufSize);
                                        if (!isSuccess)
                                        {
                                                uint errorCode = OfficalAPI.PlayM4_GetLastError(_playPort);
                                                this.ErrorFailWithReason("输入码流", "错误代码" + errorCode);

                                                switch (errorCode)
                                                {
                                                        case OfficalAPI.PLAYM4_BUF_OVER:
                                                                this.Warn("播放缓冲区满");
                                                                for (;;)
                                                                {
                                                                        Thread.Sleep(5);
                                                                        errorCode =
                                                                                OfficalAPI.PlayM4_GetLastError(
                                                                                        _playPort);

                                                                        if (errorCode == OfficalAPI.PLAYM4_NOERROR)
                                                                        {
                                                                                this.Warn("播放缓冲区正常");
                                                                                break;
                                                                        }
                                                                }
                                                                break;

                                                        default:
                                                                //Stop();
                                                                break;
                                                }
                                        }
                                        break;
                        }
                }

                #endregion

                #region 事件

                #endregion

                private void WarnDvrSdkFailWithReason(string operation)
                {
                        this.WarnFail(operation + OfficalAPI.NET_DVR_GetLastError());
                }

                private void WarnPlaySdkFailWithReason(string operation)
                {
                        this.WarnFail(operation + OfficalAPI.PlayM4_GetLastError(_playPort));
                }
        }
}