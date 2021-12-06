using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    class Program
    {
        static void Main(string[] args)
        {
            var train = Reflector.Create<Train>(null);
            Console.WriteLine(train);
            Reflector.AssemblyName(train);
            Reflector.FieldsAndPropertiesInfo(train);
            Reflector.Interfaces(train);
            Reflector.MethodsByParameterType(train, typeof(bool));
            Reflector.PublicContructors(train);
            Reflector.PublicMethods(train);

            var po = Reflector.Create<PO>(null);
            Console.WriteLine(po);
            Reflector.AssemblyName(po);
            Reflector.FieldsAndPropertiesInfo(po);
            Reflector.Interfaces(po);
            Reflector.MethodsByParameterType(po, typeof(int));
            Reflector.PublicContructors(po);
            Reflector.PublicMethods(po);

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
        public Train(int ids, string punkt, int num, string timeo, int kolk, int kolo, int kolp, int koll)
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

    public class PO
    {
        public delegate void Operation(PO po);
        public event Operation Upgrade;
        public event Operation Work;
        public void upgrade(PO po)
        {
            if (Upgrade != null)
            {
                Console.WriteLine("!!!Произошел Upgrade!!!");
                Upgrade(po);
            }
            else
            {
                Console.WriteLine("Upgrade невозможен");
            }

        }
        public void work(PO po)
        {
            if (Work != null)
            {
                Console.WriteLine("!!!Выполняется работа!!!");
                Work(po);
            }
            else
            {
                Console.WriteLine("Работа не выполнена");
            }
        }

    }
}
