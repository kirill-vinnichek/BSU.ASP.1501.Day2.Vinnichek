using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public static class NOD
    {
        public static int Euclidean(int a,int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            int temp;
            while (b != 0)
            {
                temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public static int Euclidean(params int[] array)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (array.Length == 0)
                throw new ArgumentException("Input array is empty");
            if (array.Length == 1)
                return array[0];
            int result = Euclidean(array[0], array[1]);
            for (int i = 2; i < array.Length; i++)
                result = Euclidean(result, array[i]);
            return result;
        }

        public static int Euclidean(int a,int b,out long ticks)
        {
            var sw = new Stopwatch();
            sw.Start();
            int result = Euclidean(a, b);
            sw.Stop();
            ticks = sw.ElapsedTicks;
            return result;
        }
        public static long Euclidean(out long ticks, params int[] array)
        {
            var sw = new Stopwatch();
            sw.Start();
            int result = Euclidean(array);
            sw.Stop();
            ticks = sw.ElapsedTicks;
            return result;
        }

        public static int Stein(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            if (a == 0)
                return b;
            if (a == 1)
                return 1;
            if (b == 0)
                return a;
            if (b == 1)
                return 1;
            if (a == b)
                return a;

            if (a % 2 == 0)
            {
                if (b % 2 != 0)
                    return Stein(a >> 1, b);
                return Stein(a >> 1, b >> 1) << 1;
            }
            if (b % 2 == 0)
                return Stein(a, b >> 1);

            if (a > b)
                return Stein((a - b) >> 1, b);

            return Stein((b - a) >> 1, a);
        }

       
        public static int Stein(int a, int b, out long ticks)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int result = Stein(a, b);
            sw.Stop();
            ticks = sw.ElapsedTicks;
            return result;
        }

        
        public static int Stein(params int[] array)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (array.Length == 0)
                throw new ArgumentException("Input array is empty");
            if (array.Length == 1)
                return array[0];
            int result = Stein(array[0], array[1]);
            for (int i = 2; i < array.Length; i++)
                result = Stein(result, array[i]);
            return result;
        }

        public static long Stein(out long ticks, params int[] array)
        {
            var sw = new Stopwatch();
            sw.Start();
            int result = Stein(array);
            sw.Stop();
            ticks = sw.ElapsedTicks;
            return result;
        }
    }
}
