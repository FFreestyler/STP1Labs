using lab14;

namespace TestPolynomialClass
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPolynomial()
        {
            var polynomial = new Polynomial();

            var expected = polynomial.Degree();
            var actual = 0;

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void TestDegree()
        {
            var polynomial = new Polynomial(3, 33);

            var expected = polynomial.Degree();
            var actual = 33;

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void TestCoeff()
        {
            var polynomial = new Polynomial(3, 33);

            var expected = polynomial.Degree();
            var actual = 33;

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void TestClear()
        {
            var polynomial = new Polynomial(3, 33);

            polynomial.Clear();
            var expected = polynomial.Degree();
            var actual = 0;

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void TestEqual()
        {
            var polynomialL = new Polynomial(3, 33);
            var polynomialR = new Polynomial(3, 33);


            Assert.IsTrue(polynomialL == polynomialR);
        }

        [TestMethod]
        public void TestSum()
        {
            var polynomialL = new Polynomial(2, 2);
            var polynomialR = new Polynomial(4, 2);
            var polynomialS = polynomialL + polynomialR;


            var expected = polynomialS.Coeff(2);
            var actual = 6;

            Assert.IsTrue(actual == expected);
        }

        [TestMethod]
        public void TestSub()
        {
            var polynomialL = new Polynomial(2, 2);
            var polynomialR = new Polynomial(4, 2);
            var polynomialS = polynomialL - polynomialR;


            var expected = polynomialS.Coeff(2);
            var actual = -2;

            Assert.IsTrue(actual == expected);
        }

        [TestMethod]
        public void TestMul()
        {
            var polynomialL = new Polynomial(2, 2);
            polynomialL.Add(1, 1);
            var polynomialR = new Polynomial(2, 2);
            polynomialR.Add(1, 1);
            var polynomialS = polynomialL * polynomialR;


            var expected = polynomialS.Calculation(2);
            var actual = 100;

            Assert.IsTrue(actual == expected);
        }
    }
}