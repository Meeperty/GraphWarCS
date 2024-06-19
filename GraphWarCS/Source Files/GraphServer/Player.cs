using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphWarCS
{
	public class Player
	{
		public string Name { get; }
		public int NumSoldiers { get; set; }
		public int Team { get; set; }
		public int PlayerID { get; }
		public bool Ready { get; set; }

		private static int lastID = 0;
		private static Random random = new Random();

		public Player(string name)
		{
			NumSoldiers = Constants.INITIAL_NUM_SOLDIERS; //Constants.INITIAL_NUM_SOLDIERS
			Team = random.Next(2) + 1; //1 or 2

			this.Name = name;
			PlayerID = lastID++;
		}
	}
}
