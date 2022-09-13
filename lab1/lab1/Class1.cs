using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class Class1
    {
        public static float Multiply(float[] array)
        {
            float mul = 1;
            for(int i = 0; i < array.Length; i+=2)
            {
                mul *= array[i];
            }
            return mul;
        }

        public static float[] ShiftArray(float[] array, int shift)
        {
            int fixedShift = Math.Abs(shift % array.Length);

            var newArray = new float[array.Length];

            Array.Copy(array, 0, newArray, fixedShift, array.Length - fixedShift);
            Array.Copy(array, array.Length - fixedShift, newArray, 0, fixedShift);

            return newArray;
        }

        public static (int, int) MaxEven(int[] array)
        {
            int maxNumber = int.MinValue;
            int maxNumberIndex = -1;
            for (int i = 0; i < array.Length; i += 2)
            {
                if (maxNumber < array[i] && array[i] % 2 == 0)
                {
                    maxNumber = array[i];
                    maxNumberIndex = i;
                }
            }
            return (maxNumber, maxNumberIndex);
        }
    }
}
