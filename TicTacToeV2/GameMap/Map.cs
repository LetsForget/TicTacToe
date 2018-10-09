using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace TicTacToeV2.GameMap
{
    public class Map
    {
        public int Width;
        public int Height;
        public ICellable[] Cells;

        public Map(int width, int height)
        {
            Width = width;
            Height = height;
            Cells = new ICellable[Width * Height];
            Refresh();
        }
        public Map ReturnChangedMap(int i, ICellable cell)
        {
            Map Temp = new Map(Width, Height);
            Cells.CopyTo(Temp.Cells, 0);
            Temp.Cells[i] = cell;
            return Temp;
        }
        private void Refresh()
        {
            for (int i = 0; i < Cells.Length; i++)
                Cells[i] = new Tac();
        }         
        //public int PossibleHorizontalWins(ICellable player)
        //{
        //    for (int i = 0; i < Height; i++)
        //        for (int j = 0; j < Width; j++)
        //            if (Cells[i * Width + j].State == player.State)
        //}
        //private bool CheckHorizontalLine()
        //{

        //}
    }
}
