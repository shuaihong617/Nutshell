// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2016-07-17
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2016-07-31
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System;

namespace Nutshell.Components
{
        /// <summary>
        /// 运行环境信息
        /// </summary>
        public class RuntimeInformation:IRuntimeInformation
        {
                public RuntimeInformation(Version runtimeVersion)
                {
                        RuntimeVersion = runtimeVersion;
                }


                /// <summary>
                /// 获取运行时版本
                /// </summary>
                /// <value>运行时版本</value>
                public Version RuntimeVersion { get;private set; }
        }
}
