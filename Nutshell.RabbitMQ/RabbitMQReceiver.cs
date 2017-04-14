using System;
using System.Diagnostics;
using System.Text;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Data;
using Nutshell.Extensions;
using Nutshell.MessageQueue;
using Nutshell.Messaging.Models;
using Nutshell.RabbitMQ.Models;
using Nutshell.Storaging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Nutshell.RabbitMQ
{
        public class RabbitMQReceiver<T>:RabbitMQActor<T>,IMessageQueueReceiver<T>,IStorable<IRabbitMQReceiverModel> where T : IMessageModel
	{

                public RabbitMQReceiver(string id = "") 
			: base( id)
                {
                }


	        private EventingBasicConsumer _consumer;

		[MustNotEqualNull]
		protected RabbitMQQueue Queue { get; private set; }

		public void Load(IRabbitMQReceiverModel model)
		{
			base.Load(model);
		}

		public void Save(IRabbitMQReceiverModel model)
		{
			base.Save(model);
		}

	        /// <summary>
	        /// 执行启动过程的具体步骤.
	        /// </summary>
	        /// <returns>
	        /// 成功返回True, 否则返回False.
	        /// </returns>
	        /// <remarks>
	        /// 若启动过程有多个步骤, 遇到返回错误的步骤立即停止向下执行.
	        /// </remarks>
	        protected override Result StartCore()
	        {
		        var baseResult = base.StartCore();
		        if (!baseResult.IsSuccessed)
		        {
			        return baseResult;
		        }

		        Channel.QueueDeclare(Queue.Name, Queue.IsDurable, Queue.IsExclusive, Queue.IsAutoDelete, null);
			
			_consumer = new EventingBasicConsumer(Channel);
			_consumer.Received += (model, ea) =>
			{
				var body = ea.Body;
				var messageModel = Serializer.Deserialize(body);

				Trace.WriteLine(messageModel.Id);
				
				OnReceiveSuccessed(new ValueEventArgs<T>(messageModel));
			};
			Channel.BasicConsume(Queue.Name,
					     noAck: true,
					     consumer: _consumer);

			return Result.Successed;
	        }


		public void Attach([MustNotEqualNull]RabbitMQQueue queue)
		{
			Queue = queue;
		}

		public event EventHandler<ValueEventArgs<T>> ReceiveSuccessed;

		/// <summary>
		///         引发启动事件。
		/// </summary>
		/// <param name="e">The <see cref="EventArgs" /> Itance containing the event data.</param>
		protected virtual void OnReceiveSuccessed(ValueEventArgs<T> e)
		{
			e.Raise(this, ref ReceiveSuccessed);
		}

		public event EventHandler<ValueEventArgs<Exception>> ReceiveFailed;
        }
}
