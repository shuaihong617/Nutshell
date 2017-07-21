using System;
using System.ComponentModel;
using Nutshell.Extensions;

namespace Nutshell.Automation
{
        public class ElectronicDevice : Device
        {
                private ElectronicState _state = ElectronicState.断电;

                public ElectronicDevice(string id = "")
                        : base(id)
                {
                }

                public ElectronicState State
                {
                        get { return _state; }
                        protected set
                        {
                                if (value == _state)
                                {
                                        return;
                                }
                                _state = value;
                                OnPropertyValueChanged();

                                OnStateChanged(new ValueEventArgs<ElectronicState>(State));
                        }
                }

                public void TurnOn()
                {
                        OnTurningOn(EventArgs.Empty);
                        State = ElectronicState.上电;
                }

                public void TurnOff()
                {
                        OnTurningOff(EventArgs.Empty);
                        State = ElectronicState.上电;
                }

                #region 事件

                /// <summary>
                ///         当设备上电时发生
                /// </summary>
                [Description("设备上电事件")]
                public event EventHandler<EventArgs> TurningOn;

                /// <summary>
                ///         引发设备上电事件
                /// </summary>
                /// <param name="e">包含事件数据的<see cref="EventArgs" />实例</param>
                protected virtual void OnTurningOn(EventArgs e)
                {
                        e.Raise(this, ref TurningOn);
                }

                /// <summary>
                ///         当设备断电时发生
                /// </summary>
                [Description("设备断电事件")]
                public event EventHandler<EventArgs> TurningOff;

                /// <summary>
                ///         引发设备断电事件
                /// </summary>
                /// <param name="e">包含事件数据的<see cref="EventArgs" />实例</param>
                protected virtual void OnTurningOff(EventArgs e)
                {
                        e.Raise(this, ref TurningOff);
                }

                /// <summary>
                ///         当全局标识改变时发生
                /// </summary>
                [Description("全局标识改变事件")]
                public event EventHandler<ValueEventArgs<ElectronicState>> StateChanged;

                /// <summary>
                ///         引发全局标识改变事件
                /// </summary>
                /// <param name="e">包含事件数据的<see cref="EventArgs" />实例</param>
                protected virtual void OnStateChanged(ValueEventArgs<ElectronicState> e)
                {
                        e.Raise(this, ref StateChanged);
                }

                #endregion
        }
}
