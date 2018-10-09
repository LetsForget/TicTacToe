using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeV2.GameMap;

namespace TicTacToeV2
{
    public interface IPlayer
    {
        ICellable Cell { get; set; }
        Map Map { get; set; }
        void MakeAMove();
    }
}
