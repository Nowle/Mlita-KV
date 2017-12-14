using System;
using System.Collections.Generic;

namespace RootsCorrection
{
    internal static class Program
    {
        public static void Main()
        {
            const int n = 6;
            const double x1 = 0.716+0.043*n;

            Console.WriteLine("Значения функции y=exp^x:");
            Console.WriteLine("{0:0.000000}",Fexp(x1)); 
            Console.WriteLine("Значения функции y=exp^x вычисленные прямым способом:");
            Console.WriteLine("2,648517"); 
            Console.WriteLine("Значения функции y=ln(1+x):");
            Console.WriteLine("{0:0.000000}",Fln(x1));
            Console.WriteLine("Значения функции y=ln(1+x) вычисленные прямым способом:");
            Console.WriteLine("{0:0.000000}",Math.Log(x1+1));
            Console.WriteLine("Значения функции y=cos(x):");
            Console.WriteLine("{0:0.000000}",Fcos(x1));
            Console.WriteLine("Значения функции y=cos(x) вычисленные прямым способом:");
            Console.WriteLine("{0:0.000000}",Math.Cos(x1));
            Console.WriteLine("Значения функции y=sin(x):");
            Console.WriteLine("{0:0.000000}",Fsin(x1));
            Console.WriteLine("Значения функции y=sin(x) вычисленные прямым способом:");
            Console.WriteLine("{0:0.000000}",Math.Sin(x1));
            var a = Console.ReadLine();

        }

        private static double Fexp(double x)
        {
            double f = 1, sum = 0;
            var i = 1;
            while (f > 0.000001)
            {
                sum += f;
                f *= x / i;
                i++;
            }
            return sum;
        }

        private static double Fln(double x)
        {
            double f = x, sum = x;
            var i = 1;
            while (Math.Abs(f) > 0.000001)
            {
                f *= -x * i / (i + 1);
                sum += f;
                i++;
            }
            return sum;
        }

        private static double Fsin(double x)
        {
            double f = x, sum = x;
            x *= x;
            var i = 2;
            while (Math.Abs(f) > 0.000001)
            {
                f *= -x / (i * (i + 1));
                sum += f;
                i += 2;
            }
            return sum;
        }

        private static double Fcos(double x)
        {
            double f = 1, sum = 1;
            x *= x;
            var i = 1;
            while (Math.Abs(f) > 0.000001)
            {
                f *= -x / (i * (i + 1));
                sum += f;
                i += 2;
            }
            return sum;
        }
    }
}