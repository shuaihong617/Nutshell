using System;
using System.Diagnostics;
using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Automation.IOBoard;
using Nutshell.Data.Models;
using Nutshell.Extensions;
using Nutshell.Fyying.Models;
using Nutshell.Fyying.SDK;

namespace Nutshell.Fyying
{
        public class FyyingIOBoardDevice : IOBoardDevice
        {
                [NotifyPropertyValueChanged]
                public int BoardId { get; private set; }

                public IntPtr Handle { get; private set; } = IntPtr.Zero;

                public override void Load(IIdentityModel model)
                {
                        base.Load(model);

                        var subModel = model as FyyingIOBoardDeviceModel;
                        Trace.Assert(subModel != null);

                        BoardId = subModel.BoardId;
                }

                protected override bool StartConnectCore()
                {
                        if (!base.StartConnectCore())
                        {
                                return false;
                        }

                        Handle = OfficalAPI.FY6400_OpenDevice(BoardId);

                        if (Handle.ToInt32() == -1)
                        {
                                this.Warn($"未检测到{BoardId}号板卡.");
                                return false;
                        }
                        return true;
                }

                protected override sealed bool StopConnectCore()
                {
                        var errorCode = OfficalAPI.FY6400_CloseDevice(Handle);
                        if (errorCode != ErrorCode.失败.ToInt32())
                        {
                                return false;
                        }

                        return base.StopConnectCore();
                }

                public override void CreateChannels()
                {
                        for (var i = 0; i < StandardInputChannelsCount; i++)
                        {
                                if (InputChannels.ContainsKey(i))
                                {
                                        continue;
                                }

                                var channel = new FyyingInputChannel(i);
                                channel.Parent = this;
                                //channel.ValueChanged += (obj, args) => { OnChannelValueChanged(args); };

                                InputChannels.Add(i, channel);
                        }

                        for (var i = 0; i < StandardOutputChannelsCount; i++)
                        {
                                if (OutputChannels.ContainsKey(i))
                                {
                                        continue;
                                }

                                var channel = new FyyingOutputChannel(i);
                                channel.Parent = this;
                                //channel.ValueChanged += (obj, args) => { OnChannelValueChanged(args); };

                                OutputChannels.Add(i, channel);
                        }
                }
        }
}
