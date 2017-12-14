using System;
using System.Collections.Generic;

namespace FourthLab
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var a = GetStrToArray();

            var firstWord = Console.ReadLine();
            var secondWord = Console.ReadLine();

            var isInto=false;
            Console.Write(' ');
            foreach (var word in a)
            {
                if (word==secondWord)
                {
                    isInto = false;
                }
                if (isInto)
                {
                    Console.Write(word+" ");
                }

                if (word==firstWord)
                {
                    isInto = true;
                    firstWord = "|";
                }


            }
        }

        private static IEnumerable<string> GetStrToArray()
        {
            return Console.ReadLine().Split(' ');
        }
    }
}