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
        public Map Map { get; set; }

        Computer(Map map, ICellable cell, ICellable enemyCell)
        {
            Map = map;
            Cell = cell;
            EnemyCell = enemyCell;
        }
        public void MakeAMove()
        {

        }
        private void CalculateMove()
        {

        }
    }
}
