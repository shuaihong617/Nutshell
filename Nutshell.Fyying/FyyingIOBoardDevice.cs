using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Automation;
using Nutshell.Data.Models;
using Nutshell.Extensions;
using Nutshell.Fyying.Models;
using Nutshell.Fyying.SDK;

namespace Nutshell.Fyying
{
	public class FyyingIOBoardDevice : DispatchableDevice
	{
	        #region 字段

		private Task _scanningTask;

		private bool _isScanning;

		#endregion

		[NotifyPropertyValueChanged]
		public int BoardId { get; private set; }

                public IntPtr Handle { get; private set; } = IntPtr.Zero;

	        [NotifyPropertyValueChanged]
	        public int InputChannelsCount { get; private set; } = 4;

                [NotifyPropertyValueChanged]
                public Channel[] InputChannels { get; private set; }

	        [NotifyPropertyValueChanged]
	        public int OutputChannelsCount { get; private set; } = 4;

                [NotifyPropertyValueChanged]
                public Channel[] OutputChannels { get; private set; }

                [NotifyPropertyValueChanged]
		public int ScanningInterval { get; private set; } = 500;


		public override void Load(IIdentityModel model)
		{
			base.Load(model);

			var subModel = model as FyyingIOBoardDeviceModel;
			Trace.Assert(subModel != null);

			BoardId = subModel.BoardId;
			InputChannelsCount = subModel.InputChannelsCount;
			OutputChannelsCount = subModel.OutputChannelsCount;
			ScanningInterval = subModel.ScanningInterval;
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
				this.Warn("未检测到摄像机");
				return false;
			}

                        CreateChannels();

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

		protected override sealed bool StartDispatchCore()
		{
			if (!base.StartDispatchCore())
			{
				return false;
			}

			_isScanning = true;
			_scanningTask = Task.Run(() =>
			{
				for (;;)
				{
					if (!_isScanning)
					{
						break;
					}

					for (var i = 0; i < InputChannelsCount; i++)
					{
                                                InputChannels[i].Read();
					}

					Thread.Sleep(ScanningInterval);
				}
			});

			return true;
		}

		protected override sealed bool StopDispatchCore()
		{
			_isScanning = false;

			return base.StopDispatchCore();
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
                                        InputChannels[i].ValueChanged+= (obj, args) => { OnChannelValueChanged(args); };
                                }
			}

			if (OutputChannels == null)
			{
				OutputChannels = new Channel[OutputChannelsCount];
				for (var i = 0; i < OutputChannelsCount; i++)
				{
					OutputChannels[i] = new Channel(i);
                                        OutputChannels[i].BindToBoardDevice(this);
                                        OutputChannels[i].ValueChanged += (obj, args) => { OnChannelValueChanged(args); };
                                }
			}
		}

		#region 事件

		public event EventHandler<ChannelValueChangedEventArgs> ChannelValueChanged;

		/// <summary>
		///         引发启动事件。
		/// </summary>
		/// <param name="e">包含事件数据的实例<see cref="EventArgs" /></param>
		protected virtual void OnChannelValueChanged(ChannelValueChangedEventArgs e)
			=> e.Raise(this, ref ChannelValueChanged);

		#endregion
	}
}
