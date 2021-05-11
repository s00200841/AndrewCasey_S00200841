using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AndrewCasey_S00200841;

namespace UnitTestProject_Game
{
    [TestClass]
    public class UnitTest1
    {
        // Test One is to just test two numbers that will return numbers
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            Game g1 = new Game("Call of Duty", 89, "Description Here", "X-Box", 100);
            decimal expectedResult = 90;

            // Act
            g1.DecreasePrice(.10);

            // Assert
            Assert.AreEqual(expectedResult, g1.Price);

        }

        // Second Test required to ensure code could handle change correctly
        [TestMethod]
        public void TestMethod2()
        {
            // Arrange
            Game g1 = new Game("Call of Duty", 89, "Description Here", "X-Box", 65.99m);
            decimal expectedResult = 49.49m;

            // Act
            g1.DecreasePrice(.25);

            // Assert
            Assert.AreEqual(expectedResult, g1.Price);
        }
    }
}
