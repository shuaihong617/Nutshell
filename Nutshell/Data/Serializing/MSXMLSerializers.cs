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

using System;
using System.Collections.Generic;

namespace Nutshell.Data.Serializing
{
        /// <summary>
        ///         Protobuf序列化辅助类
        /// </summary>
        public static class MSSerializers
        {
                private static readonly Dictionary<Type, MSSerializer> XmlSerializers = new Dictionary<Type, MSSerializer>();

                public static MSSerializer GetMSSerializer(Type type)
                {
                        if (!XmlSerializers.ContainsKey(type))
                        {
                                XmlSerializers.Add(type, new MSSerializer());
                        }
                        return XmlSerializers[type];
                }
        }
}