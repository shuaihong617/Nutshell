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

using System.ComponentModel;

namespace Nutshell.Hikvision.MachineVision.SDK
{
        /// <summary>
        ///         像素格式扩展方法
        /// </summary>
        public static class PixelTypeExtensions
        {
                /// <summary>
                ///         获取像素格式的位宽
                /// </summary>
                /// <param name="format">像素格式</param>
                /// <returns>位宽</returns>
                /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">不支持的像素格式</exception>
                public static int GetBits(this PixelType pixelType)
                {
                        switch (pixelType)
                        {
                                case PixelType.Mono8:
                                        return 8;

                                case PixelType.RGB8Packed:
                                        return 24;

                                default:
                                        throw new InvalidEnumArgumentException("不支持的像素格式");
                        }
                }
        }
}