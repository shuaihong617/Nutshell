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

using System.Threading;
using Nutshell.Automation.Models;
using Nutshell.Components;

namespace Nutshell.Automation
{
	/// <summary>
	/// 守护工作者
	/// </summary>
	public class DecodeLooper<T> : Looper,IDecodeLooper
	{
		public DecodeLooper(IIdentityObject parent, string id) 
			: base(parent, id)
		{
		}

		public DecodeLooper(IIdentityObject parent, string id, int interval) 
			: base(parent, id, interval)
		{
		}

		public DecodeLooper(IIdentityObject parent, string id, ThreadPriority priority, int interval) 
			: base(parent, id, priority, interval)
		{
		}

		protected sealed override IResult RepeatWork()
		{
			return IsSurvive();
		}

		/// <summary>
		/// 在线测试
		/// </summary>
		/// <returns>设备在线返回True，否则返回False</returns>
		protected virtual IResult IsSurvive()
		{
			return Result.Successed;
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
