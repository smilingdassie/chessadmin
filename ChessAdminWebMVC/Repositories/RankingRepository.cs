using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChessAdminWebMVC.Repositories
{
    public static class RankingRepository
    {

        /*
            Ranking
            Each member is ranked from 1..n. Where 1 is the top player in the club and n is the
            lowest-ranked player in the club.
            When players play a match, their ranks can change, based on the following rules:
            ● If the higher-ranked player wins against their opponent, neither of their ranks change
            ● If it’s a draw, the lower-ranked player can gain one position, unless the two players are
            adjacent. So if the players are ranked 10th and 11th, and it’s a draw, no change in
            ranking takes place. But if the players are ranked 10th and 15th, and it’s a draw, the
            player with rank 15 will move up to rank 14 and the player with rank 10 will stay the
            same
            ● If the lower-ranked player beats a higher-ranked player, the higher-ranked player will
            move one rank down, and the lower level player will move up by half the difference
            between their original ranks.
            For example, if players ranked 10th and 16th play and the lower-ranked player wins, the
            first player will move to rank 11th and the other player will move to rank (16 - 10) / 2 = 3
            placed up, to rank 13th
        */

        public static int RankMember(int MemberID, int GameID, int OpponentID)
        {
            int result = 0;
            var game = GameRepository.GetGame(GameID);

            if (game != null)
            {
                //Was the game a draw?

                //Was this player the winner?
                bool IsWinner = (GameRepository.GetGame(GameID).WinnerID ?? 0) == MemberID;
                //What was this player's rank before the game?
                int RankBeforeGame = GetPreviousGameRank(GameID, MemberID);
                //What was his opponent's rank before the game?
                int OpponentRankBeforeGame = GetPreviousGameRank(GameID, OpponentID);

               
                // ● If it’s a draw, the lower-ranked player can gain one position, unless the two players are
                //adjacent.So if the players are ranked 10th and 11th, and it’s a draw, no change in
                //ranking takes place.But if the players are ranked 10th and 15th, and it’s a draw, the
                //player with rank 15 will move up to rank 14 and the player with rank 10 will stay the
                //same
                if (game.IsDraw)
                {
                    //Adjacent rankers do not move
                    if (Math.Abs(OpponentRankBeforeGame - RankBeforeGame) == 1)
                    {
                        result = RankBeforeGame;
                    }
                    else
                    {
                        //Gapped rankers: lower rank moves up 1
                        if (RankBeforeGame < OpponentRankBeforeGame)
                        {
                            result = RankBeforeGame - 1;
                        }
                    }
                }
                else
                {
                    // ● If the lower - ranked player beats a higher-ranked player, the higher-ranked player will
                    //move one rank down, and the lower level player will move up by half the difference
                    //between their original ranks.
                    //For example, if players ranked 10th and 16th play and the lower - ranked player wins, the
                    //first player will move to rank 11th and the other player will move to rank(16 - 10) / 2 = 3
                    //placed up, to rank 13th
                    if (IsWinner)
                    {
                        //Lower ranked winner moves up half the difference
                        if (RankBeforeGame > OpponentRankBeforeGame)
                        {
                            result = (OpponentRankBeforeGame - RankBeforeGame) / 2;
                        }
                        // ● If the higher-ranked player wins against their opponent, neither of their ranks change
                        if (RankBeforeGame < OpponentRankBeforeGame)
                        {
                            result = RankBeforeGame;
                        }

                    }
                    else
                    {
                        //Higher ranked loser drops one place
                        if (RankBeforeGame < OpponentRankBeforeGame)
                        {
                            result = RankBeforeGame + 1;
                        }
                    }
                }
            }
            else
            {
                result = MemberRepository.GetMember(MemberID).CurrentRank??0;
            }

            return result;
        
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
                var game = GameRepository.GetGame(GameID);
                if (game != null)
                {
                    var games = db.Games.Where(x => x.GameDate < game.GameDate && (x.PlayerOneID == MemberID || x.PlayerTwoID == MemberID)).OrderByDescending(x => x.GameDate).Take(1);
                    if (games.Count() > 0)
                        if (games.First().PlayerOneID == MemberID)
                        {
                            return games.First().PlayerOneRankAfterGame ?? 0;
                        }
                        else
                        {
                            return games.First().PlayerTwoRankAfterGame ?? 0;
                        }
                   
                }
                return db.Members.Find(MemberID).CurrentRank ?? 0;
            }
        }


    }
}