using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

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
