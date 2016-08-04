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

using Nutshell.Collections;

namespace Nutshell.Threading
{
        /// <summary>
        ///         缓冲池
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class MonopolyBuffer<T> : QueueBuffer<T> where T : IdentityObject,IMonopolyObject
        {
                /// <summary>
                ///         初始化<see cref="IdentityObject" />的新实例.
                /// </summary>
                /// <param name="parent">上级对象</param>
                /// <param name="id">标识</param>
                public MonopolyBuffer(IdentityObject parent, string id)
                        : base(parent, id)
                {
                }

                public override T Dequeue()
                {
                        var length = Length + 3;

                        for (int i = 0; i < length; i++)
                        {
                                var t = Dequeue();
                                if (t.Lock())
                                {
                                        return t;
                                }
                                else
                                {
                                        Enqueue(t);                                        
                                }
                        }
                        return null;
                }

                
        }
}
