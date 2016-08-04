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
        ///         共享锁对象接口
        /// </summary>
        public interface IReadWriteObject
        {
                /// <summary>
                /// 读锁定
                /// </summary>
                /// <returns>锁定操作是否成功</returns>
                bool ReadLock();

                /// <summary>
                /// 读解锁
                /// </summary>
                void ReadUnlock();

                /// <summary>
                /// 写锁定
                /// </summary>
                /// <returns>锁定操作是否成功</returns>
                bool WriteLock();

                /// <summary>
                /// 写解锁
                /// </summary>
                void WriteUnlock();
        }
}
