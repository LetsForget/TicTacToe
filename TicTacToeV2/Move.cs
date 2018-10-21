using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeV2.GameMap;

namespace TicTacToeV2
{
    public class Move
    {
        public IPlayer Author;
        public Map Change;
        public Move(IPlayer player, Map map)
        {
            Author = player;
            Change = map.CopyThis();
        }
    }
}
