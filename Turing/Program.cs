using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Turing_virtual
{
    internal class Program
    {
        private static int _position = 1;

        private static void Karetka(int n)
        {
            for (var i = 0; i < n; i++)
                Console.Write(' ');
            Console.Write('^');
            Console.WriteLine();
        }

        private static void Main(string[] args)
        {
            var conditions = new Dictionary<string, Dictionary<char, Condition>>();
            Console.WriteLine("Введите ленту");
            var lineS = Console.ReadLine();
            var line = lineS.ToList();
            Console.WriteLine("Пример вводимого состояния q1.1->q2.1L");
            Console.WriteLine(
                "Для прекращения ввода введите 0.");
            Console.WriteLine("Начальное состояние - q1");
            var s = "1";

            var separators = new string[2] {".", "->"};
            while (s != "0")
            {
                s = Console.ReadLine();
                if (s == "0")
                    break;
                var mas = s.Split(separators, 5, StringSplitOptions.RemoveEmptyEntries);
                var condS = mas[0];
                var detailS = mas[1][0];
                var condE = mas[2];
                var writ = mas[3][0];
                var move = mas[3][1];
                var temp = new Condition
                {
                    Move = move,
                    Wr = writ,
                    NewCond = condE
                };
                if (!conditions.ContainsKey(condS))
                    conditions[condS] = new Dictionary<char, Condition>();
                if (!conditions[condS].ContainsKey(detailS))
                    conditions[condS][detailS] = temp;
            }
            var currentCondition = "q1";
            var step = 0;
            while (true)
            {
                if (currentCondition == "q0")
                    break;
                foreach (var e in line)
                    Console.Write(e);
                Console.WriteLine();
                Karetka(_position);
                Thread.Sleep(100);
                switch (conditions[currentCondition][line[_position]].Move)
                {
                    case 'R':
                        step = 1;
                        break;
                    case 'L':
                        step = -1;
                        break;
                }
                switch (step)
                {
                    case 1 when _position == line.Count:
                        line.Add('a');
                        break;
                    case -1 when _position == 0:
                        line.Insert(0, 'a');
                        break;
                }
                var tempest = conditions[currentCondition][line[_position]].NewCond;
                line[_position] = conditions[currentCondition][line[_position]].Wr;
                currentCondition = tempest;
                _position += step;
            }

            Console.WriteLine("Машина завершила работу.");
            foreach (var e in line)
                Console.Write(e);
        }

        private struct Condition
        {
            public char Wr;
            public char Move;
            public string NewCond;
        }
    }
}