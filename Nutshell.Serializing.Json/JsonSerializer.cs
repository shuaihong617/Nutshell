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
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Nutshell.Data.Models;

namespace Nutshell.Serializing.Json
{
        /// <summary>
        ///  Json序列化器
        /// </summary>
        public class JsonSerializer<T> : Serializer<T> where T : IIdentityModel
        {
                #region 构造函数

                private JsonSerializer()
                {
                        if (!_isConfiged)
                        {
                                JsonSerializerSettings setting = new JsonSerializerSettings();
                                JsonConvert.DefaultSettings = new Func<JsonSerializerSettings>(() =>
                                {
                                        //日期类型默认格式化处理
                                        setting.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
                                        setting.DateFormatString = "yyyy-MM-dd HH:mm:ss.fff";

                                        //空值处理
                                        //setting.NullValueHandling = NullValueHandling.Ignore;

                                        //高级用法九中的Bool类型转换 设置
                                        //setting.Converters.Add(new BoolConvert("是,否"));

                                        return setting;
                                });

                                _isConfiged = true;
                        }
                        
                }

                #endregion 构造函数

                #region 单例

                /// <summary>
                ///         单例
                /// </summary>
                public static readonly JsonSerializer<T> Instance = new JsonSerializer<T>();

                private static bool _isConfiged = false;

                #endregion 单例


                /// <summary>
                ///         将对象序列化为字节数组
                /// </summary>
                /// <typeparam name="T">类型参数</typeparam>
                /// <param name="t">序列化对象</param>
                /// <returns>序列化完成后的字节数组</returns>
                public override byte[] Serialize(T t)
                {
                        var str = JsonConvert.SerializeObject(t, Formatting.Indented);
                        return Encoding.UTF8.GetBytes(str);
                }

                /// <summary>
                /// 将字节数组反序列化为对象
                /// </summary>
                /// <typeparam name="T">类型参数</typeparam>
                /// <param name="content">包含对象信息的字节数组</param>
                /// <returns>反序列化后的对象</returns>
                public override T Deserialize(byte[] content)
                {
                        var str = Encoding.UTF8.GetString(content);
                        return JsonConvert.DeserializeObject<T>(str);
                }

                //public T Deserialize(Stream stream)
                //{
                //        return (T)MSJsonSerializer.Deserialize(stream);
                //}
        }
}