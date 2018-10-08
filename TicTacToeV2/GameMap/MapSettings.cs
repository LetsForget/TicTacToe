using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeV2.GameMap
{
    public class MapSettings
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int CellsNumber { get; private set; }

        public MapSettings(int width, int height)
        {
            Width = width;
            Height = height;
            CellsNumber = Width * Height;
        }
    }
}
