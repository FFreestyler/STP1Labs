using lab5;

namespace TestSimpleFractionClass
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestConstructor()
        {
            SimpleFractionClass a = new (1, 5);
        }

        [TestMethod]
        public void TestConstructorString()
        {
            SimpleFractionClass a = new("1/5");
        }

        [TestMethod]
        public void TestOperatorPlus()
        {
            SimpleFractionClass a = new("1/5");
            SimpleFractionClass b = new(1, 3);

            SimpleFractionClass actual = new (a + b);
            SimpleFractionClass expected = new (8, 15);
            
            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void TestOperatorMinus()
        {
            SimpleFractionClass a = new("1/5");
            SimpleFractionClass b = new(1, 3);

            SimpleFractionClass actual = new(a - b);
            SimpleFractionClass expected = new(2, -15);

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void TestOperatorProduct()
        {
            SimpleFractionClass a = new("1/5");
            SimpleFractionClass b = new(1, 3);

            SimpleFractionClass actual = new(a * b);
            SimpleFractionClass expected = new(1, 15);

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void TestOperatorDivide()
        {
            SimpleFractionClass a = new("1/5");
            SimpleFractionClass b = new(1, 3);

            SimpleFractionClass actual = new(a / b);
            SimpleFractionClass expected = new(3, 5);

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void TestPow()
        {
            SimpleFractionClass a = new(5, 18);

            SimpleFractionClass actual = SimpleFractionClass.Pow(a);
            SimpleFractionClass expected = new(25, 324);

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void TestRevers()
        {
            SimpleFractionClass a = new(5, 18);

            SimpleFractionClass actual = SimpleFractionClass.Revers(a);
            SimpleFractionClass expected = new(18, 5);

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void TestNotEqual()
        {
            SimpleFractionClass a = new(5, 18);

            SimpleFractionClass actual = SimpleFractionClass.Revers(a);
            SimpleFractionClass expected = new(1, 5);

            Assert.IsFalse(expected != actual);
        }
    }
}