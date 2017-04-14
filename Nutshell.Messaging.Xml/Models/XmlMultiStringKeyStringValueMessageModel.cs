// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2014-11-08
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2014-11-08
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************


using System.Xml.Serialization;
using Nutshell.Extensions;

namespace Nutshell.Messaging.Xml.Models
{
        /// <summary>
        ///         自动装包开始消息数据模型
        /// </summary>
        [XmlType]
        public class XmlMultiStringKeyStringValueMessageModel : XmlMultiKeyValueMessageModel<string, string>
        {
                public XmlMultiStringKeyStringValueMessageModel()
                {
                }

                public XmlMultiStringKeyStringValueMessageModel(params object[] args)
                {
                        args.Length.MustEvenNumber();

                        for (int i = 0; i < args.Length/2; i++)
                        {
                                Add(args[i*2].ToString(), args[i*2 + 1].ToString());
                        }
                }

                //public MultiStringKeyStringValueMessage(List<KeyValuePairModel<string, string>> pairs)
                //        : base(pairs)
                //{
                //}

                public void Add(string key, string value)
                {
                        Pairs.Add(new XmlKeyValuePairModel<string, string>(key, value));
                }
        }
}