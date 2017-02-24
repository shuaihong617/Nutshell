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

using System;
using System.Speech.Synthesis;
using System.Threading.Tasks;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Data.Models;
using Nutshell.Extensions;
using NativeSynthesizer = System.Speech.Synthesis.SpeechSynthesizer;
using NativeSynthesizerState = System.Speech.Synthesis.SynthesizerState;

namespace Nutshell.Speech.Microsoft
{
	/// <summary>
	///         表示数据环境上下文（缓存）
	/// </summary>
	public class MicrosoftSynthesizer : Synthesizer
	{
		#region 构造函数

		/// <summary>
		///         数据缓存上下文私有构造函数
		/// </summary>
		public MicrosoftSynthesizer(Language language = Language.中文)
			: base("微软语音合成器", language)
		{
			Language = language;

			NativeSynthesizer = new NativeSynthesizer
			{
				Volume = 100
			};
		}

		#endregion 构造函数

		#region 属性

		/// <summary>
		///         当前语音合成引擎
		/// </summary>
		/// <value>The voice info.</value>
		public VoiceInfo VoiceInfo { get; private set; }

		/// <summary>
		///         当前语音合成器
		/// </summary>
		/// <value>The speech synthesizer.</value>
		public NativeSynthesizer NativeSynthesizer { get; }

		[MustNotEqualNullOrEmpty]
		[NotifyPropertyValueChanged]
		public string Content { get; private set; }

		#endregion 属性

		#region 方法

		#endregion 方法

		public override void Load(IDataModel model)
		{
			//base.Load(model);

			//var synthesizerModel = model as ISpeechSynthesizerModel;
			//Trace.Assert(synthesizerModel != null);

			//Language = synthesizerModel.Language;
		}

		public override IResult SynthesizeAsync(string content, string fileName = null)
		{

			if (fileName == null)
			{
				OutputMode = OutputMode.扬声器;
				NativeSynthesizer.SetOutputToDefaultAudioDevice();
			}
			else
			{
				OutputMode = OutputMode.文件;
				NativeSynthesizer.SetOutputToWaveFile(fileName);
			}

			Task.Run(() =>
			{
				SynthesizerState = SynthesizerState.合成;

				NativeSynthesizer.Speak(content);

				SynthesizerState = SynthesizerState.空闲;
			});
			

			this.Info("合成:" + content);

			return Result.Successed;
		}

		public override IResult SelectVoice(string voice)
		{
			try
			{
				NativeSynthesizer.SelectVoice(voice);
				Voice = NativeSynthesizer.Voice.Name;
			}
			catch (Exception ex)
			{
				this.Error("Select voice " + voice +  "失败，失败原因：" + ex);
				return Result.Failed;
			}
			return Result.Successed;
		}
	}
}