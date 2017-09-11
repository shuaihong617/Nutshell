// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2017-09-09
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2017-09-09
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************
using System.Runtime.InteropServices;

namespace Nutshell.Automation.DaHeng.Sdk
{
        /// <summary>
        /// 视频源结构体
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct VideoSource
	{
                /// <summary>
                /// 视频源类型
                /// </summary>
                public VideoSourceType Type;

                /// <summary>
                /// 视频源序号
                /// </summary>
                public int Index;
	}
}