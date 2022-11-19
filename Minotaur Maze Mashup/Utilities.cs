using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Minotaur_Maze_Mashup
{
    static class Utilities
	{
		public const string USERDATA_FILE_PATH = "UserData.bin";
        public const string SCORES_FILE_PATH = "Scores.txt";

        public static Image UserImage = null;
		public static string ActiveUsername = null;
		public static string HelpData = Properties.Resources.Help;

		public static void WriteToScoreFile(int score, string name)
		{
			if (!File.Exists(SCORES_FILE_PATH))
			{
				File.Create(SCORES_FILE_PATH).Close();
			}
			File.AppendAllText(SCORES_FILE_PATH, $"{score},{name}" + Environment.NewLine);
		}
		public static string[] GetHighScores()
        {
            if (!File.Exists(SCORES_FILE_PATH))
            {
                File.Create(SCORES_FILE_PATH).Close();
            }
			
            //load scores from file and order based on score
            string[] allScores = File.ReadAllLines(SCORES_FILE_PATH);
			allScores = allScores.OrderByDescending(x => long.Parse(x.Split(',')[0])).ToArray();

			if (allScores.Length < 1)
			{
				return null;
			}

			int range = allScores.Length;
			if (range > 9)
			{
				range = 9;
			}

			// range expression to return top 9 strings from ordered array
			return allScores[0..range];
		}
		public static bool FileContainsUser(string filePath, User user)
		{
			// Loads all users from the binary file
			List<User> allUsers = LoadFromFileAndDeserialize(filePath);

			// Checks if any user in the file has the same username and
			// password as the user passed in through the parameters
			return allUsers.Any(x => x.Username == user.Username && x.Password == user.Password);
		}
		public static bool FileContainsEmail(string filePath, string email)
		{
			// Loads all users from the binary file
			List<User> allUsers = LoadFromFileAndDeserialize(filePath);

			// Checks if any user in the file has the same username and
			// password as the user passed in through the parameters
			return allUsers.Any(x => x.Email == email);
		}
		public static bool FileContainsUsername(string filePath, string name)
		{
			// Loads all users from the binary file
			List<User> allUsers = LoadFromFileAndDeserialize(filePath);

			// Checks if any user in the file has the same username and
			// password as the user passed in through the parameters
			return allUsers.Any(x => x.Username == name);
		}
		public static List<User> LoadFromFileAndDeserialize(string filepath) 
		{
			List<User> users = new();
			using (Stream fileStream = File.Open(filepath, FileMode.OpenOrCreate))
			{
				// This code is placed inside a 'using' block to ensure
				// the filestream is disposed of once no longer nessesary

				// checks if the file is empty if so returns an empty List
				if (fileStream.Length is 0)
				{
					return new List<User>();
				}

				BinaryFormatter binaryFormatter = new BinaryFormatter();
				// Deserialize returns the data from the file as an object which we cast to List<User>
				users = (List<User>)binaryFormatter.Deserialize(fileStream);
			}
			return users;
		}
		public static void SerializeAndWriteToFile(this User user, string filePath)
        {
			// Gets all users already in the file and appends the current user to the list
			List<User> allUsers = Utilities.LoadFromFileAndDeserialize(USERDATA_FILE_PATH);
			allUsers.Add(user);

            using (Stream fileStream = File.OpenWrite(filePath))
            {
				// This code is placed inside a 'using' block to ensure
				// the filestream is disposed of once no longer nessesary
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream, allUsers);
            }
		}
		public static void SerializeAndWriteToFile(this List<User> users, string filePath)
		{
			// Gets all users already in the file and appends the current user to the list
			using (Stream fileStream = File.OpenWrite(filePath))
			{
				// This code is placed inside a 'using' block to ensure
				// the filestream is disposed of once no longer nessesary
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				binaryFormatter.Serialize(fileStream, users);
			}
		}
	}
}
