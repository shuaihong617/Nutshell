// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-09-05
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-09-05
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System;
using System.Collections.ObjectModel;
using System.Speech.Synthesis;
using Nutshell.Aspects.Locations.Contracts;

namespace Nutshell.Speech.Microsoft
{
        /// <summary>
        ///         工作结果接口
        /// </summary>
        public class MicrosoftSynthesisRuntimeDispatchResult : Result
        {
                public MicrosoftSynthesisRuntimeDispatchResult([MustNotEqualNull]ReadOnlyCollection<InstalledVoice> chineseVoiceInfos, 
			[MustNotEqualNull]ReadOnlyCollection<InstalledVoice> englishVoiceInfos)
                        :base(true)
                {
                        ChineseVoiceInfos = chineseVoiceInfos;
                        EnglishVoiceInfos = englishVoiceInfos;
                }

                [MustNotEqualNull]
                public ReadOnlyCollection<InstalledVoice> ChineseVoiceInfos { get; private set; }

                [MustNotEqualNull]
                public ReadOnlyCollection<InstalledVoice> EnglishVoiceInfos { get; private set; }
        }
}