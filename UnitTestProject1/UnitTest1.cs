using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MazeWork;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            FileManager file = new FileManager();
            file.LoadMap();
        }
    }
}
