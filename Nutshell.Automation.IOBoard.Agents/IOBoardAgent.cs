using System;
using System.Diagnostics;
using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Data.Models;
using Nutshell.Extensions;

namespace Nutshell.Automation.IOBoard.Agents
{
        public class IOBoardAgent : IdentityObject
        {
                #region 字段

                #endregion

                [NotifyPropertyValueChanged]
                public int InputChannelsCount { get; private set; } = 4;

                [NotifyPropertyValueChanged]
                public InputChannel[] InputChannels { get; private set; }

                [NotifyPropertyValueChanged]
                public int OutputChannelsCount { get; private set; } = 4;

                [NotifyPropertyValueChanged]
                public OutputChannel[] OutputChannels { get; private set; }

                public override void Load(IIdentityModel model)
                {
                        base.Load(model);

                        var subModel = model as FyyingIOBoardDeviceModel;
                        Trace.Assert(subModel != null);

                        InputChannelsCount = subModel.InputChannelsCount;
                        OutputChannelsCount = subModel.OutputChannelsCount;
                        ScanningInterval = subModel.ScanningInterval;
                }


                private void CreateChannels()
                {
                        if (InputChannels == null)
                        {
                                InputChannels = new Channel[InputChannelsCount];
                                for (var i = 0; i < InputChannelsCount; i++)
                                {
                                        InputChannels[i] = new Channel(i);
                                        InputChannels[i].BindToBoardDevice(this);
                                        InputChannels[i].ValueChanged += (obj, args) => { OnChannelValueChanged(args); };
                                }
                        }

                        if (OutputChannels == null)
                        {
                                OutputChannels = new Channel[OutputChannelsCount];
                                for (var i = 0; i < OutputChannelsCount; i++)
                                {
                                        OutputChannels[i] = new Channel(i);
                                        OutputChannels[i].BindToBoardDevice(this);
                                        OutputChannels[i].ValueChanged +=
                                                (obj, args) => { OnChannelValueChanged(args); };
                                }
                        }
                }

                #region 事件

                public event EventHandler<ChannelValueEventArgs> ChannelValueChanged;

                /// <summary>
                ///         引发启动事件。
                /// </summary>
                /// <param name="e">包含事件数据的实例<see cref="EventArgs" /></param>
                protected virtual void OnChannelValueChanged(ChannelValueEventArgs e)
                        => e.Raise(this, ref ChannelValueChanged);

                #endregion
        }
}
