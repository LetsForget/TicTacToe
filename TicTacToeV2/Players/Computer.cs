using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeV2.GameMap;
using TicTacToeV2.GameMap.Cells;
namespace TicTacToeV2.Players
{
    public class Computer : IPlayer
    {
        public ICellable Cell { get; set; }
        public ICellable EnemyCell { get; set; }
        public Map Map
        {
            get
            {
                return _map;
            }
            set
            {
                _map = Map;
            }
        }
        private Map _map;
        private Node STree;

        public Computer(Map map, ICellable cell, ICellable enemyCell)
        {
            _map = map;
            Cell = cell;
            EnemyCell = enemyCell;
            STree = new Node(map);
        }
        public void MakeAMove(int lengthtowin, int depth)
        {
            if (Map.ReturnQuantityOfCells(new Toe()) == Map.Width * Map.Height)
                CalculateFirstMove(lengthtowin, depth);
            else
                CalculateMove(lengthtowin, depth);

            STree = STree.MaxWeightNode;
            _map = STree.Map;

        }
        public void CalculateFirstMove(int lengthtowin, int depth)
        {
            STree.BuildAStartTree(lengthtowin, depth, Cell, EnemyCell);
        }
        public void CalculateMove(int lengthtowin, int depth)
        {
            STree.BuildATree(lengthtowin, depth, Cell, EnemyCell);

        }
        
    }
}
