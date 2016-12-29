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

using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Speech.Synthesis;
using Nutshell.Data.Models;
using Nutshell.Log;
using Nutshell.Speech.Models;

namespace Nutshell.Speech
{
        /// <summary>
        ///         表示数据环境上下文（缓存）
        /// </summary>
        /// <remarks>此类表示系统所有对象在内存中的数据缓存, 唯一, 采用单例模式构造</remarks>
        public class SpeechSynthesizer : QueueConsumer<string>
        {
                private string _content;

                #region 构造函数

                /// <summary>
                ///         数据缓存上下文私有构造函数
                /// </summary>
                public SpeechSynthesizer(IdentityObject parent, string id = "未命名语音合成服务", Language language = Language.中文)
                        : base(parent, id)
                {
                        Language = language;
                }

                #endregion 构造函数

                #region 属性

                /// <summary>
                ///         当前语音合成引擎
                /// </summary>
                /// <value>The voice info.</value>
                public VoiceInfo VoiceInfo { get; private set; }

                /// <summary>
                ///         当前语音合成引擎
                /// </summary>
                /// <value>The voice info.</value>
                public Language Language { get; private set; }

                /// <summary>
                ///         当前语音合成器
                /// </summary>
                /// <value>The speech synthesizer.</value>
                public System.Speech.Synthesis.SpeechSynthesizer MSSynthesizer { get; private set; }

                [Pure]
                public string Content
                {
                        get
                        {
                                Debug.Assert(_content.IsNotNullOrEmpty());
                                return _content;
                        }
                        private set
                        {
                                Debug.Assert(value.IsNotNullOrEmpty());

                                _content = value;
                                OnPropertyChanged();
                        }
                }

                #endregion 属性

                #region 方法

                /// <summary>
                ///         Speaks the async.
                /// </summary>
                /// <param name="content">The content.</param>
                public void SpeakSync(string content)
                {
                        Acquire(content);
                }

                #endregion 方法

                public override void Load(IDataModel model)
                {
                        base.Load(model);

                        var synthesizerModel = model as ISpeechSynthesizerModel;
                        Trace.Assert(synthesizerModel != null);

                        Language = synthesizerModel.Language;
                }

                protected override bool StartCore()
                {
                        if (!base.StartCore())
                        {
                                return false;
                        }

                        MSSynthesizer = new System.Speech.Synthesis.SpeechSynthesizer();
                        MSSynthesizer.SetOutputToDefaultAudioDevice();
                        MSSynthesizer.Volume = 100;

                        switch (Language)
                        {
                                case Language.中文:
                                        List<ItalledVoice> chineseVoices =
                                                MSSynthesizer.GetItalledVoices(new CultureInfo("zh-CN"))
                                                        .Where(i => i.Enabled)
                                                        .ToList();
                                        if (chineseVoices.Count > 0)
                                        {
                                                VoiceInfo = chineseVoices.First().VoiceInfo;
                                        }
                                        break;

                                case Language.英文:
                                        List<ItalledVoice> englishVoices =
                                                MSSynthesizer.GetItalledVoices(new CultureInfo("en-US"))
                                                        .Where(i => i.Enabled)
                                                        .ToList();
                                        if (englishVoices.Count > 0)
                                        {
                                                VoiceInfo = englishVoices.First().VoiceInfo;
                                        }
                                        break;
                        }

                        if (VoiceInfo == null)
                        {
                                return false;
                        }


                        MSSynthesizer.SelectVoice(VoiceInfo.Name);

                        return true;
                }

                protected override void Consume(string content)
                {
                        if (VoiceInfo == null)
                        {
                                return;
                        }

                        if (string.IsNullOrEmpty(content))
                        {
                                return;
                        }

                        Content = content;
                        MSSynthesizer.Speak(content);
                        Content = string.Empty;

                        this.Info("播放：" + content);
                }
        }
}