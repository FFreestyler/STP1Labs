using System.Diagnostics;
using System.Reflection;
using lab1;

namespace lab1.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetMultiply()
        {
            var array = new float[] { 10.5f, 1.3f, 1.7f, 5f, 13.5f, 5.5f };

            var expected = 240.975f;
            var actual = Class1.Multiply(array);

            Assert.AreEqual(expected, actual, 0.00001f);
        }

        [TestMethod]
        public void TestShiftSequenceRight()
        {
            var array = new float[] { 1, 2, 3, 4, 5 };

            var expected = new float[] { 4, 5, 1, 2, 3 };
            var actual = Class1.ShiftArray(array, 2);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetMaxEven()
        {
            var array = new int[] { 1, 2, 2, 4, 3, 5 };

            var expected = (2,2);
            var actual = Class1.MaxEven(array);

            Assert.AreEqual(expected, actual);
        }
    }
}