using lab12;

namespace TestProcessor
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestProcessor()
        {
            var proc = new Processor<int>();
            var left = proc.getLeftOperand();
            var right = proc.getRightOperand();

            var expect = 0;

            Assert.AreEqual(expect, left);
            Assert.AreEqual(expect, right);
        }

        [TestMethod]
        public void TestReset()
        {
            var proc = new Processor<int>();
            proc.setLeftOperand(1);
            proc.setRightOperand(2);

            proc.setState(Processor<int>.Operation.Mul);

            proc.resetOperation();
            proc.pReset();

            var left = proc.getLeftOperand();
            var right = proc.getRightOperand();
            var state = proc.getState();

            var expected = 0;

            Assert.AreEqual(expected, left);
            Assert.AreEqual(expected, right);
            Assert.AreEqual(Processor<int>.Operation.None, state);
        }

        [TestMethod]
        public void TestOpAdd()
        {
            var proc = new Processor<int>();
            proc.setLeftOperand(1);
            proc.setRightOperand(2);

            proc.setState(Processor<int>.Operation.Add);
            proc.performOperation();

            var left = proc.getLeftOperand();

            var expect = 3;

            Assert.AreEqual(expect, left);
        }

        [TestMethod]
        public void TestOpSub()
        {
            var proc = new Processor<int>();
            proc.setLeftOperand(3);
            proc.setRightOperand(2);

            proc.setState(Processor<int>.Operation.Sub);
            proc.performOperation();

            var left = proc.getLeftOperand();

            var expect = 1;

            Assert.AreEqual(expect, left);
        }

        [TestMethod]
        public void TestOpMul()
        {
            var proc = new Processor<int>();
            proc.setLeftOperand(3);
            proc.setRightOperand(2);

            proc.setState(Processor<int>.Operation.Mul);
            proc.performOperation();

            var left = proc.getLeftOperand();

            var expect = 6;

            Assert.AreEqual(expect, left);
        }

        [TestMethod]
        public void TestOpDiv()
        {
            var proc = new Processor<int>();
            proc.setLeftOperand(4);
            proc.setRightOperand(2);

            proc.setState(Processor<int>.Operation.Div);
            proc.performOperation();

            var left = proc.getLeftOperand();

            var expect = 2;

            Assert.AreEqual(expect, left);
        }
    }
}