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

        private delegate int NODAlgorithm(int a, int b);

        public static int Euclidean(int a,int b)
        {
            return Calculate(EuclideanAlgorithm, a, b);
        }

        public static int Euclidean(params int[] array)
        {
            return Calculate(EuclideanAlgorithm, array);
        }
        public static int Euclidean(int a,int b,out long ticks)
        {
            return Calculate(EuclideanAlgorithm, out ticks, a, b);
        }
        public static long Euclidean(out long ticks, params int[] array)
        {
            return Calculate(EuclideanAlgorithm, out ticks, array);
        }

        public static int Stein(int a, int b)
        {
            return Calculate(SteinAlgorithm, a, b);
        }      
        public static int Stein(int a, int b, out long ticks)
        {
            return Calculate(SteinAlgorithm, out ticks, a, b);
        }        
        public static int Stein(params int[] array)
        {
            return Calculate(SteinAlgorithm, array);
        }
        public static long Stein(out long ticks, params int[] array)
        {
            return Calculate(SteinAlgorithm, out ticks,array);
        }

        private static int EuclideanAlgorithm(int a, int b)
        {
           int temp;
            while (b != 0)
            {
                temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        private static int SteinAlgorithm(int a, int b)
        {

            int shift;
            for (shift = 0; ((a | b) & 1) == 0; ++shift)
            {
                a >>= 1;
                b >>= 1;
            }

            while ((a & 1) == 0)
                a >>= 1;

            do
            {
                while ((b & 1) == 0)
                    b >>= 1;
                if (a > b)
                {
                    int d = b;
                    b = a;
                    a = d;
                }
                b = b - a;
            } while (b != 0);
            return a << shift;
        }       
        private static int Calculate(NODAlgorithm algorithm,int a,int b)
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

            return algorithm(a, b);
        }
        private static int Calculate(NODAlgorithm algorithm, params int[] array)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (array.Length == 0)
                throw new ArgumentException("Input array is empty");
            if (array.Length == 1)
                return array[0];
            int result = Calculate(algorithm,array[0], array[1]);
            for (int i = 2; i < array.Length; i++)
                result = Calculate(algorithm,result, array[i]);
            return result;
        }

        private static int Calculate(NODAlgorithm algorithm,out long ticks, int a, int b)
        {
            var sw = new Stopwatch();
            sw.Start();
            int result = Calculate(algorithm,a, b);
            sw.Stop();
            ticks = sw.ElapsedTicks;
            return result;
        }
        private static int Calculate(NODAlgorithm algorithm,out long ticks, params int[] array)
          {
              var sw = new Stopwatch();
              sw.Start();
              int result = Calculate(algorithm, array);
              sw.Stop();
              ticks = sw.ElapsedTicks;
              return result;
          }


    }
}
