using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Lab4
{
    public class MyException : Exception
    {
        public MyException(string s) : base(s)
        { }
    }
    public class MatrixClass
    {
        private readonly int[,] _matrix;
        public int Rows { get; }
        public int Cols { get; }

        public MatrixClass(int i, int j)
        {
            if (i <= 0)
            {
                throw new MyException($"недопустимое значение строки = { i }");
            }
            if (j <= 0)
            {
                throw new MyException($"недопустимое значение столбца = { j }");
            }
            Rows = i;
            Cols = j;
            _matrix = new int[i, j];
        }

        public MatrixClass(int[,] matrix, int i, int j)
        {
            if(i <= 0)
            {
                throw new MyException($"недопустимое значение строки = {i}");
            }
            if(j <= 0)
            {
                throw new MyException($"недопустимое значение столбца = {j}");
            }

            Rows = i;
            Cols = j;
            _matrix = matrix;
            Array.Copy(matrix, _matrix, matrix.Length);
        }

        public int this[int i, int j]
        {
            get
            {
                if (i < 0 | i > Rows - 1)
                {
                    throw new MyException($"неверное значение i = {i}");
                }
                if (j < 0 | j > Cols - 1)
                {
                    throw new MyException($"неверное значение j = {j}");
                }
                return _matrix[i, j];
            }
            set
            {
                if (i < 0 | i > Rows - 1)
                {
                    throw new MyException($"неверное значение i = { i }");
                }
                if (j < 0 | j > Cols - 1)
                {
                    throw new MyException($"неверное значение j = { 0 }");
                }
                _matrix[i, j] = value;
            }
        }

        public static MatrixClass operator +(MatrixClass a, MatrixClass b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols)
            {
                throw new MyException($"количество строк и столбцов в матрицах не одинаково");
            }

            MatrixClass c = new MatrixClass(a.Rows, a.Cols);
            for (int i = 0;
                i < a.Cols;
                i++)
            {
                for (int j = 0;
                    j < a.Rows;
                    j++)
                {
                    c[i, j] = a._matrix[i, j] + b._matrix[i, j];
                }
            }
            return c;
        }

        public static MatrixClass operator -(MatrixClass a, MatrixClass b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols)
            {
                throw new MyException($"количество строк и столбцов в матрицах не одинаково");
            }

            MatrixClass m = new(a.Rows, b.Cols);
            for(int i = 0;
                i < a.Cols;
                i++)
            {
                for(int j = 0;
                    j < b.Rows;
                    j++)
                {
                    m[i, j] = a._matrix[i, j] - b._matrix[i, j];
                }
            }
            return m;
        }

        public static MatrixClass operator *(MatrixClass a, MatrixClass b)
        {
            if (a.Rows != b.Cols)
            {
                throw new MyException($"матрица не квадратная");
            }

            MatrixClass m = new(a.Rows, b.Cols);
            for (int i = 0;
                i < a.Cols;
                i++)
            {
                for (int j = 0;
                    j < b.Rows;
                    j++)
                {
                    m[i, j] = 0;
                    for(int k = 0;
                        k < b.Cols;
                        k++)
                    {
                        m[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return m;
        }

        public static bool operator ==(MatrixClass a, MatrixClass b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols)
            {
                throw new MyException($"количество строк и столбцов в матрицах не одинаково");
            }

            bool q = true;
            for (int i = 0;
                i < a.Cols;
                i++)
            {
                for (int j = 0;
                    j < a.Rows;
                    j++)
                {
                    if (a[i, j] != b[i, j])
                    {
                        q = false; 
                        break;
                    }
                }
            }
            return q;
        }

        public static bool operator !=(MatrixClass a, MatrixClass b)
        {
            return !(a == b);
        }

        public MatrixClass Tranpose()
        {
            if (Rows != Cols)
            {
                throw new MyException($"матрица не квадратная");
            }

            MatrixClass c = new(_matrix, Rows, Cols);
            for (int i = 0;
                i < Rows;
                i++)
            {
                for (int j = 0;
                    j < Cols;
                    j++)
                {
                    c[i, j] = _matrix[j, i];
                }
            }
            return c;
        }

        public int Min()
        {
            int minElement = int.MaxValue;

            for(int i = 0;
                i < Rows;
                i++)
            {
                for(int j = 0;
                    j < Cols;
                    j++)
                {
                    minElement = _matrix[i, j];
                }
            }
            return minElement;
        }

        public void Show()
        {
            for (int i = 0;
                i < Rows;
                i++)
            {
                for (int j = 0;
                    j < Cols; 
                    j++)
                {
                    Console.Write("\t" + this[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public override bool Equals(object? obj)
        {
            return (this as MatrixClass) == (obj as MatrixClass);
        }

        public override string ToString()
        {
            return $"{{{{{JsonConvert.SerializeObject(_matrix).Trim('[', ']').Replace("[", "{").Replace("]", "}")}}}}}";
        }

        public override int GetHashCode()
        {
            return _matrix.GetHashCode();
        }
    }
}
