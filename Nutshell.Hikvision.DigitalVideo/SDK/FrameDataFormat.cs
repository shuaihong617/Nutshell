// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-07-22
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-07-22
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

namespace Nutshell.Hikvision.DigitalVideo.SDK
{
        /// <summary>
        /// 实时数据帧数据格式枚举
        /// </summary>
        public enum FrameDataFormat
        {
                /// <summary>
                /// The t_ audi o16
                /// </summary>
                T_AUDIO16 = 101,

                /// <summary>
                /// The t_ audi o8
                /// </summary>
                T_AUDIO8 = 100,

                /// <summary>
                /// The t_ uyvy
                /// </summary>
                T_UYVY = 1,

                /// <summary>
                /// The t_ y V12
                /// </summary>
                T_YV12 = 3,

                /// <summary>
                /// The t_ rg B32
                /// </summary>
                T_RGB32 = 7
        }
}
