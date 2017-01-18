using System;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Components;

namespace Nutshell.Speech
{
        public interface ISynthesizer : IComponent
        {
                Language Language { get; }

                OutputMode OutputMode { get; }

                [MustBetweenOrEqual(0, 100)]
                int Volume { get; set; }

                SynthesizerState SynthesizerState { get; }

                int Progresee { get; }

                IResult SelectVoice(string voice);

                IResult SynthesizeAsync(string content);

                #region 事件

                /// <summary>
                ///         当合成启动时发生。
                /// </summary>
                event EventHandler<EventArgs> SynthesizeStarting;

                /// <summary>
                ///         当合成启动完成时发生。
                /// </summary>
                event EventHandler<ValueEventArgs<Exception>> SynthesizeStarted;

                /// <summary>
                ///         当合成停止时发生。
                /// </summary>
                event EventHandler<EventArgs> SynthesizeStoping;


                /// <summary>
                ///         当合成停止完成时发生。
                /// </summary>
                event EventHandler<ValueEventArgs<Exception>> SynthesizeStoped;


                #endregion
        }
}
