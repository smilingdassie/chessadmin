using System;
using System.Data.Entity;
using ChessAdminWebMVC;
using ChessAdminWebMVC.Models;

namespace ChessAdminWebMVCUnitTests
{
    public class TestStoreAppContext : IChessAdminWebMVCContext
    {
        public TestStoreAppContext()
        {
            this.Games = new TestGameDbSet();
        }

        public DbSet<Game> Games { get; set; }

        public DbSet<Member> Members { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

       
        public void Dispose() { }
        
        public void MarkAsModified(Game item)
        {
             
        }

        public void MarkAsModified(Member item)
        {
           
        }
    }
}