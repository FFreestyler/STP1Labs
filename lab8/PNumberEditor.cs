using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab7;

namespace lab8
{
    internal class PNumberEditor
    {
        string currentString;

        bool isNull()
        {
            return currentString.Split(" ")[0] == null;
        }

        string SetNegative()
        {
            var parsed = currentString.Split(" ");
            if (parsed[0][0] == '-')
            {
                currentString.Remove(0, 1);
            } else
            {
                currentString.Insert(0, "-");
            }

            return currentString;
        }
    }


}
