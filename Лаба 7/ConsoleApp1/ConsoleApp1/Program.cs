using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace ConsoleApp1
{
    public class Person : Adres, Show
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
            surname = Console.ReadLine();
            Console.WriteLine("Введите Адрес");
            adres = Console.ReadLine();
        }
    }
    interface Show
    {
        void show();
        void input();
    }
    public class Adres
    {
        public string adres;
    }
    public class Client : Person
    {
        public override void show()
        {
            base.show();
            Console.WriteLine("Клиент:");
        }
        public override string ToString()
        {
            return "Клиент: " + name + " " + surname + " " + adres;
        }
    }

    public partial class oper_shet : Client
    {
        public override void input()
        {
            base.input();
            Console.WriteLine("Введите id счета");
            shett = Console.ReadLine();
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
            return base.ToString() + " ID Счета : " + shett + " Счет: ";
        }
    }
    sealed class val_shet : shet
    {
        public override void show()
        {
            base.show();
            Console.WriteLine("Валютный");
        }
        public override string ToString()
        {
            return base.ToString() + "Валютный";
        }
    }
    sealed class ras_shet : shet
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
    sealed class nak_shet : shet
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
    sealed class obs_shet : shet
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
    enum sheta
    {
        sheta,
        Clients,
        id
    }
    struct shets
    {
        int k;
    }
    sealed class card : Client
    {
        public string id;
        public override void input()
        {
            base.input();
            Console.WriteLine($"Введите id карты");
            id = Console.ReadLine();
        }
        public override void show()
        {
            Console.WriteLine("Владелец карты:");
            Console.WriteLine($"ID карты: {id}");
            base.show();
        }
        public override string ToString()
        {
            return base.ToString() + "ID карты: " + id;
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
    public class shet : oper_shet
    {
        public int kolshets;
        public int[] sumshet = new int[20];
        public string[] typeshet = new string[20];
        public bool[] tblock = new bool[20];
    }

    /// 
    public class bank
    {
        public List<object> Elements = new List<object>();
        public void Delete(int index)
        {
            Elements.Remove(index);
        }
        public void Print()
        {
            foreach (object obj in Elements)
                Console.WriteLine(obj);
        }
        public int menu()
        {
            Console.WriteLine(" ");
            Console.WriteLine($"Меню:\n" +
                               $"1. Вычисление общей суммы по счетам заданного клиента\n" +
                               $"2. Вычисление суммы по всем счетам(положительным)\n" +
                               $"3. Вычисление суммы по всем счетам(отрицательным)\n" +
                               $"4. Смена состояния счета\n" +
                               $"5. Закончить программу");
            return Convert.ToInt32(Console.ReadLine());
        }
        public void Add(shet sh, int kol)
        {
            sh.kolshets = kol;
            for (var i = 0; i < sh.kolshets; i++)
            {
                try
                {
                    Console.Write($"Введите сумму {i + 1} счета:");
                    sh.sumshet[i] = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    new ConsoleLogger("ERROR", e.Message);
                    new FileLogger("ERROR", e.Message);
                }
                Console.Write($"Введите тип {i + 1} счета:");
                    sh.typeshet[i] = Console.ReadLine();
                try
                {
                    Console.WriteLine($"Введите состояние счета(true-разблокированный,false-заблокированный):");
                    sh.tblock[i] = Convert.ToBoolean(Console.ReadLine());
                }
                catch(Exception e)
                {
                    new ConsoleLogger("ERROR", e.Message);
                    new FileLogger("ERROR", e.Message);
                }
            }
            Elements.Add(sh);
        }
    }
    public class Controller
    {
        public void SumShetCl(bank bk, int numcl)
        {
            int sum = 0;
            foreach (object obj in bk.Elements)
            {
                if (obj == bk.Elements[numcl])
                {
                    for (var i = 0; i < ((shet)obj).kolshets; i++)
                    {
                        sum += ((shet)obj).sumshet[i];
                    }
                }
            }
            Console.WriteLine($"Сумма счетов клиента {numcl + 1} : {sum}");
        }
        public void Sumallpos(bank bk)
        {
            int sum = 0;
            foreach (object obj in bk.Elements)
            {
                for (var i = 0; i < ((shet)obj).kolshets; i++)
                {
                    if (((shet)obj).sumshet[i] > 0)
                        sum += ((shet)obj).sumshet[i];

                }
            }
            Console.WriteLine($"Сумма всех положительных счетов в банке равна:{sum}");
            if (sum == 0)
            {
                Console.WriteLine("Нет положительных счетов");
            }

        }
        public void Sumallneg(bank bk)
        {
            int sum = 0;
            foreach (object obj in bk.Elements)
            {
                for (var i = 0; i < ((shet)obj).kolshets; i++)
                {
                    if (((shet)obj).sumshet[i] < 0)
                        sum += ((shet)obj).sumshet[i];
                }

            }
            Console.WriteLine($"Сумма всех отрицательных счетов в банке равна:{sum}");
            if (sum == 0)
            {
                Console.WriteLine("Нет отрицательных счетов");
            }
        }
        public void chanblock(bank bk, int numcl, int numsh)
        {
            bool k = false;
            foreach (object obj in bk.Elements)
            {
                if (obj == bk.Elements[numcl])
                {
                    for (var i = 0; i < ((shet)obj).kolshets; i++)
                    {
                        if (i == numsh)
                        {
                            k = true;
                            if (((shet)obj).tblock[i] == true)
                            {
                                ((shet)obj).tblock[i] = false;
                                Console.WriteLine($"Счет {i + 1} заблокирован");
                            }
                            else
                            {
                                ((shet)obj).tblock[i] = true;
                                Console.WriteLine($"Счет {i + 1} разблокирован");
                            }
                        }

                    }
                }
            }
            if (k == false) Console.WriteLine($"Нет такого счета у клиента {numcl + 1}");
        }
    }
    /// 
    class Logger
    {
        protected string Message { get; set; }
    }
    class FileLogger : Logger
    {
        public FileLogger(string type, string msg)
        {
            DateTime now = DateTime.Now;
            Message = now + " " + type + ": " + msg + '\n';
            File.AppendAllText("D:\\ООП\\Лаба 7\\Logger.txt", Message);
        }
    }
    class ConsoleLogger : Logger
    {
        public ConsoleLogger(string type, string msg)
        {
            Message = DateTime.Now + " " + type + ": " + msg;
            Console.WriteLine(Message);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int i = 4;
                int u = 2;
                int k = i / u;
                if (k > 0)
                    throw new Exception("Ошииииибка!!!");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
              
            }
            finally
            {
                Console.WriteLine("Блок финала");
              
            }
            Console.WriteLine("Если Вы введете 0, то программа экстренно завершится");
            Debug.Assert(Convert.ToByte(Console.ReadLine()) != 0,"НЮХАЙ БЕБРУ!!!");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            ///

            sheta sheta = new sheta();
            bank bank1 = new bank();
            bool Work = true;
            bank1.Add(new shet(), 3);
            Controller Controller = new Controller();
            do
            {
                switch (bank1.menu())
                {
                    case 1: Console.WriteLine("Выберите клиента:"); int s = Convert.ToInt32(Console.ReadLine()); Controller.SumShetCl(bank1, s); break;
                    case 2: Controller.Sumallpos(bank1); break;
                    case 3: Controller.Sumallneg(bank1); break;
                    case 4:
                        Console.WriteLine("Выберите клиента:"); int k = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Выберите счет клиента:"); int e = Convert.ToInt32(Console.ReadLine());
                        Controller.chanblock(bank1, k, e); break;
                    case 5: Work = false; break;
                    default: Console.WriteLine("Некорректно введенные данные!"); break;
                }
            } while (Work);
        }
    }
}
