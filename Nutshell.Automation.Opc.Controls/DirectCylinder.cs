// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2017-05-23
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2017-05-23
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using Nutshell.Aspects.Locations.Contracts;

namespace Nutshell.Automation.Opc.Controls
{
        /// <summary>
        ///         直接接受状态值的气缸
        /// </summary>
        public class DirectCylinder : Cylinder
        {
                /// <summary>
                ///         初始化<see cref="DirectCylinder" />的新实例.
                /// </summary>
                /// <param name="id">The identifier.</param>
                public DirectCylinder(string id = "")
                        : base(id)
                {
                        _stateOpcAccessor.ValueChanged += (obj, args) => State = (CylinderState) args.Value;
                        ;
                }

                /// <summary>
                ///         The _state opc accessor
                /// </summary>
                private readonly OpcAccessor<byte> _stateOpcAccessor = new OpcAccessor<byte>();

                /// <summary>
                ///         Sets the state opc item.
                /// </summary>
                /// <param name="opcItem">The opc item.</param>
                /// <returns>Cylinder.</returns>
                public Cylinder SetStateOpcItem([MustNotEqualNull] OpcItem opcItem)
                {
                        _stateOpcAccessor.SetSource(opcItem);
                        return this;
                }
        }
}