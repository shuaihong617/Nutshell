using System;
using System.Windows.Threading;
using Microsoft.WindowsAPICodePack.DirectX.Direct2D1;

namespace Nutshell.Presentation.Direct2D1
{
        /// <summary>
        ///         Allows drawing of a Scene at a specified Frame Per Second.
        /// </summary>
        public abstract class TimerSence : Sence
        {
                protected TimerSence(int desiredFps)
                {
                        desiredFps.MustGreaterThan(0);
                        Interval = 100;
                }

                private DateTime _lastUpdate;
                private DispatcherTimer _timer;

                public int Interval { get; private set; }

                /// <summary>
                ///         Gets the time in seconds since the last update.
                /// </summary>
                /// <remarks>
                ///         The accuracy of this field is the same as DateTime so will only be
                ///         accurate to approximately 15ms, as the DispatcherTimer used has the
                ///         same limitation.
                /// </remarks>
                protected double ElapsedTime { get; private set; }

                /// <summary>
                ///         Creates device dependent resources and resumes the animation.
                /// </summary>
                protected override void OnCreateResources(RenderTarget target)
                {
                        base.OnCreateResources(target);
                }

                /// <summary>
                ///         Releases device dependent resources and pauses the animation.
                /// </summary>
                protected override void OnFreeResources()
                {
                        base.OnFreeResources();
                }

                public virtual void Start()
                {
                        if (_timer == null)
                        {
                                _timer = new DispatcherTimer(DispatcherPriority.Normal);
                                _timer.Interval = TimeSpan.FromMilliseconds(Interval);
                                _timer.Tick += TimerTick;
                        }
                       
                        _timer.Start();
                }

                public virtual void Stop()
                {
                        _timer.Stop();
                }

                private void TimerTick(object sender, EventArgs e)
                {
                        // We use DateTime.UtcNow as it's faster than DateTime.Now and all
                        // we're interested in is the difference between calls.
                        ElapsedTime = DateTime.UtcNow.Subtract(_lastUpdate).TotalSeconds;

                        Render(); // Force an update 

                        _lastUpdate = DateTime.UtcNow;
                }
        }
}
