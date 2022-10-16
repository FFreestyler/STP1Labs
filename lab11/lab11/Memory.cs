using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11
{
    public class Memory<T>
    {
        public T FNumber;
        bool isTrue;

        public Memory()
        {
            clear();
        }

        public void Storage(T obj)
        {
            FNumber = obj;
            isTrue = true;
        }

        public T Read()
        {
            return FNumber;
            isTrue = true;
        }

        public void Add(T obj)
        {
            dynamic a = FNumber;
            dynamic b = obj;
            FNumber = a + b;
            isTrue = true;
        }

        public void clear()
        {
            FNumber = default;
            isTrue = false;
        }

        public string GetState()
        {
            return isTrue ? "On" : "Off";
        }

        public T GetNumber()
        {
            return FNumber;
        }
    }
}
