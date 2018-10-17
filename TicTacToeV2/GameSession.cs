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
        public IPlayer FirstPlayer;
        public IPlayer SecondPlayer;
        public Map Map;
        
        public GameSession(IPlayer first, IPlayer second, Map map)
        {
            FirstPlayer = first;
            SecondPlayer = second;
            Map = map;
        }
        public void Start(int lengthtowin, int depth)
        {
            for(; ; )
            {
                FirstPlayer.MakeAMove(lengthtowin, depth);
                Map = FirstPlayer.Map;
                SecondPlayer.Map = FirstPlayer.Map;
                
                SecondPlayer.MakeAMove(lengthtowin, depth);
                Map = SecondPlayer.Map;
                FirstPlayer.Map = SecondPlayer.Map;
            }

        }
    }
}
