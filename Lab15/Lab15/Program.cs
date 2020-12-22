using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab15
{
    internal class Time
    {
        private int _hours, _minutes, _seconds;

        public int Hours
        {
            get => _hours;
            set
            {
                if (value >= 0 && value <= 23)
                {
                    _hours = value;
                }
            }
        }

        public int Minutes
        {
            get => _minutes;
            set
            {
                if (value >= 0 && value <= 59)
                {
                    _minutes = value;
                }
            }
        }

        public int Seconds
        {
            get => _seconds;
            set
            {
                if (value >= 0 && value <= 59)
                {
                    _seconds = value;
                }
            }
        }

        public string Type
        {
            get
            {
                if (Hours >= 6 && Hours <= 11)
                    return "Утро";
                else if (Hours >= 12 && Hours <= 17)
                    return "День";
                else if (Hours >= 18 && Hours <= 23)
                    return "Вечер";
                else
                    return "Ночь";
            }
        }

        public override string ToString()
        {
            return $"{Hours}:{Minutes}:{Seconds}";
        }
    }

    class Program
    {
        static void FirstTask()
        {
            var months = new[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

            Console.WriteLine("Введите n:");
            int n = Convert.ToInt32(Console.ReadLine());

            var queryN = from month in months where month.Length == n select month;
            Console.WriteLine($"Месяцы с длинной {n}:");
            foreach (var res in queryN)
            {
                Console.WriteLine($"* {res}");
            }

            var querySummerWinter = from month in months
                                    where month.ToLower().StartsWith("j") || month == "February" || month == "December" || month == "August"
                                    select month;

            Console.WriteLine("Летние и зимние месяцы:");
            foreach (var res in querySummerWinter)
            {
                Console.WriteLine($"* {res}");
            }

            var queryAlphabet = from month in months orderby month select month;
            Console.WriteLine("Сортировка по алфавиту:");
            foreach (var res in queryAlphabet)
            {
                Console.WriteLine($"* {res}");
            }

            var query = from month in months where month.ToLower().Contains("u") && month.Length >= 4 select month;

            Console.WriteLine("Месяцы с буквой \"u\" и длиной не менее 4:");
            foreach (var res in query)
            {
                Console.WriteLine($"* {res}");
            }
        }

        static void SecondTask()
        {
            var list = new List<Time>();
            var rnd = new Random();

            Console.WriteLine("Список:");
            for (var i = 0; i < 10; i++)
            {
                list.Add(new Time() { Hours = rnd.Next(0, 24), Minutes = rnd.Next(0, 60), Seconds = rnd.Next(0, 60) });
                Console.WriteLine(list.Last());
            }

            Console.WriteLine();

            Console.WriteLine("Введите час:");
            int hours = Convert.ToInt32(Console.ReadLine());

            var queryHours = list.Where(time => time.Hours == hours);
            Console.WriteLine("время с заданным значением часа:");
            if (queryHours.Count() != 0)
                foreach (var res in queryHours) Console.WriteLine(res);
            else
                Console.WriteLine("не найдено");

            var queryGroup = list.GroupBy(time => time.Type);
            Console.WriteLine("списки времен по группам: ночь, утро, день, вечер:");
            foreach (var res in queryGroup)
            {
                Console.WriteLine($"{res.Key}:");
                foreach (var time in res)
                {
                    Console.WriteLine(time);
                }
            }

            Console.WriteLine("упорядоченный список времен:");
            var queryOrder = from time in list orderby time.Hours, time.Minutes, time.Seconds select time;
            foreach (var res in queryOrder)
            {
                Console.WriteLine(res);
            }

            var queryMin = queryOrder.Take(1);
            Console.WriteLine($"минимальное время: {queryMin.First()}");

            var query = list.Where(time => time.Hours == time.Minutes).Take(1);
            Console.WriteLine("первое время, в котором часы и минуты совпадают:");
            if (query.Count() != 0)
                foreach (var res in query) Console.WriteLine(res);
            else
                Console.WriteLine("не найдено");
        }

        static void Main(string[] args)
        {
            FirstTask();
            SecondTask();
        }
    }
}