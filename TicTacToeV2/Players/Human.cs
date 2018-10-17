using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeV2.GameMap;

namespace TicTacToeV2.Players
{
    public class Human : IPlayer
    {
        public ICellable Cell { get; set; }
        public Map Map { get; set; }
        public void MakeAMove(int lengthtowin, int depth)
        {
           // int SelectedCell = CatchCursor();
            
        }

    }
}
