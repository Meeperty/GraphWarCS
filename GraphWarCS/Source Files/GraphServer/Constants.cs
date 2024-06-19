using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphWarCS
{
	public static class Constants
	{
		public static IBrush bgBrush = new SolidColorBrush(new Color(byte.MaxValue, 158, 215, 155));

		public static int WIDTH = 800;
		public static int HEIGHT = 600;
	
		public static int FIELDS_HEIGHT = 25;
	
		public static int TIMEOUT_CONNECTING = 10000;
		public static int TIMEOUT_KEEPALIVE = 5000;
		public static int TIMEOUT_DROP = 30000;
	
		public static string GLOBAL_IP = "www.graphwar.com";
		public static int DEFAULT_PORT = 6112;
		public static int GLOBAL_PORT = 23761;
		public static int PUBLIC_ROOM_PORT = 28842;
	
		public static string DUMMY_NAME = "23E(S_%24%40)!Xc";
		//public static String ENCODED_DUMMY_NAME = "%23E(S_%24%40)!Xc";
	
		public static int START_GAME_DELAY = 5000;
	
		public static int TURN_TIME = 60000;
	
		public static int MAX_PLAYERS = 10;
		public static int MAX_SOLDIERS_PER_PLAYER = 4;
		public static int MAX_CLIENTS = 10;
		public static int INITIAL_NUM_SOLDIERS = 2;
	
		public static int MAXIMUM_COLOR_MODULE_SQUARED = 3*160*160;
	
		public static int TEAM1 = 1;
		public static int TEAM2 = 2;
	
		public static int NORMAL_FUNC = 0;
		public static int FST_ODE = 1;
		public static int SND_ODE = 2;
	
		public static int PLANE_LENGTH = 770;
		public static int PLANE_HEIGHT = 450;
		public static int PLANE_GAME_LENGTH = 50;
	
		public static int CIRCLE_MEAN_RADIUS = 40;
		public static int CIRCLE_STANDARD_DEVIATION = 25;
		public static int NUM_CIRCLES_MEAN_VALUE = 15;
		public static int NUM_CIRCLES_STANDARD_DEVIATION = 7;
	
		public static int SOLDIER_RADIUS = 7;
		public static int SOLDIER_SELECTION_RADIUS = 15;
		public static int SOLDIER_ANIMATION_DELAY_STANDARD_DEVIATION = 5000;
		public static int SOLDIER_ANIMATION_MEAN_VALUE = 3000;
		public static int SOLDIER_MAX_DEATH_TIME = 6000;
		public static int NAME_FADE_TIME = 1000;
	
		public static int EXPLOSION_RADIUS = 12;
	
		public static int FUNCTION_VELOCITY = 1500;	//steps per second
		public static int FUNC_FADE_TIME = 1000;
		public static int NEXT_TURN_DELAY = 3000;	// Delay after functions hits target to change turn
	
		public static int FUNC_MAX_STEPS = 20000;
		public static double FUNC_MAX_STEP_DISTANCE_SQUARED = 0.001;
		public static double FUNC_MIN_X_STEP_DISTANCE = 0.00001;
		public static double STEP_SIZE = 0.01;	
		public static double ANGLE_STEP_MIN = Math.PI/(20*360);
		public static double ANGLE_STEP_MAX = 0.03;
		public static double ANGLE_FACTOR = 1.2;
		public static double ANGLE_ERROR = Math.PI/360;
		public static int MAX_ANGLE_LOOPS = 100;
	
		public static int RANDOM_TREE_MAX_RAND = 1000;
		public static int RANDOM_TREE_VALUE_VARIABLE_CHANCE = 900;
		public static int RANDOM_TREE_ONE_PARAMETER_CHANCE = 500;
		public static int MAX_AI_RANDOM_DOUBLE = 100;
		public static int NODE_MUTATION_CHANCE = 750;
		public static int MAX_AI_TIME = 2;

		public static double ANGLE_ACCELERATION = 0.000003;
	
		public static int NUM_FUNCTIONS_AI = 50;
		public static int NUM_FUNCTIONS_UNCHANGED_TURN_AI = 5;
		public static int NUM_FUNCTION_MUTATED_AI = 25;
		public static int RANDOM_FUNC_MEAN_LENGTH = 10;
		public static double RANDOM_FUNC_VALUE_CHANCE = 0.5;
		public static double RANDOM_FUNC_VARIABLE_CHANCE = 0.5;
		public static double RANDOM_FUNC_VALUE_MEAN = 10.2;
		public static int RANDOM_FUNC_MEAN_CROSSOVER_LENGTH = 5;
		public static int RANDOM_FUNC_MEAN_MUTATION_LENGTH = 5;
	
		public static string[] computerNames = {"Deep Thought", "HAL", "Skynet", "Agent Smith", "Multivac", "Deep Blue", "Cleverbot", "Alpha Zordon", "Wolfram"};
		public static int COMPUTER_LEVEL_STANDARD_DEVIATION = 40;
		public static int COMPUTER_LEVEL_MEAN_VALUE = 50;
		public static int COMPUTER_LEVEL_MIN_VALUE = 10;
	}

	public enum GameState
	{
		NONE = 0,
		PRE_GAME = 1,
		GAME = 2
	}
}
