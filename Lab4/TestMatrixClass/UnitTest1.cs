using Lab4;

namespace TestMatrixClass
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void TestMethod1()
        {
            Lab4.MatrixClass a = new Lab4.MatrixClass(0, 2);

        }
    }
}