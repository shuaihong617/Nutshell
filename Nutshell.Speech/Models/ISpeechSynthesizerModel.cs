// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-09-09
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-09-09
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using Nutshell.Data.Models;

namespace Nutshell.Speech.Models
{
        /// <summary>
        ///         调度者数据模型接口
        /// </summary>
        public interface ISpeechSynthesizerModel : IDataModel
        {
                /// <summary>
                ///         是否启用
                /// </summary>
                Language Language { get; set; }
        }
}