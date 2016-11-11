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

using System.Collections.ObjectModel;

namespace Nutshell.Management
{
        /// <summary>
        /// CPU
        /// </summary>
        public class NSMemroy
        {
                private NSMemroy()
                {
                        
                }

                /// <summary>
                /// 型号
                /// </summary>
                public uint TotalSize { get; private set; }

                /// <summary>
                /// 使用率
                /// </summary>
                public float UsedPercentage { get; private set; }

                public void StartMonitoring()
                {
                        


                }

                public void StopMonitoring()
                {
                        
                }
        }
}
