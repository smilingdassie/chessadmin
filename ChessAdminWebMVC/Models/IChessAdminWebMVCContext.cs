using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChessAdminWebMVC.Models
{

    public interface IChessAdminWebMVCContext : IDisposable
    {
        DbSet<Game> Games { get; }

        DbSet<Member> Members { get; }
        int SaveChanges();
        void MarkAsModified(Game item);
        void MarkAsModified(Member item);
    }

}