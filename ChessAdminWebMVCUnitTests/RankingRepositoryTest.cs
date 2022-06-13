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

    }
}
