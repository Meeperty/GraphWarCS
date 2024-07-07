using ReactiveUI;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;

namespace GraphWarCS.ViewModels
{
	public class GameLobbyViewModel : ViewModelBase
	{
		public List<Player> Players
		{
			get
			{
				return Players;
			}
		}
		public List<Player> Team1 { get => Players.Where(p => p.Team == 1).ToList(); }
		public List<Player> Team2 { get => Players.Where(p => p.Team == 2).ToList(); }

		private bool isRoomLeader;

		private ClientSideConnection connection;

		public GameLobbyViewModel(string playerName, IPEndPoint roomEndpoint)
		{
			connection = new(playerName, roomEndpoint);
			connection.OnIncomingMessage += HandleMessage;
		}

		public void HandleMessage(HandleMessageEventArgs eventArgs)
		{
			switch (eventArgs.code)
			{
				case NetworkCode.NEW_LEADER:
					isRoomLeader = true;
					break;

				case NetworkCode.ADD_PLAYER:
					{
						int playerID = int.Parse(eventArgs.args[0]);
						string playerName = eventArgs.args[1];
						int team = int.Parse(eventArgs.args[2]);
						bool local = int.Parse(eventArgs.args[3]) != 0;
						int numSoldiers = int.Parse(eventArgs.args[4]);
						bool ready = int.Parse(eventArgs.args[5]) != 0;

						Player player = new(playerID, playerName, team, numSoldiers, ready);
						if (team == 0)
							Debug.WriteLine($"{Utils.CurrentTime} GameLobbyViewModel tried to add player w/ team 0");
						else
							Players.Add(player);
					}
					break;

				case NetworkCode.SET_TEAM:
					{
						int team = int.Parse(eventArgs.args[0]);
						int playerID = int.Parse(eventArgs.args[1]);

						Player? player = GetPlayer(playerID);
						if (player is not null)
						{
							player.Team = team;
							RaisePlayersChanged();
						}
						else
						{
							Debug.WriteLine($"{Utils.CurrentTime} GameLobbyViewModel tried to set team of nonexistent player {playerID}");
							break;
						}
					}
					break;

				case NetworkCode.REMOVE_PLAYER:
					{

					}
					break;

				case NetworkCode.ADD_SOLDIER:
					{

					}
					break;

				case NetworkCode.REMOVE_SOLDIER:
					{

					}
					break;

				case NetworkCode.CHAT_MSG:
					{

					}
					break;

				case NetworkCode.SET_MODE:
					{

					}
					break;

				case NetworkCode.SET_READY:
					{

					}
					break;

				case NetworkCode.START_GAME:
					{

					}
					break;

				case NetworkCode.START_COUNTDOWN:
					{

					}
					break;

				case NetworkCode.REORDER:
					{

					}
					break;
			}
		}

		public Player? GetPlayer(int id)
		{
			return Players.FirstOrDefault(p => p.PlayerID == id);
		}

		private void RaisePlayersChanged()
		{
			this.RaisePropertyChanged(nameof(Players));
			this.RaisePropertyChanged(nameof(Team1));
			this.RaisePropertyChanged(nameof(Team2));
		}
	}
}
