using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Threading;
using System.Media;
using Minotaur_Maze_Mashup.Engines.Minotaur_Objects;

using static Minotaur_Maze_Mashup.Engines.TetrominoType;

namespace Minotaur_Maze_Mashup.Engines
{
    static class BuildEngine
    {
		#region Fields
		private static Canvas Canvas = new();

		private static int frame = 0;
		private static int updateFrame = 5;
		private static Keys keyPressed;
		private static Random rng = new();
		private static Tetromino tetromino = new();
		private static Tetromino[] tetrominos = LoadTetrominoData();
		private static TetrominoType[,] board = new TetrominoType[CanvasInfo.ROWS, CanvasInfo.COLUMNS];
		private static SoundPlayer lineClearSound = new(Properties.Resources.lineClearSound);
		#endregion

		#region Game Methods
		public static void Update()
		{
			#region GameLogic
			if (frame is 0)
			{
				GameForm.Instructions = "Being one of the greatest inventors in crete you are tasked by King Minos to construct a labryinth to hold the minotaur";
				LoadNewTetromino();
			}

			frame++;
			EraseTetromino(tetromino);
			Point initilialPos = tetromino.Location; // used for checking for gameover

			switch (keyPressed)
			{
				case Keys.Right or Keys.D:
					GameForm.joystickImage = Properties.Resources.joystickRight;
					if (!ValidateTetromino(tetromino: tetromino,
						x: tetromino.X + 1,
						y: tetromino.Y)) // Checks if a tetromino moving one space to the right is valid
					{
						break;
					}
					tetromino.X++;
					break;

				case Keys.Left or Keys.A:
					GameForm.joystickImage = Properties.Resources.joystickLeft;
					if (!ValidateTetromino(tetromino: tetromino,
						x: tetromino.X - 1,
						y: tetromino.Y)) // Checks if a tetromino moving one space to the left is valid
					{
						break;
					}
					tetromino.X--;
					break;

				case Keys.Up or Keys.R:
					GameForm.joystickImage = Properties.Resources.joystickUp;
					if (!ValidTetromino(tetromino: tetromino.CloneAndRotateRight(),
						y: tetromino.Y)) // Checks if a tetromino rotation right is valid
					{
						break;
					}
					tetromino.RotateRight();
					break;

				case Keys.Down: // Increases game speed 
					GameForm.joystickImage = Properties.Resources.joystickDown;
					updateFrame = 1;
					GameForm.Score += 10;
					break;

				default: GameForm.joystickImage = Properties.Resources.joystickNeutral; break;
			}

			// Only moves down a square if the framecount is a multiple of the updateframe
			if (frame % updateFrame is 0)
			{
				// Determines if a piece can freely move down 1 square and does so accordinly
				if (ValidTetromino(tetromino: tetromino, y: tetromino.Y + 1))
				{
					tetromino.Y++;
				}

				// Determines wether the game is over or if a new tetromino piece needs to be loaded
				if (initilialPos == tetromino.Location)
				{
					DrawTetromino(tetromino);

					if (initilialPos.Y is 0)
					{
						// Parses board info and sends to the minotaur engine
						SendBoardInfoToMinotaurEngine();
						// Animate lines 0 - row count [.Range(start,count) returns IEnumerator with 1,2,3...count]
						AnimatePop(Enumerable.Range(0, CanvasInfo.ROWS));
						GameForm.FormMode = Mode.Minotaur;
						return;
					}

					GameForm.Score += 50;
					LoadNewTetromino();
					ClearLinesWithAnimation();
				}
				updateFrame = 5;
			}

			DrawTetromino(tetromino);
			#endregion

			#region Rendering
			Canvas.DrawGrid(CanvasInfo.SQUARE_SIZE);

			// draws board onto canvas
			for (int ri = 0; ri < CanvasInfo.ROWS; ri++)
			{
				for (int ci = 0; ci < CanvasInfo.COLUMNS; ci++)
				{
					if (board[ri,ci] is not Space)
					{
						Color color = board[ri,ci] is Solid ? Color.Gray : Color.SkyBlue;

						Canvas.FillRectangle(
							color,
							x: CanvasInfo.LINE_WIDTH + ci + (CanvasInfo.GRID_SQUARE_SIZE * ci),
							y: CanvasInfo.LINE_WIDTH + ri + (CanvasInfo.GRID_SQUARE_SIZE * ri),
							size: CanvasInfo.SQUARE_SIZE);
					}
				}
			}
			Canvas.Render();
			#endregion
		}
		public static void AnimatePop(IEnumerable<int> lines)
		{
			// slowly decreases block size and moves block location into centre
			// to create this effect : █ -> ■ -> ∙
			for (int size = 0; size <= 32; size += 4)
			{
				Canvas.DrawGrid(CanvasInfo.SQUARE_SIZE);
				for (int ri = 0; ri < CanvasInfo.ROWS; ri++)
				{
					for (int ci = 0; ci < CanvasInfo.COLUMNS; ci++)
					{
						if (board[ri, ci] is not Space)
						{
							Color color = board[ri, ci] is Solid ? Color.Gray : Color.SkyBlue;

							Canvas.FillRectangle(
								color,
								x: CanvasInfo.LINE_WIDTH + ci + (CanvasInfo.GRID_SQUARE_SIZE * ci) + (lines.Contains(ri) ? size / 2 : 0),
								y: CanvasInfo.LINE_WIDTH + ri + (CanvasInfo.GRID_SQUARE_SIZE * ri) + (lines.Contains(ri) ? size / 2 : 0),
								width:  lines.Contains(ri) ? CanvasInfo.GRID_SQUARE_SIZE - size : CanvasInfo.GRID_SQUARE_SIZE,
								height: lines.Contains(ri) ? CanvasInfo.GRID_SQUARE_SIZE - size : CanvasInfo.GRID_SQUARE_SIZE);
						}

					}
					Thread.Sleep(TimeSpan.FromMilliseconds(2));
				}
				Canvas.Render();
			}
		}
		public static void ClearLinesWithAnimation()
		{
			// loops through each row and checks for blocks if no block is found the row is skipped
			// if a row contains only blocks then it is marked for clear
			List<int> toBeCleared = new();
			for (int ri = 0; ri < CanvasInfo.ROWS; ri++)
			{
				bool toClear = true;
				for (int ci = 0; ci < CanvasInfo.COLUMNS; ci++)
				{
					if (board[ri,ci] is TetrominoType.Space)
					{
						toClear = false;
					}
				}
				if (toClear)
				{
					toBeCleared.Add(ri);
				}
			}
			// delete each row marked for clear and move ascending rows down
			if (toBeCleared.Count > 0)
			{
				GameForm.Score += 300;
				lineClearSound.Play();
				AnimatePop(toBeCleared);
				foreach (int row in toBeCleared)
				{
					for (int ci = 0; ci < CanvasInfo.COLUMNS; ci++)
					{
						board[row, ci] = Space;
					}
				}
				foreach (int row in toBeCleared.OrderBy(x => x))
				{
					for (int ri = row; ri-- > 0;)
					{
						SwapLines(ri + 1, ri);
					}
				}
			}			
		}
		public static void SwapLines(int start, int target)
		{
			for (int ci = 0; ci < CanvasInfo.COLUMNS; ci++)
			{
				TetrominoType tmp = board[target, ci];
				board[target, ci] = board[start, ci];
				board[start, ci] = tmp;
			}
		}
		public static void SendBoardInfoToMinotaurEngine()
		{
			// convert board to wall objects
			for (int ri = 0; ri < CanvasInfo.ROWS; ri++)
			{
				for (int ci = 0; ci < CanvasInfo.COLUMNS; ci++)
				{
					if (board[ri,ci] is TetrominoType.Solid)
					{
						MinotaurEngine.Objects.Add(new Wall(
							x: CanvasInfo.LINE_WIDTH + ci + (CanvasInfo.GRID_SQUARE_SIZE * ci),
							y: CanvasInfo.LINE_WIDTH + ri + (CanvasInfo.GRID_SQUARE_SIZE * ri)));
					}
				}
			}
		}
		public static void RestartEngine()
		{
			Canvas = new();
			frame = 0;
			updateFrame = 5;
			rng = new();
			tetromino = new();
			tetrominos = LoadTetrominoData();
			board = new TetrominoType[CanvasInfo.ROWS, CanvasInfo.COLUMNS];
			lineClearSound = new(Properties.Resources.lineClearSound);
		}
		#endregion

		#region Tetromino Methods
		private static void LoadNewTetromino()
		{
			// randomly load a new piece from tetromino file
			tetromino = tetrominos[rng.Next(tetrominos.Length)];
			tetromino.X = 5 + rng.Next(-3, 4);
			tetromino.Y = 0;
			tetromino.Visible = rng.Next(0, 100) < 50;
			while (!ValidateTetromino(tetromino, tetromino.Location.X, tetromino.Location.Y))
			{
				if (tetromino.X == 0)
				{
					break;
				}
				tetromino.X--;
			}
		}
		private static Tetromino[] LoadTetrominoData()
		{
			/// Each tetromino piece is stored in a text file via ascii 
			/// I decided to do this as it allowed be to see each piece as I made it. 
			/// It also allows for easy addition and removal of pieces
			/// This method loads all the ascii from the file and converts it to tetromino objects
			/// Each tetromino class has all the possible rotations of itself stored in a 2D array


			List<Tetromino> allTetrominos = new();
			List<TetrominoType[][,]> allTetrominoData = new();

			string[] rawData = Properties.Resources.TetrominoData.Split(Environment.NewLine + Environment.NewLine);

			for (int i = 0; i < rawData.Length; i++)
			{
				int size = rawData[i].Split(Environment.NewLine).Length;

				string[] currentTetromino = rawData[i].Split(Environment.NewLine);

				List<TetrominoType[,]> allTetrominoRotations = new();
				TetrominoType[,] tetrominos = new TetrominoType[size, size];
				for (int j = 0; j < currentTetromino[0].Split(' ').Length; j++)
				{
					for (int h = 0; h < size; h++)
					{
						for (int w = 0; w < size; w++)
						{
							tetrominos[h, w] = currentTetromino[h][w + j + (j * size)] is '█'
								? Solid
								: Space;
						}
					}
					allTetrominoRotations.Add((TetrominoType[,])tetrominos.Clone());
				}
				allTetrominoData.Add(allTetrominoRotations.ToArray());
			}

			foreach (var data in allTetrominoData)
			{
				allTetrominos.Add(new Tetromino(data));
			}

			return allTetrominos.ToArray();
		}
		private static void DrawTetromino(Tetromino tetromino)
		{
			// writes tetromino blocks to board array
			int size = tetromino.Size;
			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					if (tetromino.TetrominoData[i, j] is TetrominoType.Solid ||
						tetromino.TetrominoData[i, j] is TetrominoType.Invis)
					{
						board[tetromino.Y + i, tetromino.X + j] = tetromino.TetrominoData[i, j];
					}
				}
			}
		}
		private static void EraseTetromino(Tetromino tetromino)
		{
			// removes tetromino blocks from board array
			int size = tetromino.Size;
			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					if (tetromino.TetrominoData[i, j] is TetrominoType.Solid ||
						tetromino.TetrominoData[i, j] is TetrominoType.Invis)
					{
						board[tetromino.Y + i, tetromino.X + j] = TetrominoType.Space;
					}
				}
			}
		}
		private static bool ValidTetromino(Tetromino tetromino, int y)
		{
			// returns true or false depending on whether any blocks
			// in the tetromino intersect with the board at the y offset
			int size = tetromino.Size;
			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					if (tetromino.Location.X < 0 - tetromino.LeftOffset || tetromino.Location.X + tetromino.RightOffset > 11 || y + tetromino.BottomOffset > 14 ||
						(tetromino.TetrominoData[i, j] is TetrominoType.Solid ||
						 tetromino.TetrominoData[i, j] is TetrominoType.Invis) &&
						(board[y + i, tetromino.Location.X + j] is TetrominoType.Solid ||
						 board[y + i, tetromino.Location.X + j] is TetrominoType.Invis))
					{
						return false;
					}
				}
			}
			return true;
		}
		private static bool ValidateTetromino(Tetromino tetromino, int x, int y)
		{
			// returns true or false depending on whether any blocks
			// in the tetromino intersect with the board at the x and y offset
			int size = tetromino.Size;
			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					if (x < 0 - tetromino.LeftOffset || x + tetromino.RightOffset > 11 || y + tetromino.BottomOffset > 14 ||
						(tetromino.TetrominoData[i, j] is TetrominoType.Solid || 
						 tetromino.TetrominoData[i, j] is TetrominoType.Invis) &&
						(board[y + i, x + j] is TetrominoType.Solid ||
						 board[y + i, x + j] is TetrominoType.Invis))
					{
						return false;
					}
				}
			}
			return true;
		}
		#endregion

		#region Bindings
		public static void BindCanvasToForm(Form form)
        {
			RestartEngine();
            form.Controls.Add(Canvas);
		}
		public static void UnBindCanvasToForm(Form form)
		{
			form.Controls.Remove(Canvas);
		}
		public static void BindControlsToForm(Form form)
		{
			form.KeyUp += TEngineKeyUp;
			form.KeyDown += TEngineKeyDown;
		}
		public static void UnBindControlsToForm(Form form)
		{
			form.KeyUp -= TEngineKeyUp;
			form.KeyDown -= TEngineKeyDown;
		}
		private static void TEngineKeyUp(object sender, KeyEventArgs e)
		{
			keyPressed = Keys.None;
		}
		private static void TEngineKeyDown(object sender, KeyEventArgs e)
		{
			keyPressed = e.KeyCode;
		}
		#endregion
	}
	class Tetromino
	{
		#region Fields
		public int X;
		public int Y;

		private int rotation;
		private bool visible;
		private TetrominoType[][,] tetrominoRotationalStates;
		#endregion

		#region Constructors
		public Tetromino() { }
		public Tetromino(TetrominoType[][,] tetrominoData)
		{
			rotation = 0;
			this.tetrominoRotationalStates = tetrominoData;
		}
		#endregion

		#region Properties
		public int Size
		{
			get { return TetrominoData.GetLength(0); }
		}
		public bool Visible
		{
			get { return visible; }
			set
			{
				// loop through all squares and set the solid ones to invis and the invis ones to solid
				visible = value;
				if (!visible)
				{
					foreach (var rotation in tetrominoRotationalStates)
					{
						for (int i = 0; i < Size; i++)
						{
							for (int j = 0; j < Size; j++)
							{
								if (rotation[i, j] is TetrominoType.Solid)
								{
									rotation[i, j] = TetrominoType.Invis;
								}
							}
						}
					}
				}
				else
				{
					foreach (var rotation in tetrominoRotationalStates)
					{
						for (int i = 0; i < Size; i++)
						{
							for (int j = 0; j < Size; j++)
							{
								if (rotation[i, j] is TetrominoType.Invis)
								{
									rotation[i, j] = TetrominoType.Solid;
								}
							}
						}
					}
				}
			}
		}
		public Point Location
		{
			get { return new Point(X, Y); }
		}
		public int LeftOffset
		{
			// get left most x position
			get
			{
				int max = Size;
				for (int i = 0; i < Size; i++)
				{
					for (int offset = 0; offset < Size; offset++)
					{
						if (TetrominoData[i, offset] is not Space)
						{
							if (offset < max)
							{
								max = offset;
							}
						}
					}
				}
				return max;
			}
		}
		public int RightOffset
		{
			// get right most x position
			get
			{
				int max = 0;
				for (int i = 0; i < Size; i++)
				{
					for (int offset = Size - 1; offset > 0; offset--)
					{
						if (TetrominoData[i, offset] is not Space)
						{
							if (offset > max)
							{
								max = offset;
							}
						}
					}
				}
				return max;
			}
		}
		public int BottomOffset
		{
			// get bottom most y position
			get
			{
				int max = 0;
				for (int i = 0; i < Size; i++)
				{
					for (int offset = Size - 1; offset > 0; offset--)
					{
						if (TetrominoData[offset, i] is not Space)
						{
							if (offset > max)
							{
								max = offset;
							}
						}
					}
				}
				return max;
			}
		}
		public TetrominoType[,] TetrominoData
		{
			get { return tetrominoRotationalStates[rotation]; }
		}
		#endregion

		#region Methods
		public void RotateLeft()
		{
			rotation--;
			if (rotation < 0)
			{
				rotation = tetrominoRotationalStates.Length - 1;
			}
		}
		public void RotateRight()
		{
			rotation++;
			if (rotation >= tetrominoRotationalStates.Length)
			{
				rotation = 0;
			}
		}
		public Tetromino CloneAndRotateLeft()
		{
			// create a temp object and rotate it
			Tetromino tmp = (Tetromino)this.MemberwiseClone();
			tmp.RotateLeft();
			return tmp;
		}
		public Tetromino CloneAndRotateRight()
		{
			// create a temp object and rotate it
			Tetromino tmp = (Tetromino)this.MemberwiseClone();
			tmp.RotateRight();
			return tmp;
		}
		#endregion
	}
	enum TetrominoType
	{
		Space,
		Solid,
		Invis,
		NewLine,
	}
}
