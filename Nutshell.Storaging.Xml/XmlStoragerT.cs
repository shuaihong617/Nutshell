// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2017-01-06
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2017-01-06
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using Nutshell.IO.Aspects.Locations.Contracts;
using System.IO;
using System.Text;
using Nutshell.Data.Models;
using Nutshell.Serializing.Xml;

namespace Nutshell.Storaging.Xml
{
        /// <summary>
        ///         Xml文件泛型存储加载器
        /// </summary>
        /// <remarks>
        ///         只支持UTF-8编码。
        /// </remarks>
        public class XmlStorager<TS, TM> where TS:StorableObject,new() where TM : IIdentityModel,new()
        {
                /// <summary>
                ///         初始化<see cref="XmlStorager" />的新实例.
                /// </summary>
                protected XmlStorager()
                {
                }

                private readonly XmlSerializer<TM> _serializer = XmlSerializer<TM>.Instance ;

                #region 属性

                #region 单例

                /// <summary>
                ///         单例
                /// </summary>
                public static readonly XmlStorager<TS,TM> Instance = new XmlStorager<TS, TM>();

                #endregion 单例

                #endregion 属性

                public TS Load([MustFileExist] string fileName)
                {
                        var bytes = XmlStorager.Instance.Load(fileName);
                        var model = _serializer.Deserialize(bytes);

                        var t = new TS();
                        t.Load(model);

                        return t;
                }

                /// <summary>
                ///         加载指定路径的文件并转换成字节数组，可用于反序列化。
                /// </summary>
                /// <param name="filePath">文件路径</param>
                /// <param name="t">文件内容</param>
                /// <returns>字节数组</returns>
                public void Save([MustFileExist] string filePath, TS t)
                {
                        var model = new TM();
                        t.Save(model);

                        var content = _serializer.Serialize(model);

                        using (var stream = new StreamWriter(filePath,false, Encoding.UTF8))
                        {
                                stream.WriteLine(Encoding.UTF8.GetString(content));
                        }
                }
        }
}