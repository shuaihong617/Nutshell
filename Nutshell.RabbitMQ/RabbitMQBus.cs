// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2017-07-11
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2017-07-19
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************
using System;
using System.Diagnostics;
using Nutshell.Communication;
using Nutshell.Data.Models;
using Nutshell.RabbitMQ.Messaging;
using Nutshell.RabbitMQ.Models;
using RabbitMQ.Client;

namespace Nutshell.RabbitMQ
{
        /// <summary>
        /// Class RabbitMQBus.
        /// </summary>
        public class RabbitMQBus : Bus
        {
                #region 字段

                /// <summary>
                /// 连接工厂
                /// </summary>
                private ConnectionFactory _factory;

                #endregion

                #region 属性

                /// <summary>
                /// Gets the authorization.
                /// </summary>
                /// <value>The authorization.</value>
                public RabbitMQAuthorization Authorization { get; } = new RabbitMQAuthorization();

                /// <summary>
                /// 获取连接
                /// </summary>
                /// <value>连接</value>
                /// <remarks>1 连接可以Dispose，所以必须可为null。
                /// 2 连接比较消耗资源，所以多个发送和接收单元尽量共享连接。（官方文档上说的）</remarks>
                public IConnection Connection { get; private set; }

                #endregion

                /// <summary>
                /// 从数据模型加载数据
                /// </summary>
                /// <param name="model">读取数据的源数据模型，该数据模型不能为空引用</param>
                public override void Load(IIdentityModel model)
                {
                        base.Load(model);

                        var subModel = model as RabbitMQBusModel;
                        Trace.Assert(subModel != null);

                        Authorization.Load(subModel.RabbitMQAuthorizationModel);
                }


                /// <summary>
                /// 执行启动过程的具体步骤.
                /// </summary>
                /// <returns>成功返回True, 否则返回False.</returns>
                /// <remarks>若启动过程有多个步骤, 遇到返回错误的步骤立即停止向下执行.</remarks>
                protected override bool StartCore()
                {
                        if (!base.StartCore())
                        {
                                return false;
                        }

                        _factory = new ConnectionFactory
                        {
                                HostName = Authorization.HostName,
                                Port = Authorization.PortNumber,
                                UserName = Authorization.UserName,
                                Password = Authorization.Password
                        };

                        Connection = _factory.CreateConnection();

                        return true;
                }

                /// <summary>
                /// 执行退出过程的具体步骤.
                /// </summary>
                /// <returns>成功返回True, 否则返回False.</returns>
                /// <remarks>若退出过程有多个步骤,执行尽可能多的步骤, 以保证尽量清理现场.</remarks>
                protected override bool StopCore()
                {
                        base.StopCore();

                        Connection.Close();
                        Connection.Dispose();
                        Connection = null;

                        _factory = null;

                        return true;
                }

        }
}
