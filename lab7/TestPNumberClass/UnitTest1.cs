using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab7;
using System;

namespace TestPNumberClass
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPNumber()
        {
            var _ = new PNumber(1, 2, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestPNumberSecond()
        {
            var _ = new PNumber(1, 0, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestPNumberThird()
        {
            var _ = new PNumber("1, 29, 1");
        }

        [TestMethod]
        public void TestPNumberAdd()
        {
            PNumber a = new PNumber(1, 2, 3);
            PNumber b = new PNumber(5, 2, 3);

            PNumber actual = a + b;
            PNumber expected = new PNumber(6, 2, 3);

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestPNumberAddSecond()
        {
            PNumber a = new PNumber(1, 1, 3);
            PNumber b = new PNumber(5, 2, 3);

            PNumber actual = a + b;
            PNumber expected = new PNumber(6, 2, 3);

            Assert.IsTrue(actual == expected);
        }

        [TestMethod]
        public void TestPNumberSub()
        {
            PNumber a = new PNumber(0, 2, 3);
            PNumber b = new PNumber(1, 2, 3);

            PNumber actual = a - b;
            PNumber expected = new PNumber(-1, 2, 3);

            Assert.IsTrue(actual == expected);
        }

        [TestMethod]
        public void TestPNumberMul()
        {
            PNumber a = new PNumber(2, 2, 3);
            PNumber b = new PNumber(1, 2, 3);

            PNumber actual = a * b;
            PNumber expected = new PNumber(2, 2, 3);

            Assert.IsTrue(actual == expected);
        }

        [TestMethod]
        public void TestPNumberDiv()
        {
            PNumber a = new PNumber(2, 2, 3);
            PNumber b = new PNumber(1, 2, 3);

            PNumber actual = a / b;
            PNumber expected = new PNumber(2, 2, 3);

            Assert.IsTrue(actual == expected);
        }

        [TestMethod]
        public void TestPNumberPow()
        {
            PNumber a = new PNumber(2, 2, 3);

            PNumber actual = PNumber.Pow(a, 2);
            PNumber expected = new PNumber(4, 2, 3);

            Assert.IsTrue(actual == expected);
        }

        [TestMethod]
        public void TestPNumberRevers()
        {
            PNumber a = new PNumber(2, 2, 3);

            PNumber actual = PNumber.Revers(a);
            PNumber expected = new PNumber(1.0 / 2, 2, 3);

            Assert.IsTrue(actual == expected);
        }

        [TestMethod]
        public void TestPNumberGetNum()
        {
            PNumber a = new PNumber(2, 2, 3);

            var actual = PNumber.GetNum(a);
            var expected = 2;

            Assert.IsTrue(actual == expected);
        }

        [TestMethod]
        public void TestPNumberGetString()
        {
            PNumber a = new PNumber(2, 2, 3);

            var actual = PNumber.GetString(a);
            var expected = "2, 2, 3";

            Assert.IsTrue(actual == expected);
        }

        [TestMethod]
        public void TestPNumberGetBase()
        {
            PNumber a = new PNumber(2, 2, 3);

            var actual = PNumber.GetBase(a);
            var expected = 2;

            Assert.IsTrue(actual == expected);
        }

        [TestMethod]
        public void TestPNumberGetAccuracy()
        {
            PNumber a = new PNumber(2, 2, 3);

            var actual = PNumber.GetAccuracy(a);
            var expected = 3;

            Assert.IsTrue(actual == expected);
        }

        [TestMethod]
        public void TestPNumberSetBase()
        {
            PNumber actual = new PNumber(2, 2, 3);

            actual.SetBase(5);
            var expected = new PNumber(2, 5, 3);

            Assert.IsTrue(actual == expected);
        }

        [TestMethod]
        public void TestPNumberSetAccuracy()
        {
            PNumber actual = new PNumber(2, 2, 3);

            actual.SetAccuracy(5);
            var expected = new PNumber(2, 2, 5);

            Assert.IsTrue(actual == expected);
        }
    }
}