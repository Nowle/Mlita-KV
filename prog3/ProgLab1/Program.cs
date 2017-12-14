using System;
using System.Collections.Generic;
    
namespace ProgLab1
{
    internal static class Program
    {
        public static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            var size = int.Parse(Console.ReadLine() ?? throw new FormatException());
            var matrix = new float[size,size];
            var vector= new float[size];
            var vector2 = new float[size];
            for (var i = 0; i < size; i++)
            {
                vector2[i] = 1;
            }
            for (var i = 0; i < size; i++)
            {
                var mas = Console.ReadLine()?.Split(' ');
                for (var j = 0; j < size; j++)
                {
                    matrix[i,j] = float.Parse(mas[j]);
                }
            }
            
            var svector = Console.ReadLine()?.Split(' ');
            for (var i = 0; i < size; i++)
            {
                if (svector != null) vector[i] = float.Parse(svector[i]);
            }
            for (var i = size-1; i > 0; i--)
            {
                var n = vector[i];
                for (var j = size-1; j >0; j--)
                {
                     n=n- matrix[i, j]*vector2[j];
                    
                }
                n += matrix[i, i]*vector2[i];
                vector2[i ] = n / matrix[i , i ];
                
            }
            for (var i = 0; i < size; i++)
            {
                Console.Write("{0:##.000}",vector2[i]);
                Console.Write(" ");
            }
            Console.WriteLine();

        }

    }
}