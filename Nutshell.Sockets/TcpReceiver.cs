using System.Net.Sockets;
using Nutshell.Sockets.Models;

namespace Nutshell.Sockets
{
	public class TcpReceiver
	{
		private readonly TcpClient _client = new TcpClient();

		public SocketAuthorization Authorization { get; } = new SocketAuthorization();

		public void Connect()
		{
			_client.Connect(Authorization.IPAddress, Authorization.PortNumber);
		}

		public void Send()
		{
			
		}

		public void Receive()
		{
			
		}
	}
}
