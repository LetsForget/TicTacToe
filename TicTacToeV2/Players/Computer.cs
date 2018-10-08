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
        public State Sign { get; set; }
        public State EnemySign { get; set; }
        public Map Map { get; set; }

        Computer(Map map, State sign)
        {
            Map = map;
            Sign = sign;
            if (Sign == State.Tac)
                EnemySign = State.Tic;
            else
                EnemySign = State.Tac;
        }
        public void MakeAMove()
        {

        }
        private void CalculateMove()
        {
            Node search = new Node(Map);
            search.Build(2, Sign, EnemySign)
        }
    }
}
