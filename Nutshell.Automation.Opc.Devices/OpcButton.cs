using Nutshell.Extensions;
using System;

namespace Nutshell.Automation.Opc.Devices
{
        /// <summary>
        /// 按钮
        /// </summary>
        public class OpcButton : OpcDevice<bool>
        {
                public OpcButton(string id, OpcItem opcItem)
                        : base(id, opcItem)
                {
                        OpcPoint.ValueChanged += Current_ValueChanged;
                }

                public void Press()
                {
                        OpcPoint.RemoteWrite(true);
                }

                public void Raise()
                {
                        OpcPoint.RemoteWrite(false);
                }

                private void Current_ValueChanged(object sender, ValueEventArgs<bool?> e)
                {
                        if (!e.Value.HasValue)
                        {
                                return;
                        }

                        if (e.Value.Value)
                        {
                                OnPressed(null);
                        }
                        else
                        {
                                OnRaised(null);
                        }
                }

                #region 事件

                /// <summary>
                ///         Occurs when [opened].
                /// </summary>
                public event EventHandler<EventArgs> Pressed;

                /// <summary>
                ///         Raises the <see cref="E:Opened" /> event.
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
                protected virtual void OnPressed(EventArgs e)
                {
                        this.InfoEvent("按下");
                        e.Raise(this, ref Pressed);
                }

                /// <summary>
                ///         Occurs when [opened].
                /// </summary>
                public event EventHandler<EventArgs> Raised;

                /// <summary>
                ///         Raises the <see cref="E:Opened" /> event.
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
                protected virtual void OnRaised(EventArgs e)
                {
                        this.InfoEvent("弹起");
                        e.Raise(this, ref Raised);
                }

                #endregion 事件
        }
}