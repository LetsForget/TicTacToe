using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeV2.GameMap
{
    public class Node
    {
        public List<Node> Childs = new List<Node>();
        public Map Map;
        public int Weight { get; private set; }

        public Node(Map map)
        {
            Map = map;
        }
        public void Build(int depth, State sign, State enemy)
        {
            if (depth == 0)
                return;
            State first;

            if (Map.QuantityOfSpecialCells(sign) > Map.QuantityOfSpecialCells(enemy))
                first = enemy;
            else
                first = sign;

            for (int i = 0; i < Map.Cells.Length; i++)
                Childs.Add(new Node(Map.Set(i, first)));
            foreach (Node t in Childs)
                t.Build(depth--, sign, enemy);
        }
        private void EvaluatingFunction()
        {

        }
        public void SetWeights()
        {
            if (Childs.Count == 0)
                return;

        }
    }

}
