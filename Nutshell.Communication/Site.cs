using System;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Components;
using Nutshell.Messaging;
using Nutshell.Serializing;
using PostSharp.Patterns.Model;
using PostSharp.Serialization;

namespace Nutshell.Communication
{
        /// <summary>
        /// 通讯上下文接口
        /// </summary>
        public sealed class Site:Worker,ISite
        {
                public Site(IdentityObject parent, string id = null) 
                        : base(parent, id)
                {
                }

		/// <summary>
		/// 获取或设置发送者
		/// </summary>
		/// <value>发送者</value>
		[MustNotEqualNull]
	        public ISender Sender { get; set; }

	        public void Send([MustNotEqualNull]byte[] data)
	        {
		        if (Sender == null)
		        {
			        throw new InvalidOperationException();
		        }
		        Sender.Send(data);
	        }


		public event EventHandler<EventArgs> SendSuccessed;
	        public event EventHandler<EventArgs> SendFailed;

		[MustNotEqualNull]
	        public IReceiver Receiver { get; set; }

	        public event EventHandler<ValueEventArgs<byte[]>> ReceiveSuccessed;


	        protected override bool StartCore()
	        {
		        throw new System.NotImplementedException();
	        }

	        protected override bool StopCore()
	        {
		        throw new System.NotImplementedException();
	        }

	        
        }
}
