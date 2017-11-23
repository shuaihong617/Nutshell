// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2017-11-23
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2017-11-23
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************
using System.Runtime.InteropServices;

namespace Nutshell.Hikvision.SmartVision.Sdk
{
        /// <summary>
        /// 2维平面整形点结构体
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct Point2I
        {
                /// <summary>
                /// 横坐标
                /// </summary>
                public int x;

                /// <summary>
                /// 纵坐标
                /// </summary>
                public int y;
        }
}