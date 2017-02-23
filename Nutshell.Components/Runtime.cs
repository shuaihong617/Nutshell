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

namespace Nutshell.Components
{
        /// <summary>
        ///         运行环境
        /// </summary>
        public abstract class Runtime:RunableObject,IRuntime
        {
                protected Runtime([MustNotEqualNull]IIdentityObject parent,
                        [MustNotEqualNullOrEmpty] string id)
                        : base(parent, id)
                {
                }

                #region 属性


                [MustNotEqualNull]
                public IRuntimeInformation RuntimeInformation { get; protected set; }

		[MustNotEqualNull]
                protected IWorker DispatchWorker { get; set; }

                public WorkerState WorkerState
                {
                        get { return DispatchWorker.WorkerState; }
                }

                #endregion

                #region 方法
                
                [MustReturnNotEqualNull]
                public virtual IResult Start()
                {
                        return DispatchWorker.Start(this);
                }

                [MustReturnNotEqualNull]
                public virtual IResult Stop()
                {
			return DispatchWorker.Stop(this);
                }

	        #endregion

	        
        }
}