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

namespace Nutshell.Storaging.Xml
{
        /// <summary>
        ///         Xml文件存储加载器
        /// </summary>
        /// <remarks>
        ///         只支持UTF-8编码。
        /// </remarks>
        public class XmlStorager
        {
                /// <summary>
                ///         初始化<see cref="XmlStorager" />的新实例.
                /// </summary>
                protected XmlStorager()
                {
                }

                #region 属性

                #region 单例

                /// <summary>
                ///         单例
                /// </summary>
                public static readonly XmlStorager Instance = new XmlStorager();

                #endregion 单例

                #endregion 属性

                /// <summary>
                ///         加载指定路径的文件并转换成字节数组，可用于反序列化。
                /// </summary>
                /// <param name="filePath">文件路径</param>
                /// <returns>字节数组</returns>
                public byte[] Load([MustFileExist] string filePath)
                {
                        using (var stream = new StreamReader(filePath, Encoding.UTF8))
                        {
                                var result = stream.ReadToEnd();
                                return Encoding.UTF8.GetBytes(result);
                        }
                }
        }
}