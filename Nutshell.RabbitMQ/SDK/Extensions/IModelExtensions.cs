// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2014-12-15
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2014-12-12
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System;
using System.ComponentModel;
using Nutshell.RabbitMQ.Models;
using RabbitMQ.Client;

namespace Nutshell.RabbitMQ.SDK.Extensions
{
        /// <summary>
        ///         像素格式扩展方法
        /// </summary>
        public static class IModelExtensions
        {

                public static void DeclareExchange(this IModel channel, RabbitMQExchangeModel exchange)
                {
                        channel.ExchangeDeclare(exchange.Name,
                                exchange.ExchangeType.ToString().ToLower(),
                                exchange.IsDurable,
                                exchange.IsAutoDelete);
                }


                public static QueueDeclareOk DeclareQueue(this IModel channel, RabbitMQQueueModel queue)
                {
                        return channel.QueueDeclare(queue.Name,
                                queue.IsDurable,
                                queue.IsExclusive,
                                queue.IsAutoDelete,
                                null);
                }

                public static QueueDeclareOk DeclareAndPurgeQueue(this IModel channel, RabbitMQQueueModel queue)
                {
                        var result = channel.QueueDeclare(queue.Name,
                                queue.IsDurable,
                                queue.IsExclusive,
                                queue.IsAutoDelete,
                                null);

                        channel.QueuePurge(queue.Name);

                        return result;
                }
        }
}