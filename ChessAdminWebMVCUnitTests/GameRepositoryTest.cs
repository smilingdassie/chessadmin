using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ChessAdminWebMVC.Repositories;

namespace ChessAdminWebMVCUnitTests
{
    [TestClass]
    public class GameRepositoryTest
    {
        [TestMethod]
        public void TestSaveGameBeforeMatch()
        {
            int ID = 1;
            int PlayerOneID = 1;
            Assert.AreEqual(5, RankingRepository.GetPreviousGameRank(ID, PlayerOneID));
        }
    }
}
