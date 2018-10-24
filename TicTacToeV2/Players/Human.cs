using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeV2.GameMap;
namespace TicTacToeV2.Players
{
    class Human : IPlayer
    {
        public GameSession Gs;
        public ICellable Sign;
     
        public void MakeaMove(int i)
        {
            if (i == -1)
                return;
            Gs.Map = Gs.Map.ReturnChangedMap(i, Sign);
            Gs.HistoryOfMoves.Add(new Move(this, Gs.Map));
            Gs.NotifyPlayers(i);
        }
        public Human(ICellable sign, GameSession gs)
        {
            Sign = sign;
            Gs = gs;
        }
        public void Update(int i)
        {
            if (Gs.HistoryOfMoves.Count() == 0)
            {
                MakeaMove(i);
                return;
            }
            if (Gs.HistoryOfMoves.Last().Author != this)
                MakeaMove(i);
        }
        public ICellable ReturnSign()
        {
            return Sign;
        }

    }
}
