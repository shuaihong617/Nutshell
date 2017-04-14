using Nutshell.Extensions;
using System;

namespace Nutshell.Automation.Opc.Devices
{
        /// <summary>
        ///         气缸
        /// </summary>
        public class OpcCylinder : IdentityObject
        {
                public OpcCylinder(string id, OpcSolenoid solenoid, OpcSensor<bool> openSensor, OpcSensor<bool> closeSensor)
                        : base(id)
                {
                        _state = CylinderState.未定义;

                        Solenoid = solenoid;

                        OpenSensor = openSensor;
                        OpenSensor.OpcPoint.ValueChanged += Sensors_ValueChanged;

                        CloseSensor = closeSensor;
                        CloseSensor.OpcPoint.ValueChanged += Sensors_ValueChanged;
                }

                private CylinderState _state;

                /// <summary>
                ///         电磁阀
                /// </summary>
                public OpcSolenoid Solenoid { get; }

                /// <summary>
                ///         开启光电开关
                /// </summary>
                public OpcSensor<bool> OpenSensor { get; }

                /// <summary>
                ///         关闭完成光电开关
                /// </summary>
                public OpcSensor<bool> CloseSensor { get; }

                public CylinderState State
                {
                        get { return _state; }
                        private set
                        {
                                if (value == _state)
                                {
                                        return;
                                }
                                _state = value;
                                OnPropertyChanged();

                                switch (_state)
                                {
                                        case CylinderState.正在开启:
                                                OnOpening(null);
                                                break;

                                        case CylinderState.开启完成:
                                                OnOpenCompleted(null);
                                                break;

                                        case CylinderState.正在关闭:
                                                OnClosing(null);
                                                break;

                                        case CylinderState.关闭完成:
                                                OnCloseCompleted(null);
                                                break;
                                }
                        }
                }

                private void Sensors_ValueChanged(object sender, ValueEventArgs<bool?> e)
                {
                        if (CloseSensor.OpcPoint.Value.HasValue
                                && CloseSensor.OpcPoint.Value.Value)
                        {
                                State = CylinderState.关闭完成;
                                return;
                        }

                        if (OpenSensor.OpcPoint.Value.HasValue
                                && OpenSensor.OpcPoint.Value.Value)
                        {
                                State = CylinderState.开启完成;
                                return;
                        }

                        if (OpenSensor.OpcPoint.Value.HasValue
                                && !OpenSensor.OpcPoint.Value.Value)
                        {
                                State = CylinderState.正在关闭;
                                return;
                        }

                        if (CloseSensor.OpcPoint.Value.HasValue
                                && !CloseSensor.OpcPoint.Value.Value)
                        {
                                State = CylinderState.正在开启;
                        }
                }

                public void Open()
                {
                        Solenoid.Open();
                }

                public void Close()
                {
                        Solenoid.Close();
                }

                #region 事件

                /// <summary>
                ///         Occurs when [opened].
                /// </summary>
                public event EventHandler<EventArgs> Opening;

                /// <summary>
                ///         引发<see cref="E:Opened" />事件
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
                protected virtual void OnOpening(EventArgs e)
                {
                        this.InfoEvent(CylinderState.正在开启);
                        e.Raise(this, ref Opening);
                }

                /// <summary>
                ///         Occurs when [opened].
                /// </summary>
                public event EventHandler<EventArgs> Closing;

                /// <summary>
                ///         引发<see cref="E:Opened" />事件
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
                protected virtual void OnClosing(EventArgs e)
                {
                        this.InfoEvent(CylinderState.正在关闭);
                        e.Raise(this, ref Closing);
                }

                /// <summary>
                ///         Occurs when [opened].
                /// </summary>
                public event EventHandler<EventArgs> OpenCompleted;

                /// <summary>
                ///         引发<see cref="E:Opened" />事件
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
                protected virtual void OnOpenCompleted(EventArgs e)
                {
                        this.InfoEvent(CylinderState.开启完成);
                        e.Raise(this, ref OpenCompleted);
                }

                /// <summary>
                ///         Occurs when [opened].
                /// </summary>
                public event EventHandler<EventArgs> CloseCompleted;

                /// <summary>
                ///         引发<see cref="E:Opened" />事件
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
                protected virtual void OnCloseCompleted(EventArgs e)
                {
                        this.InfoEvent(CylinderState.关闭完成);
                        e.Raise(this, ref CloseCompleted);
                }

                #endregion 事件
        }
}