// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2016-07-09
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2016-07-09
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

namespace Nutshell.Threading
{
        /// <summary>
        ///         缓冲池
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public interface IReaderWriterObject
        {
                bool EnterRead();

                /// <summary>
                ///         Exits the read.
                /// </summary>
                /// <param name="t">The t.</param>
                void ExitRead();

                /// <summary>
                ///         Enters the write.
                /// </summary>
                /// <returns>T.</returns>
                bool EnterWrite();

                /// <summary>
                ///         Exits the write.
                /// </summary>
                /// <param name="t">The t.</param>
                void ExitWrite();
        }
}
