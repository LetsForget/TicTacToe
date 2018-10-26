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
        public int Lengthtowin;
        public int Weight { get; set; }

        #region Constructors
        public Node(Map map, IPlayer pl, IPlayer en, int lengthtowin)
        {
            Map = map;
            Player = pl;
            Enemy = en;
            Lengthtowin = lengthtowin;
            Childs = new List<Node>();
        }
        public Node(Map map, IPlayer pl, IPlayer en, Node parent, int lengthtowin)
        {
            Map = map;
            Player = pl;
            Enemy = en;
            Parent = parent;
            Lengthtowin = lengthtowin;
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
                ch.OwnMove(depth - 1);
        }       
        private void Move(int depth, IPlayer Author)
        {
            ICellable pl = Player.ReturnSign();
            ICellable en = Enemy.ReturnSign();

            if (depth == 0 || Map.ReturnWeight(Lengthtowin, pl, en) > 100 || Map.ReturnWeight(Lengthtowin,pl,en) < - 100)
                return;

            int len = Map.Cells.Length;
            ICellable playerSign = Author.ReturnSign();

            for (int i = 0; i < len; i++)
                if (Map.Cells[i].State == State.Toe)
                {
                    Map childMap = Map.ReturnChangedMap(i, playerSign);
                    Node newChild = new Node(childMap, Player, Enemy, this,Lengthtowin);
                    Childs.Add(newChild);
                }
        }
        #endregion

        #region Calculating weights
        private int ReturnMaximalChildWeight()
        {
            ICellable pl = Player.ReturnSign();
            ICellable en = Enemy.ReturnSign();

            if (Childs.Count == 0)
                return Map.ReturnWeight(Lengthtowin, pl, en);

            if (Childs[0].Childs.Count == 0)
                return EndChildMaximalWeight();

            List<int> childsWeights = new List<int>();
            foreach (Node ch in Childs)
                childsWeights.Add(ch.ReturnMinimalChildWeight());

            var maxWeight = childsWeights.Max();
            return maxWeight;
        }
        private int ReturnMinimalChildWeight()
        {
            ICellable pl = Player.ReturnSign();
            ICellable en = Enemy.ReturnSign();

            if (Childs.Count == 0)
                return Map.ReturnWeight(Lengthtowin, pl, en);

            if (Childs[0].Childs.Count == 0)
                return EndChildMinimalWeight();

            List<int> childsWeights = new List<int>();   
            foreach (Node ch in Childs)
                childsWeights.Add(ch.ReturnMaximalChildWeight());

            var minWeight = childsWeights.Min();
            return minWeight;
        }
        private int EndChildMaximalWeight()
        {
            List<int> childsWeights = new List<int>();
            ICellable pl = Player.ReturnSign();
            ICellable en = Enemy.ReturnSign();
            foreach (Node ch in Childs)
                childsWeights.Add(ch.Map.ReturnWeight(Lengthtowin, pl, en));
            var maxWeight = childsWeights.Max();
            return maxWeight;
        }
        private int EndChildMinimalWeight()
        {
            List<int> childsWeights = new List<int>();
            ICellable pl = Player.ReturnSign();
            ICellable en = Enemy.ReturnSign();
            foreach (Node ch in Childs)
                childsWeights.Add(ch.Map.ReturnWeight(Lengthtowin, pl, en));
            var minWeight = childsWeights.Min();
            return minWeight;
        }
        public void SetWeights(int lengthtowin)
        {
            foreach (Node ch in Childs)
                ch.Weight = ch.ReturnMinimalChildWeight();
        }
        #endregion
    }

}
