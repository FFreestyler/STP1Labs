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
        public void Equel()
        {

            MatrixClass a = new MatrixClass(2, 2);
            a[0, 0] = 1; a[0, 1] = 1; a[1, 0] = 1; a[1, 1] = 1;
            MatrixClass b = new MatrixClass(2, 2);
            b[0, 0] = 1; b[0, 1] = 1; b[1, 0] = 1; b[1, 1] = 1;

            Assert.AreEqual(a, b);
        }

        [TestMethod]
        public void TestEqualOperator1()
        {

            MatrixClass a = new MatrixClass(2, 2);
            a[0, 0] = 1; a[0, 1] = 1; a[1, 0] = 1; a[1, 1] = 1;
            MatrixClass b = new MatrixClass(2, 2);
            b[0, 0] = 1; b[0, 1] = 1; b[1, 0] = 1; b[1, 1] = 2;

            Assert.IsFalse(a == b);
        }

        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void TestEqualOperator2()
        {
            MatrixClass a = new MatrixClass(1, 1);
            a[0, 0] = 1; a[1, 0] = 1;
            MatrixClass b = new MatrixClass(2, 2);
            b[0, 0] = 1; b[0, 1] = 1; b[1, 0] = 1; b[1, 1] = 2;

            Assert.IsTrue(a != b);
        }

        [TestMethod]
        public void NotEquel()
        {

            MatrixClass a = new MatrixClass(2, 2);
            a[0, 0] = 1; a[0, 1] = 1; a[1, 0] = 1; a[1, 1] = 1;
            MatrixClass b = new MatrixClass(2, 2);
            b[0, 0] = 1; b[0, 1] = 1; b[1, 0] = 1; b[1, 1] = 2;

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void Summa1()
        {

            MatrixClass a = new MatrixClass(2, 2);
            a[0, 0] = 1; a[0, 1] = 1;
            a[1, 0] = 1; a[1, 1] = 1;

            MatrixClass b = new MatrixClass(2, 2);
            b[0, 0] = 2; b[0, 1] = 2;
            b[1, 0] = 2; b[1, 1] = 2;

            MatrixClass expected = new MatrixClass(2, 2);
            expected[0, 0] = 3; expected[0, 1] = 3;
            expected[1, 0] = 3; expected[1, 1] = 3;

            MatrixClass actual = new MatrixClass(2, 2);

            actual = a + b;

            Assert.IsTrue(actual == expected);
        }

        [TestMethod]
        public void Summa2()
        {

            MatrixClass a = new MatrixClass(2, 2);
            a[0, 0] = -1; a[0, 1] = -1;
            a[1, 0] = -1; a[1, 1] = -1;

            MatrixClass b = new MatrixClass(2, 2);
            b[0, 0] = 2; b[0, 1] = 2;
            b[1, 0] = 2; b[1, 1] = 2;

            MatrixClass expected = new MatrixClass(2, 2);
            expected[0, 0] = 1; expected[0, 1] = 1;
            expected[1, 0] = 1; expected[1, 1] = 1;

            MatrixClass actual = new MatrixClass(2, 2);

            actual = a + b;

            Assert.IsTrue(actual == expected);
        }

        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void Summa3()
        {

            MatrixClass a = new MatrixClass(2, 2);
            a[0, 0] = -1; a[0, 1] = -1;
            a[1, 0] = -1; a[1, 1] = -1;

            MatrixClass b = new MatrixClass(2, 1);
            b[0, 0] = 2;
            b[1, 0] = 2;

            MatrixClass expected = new MatrixClass(2, 2);
            expected[0, 0] = 1; expected[0, 1] = 1;
            expected[1, 0] = 1; expected[1, 1] = 1;

            MatrixClass actual = new MatrixClass(2, 2);

            actual = a + b;

            Assert.IsTrue(actual == expected);
        }

        [TestMethod]
        public void Raznost1()
        {

            MatrixClass a = new MatrixClass(2, 2);
            a[0, 0] = 5; a[0, 1] = 4;
            a[1, 0] = 3; a[1, 1] = 2;

            MatrixClass b = new MatrixClass(2, 2);
            b[0, 0] = 5; b[0, 1] = 4;
            b[1, 0] = 3; b[1, 1] = 2;

            MatrixClass expected = new MatrixClass(2, 2);
            expected[0, 0] = 0; expected[0, 1] = 0;
            expected[1, 0] = 0; expected[1, 1] = 0;

            MatrixClass actual = new MatrixClass(2, 2);

            actual = a - b;

            Assert.IsTrue(actual == expected);
        }

        [TestMethod]
        public void Raznost2()
        {

            MatrixClass a = new MatrixClass(2, 2);
            a[0, 0] = -1; a[0, 1] = -1;
            a[1, 0] = -1; a[1, 1] = -1;

            MatrixClass b = new MatrixClass(2, 2);
            b[0, 0] = 2; b[0, 1] = 2;
            b[1, 0] = 2; b[1, 1] = 2;

            MatrixClass expected = new MatrixClass(2, 2);
            expected[0, 0] = -3; expected[0, 1] = -3;
            expected[1, 0] = -3; expected[1, 1] = -3;

            MatrixClass actual = new MatrixClass(2, 2);

            actual = a - b;

            Assert.IsTrue(actual == expected);
        }

        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void Raznost3()
        {

            MatrixClass a = new MatrixClass(1, 1);
            a[0, 0] = -1;
            a[1, 0] = -1;

            MatrixClass b = new MatrixClass(2, 2);
            b[0, 0] = 2; b[0, 1] = 2;
            b[1, 0] = 2; b[1, 1] = 2;

            MatrixClass expected = new MatrixClass(2, 2);
            expected[0, 0] = -3; expected[0, 1] = -3;
            expected[1, 0] = -3; expected[1, 1] = -3;

            MatrixClass actual = new MatrixClass(2, 2);

            actual = a - b;

            Assert.IsTrue(actual == expected);
        }

        [TestMethod]
        public void TestTrans1()
        {
            MatrixClass a = new MatrixClass(new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } }, 3, 3);

            MatrixClass expected = new MatrixClass(new int[,] { { 1, 4, 7 }, { 2, 5, 8 }, { 3, 6, 9 } }, 3, 3);

            var actual = a.Tranpose();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void TestTrans2()
        {
            MatrixClass a = new MatrixClass(3, 2);
            a[0, 0] = 1; a[0, 1] = 2;
            a[1, 0] = 3; a[1, 1] = 4;
            a[2, 0] = 3; a[2, 1] = 4;

            MatrixClass expected = new MatrixClass(3, 2);
            expected[0, 0] = 1; expected[0, 1] = 3;
            expected[1, 0] = 2; expected[1, 1] = 4;
            expected[2, 0] = 2; expected[2, 1] = 4;

            var actual = a.Tranpose();

            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void TestMultiply1()
        {
            MatrixClass a = new MatrixClass(2, 2);
            a[0, 0] = 1; a[0, 1] = 2;
            a[1, 0] = 3; a[1, 1] = 4;

            MatrixClass b = new MatrixClass(2, 2);
            b[0, 0] = 1; b[0, 1] = 2;
            b[1, 0] = 3; b[1, 1] = 4;

            MatrixClass expected = new MatrixClass(2, 2);
            expected[0, 0] = 7; expected[0, 1] = 10;
            expected[1, 0] = 15; expected[1, 1] = 22;

            MatrixClass actual = a * b;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void TestMultiply2()
        {
            MatrixClass a = new MatrixClass(2, 2);
            a[0, 0] = 1; a[0, 1] = 2;
            a[1, 0] = 3; a[1, 1] = 4;

            MatrixClass b = new MatrixClass(2, 3);
            b[0, 0] = 1; b[0, 1] = 2; b[0, 2] = 2;
            b[1, 0] = 3; b[1, 1] = 4; b[1, 2] = 4;

            MatrixClass expected = new MatrixClass(2, 2);
            expected[0, 0] = 7; expected[0, 1] = 10;
            expected[1, 0] = 15; expected[1, 1] = 22;

            MatrixClass actual = a * b;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMultiply3()
        {
            MatrixClass a = new MatrixClass(2, 2);
            a[0, 0] = 0; a[0, 1] = 1;
            a[1, 0] = 1; a[1, 1] = 0;

            MatrixClass b = new MatrixClass(2, 2);
            b[0, 0] = 0; b[0, 1] = 0;
            b[1, 0] = 0; b[1, 1] = 0;

            MatrixClass expected = new MatrixClass(2, 2);
            expected[0, 0] = 0; expected[0, 1] = 0;
            expected[1, 0] = 0; expected[1, 1] = 0;

            MatrixClass actual = a * b;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMin1()
        {
            MatrixClass a = new MatrixClass(2, 2);
            a[0, 0] = 1; a[0, 1] = 2;
            a[1, 0] = 3; a[1, 1] = 4;

            var expected = 1;
            var actual = a.Min();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMin2()
        {
            MatrixClass a = new MatrixClass(2, 2);
            a[0, 0] = -99; a[0, 1] = 99;
            a[1, 0] = 256; a[1, 1] = -100;

            var expected = -100;
            var actual = a.Min();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestToString1()
        {
            MatrixClass a = new MatrixClass(2, 2);
            a[0, 0] = 1; a[0, 1] = 2;
            a[1, 0] = 3; a[1, 1] = 4;

            var expected = "{{1,2},{3,4}}";
            var actual = a.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void TestToString2()
        {
            MatrixClass a = new MatrixClass(2, 2);
            a[0, 0] = 1; a[0, 1] = 2; a[0, 2] = 2;
            a[1, 0] = 3; a[1, 1] = 4; a[1, 2] = 4;
            a[2, 0] = 1; a[2, 1] = 2; a[2, 2] = 5;
            a[3, 0] = 3; a[3, 1] = 4; a[3, 2] = 6;

            var expected = "{{1,2,2},{3,4,4},{1,2,5},{3,4,6}}";
            var actual = a.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestToString3()
        {
            MatrixClass a = new MatrixClass(4, 3);
            a[0, 0] = 1; a[0, 1] = 2; a[0, 2] = 2;
            a[1, 0] = 3; a[1, 1] = 4; a[1, 2] = 4;
            a[2, 0] = 1; a[2, 1] = 2; a[2, 2] = 5;
            a[3, 0] = 3; a[3, 1] = 4; a[3, 2] = 6;

            var expected = "{{1,2,2},{3,4,4},{1,2,5},{3,4,6}}";
            var actual = a.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void TestToString4()
        {
            MatrixClass a = new MatrixClass(0, 0);

            var expected = "{{1,2,2},{3,4,4},{1,2,5},{3,4,6}}";
            var actual = a.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}