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
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Speech.Synthesis;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Data.Models;
using NativeSynthesizer = System.Speech.Synthesis.SpeechSynthesizer;

namespace Nutshell.Speech.Microsoft
{
	/// <summary>
	///         表示数据环境上下文（缓存）
	/// </summary>
	/// <remarks>此类表示系统所有对象在内存中的数据缓存, 唯一, 采用单例模式构造</remarks>
	public class MicrosoftSynthesizer : Synthesizer
	{

		#region 构造函数

		/// <summary>
		///         数据缓存上下文私有构造函数
		/// </summary>
		public MicrosoftSynthesizer(IIdentityObject parent, Language language = Language.中文)
			: base(parent, "微软语音合成服务", language)
		{
			Language = language;

                        NativeSynthesizer = new NativeSynthesizer();
		        NativeSynthesizer.Volume = 100;

		        NativeSynthesizer.StateChanged += (obj, args) =>
		        {
                                
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
		public NativeSynthesizer NativeSynthesizer { get; private set; }

		[MustNotEqualNullOrEmpty]
		[WillNotifyPropertyChanged]
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

		

		

		public override IResult SynthesizeAsync(string content)
		{
			switch (OutputMode)
			{
					case OutputMode.扬声器:
					NativeSynthesizer.SetOutputToDefaultAudioDevice();
					break;
			}

		        NativeSynthesizer.SpeakAsync(content);

			return Result.Successed;
		}

		public override IResult SelectVoice(string voice)
		{
			try
			{
				NativeSynthesizer.SelectVoice(voice);
				
			}
			catch (Exception ex)
			{
				
				return new Result(ex);
			}
			return Result.Successed;
		}

		public IResult SpeakAsync(string content, string fileName)
		{
			switch (OutputMode)
			{
				case OutputMode.扬声器:
					NativeSynthesizer.SetOutputToDefaultAudioDevice();
					break;

					case OutputMode.文件:
					NativeSynthesizer.SetOutputToWaveFile(fileName);
					break;

			}

			NativeSynthesizer.SpeakAsync(content);

			return Result.Successed;
		}
	}
}