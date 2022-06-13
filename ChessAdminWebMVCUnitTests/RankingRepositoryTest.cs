using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ChessAdminWebMVC.Repositories;

namespace ChessAdminWebMVCUnitTests
{
    [TestClass]
    public class RankingRepositoryTest
    { 
        [TestMethod]
        public void TestRankMemberHigherRankDraw()
        {
            int GameID = 1;
            int PlayerOneID = 1;
            int OpponentID = 2;
            Assert.AreEqual(1, RankingRepository.RankMember(PlayerOneID, GameID, OpponentID));
        }

        [TestMethod]
        public void TestRankMemberLowerRankDrawAdjacent()
        {
            int GameID = 1;
            int PlayerOneID = 2;
            int OpponentID = 1;
            Assert.AreEqual(2, RankingRepository.RankMember(PlayerOneID, GameID, OpponentID));
        }

        [TestMethod]
        public void TestRankMemberLowerRankWin()
        {
            //PlayerID 2 is winner and has lower rank
            int GameID = 2;
            int PlayerOneID = 2;
            int OpponentID = 1;
            Assert.AreEqual(1, RankingRepository.RankMember(PlayerOneID, GameID, OpponentID));
        }

        [TestMethod]
        public void TestRankMemberHigherRankLose()
        {
            //PlayerID 1 is loser and has higher rank
            int GameID = 2;
            int PlayerOneID = 1;
            int OpponentID = 2;
            Assert.AreEqual(2, RankingRepository.RankMember(PlayerOneID, GameID, OpponentID));
        }
        [TestMethod]
        public void TestRankMemberLowerRankDraw()
        {
            //PlayerID 12 is not adjacent to PlayerID 1 and its a draw
            int GameID = 3;
            int PlayerOneID = 12;
            int OpponentID = 1;
            Assert.AreEqual(11, RankingRepository.RankMember(PlayerOneID, GameID, OpponentID));
        }
    }
}
