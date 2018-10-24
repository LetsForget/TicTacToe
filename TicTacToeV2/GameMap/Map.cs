using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using TicTacToeV2.GameMap.Cells;

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
        public int ReturnQuantityOfCells(ICellable cell)
        {
            return Cells.Where(t => t.State == cell.State).Count();
        }
        public Map CopyThis()
        {
            Map Temp = new Map(Width, Height);
            Cells.CopyTo(Temp.Cells, 0);
            return Temp;
        }
        public Map ReturnChangedMap(int i, ICellable cell)
        {
            Map Temp = CopyThis();
            Temp.Cells[i] = cell;
            return Temp;
        }
        private void Refresh()
        {
            for (int i = 0; i < Cells.Length; i++)
                Cells[i] = new Toe();
        }
        public int ReturnWeight(int lengthtowin,ICellable cell, ICellable enemyCell)
        {
            int cellWins = QuantityOfHorWins(cell, lengthtowin) 
                         + QuantityOfVerWins(cell, lengthtowin)
                         + QuantityOfDiagWins(cell, lengthtowin);
            int enemyWins = QuantityOfHorWins(enemyCell, lengthtowin)
                          + QuantityOfVerWins(enemyCell, lengthtowin)
                          + QuantityOfDiagWins(enemyCell, lengthtowin);
            return (cellWins - enemyWins);
        }
        private int QuantityOfHorWins(ICellable cell, int lengthtowin)
        {
            int counter = 0;
            for (int i = 0; i < Cells.Length; i++)
                counter += ReturnNumberOfHorizWins(i, lengthtowin, cell);
            return counter;
        }
        private int QuantityOfVerWins(ICellable cell, int lengthtowin)
        {
            int counter = 0;
            for (int i = 0; i < Cells.Length; i++)
                counter += ReturnNumberOfVertWins(i, lengthtowin, cell);
            return counter;
        }
        private int QuantityOfDiagWins(ICellable cell, int lengthtowin)
        {
            int counter = 0;
            for (int i = 0; i < Cells.Length; i++)
                counter += ReturnNumberOfDiagWins(i, lengthtowin, cell);
            return counter;
        }
        private int ReturnNumberOfHorizWins(int i, int lengthtowin, ICellable cell)
        {
            if (Cells[i].State != cell.State)
                return 0;
            if (Width - i % Width < lengthtowin)
                return 0;
            for (int j = i; j < i + lengthtowin; j++)
                if (Cells[j].State != cell.State && Cells[j].State != State.Toe)
                    return 0;
            for (int j = i; j < i + lengthtowin; j++)
                if (Cells[j].State == State.Toe)
                    return 1;
            return 999;
        }
        private int ReturnNumberOfVertWins(int i, int lengthtowin, ICellable cell)
        {
            if (Cells[i].State != cell.State)
                return 0;
            if (Height - i / Width < lengthtowin)
                return 0;
            for (int j = i; j < i + lengthtowin * Width; j += Width)
                if (Cells[j].State != cell.State && Cells[j].State != State.Toe)
                    return 0;
            for (int j = i; j < i + lengthtowin * Width; j += Width)
                if (Cells[j].State == State.Toe)
                    return 1;
            return 999;
        }
        private int ReturnNumberOfDiagWins(int i, int lengthtowin, ICellable cell)
        {
            return (ReturnNumberOfLDiagWins(i, lengthtowin, cell) + ReturnNumberOfRDiagWins(i, lengthtowin, cell));
        }
        private int ReturnNumberOfLDiagWins(int i, int lengthtowin, ICellable cell)
        {
            if (Cells[i].State != cell.State)
                return 0;
            if (Width - i % Width < lengthtowin || Height - i / Width < lengthtowin)
                return 0;
            for (int j = i; j < i + lengthtowin * Width + lengthtowin; j += Width + 1)
                if (Cells[j].State != cell.State && Cells[j].State != State.Toe)
                    return 0;
            for (int j = i; j < i + lengthtowin * Width + lengthtowin; j += Width + 1)
                if (Cells[j].State == State.Toe)
                    return 1;
            return 999;
        }
        private int ReturnNumberOfRDiagWins(int i, int lengthtowin, ICellable cell)
        {
            if (Cells[i].State != cell.State)
                return 0;
            if (i % Width - (lengthtowin - 1) < 0 || Height - i / Width < lengthtowin)
                return 0;
            for (int j = i; j < i + lengthtowin * Width - lengthtowin; j += Width - 1)
                if (Cells[j].State != cell.State && Cells[j].State != State.Toe)
                    return 0;
            for (int j = i; j < i + lengthtowin * Width - lengthtowin; j += Width - 1)
                if (Cells[j].State == State.Toe)
                    return 1;
            return 999;
        }
    }
}
