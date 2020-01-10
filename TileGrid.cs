using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shroomsweeper.Properties;

namespace Shroomsweeper
{
    public class TileGrid : Panel
    {
        private static readonly Random random = new Random();

        private Size gridSize;
        private int shrooms;
        private int poops;
        public int ShroomsCounter;
        public static bool GameOver;
        private bool disableGame;

        private bool BoardGenerated { get; set; }

        private Point yourPosition;
        private Point[] poopsPositions;
        private Point[] shroomsPositions;

        private static int[][] LegalMovesDirections =
        {
            new[] {0, -1}, new[] {1, 0}, new[] {0, 1}, new[] {-1, 0}
        };

        public Tile this[Point point] => (Tile)this.Controls[$"Tile_{point.X}_{point.Y}"];

        internal void LoadGrid(Size gridSize, int shrooms, int poops)
        {
            Controls.Clear();
            BoardGenerated = false;
            this.gridSize = gridSize;
            this.shrooms = shrooms;
            this.poops = poops;
            ShroomsCounter = 0;
            GameOver = false;
            Size = new Size(gridSize.Width * Tile.TileLength, gridSize.Height * Tile.TileLength);

            for (int x = 0; x < gridSize.Width; x++)
            {
                for (int y = 0; y < gridSize.Height; y++)
                {
                    Tile tile = new Tile(x, y);
                    Controls.Add(tile);
                }
            }

            while (BoardGenerated == false)
            { 
            GenerateBoard();
            }
        }

        private void GenerateBoard()
        {
            disableGame = false;
            shroomsPositions = new Point[shrooms];
            poopsPositions = new Point[poops];

            Point startPosition = new Point(gridSize.Width / 2, gridSize.Height / 2);
            this[startPosition].PlaceYou();
            yourPosition = startPosition;

            int poopsCount = 0;
            Point[] usedPositions = new Point[shrooms + poops + 1];
            usedPositions[shrooms + poops] = startPosition;

            for (int i = poopsCount; i < poops; i++)
            {
                Point point = new Point(random.Next(gridSize.Width), random.Next(gridSize.Height));
                if (!usedPositions.Contains(point))
                {
                    this[point].PlacePoop();
                    usedPositions[i] = point;
                    poopsPositions[i] = point;
                }
                else
                {
                    i--;
                }
            }

            // legal positions for shrooms to make board solvable
            Point[] legalPositionsForShrooms;
            List<Point> NewLegalPositionsForShrooms = new List<Point>();
            List<Point> CurrentLegalPositionsForShrooms = new List<Point>();
            List<Point> LegalPositionsForShrooms = new List<Point>();
            NewLegalPositionsForShrooms.Add(startPosition);
            CurrentLegalPositionsForShrooms.Add(startPosition);

            while (NewLegalPositionsForShrooms.ToArray().Length > 0)
            {
                NewLegalPositionsForShrooms.Clear();
                LegalPositionsForShrooms = LegalPositionsForShrooms.Concat(CurrentLegalPositionsForShrooms).ToList();
                foreach (Point currentLegalPosition in CurrentLegalPositionsForShrooms)
                {
                    foreach (int[] legalMovesDirection in LegalMovesDirections)
                    {
                        Point point = new Point(currentLegalPosition.X + legalMovesDirection[0], currentLegalPosition.Y + legalMovesDirection[1]);
                        if (!poopsPositions.Contains(point) && !LegalPositionsForShrooms.Contains(point) && !NewLegalPositionsForShrooms.Contains(point)
                            && point.X >= 0 && point.X < gridSize.Width && point.Y >= 0 && point.Y < gridSize.Height)
                        {
                            NewLegalPositionsForShrooms.Add(point);
                        }
                    }
                }
                CurrentLegalPositionsForShrooms = NewLegalPositionsForShrooms.ToList();
            }
            LegalPositionsForShrooms = LegalPositionsForShrooms.Concat(CurrentLegalPositionsForShrooms).ToList();
            LegalPositionsForShrooms.RemoveAt(0);
            legalPositionsForShrooms = LegalPositionsForShrooms.ToArray();

            if (legalPositionsForShrooms.Length < shrooms)
            {
                var poopResetCount = 0;
                for (int i = poopResetCount; i < poops; i++)
                {
                    Point point = poopsPositions[i];
                    this[point].ResetTileWithPoop();
                }
                    return;
            }

            int shroomsCount = 0;
            for (int i = shroomsCount; i < shrooms; i++)
            {
                Point point = new Point(random.Next(gridSize.Width), random.Next(gridSize.Height));
                if (!usedPositions.Contains(point) && legalPositionsForShrooms.Contains(point))
                {
                    this[point].PlaceShroom();
                    usedPositions[i + poops] = point;
                    shroomsPositions[i] = point;
                }
                else
                {
                    i--;
                }
            }

            BoardGenerated = true;
            return;
        }

        public void ChangePosition(bool left, bool right, bool up, bool down)
        {
            Point nextPosition;
            if (left && yourPosition.X > 0 && !disableGame)
            {
                nextPosition = new Point(yourPosition.X - 1, yourPosition.Y);
                MoveToNextPosiotion(nextPosition);
            }
            else if (right && yourPosition.X < gridSize.Width - 1 && !disableGame)
            {
                nextPosition = new Point(yourPosition.X + 1, yourPosition.Y);
                MoveToNextPosiotion(nextPosition);
            }
            else if (up && yourPosition.Y > 0 && !disableGame)
            {
                nextPosition = new Point(yourPosition.X, yourPosition.Y - 1);
                MoveToNextPosiotion(nextPosition);
            }
            else if (down && yourPosition.Y < gridSize.Height - 1 && !disableGame)
            {
                nextPosition = new Point(yourPosition.X, yourPosition.Y + 1);
                MoveToNextPosiotion(nextPosition);
            };
        }

        private void MoveToNextPosiotion(Point nextPosition)
        {
            this[yourPosition].LeaveOldTile();
            if (this[nextPosition].IsShroom)
                ShroomsCounter++;
            if (ShroomsCounter == shrooms)
            {
                GameOver = true;
                disableGame = true;
            }
            if (this[nextPosition].IsPoop)
            {
                GameOver = true;
                disableGame = true;
            }
            yourPosition = nextPosition;
            this[yourPosition].EnterNewTile();
        }
    }
}
