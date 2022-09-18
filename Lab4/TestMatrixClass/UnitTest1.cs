using Lab4;

namespace TestMatrixClass
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void Matrix_Expected_MyException_i()
        {
            MatrixClass a = new MatrixClass(0, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void Matrix_Expected_MyException_j()
        {
            MatrixClass a = new MatrixClass(2, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void this_Expected_MyException_set_j()
        {
            MatrixClass a = new MatrixClass(2, 2);
            a[1, 3] = 2;
        }

        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void this_Expected_MyException_get_i()
        {

            MatrixClass a = new MatrixClass(2, 2);
            int r = a[3, 1];
        }

        [TestMethod]
        public void TestEqual()
        {

            MatrixClass actual = new MatrixClass(new int[,] { { 1, 1 }, { 1, 1 } }, 2, 2);
            MatrixClass expected = new MatrixClass(new int[,] { { 1, 1 }, { 1, 1 } }, 2, 2);

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestEqualOperator()
        {

            MatrixClass actual = new MatrixClass(new int[,] { { 1, 1}, { 1, 1 } }, 2, 2);
            MatrixClass expected = new MatrixClass(new int[,] { { 1, 2 }, { 3, 4 } }, 2, 2);

            Assert.IsFalse(actual == expected);
        }

        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void TestEqualOperatorSecond()
        {
            MatrixClass actual = new (new int[,] { { 1 }, { 1 } }, 1, 1);
            MatrixClass expected = new (new int[,] { { 1, 2 }, { 1, 2 } }, 2, 2);

            Assert.IsTrue(actual != expected);
        }

        [TestMethod]
        public void TestNotEqual()
        {

            MatrixClass actual = new MatrixClass(new int[,] { { 1, 1 }, { 1, 1 } }, 2, 2);
            MatrixClass expected = new MatrixClass(new int[,] { { 1, 2 }, { 1, 5 } }, 2, 2);

            Assert.AreNotEqual(actual, expected);
        }

        [TestMethod]
        public void TestSum()
        {

            MatrixClass a = new (new int[,] { { 1, 1 }, { 1, 1 } }, 2, 2);

            MatrixClass b = new (new int[,] { { 2, 2 }, { 2, 2 } }, 2, 2);

            MatrixClass expected = new (new int[,] { { 3, 3 }, { 3, 3 } }, 2, 2);

            MatrixClass actual = new (2, 2);

            actual = a + b;

            Assert.IsTrue(actual == expected);
        }

        [TestMethod]
        public void TestSumSecond()
        {

            MatrixClass a = new MatrixClass(new int[,] { { -1, -1 }, { -1, -1 } }, 2, 2);

            MatrixClass b = new MatrixClass(new int[,] { { 2, 2 }, { 2, 2 } }, 2, 2);

            MatrixClass expected = new MatrixClass(new int[,] { { 1, 1}, { 1, 1 } }, 2, 2);

            MatrixClass actual = new MatrixClass(2, 2);

            actual = a + b;

            Assert.IsTrue(actual == expected);
        }

        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void TestSumThird()
        {

            MatrixClass a = new MatrixClass(new int[,] { { -1, -1 }, { -1, -1 } }, 2, 2);
            
            MatrixClass b = new MatrixClass(new int[,] { { 2, 2 } }, 2, 1);

            MatrixClass expected = new MatrixClass(2, 2);

            MatrixClass actual = new MatrixClass(2, 2);

            actual = a + b;

        }

        [TestMethod]
        public void TestDiff()
        {

            MatrixClass a = new MatrixClass(new int[,] { { 5, 4 }, { 3, 2 } }, 2, 2);

            MatrixClass b = new MatrixClass(new int[,] { { 5, 4 }, { 3, 2 } }, 2, 2);

            MatrixClass expected = new MatrixClass(new int[,] { { 0, 0 }, { 0, 0 } }, 2, 2);

            MatrixClass actual = new MatrixClass(2, 2);

            actual = a - b;

            Assert.IsTrue(actual == expected);
        }

        [TestMethod]
        public void TestDiffSecond()
        {

            MatrixClass a = new MatrixClass(new int[,] { { -1, -1 }, { -1, -1 } }, 2, 2);

            MatrixClass b = new MatrixClass(new int[,] { { 2, 2 }, { 2, 2 } }, 2, 2);

            MatrixClass expected = new MatrixClass(new int[,] { { -3, -3 }, { -3, -3 } }, 2, 2);

            MatrixClass actual = new MatrixClass(2, 2);

            actual = a - b;

            Assert.IsTrue(actual == expected);
        }

        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void TestDiffThird()
        {

            MatrixClass a = new MatrixClass(new int[,] { { -1, -1 } }, 1, 1);

            MatrixClass b = new MatrixClass(new int[,] { { 2, 2 }, { 2, 2 } }, 2, 2);

            MatrixClass expected = new MatrixClass(new int[,] { { -3, -3 }, { -3, -3 } }, 2, 2);

            MatrixClass actual = new MatrixClass(2, 2);

            actual = a - b;

            Assert.IsTrue(actual == expected);
        }

        [TestMethod]
        public void TestTranspese()
        {
            MatrixClass a = new MatrixClass(new int[,] { { 1, 2, 2 }, { 3, 4, 4 }, { 3, 4, 3 } }, 3, 3);
           
            MatrixClass expected = new MatrixClass(new int[,] { { 1, 3, 3 }, { 2, 4, 4 }, { 2, 4, 3 } }, 3, 3);

            var actual = a.Transpose();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void TestTranspeseSecond()
        {
            MatrixClass a = new MatrixClass(new int[,] { { 1, 2 }, { 3, 4 }, { 3, 4 } }, 3, 2);

            MatrixClass expected = new MatrixClass(new int[,] { { 1, 3 }, { 2, 4 }, { 2, 4 } }, 3, 2);

            var actual = a.Transpose();

            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void TestMultiply()
        {
            MatrixClass a = new MatrixClass(new int[,] { { 1, 2 }, { 3, 4 } }, 2, 2);

            MatrixClass b = new MatrixClass(new int[,] { { 1, 2 }, { 3, 4 } }, 2, 2);

            MatrixClass expected = new MatrixClass(new int[,] { { 7, 10 }, { 15, 22 } }, 2, 2);

            MatrixClass actual = a * b;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void TestMultiplySecond()
        {
            MatrixClass a = new MatrixClass(new int[,] { { 1, 2 }, { 3, 4 } }, 2, 2);

            MatrixClass b = new MatrixClass(new int[,] { { 1, 2, 2 }, { 3, 4, 4 } }, 2, 3);

            MatrixClass expected = new MatrixClass(new int[,] { { 7, 10 }, { 15, 22 } }, 2, 2);

            MatrixClass actual = a * b;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMultiplyThird()
        {
            MatrixClass a = new MatrixClass(new int[,] { { 0, 1 }, { 1, 0 } }, 2, 2);

            MatrixClass b = new MatrixClass(new int[,] { { 0, 0 }, { 0, 0 } }, 2, 2);

            MatrixClass expected = new MatrixClass(new int[,] { { 0, 0 }, { 0, 0 } }, 2, 2);

            MatrixClass actual = a * b;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMin()
        {
            MatrixClass a = new MatrixClass(new int[,] { { 1, 2}, { 3,4 } }, 2, 2);

            var expected = 1;
            var actual = a.Min();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMinSecond()
        {
            MatrixClass a = new MatrixClass(new int[,] { { -99, 99 }, { -101, 111 } }, 2, 2);

            var expected = -101;
            var actual = a.Min();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestToString()
        {
            MatrixClass a = new MatrixClass(new int[,] { { 1, 2 }, { 3, 4 } }, 2, 2);

            var expected = "{{1,2},{3,4}}";
            var actual = a.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestToStringSecond()
        {
            MatrixClass a = new MatrixClass(new int[,] { { 1, 2, 2 }, { 3, 4, 4 }, { 1, 2, 5 }, { 3, 4, 6 } }, 4,3 );

            var expected = "{{1,2,2},{3,4,4},{1,2,5},{3,4,6}}";
            var actual = a.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestToStringThird()
        {
            MatrixClass a = new MatrixClass(new int[,] { { 1, 2, 3 }, { 1, 2, 3 }, { 1, 2, 3 }, { 1, 2, 3 } }, 4, 3);

            var expected = "{{1,2,2},{3,4,4},{1,2,5},{3,4,6}}";
            var actual = a.ToString();

            Assert.AreNotEqual(expected, actual);
        }
    }
}