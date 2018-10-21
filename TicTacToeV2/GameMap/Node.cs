using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeV2.GameMap.Cells;

namespace TicTacToeV2.GameMap
{
    public class Node
    {
        public Map Map;
        public List<Node> Childs;
        public IPlayer Player;
        public IPlayer Enemy;

        public Node(Map map, IPlayer pl, IPlayer en)
        {
            Map = map;
            Player = pl;
            Enemy = en;
            Childs = new List<Node>();
        }
        public void OwnMove(int depth)
        {
            Move(depth, Player);
            foreach (Node ch in Childs)
                ch.EnemyMove(depth - 1);
        }
        public void EnemyMove(int depth)
        {
            Move(depth, Enemy);
            foreach (Node ch in Childs)
                ch.EnemyMove(depth - 1);
        }
        private void Move(int depth, IPlayer Author)
        {
            if (depth == 0)
                return;

            int len = Map.Cells.Length;
            ICellable playerSign = Author.ReturnSign();

            for (int i = 0; i < len; i++)
                if (Map.Cells[i].State == State.Toe)
                {
                    Map childMap = Map.ReturnChangedMap(i, playerSign);
                    Node newChild = new Node(childMap, Player, Enemy);
                    Childs.Add(newChild);
                }
        }
    }

}
