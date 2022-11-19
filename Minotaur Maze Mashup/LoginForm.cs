using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Windows.Forms;

namespace Minotaur_Maze_Mashup
{
    public partial class LoginForm : Form
    {
		private bool audioState = true;
		private string imageFilepath = null;
		private SoundPlayer audioPlayer = null;
        private Control[] loginControls = null;
		private Control[] registerControls = null;

		public LoginForm()
        {
            InitializeComponent();

			// Assigning form controls to corrosponding arrays
			loginControls = new Control[] 
            {
				pbLogo,
				btnLogin,btnSignUp,
                pbUsername,pbPassword,
                pnlUsername,pnlPassword,
                txtUsername,txtPassword,
            };
			registerControls = new Control[]
			{
				pbUser, pbArrow,
				btnRegister, txtEmail,
				txtForename, txtSurname,
				txtUsernameRegister,txtPasswordRegister,
			};

			// Shift all register controls left 300 pixels
			// this was done to avoid having overlap in the design editor
			foreach (Control c in registerControls)
			{
				c.Location = new Point(c.Location.X - 300, c.Location.Y);
			}
		}

		private void btnSignUp_Click(object sender, EventArgs e)
        {
			ResetAllTextboxes();
			HideAllControls(loginControls);
			ShowAllControls(registerControls);
        }

		private void btnRegister_Click(object sender, EventArgs e)
		{
			User user = new();
			bool valid = true;
			try
			{
				user.Forename = txtForename.Text;

				ForenameError.Dispose();
				ForenameError.Icon = Properties.Resources.correct;
				ForenameError.SetError(txtForename, "Correct");
			}
			catch (InvalidClientException ex)
			{
				valid = false;
				ForenameError.Dispose();
				ForenameError.Icon = Properties.Resources.incorrect;
				ForenameError.SetError(txtForename, ex.DetailedMessage);
			}

			try
			{
				user.Surname = txtSurname.Text;

				SurnameError.Dispose();
				SurnameError.Icon = Properties.Resources.correct;
				SurnameError.SetError(txtSurname, "Correct");
			}
			catch (InvalidClientException ex)
			{
				valid = false;
				SurnameError.Dispose();
				SurnameError.Icon = Properties.Resources.incorrect;
				SurnameError.SetError(txtSurname, ex.DetailedMessage);
			}

			try
			{
				user.Email = txtEmail.Text;

				if (Utilities.FileContainsEmail(Utilities.USERDATA_FILE_PATH, user.Email))
				{
					throw new InvalidClientException("Email already registered", "Email already registered");
				}

				EmailError.Dispose();
				EmailError.Icon = Properties.Resources.correct;
				EmailError.SetError(txtEmail, "Correct");
			}
			catch (InvalidClientException ex)
			{
				valid = false;
				EmailError.Dispose();
				EmailError.Icon = Properties.Resources.incorrect;
				EmailError.SetError(txtEmail, ex.DetailedMessage);
			}

			try
			{
				user.Username = txtUsernameRegister.Text;

				if (Utilities.FileContainsUsername(Utilities.USERDATA_FILE_PATH, user.Username))
				{
					throw new InvalidClientException("Username already taken", "Username already taken");
				}

				UsernameRegisterError.Dispose();
				UsernameRegisterError.Icon = Properties.Resources.correct;
				UsernameRegisterError.SetError(txtUsernameRegister, "Correct");
			}
			catch (InvalidClientException ex)
			{
				valid = false;
				UsernameRegisterError.Dispose();
				UsernameRegisterError.Icon = Properties.Resources.incorrect;
				UsernameRegisterError.SetError(txtUsernameRegister, ex.DetailedMessage);
			}

			try
			{
				user.Password = txtPasswordRegister.Text;

				PasswordRegisterError.Dispose();
				PasswordRegisterError.Icon = Properties.Resources.correct;
				PasswordRegisterError.SetError(txtPasswordRegister, "Correct");
			}
			catch (InvalidClientException ex)
			{
				valid = false;

				PasswordRegisterError.Dispose();
				PasswordRegisterError.Icon = Properties.Resources.incorrect;
				PasswordRegisterError.SetError(txtPasswordRegister, ex.DetailedMessage); 
			}

			if (valid)
			{
				HideAllControls(registerControls);
				ShowAllControls(loginControls);

                if (imageFilepath is not null)
                {
					user.Image = new Bitmap(imageFilepath);
				}
				user.SerializeAndWriteToFile(Utilities.USERDATA_FILE_PATH);
			}
		}

		private void btnLogin_Click(object sender, EventArgs e)
		{
			// Checks if account exists in the binary file
			if (!Utilities.FileContainsUser(Utilities.USERDATA_FILE_PATH, new User(txtUsername.Text, txtPassword.Text)))
			{
				MessageBox.Show("Invalid Login \nIf you do not have an account click Register and create an account");
				return;
			}

			audioPlayer.Stop();

			Utilities.ActiveUsername = txtUsername.Text;
			List<User> users = Utilities.LoadFromFileAndDeserialize(Utilities.USERDATA_FILE_PATH);
			foreach (User user in users)
			{
				if (user.Username == Utilities.ActiveUsername)
				{
					Utilities.UserImage = user.Image;
				}
			}
			// Creates a new instance of the menu form and
			// shows it to the user whilst hiding the login form
			Form form = new MenuForm();
			form.Show();
			this.Hide();
		}

		private void LoginForm_Load(object sender, EventArgs e)
		{
			// Starts playing audio on load
			audioPlayer = new SoundPlayer(Properties.Resources.loginmusic);
			audioPlayer.PlayLooping();
		}

		private void pbMicrophone_Click(object sender, EventArgs e)
		{
			// Starts/Stops the menu audio and adjusts microphone image accordinly
			if (audioState)
			{
				audioPlayer.Stop();
				pbMicrophone.Image = Properties.Resources.microphoneMute;
			}
			else
			{
				audioPlayer.PlayLooping();
				pbMicrophone.Image = Properties.Resources.microphoneUnmute;
			}
			audioState = !audioState;
		}
		private void ShowAllControls(Control[] controls)
		{
			foreach (Control c in controls)
			{
				c.Show();
			}
		}
		private void HideAllControls(Control[] controls)
		{
			foreach (Control c in controls)
			{
				c.Hide();
			}
		}
		private void ResetAllTextboxes()
		{
			// Clear all textbox text
			txtEmail.Text = "";
			txtSurname.Text = "";
			txtUsername.Text = "";
			txtPassword.Text = "";
			txtForename.Text = "";
			txtUsernameRegister.Text = "";
			txtPasswordRegister.Text = "";

			// Clear all error providers
			EmailError.Clear();
			SurnameError.Clear();
			ForenameError.Clear();
			UsernameRegisterError.Clear();
			PasswordRegisterError.Clear();
		}

		private void pbUser_Click(object sender, EventArgs e)
		{
			OpenFileDialog imageFileDialog = new();
			imageFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG";
			imageFileDialog.ShowDialog();

            if (imageFileDialog.FileName != null)
            {
				imageFilepath = imageFileDialog.FileName;
				pbUser.Image = new Bitmap(imageFilepath);
            }
		}

		private void pbArrow_Click(object sender, EventArgs e)
		{
			ResetAllTextboxes();
			HideAllControls(registerControls);
			ShowAllControls(loginControls);
		}
	}
}
