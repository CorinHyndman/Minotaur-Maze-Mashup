using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotaur_Maze_Mashup.Engines.Minotaur_Objects
{
	class Player : Sprite
	{
		#region Fields
		public int Size = 24;
		public int Angle = 0;
		public int Health = 3;
		public int BombCount = 3;
		public bool HasSword = false;
		#endregion

		#region Constructor
		public Player(int x, int y) : base(x,y)
		{
		}
		#endregion

		#region Methods
		public static Bitmap GetAnimationFrame(int frame)
		{
			// returns animation frame based on parameter
			return frame switch
			{
				0 => Properties.Resources.playerDeath1,
				1 => Properties.Resources.playerDeath2,
				2 => Properties.Resources.playerDeath3,
				3 => Properties.Resources.playerDeath4,
				4 => Properties.Resources.playerDeath5,
				5 => Properties.Resources.playerDeath6,
				6 => Properties.Resources.playerDeath7,
				7 => Properties.Resources.playerDeath8,
				8 => Properties.Resources.playerDeath9,
				_ => Properties.Resources.playerDeath10,
			};
		}
		#endregion

		#region Properties
		public new Bitmap Image
		{
			get
			{
				Size heroSize = new(Size, Size);
				Bitmap rotatedHero = new(heroSize.Width, heroSize.Height);
				using (Graphics graphics = Graphics.FromImage(rotatedHero))
				{
					// set pivot point to centre of image
					graphics.TranslateTransform(Size / 2, Size / 2);
					// rotate image by angle
					graphics.RotateTransform(Angle);
					// set pivot back to top left
					graphics.TranslateTransform(-Size / 2, -Size / 2);
					//draws image to the rotated hero bitmap
					graphics.DrawImage(new Bitmap(Properties.Resources.hero, heroSize), 0, 0);
				}
				return rotatedHero;
			}
		}
		public Rectangle Hitbox
		{
			get => new Rectangle(X,Y,Size,Size);
		}
		#endregion
	}
	class Minotaur : Sprite
	{
		#region Fields
		public int Speed = 2;
		public int Size = 48;
		public int Angle = 0;
		public bool Dead = false;
		#endregion

		#region Constructor
		public Minotaur(int x, int y) : base(x, y)
		{
		}
		#endregion

		#region Methods
		public static Bitmap GetAnimationFrame(int frame)
		{
			// returns animation frame based on parameter
			return frame switch
			{
				0 => Properties.Resources.minotaurDeath1,
				1 => Properties.Resources.minotaurDeath2,
				2 => Properties.Resources.minotaurDeath3,
				3 => Properties.Resources.minotaurDeath4,
				4 => Properties.Resources.minotaurDeath5,
				5 => Properties.Resources.minotaurDeath6,
				6 => Properties.Resources.minotaurDeath7,
				7 => Properties.Resources.minotaurDeath8,
				8 => Properties.Resources.minotaurDeath9,
				9 => Properties.Resources.minotaurDeath10,
				10 => Properties.Resources.minotaurDeath11,
				11 => Properties.Resources.minotaurDeath12,
				12 => Properties.Resources.minotaurDeath13,
				13 => Properties.Resources.minotaurDeath14,
				14 => Properties.Resources.minotaurDeath15,
				15 => Properties.Resources.minotaurDeath16,
				16 => Properties.Resources.minotaurDeath17,
				17 => Properties.Resources.minotaurDeath18,
				18 => Properties.Resources.minotaurDeath19,
				_ => Properties.Resources.minotaurDeath20,
			};
		}
		#endregion

		#region Properties
		public new Bitmap Image
		{
			get
			{
				Size minotaurSize = new(Size, Size);
				Bitmap rotatedMinotaur = new(minotaurSize.Width, minotaurSize.Height);
				using (Graphics graphics = Graphics.FromImage(rotatedMinotaur))
				{
					// set pivot point to centre of image
					graphics.TranslateTransform(Size / 2, Size / 2);
					// rotate image by angle
					graphics.RotateTransform(Angle);
					// set pivot back to top left
					graphics.TranslateTransform(-Size / 2, -Size / 2);
					//draws image to the rotated minotaur bitmap
					graphics.DrawImage(new Bitmap(Properties.Resources.minotaur, minotaurSize), 0, 0);
				}
				return rotatedMinotaur;
			}
		}
		public Rectangle Hitbox
		{
			get => new Rectangle(X, Y, Size, Size);
		}
		#endregion
	}
}
