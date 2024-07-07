using System.Net;

namespace GraphWarCS
{
	public class Room
	{
		string roomName;
		int roomId;
		IPEndPoint endPoint;
		//List<Player> players = new();
		int playerCount;
		GameMode gameMode = GameMode.NORMAL;

		public string RoomName { get => roomName; }
		public int RoomID { get => roomId; }
		public string Port { get => endPoint.Port.ToString(); }
		public string PlayerCount { get => playerCount.ToString(); }
		public string FormattedPlayerCount { get => $"{playerCount}/{Constants.MAX_PLAYERS}"; }
		public string FormattedGameMode
		{
			get
			{
				switch (gameMode)
				{
					case GameMode.FIRSTDERIV:
						return "y'";
					case GameMode.SECONDDERIV:
						return "y\"";
					default:
						return "y";
				}
			}
		}

		public Room(string name, int roomID, IPEndPoint endpoint, GameMode mode, int players)
		{
			this.roomName = name;
			this.roomId = roomID;
			this.endPoint = endpoint;
			this.gameMode = mode;
			this.playerCount = players;
		}

		public Room(string name)
		{
			this.roomName = name;
			this.roomId = 0;
			this.endPoint = new IPEndPoint(IPAddress.Any, 0);
			this.gameMode = GameMode.NORMAL;
			this.playerCount = 0;
		}

		public void UpdateRoom(GameMode newMode, int newNumPlayers)
		{
			this.gameMode = newMode;
			this.playerCount = newNumPlayers;
		}
	}
}
