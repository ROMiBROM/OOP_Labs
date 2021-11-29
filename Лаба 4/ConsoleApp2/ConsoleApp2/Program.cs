using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Owner
    {
        public string name;
        public string organization;
        public uint id;
    }
    public class MYList<T> : List<T>
    {
        private Owner owner = new Owner { name = "Роман", organization = "BSTU", id = 1 };
        private Date date = new Date { date = (DateTime.Now).ToString() };
       
        public static MYList<T> operator +(MYList<T> a, T b)
        {
            MYList<T> result = new MYList<T>();
            result = a;
            result.Add(b);
            return result;
        }
        public static MYList<T> operator --(MYList<T> a)
        {
            MYList<T> result = new MYList<T>();
            result = a;
            result.RemoveAt(result.Count() - 1);
            return result;
        }
        public static bool operator !=(MYList<T> a, MYList<T> b)
        {
            if (a.Equals(b))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool operator ==(MYList<T> a, MYList<T> b)
        {
            if (a.Equals(b))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator true(MYList<T> a)
        {
            if (a == a.OrderBy(x => x))
                return true;
            else return false;
        }
        public static bool operator false(MYList<T> a)
        {
            return false;
        }
        class Date
        {
            public string date;
        }

    }
    public static class StaticOperation
    {
        public static int SUm(this MYList<int> a)
        {
            var sum = 0;
            for (int i = 0; i < a.Count; i++)
            {
                sum += a[i];
            }
            return sum;
        }
        public static int Diff(this MYList<int> a)
        {
            var diff = 0;
            diff = a.Max() - a.Min();
            return diff;
        }
        public static int COunt(this MYList<int> a)
        {
            return a.Count;
        }
        public static int Words(this string a)
        {
            int u = 0;
            for(int i=0;i<a.Length;i++)
            {
                if (a[i]==' ')
                {
                    u++;
                }
                if(i==a.Length-1)
                {
                    if(a[a.Length - 1]!=' ')
                    {
                        u++;
                    }
                   
                }
            }
            return u;
        }
        public static void NULLof(this MYList<int> a)
        {
            for (int i = 0; i < a.Count; i++)
            {
                if(a[i]==null)
                {
                    Console.WriteLine("Ошибка:пустое значение");
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            MYList<int> list1 = new MYList<int>() { 1, 2, 3, 45 };
            MYList<int> list2 = new MYList<int>() { 1, 4, 3, 6 };

            list2 =list2 + 9;
            list1 = list1--;
            foreach(var item in list2)
            {
                Console.Write($"{item}\t");
            }
            Console.WriteLine("");
            foreach (var item in list1)
            {
                Console.Write($"{item}\t");
            }
            Console.WriteLine("");
            bool res = list1 != list2;
            Console.WriteLine(res);
            Console.WriteLine("");

            list1.SUm();
            list2.Diff();
            list2.COunt();

            MYList<int> list3 = new MYList<int>();
            list3.Add(3);
            list3.Add(5);
            list3.Add(6);
            list3.Insert(3, 9);
            string F = "DEL SEL PEL";
            Console.WriteLine($"Количество слов:{ F.Words() }");
            list3.NULLof();

            Console.WriteLine(" ");
            Console.WriteLine(" ");
            foreach (var item in list1)
            {
                Console.Write($"{item}\t");
            }
            Console.WriteLine(" ");
            if (list2)
            {
                Console.WriteLine("Упорядочен");
            }
            else
            {
                Console.WriteLine("Не упорядочен");
            }
        }
    }
}
