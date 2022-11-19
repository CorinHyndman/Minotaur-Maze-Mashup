using System;
using System.Diagnostics;

namespace Minotaur_Maze_Mashup
{
	#region Custom Exceptions
	class InvalidGameException : Exception
	{
		public string DetailedMessage { get; set; }
		public InvalidGameException(string message, string detailedMessage) : base(message)
		{
			detailedMessage ??= "No Detailed Message Available";
			DetailedMessage = detailedMessage;
		}
		public void WriteErrorToDebug()
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Debug.WriteLine(Message);
			Debug.WriteLine("Dev Error: " + DetailedMessage);
			Console.ForegroundColor = ConsoleColor.White;
		}
	}
	class InvalidClientException : Exception
	{
		public string DetailedMessage { get; set; }
		public InvalidClientException(string message, string detailedMessage) : base(message)
		{
			detailedMessage ??= "No Detailed Message Available";
			DetailedMessage = detailedMessage;
		}
		public void WriteErrorToDebug()
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Debug.WriteLine(Message);
			Debug.WriteLine("Dev Error: " + DetailedMessage);
			Console.ForegroundColor = ConsoleColor.White;
		}
	}
	class InvalidResourceException : Exception
	{
		public string DetailedMessage { get; set; }
		public InvalidResourceException(string message, string detailedMessage) : base(message)
		{
			detailedMessage ??= "No Detailed Message Available";
			DetailedMessage = detailedMessage;
		}
		public void WriteErrorToDebug()
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Debug.WriteLine(Message);
			Debug.WriteLine("Dev Error: " + DetailedMessage);
			Console.ForegroundColor = ConsoleColor.White;
		}
	}
	#endregion
}
