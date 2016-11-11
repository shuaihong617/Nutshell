// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-09-05
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-09-05
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

namespace Nutshell.Components
{
        /// <summary>
        ///         工作者接口
        /// </summary>
        public interface IWorker
        {
                /// <summary>
                ///         是否允许运行
                /// </summary>
                bool IsEnable { get; }


                /// <summary>
                ///         是否正在运行
                /// </summary>
                bool IsStarted { get; }


                /// <summary>
                ///         启动
                /// </summary>
                bool Start();

                /// <summary>
                ///         停止
                /// </summary>
                bool Stop();
        }
}