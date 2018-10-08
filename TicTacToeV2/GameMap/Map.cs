using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeV2.GameMap
{
    public class Map
    {
        public MapSettings Settings { get; private set; }
        public State[] Cells;

        public Map(int width, int height)
        {
            Settings = new MapSettings(width, height);
            Cells = new State[Settings.CellsNumber];
        }
        public Map Set(int i, State sign)
        {
            Map Temp = new Map(Settings.Width, Settings.Height);
            Cells.CopyTo(Temp.Cells, 0);
            Temp.Cells[i] = sign;
            return Temp;
        }
        private bool CheckHorizontalLine(int i, State player, State enemy)
        {
            for (int j = 0; j < Settings.Width; j++)
                if (Cells[i * Settings.Width + j] == enemy)
                    return false;
            return true;
        }
        public int PossibleHorizontalWins(State player, State enemy)
        {
            int counter = 0;
            for (int i = 0; i < Settings.Height; i++)
                for (int j = 0; j < Settings.Width; j++)
                    if (Cells[i * Settings.Width + j] == player)
                        if (CheckHorizontalLine(i,player,enemy))
                        {
                            counter += 1;
                            break;
                        }
            return counter;            
        }
        private bool CheckVerticalLine(int i, State player, State enemy)
        {
            for (int j = 0; j < Settings.Width; j++)
                if (Cells[j * Settings.Width + i] == enemy)
                    return false;
            return true;
        }
        public int PossibleVerticallWins(State player, State enemy)
        {
            int counter = 0;
            for (int i = 0; i < Settings.Width; i++)
                for (int j = 0; j < Settings.Height; j++)
                    if (Cells[i + j * Settings.Width] == player)
                        if (CheckVerticalLine(i, player, enemy))
                        {
                            counter += 1;
                            break;
                        }
            return counter;
        }
        public State Check()
        {

        }
        public int QuantityOfSpecialCells(State cell)
        {
            return Cells.Where(t => t == cell).Count();
        }
    }
    public enum State
    {
        Toe,
        Tic,
        Tac
    }
}
