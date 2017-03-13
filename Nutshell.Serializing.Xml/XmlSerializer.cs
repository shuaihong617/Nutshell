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

using Nutshell.Data.Models;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using MSXmlSerializer = System.Xml.Serialization.XmlSerializer;

namespace Nutshell.Serializing.Xml
{
        /// <summary>
        ///  Xml序列化器
        /// </summary>
        public class XmlSerializer<T> : Serializer<T> where T : IDataModel
        {
                #region 构造函数

                private XmlSerializer()
                {
                }

                #endregion 构造函数

                #region 单例

                /// <summary>
                ///         单例
                /// </summary>
                public static readonly XmlSerializer<T> Instance = new XmlSerializer<T>();

                #endregion 单例

                private static readonly MSXmlSerializer MSXmlSerializer = new MSXmlSerializer(typeof(T));

                /// <summary>
                /// 定义命名空间为空
                /// </summary>
                private static readonly XmlSerializerNamespaces Namespaces = new XmlSerializerNamespaces(
                        new[] { new XmlQualifiedName(string.Empty, string.Empty) });

                /// <summary>
                ///         将对象序列化为字节数组
                /// </summary>
                /// <typeparam name="T">类型参数</typeparam>
                /// <param name="t">序列化对象</param>
                /// <returns>序列化完成后的字节数组</returns>
                public override byte[] Serialize(T t)
                {
                        using (var ms = new MemoryStream())
                        {
                                MSXmlSerializer.Serialize(ms, t, Namespaces);
                                return ms.ToArray();
                        }
                }

                /// <summary>
                /// 将字节数组反序列化为对象
                /// </summary>
                /// <typeparam name="T">类型参数</typeparam>
                /// <param name="content">包含对象信息的字节数组</param>
                /// <returns>反序列化后的对象</returns>
                public override T Deserialize(byte[] content)
                {
                        using (var stream = new MemoryStream(content))
                        {
                                return Deserialize(stream);
                        }
                }

                public T Deserialize(Stream stream)
                {
                        return (T)MSXmlSerializer.Deserialize(stream);
                }
        }
}