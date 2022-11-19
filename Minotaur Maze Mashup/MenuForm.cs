using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Minotaur_Maze_Mashup
{
	public partial class MenuForm : Form
	{
		public MenuForm()
		{
			InitializeComponent();
		}

		private void btnHelp_Click(object sender, EventArgs e)
		{
			btnLeaderboard.Hide();
			btnModeOne.Hide();
			btnModeTwo.Hide();
			btnHelp.Hide();
			btnReturn.Show();

			txtHelp.Show();
			txtHelp.Text = Utilities.HelpData;
		}

        private void btnModeOne_Click(object sender, EventArgs e)
        {
			GameForm.FormMode = Mode.Build;
			GameForm.Score = 0;
			GameForm.Level = 1;

			Form form = new GameForm();
			form.Show(this);
			this.Hide();
		}
		private void btnModeTwo_Click(object sender, EventArgs e)
		{
			GameForm.FormMode = Mode.Build;
			GameForm.Score = 0;
			GameForm.Level = 2;

			Form form = new GameForm();
			form.Show(this);
			this.Hide();
		}

		private void btnLeaderboard_Click(object sender, EventArgs e)
		{
			btnLeaderboard.Hide();
			btnModeOne.Hide();
			btnModeTwo.Hide();
			btnHelp.Hide();

			lblLeaderboard.Show();
			btnReturn.Show();

			while (tblLeaderboard.Controls.Count > 0)
			{
				tblLeaderboard.Controls[0].Dispose();
			}

			string[] scores = Utilities.GetHighScores();
			if (scores is null)
			{
				return;
			}
			for (int i = 0; i < scores.Length; i++)
			{
				string[] scoreInfo = scores[i].Split(',');
				tblLeaderboard.Controls.Add(new Label() { Anchor = AnchorStyles.Left, Text = scoreInfo[0] }, 2, i);
				tblLeaderboard.Controls.Add(new Label() { Anchor = AnchorStyles.Left, Text = scoreInfo[1] }, 1, i);

				User user = Utilities.LoadFromFileAndDeserialize(Utilities.USERDATA_FILE_PATH)
					.Where(x => x.Username == scoreInfo[1])
					.ToArray()[0];

				tblLeaderboard.Controls.Add(new PictureBox() { Anchor = AnchorStyles.Right, Image = user.Image, Size = new Size(30,30), SizeMode = PictureBoxSizeMode.StretchImage }, 0, i);
			}
			tblLeaderboard.Show();
		}

        private void btnReturn_Click(object sender, EventArgs e)
		{
			btnLeaderboard.Show();
			btnModeOne.Show();
			btnModeTwo.Show();
			btnHelp.Show();

			txtHelp.Hide();
			btnReturn.Hide();
			tblLeaderboard.Hide();
			lblLeaderboard.Hide();
		}

		private void MenuForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			Form frmFeedback = new FeedbackForm();
			frmFeedback.Show();
		}
	}
}
