using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChessAdminWebMVC.Repositories
{
    public static class GameRepository
    {

        public static Game GetGame(int GameID)
        {
            using (var db = new ChessAdminDbEntities1())
            {
                return db.Games.Find(GameID);
            }

        }

        /// <summary>
        /// Get the Rank this Player scored in his previous game
        /// </summary>
        /// <param name="GameID"></param>
        /// <param name="MemberID"></param>
        /// <returns></returns>
        public static int GetPreviousGameRank(int GameID, int MemberID)
        {
            using (var db = new ChessAdminDbEntities1())
            {
                var game = GetGame(GameID);
                var games = db.Games.Where(x => x.GameDateTime < game.GameDateTime && (x.PlayerOneID == MemberID || x.PlayerTwoID == MemberID)).OrderByDescending(x => x.GameDateTime).Take(1);
                if (games.Count() > 0)
                    if (games.First().PlayerOneID == MemberID)
                    {
                        return games.First().PlayerOneRankAfterGame ?? 0;
                    }
                    else
                    {
                        return games.First().PlayerTwoRankAfterGame ?? 0;
                    }
                else
                    return 0;

            }
        }



    }
}