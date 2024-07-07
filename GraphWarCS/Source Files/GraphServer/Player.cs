using ReactiveUI;
using System;
using System.Windows.Input;

namespace GraphWarCS
{
	public class Player : ReactiveObject
	{
		public event EventHandler OnSwitchTeams;
		public event EventHandler OnKick;

		public ICommand switchTeamsCommand;
		public ICommand kickCommand;

		public string Name { get; }
		public int NumSoldiers
		{
			get => numSoldiers;
			set => this.RaiseAndSetIfChanged(ref numSoldiers, value);
		}
		public int Team
		{
			get => team;
			set => this.RaiseAndSetIfChanged(ref team, value);
		}
		public int PlayerID { get; }
		public bool Ready { get; }

		private int numSoldiers;
		private int team;

		private static Random random = new Random();

		public Player(string name)
		{
			CreateCommands();

			NumSoldiers = Constants.INITIAL_NUM_SOLDIERS; //Constants.INITIAL_NUM_SOLDIERS
			Team = random.Next(2) + 1; //1 or 2

			this.Name = name;
			PlayerID = -2;
		}

		public Player(int ID, string name, int team, int numSoldiers, bool ready)
		{
			CreateCommands();

			this.PlayerID = ID;
			this.Name = name;
			this.Team = team;
			this.NumSoldiers = numSoldiers;
			this.Ready = ready;
		}

		private void CreateCommands()
		{
			switchTeamsCommand = ReactiveCommand.Create(SwitchTeams);
			kickCommand = ReactiveCommand.Create(Kick);
		}

		public void SwitchTeams()
		{
			Team = Team == 1 ? 2 : 1;
			OnSwitchTeams?.Invoke(this, new());
		}

		public void Kick()
		{
			OnKick?.Invoke(this, new());
		}
	}
}
