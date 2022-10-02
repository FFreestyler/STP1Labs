using lab6;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestComplexClass
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestConstructor()
        {
            var _ = new Complex(1, 5);
        }

        [TestMethod]
        public void TestConstructorZero()
        {
            var _ = new Complex(0, 0);
        }

        [TestMethod]
        public void TestConstructorUnderZero()
        {
            var _ = new Complex(-1, -5);
        }

        [TestMethod]
        public void TestSum()
        {
            var first = new Complex(1, 5);
            var second = new Complex(2, 3);

            var actual = first + second;
            var expected = new Complex(3, 8);

            Assert.IsTrue(expected == actual);

        }


        [TestMethod]
        public void TestSumWithUnderZeroOneVars()
        {
            var first = new Complex(2, 5);
            var second = new Complex(-1, -5);

            var actual = first + second;
            var expected = new Complex(1, 0);

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void TestSumWithUnderZeroTwoVars()
        {
            var first = new Complex(-2, -5);
            var second = new Complex(-1, -5);

            var actual = first + second;
            var expected = new Complex(-3, -10);

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void TestMinus()
        {
            var first = new Complex(2, 5);
            var second = new Complex(1, 5);

            var actual = first - second;
            var expected = new Complex(-1, 0);

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void TestMinusWithUnderZeroOneVars()
        {
            var first = new Complex(2, 5);
            var second = new Complex(-1, -5);

            var actual = first - second;
            var expected = new Complex(-3, -10);

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void TestMinusWithUnderZeroTwoVars()
        {
            var first = new Complex(-2, -5);
            var second = new Complex(-1, -5);

            var actual = first - second;
            var expected = new Complex(1, 0);

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void TestMultiply()
        {
            var first = new Complex(2, 5);
            var second = new Complex(1, 5);

            var actual = first * second;
            var expected = new Complex(-23, 15);

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void TestMultiplyWithUnderZeroOneVars()
        {
            var first = new Complex(2, 5);
            var second = new Complex(-1, -5);

            var actual = first * second;
            var expected = new Complex(23, -15);

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void TestMultiplyWithUnderZeroTwoVars()
        {
            var first = new Complex(-2, -5);
            var second = new Complex(-1, -5);

            var actual = first * second;
            var expected = new Complex(-23, 15);

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void TestMultiplyWithDouble()
        {
            var first = new Complex(0.12, 0.44);
            var second = new Complex(0.76, 0.424);

            var actual = first * second;
            var expected = new Complex(-0.09536, 0.38528);

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void TestDivide()
        {
            var first = new Complex(32, 16);
            var second = new Complex(2, 16);

            var actual = first / second;
            var expected = new Complex(0.25, -0.15);

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void TestDivideWithZeroVar()
        {
            var first = new Complex(-32, 16);
            var second = new Complex(-2, 16);

            var actual = first / second;
            var expected = new Complex(0.25, -0.15);

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void TestEqual()
        {
            var first = new Complex(32, 16);
            var second = new Complex(32, 16);

            var actual = first * second;
            var expected = new Complex(0.25, 0.15);

            Assert.IsTrue(first == second);
        }

        [TestMethod]
        public void TestUnEqual()
        {
            var first = new Complex(32, 16);
            var second = new Complex(132, 16);

            var actual = first * second;
            var expected = new Complex(0.25, 0.15);

            Assert.IsTrue(first != second);
        }

        [TestMethod]
        public void TestPow()
        {
            var first = new Complex(32, 16);

            var actual = first.Pow(2);
            var expected = new Complex(768, 1024);

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void TestPowUnderZero()
        {
            var first = new Complex(-32, 16);

            var actual = first.Pow(2);
            var expected = new Complex(768, -1024);

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void TestAbs()
        {
            var first = new Complex(2, 2);

            var expected = 2.8284271247461903;
            var actual = first.Abs();

            Assert.IsTrue(actual == expected);
        }

        [TestMethod]
        public void TestAngleRadians()
        {
            var first = new Complex(2, 2);

            var expected = 0.78539816339744828;
            var actual = first.AngleRadians();

            Assert.IsTrue(actual == expected);
        }

        [TestMethod]
        public void TestAngleRadiansWithUnderZeroOneVars()
        {
            var first = new Complex(-2, 2);

            var expected = 2.356194490192345;
            var actual = first.AngleRadians();

            Assert.IsTrue(actual == expected);
        }

        [TestMethod]
        public void TestAngleRadiansWithUnderZeroTwoVars()
        {
            var first = new Complex(-2, -2);

            var expected = 3.9269908169872414;
            var actual = first.AngleRadians();

            Assert.IsTrue(actual == expected);
        }


        [TestMethod]
        public void TestGetReal()
        {
            var first = new Complex(2, 2);

            var expected = 2;
            var actual = first.GetReal();

            Assert.IsTrue(actual == expected);
        }

        [TestMethod]
        public void TestGetImag()
        {
            var first = new Complex(2, 4);

            var expected = 4;
            var actual = first.GetImag();

            Assert.IsTrue(actual == expected);
        }

        [TestMethod]
        public void TestToString()
        {
            var first = new Complex(2, 2);

            var expected = "2+i2";
            var actual = first.ToString();

            Assert.IsTrue(actual == expected);
        }

        [TestMethod]
        public void TestRoot()
        {
            var first = new Complex(3840, 2048);

            var expected = new Complex(64, 16);
            var actual = first.Root(2, 0);

            Assert.IsTrue(actual == expected);
        }
    }
}