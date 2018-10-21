using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeV2.GameMap;


namespace TicTacToeV2
{
    public class GameSession
    {
        public List<IPlayer> Players;
        public List<Move> HistoryOfMoves;
        public Map Map;
        public int LentgthToWin;
        public int DepthOfCalculating;

        public GameSession()
        {
            Players = new List<IPlayer>();
            HistoryOfMoves = new List<Move>();
            Map = new Map(6, 6);
        }
        public void AddPlayer(IPlayer player)
        {
            Players.Add(player);
        }
        public void RemovePlayer(IPlayer player)
        {
            Players.Remove(player);
        }
        public void NotifyPlayers(int i)
        {
            foreach (IPlayer p in Players)
                p.Update(i);
        }
    }
}
