using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace GraphWarCS
{
	public delegate void HandleMessage(HandleMessageEventArgs messageHandlerArgs);

	public class ClientSideConnection
	{
		private Connection connection;

		private bool running;
		private Thread runThread;

#pragma warning disable IDE0044 // Add readonly modifier
		private Timer keepAliveTimer;
#pragma warning restore IDE0044 // Add readonly modifier

		public event HandleMessage? OnIncomingMessage;
		public event EventHandler<bool>? OnDisconnect;

		/// <summary>
		/// Connects to the global server with the given name
		/// </summary>
		/// <param name="playerName"></param>
		public ClientSideConnection(string playerName)
		{
			runThread = new Thread(Run);
			runThread.Start();

			connection = new Connection(Constants.GlobalServerEndPoint);

			SendMessage(playerName);

			keepAliveTimer = new Timer(SendKeepAlive, null, TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(5));
		}

		public ClientSideConnection(string playerName, IPEndPoint endpoint)
		{
			runThread = new Thread(Run);
			runThread.Start();

			connection = new Connection(endpoint);

			SendMessage(playerName);

			keepAliveTimer = new Timer(SendKeepAlive, null, TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(5));
		}

		public void Run()
		{
			running = true;

			while (running)
			{
				if (connection is null)
					continue;

				string? incomingMessage = connection.ReadMessage();

				if (incomingMessage is not null)
				{
					Debug.WriteLine($"{Utils.CurrentTime} before message dispatch on {incomingMessage}");
					Task.Factory.StartNew(
						DispatchMessage,
						state: incomingMessage);
				}
				else
				{
					Debug.WriteLine($"{Utils.CurrentTime} ClientSideConnection disconnected due to lack of message");
					Disconnect(true);
				}
			}
		}

		public void DispatchMessage(object param)
		{
			string fullMessage = (string)param;
			Debug.WriteLine($"{Utils.CurrentTime} ClientSideConnection recieved raw message {fullMessage}");
			string[] messages = fullMessage.Split('\n');
			HandleMessageEventArgs[] handlerArgs = new HandleMessageEventArgs[messages.Length];

			foreach (string partialMessage in messages)
			{
				string[] sections = partialMessage.Split("&");

				NetworkCode code = (NetworkCode)Enum.Parse(typeof(NetworkCode), sections[0]);

				HandleMessageEventArgs handlerArg = new(code, sections.Skip(1).ToArray());

				Debug.WriteLine($"{Utils.CurrentTime} ClientSideConnection recieved " +
					$"code {code} with " +
					$"args {string.Join("&", sections)}");
				if (code != NetworkCode.KEEP_ALIVE)
					OnIncomingMessage?.Invoke(handlerArg);
			}
		}

		public void Disconnect(bool lostConnection = false)
		{
			if (!lostConnection)
				SendMessage($"{NetworkCode.DISCONNECT}");

			running = false;
			connection.Close();

			OnDisconnect?.Invoke(this, lostConnection);
		}

		private void SendKeepAlive(object? state)
		{
			SendMessage($"{(int)NetworkCode.KEEP_ALIVE}");
		}

		public void SendMessage(string message)
		{
			connection.SendMessage(message);
		}
	}
}
