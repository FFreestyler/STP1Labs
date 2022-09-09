namespace lab2
{
    public class Class1
    {
        public static (int, int) Max(int a, int b)
        {
            return (Math.Max(a, b), Math.Min(a, b));
        }

        public static int EvenMultiplyMatrix(int[,] array)
        {
            int mul = 1;
            for(int i = 0; i < array.GetLength(0); i++)
            {
                for(int j = 0; j < array.GetLength(1); j++)
                {
                    if(array[i,j] % 2 == 0)
                    {
                        mul *= array[i,j];
                    }
                }
            }
            return mul;
        }

        public static int EvenSumMatrix(int[,] array)
        {
            int sum = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1) - i; j++)
                {
                    if (array[i, j] % 2 == 0)
                    {
                        sum += array[i, j];
                    }
                }
            }
            return sum;
        }
    }
}