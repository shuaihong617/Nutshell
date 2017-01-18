// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-10-14
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-10-14
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System.Collections.ObjectModel;
using System.Speech.Synthesis;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Components;

namespace Nutshell.Speech.Microsoft
{
        /// <summary>
        ///         表示数据环境上下文（缓存）
        /// </summary>
        public class MicrosoftSynthesisRuntime : Runtime
        {
                #region 构造函数

                /// <summary>
                ///         数据缓存上下文私有构造函数
                /// </summary>
                public MicrosoftSynthesisRuntime(IIdentityObject parent)
                        : base(parent, "微软语音合成运行环境")
                {
                        DispatchWorker = new MicrosoftSynthesisRuntimeDispatchWorker(this);
                }

                #endregion 构造函数

                #region 属性

                [MustNotEqualNull]
                public ReadOnlyCollection<InstalledVoice> ChineseVoices { get; private set; }

                [MustNotEqualNull]
                public ReadOnlyCollection<InstalledVoice> EnglishVoices { get; private set; }

                #endregion 属性

                #region 方法

                public override IResult Start()
                {
                        var result = base.Start();
                        if (!result.IsSuccessed)
                        {
                                return result;
                        }

                        var microsoftResult = DispatchWorker.Start(this);
                        var microsoft = microsoftResult as MicrosoftSynthesisRuntimeDispatchResult;

                        ChineseVoices = microsoft.ChineseVoiceInfos;
                        EnglishVoices = microsoft.EnglishVoiceInfos;

                        return microsoftResult;
                }

                #endregion 方法
        }
}