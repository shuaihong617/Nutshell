// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2016-10-28
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2016-12-23
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Nutshell.Aspects.Locations.Contracts;

namespace Nutshell
{
	/// <summary>
	/// 时间戳链，用于跟踪其附着的对象状态变更的时间
	/// </summary>
	public class TimeStampChain<T>
        {
		/// <summary>
		/// 获取时间戳的只读字典集合
		/// </summary>
		/// <value>时间戳的只读字典集合</value>
		public ReadOnlyDictionary<T, DateTime> TimeStamps { get; private set; }

		#region 字段

		/// <summary>
		/// 时间戳字典集合
		/// </summary>
		private readonly Dictionary<T, DateTime> _timeStamps = new Dictionary<T, DateTime>();

		/// <summary>
		/// 线程同步标识
		/// </summary>
		private readonly object _syncFlag = new object();

		#endregion


		#region 方法

		/// <summary>
		/// 创建指定名称的时间戳
		/// </summary>
		/// <param name="key">待生成的时间戳的标识或说明，在时间戳集合中必须唯一，而且不能为null</param>
		public void CreateStamp([MustNotEqualNull] T key)
		{
			lock (_syncFlag)
			{
				_timeStamps.Add(key, DateTime.Now);
				UpdateTimeStamps();
			}
		}

		/// <summary>
		/// 清空所有时间戳
		/// </summary>
		public void Clear()
		{
			lock (_syncFlag)
			{
				_timeStamps.Clear();
				UpdateTimeStamps();
			}
		}

		/// <summary>
		/// 当时间戳增减时更新只读
		/// </summary>
		private void UpdateTimeStamps()
		{
			TimeStamps = new ReadOnlyDictionary<T, DateTime>(_timeStamps);
		}

		#endregion


	}
}
