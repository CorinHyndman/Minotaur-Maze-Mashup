using System.Drawing;
using System.Windows.Forms;

namespace Minotaur_Maze_Mashup
{
	class Canvas : PictureBox
	{
		#region Fields
		private Bitmap buffer { get; set; }
		private Graphics bufferGraphics { get; set; }
		#endregion

		#region Constructor
		public Canvas()
		{
			this.DoubleBuffered = true;
			BackColor = Color.Black;
			Size = new Size(CanvasInfo.WIDTH, CanvasInfo.HEIGHT);
			buffer = new Bitmap(Size.Width,Size.Height);
			Width = buffer.Width;
			Height = buffer.Height;
			Location = new Point(162, 132);
			bufferGraphics = Graphics.FromImage(buffer);
		}
        #endregion

        #region Methods
        public void Render()
		{
			bufferGraphics.Flush();
			this.Image = buffer;
			this.Refresh();
			bufferGraphics.Clear(Color.Black);
		}
		public Bitmap GetCopy()
		{
			return (Bitmap)buffer.Clone();
		}
		public void SetImage(Bitmap img)
		{
			buffer = img;
		}
		#endregion

		#region Drawing
		public void DrawText(string text, Color color, int x, int y)
		{
			bufferGraphics.DrawString(
				text,
				font: new Font("Edwardian Script ITC", 20),
				brush: new SolidBrush(color),
				point: new PointF(x, y));
		}
		public void DrawGrid(Size size)
		{
			int gridWidth = this.Width / size.Width;
			int gridHeight = this.Height / size.Height;

			for (int x = 0; x < gridWidth; x++)
            {
                for (int y = 0; y < gridHeight; y++)
                {
					bufferGraphics.DrawRectangle(
						Pens.White,
						x * (size.Width + 1),
						y * (size.Height + 1),
						1 + size.Width,
						1 + size.Height);
                }
            }
		}
		public void DrawGrid(Size size, Color color)
		{
			int gridWidth = this.Width / size.Width;
			int gridHeight = this.Height / size.Height;

			for (int x = 0; x < gridWidth; x++)
			{
				for (int y = 0; y < gridHeight; y++)
				{
					bufferGraphics.DrawRectangle(
						new Pen(color),
						x * (size.Width + 1),
						y * (size.Height + 1),
						1 + size.Width,
						1 + size.Height);
				}
			}
		}
		public void DrawLine(Point start, Point end)
		{
			bufferGraphics.DrawLine(Pens.Black, start, end);
		}
		public void DrawLine(Color color, Point start, Point end)
		{
			bufferGraphics.DrawLine(new Pen(color), start, end);
		}
		public void DrawLine(int x1, int y1, int x2, int y2)
		{
			bufferGraphics.DrawLine(Pens.Black, x1,y1,x2,y2);
		}
		public void DrawLine(Color color,int x1, int y1, int x2, int y2)
		{
			bufferGraphics.DrawLine(new Pen(color), x1, y1, x2, y2);
		}
		public void DrawImage(Image img, Point point, int size)
		{
			bufferGraphics.DrawImage(img, point.X, point.Y, size, size);
		}
		public void DrawImage(Image img, Point point, Size size)
		{
			bufferGraphics.DrawImage(img, point.X, point.Y, size.Width, size.Height);
		}
		public void DrawImage(Image img, int x, int y, Size size)
		{
			bufferGraphics.DrawImage(img, x, y, size.Width, size.Height);
		}
		public void DrawImage(Image img, int x, int y, int width, int height)
		{
			bufferGraphics.DrawImage(img, x, y, width, height);
		}
		public void DrawRectangle(Color color, Rectangle rectangle)
		{
			bufferGraphics.DrawRectangle(new Pen(color), rectangle);
		}
		public void DrawRectangle(Color color, Point point, Size size)
		{
			bufferGraphics.DrawRectangle(new Pen(color), point.X, point.Y, size.Width, size.Height);
		}
		public void DrawRectangle(Color color, int x, int y, int width, int height)
		{
			bufferGraphics.DrawRectangle(new Pen(color), x, y, width, height);
		}
		public void FillRectangle(Color color, Rectangle rectangle)
		{
			bufferGraphics.FillRectangle(new SolidBrush(color), rectangle);
		}
		public void FillRectangle(Color color, Point point, Size size)
		{
			bufferGraphics.FillRectangle(new SolidBrush(color), point.X, point.Y, size.Width, size.Height);
		}
		public void FillRectangle(Color color, int x, int y, Size size)
		{
			bufferGraphics.FillRectangle(new SolidBrush(color), x, y, size.Width, size.Height);
		}
		public void FillRectangle(Color color, int x, int y, int width, int height)
		{
			bufferGraphics.FillRectangle(new SolidBrush(color), x, y, width, height);
		}
		#endregion
	}
	static class CanvasInfo
    {
		public const int WIDTH = 398;
		public const int HEIGHT = 497;
		public const int ROWS = 15;
		public const int COLUMNS = 12;
		public const int LINE_WIDTH = 1;
		public const int GRID_SQUARE_SIZE = 32;
		public static Size SQUARE_SIZE = new Size(GRID_SQUARE_SIZE, GRID_SQUARE_SIZE);
	}
}
