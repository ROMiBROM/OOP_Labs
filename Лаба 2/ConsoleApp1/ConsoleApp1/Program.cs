using System;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            static (int max, int min, int sum, char) fun1(int[] arr,string str)
            {
                int min=100;
                int max=0;
                int sum=0;
                for(int u=0;u<arr.Length;u++)
                {
                    if(arr[u]>max)
                    {
                        max = arr[u];
                    }
                    if(arr[u]<min)
                    {
                        min = arr[u];
                    }
                    sum += arr[u];
                }
                var tuple = (max, min,sum,str[0]);
                return tuple;
            }
            static int fun2()
            {
                checked
                {
                    int a = int.MaxValue;
                    a++;
                    return a;
                }
                
            }
            static int fun3()
            {
                unchecked
                {
                    int b = int.MaxValue;
                    b++;
                    return b;
                }

            }
            Console.Write("Первое задание:");
            int a = -5;
            bool e = true;
            byte b = 127;
            Int16 d = 3267;
            Console.Write("long = ");
            long g = Convert.ToInt64(Console.ReadLine());
            float r = 56;
            double y = 89;
            char w = 'r';
            Console.WriteLine(a + "|" + e + "|" + b + "|" + d + "|" + g + "|" + r + "|" + y + "|" + w);
            Console.WriteLine("");

            byte m = 6;
            short x = m;
            int f = x;
            long c = f;
            float n = c;
            double v = n;
            Console.WriteLine(v);
            byte j = 9;
            short da = (short)j;
            int fw = Convert.ToInt32(da);
            long cq = (long)fw;
            float vz = Convert.ToSingle(c);
            double xc = (double)vz;
            Console.WriteLine(xc);
            Console.WriteLine("");

            int h = 5;
            object p = h;
            int fg = (int)p;
            float nm = 9;
            object l = nm;
            float i = (float)l;

            var s = 55;
            //s = 4.2; ошибка!!!
            Console.WriteLine(s);
            Console.WriteLine("");

            int? gl = null;
            Nullable<bool> fp = null;
            Console.WriteLine(" задание с NULL : " + gl + " " + fp);
            Console.WriteLine(" ");
            Console.WriteLine(" ");




            Console.WriteLine("Второе задание:");
            Console.WriteLine("a:");
            string s1 = "hi";
            string s2 = "beloded";
            int result = String.Compare(s1, s2);
            Console.WriteLine(result);
            Console.WriteLine(" ");

            Console.WriteLine("b:");
            string s3 = "debred";
            string s4 = "savfed";
            string s5 = "vebinar";
            string s6 = String.Concat(s3, " ", s4, " ", s5, "!!!");
            Console.WriteLine(s6);
            string s7 = String.Copy(s6);
            Console.WriteLine(s7);
            string s8 = s5.Substring(2, 5);
            Console.WriteLine(s8);
            Console.WriteLine(" ");
            string[] vec = s6.Split();
            foreach (string words in vec)
            {
                Console.WriteLine(words);
            }
            Console.WriteLine(" ");
            string s9 = s6.Insert(4, " er");
            Console.WriteLine(s9);
            Console.WriteLine(" ");
            string sub = "debr";
            int subn = s9.IndexOf(sub);
            s9 = s9.Remove(subn, sub.Length);
            Console.WriteLine(s9);
            string output = String.Format("Этот {0} просто {1}", s1, s2);
            Console.WriteLine(output);
            Console.WriteLine(" ");

            Console.WriteLine("c:");
            string str1 = "";
            string str2 = null;
            Console.WriteLine(String.IsNullOrEmpty(str1));
            Console.WriteLine(String.IsNullOrEmpty(str2));
            Console.WriteLine(String.IsNullOrWhiteSpace(str1));
            Console.WriteLine(String.IsNullOrWhiteSpace(str2));
            Console.WriteLine(" ");

            Console.WriteLine("d:");
            StringBuilder sb = new StringBuilder("мирf dfv");
            Console.WriteLine(sb.Remove(3, 1));
            sb.Insert(0, "!");
            sb.AppendFormat("!");
            Console.WriteLine(sb);
            Console.WriteLine(" ");
            Console.WriteLine(" ");




            Console.WriteLine("Третье задание:");
            Console.WriteLine("a:");
            int[,] masstwo = { { 1, 5, 7 }, { 6, 9, 3 }, { 3, 6, 1 } };
            int rows = masstwo.GetUpperBound(0) + 1;
            int columns = masstwo.Length / rows;
            for (int u = 0; u < rows; u++)
            {
                for (int se = 0; se < columns; se++)
                {
                    Console.Write($"{masstwo[u, se]}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine(" ");

            Console.WriteLine("b:");
            int[] mass = { 1, 5, 7, 6, 9, 3, 3, 6, 1 };
            for (int u = 0; u < mass.Length; u++)
            {
                Console.Write(mass[u] + " ");
            }
            Console.WriteLine(" ");
            Console.WriteLine("Длина массива: " + mass.Length);
            mass[4] = 22;
            Console.WriteLine(" ");

            Console.WriteLine("c:");
            int[][] array = new int[3][];
            array[0] = new int[2];
            array[1] = new int[3];
            array[2] = new int[4];
            for (int za = 0; za < array.Length; za++)
            {
                for (int ze = 0; ze<array[za].Length; ze++)
                {
                    array[za][ze]=Console.Read();
                }
            }
            for (int za = 0; za < array.Length; za++)
            {
                for (int ze = 0; ze<array[za].Length; ze++)
                {
                    Console.Write(array[za][ze]+"\t");
                }
                Console.WriteLine(" ");
            }
            Console.WriteLine(" ");

            Console.WriteLine("d:");
            var arr = new[] { 3,45,67};
            var strr = "";
            Console.WriteLine(" ");
            Console.WriteLine(" ");




            Console.WriteLine("Четвертое задание:");
            Console.WriteLine("a:");
            (int,string,char,string,ulong)tuple = (2, "4reds", '@', "sdw", 34567856);
            Console.WriteLine("b:");
            Console.WriteLine(tuple);
            Console.WriteLine(tuple.Item3);
            Console.WriteLine(" ");
            Console.WriteLine("c:");
            int i1;
            string treq;
            char fgq;
            string we;
            ulong erq;
            (i1, treq, fgq, we,erq) = tuple;
            Console.WriteLine(i1);
            Console.WriteLine(" ");
            Console.WriteLine("d:");
            (int, string, char, string, ulong)tuple2 = (34, "wads", '2', "saS", 23);
            bool ty=false;
            if (tuple == tuple2)
            {
                ty = true;
            }
            Console.WriteLine(ty);
            Console.WriteLine(" ");
            Console.WriteLine(" ");




            Console.WriteLine("пятое задание:");
            int[]arrrr = new int[] { 9, 4, 6, 7 };
            string sstrr = "weare";
            Console.WriteLine(fun1(arrrr,sstrr));
            Console.WriteLine(" ");
            Console.WriteLine(" ");




            Console.WriteLine("шестое задание:");
            Console.WriteLine(fun3());
            Console.WriteLine(fun2());
        }
    }
}
/*
 using ConsoleApp2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1 Вариант
            //1
            //a)Вывести максимально допустимое число char
            Console.WriteLine("1 А):");
            Console.WriteLine((int)char.MaxValue);//перевел макс размер в int
            Console.WriteLine(" ");//просто отступ
            //б)Ввести строку,содержащую число, конвертировать в целое число
            Console.WriteLine("1 Б):");
            Console.WriteLine("Введите число в строку:");
            string str;
            str = Console.ReadLine();//вводим строку в консоли
            var result = Int32.Parse(str);//перевод из string в int
            Console.WriteLine(result);
            Console.WriteLine(" ");

            //2 Создать класс Time с автоматич. свойствами для часов , минут и секунд .
            Time t1 = new Time(23, 59, 59);
            t1.Print(t1);
            Time t2 = new Time(0, 59, 59);
            t2.Print(t2);
            t2.Poslanie = t2.ToString();
            Console.WriteLine(t2 > t1);
            Console.WriteLine(t2.Poslanie);
            //3 

        }

    }
    //2
    public class Time
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public string Poslanie { get; set; }
        public Time(int hours, int minutes, int seconds)
        {
            if (hours <= 23 && minutes <= 59 && seconds <= 59)
            {
                if (hours >= 0 && minutes >= 0 && seconds >= 0)
                {
                    Hours = hours;
                    Minutes = minutes;
                    Seconds = seconds;
                }
                else
                {
                    Console.WriteLine("Ошибка записи");
                }
            }

        }
        public Time()
        {

        }
        public void Print(Time t1)
        {
            if (t1.Hours >= 12 && t1.Hours < 24)
                Console.WriteLine($"Время : {t1.Hours}:{t1.Minutes}:{t1.Seconds} {time.PM}");
            else
                Console.WriteLine($"Время : {t1.Hours}:{t1.Minutes}:{t1.Seconds} {time.AM}");
        }
        public static bool operator <(Time t1, Time t2)
        {
            if (t2.Hours < t1.Hours && t2.Minutes < t1.Minutes && t2.Seconds < t1.Seconds)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator >(Time t1, Time t2)
        {
            if (t2.Hours > t1.Hours && t2.Minutes > t1.Minutes && t2.Seconds > t1.Seconds)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override string ToString()
        {
            return "Время-самый ценный ресурс";
        }
    }
    enum time
    {
        PM,
        AM
    }
    //3
    public class FullTime : Time, ICheck
    {


        void ICheck.Check()
        {
            throw new NotImplementedException();
        }
    }
    interface ICheck
    {
        void Check();
    }
}
*/   

