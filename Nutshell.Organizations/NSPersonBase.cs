// ***********************************************************************
// 程序集         : FutureTech
// 作者           : 帅红
// 创建           : 2014-09-30
//
// 编辑           : 帅红
// 日期           : 2014-10-06
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 武汉九鼎科达科技有限公司. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using Nutshell.Data;

namespace Nutshell.Organizations
{
        /// <summary>
        /// 个人接口
        /// </summary>
        public class NSPersonBase : StorableObject
        {
                public string Name { get; private set; }

                /// <summary>
                /// 性别
                /// </summary>
                public NSSex NSSex { get; private set; }

                /// <summary>
                /// 电话
                /// </summary>
                public string Telephone { get; private set; }

                /// <summary>
                /// 获取电子邮箱
                /// </summary>
                /// <value>The E mail.</value>
                public string Email { get; private set; }

                /// <summary>
                /// 获取QQ
                /// </summary>
                /// <value>The QQ.</value>
                public string QQ { get; private set; }
        }
}
