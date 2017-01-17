using Nutshell.Components;

namespace Nutshell.Speech
{
        public interface ISynthesizer : IComponent
        {
                Language Language { get; }

                OutputMode OutputMode { get; }

                SynthesizerState SynthesizerState { get; }

                IResult SelectVoice(string voice);

                IResult SpeakAsync(string content);
        }
}
