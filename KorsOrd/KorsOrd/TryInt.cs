using System;
using System.Collections.Generic;
using System.Text;

namespace KorsOrd
{
    internal class TryInt
    {
        public bool TestStringIsInt(string input)
        {
            try
            {
                int.Parse(input);

                //string går att replaca med en int
                return true;
            }
            catch (Exception e)
            {
                //string går inte att replaca -> det är bokstäver/tecken t.ex
                return false;
            }
        }
    }
}
