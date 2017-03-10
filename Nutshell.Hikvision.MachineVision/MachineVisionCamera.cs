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
using System.Net;
using Nutshell.Automation.Vision;
using Nutshell.Data;
using Nutshell.Drawing.Imaging;
using Nutshell.Extensions;
using Nutshell.Hikvision.MachineVision.Models;
using Nutshell.Hikvision.MachineVision.SDK;

namespace Nutshell.Hikvision.MachineVision
{
	/// <summary>
	///         海康威视机器视觉摄像机
	/// </summary>
	public class MachineVisionCamera : NetworkCamera, IStorable<IMachineVisionCameraModel>
	{
		public MachineVisionCamera(string id = "", string ipAddress = "0.0.0.0")
			: base(id, 1280, 960, PixelFormat.Rgb24, ipAddress)
		{
		}

		#region 常量

		#endregion

		#region 字段

		/// <summary>
		///         播放通道
		/// </summary>
		private IntPtr _handle = IntPtr.Zero;

		private DeviceInformation _deviceInformation;

		private FrameOutInformation _frameOutInformation;

		#endregion

		#region 方法

		#region 存储

		/// <summary>
		///         从数据模型加载数据
		/// </summary>
		/// <param name="model">读取数据的源数据模型，该数据模型不能为null</param>
		public void Load(IMachineVisionCameraModel model)
		{
			base.Load(model);
		}

		/// <summary>
		///         保存数据到数据模型
		/// </summary>
		/// <param name="model">写入数据的目的数据模型，该数据模型不能为null</param>
		public void Save(IMachineVisionCameraModel model)
		{
			throw new NotImplementedException();
		}

		#endregion

		protected override sealed Result StartConnectCore()
		{
			var baseResult = base.StartConnectCore();
			if (!baseResult.IsSuccessed)
			{
				return baseResult;
			}

			Debug.Assert(!Equals(IPAddress, IPAddress.Any));

			var installedMachineVisionCamera = MachineVisionRuntime.Instance.InstalledMachineVisionCameras.FirstOrDefault(
				i => Equals(i.IPAddress, IPAddress));

			if (installedMachineVisionCamera == null)
			{
				this.WarnFailWithReason("获取摄像机", "未检测到摄像机");
				return Result.Failed;
			}

			_deviceInformation = installedMachineVisionCamera.DeviceInformation;

			var errorCode = CreateHandle();
			if (errorCode != ErrorCode.MV_OK)
			{
				return Result.Failed;
			}

			//if (!MVOfficialAPI.RegisterExceptionCallBack(_handle, _exceptionCallback, IntPtr.Zero))
			//{
			//	this.WarnFail("RegisterExceptionCallBack", mvError);
			//	return Result.Failed;
			//}


			errorCode = OpenDevice();
			if (errorCode != ErrorCode.MV_OK)
			{
				return Result.Failed;
			}
			return Result.Successed;
		}

		protected override sealed Result StopConnectCore()
		{
			var errorCode = CloseDevice();
			if (errorCode != ErrorCode.MV_OK)
			{
				return Result.Failed;
			}

			errorCode = DestroyHandle();
			if (errorCode != ErrorCode.MV_OK)
			{
				return Result.Failed;
			}

			return base.StopConnectCore();
		}

		public bool IsAccessible()
		{
			return OfficialApi.IsDeviceAccessible(_handle, ref _deviceInformation, AccessMode.独占权限);
		}

		protected override sealed Result StartDispatchCore()
		{
			var baseResult = base.StartDispatchCore();
			if (!baseResult.IsSuccessed)
			{
				return baseResult;
			}

			var errorCode = StartGrabbing();
			if (errorCode != ErrorCode.MV_OK)
			{
				return Result.Failed;
			}
			return Result.Successed;
		}

		protected override sealed Result StopDispatchCore()
		{
			StopGrabbing();

			return base.StopDispatchCore();
		}

		protected override sealed ValueResult<Bitmap> CaptureCore()
		{
			var bitmap = Pool.WriteLock();

			var error = GetOneFrame(bitmap);

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

		#endregion

		#region 私有API

		//              public static extern ErrorCode EnumDevices(DeviceType nTLayerType, ref DeviceInformationCollection deviceInfoCollection);

  //              public static extern bool IsDeviceAccessible(IntPtr handle, ref DeviceInformation pstDevInfo,
  //                      AccessMode accessMode);

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

                //#region 万能接口

                //public static extern ErrorCode SetIntValue(IntPtr handle, string strValue, uint value);

                //public static extern ErrorCode SetEnumValue(IntPtr handle, string strValue, uint value);

                //public static extern ErrorCode SetCommandValue(IntPtr handle, string strValue);

                //#endregion

                //#region GIGE独有接口

                //public static extern ErrorCode GetGevSCPSPacketSize(IntPtr handle, ref IntValue value);

                //public static extern ErrorCode SetGevSCPSPacketSize(IntPtr handle, uint value);

                //#endregion



                #endregion
        }
}