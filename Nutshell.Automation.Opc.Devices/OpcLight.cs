﻿using System;
using Nutshell.Extensions;

namespace Nutshell.Automation.Opc.Devices
{
        /// <summary>
        /// 电灯
        /// </summary>
        public class OpcLight:OpcDevice<bool>
        {

                public OpcLight(IdentityObject parent, string id, OpcItem opcItem)
                        :base(parent, id, opcItem)
                {
                        OpcPoint.ValueChanged += Data_ValueChanged;
                }

                #region 事件

                public void TurnOn()
                {
                        OpcPoint.RemoteWrite(true);
                }

                public void TurnOff()
                {
                        OpcPoint.RemoteWrite(false);
                }

                private void Data_ValueChanged(object sender, ValueEventArgs<bool?> e)
                {
                        if (!e.Value.HasValue)
                        {
                                return;
                        }

                        if (e.Value.Value)
                        {
                                OnOpened(null);
                        }
                        else
                        {
                                OnClosed(null);
                        }
                }

                /// <summary>
                ///         Occurs when [opened].
                /// </summary>
                public event EventHandler<EventArgs> Opened;

                /// <summary>
                ///         Raises the <see cref="E:Opened" /> event.
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
                protected virtual void OnOpened(EventArgs e)
                {
                        this.InfoEvent("打开");
                        e.Raise(this, ref Opened);
                }

                /// <summary>
                ///         Occurs when [opened].
                /// </summary>
                public event EventHandler<EventArgs> Closed;

                /// <summary>
                ///         Raises the <see cref="E:Opened" /> event.
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
                protected virtual void OnClosed(EventArgs e)
                {
                        this.InfoEvent("关闭");
                        e.Raise(this, ref Closed);
                }

                #endregion
        }
}