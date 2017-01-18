using System;
using Nutshell.Aspects.Locations.Contracts;
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

                [MustBetweenOrEqual(0,100)]
                [WillNotifyPropertyChanged]
	        public int Volume { get; set; }

	        [WillNotifyPropertyChanged]
		public SynthesizerState SynthesizerState { get; protected set; }

	        public int Progresee { get; }

	        [WillNotifyPropertyChanged]
		public OutputMode OutputMode { get; set; }

		public abstract IResult SelectVoice(string voice);

		public abstract IResult SynthesizeAsync(string content);

	        public event EventHandler<EventArgs> SynthesizeStarting;
	        public event EventHandler<ValueEventArgs<Exception>> SynthesizeStarted;
	        public event EventHandler<EventArgs> SynthesizeStoping;
	        public event EventHandler<ValueEventArgs<Exception>> SynthesizeStoped;
	}
}
