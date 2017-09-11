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
namespace Nutshell.Automation.DaHeng.Sdk
{
        /// <summary>
        /// 标识视频信号源路的类型
        /// </summary>
        public enum VideoSourceType
	{
                /// <summary>
                /// 复合视频信号
                /// </summary>
                CompositeVideo = 0,

                /// <summary>
                /// S端子视频信号
                /// </summary>
                SVideo = 1,

                /// <summary>
                /// YPbPr分量视频信号
                /// </summary>
                ComponentVideo = 2
	}
}