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

namespace Nutshell.Components
{
        /// <summary>
        ///         同步缓存订阅者, 顺序缓存订阅结果后依次处理
        /// </summary>
        public abstract class DirectProducer<T> : Producer<T> where T : class
        {
                protected DirectProducer(IdentityObject parent, string id)
                        : base(parent, id)
                {
                }

                protected override void Product(T t)
                {
                        base.Product(t);
                        Dispatch(t);
                }
        }
}