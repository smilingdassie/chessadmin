using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ChessAdminWebMVC.Repositories;

namespace ChessAdminWebMVCUnitTests
{
    [TestClass]
    public class RankingRepositoryTest
    { 
        [TestMethod]
        public void TestRankMember()
        {
            int GameID = 1;
            int PlayerOneID = 1;
            int OpponentID = 2;
            Assert.AreEqual(1, RankingRepository.RankMember(PlayerOneID, GameID, OpponentID));
        }

        [TestMethod]
        public void TestRankMemberLowerRankDraw()
        {
            int GameID = 1;
            int PlayerOneID = 2;
            int OpponentID = 1;
            Assert.AreEqual(2, RankingRepository.RankMember(PlayerOneID, GameID, OpponentID));
        }

        [TestMethod]
        public void TestRankMemberLowerRankWin()
        {
            int GameID = 2;
            int PlayerOneID = 2;
            int OpponentID = 1;
            Assert.AreEqual(1, RankingRepository.RankMember(PlayerOneID, GameID, OpponentID));
        }


    }
}
