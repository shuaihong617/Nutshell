// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2014-12-15
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2014-12-12
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System;

namespace Nutshell.Communication
{
        /// <summary>
        ///         以太网端口扩展
        /// </summary>
        public static class EthernetPortNumberExtensions
	{
                /// <summary>
                ///         最大可用端口号
                /// </summary>
                public const int MaximumAvailablePortNumber = UInt16.MaxValue;

                /// <summary>
                ///         最小可用端口号，1024以下端口号一般被系统占用分配
                /// </summary>
                public const int MinimumAvailablePortNumber = 1;

		/// <summary>
		///         最小推荐端口号，1024以下端口号一般被系统占用分配
		/// </summary>
		public const int MinimumRecommendPortNumber = 1024;

	}
}