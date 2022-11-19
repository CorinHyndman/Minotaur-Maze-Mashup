using System;
using System.Drawing;
using System.Windows.Forms;
using Minotaur_Maze_Mashup.Engines;

namespace Minotaur_Maze_Mashup
{
    public partial class GameForm : Form
    {
		public static int Level = 1;
		public static int Score = 0;
		public static int Health = 3;
		public static bool Won = false;
		public static Image joystickImage;
		public static bool scrollActive = false;
		public static Mode FormMode = Mode.Build;
		public static string Instructions = "Being one of the greatest inventors in crete you are tasked by King Minos to construct a labryinth to hold the minotaur";
        public GameForm()
        {
            InitializeComponent();
        }

		private void GameClock_Tick(object sender, EventArgs e)
		{
			lblInstructions.Text = Instructions;
			lblScore.Text = $"Score: {Score}";

			pbJoystick.Image = joystickImage;
			pbScrollArrow.Visible = scrollActive;

			if (Health >= 3)
			{
				pbThirdLife.Show();
				pbSecondLife.Show();
				pbFirstLife.Show();
			}
			if (Health <  3)
			{
				pbThirdLife.Hide();
			}
			if (Health <  2)
			{
				pbSecondLife.Hide();
			}
			if (Health <  1)
			{ 
				pbFirstLife.Hide();
			}
			if (Health is 0)
			{
				FormMode = Mode.GameOver;
			}

			if (FormMode is Mode.Build)
			{
				GameClock.Interval = 100;
				BuildEngine.Update();
				if (FormMode is not Mode.Build)
				{
					BuildEngine.UnBindCanvasToForm(this);
					BuildEngine.UnBindControlsToForm(this);

					lblLives.Show();
					pbFirstLife.Show();
					pbSecondLife.Show();
					pbThirdLife.Show();
				}
			}
			else if (FormMode is Mode.Minotaur)
			{
				GameClock.Interval = 33;
				MinotaurEngine.Update();
			}
			else if (FormMode is Mode.GameOver)
            {

				this.Owner.Show();
				Utilities.WriteToScoreFile(Score, Utilities.ActiveUsername);
				this.Close();
			}
		}
        private void GameForm_Load(object sender, EventArgs e)
        {
			BuildEngine.BindCanvasToForm(this);
			BuildEngine.BindControlsToForm(this);
			MinotaurEngine.BindCanvasToForm(this);
			MinotaurEngine.BindControlsToForm(this);
		}
		private void pbScrollArrow_Click(object sender, EventArgs e)
		{
			scrollActive = false;
			MinotaurEngine.removeScroll = true;			
		}
	}
	public enum Mode
	{
		Default,
		Build,
		Minotaur,
		GameOver,
	}
}
