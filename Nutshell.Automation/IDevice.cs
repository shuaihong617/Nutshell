// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-07-22
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-07-22
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************


using Nutshell.Components;

namespace Nutshell.Automation
{
        /// <summary>
        /// 设备接口
        /// </summary>
        public interface IDevice : IWorker
        {
        	#region 属性

                ManufacturingInformation ManufacturingInformation { get; }

                #endregion
        }
}