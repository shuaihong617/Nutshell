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
		#region 常量

		public const int One = 1;

		public const int Zero = 0;

		#endregion

		#region 字段

		private Task _scanningTask;

		private bool _isScanning;

		#endregion

		[NotifyPropertyValueChanged]
		public int BoardId { get; private set; }

		[NotifyPropertyValueChanged]
		public int InputChannelsCount { get; private set; } = 4;

		[NotifyPropertyValueChanged]
		public int OutputChannelsCount { get; private set; } = 4;

		protected IntPtr Handle { get; private set; } = IntPtr.Zero;

		[NotifyPropertyValueChanged]
		public int ScanningInterval { get; private set; } = 500;

		[NotifyPropertyValueChanged]
		public int[] InputBuffer { get; private set; } = new int[16];

		[NotifyPropertyValueChanged]
		public int[] OutputBuffer { get; private set; } = new int[16];

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

			CreateBuffer();

			Handle = OfficalAPI.FY6400_OpenDevice(BoardId);

			if (Handle.ToInt32() == -1)
			{
				this.Warn("未检测到摄像机");
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
						var result = OfficalAPI.FY6400_DI_Bit(Handle, i);
						if (InputBuffer[i] != result)
						{
							InputBuffer[i] = result;
							OnChannelValueChanged(new ChannelValueChangedEventArgs(i, result == One));
						}
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

		private void CreateBuffer()
		{
			if (InputBuffer == null)
			{
				InputBuffer = new int[InputChannelsCount];
				for (var i = 0; i < InputChannelsCount; i++)
				{
					InputBuffer[i] = Zero;
				}
			}

			if (OutputBuffer == null)
			{
				OutputBuffer = new int[OutputChannelsCount];
				for (var i = 0; i < OutputChannelsCount; i++)
				{
					OutputBuffer[i] = Zero;
				}
			}
		}

		public bool ReadChannel(int channel)
		{
			return OfficalAPI.FY6400_DI_Bit(Handle, channel) == One;
		}

		public void Write(int channel, bool value)
		{
			OfficalAPI.FY6400_DO_Bit(Handle, value ? 1 : 0, channel);
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
