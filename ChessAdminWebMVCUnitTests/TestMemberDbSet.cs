using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessAdminWebMVC;
using ChessAdminWebMVC.Models;
namespace ChessAdminWebMVCUnitTests
{
 
    class TestMemberDbSet : TestDbSet<Member>
    {
        public override Member Find(params object[] keyValues)
        {
            return this.SingleOrDefault(member => member.ID == (int)keyValues.Single());
        }
    }
}