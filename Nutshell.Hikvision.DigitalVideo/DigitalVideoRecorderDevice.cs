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
        ///         海康威视硬盘数字录像机
        /// </summary>
        public class DigitalVideoRecorderDevice : DigitalVideoDevice
        {
	        public DigitalVideoRecorderDevice()
		        : this(String.Empty, "192.168.1.1")
	        {
		        
	        }

		public DigitalVideoRecorderDevice(string id, string ipAddress)
                        : base(id, ipAddress)
                {
                        

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

                #region 方法

                public override void Load(IIdentityModel model)
                {
                        base.Load(model);

                        var cameraModel = model as DigitalVideoDeviceModel;
                        Trace.Assert(cameraModel != null);
                }

	        public void Login()
	        {
			for (int i = 0; i < 5; i++)
			{
				_userId = OfficalAPI.NET_DVR_Login_V30(IPAddress.ToString(), 
					Authorization.PortNumber, 
					Authorization.UserName,
					Authorization.Password,
					ref _deviceInfo);

                                Trace.WriteLine(_deviceInfo.byIPChanNum);
				if (_userId != InvalidUserId)
				{
					this.Info("NET_DVR_Login_V30调用成功, 用户标识：" + _userId);
                                        break;
				}
			}
		}

	        public void Logout()
	        {
			Debug.Assert(_userId >=0);
			if (!OfficalAPI.NET_DVR_Logout_V30(_userId))
			{
				WarnDvrSdkFailWithReason("NET_DVR_Logout_V30");
			}
		}

	        private int _playHandle;

	        public void StartPlayBack(DateTime beginTime, DateTime endTime, IntPtr hwnd)
	        {
		        NetDvrTime begin = new NetDvrTime
			{
			        Year = (uint) beginTime.Year,
			        Month = (uint) beginTime.Month,
			        Day = (uint) beginTime.Day,
			        Hour = (uint) beginTime.Hour,
			        Minute = (uint) beginTime.Minute
		        };

			NetDvrTime end = new NetDvrTime
			{
				Year = (uint)endTime.Year,
				Month = (uint)endTime.Month,
				Day = (uint)endTime.Day,
				Hour = (uint)endTime.Hour,
				Minute = (uint)endTime.Minute
			};


			//按时间播放
			NetDvrVodPara vod = new NetDvrVodPara();
			vod.Size = (uint)Marshal.SizeOf(vod);
			//vod.struIDInfo.dwSize = Marshal.SizeOf(NET_DVR_STREAM_INFO);
			vod.struIDInfo.Channel = 33;//按录像机网口32+i计算
			vod.HWnd = hwnd;
			vod.BeginTime = begin;
			vod.EndTime = end;


			_playHandle = OfficalAPI.NET_DVR_PlayBackByTime(_userId, 33, ref begin, ref end, hwnd);
			//playHandle = OfficalAPI.NET_DVR_PlayBackByTime_V40(_userId, ref vod);

			Trace.WriteLine($"playHandle   {_playHandle}");
			var error = OfficalAPI.NET_DVR_GetLastError();
			Trace.WriteLine($"error   {error}");


		}

		private int _fileHandle;

		public void StartDownloadAsync(DateTime beginTime, DateTime endTime, string fileName)
                {
                        NetDvrTime begin = new NetDvrTime
                        {
                                Year = (uint) beginTime.Year,
                                Month = (uint) beginTime.Month,
                                Day = (uint) beginTime.Day,
                                Hour = (uint) beginTime.Hour,
                                Minute = (uint) beginTime.Minute
                        };

                        NetDvrTime end = new NetDvrTime
                        {
                                Year = (uint) endTime.Year,
                                Month = (uint) endTime.Month,
                                Day = (uint) endTime.Day,
                                Hour = (uint) endTime.Hour,
                                Minute = (uint) endTime.Minute
                        };

                        NetDvrPlayCondition condition = new NetDvrPlayCondition();
                        condition.Channel = 33;
                        condition.StartTime = begin;
                        condition.StopTime = end;

                        _fileHandle = OfficalAPI.NET_DVR_GetFileByTime_V40(_userId, fileName, ref condition);

                        PlayBackControl(NetDvrPlayBackControlCode.NET_DVR_PLAYSTART);
		}

	        public int GetDownloadPercent()
	        {
		        if (_fileHandle == -1)
		        {
			        return -1;
		        }
			return OfficalAPI.NET_DVR_GetDownloadPos(_fileHandle);
		}

		public void StopDownloadAsync()
		{
			if (_fileHandle > -1)
			{
				OfficalAPI.NET_DVR_StopGetFile(_fileHandle);
			}
		}

		public void PlayBackControl(NetDvrPlayBackControlCode controlCode)
	        {
			uint outValue = 0;
			OfficalAPI.NET_DVR_PlayBackControl(_playHandle, controlCode, 0, ref outValue);
	        }

	        public void StartPlay()
	        {
		        PlayBackControl(NetDvrPlayBackControlCode.NET_DVR_PLAYSTART);
	        }



	        public void StopPlayBack()
	        {
			Debug.Assert(_playHandle>-1);
		        OfficalAPI.NET_DVR_StopPlayBack(_playHandle);
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