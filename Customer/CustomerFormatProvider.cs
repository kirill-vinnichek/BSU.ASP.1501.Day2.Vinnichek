using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
   public class CustomerFormatProvider:IFormatProvider,ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
           return formatType == typeof(ICustomFormatter) ? this:null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            var customer = arg as Customer;
            if (customer == null)
                return String.Empty;

            if(format!="UN")
                throw new FormatException(String.Format("The {0} format string is not supported.", format));

            return customer.Name.ToUpperInvariant();        }
    }
}
