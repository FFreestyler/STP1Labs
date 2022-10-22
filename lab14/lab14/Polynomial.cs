using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab14
{
    public class Polynomial : SimplePolynomial
    {
        public List<SimplePolynomial> polynomials = new List<SimplePolynomial>();

        public Polynomial(int coeff = 0, int degree = 0)
        {
            this.polynomials.Add(new SimplePolynomial(coeff, degree));
        }

        public int Degree()
        {
            if (polynomials.Count == 0)
            {
                return 0;
            }

            return polynomials.Max().GetDegree();
        }

        public int Coeff(int degree)
        {
            if(polynomials.Count() == 0)
            {
                return 0;
            }

            foreach(SimplePolynomial p in polynomials)
            {
                if(p.GetDegree() == degree)
                { return p.GetCoeff(); }
            }
            return 0;
        }

        public void Clear()
        {
            polynomials.Clear();
        }

        public static Polynomial operator +(Polynomial lhs, Polynomial rhs)
        {
            var maxDegree = Math.Max(lhs.Degree(), rhs.Degree());

            var newPoly = new Polynomial();

            for (int i = 0; i <= maxDegree; i++)
            {
                bool atLeastOne = false;
                int sum = 0;

                for (int j = 0; j < lhs.polynomials.Count(); j++)
                {
                    if (lhs.polynomials[j].GetDegree() == i)
                    {
                        sum += lhs.polynomials[j].GetCoeff();
                        atLeastOne = true;
                    }
                }

                for (int j = 0; j < rhs.polynomials.Count(); j++)
                {
                    if (rhs.polynomials[j].GetDegree() == i)
                    {
                        sum += rhs.polynomials[j].GetCoeff();
                        atLeastOne = true;
                    }
                }

                if (atLeastOne)
                {
                    newPoly.polynomials.Add(new SimplePolynomial(sum, i));
                }
            }
            return newPoly;
        }

        public static Polynomial operator -(Polynomial lhs, Polynomial rhs)
        {
            var maxDegree = Math.Max(lhs.Degree(), rhs.Degree());
            var maxSize = Math.Max(lhs.polynomials.Count(), rhs.polynomials.Count());

            bool isRhsPol = lhs.polynomials.Count() > rhs.polynomials.Count();

            var newPoly = new Polynomial();

            for (int i = 0; i <= maxDegree; i++)
            {
                bool atLeastOne = false;
                int sum = 0;

                for (int j = 0; j < lhs.polynomials.Count(); j++)
                {
                    if (lhs.polynomials[j].GetDegree() == i)
                    {
                        sum += lhs.polynomials[j].GetCoeff();
                        atLeastOne = true;
                    }
                }

                for (int j = 0; j < rhs.polynomials.Count(); j++)
                {
                    if (rhs.polynomials[j].GetDegree() == i)
                    {
                        sum -= rhs.polynomials[j].GetCoeff();
                        atLeastOne = true;
                    }
                }

                if (atLeastOne)
                {
                    newPoly.polynomials.Add(new SimplePolynomial(sum, i));
                }
            }
            return newPoly;
        }

        public static bool operator==(Polynomial lhs, Polynomial rhs)
        {
            if(lhs.polynomials.Count() != rhs.polynomials.Count())
            {
                return false;
            }

            bool check = false;

            for(int i=0 ; i < lhs.polynomials.Count(); i++)
            {
                if (lhs.polynomials[i].GetCoeff() == rhs.polynomials[i].GetCoeff() &&
                    lhs.polynomials[i].GetDegree() == rhs.polynomials[i].GetDegree())
                {
                    check = true;
                } 
                else
                {
                    check = false;
                }
            }

            return check;
        }

        public static bool operator !=(Polynomial lhs, Polynomial rhs)
        {
            if (lhs.polynomials.Count() != rhs.polynomials.Count())
            {
                return true;
            }

            bool check = false;

            for (int i = 0; i < lhs.polynomials.Count(); i++)
            {
                if (lhs.polynomials[i].GetCoeff() == rhs.polynomials[i].GetCoeff() &&
                    lhs.polynomials[i].GetDegree() == rhs.polynomials[i].GetDegree())
                {
                    check = false;
                }
                else
                {
                    check = true;
                }
            }

            return check;
        }

        public void Add(int coeff, int degree)
        {
            var el = new SimplePolynomial();

            foreach (SimplePolynomial p in polynomials)
            {
                if (p.GetDegree() == degree)
                {
                    p.SetCoeff(p.GetCoeff() + coeff);
                }
                else
                {
                    el = p;
                }
            }

            if (el == polynomials.Last())
            {
                polynomials.Add(new SimplePolynomial(coeff, degree));
            }

        }

        public static Polynomial operator *(Polynomial lhs, Polynomial rhs)
        {
            Polynomial newPoly = new Polynomial();

            for (int i = 0; i < lhs.polynomials.Count(); i++)   
            {
                for (int j = 0; j < rhs.polynomials.Count(); j++)
                {
                    newPoly.Add(lhs.polynomials[i].GetCoeff() * rhs.polynomials[j].GetCoeff(),
                             lhs.polynomials[i].GetDegree() + rhs.polynomials[j].GetDegree());
                }
            }

            return newPoly;
        }

        public int Calculation(int x)
        {
            int result = 0;

            foreach(SimplePolynomial p in polynomials)
            {
                result += p.SimpleCalculation(x);
            }

            return result;
        }
    }
}
