using Avalonia.Media;

namespace GraphWarCS
{
	public class ChatItem
	{
		public int PlayerID { get; }
		public string PlayerName { get; }
		public string Message { get; }

		public ChatItem(int id, string message, string name)
		{
			this.PlayerID = id;
			this.Message = message;
			this.PlayerName = name;
		}
	}
}
