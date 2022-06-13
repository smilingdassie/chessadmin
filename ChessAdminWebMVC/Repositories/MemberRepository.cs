using ChessAdminWebMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ChessAdminWebMVC.Repositories
{
    public static class MemberRepository
    {

        public static Member CreateNewMember(Member member)
        {
            using (var db = new ChessAdminDbEntities1())
            {
                //New players will, by default, be ranked last.
                member.CurrentRank = db.Members.OrderByDescending(x => x.CurrentRank).First().CurrentRank + 1;
                db.Members.Add(member);
                db.SaveChanges();
                return member;
            }

        }

        public static Member GetMember(int MemberID)
        {
            using (var db = new ChessAdminDbEntities1())
            {
                return db.Members.Find(MemberID);
            }

        }

        public static void UpdateStats(Game game)
        {
            using (var db = new ChessAdminDbEntities1())
            {
                Member player1 = GetMember(game.PlayerOneID);
                Member player2 = GetMember(game.PlayerTwoID);
                                
                List<Game> player1Games = db.Games.Where(x => x.PlayerOneID == player1.ID || x.PlayerTwoID == player1.ID).ToList();
                List<Game> player2Games = db.Games.Where(x => x.PlayerTwoID == player2.ID || x.PlayerOneID == player2.ID).ToList();

                player1.CurrentRank = game.PlayerOneRankAfterGame;
                player2.CurrentRank = game.PlayerTwoRankAfterGame;

                player1.TotalGamesPlayed = player1Games.Count();
                player2.TotalGamesPlayed = player2Games.Count();


                db.Entry(player1).State = EntityState.Modified;
                db.SaveChanges();

                db.Entry(player2).State = EntityState.Modified;
                db.SaveChanges();

            }


        }

        public static List<MemberViewModel> GetMemberViewModels(List<Member> members)
        {
            List<MemberViewModel> output = new List<MemberViewModel>();
            
            foreach (var member in members)
            {
                output.Add(new MemberViewModel(member));
            }
            return output;
        }

    }
}