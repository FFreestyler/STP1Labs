using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab14
{
    public class SimplePolynomial
    {
        private int _coeff { get; set; }
        private int _degree { get; set; }

        public SimplePolynomial(int coeff = 0, int degree = 0)
        {
            this._coeff = coeff;
            this._degree = degree;
        }

        public int GetDegree()
        {
            return _degree;
        }

        public void SetDegree(int degree)
        {
            _degree = degree;
        }

        public int GetCoeff()
        {
            return _coeff;
        }

        public void SetCoeff(int coeff)
        {
            _coeff = coeff;
        }

        public static bool operator ==(SimplePolynomial lhs, SimplePolynomial rhs)
        {
            return lhs._coeff == rhs._coeff && lhs._degree == rhs._degree;
        }

        public static bool operator !=(SimplePolynomial lhs, SimplePolynomial rhs)
        {
            return lhs._coeff != rhs._coeff || lhs._degree != rhs._degree;
        }

        public SimplePolynomial Differentiate()
        {
            return new SimplePolynomial(_coeff * (_degree), _degree - 1);
        }

        public int SimpleCalculation(int x)
        {
            return ((int)(_coeff * Math.Pow(x, _degree)));
        }

        public string ToString(string x = "x")
        {
            return $"{_coeff}{x} ^ {_degree}";
        }

        public static bool operator >(SimplePolynomial lhs, SimplePolynomial rhs)
        {
            return lhs.SimpleCalculation(1) > rhs.SimpleCalculation(1);
        }

        public static bool operator <(SimplePolynomial lhs, SimplePolynomial rhs)
        {
            return lhs.SimpleCalculation(1) < rhs.SimpleCalculation(1);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
