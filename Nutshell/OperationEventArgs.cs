// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2014-10-16
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2014-10-16
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System;

namespace Nutshell
{
        /// <summary>
        ///         Class OperationEventArgs.
        /// </summary>
        public class OperationEventArgs : EventArgs
        {
                /// <summary>
                ///         初始化<see cref="OperationEventArgs" />的新实例.
                /// </summary>
                /// <param name="isSuccess">if set to <c>true</c> [is success].</param>
                /// <param name="operation">The operation.</param>
                /// <param name="description">The description.</param>
                public OperationEventArgs(bool isSuccess, string operation, object description = null)
                {
                        IsSuccess = isSuccess;
                        Operation = operation;
                        Description = description;
                }


                /// <summary>
                ///         操作是否執行成功
                /// </summary>
                public bool IsSuccess { get; private set; }

                public string Operation { get; private set; }


                /// <summary>
                ///         返回值的描述信息, 或者操作執行失敗的原因, 返回值等
                /// </summary>
                public object Description { get; private set; }

                public override string ToString()
                {
                        return string.Format("{0}{1}{2}{3}{4}{5}",
                                Operation,
                                IsSuccess ? "成功" : " 失败",
                                Description == null ? "." : ",",
                                IsSuccess ? "" : " 错误原因 :",
                                Description,
                                Description == null ? "" : ".");
                }
        }
}