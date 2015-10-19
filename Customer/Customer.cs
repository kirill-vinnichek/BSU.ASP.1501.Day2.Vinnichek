using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Task2
{
    public class Customer:IFormattable
    {
   
       public string Name { get; set; }
       public string ContactPhone { get; set; }
       public decimal Revenue { get; set; }

       
        public Customer()
        { }
        public Customer(string name,string phone,decimal revenue)
        {
            this.Name = name;
            this.ContactPhone = phone;
            this.Revenue = revenue;
        }

        public override string ToString()
        {
            return this.ToString("G", CultureInfo.CurrentCulture);
        }

        public string ToString(string format)
        {
            return this.ToString(format, CultureInfo.CurrentCulture);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (String.IsNullOrEmpty(format))
                format = "G";
            if (formatProvider == null)
                formatProvider = CultureInfo.CurrentCulture;

            var formats = format.ToUpperInvariant().Split(',');
            var sb = new StringBuilder();

            for (int i = 0; i < formats.Length; i++)
            {
                switch (formats[i])
                {
                    case "G":
                        sb.Append(String.Format("{0} {1} {2}", Name.ToString(formatProvider), ContactPhone.ToString(formatProvider), Revenue.ToString(formatProvider)));
                        break;
                    case "N":
                        sb.Append(String.Format("{0}", Name.ToString(formatProvider)));
                        break;
                    case "P":
                        sb.Append(String.Format("{0}", ContactPhone.ToString(formatProvider)));
                        break;
                    case "R":
                        sb.Append(String.Format("{0}", Revenue.ToString(formatProvider)));
                        break;
                    default:
                        throw new FormatException(String.Format("The {0} format string is not supported.", format));

                }
                if(i!=formats.Length-1)
                 sb.Append(" ");
            }
            return sb.ToString();
        }
    }
}
