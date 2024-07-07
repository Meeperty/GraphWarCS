using System;
using System.Net;
using System.Runtime.InteropServices;

namespace GraphWarCS
{
	public static class Utils
	{
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
		public static DateTime CurrentTime
		{
			get
			{
				long filetime;
				GetSystemTimePreciseAsFileTime(out filetime);
				return DateTime.FromFileTimeUtc(filetime);
			}
		}

		public static IPEndPoint EndpointFromUrlandPort(string url, string port)
		{
			return new IPEndPoint(Dns.GetHostAddresses(url)[0], int.Parse(port));
		}

		public static IPEndPoint EndPointFromIPandPort(string IP, string port)
		{
			return new IPEndPoint(IPAddress.Parse(IP), int.Parse(port));
		}
	}
}
