using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minotaur_Maze_Mashup
{
    public partial class FeedbackForm : Form
    {
        public FeedbackForm()
        {
            InitializeComponent();
        }

		private void FeedbackForm_FormClosed(object sender, FormClosedEventArgs e)
		{
            // Ensures all other forms are closed upon exiting
            Environment.Exit(0);
        }
	}
}
