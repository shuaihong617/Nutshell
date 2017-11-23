// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2017-11-22
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2017-11-22
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************
namespace Nutshell.Hikvision.SmartVision.Sdk
{
        /// <summary>
        /// 场校验模式
        /// </summary>
        public enum FieldCorretMode
        {
                /// <summary>
                /// 暗场校验
                /// </summary>
                Dark = 0,       
                     
                /// <summary>
                /// 明场校验
                /// </summary>
                Bright = 1,     
                      
                /// <summary>
                /// 无效校验
                /// </summary>
                Invailed = 2,           
        }
}