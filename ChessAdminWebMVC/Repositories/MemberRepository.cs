using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChessAdminWebMVC.Repositories
{
    public static class MemberRepository
    {

        public static int CreateNewMember(Member member)
        {
            using (var db = new ChessAdminDbEntities1())
            {
                //New players will, by default, be ranked last.
                member.CurrentRank = db.Members.OrderBy(x => x.CurrentRank).First().CurrentRank + 1;
                db.Members.Add(member);
                db.SaveChanges();
                return member.ID;
            }

        }



        public static Member GetMember(int MemberID)
        {
            using (var db = new ChessAdminDbEntities1())
            {
                return db.Members.Find(MemberID);
            }

        }
    }
}