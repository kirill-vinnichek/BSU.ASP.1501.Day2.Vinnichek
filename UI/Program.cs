using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2;
using Task3;
using Task4;
namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new Customer("Sai", "+375505", 50);
            Console.WriteLine(c);
            Console.WriteLine(String.Format("{0:N}123", c));
            var pr = new CustomerFormatProvider();
            Console.WriteLine(String.Format(pr, "{0:UN}", c));
            Console.WriteLine("-----------------------------------");
            var ith = new IntToHexFormatProvider();
            Console.WriteLine(String.Format(ith, "{0:H}", 88));
            Console.WriteLine("-----------------------------------");
            int[] a = { 4, 2, 8 };
           // Console.WriteLine(NOD.Euclidian());
        }
    }
}
