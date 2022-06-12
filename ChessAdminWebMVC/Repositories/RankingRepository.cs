using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChessAdminWebMVC.Repositories
{
    public class RankingRepository
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

        public int RankMember(int MemberID, int GameID, int OpponentID)
        {
            int result = 0;
            //Was the game a draw?
            bool IsDraw = GameRepository.GetGame(GameID).IsDraw??false;
            //Was this player the winner?
            bool IsWinner = (GameRepository.GetGame(GameID).WinnerID??0) == MemberID;
            //What was this player's rank before the game?
            int RankBeforeGame = GameRepository.GetPreviousGameRank(GameID, MemberID);
            //What was his opponent's rank before the game?
            int OpponentRankBeforeGame = GameRepository.GetPreviousGameRank(GameID, OpponentID);

            // ● If the higher - ranked player wins against their opponent, neither of their ranks change
            if (!IsDraw && !IsWinner && (OpponentRankBeforeGame > RankBeforeGame))
            {
                result = RankBeforeGame;
            }
            // ● If it’s a draw, the lower-ranked player can gain one position, unless the two players are
            //adjacent.So if the players are ranked 10th and 11th, and it’s a draw, no change in
            //ranking takes place.But if the players are ranked 10th and 15th, and it’s a draw, the
            //player with rank 15 will move up to rank 14 and the player with rank 10 will stay the
            //same
            if (IsDraw)
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
                    if (RankBeforeGame < OpponentRankBeforeGame)
                    {
                        result = (OpponentRankBeforeGame - RankBeforeGame) / 2;
                    }

                }
                else
                {
                    //Higher ranked loser drops one place
                    if (RankBeforeGame > OpponentRankBeforeGame)
                    {
                        result = RankBeforeGame +1;
                    }
                }
            }


            return result;
        
        }





    }
}