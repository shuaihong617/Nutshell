using System.Collections.Generic;
using System.Diagnostics;
using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Automation.IOBoard.Devices.Models;
using Nutshell.Components;
using Nutshell.Data.Models;

namespace Nutshell.Automation.IOBoard.Devices
{
        public abstract class IOBoardDevice : DispatchableDevice
        {
                protected IOBoardDevice()
                {
                        ReadLooper = new ActionLooper(string.Empty, ReadChannels);
                        ReadLooper.Parent = this;
                }

                #region 字段

                #endregion

                [NotifyPropertyValueChanged]
                public int StandardInputChannelsCount { get; private set; } = 4;

                [NotifyPropertyValueChanged]
                public Dictionary<int, InputChannel> InputChannels { get; } = new Dictionary<int, InputChannel>();

                [NotifyPropertyValueChanged]
                public int PracticeInputChannelsCount { get; private set; } = 4;

                [NotifyPropertyValueChanged]
                public int StandardOutputChannelsCount { get; private set; } = 4;

                [NotifyPropertyValueChanged]
                public Dictionary<int, OutputChannel> OutputChannels { get; } = new Dictionary<int, OutputChannel>();

                [NotifyPropertyValueChanged]
                public int PracticeOutputChannelsCount { get; private set; } = 4;

                [NotifyPropertyValueChanged]
                public Looper ReadLooper { get; }


                public override void Load(IIdentityModel model)
                {
                        base.Load(model);

                        var subModel = model as IOBoardDeviceModel;
                        Trace.Assert(subModel != null);

                        StandardInputChannelsCount = subModel.StandardInputChannelsCount;
                        PracticeInputChannelsCount = subModel.PracticeInputChannelsCount;

                        StandardOutputChannelsCount = subModel.StandardOutputChannelsCount;
                        PracticeOutputChannelsCount = subModel.PracticeOutputChannelsCount;

                        ReadLooper.Load(subModel.ReadLooperModel);
                }

                protected override sealed bool StartDispatchCore()
                {
                        if (!base.StartDispatchCore())
                        {
                                return false;
                        }

                        CreateChannels();

                        ReadLooper.Start();

                        return true;
                }

                protected override sealed bool StopDispatchCore()
                {
                        ReadLooper.Stop();

                        return base.StopDispatchCore();
                }

                public abstract void CreateChannels();

                protected void ReadChannels()
                {
                        for (var i = 0; i < PracticeInputChannelsCount; i++)
                        {
                                InputChannels[i].Read();
                        }

                        for (var i = 0; i < PracticeOutputChannelsCount; i++)
                        {
                                OutputChannels[i].Read();
                        }
                }
        }
}
