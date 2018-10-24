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
            sTree.SetWeights(Gs.LentgthToWin);
            Node BestMove = sTree.Childs[0];
            for (int j = 1; j < sTree.Childs.Count; j++)
                if (BestMove.Weight < sTree.Childs[j].Weight)
                    BestMove = sTree.Childs[j];
            Gs.Map = BestMove.Map;
            Gs.HistoryOfMoves.Add(new Move(this, Gs.Map));
            Gs.NotifyPlayers(-1);
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
