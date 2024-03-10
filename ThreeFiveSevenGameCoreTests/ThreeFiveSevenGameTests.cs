using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThreeFiveSevenGameCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeFiveSevenGameCore.Tests
{
    [TestClass()]
    public class ThreeFiveSevenGameTests
    {
        [TestMethod()]
        public void StartTest()
        {
            ThreeFiveSevenGame threeFiveSevenGame = new ThreeFiveSevenGame();
            threeFiveSevenGame.Start();
            if (threeFiveSevenGame.IsStart == false)
            {
                Assert.Fail("状态不对");
            }
            //Assert.Fail();
        }

        [TestMethod()]
        public void ReStartTest()
        {
            ThreeFiveSevenGame threeFiveSevenGame = new ThreeFiveSevenGame();
            threeFiveSevenGame.ReStart();
            if (threeFiveSevenGame.IsStart == true)
            {
                Assert.Fail("状态不对");
            }
            //Assert.Fail();
        }
    }
}