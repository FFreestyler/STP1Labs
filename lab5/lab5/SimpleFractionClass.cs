using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    public class SimpleFractionClass
    {
        private int _nominator = 0;
        private int _denominator = 0;

        private void reduce()
        {
            var GCD = gcd(_nominator, _denominator);

            if (GCD != 1)
            {
                _nominator /= GCD;
                _denominator /= GCD;
            }

        }

        private static int gcd(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        private static int lcm(int a, int b)
        {
            return (a / gcd(a, b)) * b;
        }

        public SimpleFractionClass(int numerator, int denominator)
        {
            this._nominator = numerator;
            this._denominator = denominator;

            reduce();
        }

        public SimpleFractionClass(string fractionString)
        {
            int delimeterPosition = fractionString.IndexOf('/');

            if (delimeterPosition < 0)
            {
                throw new Exception($"Invalid string"); ;
            }

            _nominator = int.Parse(fractionString.Substring(0, delimeterPosition));
            _denominator = int.Parse(fractionString.Substring(delimeterPosition + 1));
        }

        public SimpleFractionClass(SimpleFractionClass x)
        {
            _nominator = x._nominator;
            _denominator = x._denominator;
        }

        public void Show()
        {
            Console.WriteLine($"Nominator {_nominator}");
            Console.WriteLine($"Denominator {_denominator}");
        }

        public static SimpleFractionClass operator +(SimpleFractionClass a, SimpleFractionClass b)
        {
            var unionDenominator = lcm(a._denominator, b._denominator);

            var firstNumber = a._nominator * unionDenominator / a._denominator;
            var secondNumber = b._nominator * unionDenominator / b._denominator;

            return new(firstNumber + secondNumber, unionDenominator);
        }

        public static SimpleFractionClass operator -(SimpleFractionClass a, SimpleFractionClass b)
        {
            var unionDenominator = lcm(a._denominator, b._denominator);

            var firstNumber = a._nominator * unionDenominator / a._denominator;
            var secondNumber = b._nominator * unionDenominator / b._denominator;

            return new(firstNumber - secondNumber, unionDenominator);
        }

        public static SimpleFractionClass operator *(SimpleFractionClass a, SimpleFractionClass b)
        {
            return new(a._nominator * b._nominator, a._denominator * b._denominator);
        }

        public static SimpleFractionClass operator /(SimpleFractionClass a, SimpleFractionClass b)
        {
            var nominator = a._nominator * b._denominator;
            var denominator = a._denominator * b._nominator;

            if (denominator < 0)
            {
                nominator *= -1;
                denominator *= -1;
            }

            return new(a._nominator * b._denominator, a._denominator * b._nominator);
        }

        public static SimpleFractionClass Pow(SimpleFractionClass a, int n = 2)
        {
            return new((int)Math.Pow(a._nominator, n), (int)Math.Pow(a._denominator, n));
        }

        public static SimpleFractionClass Revers(SimpleFractionClass a)
        {
            return new(a._denominator, a._nominator);
        }

        public static SimpleFractionClass Minus(SimpleFractionClass a)
        {
            SimpleFractionClass z = new(0, 1);
            return new(z - a);
        }

        public static bool operator ==(SimpleFractionClass a, SimpleFractionClass b)
        {
            return (a._nominator == b._nominator && a._denominator == b._denominator);
        }

        public static bool operator !=(SimpleFractionClass a, SimpleFractionClass b)
        {
            return (a._nominator != b._nominator && a._denominator != b._denominator);
        }

        public int GetNominatorInt()
        {
            return _nominator;
        }

        public int GetDenominatorInt()
        {
            return _denominator;
        }

        public string GetNominatorString()
        {
            return _nominator.ToString();
        }

        public string GetDenominatorString()
        {
            return _denominator.ToString();
        }

        new public string ToString()
        {
            var nominator = GetNominatorString();
            var denominator = GetDenominatorString();

            string sout = nominator + "/" + denominator;

            return sout;
        }
    }
}
