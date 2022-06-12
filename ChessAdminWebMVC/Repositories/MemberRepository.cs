using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChessAdminWebMVC.Repositories
{
    public static class MemberRepository
    {
        public static Member GetMember(int MemberID)
        {
            using (var db = new ChessAdminDbEntities1())
            {
                return db.Members.Find(MemberID);
            }

        }
    }
}