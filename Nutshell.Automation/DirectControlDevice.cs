using System;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Automation.Models;
using Nutshell.Data.Models;
using Nutshell.Hardware;
using Nutshell.Log;
using PostSharp.Patterns.Model;

namespace Nutshell.Automation
{
        [NotifyPropertyChanged]
        public abstract class DirectControlDevice:ControllableDevice
        {
                protected DirectControlDevice(IdentityObject parent, string id = "直接控制设备")
                        : base(parent, id)
                {
                }


                #region 字段

                private bool _isOnline;

                #endregion

                #region 属性

                public RuntimeInformation RuntimeInformation { get; private set; }


                /// <summary>
                ///         设备是否已打开
                /// </summary>
                public bool IsOpened { get; private set; }

                /// <summary>
                ///         是否在线
                /// </summary>
                public bool IsOnline
                {
                        get { return _isOnline; }
                        private set
                        {
                                if (value == _isOnline)
                                {
                                        return;
                                }
                                _isOnline = value;
                                OnPropertyChanged();

                                if (IsOnline)
                                {
                                        OnOnlined(null);
                                }
                                else
                                {
                                        OnOfflined(null);
                                }
                        }
                }

                #endregion

                #region 方法

                public override void Load([AssignableFrom(typeof(IDeviceModel))] IDataModel model)
                {
                        base.Load(model);

                        var deviceModel = model as IDeviceModel;
                        
                }

                protected override sealed bool StartCore()
                {
                        return Open();
                }

                protected override sealed bool StopCore()
                {
                        return Close();
                }

                protected bool Open()
                {
                        if (IsOpened)
                        {
                                return true;
                        }

                        this.Info("运行状态：" + RunMode);

                        IsOpened = OpenCore();
                        return IsOpened;
                }

                protected abstract bool OpenCore();

                protected bool Close()
                {
                        if (!IsOpened)
                        {
                                return true;
                        }
                        IsOpened = !CloseCore();
                        return !IsOpened;
                }

                protected abstract bool CloseCore();

                protected void Online()
                {
                        IsOnline = true;
                }

                protected void Offline()
                {
                        IsOnline = false;
                }

                #endregion

                #region 事件

                /// <summary>
                ///         Occurs when [opened].
                /// </summary>
                public event EventHandler<EventArgs> Onlined;

                /// <summary>
                ///         Raises the <see cref="E:Opened" /> event.
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> Itance containing the event data.</param>
                protected virtual void OnOnlined(EventArgs e)
                {
                        this.InfoEvent("上线");
                        e.Raise(this, ref Onlined);
                }

                /// <summary>
                ///         Occurs when [opened].
                /// </summary>
                public event EventHandler<EventArgs> Offlined;

                /// <summary>
                ///         Raises the <see cref="E:Opened" /> event.
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> Itance containing the event data.</param>
                protected virtual void OnOfflined(EventArgs e)
                {
                        this.InfoEvent("离线");
                        e.Raise(this, ref Offlined);
                }

                /// <summary>
                ///         Occurs when [closed].
                /// </summary>
                protected event EventHandler<EventArgs> OnlineTestFailed;

                /// <summary>
                ///         引发 <see cref="E:Closed" /> 事件.
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> Itance containing the event data.</param>
                protected virtual void OnOnlineTestFailed(EventArgs e)
                {
                        //Close();
                        e.Raise(this, ref OnlineTestFailed);
                }

                #endregion

        }
}
