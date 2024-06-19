using Avalonia.Controls.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GraphWarCS
{
	public class GraphServer
	{
		private int port;
		private Socket serverSocket;
		private IPEndPoint ipEndPoint;

		private List<ClientConnection> clients = new();
		private List<Player> players = new();
		private bool acceptingConnections;

		private int gameMode;
		private int gameState;
		private bool countingDown;
		private long timeSinceTurnStarted;

		private static Random random = new Random();

		public GraphServer(int port)
		{
			this.port = port;
			ipEndPoint = new(IPAddress.Any, port);
			serverSocket = new Socket(ipEndPoint.AddressFamily, SocketType.Unknown, ProtocolType.Unspecified);
			serverSocket.Bind(ipEndPoint);
			serverSocket.Listen(port);

			acceptingConnections = true;
		}

		public void Run()
		{
			acceptingConnections = true;
			while (acceptingConnections)
			{
				Socket socket = serverSocket.Accept();

				if (acceptingConnections)
				{
					AddClient(socket);
				}
				else
				{
					ClientConnection client = new ClientConnection(this, socket);
					client.SendMessage($"{NetworkConstants.GAME_FULL}");

					client.Disconnect();
				}
			}
		}

		public void AddClient(Socket socket)
		{
			//if (clients.Count < )
		}
	}
}
