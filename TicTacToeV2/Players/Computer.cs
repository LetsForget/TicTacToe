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
        public GameSession Gs;
        public ICellable Sign;

        public Computer(ICellable sign, GameSession gs)
        {
            Sign = sign;
            Gs = gs;
        }
        public void MakeaMove(int i)
        {
            Node sTree = new Node(Gs.Map,this, Gs.HistoryOfMoves.Last().Author);
            sTree.OwnMove(Gs.DepthOfCalculating);
            
        }
        public void Update(int i)
        {
            if (Gs.HistoryOfMoves.Last().Author != this)
                MakeaMove(i);
        }
        public ICellable ReturnSign()
        {
            return Sign;
        }
    }
}
