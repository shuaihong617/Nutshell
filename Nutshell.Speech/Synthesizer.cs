// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2017-01-19
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2017-01-19
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************
using System;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Components;

namespace Nutshell.Speech
{
	/// <summary>
	/// 语音合成器
	/// </summary>
	public abstract class Synthesizer : Component, ISynthesizer
	{
		/// <summary>
		/// 初始化<see cref="Synthesizer"/>的新实例.
		/// </summary>
		/// <param name="parent">The parent.</param>
		/// <param name="id">The identifier.</param>
		/// <param name="language">The language.</param>
		protected Synthesizer(IIdentityObject parent, string id, Language language = Language.中文)
			: base(parent, id)
		{
			Language = language;
		        Volume = 100;
			SynthesizerState = SynthesizerState.空闲;
			OutputMode = OutputMode.扬声器;
		}

		/// <summary>
		/// Gets or sets the language.
		/// </summary>
		/// <value>The language.</value>
		[WillNotifyPropertyChanged]
		public Language Language { get; protected set; }

		/// <summary>
		/// Gets or sets the voice.
		/// </summary>
		/// <value>The voice.</value>
		[MustNotEqualNullOrEmpty]
                [WillNotifyPropertyChanged]
                public string Voice { get; protected set; }

		/// <summary>
		/// Gets or sets the volume.
		/// </summary>
		/// <value>The volume.</value>
		[MustBetweenOrEqual(0,100)]
                [WillNotifyPropertyChanged]
	        public int Volume { get; set; }

		/// <summary>
		/// Gets or sets the state of the synthesizer.
		/// </summary>
		/// <value>The state of the synthesizer.</value>
		[WillNotifyPropertyChanged]
		public SynthesizerState SynthesizerState { get; protected set; }

		/// <summary>
		/// Gets the progresee.
		/// </summary>
		/// <value>The progresee.</value>
		public int Progresee { get; }

		/// <summary>
		/// Gets or sets the output mode.
		/// </summary>
		/// <value>The output mode.</value>
		[WillNotifyPropertyChanged]
		public OutputMode OutputMode { get; set; }

		/// <summary>
		/// Selects the voice.
		/// </summary>
		/// <param name="voice">The voice.</param>
		/// <returns>IResult.</returns>
		public abstract IResult SelectVoice(string voice);

		/// <summary>
		/// Synthesizes the asynchronous.
		/// </summary>
		/// <param name="content">The content.</param>
		/// <param name="fileName">Name of the file.</param>
		/// <returns>IResult.</returns>
		public abstract IResult SynthesizeAsync(string content, string fileName = null);

		/// <summary>
		/// 当合成启动时发生。
		/// </summary>
		public event EventHandler<EventArgs> SynthesizeStarting;
		/// <summary>
		/// 当合成启动完成时发生。
		/// </summary>
		public event EventHandler<ValueEventArgs<Exception>> SynthesizeStarted;
		/// <summary>
		/// 当合成停止时发生。
		/// </summary>
		public event EventHandler<EventArgs> SynthesizeStoping;
		/// <summary>
		/// 当合成停止完成时发生。
		/// </summary>
		public event EventHandler<ValueEventArgs<Exception>> SynthesizeStoped;
	}
}
