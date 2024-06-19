using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GraphWarCS
{
	public class ClientConnection
	{
		private GraphServer server;

		List<Player> players = new();

		private bool running;
		private bool leader;
		private bool readyNextTurn;
		private bool gameFinished;
		private bool skipLevel;

		private Connection connection;

		public ClientConnection(GraphServer server, Socket socket)
		{
			this.server = server;
			connection = new(socket);
		}

		public void Run()
		{
			running = true;

			while (running)
			{
				string message = connection.ReadMessage();
			}
		}

		public void Disconnect()
		{
			running = false;

			connection.Close();
		}

		public void SendMessage(string message)
		{
			connection.SendMessage(message);
		}

		public void SendKeepAlive()
		{
			connection.SendMessage($"{NetworkConstants.NO_INFO}");
		}
	}
}
