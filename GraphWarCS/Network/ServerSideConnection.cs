using System.Net.Sockets;

namespace GraphWarCS
{
	public class ServerSideConnection
	{
		private GraphServer server;
		private Connection connection;

		public ServerSideConnection(GraphServer server, Socket acceptedSocket)
		{
			this.server = server;
			this.connection = new Connection(acceptedSocket);
		}

		public void Disconnect()
		{
			connection.Close();
		}

		public void SendMessage(string message)
		{
			connection.SendMessage(message);
		}
	}
}
