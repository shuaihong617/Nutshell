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

using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Components;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Speech.Synthesis;
using NativeSynthesizer = System.Speech.Synthesis.SpeechSynthesizer;

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
                private MicrosoftSynthesisRuntime()
                        : base("微软语音合成运行环境")
                {
                }

                #endregion 构造函数

                #region 属性

                /// <summary>
                ///         单例
                /// </summary>
                public static readonly MicrosoftSynthesisRuntime Instance = new MicrosoftSynthesisRuntime();

                [MustNotEqualNull]
                public ReadOnlyCollection<InstalledVoice> ChineseVoices { get; private set; }

                [MustNotEqualNull]
                public ReadOnlyCollection<InstalledVoice> EnglishVoices { get; private set; }

                #endregion 属性

                #region 方法

                /// <summary>
                ///         执行启动过程的具体步骤.
                /// </summary>
                /// <returns>成功返回True, 否则返回False.</returns>
                /// <remarks>
                ///         若启动过程有多个步骤, 遇到返回错误的步骤立即停止向下执行.
                /// </remarks>
                protected override Result StartCore()
                {
                        var baseResult = base.StartCore();
                        if (!baseResult.IsSuccessed)
                        {
                                return baseResult;
                        }

                        var synthesizer = new NativeSynthesizer();

                        ChineseVoices = synthesizer.GetInstalledVoices(new CultureInfo("zh-CN"));
                        EnglishVoices = synthesizer.GetInstalledVoices(new CultureInfo("en-US"));

                        return Result.Successed;
                }

                #endregion 方法
        }
}