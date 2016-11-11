// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-08-29
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-08-29
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using Nutshell.Data;

namespace Nutshell.Components
{
        /// <summary>
        ///         不带缓存的消费者
        /// </summary>
        public abstract class DirectConsumer<T> : Consumer<T> where T : class
        {
                protected DirectConsumer(IdentityObject parent, string id)
                        : base(parent, id)
                {
                }

                public override void Acquire(T t)
                {
                        base.Acquire(t);
                        Consume(t);
                }
        }
}