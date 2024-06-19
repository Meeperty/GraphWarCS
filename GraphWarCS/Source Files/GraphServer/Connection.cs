using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GraphWarCS
{
	public class Connection
	{
		private Socket socket;

		private long lastRecievedTime;
		private long lastSentTime;
		
		public Connection(string address, int port)
		{
			byte[] addressArr = address.Split('.').Select<string, byte>(x => byte.Parse(x)).ToArray();

			IPAddress addr = new(addressArr);
			IPEndPoint test = new(addr, port);
			socket = new(SocketType.Stream, ProtocolType.Tcp);
			socket.ReceiveTimeout = 10000;
			socket.Bind(test);
			socket.Listen();

			lastRecievedTime = CurrentTimeMillis;
			lastSentTime = CurrentTimeMillis;
		}

		public Connection(Socket socket)
		{
			this.socket = socket;

			socket.ReceiveTimeout = 10000;
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
			NetworkStream stream = new NetworkStream(socket);
			StreamWriter writer = new StreamWriter(stream);

			writer.WriteLine(message);

			writer.Close();
			stream.Close();
		}

		public string ReadMessage()
		{
			string line = "";

			NetworkStream stream = new NetworkStream(socket);
			StreamReader reader = new StreamReader(stream);

			line = reader.ReadLine();

			reader.Close();
			stream.Close();

			return line;
		}


		[DllImport("Kernel32.dll", CallingConvention = CallingConvention.Winapi)]
		private static extern void GetSystemTimePreciseAsFileTime(out long filetime);
		public static long CurrentTimeMillis
		{
			get
			{
				long filetime;
				GetSystemTimePreciseAsFileTime(out filetime);
				DateTime dt = DateTime.FromFileTimeUtc(filetime);
				return (long)(DateTime.UnixEpoch - dt).TotalMilliseconds;
			}
		}
	}
}
