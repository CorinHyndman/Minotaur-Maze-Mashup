using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Minotaur_Maze_Mashup
{
	[Serializable]
	public class User
	{
		#region Fields
		private Bitmap image;
		private string email;
		private string surname;
		private string forename;
		private string username;
		private string password;
		#endregion

		#region Constructors
		public User() { }
		public User(string username, string password)
		{
			this.username = username;
			this.password = password;
		} 
		public User(string forename, string surname, string username, string password, string email)
		{
			this.email = email;
			this.surname = surname;
			this.forename = forename;
			this.username = username;
			this.password = password;
		}
		#endregion

		#region Properties
		public Bitmap Image
		{
			get { return image; }
			set { image = value; }
		}
		public string Email
		{
			get { return email; }
			set
			{
				if (ValidateEmail(value))
				{
					email = value;
				}
				else
				{
					// Throw error if invalid email
				
					throw new InvalidClientException(
						message: "Invalid Email",
						detailedMessage: "Email is not in the format ###@###.###");
				}
			}
		}
		public string Forename
		{
			get { return forename; }
			set
			{
				if (ValidateName(value))
				{
					forename = value;
				}
				else
				{
					// Throw error if invalid forename
				
					throw new InvalidClientException(
						message: "Invalid Forename",
						detailedMessage: "Forename is Null or contains Non-Letters");
				}
			}
		}
		public string Surname
		{
			get { return surname; }
			set
			{
				if (ValidateName(value))
				{
					surname = value;
				}
				else
				{
					// Throw error if invalid surname
				
					throw new InvalidClientException(
						message: "Invalid Surname",
						detailedMessage: "Surname is Null or contains Non-Letters");
				}
			}
		}
		public string Username
		{
			get { return username; }
			set
			{
				if (ValidateUsername(value))
				{
					username = value;
				}
				else
				{
					// Throw error if invalid username

					throw new InvalidClientException(
						message: "Invalid Username",
						detailedMessage: "Username is Null or contains Non-Digit/Letter Characters");
				}
			}
		}
		public string Password
		{
			get { return password; }
			set
			{
				if (ValidatePassword(value))
				{
					password = value;
				}
				else
				{
					// Throw error if invalid password

					throw new InvalidClientException(
						message: "Invalid Password",
						detailedMessage: "Password must contain [#,!,@] and be between 8 - 15");
				}
			}
		}
		#endregion

		#region Validation Methods
		private bool ValidatePassword(string input)
		{
			char[] specialCharacters = { '#', '!', '@' };
			if (!string.IsNullOrEmpty(input) && // Check for null input
				8 <= input.Length && input.Length <= 15 && // Range check between 8 - 15 inclusive
				input.Any(x => specialCharacters.Contains(x)) && // Checks if any of the characters are contained in the specialCharacters array
				input.All(x => specialCharacters.Contains(x) || char.IsLetterOrDigit(x))) // Checks if all the characters are either a letter or a digit
			{
				return true;
			}
			return false;
		}
		private bool ValidateEmail(string email)
		{
			string emailPattern = null;

			// First we check if there are 3-64 '{3,64}' of any character '.' followed by a @ character '[@]'
			emailPattern += ".{3,64}[@]";

			// We then check if there are 3-64 '{3,64}' of any character '.' followed by a full stop character '[.]'
			emailPattern += ".{3,64}[.]";

			// Finally we check if there are 3-64 '{3,64}' of any character '.' remaining in the string
			emailPattern += ".{3,64}";

			// We can then check if the email input matches the pattern we have created;
			return Regex.IsMatch(email, emailPattern);
		}

		private bool ValidateUsername(string name) => 
			!string.IsNullOrEmpty(name) &&  // Check for null input
			name.All(c => char.IsLetterOrDigit(c)); // Checks if all characters are either a letter or a digit

		private bool ValidateName(string name) => 
			!string.IsNullOrEmpty(name) && // Check for null input
			name.All(c => char.IsLetter(c)); // Checks if all characters are letters
		#endregion
	}
}
