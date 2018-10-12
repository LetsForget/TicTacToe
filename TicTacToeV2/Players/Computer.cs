using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeV2.GameMap;

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
            Map = map;
            Cell = cell;
            EnemyCell = enemyCell;
            STree = new Node(map);
        }
        public void MakeAMove()
        {

        }
        public void CalculateMove(int lengthtowin, int depth)
        {
            STree.BuildATree(lengthtowin, depth, Cell, EnemyCell);

        }
        
    }
}
