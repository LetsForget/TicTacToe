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
        public void Build(int depth, ICellable cell, ICellable enemyCell)
        {
           
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
