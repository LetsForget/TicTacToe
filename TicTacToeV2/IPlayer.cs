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
        void MakeaMove(int i);
        void Update(int i);
    }

}
