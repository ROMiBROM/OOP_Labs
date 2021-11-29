using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 1:");
            List<string> months = new List<string> { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            var ans = months.Where(x => x.Count() == 5);
            Console.WriteLine("Месяцы с размером = 5 символам:");
            foreach (var a in ans)
            {
                Console.Write(a+"\t");
            }
            Console.WriteLine(" ");

            Console.WriteLine("Летние месяцы:");
            ans = months.SkipWhile(x => x != "June").TakeWhile(x => x != "September");
            foreach (var a in ans)
            {
                Console.Write(a + "\t");
            }
            Console.WriteLine(" ");
            Console.WriteLine("Зимние месяцы:");
            List<string> ans1 = new List<string>(months);
           ans1.RemoveRange(2,9);
            foreach (var a in ans1)
            {
                Console.Write(a + "\t");
            }
            Console.WriteLine(" ");

            Console.WriteLine("Сортировка по алфавиту:");
            ans=months.OrderBy(x => x);
            foreach (var a in ans)
            {
                Console.Write($"{a}\t");
            }
            Console.WriteLine(" ");

            Console.WriteLine("Содержащие букву u и не менее 4-х символов:");
            ans=months.Where(x => x.Contains('u')).Where(x => x.Count() >= 4);
            foreach (var a in ans)
            {
                Console.Write($"{a}\t");
            }
            Console.WriteLine(" ");
            Console.WriteLine(" ");

            Console.WriteLine("Задание 2:");
            List<Train> Trains = new List<Train>();
            Trains.Add(new Train(1,"Рига", 13, "22:00", 12, 25, 34, 15));
            Trains.Add(new Train(2,"Вильнюс", 3, "21:00", 15, 29, 45, 19));
            Trains.Add(new Train(3,"Рига", 16, "23:00", 12, 25, 34, 15));
            Trains.Add(new Train(4,"Рига", 13, "22:00", 12, 15, 43, 5));
            Trains.Add(new Train(5,"Белосток", 23, "12:00", 10, 29, 24, 15));
            Trains.Add(new Train(6,"Киев", 13, "22:00", 2, 5, 34, 17));
            Trains.Add(new Train(7,"Львов", 33, "10:00", 12, 5, 36, 15));
            Trains.Add(new Train(8,"Варшава", 11, "23:30", 12, 22, 4, 15));
            Trains.Add(new Train(9,"Кишинев", 13, "15:00", 12, 25, 34, 15));
            Trains.Add(new Train(10,"Бухарест", 17, "17:40", 10, 7, 38, 5));

            Console.WriteLine("Поезда в 22:00 :");
           var Tr = Trains.Where(x => x.Timeotp == "22:00");
            foreach (var a in Tr)
            {
                Console.WriteLine($"{a.id}\t");
            }
            Console.WriteLine(" ");

            Console.WriteLine("Поезда в 23:00 и в Ригу:");
             Tr = Trains.Where(x => x.Timeotp == "23:00" &&  x.Punktnaz=="Рига");
            foreach (var a in Tr)
            {
                Console.WriteLine($"{a.id}\t");
            }
            Console.WriteLine(" ");

            Console.WriteLine("Поезда по макс кол мест:");
            int z = 0;
            int r = Trains.Max(x=>x.Count_suit);
            Tr = Trains.Where(x => x.Count_suit == r);
            foreach (var a in Tr)
            {
                Console.WriteLine($"{a.id}\t");
            }
            Console.WriteLine(" ");

            Console.WriteLine("Последние 5 поездов по времени отправления:");
            Tr = Trains.SkipWhile(x => x.id!=6);
            foreach (var a in Tr)
            {
                Console.WriteLine($"{a.id}\t");
                Console.WriteLine($"{a.Timeotp}\t");
            }
            Console.WriteLine(" ");

            Console.WriteLine("Поезда в алфавитном порядке по пункту назначения:");
            Tr = Trains.OrderBy(x => x.Punktnaz);
            foreach (var a in Tr)
            {
                a.Info();
            }
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");

            Console.WriteLine("Сложный запрос");
            List<int> Numbers = new List<int> { 1, 2, 3, 6, 5, 6, 7, 50, 9, 10, 50, 100 };
            Console.WriteLine(Numbers.OrderByDescending(x => x).Skip(1).Reverse().Distinct().Aggregate((x, y) => x + y));
        }
    }
    public partial class Train
    {
        private string punktnaz;
        public int id;
        private int number;
        private string timeotp;
        private int kolkupe;
        private int kolobj;
        private int kolplaz;
        private int kolluks;
        public static int price;
        public const int pass = 55;
        private int exampleset;
        public int Exampleset
        {
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Как может быть отрицательным число?!!!!!");
                }
                else
                {
                    exampleset = value;
                }
            }
        }
        public int Count_suit;
        public string Punktnaz
        {
            get
            {
                return punktnaz;
            }
            set
            {
                punktnaz = String.IsNullOrEmpty(value) ? "Нет значения" : value;
            }
        }
        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Как может быть отрицательное номер поезда?!!!!!");
                }
                else
                {
                    number = value;
                }
            }
        }
        public string Timeotp
        {
            get
            {
                return timeotp;
            }
            set
            {
                timeotp = String.IsNullOrEmpty(value) ? "Нет значения" : value;
            }
        }
        public int Kolkupe
        {
            get
            {
                return kolkupe;
            }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Как может быть отрицательное число мест?!!!!!");
                }
                else
                {
                    kolkupe = value;
                }
            }
        }
        public int Kolobj
        {
            get
            {
                return kolobj;
            }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Как может быть отрицательное число мест?!!!!!");
                }
                else
                {
                    kolobj = value;
                }
            }
        }
        public int Kolplaz
        {
            get
            {
                return kolplaz;
            }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Как может быть отрицательное число мест?!!!!!");
                }
                else
                {
                    kolplaz = value;
                }
            }
        }
        public int Kolluks
        {
            get
            {
                return kolluks;
            }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Как может быть отрицательное число мест?!!!!!");
                }
                else
                {
                    kolluks = value;
                }
            }
        }
        public void mainvivod()
        {
            Console.WriteLine($"Общее количество мест в вагоне: {kolkupe + kolobj + kolplaz + kolluks} \n" +
                $"-------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ \n");
        }
        public Train(int ids,string punkt, int num, string timeo, int kolk, int kolo, int kolp, int koll)
        {
            id = ids;
            punktnaz = punkt;
            number = num;
            timeotp = timeo;
            kolkupe = kolk;
            kolobj = kolo;
            kolplaz = kolp;
            kolluks = koll;
            count++;
            Count_suit = kolkupe + kolobj + kolplaz + kolluks;
        }
        public Train()
        {
            punktnaz = "Минск";
            number = 1;
            timeotp = "13:00";
            kolkupe = 15;
            kolobj = 16;
            kolplaz = 20;
            kolluks = 13;
            count++;
        }
        public void Info()
        {
            Console.WriteLine($"Пункт назначения: {punktnaz} \n" +
                $"ID: {id} \n" +
                $"Номер поезда: {number} \n" +
                $"Время отправления: {timeotp} \n" +
                $"Количество мест купе: {kolkupe} \n" +
                $"Количество общих мест: {kolobj} \n" +
                $"Количество плацкартных мест: {kolplaz} \n" +
                $"Количество люксовых мест: {kolluks} \n" +
                $"-------------------------------------------------------------------------------------------------------");
        }
        static Train()
        {
            price = 45;
            object tr = new Train(1);
        }
        private Train(object k)
        {
            Console.WriteLine($"Вызван закрытый конструктор\n-----------------------");
        }
        static public int count = 0;
        static public void Count()
        {
            Console.WriteLine($"Количество объектов: {count}");
        }
    }
}
