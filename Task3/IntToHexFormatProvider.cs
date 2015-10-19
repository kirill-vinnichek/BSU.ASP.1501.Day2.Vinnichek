using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class IntToHexFormatProvider:IFormatProvider,ICustomFormatter
    {
        private static readonly char[] hexNumbers ={'0','1','2','3','4','5','6','7','8','9','A','B','C','D','E','F'};

        public object GetFormat(Type formatType)
        {
            return formatType == typeof(ICustomFormatter) ? this : null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg == null || (!(arg is int) && !(arg is long)))
                throw new ArgumentException("Wrong argument type");
            if (format.ToUpperInvariant()!="H")
                throw new FormatException(String.Format("The {0} format string is not supported.", format));

            var num = Convert.ToInt64(arg);
            bool isNegativ = false;
            if (num<0)
            {
                num *=-1;
                isNegativ = true;
            }
            var sb = new StringBuilder();
            do
            {
                sb.Append(hexNumbers[num % 16]);
                num /= 16;

            } while (num != 0);

                return (isNegativ ? "-" : "") + "0x" + new string(sb.ToString().Reverse().ToArray()); 

        }
    }
}
