using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    abstract class Person:Adres,Show
    {
        public string name;
        public string surname;
        public virtual void show()
        {
            Console.WriteLine("Персона");
        }
        public override string ToString()
        {
            return "Персона:";
        }
        public virtual void input()
        {
            Console.WriteLine("Введите имя");
            name = Console.ReadLine();
            Console.WriteLine("Введите Фамилию");
            surname= Console.ReadLine();
            Console.WriteLine("Введите Адрес");
            adres = Console.ReadLine();
        }
    }
    interface Show
    {
        void show();
        void input();
    }
    abstract class Adres
    {
        public string adres;
    }
    abstract class Client : Person
    {
        public override void  show()
        {
            base.show();
            Console.WriteLine("Клиент:");
        }
        public override string ToString()
        {
            return "Клиент: " + name + " "+ surname+" " +adres  ;
        }
    }
    abstract class shet:oper_shet
    {
        
    }
    abstract class oper_shet:Client
    {
        public string shett;
        public override void input()
        {
            base.input();
            Console.WriteLine("Введите id счета");
            shett=Console.ReadLine();
        }
        public override void show()
        {
            Console.Write("ID Счета : ");
            Console.WriteLine(shett);
            base.show();
            Console.WriteLine("Счет: ");
        }
        public override string ToString()
        {
            return base.ToString()+ " ID Счета : "+shett+" Счет: ";
        }
    }
    sealed class val_shet:shet
    {
        public override void show()
        {
            base.show();
            Console.WriteLine("Валютный");
        }
        public override string ToString()
        {
            return base.ToString()+"Валютный";
        }
    }
    sealed class ras_shet:shet
    {
        public override void show()
        {
            base.show();
            Console.WriteLine("Рассчетный");
        }
        public override string ToString()
        {
            return base.ToString() + "Рассчетный";
        }
    }
    sealed class nak_shet:shet
    {
        public override void show()
        {
            base.show();
            Console.WriteLine("Накопительный");
        }
        public override string ToString()
        {
            return base.ToString() + "Накопительный";
        }
    }
    sealed class obs_shet:shet
    {
        public override void show()
        {
            base.show();
            Console.WriteLine("Общий");
        }
        public override string ToString()
        {
            return base.ToString() + "Общий";
        }
    }
    sealed class card:Client
    {
        public string id;
        public override void input()
        {
            base.input();
            Console.WriteLine($"Введите id карты");
            id=Console.ReadLine();
        }
        public override void show()
        {
            Console.WriteLine("Владелец карты:");
            Console.WriteLine($"ID карты: {id}");
            base.show();
        }
        public override string ToString()
        {
            return base.ToString()+ "ID карты: "+id;
        }
    }
    class Printer
    {
        public virtual void IAmPrinting(object someObj)
        {
            Console.Write(someObj.GetType());
        }
    }
    /// <summary>
    interface interder
    {
        void sam();
    }
    abstract class der
    {
        public abstract void sam();
    }
    class cl1 : der, interder
    {
        private int num;
        public override void sam()
        {
            num = Convert.ToInt32(Console.ReadLine());
        }
    }

    class cl2 : der, interder
    {
        private bool isPressed { get; set; } = false;
        public override void sam()
        {
            isPressed = Convert.ToBoolean(Console.ReadLine());
        }
    }

    class cl3 : der, interder
    {
        private int count { get; set; } = 0;
        public override void sam()
        {
            Console.WriteLine("Кликните на кнопку");
            Console.ReadKey();
            count++;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            obs_shet sh1 = new obs_shet();
            sh1.input();
            Console.WriteLine(sh1.ToString());
            Printer k = new Printer();
            k.IAmPrinting(sh1);
            Console.WriteLine(" ");
            Console.WriteLine(" ");

            List<der> cl = new List<der>();
            cl.Add(new cl1());
            cl.Add(new cl2());
            cl.Add(new cl3());
            Printer printer = new Printer();
            foreach (der item  in cl)
            {
                printer.IAmPrinting(item);
                if (item is cl1)
                    Console.WriteLine($"  cl1");
                else if (item is cl2)
                    Console.WriteLine($"  cl2");
                else if (item is cl3)
                    Console.WriteLine($"  cl3");
                else
                    Console.WriteLine("  nothing");
            }
        }
    }
}
