using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lab8
{
    public class PNumberEditor
    {
        private string currentNumber;

        public PNumberEditor()
        {
            clear();
        }

        public bool IsNull()
        {
            return currentNumber.Split(" ")[0] == "0";
        }

        public void toggleNegative()
        {
            var parsed = currentNumber.Split(" ");
            if(parsed[0][0] == '-')
            {
                currentNumber.Remove(0, 1);
            } 
            else
            {
                currentNumber.Insert(0, "-");
            }
        }

        public string appendNumber(int num)
        {
            currentNumber += num.ToString();
            return currentNumber;
        }

        public string appendZero()
        {
            return appendNumber(0);
        }

        public string popNumberBack()
        {
            currentNumber = currentNumber.Substring(0, currentNumber.Length - 1);
            return currentNumber;
        }

        public string clear()
        {
            currentNumber = "0";
            return currentNumber;
        }

        public string getNumber()
        {
            return currentNumber;
        }

        public string setNumber(string number)
        {
            bool isValid = Regex.Match(number, "[0-9]+").Success;
            if (!isValid)
            {
                throw new Exception("Number is not valid");
            }
            currentNumber = number;
            return currentNumber;
        }
    }
}
