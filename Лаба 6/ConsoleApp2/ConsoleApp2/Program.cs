using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
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
        public int[] sumshet;
        public string[] typeshet;
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
            Console.WriteLine($"1. Вычисление общей суммы по счетам заданного клиента\n"+
                              $"2. Вычисление суммы по всем счетам(положительным)\n"+
                              $"3. Вычисление суммы по всем счетам(отрицательным)\n");
            return Convert.ToInt32(Console.ReadLine());
        }
        public void Add(shet sh,int kol)
        {
            sh.kolshets = kol;
            for(var i=0;i<sh.kolshets;i++)
            {
                Console.Write($"Введите сумму {i+1} счета:");
                sh.sumshet[i] = Convert.ToInt32(Console.ReadLine());
                Console.Write($"Введите тип {i+1} счета:");
                sh.typeshet[i]= Console.ReadLine();
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
                        sum += ((shet)obj).sumshet[0];
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
                    if (((shet)obj).sumshet[0] > 0)
                        sum += ((shet)obj).sumshet[0];
                    else Console.WriteLine("Нет положительных счетов");
                    }
            }
        }
        public void Sumallneg(bank bk)
        {
            int sum = 0;
            foreach (object obj in bk.Elements)
            {
                    for (var i = 0; i < ((shet)obj).kolshets; i++)
                    {
                        if (((shet)obj).sumshet[0] > 0)
                            sum += ((shet)obj).sumshet[0];
                        else Console.WriteLine("Нет отрицательных счетов");
                    }
              
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
           
            sheta sheta = new sheta();
            bank bank1 = new bank();
            shet sh1 = new shet();
            bool Work = true;
            bank1.Add(sh1, 3);
            do
            {
                switch (bank1.menu())
                {
                    case 1: Console.WriteLine("Выберите клиента:"); int s = Convert.ToInt32(Console.ReadLine()); Controller.SumShetCl(bank1,10); break;
                    case 2: Controller.Sumallpos(bank1); break;
                    case 3: Controller.Sumallneg(bank1); break;
                    case 4: Work = false; break;
                    default: Console.WriteLine("Некорректно введенные данные!"); break;
                }
            } while (Work);
        }
    }
}
