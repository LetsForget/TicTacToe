﻿using System;
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
            Map = new Map(3, 3);
        }
        public void AddPlayer(IPlayer player)
        {
            Players.Add(player);
        }
        public void RemovePlayer(IPlayer player)
        {
            Players.Remove(player);
        }

        public void StopGame()
        {
            Players.Clear();
        }

        public void NotifyPlayers(int i)
        {
            if (Players.Count == 0)
                return;
            foreach (IPlayer p in Players)
                p.Update(i);
        }
    }
}
