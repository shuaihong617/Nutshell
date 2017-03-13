// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-01-05
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-01-05
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using Nutshell.Components.Models;
using Nutshell.Drawing.Imaging;

namespace Nutshell.Automation.Vision.Models
{
        /// <summary>
        ///         摄像机数据模型
        /// </summary>
        public interface ICameraModel : IComponentModel
        {
                /// <summary>
                ///         像素格式
                /// </summary>
                int Width { get; set; }

                /// <summary>
                ///         像素格式
                /// </summary>
                int Height { get; set; }

                /// <summary>
                ///         像素格式
                /// </summary>
                PixelFormat PixelFormat { get; set; }
        }
}