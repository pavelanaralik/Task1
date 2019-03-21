using CustomClassLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomClassLibrary
{
    public class Parse
    {
        public static int ParseToInt32(string str)
        {
            if (str == null)
                throw new ArgumentNullException();

            str = str.Trim();

            if (string.IsNullOrEmpty(str))
                throw new ArgumentFormatException();

            var isMinus = false;
            var startIndex = 0;

            switch (str[0])
            {
                case '-':
                    if (str.Length == 1)
                        throw new ArgumentFormatException();

                    isMinus = true;
                    startIndex = 1;
                    break;
                case '+':
                    if (str.Length == 1)
                        throw new ArgumentFormatException();

                    startIndex = 1;
                    break;
            }

            var result = Calculate(str, startIndex);
            return isMinus ? result : -result;
        }

        /// <summary>
        /// Returns a negative number because for int 
        /// a negative number modulo more then positive(From -2,147,483,648 to 2,147,483,647)
        /// </summary>
        private static int Calculate(string str, int startIndex)
        {
            var result = 0;      
            var length = str.Length;
            for (int i = startIndex; i < length; i++)
            {
                if (!IsNumber(str[i]))
                    throw new ArgumentFormatException();

                try
                {
                    checked
                    {
                        result = result * 10 - (str[i] - '0');
                    }
                }
                catch (OverflowException e)
                {
                    throw new OverflowException(string.Format(ErrorMessage.OverflowExceptionMsg, typeof(int).ToString()), e);
                }
            }

            return result;
        }

        private static bool IsNumber(char ch)
        {
            return ((ch) >= 0x30 && (ch) <= 0x39);
        }
    }
}
