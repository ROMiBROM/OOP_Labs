
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab8
{
    interface IGeneric<T>
    {
        public void add(T index);
        public void del(T index);
        public void show(CollectionType<T> k, T index);
    }
    public class Owner
    {
        public string name;
        public string organization;
        public uint id;
    }
    public class CollectionType<T> : List<T>, IGeneric<int>
    {
        private Owner owner = new Owner { name = "Роман", organization = "BSTU", id = 1 };
        private Date date = new Date { date = (DateTime.Now).ToString() };
        public void SaveAsFile(CollectionType<T> a)
        {
            string TEXT = $"Владелец: { owner.name}\nID владельца: { owner.id}\nОрганизация: { owner.organization}\nМножество: ";
            foreach (T i in a)
                TEXT += i + " ";
            TEXT += "\n";
            File.AppendAllText("D:\\ООП\\Лаба 8\\laba8.json", TEXT);
        }
            public void add(int index)
        {
            return;
        }
        public void del(int index)
        {
            return;
        }
        public void show(CollectionType<int> a, int index)
        {
            try
            {
                for (int i = 0; i < a.Count; i++)
                {
                    if (i == index - 1)
                    {
                        Console.WriteLine($"{i + 1} элемент:{a[i]}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Показываю");
            }
        }
        public static CollectionType<T> operator +(CollectionType<T> a, T b)
        {
            a.Add(b);
            return a;
        }
        public static CollectionType<T> operator --(CollectionType<T> a)
        {
            a.RemoveAt(a.Count() - 1);
            return a;
        }
        public static bool operator !=(CollectionType<T> a, CollectionType<T> b)
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
        public static bool operator ==(CollectionType<T> a, CollectionType<T> b)
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
        public static bool operator true(CollectionType<T> a)
        {
            if (a == a.OrderBy(x => x))
                return true;
            else return false;
        }
        public static bool operator false(CollectionType<T> a)
        {
            return false;
        }
        class Date
        {
            public string date;
        }

    }
    public class Person
    {
        public string name;
        public string surname;
    }
        class Personcol<T> where T:Person
    {
        public void inputname(T per)
        {
            per.name = Console.ReadLine();
        }
        public void inputsurname(T per)
        {
            per.surname = Console.ReadLine();
        }
        public void proverka(T per)
        {
            if(per is T)
            {
                Console.WriteLine("Все ок");
            }
            else
            {
                Console.WriteLine("Не все ок");
            }
        }
    }
    public static class StaticOperation
    {
  
        public static int Diff(this CollectionType<int> a)
        {
            var diff = 0;
            diff = a.Max() - a.Min();
            return diff;
        }
        public static int COunt(this CollectionType<int> a)
        {
            return a.Count;
        }
        public static int Words(this string a)
        {
            int u = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == ' ')
                {
                    u++;
                }
                if (i == a.Length - 1)
                {
                    if (a[a.Length - 1] != ' ')
                    {
                        u++;
                    }

                }
            }
            return u;
        }
        public static void NULLof(this CollectionType<int> a)
        {
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] == null)
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

            CollectionType<string> list1 = new CollectionType<string>{ "ds", "ds", "rewa", "ea"};
            CollectionType<int> list4 = new CollectionType<int> { 4, 6, 7 };
            CollectionType<int> list2 = new CollectionType<int>{ 4, 6, 7 };
            list2 = list2 + 9;
            list1 = list1--;
            foreach (var item in list2)
            {
                Console.Write($"{item}\t");
            }
            Console.WriteLine("");
            foreach (var item in list1)
            {
                Console.Write($"{item}\t");
            }
            Console.WriteLine("");
            bool res = list4 != list2;
            Console.WriteLine(res);
            Console.WriteLine("");

            list2.Diff();
            list2.COunt();

            CollectionType<int> list3 = new CollectionType<int>();
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
            list1.SaveAsFile(list1);
            list3.show(list3, 3);
            Console.WriteLine(" ");
            Console.WriteLine(" ");

            Person re = new Person();
            Personcol<Person> per = new Personcol<Person>();
            per.proverka(re);
        }
    }
}
