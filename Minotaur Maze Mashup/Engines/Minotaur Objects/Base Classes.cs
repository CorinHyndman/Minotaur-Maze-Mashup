using System.Drawing;

namespace Minotaur_Maze_Mashup.Engines.Minotaur_Objects
{
	class Sprite
	{
		#region Fields
		public int X;
		public int Y;
		public int Size;
		public Bitmap Image;
		#endregion

		#region Constructors
		public Sprite() { }
		public Sprite(int x, int y) 
		{
			X = x; 
			Y = y; 
		}
		public Sprite(Bitmap image)
		{
			Image = image;
		}
		public Sprite(int x, int y, Bitmap image)
		{
			X = x; 
			Y = y;
			Image = image;
		}
		#endregion

		#region Properties
		public Point Location
		{
			get => new Point(X, Y);
			set
			{
				X = value.X;
				Y = value.Y;
			}
		}
		#endregion
	}
	interface MinotaurObject
	{
		public void Update();
	}
}
