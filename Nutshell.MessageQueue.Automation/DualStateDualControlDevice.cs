using System.Diagnostics;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Communication;
using Nutshell.Data;
using Nutshell.Messaging.Models;
using Nutshell.Messaging.Xml.Models;

namespace Nutshell.Automation.MicroDevices
{
	/// <summary>
	///         双态双控设备
	/// </summary>
	/// <remarks>双态双控设备指设备有两种状态（开/关；上/下等）并且可以发送两种指令分别到达某种状态的设备，比如电灯</remarks>
	public abstract class DualStateDualControlDevice : Device
	{
		protected DualStateDualControlDevice(string id)
			: base(id)
		{
			_state.ValueChanged += (obj, args) =>
			{
				if (!args.Value.HasValue)
				{
					return;
				}
				State = args.Value.Value;

				var message = new XmlValueMessageModel<bool>();
				StateSender.Send(message);
			};
		}

		protected readonly ObservableNullable<bool> _state = new ObservableNullable<bool>();

		[NotifyPropertyValueChanged]
		public bool State { get; private set; }

		/// <summary>
		/// 获取状态发送器，状态接收器负责将新状态发送到控制设备
		/// </summary>
		/// <value>状态发送器</value>
		[MustNotEqualNull]
		public ISender<IValueMessageModel<bool>> StateSender { get; private set; }

		/// <summary>
		/// 获取状态接收器，状态接收器负责从执行接收状态
		/// </summary>
		/// <value>状态接收器</value>
		[MustNotEqualNull]
		public IReceiver<IValueMessageModel<bool>> StateReceiver { get; private set; }

		/// <summary>
		/// 获取命令发送器，命令发送器负责将控制命令发送到可以执行的设备
		/// </summary>
		/// <value>命令发送器</value>
		[MustNotEqualNull]
		public ISender<IValueMessageModel<bool>> CommandSender { get; private set; }

		/// <summary>
		/// 获取命令接收器，命令接收器负责从控制设备接收控制命令
		/// </summary>
		/// <value>命令接收器</value>
		[MustNotEqualNull]
		public IReceiver<IValueMessageModel<bool>> CommandReceiver { get; private set; }

		public DualStateDualControlDevice SetStateSender([MustNotEqualNull] ISender<IValueMessageModel<bool>> sender)
		{
			Trace.Assert(StateSender == null);

			StateSender = sender;

			return this;
		}

		public DualStateDualControlDevice SetStateReceiver([MustNotEqualNull] IReceiver<IValueMessageModel<bool>> receiver)
		{
			Trace.Assert(StateSender != null);
			Trace.Assert(StateReceiver == null);

			StateReceiver = receiver;
			receiver.ReceiveSuccessed += (obj, args) =>
			{
				_state.Value = args.Value.Value;
			};
			return this;
		}


		public DualStateDualControlDevice SetCommandReceiver([MustNotEqualNull] IReceiver<IValueMessageModel<bool>> receiver)
		{
			Trace.Assert(CommandReceiver == null);
			CommandReceiver = receiver;
			//receiver.ReceiveSuccessed += (obj, args) => { _state.Value = args.Value.Value; };
			return this;
		}

		public DualStateDualControlDevice SetCommandSender([MustNotEqualNull] ISender<IValueMessageModel<bool>> sender)
		{
			Trace.Assert(CommandReceiver != null);
			Trace.Assert(CommandSender == null);
			
			CommandSender = sender;
			return this;
		}

		
		
	}
}