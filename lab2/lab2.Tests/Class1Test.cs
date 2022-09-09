using lab2;

namespace lab2.Tests
{
    [TestClass]
    public class Class1Test
    {
        [TestMethod]
        public void TestMax()
        {
            var actual = Class1.Max(25, 26);
            var expected = (26, 25);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestEvenMultiplyMatrix()
        {
            var array = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 33, 9 } };
            var actual = 48;
            var expected = Class1.EvenMultiplyMatrix(array);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestEvenMultiplyMatrixWithoutEven()
        {
            var array = new int[,] { { 1, 13, 3 }, { 5, 5, 23 }, { 7, 33, 9 } };
            var actual = 1;
            var expected = Class1.EvenMultiplyMatrix(array);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestEvenSumMatrix()
        {
            var array = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 33, 9 } };
            var actual = 6;
            var expected = Class1.EvenSumMatrix(array);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestEvenSumMatrixWithoutEven()
        {
            var array = new int[,] { { 1, 13, 3 }, { 5, 5, 23 }, { 7, 33, 9 } };
            var actual = 0;
            var expected = Class1.EvenSumMatrix(array);

            Assert.AreEqual(expected, actual);
        }
    }
}