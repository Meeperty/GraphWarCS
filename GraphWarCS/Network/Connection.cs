using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Web;

namespace GraphWarCS
{
	public class Connection
	{
		private Socket socket;

		private const int receiveTimeout = 10000;

		public Connection(IPEndPoint endpoint)
		{
			socket = new(SocketType.Stream, ProtocolType.Tcp);
			socket.ReceiveTimeout = receiveTimeout;
			socket.Connect(endpoint);
		}

		public Connection(Socket socket)
		{
			this.socket = socket;

			socket.ReceiveTimeout = receiveTimeout;
		}

		~Connection()
		{
			Close();
		}

		public void Close()
		{
			socket.Close();
		}

		public void SendMessage(string message)
		{
			string encoded = HttpUtility.UrlEncode(message);
			Debug.WriteLine($"{Utils.CurrentTime} Connection encoded {message} as {encoded}");

			NetworkStream stream = new NetworkStream(socket);
			StreamWriter writer = new StreamWriter(stream);

			writer.WriteLine(encoded);

			writer.Close();
			stream.Close();
		}

		public string? ReadMessage()
		{
			//NetworkStream stream = new NetworkStream(socket);
			////StreamReader reader = new StreamReader(stream);

			//line = reader.ReadLine();

			//reader.Close();
			//stream.Close();

			byte[] rawBuffer = new byte[1024];
			int bytesRecieved = socket.Receive(rawBuffer);

			if (bytesRecieved == 0) { return null; }

			string line = Encoding.ASCII.GetString(rawBuffer, 0, bytesRecieved);
			line = line.TrimEnd('\n');
			line = HttpUtility.UrlDecode(line);

			Debug.WriteLine($"{Utils.CurrentTime} Connection receiving {line}");

			return line;
		}
	}
}
