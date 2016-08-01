// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2016-07-17
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2016-07-17
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

namespace Nutshell.Collections
{
        /// <summary>
        /// 缓冲区接口
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public interface  IBuffer<T>
        {
                /// <summary>
                /// 将对象添加到缓冲区中。
                /// </summary>
                /// <param name="t">要添加的对象，该对象不可为null。</param>
                void Enqueue(T t);

                /// <summary>
                /// 从缓冲区中移除并返回对象。
                /// </summary>
                /// <returns>移除并返回的对象</returns>
                T Dequeue();

                /// <summary>
                /// 清空缓冲区。
                /// </summary>
                void Clear();
        }
}
