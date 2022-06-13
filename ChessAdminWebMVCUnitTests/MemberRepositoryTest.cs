using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ChessAdminWebMVC.Repositories;
using ChessAdminWebMVC;

namespace ChessAdminWebMVCUnitTests
{
    [TestClass]
    public class MemberRepositoryTest
    {
        [TestMethod]
        public void TestCreateNewMember()
        {
            Member member = new Member();
            member.Name = "Daniel";
            member.Surname = "Souchon";
            member.Email = "dsouchon@gmail.com";
            member.Birthday = DateTime.Parse("1 September 1973");
            Assert.AreEqual(14, MemberRepository.CreateNewMember(member).CurrentRank);
        }
    }
}
