using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotaur_Maze_Mashup.Engines.Minotaur_Objects
{
	class Wall : Sprite, MinotaurObject
	{
		#region Fields
		public int XSpeed = 0;
		public int YSpeed = 0;
		public int XTarget = -1;
		public int YTarget = -1;
		public bool MarkedForDemo = false;
		#endregion

		#region Constructor
		public Wall(int x, int y) : base(x, y)
		{
			Size = 33;
			Image = Properties.Resources.wall;
		}
		#endregion

		#region Methods
		public void Update()
		{
			/// moves wall to target location one pixel at a time
			if (XTarget == X)
			{
				XTarget = -1;
			}
			if (YTarget == Y)
			{
				YTarget = -1;
			}

			if (XTarget is -1)
			{
				XSpeed = 0;
			}
			else if (XTarget < X)
			{
				XSpeed = -1;
			}
			else if (XTarget > X)
			{
				XSpeed = 1;
			}

			if (YTarget is -1)
			{
				YSpeed = 0;
			}
			else if (YTarget < Y)
			{
				YSpeed = -1;
			}
			else if (YTarget > Y)
			{
				YSpeed = 1;
			}

			X += XSpeed;
			Y += YSpeed;

			// warps wall around screen if it goes off
			if (X == 1 + -Size)
			{
				X += CanvasInfo.WIDTH - 2 + 33;
				XTarget += CanvasInfo.WIDTH - 2 + 33;
			}
			if (X == CanvasInfo.WIDTH - 1)
			{
				X -= CanvasInfo.WIDTH - 2 + 33;
				XTarget -= CanvasInfo.WIDTH - 2 + 33;
			}

			if (Y == 1 + -Size)
			{
				Y += CanvasInfo.HEIGHT - 2 + 33;
				YTarget += CanvasInfo.HEIGHT - 2 + 33;
			}
			if (Y == CanvasInfo.HEIGHT - 1)
			{
				Y -= CanvasInfo.HEIGHT - 2 + 33;
				YTarget -= CanvasInfo.HEIGHT - 2 + 33;
			}
		}
		#endregion

		#region Properties
		public Rectangle Hitbox
		{
			get => new Rectangle(X, Y, Size, Size);
		}
		#endregion
	}
	class Bomb : Sprite, MinotaurObject
	{
		#region Fields
		public int Frame = 0;
		#endregion

		#region Constructor
		public Bomb(int x, int y)
		{
			X = x;
			Y = y;
			Size = 24;
		}
		#endregion

		public void Update()
		{
			if (Frame is 13)
			{
				// adds bomb trails in + pattern around the bomb location
				MinotaurEngine.tempObjects.AddRange(new List<BombTrail>()
				{
					new BombTrail(X, Y - (Size * 1), false, Direction.Up),
					new BombTrail(X, Y - (Size * 2), false, Direction.Up),
					new BombTrail(X, Y - (Size * 3), false, Direction.Up),
					new BombTrail(X, Y - (Size * 4), true,  Direction.Up),
					new BombTrail(X, Y + (Size * 1), false, Direction.Down),
					new BombTrail(X, Y + (Size * 2), false, Direction.Down),
					new BombTrail(X, Y + (Size * 3), false, Direction.Down),
					new BombTrail(X, Y + (Size * 4), true,  Direction.Down),

					new BombTrail(X - (Size * 1), Y, false, Direction.Left),
					new BombTrail(X - (Size * 2), Y, false, Direction.Left),
					new BombTrail(X - (Size * 3), Y, false, Direction.Left),
					new BombTrail(X - (Size * 4), Y, true,  Direction.Left),
					new BombTrail(X + (Size * 1), Y, false, Direction.Right),
					new BombTrail(X + (Size * 2), Y, false, Direction.Right),
					new BombTrail(X + (Size * 3), Y, false, Direction.Right),
					new BombTrail(X + (Size * 4), Y, true,  Direction.Right),
				});
			}

			Image = Frame switch
			{
				0 => Properties.Resources.bomb0,
				1 => Properties.Resources.bomb0,
				2 => Properties.Resources.bomb1,
				3 => Properties.Resources.bomb1,
				4 => Properties.Resources.bomb2,
				5 => Properties.Resources.bomb2,
				6 => Properties.Resources.bomb3,
				7 => Properties.Resources.bomb3,
				8 => Properties.Resources.bomb4,
				9 => Properties.Resources.bomb4,
				10 => Properties.Resources.bomb5,
				11 => Properties.Resources.bomb5,
				12 => Properties.Resources.bomb6,
				13 => Properties.Resources.bomb6,
				14 => Properties.Resources.bomb7,
				15 => Properties.Resources.bomb8,
				16 => Properties.Resources.bomb9,
				_ => Properties.Resources.bomb10,
			};
			Frame++;
		}
	}
	class BombTrail : Sprite, MinotaurObject
	{
		#region Fields
		public int Frame = 0;

		private bool IsEnd;
		private Direction Direction;
		#endregion

		#region Constructor
		public BombTrail(int x, int y, bool isEnd, Direction direction)
		{
			X = x;
			Y = y;
			Size = 24;
			IsEnd = isEnd;
			Direction = direction;
		}
		#endregion

		#region Methods
		public void Update()
		{
			Bitmap sprite;
			if (IsEnd)
			{
				sprite = Frame switch
				{
					0 => Properties.Resources.bombTrailEnd1,
					1 => Properties.Resources.bombTrailEnd2,
					2 => Properties.Resources.bombTrailEnd3,
					_ => Properties.Resources.bombTrailEnd4,
				};
			}
			else
			{
				sprite = Frame switch
				{
					0 => Properties.Resources.bombTrail1,
					1 => Properties.Resources.bombTrail2,
					2 => Properties.Resources.bombTrail3,
					_ => Properties.Resources.bombTrail4,
				};
			}

			// rotate image according to direction facing
			switch (Direction)
			{
				case Direction.Up: sprite.RotateFlip(RotateFlipType.Rotate90FlipNone); break;
				case Direction.Down: sprite.RotateFlip(RotateFlipType.Rotate270FlipNone); break;
				case Direction.Right: sprite.RotateFlip(RotateFlipType.Rotate180FlipNone); break;
			}

			// demolish any walls the trail comes in contact with
			foreach (Sprite spr in MinotaurEngine.Objects)
			{
				if (spr is Wall wall)
				{
					Rectangle wallRect = new()
					{
						X = wall.X,
						Y = wall.Y,
						Location = wall.Location,
						Size = new Size(wall.Size, wall.Size),
					};
					Rectangle trailRect = new()
					{
						X = X,
						Y = Y,
						Location = Location,
						Size = new Size(Size, Size),
					};

					if (wallRect.IntersectsWith(trailRect))
					{
						wall.MarkedForDemo = true;
					}
				}
			}

			Frame++;
			Image = sprite;
		}
		#endregion
	}
	class Scroll : Sprite, MinotaurObject
	{
		#region Fields
		public int XSpeed = 0;
		public int YSpeed = 0;
		public int XTarget = -1;
		public int YTarget = -1;
		#endregion

		#region Constructor
		public Scroll(Point location)
		{
			X = location.X;
			Y = location.Y;
			Size = 33;
			Image = Properties.Resources.scroll;
		}
		public Scroll(int x, int y)
		{
			X = x;
			Y = y;
			Size = 33;
			Image = Properties.Resources.scroll;
		}
		#endregion

		#region Properties
		public Rectangle Hitbox
		{
			get => new Rectangle(X, Y, Size, Size);
		}
		public static Bitmap GetAnimationFrame(int frame)
		{
			return frame switch
			{
				0 => Properties.Resources.scroll0,
				1 => Properties.Resources.scroll1,
				2 => Properties.Resources.scroll2,
				3 => Properties.Resources.scroll3,
				4 => Properties.Resources.scroll4,
				5 => Properties.Resources.scroll5,
				6 => Properties.Resources.scroll6,
				7 => Properties.Resources.scroll7,
				8 => Properties.Resources.scroll8,
				_ => Properties.Resources.scroll9,
			};
		}
		#endregion

		#region Methods
		public void Update()
		{
			if (XTarget == X)
			{
				XTarget = -1;
			}
			if (YTarget == Y)
			{
				YTarget = -1;
			}

			if (XTarget is -1)
			{
				XSpeed = 0;
			}
			else if (XTarget < X)
			{
				XSpeed = -1;
			}
			else if (XTarget > X)
			{
				XSpeed = 1;
			}

			if (YTarget is -1)
			{
				YSpeed = 0;
			}
			else if (YTarget < Y)
			{
				YSpeed = -1;
			}
			else if (YTarget > Y)
			{
				YSpeed = 1;
			}

			X += XSpeed;
			Y += YSpeed;
		}
		#endregion
	}
	class Sword : Sprite, MinotaurObject
	{
		#region Fields
		public int XSpeed = 0;
		public int YSpeed = 0;
		public int XTarget = -1;
		public int YTarget = -1;
		#endregion

		#region Constructor
		public Sword(Point location)
		{
			X = location.X;
			Y = location.Y;
			Size = 33;
			Image = Properties.Resources.sword;
		}
		public Sword(int x, int y)
		{
			X = x;
			Y = y;
			Size = 33;
			Image = Properties.Resources.sword;
		}
		#endregion

		#region Properties
		public Rectangle Hitbox
		{
			get => new Rectangle(X, Y, Size, Size);
		}
		#endregion

		#region Methods
		public void Update()
		{
			if (XTarget == X)
			{
				XTarget = -1;
			}
			if (YTarget == Y)
			{
				YTarget = -1;
			}

			if (XTarget is -1)
			{
				XSpeed = 0;
			}
			else if (XTarget < X)
			{
				XSpeed = -1;
			}
			else if (XTarget > X)
			{
				XSpeed = 1;
			}

			if (YTarget is -1)
			{
				YSpeed = 0;
			}
			else if (YTarget < Y)
			{
				YSpeed = -1;
			}
			else if (YTarget > Y)
			{
				YSpeed = 1;
			}

			X += XSpeed;
			Y += YSpeed;
		}
		#endregion
	}
	class Exit : Sprite, MinotaurObject
	{
		#region Fields
		public int XSpeed = 0;
		public int YSpeed = 0;
		public int XTarget = -1;
		public int YTarget = -1;
		#endregion

		#region Constructor
		public Exit(Point location)
		{
			Size = 33;
			X = location.X;
			Y = location.Y;
			Image = Properties.Resources.exit;
		}
		public Exit(int x, int y) : base(x, y)
		{
			Size = 33;
			Image = Properties.Resources.exit;
		}
		#endregion

		#region Methods
		public void Update()
		{
			if (XTarget == X)
			{
				XTarget = -1;
			}
			if (YTarget == Y)
			{
				YTarget = -1;
			}

			if (XTarget is -1)
			{
				XSpeed = 0;
			}
			else if (XTarget < X)
			{
				XSpeed = -1;
			}
			else if (XTarget > X)
			{
				XSpeed = 1;
			}

			if (YTarget is -1)
			{
				YSpeed = 0;
			}
			else if (YTarget < Y)
			{
				YSpeed = -1;
			}
			else if (YTarget > Y)
			{
				YSpeed = 1;
			}

			X += XSpeed;
			Y += YSpeed;

			if (X == 1 + -Size)
			{
				X += CanvasInfo.WIDTH - 2;
				XTarget += CanvasInfo.WIDTH - 2;
			}
			if (X == CanvasInfo.WIDTH - 1)
			{
				X -= CanvasInfo.WIDTH - 2;
				XTarget -= CanvasInfo.WIDTH - 2;
			}

			if (Y == 1 + -Size)
			{
				Y += CanvasInfo.HEIGHT - 2;
				YTarget += CanvasInfo.HEIGHT - 2;
			}
			if (Y == CanvasInfo.HEIGHT - 1)
			{
				Y -= CanvasInfo.HEIGHT - 2;
				YTarget -= CanvasInfo.HEIGHT - 2;
			}
		}
		#endregion

		#region Properties
		public Rectangle Hitbox
		{
			get => new Rectangle(X, Y, Size, Size);
		}
		#endregion
	}
}
