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
        public State Sign { get; set; }
        public Map Map { get; set; }
        public void MakeAMove()
        {
            int SelectedCell = CatchCursor();
            
        }
    }
}
