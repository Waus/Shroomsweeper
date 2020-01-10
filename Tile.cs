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
    public class Tile : PictureBox
    {
        public const int TileLength = 27;

        internal Tile(int x, int y)
        {
            this.Name = $"Tile_{x}_{y}";
            this.Location = new Point(x * TileLength, y * TileLength);
            this.GridPosition = new Point(x, y);
            this.Size = new Size(TileLength, TileLength);
            this.Image = Resources.TileEmpty;
            this.SizeMode = PictureBoxSizeMode.Zoom;
        }

        internal Point GridPosition { get; }
        internal bool IsShroom { get; private set; }
        internal bool IsPoop { get; private set; }
        internal bool IsYou { get; private set; }

        internal void PlaceYou()
        {
            this.IsYou = true;
            this.Image = (Image)Resources.ResourceManager.GetObject("TileWithYou");
        }

        internal void PlaceShroom()
        {
            this.IsShroom = true;
            this.Image = (Image)Resources.ResourceManager.GetObject("TileWithShroom");
        }

        internal void PlacePoop()
        {
            IsPoop = true;
            Image = (Image)Resources.ResourceManager.GetObject("TileWithPoop");
        }

        internal void ResetTileWithPoop()
        {
            IsPoop = false;
            Image = (Image)Resources.ResourceManager.GetObject("TileEmpty");
        }

        internal void EnterNewTile()
        {
            if (IsShroom)
                IsShroom = false;

            if (IsPoop)
                Image = (Image)Resources.ResourceManager.GetObject("TileWithYouDead");

            if (!IsPoop && !TileGrid.GameOver)
                Image = (Image)Resources.ResourceManager.GetObject("TileWithYou");

            if (!IsPoop && TileGrid.GameOver)
                Image = (Image)Resources.ResourceManager.GetObject("TileWithYouWon");

            IsYou = true;
        }

        internal void LeaveOldTile()
        {
            IsYou = false;
            Image = (Image)Resources.ResourceManager.GetObject("TileEmpty");
        }
    }
}
