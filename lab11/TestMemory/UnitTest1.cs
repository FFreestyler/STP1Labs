using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab11;


namespace TestMemory
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMemory()
        {
            var expected = 0;
            var v = new Memory<int>();
            var actual = v.GetNumber();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestStore()
        {
            var mem = new Memory<int>();
            mem.Storage(2);
            var actual = mem.GetNumber();
            var expected = 2;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRead()
        {
            var mem = new Memory<int>();
            mem.Storage(2);
            var actual = mem.Read();
            var expected = 2;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestClear()
        {
            var mem = new Memory<int>();
            mem.Storage(2);
            mem.clear();
            var actual = mem.GetNumber();
            var expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetState()
        {
            var mem = new Memory<int>();
            mem.Storage(2);
            mem.clear();
            var actual = mem.GetState();
            var expected = "Off";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAdd()
        {
            var mem = new Memory<int>();
            mem.Storage(2);
            mem.Add(2);
            var actual = mem.GetNumber();
            var expected = 4;

            Assert.AreEqual(expected, actual);
        }
    }
}