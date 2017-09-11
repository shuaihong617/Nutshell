// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2016-10-28
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2016-10-07
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System;

namespace Nutshell
{
        /// <summary>
        /// 方向枚举
        /// </summary>
        [Flags]
        public enum Directions
        {
                /// <summary>
                /// 未知
                /// </summary>
                未知 = 0,

                /// <summary>
                /// 上
                /// </summary>
                从下到上 = 1,

                /// <summary>
                /// 下
                /// </summary>
                从上到下 = 2,

                /// <summary>
                /// 左
                /// </summary>
                从右到左 = 4,

                /// <summary>
                /// 右
                /// </summary>
                从左到右 = 8,

                /// <summary>
                /// 水平
                /// </summary>
                水平 = 3,

                /// <summary>
                /// 垂直
                /// </summary>
                垂直 = 12
        }
}