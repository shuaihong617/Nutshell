using System;
using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Components;

namespace Nutshell.Speech
{
	public abstract class Synthesizer : Component, ISynthesizer
	{
		protected Synthesizer(IIdentityObject parent, string id, Language language = Language.中文)
			: base(parent, id)
		{
			Language = language;
			SynthesizerState = SynthesizerState.空闲;
			OutputMode = OutputMode.扬声器;
		}

		[WillNotifyPropertyChanged]
		public Language Language { get; protected set; }

		[WillNotifyPropertyChanged]
		public SynthesizerState SynthesizerState { get; protected set; }
		
		[WillNotifyPropertyChanged]
		public OutputMode OutputMode { get; protected set; }

		public abstract IResult SelectVoice(string voice);

		public abstract IResult SpeakAsync(string content);
	}
}
