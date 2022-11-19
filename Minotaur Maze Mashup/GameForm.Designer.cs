
namespace Minotaur_Maze_Mashup
{
    partial class GameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.GameClock = new System.Windows.Forms.Timer(this.components);
            this.lblScore = new System.Windows.Forms.Label();
            this.lblLives = new System.Windows.Forms.Label();
            this.pbFirstLife = new System.Windows.Forms.PictureBox();
            this.pbSecondLife = new System.Windows.Forms.PictureBox();
            this.pbThirdLife = new System.Windows.Forms.PictureBox();
            this.pbJoystick = new System.Windows.Forms.PictureBox();
            this.pbScrollArrow = new System.Windows.Forms.PictureBox();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.lblInstruction = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbFirstLife)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSecondLife)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbThirdLife)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbJoystick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbScrollArrow)).BeginInit();
            this.SuspendLayout();
            // 
            // GameClock
            // 
            this.GameClock.Enabled = true;
            this.GameClock.Tick += new System.EventHandler(this.GameClock_Tick);
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.BackColor = System.Drawing.Color.Transparent;
            this.lblScore.ForeColor = System.Drawing.SystemColors.Control;
            this.lblScore.Location = new System.Drawing.Point(162, 634);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(42, 15);
            this.lblScore.TabIndex = 0;
            this.lblScore.Text = "Score: ";
            // 
            // lblLives
            // 
            this.lblLives.AutoSize = true;
            this.lblLives.BackColor = System.Drawing.Color.Transparent;
            this.lblLives.ForeColor = System.Drawing.SystemColors.Control;
            this.lblLives.Location = new System.Drawing.Point(446, 634);
            this.lblLives.Name = "lblLives";
            this.lblLives.Size = new System.Drawing.Size(36, 15);
            this.lblLives.TabIndex = 1;
            this.lblLives.Text = "Lives:";
            // 
            // pbFirstLife
            // 
            this.pbFirstLife.BackColor = System.Drawing.Color.Transparent;
            this.pbFirstLife.Image = global::Minotaur_Maze_Mashup.Properties.Resources.heart;
            this.pbFirstLife.Location = new System.Drawing.Point(483, 634);
            this.pbFirstLife.Name = "pbFirstLife";
            this.pbFirstLife.Size = new System.Drawing.Size(16, 16);
            this.pbFirstLife.TabIndex = 2;
            this.pbFirstLife.TabStop = false;
            this.pbFirstLife.Visible = false;
            // 
            // pbSecondLife
            // 
            this.pbSecondLife.BackColor = System.Drawing.Color.Transparent;
            this.pbSecondLife.Image = global::Minotaur_Maze_Mashup.Properties.Resources.heart;
            this.pbSecondLife.Location = new System.Drawing.Point(505, 634);
            this.pbSecondLife.Name = "pbSecondLife";
            this.pbSecondLife.Size = new System.Drawing.Size(16, 16);
            this.pbSecondLife.TabIndex = 3;
            this.pbSecondLife.TabStop = false;
            this.pbSecondLife.Visible = false;
            // 
            // pbThirdLife
            // 
            this.pbThirdLife.BackColor = System.Drawing.Color.Transparent;
            this.pbThirdLife.Image = global::Minotaur_Maze_Mashup.Properties.Resources.heart;
            this.pbThirdLife.Location = new System.Drawing.Point(527, 633);
            this.pbThirdLife.Name = "pbThirdLife";
            this.pbThirdLife.Size = new System.Drawing.Size(16, 16);
            this.pbThirdLife.TabIndex = 4;
            this.pbThirdLife.TabStop = false;
            this.pbThirdLife.Visible = false;
            // 
            // pbJoystick
            // 
            this.pbJoystick.BackColor = System.Drawing.Color.Transparent;
            this.pbJoystick.Image = global::Minotaur_Maze_Mashup.Properties.Resources.joystickNeutral;
            this.pbJoystick.Location = new System.Drawing.Point(279, 683);
            this.pbJoystick.Name = "pbJoystick";
            this.pbJoystick.Size = new System.Drawing.Size(175, 109);
            this.pbJoystick.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbJoystick.TabIndex = 5;
            this.pbJoystick.TabStop = false;
            // 
            // pbScrollArrow
            // 
            this.pbScrollArrow.BackColor = System.Drawing.Color.Transparent;
            this.pbScrollArrow.Image = global::Minotaur_Maze_Mashup.Properties.Resources.scrollArrow;
            this.pbScrollArrow.Location = new System.Drawing.Point(413, 529);
            this.pbScrollArrow.Name = "pbScrollArrow";
            this.pbScrollArrow.Size = new System.Drawing.Size(55, 30);
            this.pbScrollArrow.TabIndex = 6;
            this.pbScrollArrow.TabStop = false;
            this.pbScrollArrow.Visible = false;
            this.pbScrollArrow.Click += new System.EventHandler(this.pbScrollArrow_Click);
            // 
            // lblInstructions
            // 
            this.lblInstructions.BackColor = System.Drawing.Color.White;
            this.lblInstructions.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblInstructions.Location = new System.Drawing.Point(40, 469);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(82, 149);
            this.lblInstructions.TabIndex = 7;
            this.lblInstructions.Text = "Being one of the greatest inventors in crete you are tasked by King Minos to cons" +
    "truct a labryinth to hold the minotaur";
            this.lblInstructions.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblInstruction
            // 
            this.lblInstruction.AutoSize = true;
            this.lblInstruction.BackColor = System.Drawing.Color.White;
            this.lblInstruction.Font = new System.Drawing.Font("Gadugi", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblInstruction.Location = new System.Drawing.Point(42, 451);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(80, 17);
            this.lblInstruction.TabIndex = 8;
            this.lblInstruction.Text = "Instructions";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Minotaur_Maze_Mashup.Properties.Resources.gameBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(734, 881);
            this.Controls.Add(this.lblInstruction);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.pbScrollArrow);
            this.Controls.Add(this.pbJoystick);
            this.Controls.Add(this.pbThirdLife);
            this.Controls.Add(this.pbSecondLife);
            this.Controls.Add(this.pbFirstLife);
            this.Controls.Add(this.lblLives);
            this.Controls.Add(this.lblScore);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(750, 920);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(750, 868);
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.GameForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbFirstLife)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSecondLife)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbThirdLife)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbJoystick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbScrollArrow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

		#endregion
		private System.Windows.Forms.Timer GameClock;
		private Canvas Display;
		private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblLives;
        private System.Windows.Forms.PictureBox pbFirstLife;
        private System.Windows.Forms.PictureBox pbSecondLife;
        private System.Windows.Forms.PictureBox pbThirdLife;
        private System.Windows.Forms.PictureBox pbJoystick;
		private System.Windows.Forms.PictureBox pbScrollArrow;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Label lblInstruction;
	}
}