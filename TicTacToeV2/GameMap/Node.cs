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
        public List<Node> Childs = new List<Node>();
        public Map Map;
        public Node MaxWeightNode;

        public Node(Map map)
        {
            Map = map;
        }
        public void Move(Map map, ICellable cell, ICellable enemyCell, int lengthtowin)
        {
            int length = map.Cells.Length;

            for (int i = 0; i < length; i++)
                if (map.Cells[i].State == State.Toe)
                {
                    Node newChild = new Node(map.ReturnChangedMap(i, cell));
                    Childs.Add(newChild);
                }

            if (Childs.Count == 0)
                return;

            int weight = Childs[0].Map.ReturnWeight(lengthtowin, cell, enemyCell);
            MaxWeightNode = Childs[0];
            for (int i = 1; i < Childs.Count; i++)
                if (Childs[i].Map.ReturnWeight(lengthtowin,cell,enemyCell) > weight)
                {
                    weight = Childs[i].Map.ReturnWeight(lengthtowin, cell, enemyCell);
                    MaxWeightNode = Childs[i];
                }
        }


        public void BuildATree(int lengthtowin, int depth, ICellable cell, ICellable enemyCell)
        {
            if (depth == 0)
                return;
            int cellsQuantity = Map.ReturnQuantityOfCells(cell);
            int enemyCellsQuantity = Map.ReturnQuantityOfCells(enemyCell);

            if (cellsQuantity < enemyCellsQuantity)
                Move(Map, cell, enemyCell, lengthtowin);
            else
                Move(Map, enemyCell, cell, lengthtowin);

            foreach (Node t in Childs)
                t.BuildATree(lengthtowin, depth - 1, cell, enemyCell);
        }
        public void BuildAStartTree(int lengthtowin, int depth, ICellable cell, ICellable enemyCell)
        {
            if (depth == 0)
                return;
            Move(Map, cell, enemyCell, lengthtowin);
            foreach (Node t in Childs)
                t.BuildATree(lengthtowin, depth - 1, cell, enemyCell);
        }
    }

}
