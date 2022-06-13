using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessAdminWebMVC;
using ChessAdminWebMVC.Models;
namespace ChessAdminWebMVCUnitTests
{
 
    class TestGameDbSet : TestDbSet<Game>
    {
        public override Game Find(params object[] keyValues)
        {
            return this.SingleOrDefault(game => game.ID == (int)keyValues.Single());
        }
    }
}