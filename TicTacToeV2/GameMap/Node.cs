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
        public Node Parent;
        public IPlayer Player;
        public IPlayer Enemy;
        public int Weight { get; set; }

        #region Constructors
        public Node(Map map, IPlayer pl, IPlayer en)
        {
            Map = map;
            Player = pl;
            Enemy = en;
            Childs = new List<Node>();
        }
        public Node(Map map, IPlayer pl, IPlayer en, Node parent)
        {
            Map = map;
            Player = pl;
            Enemy = en;
            Parent = parent;
            Childs = new List<Node>();
        }
        #endregion
        #region Building a tree
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
                    Node newChild = new Node(childMap, Player, Enemy, this);
                    Childs.Add(newChild);
                }
        }
        #endregion
        #region Calculating weights
        private int ReturnMaximalChildWeight(int lengthtowin)
        {
            if (Childs[0].Childs.Count == 0)
                return EndChildMaximalWeight(lengthtowin);

            List<int> childsWeights = new List<int>();
            ICellable pl = Player.ReturnSign();
            ICellable en = Enemy.ReturnSign();

            foreach (Node ch in Childs)
                childsWeights.Add(ch.ReturnMinimalChildWeight(lengthtowin));

            var maxWeight = childsWeights.Max();
            return maxWeight;
        }
        private int ReturnMinimalChildWeight(int lengthtowin)
        {
            if (Childs[0].Childs.Count == 0)
                return EndChildMinimalWeight(lengthtowin);

            List<int> childsWeights = new List<int>();
            ICellable pl = Player.ReturnSign();
            ICellable en = Enemy.ReturnSign();

            foreach (Node ch in Childs)
                childsWeights.Add(ch.ReturnMaximalChildWeight(lengthtowin));

            var minWeight = childsWeights.Min();
            return minWeight;
        }
        private int EndChildMaximalWeight(int lengthtowin)
        {
            List<int> childsWeights = new List<int>();
            ICellable pl = Player.ReturnSign();
            ICellable en = Enemy.ReturnSign();
            foreach (Node ch in Childs)
                childsWeights.Add(ch.Map.ReturnWeight(lengthtowin, pl, en));
            var maxWeight = childsWeights.Max();
            return maxWeight;
        }
        private int EndChildMinimalWeight(int lengthtowin)
        {
            List<int> childsWeights = new List<int>();
            ICellable pl = Player.ReturnSign();
            ICellable en = Enemy.ReturnSign();
            foreach (Node ch in Childs)
                childsWeights.Add(ch.Map.ReturnWeight(lengthtowin, pl, en));
            var minWeight = childsWeights.Min();
            return minWeight;
        }
        public void SetWeights(int lengthtowin)
        {
            foreach (Node ch in Childs)
                ch.Weight = ch.ReturnMaximalChildWeight(lengthtowin);
        }
        #endregion
    }

}
