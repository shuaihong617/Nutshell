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

using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Storaging.Models;

namespace Nutshell.Serializing
{
        /// <summary>
        ///         序列化器抽象基类
        /// </summary>
        public abstract class Serializer<T> : ISerializer<T> where T : DataModel
        {
                /// <summary>
                ///         将对象序列化为字节数组
                /// </summary>
                /// <typeparam name="T">类型参数</typeparam>
                /// <param name="t">序列化对象</param>
                /// <returns>序列化完成后的字节数组</returns>
                public abstract byte[] Serialize([MustNotEqualNull] T t);

                /// <summary>
                ///         将字节数组反序列化为对象
                /// </summary>
                /// <typeparam name="T">类型参数</typeparam>
                /// <param name="content">包含对象信息的字节数组</param>
                /// <returns>反序列化后的对象</returns>
                public abstract T Deserialize([MustNotEqualNull] byte[] content);
        }
}