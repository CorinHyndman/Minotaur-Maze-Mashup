using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Threading;
using System.Windows.Forms;
using Minotaur_Maze_Mashup.Engines.Minotaur_Objects;

namespace Minotaur_Maze_Mashup.Engines
{
    static class MinotaurEngine
	{
		private readonly static string[] SCROLLTEXT =
		{
			"The Minotaur in Greek\nmythology is said to be a fabulous\nmonster of Crete, that had the\nbody of a man and the head\nof a bull. It was the offspring of\nPasiphae, the wife of Minos,\nand a snow-white bull sent to\nMinos by the god Poseidon\nfor sacrifice.",
			"Minos, instead of sacrificing\n it, kept it alive Poseidon\n as a punishment made\nPasiphae fall in love with it.\nHer child by the bull was shut up in\nthe Labyrinth created for\nMinos by Daedalus.",
			"A son of Minos, Androgeos, was\n later killed by the Athenians;\nto avenge his death, Minos de\nmanded that seven Athenians\nyouths and seven maidens should\nbe sent every ninth year to be\ndevoured by the Minotaur.",
			"When the third time of\nsacrifice came, the Athenian\nhero Theseus volunteered to go,\nand, with the help of Ariadne,\ndaughter of Minos and\nPasiphae, he killed the monster and\nended the tribute.",
			"In most accounts Ariadne\ngave him a ball of thread,\nallowing him to retrace his path.\nAccording to various\nClassical sources and\nrepresentations, Theseus killed\nthe Minotaur with\nhis bare hands,\nhis club, or a sword.",
			"He neglected to put up the\nwhite sail. King Aegeus,\nfrom his lookout on Cape\nSounion, saw the\nblack-sailed ship approach\nand, presuming his son dead,\ncommitted suicide by throwing\nhimself into the sea that\nis since named after him.\nThis act secured the\nthrone for Theseus.",
		};

		#region Fields
		private static Canvas Canvas = new();
		private static int walkSpeed = 2;

		public static int scrollCount = 0;
		public static bool removeScroll = false;
		public static Player Player = new(34,34);
		public static Minotaur Minotaur = new(331,331);
		public static List<Sprite> Objects = new();
		public static List<Sprite> tempObjects = new();

		private static bool up    = false;
		private static bool down  = false;
		private static bool left  = false;
		private static bool right = false;
		private static bool space = false;

		private static int frame = 0;
		private static int wallMovementFrames = 100;
		private static int invincibilityFrames = 0;
		private static bool wallMoving;
		private static bool startScroll = false;
		private static Random rng = new();
		private static Keys keyPressed = Keys.None;
		private static SoundPlayer audioPlayer = null;
		#endregion

		public static void Update()
		{
			List<Point> emptyLocations = GetEmptyPlayerLocations();

			// frame 0 is the start of the game
			if (frame is 0)
			{
				GameForm.Instructions = "To avoid having having more death you have volunteered to slay the Minotaur with the help of  Minos' daughter Ariadne.";
				
				// place scrolls in open spaces around the map
				for (int i = 0; i < 3 * GameForm.Level; i++)
				{
					emptyLocations = GetEmptyPlayerLocations();
					Objects.Add(new Scroll(emptyLocations[rng.Next(0, emptyLocations.Count)]));

					emptyLocations = GetEmptyPlayerLocations();
					Player.Location = emptyLocations[rng.Next(0, emptyLocations.Count)];

					List<Point> minotaurPositions = GetEmptyMinotaurLocations();
					Minotaur.Location = minotaurPositions[rng.Next(0, minotaurPositions.Count)];
				}
			}

			invincibilityFrames--;
			wallMovementFrames--;
			frame++;

			// slowly set walkspeed to 2
			if (walkSpeed > 2)
			{
				walkSpeed--;
			}

			// show scroll opening animation
			if (startScroll)
			{
				for (int i = 0; i < 10; i++)
				{
					Canvas.DrawImage(Scroll.GetAnimationFrame(i), 0, 0, Canvas.Size);
					Thread.Sleep(TimeSpan.FromMilliseconds(150));
					Canvas.Render();
				}
				GameForm.scrollActive = true;
				startScroll = false;
				return;
			}

			// show scroll with text until the user clicks the arrow
			if (GameForm.scrollActive)
			{
				Canvas.DrawImage(Scroll.GetAnimationFrame(9), 0, 0, Canvas.Size);
				Canvas.DrawText(SCROLLTEXT[scrollCount], Color.Black, 80, 80);
				Canvas.Render();
				return;
			}

			// show scroll being rolled up
			if (removeScroll)
			{
				for (int i = 10; i-- > 0;)
				{
					Canvas.DrawImage(Scroll.GetAnimationFrame(i), 0, 0, Canvas.Size);
					Thread.Sleep(TimeSpan.FromMilliseconds(150));
					Canvas.Render();
				}
				removeScroll = false;
				scrollCount++;
				return;
			}

			#region Player
			GameForm.joystickImage = Properties.Resources.joystickNeutral;
			// boolean flags used as winforms does not support multiple keypresses at a time
			// so each keypress event interacts with these bools instead
			if (up)
			{
				Player.Y -= walkSpeed;
				if (PlayerCollidesWithWall() || PlayerIsOutOfBounds())
				{
					Player.Y += walkSpeed;
				}

				if (Player.Angle > -90 && Player.Angle < 90)
				{
					Player.Angle += 45;
				}
				else if (Player.Angle != 90)
				{
					Player.Angle -= 45;
				}
				GameForm.joystickImage = Properties.Resources.joystickUp;
			}
			if (down)
			{
				Player.Y += walkSpeed;
				if (PlayerCollidesWithWall() || PlayerIsOutOfBounds())
				{
					Player.Y -= walkSpeed;
				}

				if (Player.Angle > -90 && Player.Angle < 90)
				{
					Player.Angle -= 45;
				}
				else if (Player.Angle != -90)
				{
					Player.Angle += 45;
				}
				GameForm.joystickImage = Properties.Resources.joystickDown;
			}
			if (left)
			{
				Player.X -= walkSpeed;
				if (PlayerCollidesWithWall() || PlayerIsOutOfBounds())
				{
					Player.X += walkSpeed;
				}

				if (Player.Angle < 0)
				{
					Player.Angle += 45;
					if (down && Player.Angle != -45)
					{
						Player.Angle -= 45;
					}
				}
				else if (Player.Angle > 0)
				{
					Player.Angle -= 45;
					if (up && Player.Angle != 45)
					{
						Player.Angle += 45;
					}
				}
				GameForm.joystickImage = Properties.Resources.joystickLeft;
			}
			if (right)
			{
				Player.X += walkSpeed;
				if (PlayerCollidesWithWall() || PlayerIsOutOfBounds())
				{
					Player.X -= walkSpeed;
				}

				if (Player.Angle >= 0 && Player.Angle < 180)
				{
					Player.Angle += 45;
					if (up && Player.Angle != 135)
					{
						Player.Angle -= 45;
					}
				}
				else if (Player.Angle < 0 && Player.Angle > -180)
				{
					Player.Angle -= 45;
					if (down && Player.Angle != -135)
					{
						Player.Angle += 45;
					}
				}
				GameForm.joystickImage = Properties.Resources.joystickRight;
			}
			if (space)
			{
				if (Player.BombCount > 0)
				{
					Objects.Add(new Bomb(Player.X,Player.Y));
					Player.BombCount--;
				}
				space = false;
			}

			// making sure player angle doesn't overflow past 180 / -180
			if (Player.Angle > 180)
			{
				Player.Angle -= 360;
			}
			if (Player.Angle < -180)
			{
				Player.Angle += 360;
			}
			#endregion

			#region Minotaur
			// if minotaur has not been killed yet update logic otherwise hide him offscreen
			if (!Minotaur.Dead)
			{
				if (Minotaur.Hitbox.IntersectsWith(Player.Hitbox))
				{
					if (Player.HasSword)
					{
						Minotaur.Dead = true;
						GameForm.Score += 1000;
						for (int i = 0; i < 20; i++)
						{
							Canvas.DrawImage(Minotaur.GetAnimationFrame(i), 0, 0, Canvas.Size);
							Thread.Sleep(TimeSpan.FromMilliseconds(150));
							Canvas.Render();
						}
					}
					else if (invincibilityFrames <= 0)
					{
						Player.Health--;
						walkSpeed = 10;
						invincibilityFrames = 50;
					}
				}

				if (Player.Y < Minotaur.Y)
				{
					Minotaur.Y -= Minotaur.Speed;
					if (MinotaurCollidesWithWall())
					{
						Minotaur.Y += Minotaur.Speed;
					}
					Minotaur.Angle = 90;
					if (Player.X < Minotaur.X)
					{
						Minotaur.Angle -= 45;
					}
					if (Player.X > Minotaur.X)
					{
						Minotaur.Angle += 45;
					}
				}
				if (Player.Y > Minotaur.Y)
				{
					Minotaur.Y += Minotaur.Speed;
					if (MinotaurCollidesWithWall())
					{
						Minotaur.Y -= Minotaur.Speed;
					}
					Minotaur.Angle = -90;
					if (Player.X < Minotaur.X)
					{
						Minotaur.Angle += 45;
					}
					if (Player.X > Minotaur.X)
					{
						Minotaur.Angle -= 45;
					}
				}
				if (Player.X < Minotaur.X)
				{
					Minotaur.X -= Minotaur.Speed;
					if (MinotaurCollidesWithWall())
					{
						Minotaur.X += Minotaur.Speed;
					}
				}
				if (Player.X > Minotaur.X)
				{
					Minotaur.X += Minotaur.Speed;
					if (MinotaurCollidesWithWall())
					{
						Minotaur.X -= Minotaur.Speed;
					}
				}

				foreach (Sprite spr in Objects)
				{
					if (spr is Wall wall)
					{
						Rectangle wallRect = new()
						{
							X = spr.X,
							Y = spr.Y,
							Location = spr.Location,
							Size = new Size(spr.Size, spr.Size),
						};

						if (wallRect.IntersectsWith(Minotaur.Hitbox))
						{
							wall.MarkedForDemo = true;
						}
					}
				}
			}
            else
            {
				Minotaur.Location = new Point(-500,-500);
            }
			#endregion

			// shift walls near minotaur every 50 frames
			if (wallMovementFrames < 0)
			{
				ShiftRow(Minotaur.Y / 33 + rng.Next(-2, 3), rng.Next(1,4));
				wallMovementFrames = 100;
			}
			if (wallMovementFrames is 50)
			{				
				ShiftColumn(Minotaur.X / 33 + rng.Next(-2, 3), rng.Next(1, 4));
			}

			// add exit once all scrolls are found
			if (scrollCount == 3 * GameForm.Level && !Objects.Any(x => x is Exit) && !wallMoving)
			{
				emptyLocations = GetEmptyPlayerLocations();
				Objects.Add(new Exit(emptyLocations[rng.Next(0, emptyLocations.Count)]));

				if (GameForm.Level is 2)
				{
					emptyLocations = GetEmptyPlayerLocations();
					Objects.Add(new Sword(emptyLocations[rng.Next(0, emptyLocations.Count)]));
				}
			}

			// templist used as foreach loops enumerator cannot be changed mid loop
			if (tempObjects is not null)
			{
				Objects.AddRange(tempObjects);
				tempObjects.Clear();
			}

			// loop through all objects that inherit from the MinotaurObject Interface and call .Update()
			foreach (MinotaurObject obj in Objects.Where(x => x is MinotaurObject))
			{
				obj.Update();
				if (obj is Wall wall)
				{
					Rectangle wallRect = new()
					{
						X = wall.X,
						Y = wall.Y,
						Location = wall.Location,
						Size = new Size(wall.Size, wall.Size),
					};

					if (Player.Hitbox.IntersectsWith(wallRect))
					{
						Player.X += wall.XSpeed;
						Player.Y += wall.YSpeed;
					}
					if (Minotaur.Hitbox.IntersectsWith(wallRect))
					{
						Minotaur.X += wall.XSpeed;
						Minotaur.Y += wall.YSpeed;
					}
				}
				if (obj is Sword sword)
				{
					if (sword.X < 0 || sword.X > CanvasInfo.WIDTH ||
						sword.Y < 0 || sword.Y > CanvasInfo.HEIGHT ||
						Objects.Any(x => x is Wall && x.Location == sword.Location))
					{
						emptyLocations = GetEmptyPlayerLocations();

						sword.XSpeed = 0;
						sword.YSpeed = 0;
						sword.XTarget = -1;
						sword.YTarget = -1;
						sword.Location = emptyLocations[rng.Next(0, emptyLocations.Count)];
					}
				}
				if (obj is Scroll scroll)
				{
					if (scroll.X < 0 || scroll.X > CanvasInfo.WIDTH - scroll.Size ||
						scroll.Y < 0 || scroll.Y > CanvasInfo.HEIGHT - scroll.Size ||
						Objects.Any(x => x is Wall && x.Location == scroll.Location))
					{
						emptyLocations = GetEmptyPlayerLocations();

						scroll.XSpeed = 0;
						scroll.YSpeed = 0;
						scroll.XTarget = -1;
						scroll.YTarget = -1;
						scroll.Location = emptyLocations[rng.Next(0, emptyLocations.Count)];
					}
				}
			}

			wallMoving = // Check if any walls or scrolls are moving
				Objects.Any(x => x is Wall wall && (wall.XTarget != -1 || wall.YTarget != -1)) ||
				Objects.Any(x => x is Sword sword && (sword.XTarget != -1 || sword.YTarget != -1)) ||
				Objects.Any(x => x is Scroll scroll && (scroll.XTarget != -1 || scroll.YTarget != -1));

			// avoid user getting stuck in the wall whilst walls are moving
			if (PlayerCollidesWithWall() || PlayerIsOutOfBounds())
			{
				Player.Location = emptyLocations[rng.Next(0, emptyLocations.Count)];
			}

			GameForm.Health = Player.Health;

			if (Player.Health is 0)
			{
				audioPlayer = new SoundPlayer(Properties.Resources.deathNoise);
				audioPlayer.Play();
				for (int i = 0; i < 10; i++)
				{
					Canvas.DrawImage(Player.GetAnimationFrame(i), 0, 0, Canvas.Size);
					Thread.Sleep(TimeSpan.FromMilliseconds(150));
					Canvas.Render();
				}
				return;
			}
			// Deleting unused objects from list
			for (int i = Objects.Count; i-- > 0;)
			{
				if (i >= 0)
				{
					if (Objects[i] is Wall wall)
					{
						if (wall.MarkedForDemo)
						{
							Objects.RemoveAt(i);
							i--;
						}
					}
				}
				if (i >= 0)
				{
					if (Objects[i] is Bomb bomb)
					{
						if (bomb.Frame > 17)
						{
							Objects.RemoveAt(i);
							i--;
						}
					}
				}
				if (i >= 0)
				{
					if (Objects[i] is BombTrail bombTrail)
					{
						if (bombTrail.Frame > 2)
						{
							Objects.RemoveAt(i);
							i--;
						}
					}
				}
				if (i >= 0)
				{
					if (Objects[i] is Scroll scroll)
					{
						if (Player.Hitbox.IntersectsWith(scroll.Hitbox) && startScroll is false)
						{
							GameForm.Score += 200;
							startScroll = true;
							Objects.RemoveAt(i);
							i--;
						}
					}
				}
				if (i >= 0)
				{
					if (Objects[i] is Exit exit)
					{
						if (Player.Hitbox.IntersectsWith(exit.Hitbox))
						{
							GameForm.FormMode = Mode.GameOver;
							return;
						}
					}
				}
				if (i >= 0)
				{
					if (Objects[i] is Sword sword)
					{
						if (Player.Hitbox.IntersectsWith(sword.Hitbox))
						{
							Player.HasSword = true;
							Objects.RemoveAt(i);
							i--;
						}
					}
				}
			}

			#region Rendering
			// draws all walls,player and any other objects to canvas
			Canvas.DrawRectangle(Color.Gray, 0, 0, Canvas.Width - 1, Canvas.Height - 1);
			foreach (Sprite obj in Objects)
			{
				Canvas.DrawImage(obj.Image, obj.Location, obj.Size);
			}

			Canvas.DrawImage(Player.Image, Player.Location, Player.Size);
			Canvas.DrawImage(Minotaur.Image, Minotaur.Location, Minotaur.Size);
			Canvas.Render();
			#endregion
		}
		private static bool PlayerIsOutOfBounds()
		{
			return
				Player.X < 1 || Player.X > CanvasInfo.WIDTH - Player.Size ||
				Player.Y < 1 || Player.Y > CanvasInfo.HEIGHT - Player.Size;
		}
		private static bool PlayerCollidesWithWall()
		{
			foreach (Sprite wall in Objects)
			{
				if (wall is Wall)
				{
					Rectangle wallRect = new()
					{
						X = wall.X,
						Y = wall.Y,
						Location = wall.Location,
						Size = new Size(wall.Size, wall.Size),
					};

					if (wallRect.IntersectsWith(Player.Hitbox))
					{
						return true;
					}
				}
			}
			return false;
		}
		private static bool MinotaurCollidesWithWall()
		{
			foreach (Sprite wall in Objects)
			{
				if (wall is Wall)
				{
					Rectangle wallRect = new()
					{
						X = wall.X,
						Y = wall.Y,
						Location = wall.Location,
						Size = new Size(wall.Size, wall.Size),
					};

					if (wallRect.IntersectsWith(Minotaur.Hitbox))
					{
						return true;
					}
				}
			}
			return false;
		}
		private static List<Point> GetEmptyPlayerLocations()
		{
			// returns any empty positions on the board that the player sprite can fit
			List<Point> emptyLocations = new();
			for (int x = 0; x < (CanvasInfo.WIDTH - 2) / 33; x++)
			{
				for (int y = 0; y < (CanvasInfo.HEIGHT - 2) / 33; y++)
				{
					if (!Objects.Any(o => o.X == 1 + (x * 33) && o.Y == 1 + (y * 33)))
					{
						emptyLocations.Add(new Point(1 + (x * 33), 1 + (y * 33)));
					}
				}
			}
			return emptyLocations;
		}
		private static List<Point> GetEmptyMinotaurLocations()
		{
			// returns any empty positions on the board that the minotaur sprite can fit
			List<Point> emptyLocations = new();
			for (int x = 0; x < (CanvasInfo.WIDTH - 2) / 33; x++)
			{
				for (int y = 0; y < (CanvasInfo.HEIGHT - 2) / 33; y++)
				{
					bool valid = true;
					Rectangle checkRect = new(1 + (x * 33), 1 + (y * 33), Minotaur.Size, Minotaur.Size);
					foreach (Sprite wall in Objects)
					{
						if (wall is Wall)
						{
							Rectangle wallRect = new()
							{
								X = wall.X,
								Y = wall.Y,
								Location = wall.Location,
								Size = new Size(wall.Size, wall.Size),
							};

							if (checkRect.IntersectsWith(wallRect) || checkRect.IntersectsWith(Player.Hitbox))
							{
								valid = false;
							}
						}
					}
					if (valid)
					{
						emptyLocations.Add(new Point(1 + (x * 33), 1 + (y * 33)));
					}
				}
			}
			return emptyLocations;
		}
		private static void ShiftRow(int row, int offset)
		{
			// sets each wall in that rows new target position to wall position + offset
			foreach (Wall wall in Objects.Where(x => x is Wall))
			{
				if (wall.Y == 1 + row * wall.Size && 
					wall.XSpeed is 0 && wall.YSpeed is 0 &&
					wall.XTarget is -1 && wall.YTarget is -1)
				{
					wall.XTarget = wall.X + (wall.Size * offset);
				}
			}
			foreach (Scroll scroll in Objects.Where(x => x is Scroll))
			{
				if (scroll.Y == 1 + row * scroll.Size && 
					scroll.XSpeed is 0 && scroll.YSpeed is 0 &&
					scroll.XTarget is -1 && scroll.YTarget is -1)
				{
					scroll.XTarget = scroll.X + (scroll.Size * offset);
				}
			}
		}
		private static void ShiftColumn(int col, int offset)
		{
			// sets each wall in that columns new target position to wall position + offset
			foreach (Wall wall in Objects.Where(x => x is Wall))
			{
				if (wall.X == 1 + col * wall.Size && 
					wall.XSpeed is 0 && wall.YSpeed is 0 &&
					wall.XTarget is -1 && wall.YTarget is -1)
				{
					wall.YTarget = wall.Y + (wall.Size * offset);
				}
			}
			foreach (Scroll scroll in Objects.Where(x => x is Scroll))
			{
				if (scroll.X == 1 + col * scroll.Size &&
					scroll.XSpeed is 0 && scroll.YSpeed is 0 &&
					scroll.XTarget is -1 && scroll.YTarget is -1)
				{
					scroll.YTarget = scroll.Y + (scroll.Size * offset);
				}
			}
		}
		public static void RestartEngine()
		{
			Canvas = new();
			walkSpeed = 2;
			scrollCount = 0;
			Player = new(34, 34);
			Minotaur = new(331, 331);
			Objects = new();
			tempObjects = new();

			up = false;
			down = false;
			left = false;
			right = false;
			space = false;
			frame = 0;
			wallMoving = false;
			keyPressed = Keys.None;
			audioPlayer = null;
			GameForm.Health = 3;
		}

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
			form.KeyUp += MEngineKeyUp;
			form.KeyDown += MEngineKeyDown;
		}
		public static void UnBindControlsToForm(Form form)
		{
			form.KeyUp -= MEngineKeyUp;
			form.KeyDown -= MEngineKeyDown;
		}
		private static void MEngineKeyUp(object sender, KeyEventArgs e)
		{
			keyPressed = Keys.None;

			// falsify input flags
			if (e.KeyCode is Keys.Up || e.KeyCode is Keys.W)
			{
				up = false;
			}
			if (e.KeyCode is Keys.Down || e.KeyCode is Keys.S)
			{
				down = false;
			}
			if (e.KeyCode is Keys.Left || e.KeyCode is Keys.A)
			{
				left = false;
			}
			if (e.KeyCode is Keys.Right || e.KeyCode is Keys.D)
			{
				right = false;
			}
		}
		private static void MEngineKeyDown(object sender, KeyEventArgs e)
		{
			keyPressed = e.KeyCode;

			// seting input flags
			if (e.KeyCode is Keys.Up || e.KeyCode is Keys.W)
			{
				up = true;
			}
			if (e.KeyCode is Keys.Down || e.KeyCode is Keys.S)
			{
				down = true;
			}
			if (e.KeyCode is Keys.Left || e.KeyCode is Keys.A)
			{
				left = true;
			}
			if (e.KeyCode is Keys.Right || e.KeyCode is Keys.D)
			{
				right = true;
			}
			if (e.KeyCode is Keys.Space)
			{
				space = true;
			}
		}
		#endregion
	}
	enum Direction
	{
		Up,Down,
		Left,Right
	}
}