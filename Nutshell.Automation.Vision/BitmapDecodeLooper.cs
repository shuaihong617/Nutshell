// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2017-02-18
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2017-02-18
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System;
using System.Threading;
using Nutshell.Automation.Models;
using Nutshell.Components;

namespace Nutshell.Automation.Vision
{
	/// <summary>
	/// 守护工作者
	/// </summary>
	public class BitmapDecodeLooper : Looper,IDecodeLooper
	{
		public BitmapDecodeLooper(string id) 
			: base( id)
		{
		}

		public BitmapDecodeLooper(string id, int interval) 
			: base( id, interval)
		{
		}

		public BitmapDecodeLooper(string id, ThreadPriority priority, int interval) 
			: base( id, priority, interval)
		{
		}

		protected sealed override IResult RepeatWork()
		{
			return Decode();
		}

		/// <summary>
		/// 在线测试
		/// </summary>
		/// <returns>设备在线返回True，否则返回False</returns>
		protected virtual IResult Decode()
		{
			if (_decodeBitmap == null)
			{
				return;
			}

			throw new NotImplementedException();
			//
			//if (!IsEnable || !IsStarted)
			//                     {
			//                             Camera.Buffers.ReadUnlock(_decodeBitmap);
			//                             _decodeBitmap = null;
			//                             return;
			//                     }                        

			//Bitmap target = Buffers.WriteLock();

			//_decodeBitmap.TranslateTo(target);

			//var sourceStamp = _decodeBitmap.TimeStampChain as CaptureTimeStampChain;
			//var targetStamp = target.TimeStampChain as DecodeTimeStampChain;
			//if (sourceStamp != null && targetStamp != null)
			//{
			//        targetStamp.CaptureTime = sourceStamp.CaptureTime;
			//        targetStamp.DecodeTime = DateTime.Now;
			//}

			//Buffers.WriteUnlock(target);

			//Capturer.Buffers.ReadUnlock(_decodeBitmap);

			//OnDecodeFinished(new ValueEventArgs<Bitmap>(target));

			//_decodeBitmap = null;
		}

		/// <summary>
		///         从数据模型加载数据
		/// </summary>
		/// <param name="model">读取数据的源数据模型，该数据模型不能为null</param>
		public void Load(IDecodeLooperModel model)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>
		///         保存数据到数据模型
		/// </summary>
		/// <param name="model">写入数据的目的数据模型，该数据模型不能为null</param>
		public void Save(IDecodeLooperModel model)
		{
			throw new System.NotImplementedException();
		}
	}
}
