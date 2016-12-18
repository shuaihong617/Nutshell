// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2016-12-17
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2016-12-17
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System.Collections.ObjectModel;

namespace Nutshell.Communication
{
        /// <summary>
        /// 接收转发器接口
        /// </summary>
        public class Receiver:Transferor,IReceiver
        {                
                public Receiver(IdentityObject parent, string id = null) : base(parent, id)
                {
                }

                public ReadOnlyCollection<IReceivePort> ReceivePorts { get; private set; }

                protected override bool StartCore()
                {
                        ReceivePorts.Each(i=>i.ReceiveSuccessed+=((sender, args) =>
                        {
                                
                        }));
                        return true;
                }

                protected override bool StopCore()
                {
                        throw new System.NotImplementedException();
                }
        }
}
