using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace basic2_25061
{
    public class Program
    {
        public const int Times = 1000000;
        public const int Element = 496753;
        public const int Divide = 777;

        public static void Main(string[] args)
        {
            WriteLine("List", CheckList());
            WriteLine("ArrayList", CheckArrayList());
            WriteLine("LinkedList", CheckLinkedList());
        }

        private static void WriteLine(string listType, (long timeAdd, long timeSearch, long timedivide, StringBuilder sb) results)
        {
            StringBuilder sb = new();
            
            sb.AppendLine($"{listType}:");
            sb.AppendLine($"Наполнение = {results.timeAdd} мс");
            sb.AppendLine($"Search элемента = {results.timeSearch} мс");
            sb.AppendLine($"Фильтрация элементов = {results.timedivide} мс");
            //Для просмотра содержимого убрать .Length (для чистоты консоли стоит)
            sb.AppendLine($"Элементы: {results.sb.Length.ToString()}");

            Console.WriteLine(sb.ToString());
        }

        private static long StopwatchTime(Action action)
        {
            var stopwatch = Stopwatch.StartNew();
            action.Invoke();
            stopwatch.Stop();

            return stopwatch.ElapsedMilliseconds;
        }

        private static (long timeAdd, long timeSearch, long timedivide, StringBuilder sb) CheckList()
        {
            List<int> list = new();
            StringBuilder sb = new();

            long timeAdd = StopwatchTime(() =>
            {
                for (int i = 0; i < Times; i++)
                {
                    list.Add(i);
                }
            });

            long timeSearch = StopwatchTime(() =>
            {
                var tmp = list[Element];
            });

            long timeDivide = StopwatchTime(() =>
            {
                foreach (int element in list)
                {
                    if (element % Divide == 0)
                    {
                        sb.Append($"{element} ");
                    }
                }
            });

            return (timeAdd, timeSearch, timeDivide, sb);
        }

        private static (long timeAdd, long timeSearch, long timedivide, StringBuilder sb) CheckArrayList()
        {
            ArrayList list = new();
            StringBuilder sb = new();

            long timeAdd = StopwatchTime(() =>
            {
                for (int i = 0; i < Times; i++)
                {
                    list.Add(i);
                }
            });

            long timeSearch = StopwatchTime(() =>
            {
                var tmp = list[Element];
            });

            long timeDivide = StopwatchTime(() =>
            {
                foreach (int element in list)
                {
                    if (element % Divide == 0)
                    {
                        sb.Append($"{element} ");
                    }
                }
            });

            return (timeAdd, timeSearch, timeDivide, sb);
        }

        private static (long timeAdd, long timeSearch, long timedivide, StringBuilder sb) CheckLinkedList()
        {
            LinkedList<int> list = new();
            StringBuilder sb = new();

            long timeAdd = StopwatchTime(() =>
            {
                for (int i = 0; i < Times; i++)
                {
                    list.AddLast(i);
                }
            });

            long timeSearch = StopwatchTime(() =>
            {
                var tmp = list.ElementAt(Element);
            });

            long timeDivide = StopwatchTime(() =>
            {
                foreach (int element in list)
                {
                    if (element % Divide == 0)
                    {
                        sb.Append($"{element} ");
                    }
                }
            });

            return (timeAdd, timeSearch, timeDivide, sb);
        }
    }
}
