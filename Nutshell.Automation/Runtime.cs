// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2014-10-16
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2014-10-17
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Aspects.Methods.Contracts;
using Nutshell.Components;

namespace Nutshell.Automation
{
        /// <summary>
        ///         设备运行环境
        /// </summary>
        public abstract class Runtime:IdentityObject
        {
                protected Runtime()
                        :base(null,"设备运行环境")
                {

                }

                #region 属性

		[MustNotEqualNull]
                public IRuntimeInformation RuntimeInformation { get; protected set; }

		[MustNotEqualNull]
                protected IWorker DispatchWorker { get; set; }

                public WorkState WorkState
                {
                        get { return DispatchWorker.WorkState; }
                }

                #endregion

                #region 方法

                [MustReturnNotEqualNull]
                protected virtual IWorkContext CreateDispatchContext()
	        {
		        return WorkContext.EnableRelease;
	        }

                [MustReturnNotEqualNull]
                public virtual IResult Start()
                {
	                var context = CreateDispatchContext();
                        return DispatchWorker.Start(context);
                }

                [MustReturnNotEqualNull]
                public virtual IResult Stop()
                {
			var context = CreateDispatchContext();
			return DispatchWorker.Stop(context);
                }

	        #endregion


        }
}