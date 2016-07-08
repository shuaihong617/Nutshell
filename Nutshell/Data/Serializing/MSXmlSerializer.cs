﻿// ***********************************************************************
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

using System.IO;
using System.Xml.Serialization;

namespace Nutshell.Data.Serializing
{
        /// <summary>
        ///         Protobuf序列化辅助类
        /// </summary>
        public class MSSerializer : Serializer
        {
                private XmlSerializer _xmlSerializer;

                /// <summary>
                ///         将对象序列化为字节数组
                /// </summary>
                /// <typeparam name="T">类型参数</typeparam>
                /// <param name="t">序列化对象</param>
                /// <returns>序列化完成后的字节数组</returns>
                public override byte[] Serialize<T>(T t)
                {
                        using (var ms = new MemoryStream())
                        {
                                if (_xmlSerializer == null)
                                {
                                        _xmlSerializer = new XmlSerializer(typeof (T));
                                }
                                _xmlSerializer.Serialize(ms, t);
                                return ms.ToArray();
                        }
                }


                /// <summary>
                ///         将字节数组反序列化为对象
                /// </summary>
                /// <typeparam name="T">类型参数</typeparam>
                /// <param name="content">包含对象信息的字节数组</param>
                /// <returns>反序列化后的对象</returns>
                public override T Deserialize<T>(byte[] content)
                {
                        using (var stream = new MemoryStream(content))
                        {
                                return Deserialize<T>(stream);
                        }
                }


                public T Deserialize<T>(Stream stream) where T : class
                {
                        if (_xmlSerializer == null)
                        {
                                _xmlSerializer = new XmlSerializer(typeof (T));
                        }
                        return _xmlSerializer.Deserialize(stream) as T;
                }
        }
}