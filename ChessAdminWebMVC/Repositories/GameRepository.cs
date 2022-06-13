using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ChessAdminWebMVC.Repositories
{
    public static class GameRepository
    {
        // The application will also need a facility to enter a match between two players and then update
        // their ranks accordingly.
        /// <summary>
        /// Save Game and apply ranking rules
        /// </summary>
        /// <param name="game"></param>
        public static void SaveGameAfterMatch(Game game)
        {
            using (var db = new ChessAdminDbEntities1())
            {
                if (game.WinnerID == null) { game.IsDraw = true; }
                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();

                game.PlayerOneRankAfterGame = RankingRepository.RankMember(game.PlayerOneID, game.ID, game.PlayerTwoID);
                game.PlayerTwoRankAfterGame = RankingRepository.RankMember(game.PlayerTwoID, game.ID, game.PlayerOneID);
                                
                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static int SaveGameBeforeMatch(Game game)
        {
            using (var db = new ChessAdminDbEntities1())
            {
                db.Games.Add(game);
                db.SaveChanges();

                game.PlayerOneCurrentRank = RankingRepository.GetPreviousGameRank(game.ID, game.PlayerOneID);
                game.PlayerTwoCurrentRank = RankingRepository.GetPreviousGameRank(game.ID, game.PlayerTwoID);

                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();

                return game.ID;
            }
        }

        public static Game GetGame(int GameID)
        {
            using (var db = new ChessAdminDbEntities1())
            {
                return db.Games.Find(GameID);
            }

        }     
    }
}