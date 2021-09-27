using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public partial class Train
    {
        private string punktnaz;
        readonly Guid id;
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
                    Console.WriteLine("��� ����� ���� ������������� �����?!!!!!");
                }
                else
                {
                    exampleset = value;
                }
            }
        }
        public string Punktnaz
        {
            get
            {
                return punktnaz;
            }
            set
            {
                punktnaz = String.IsNullOrEmpty(value) ? "��� ��������" : value;
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
                    Console.WriteLine("��� ����� ���� ������������� ����� ������?!!!!!");
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
                timeotp = String.IsNullOrEmpty(value) ? "��� ��������" : value;
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
                    Console.WriteLine("��� ����� ���� ������������� ����� ����?!!!!!");
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
                    Console.WriteLine("��� ����� ���� ������������� ����� ����?!!!!!");
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
                    Console.WriteLine("��� ����� ���� ������������� ����� ����?!!!!!");
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
                    Console.WriteLine("��� ����� ���� ������������� ����� ����?!!!!!");
                }
                else
                {
                    kolluks = value;
                }
            }
        }
        public void mainvivod()
        {
            Console.WriteLine($"����� ���������� ���� � ������: {kolkupe + kolobj + kolplaz + kolluks} \n" +
                $"-------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ \n");
        }
        public Train(string punkt, int num, string timeo, int kolk, int kolo, int kolp, int koll)
        {
            punktnaz = punkt;
            number = num;
            timeotp = timeo;
            kolkupe = kolk;
            kolobj = kolo;
            kolplaz = kolp;
            kolluks = koll;
            count++;
        }
        public Train()
        {
            punktnaz = "�����";
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
            Console.WriteLine($"����� ����������: {punktnaz} \n" +
                $"ID: {id} \n" +
                $"����� ������: {number} \n" +
                $"����� �����������: {timeotp} \n" +
                $"���������� ���� ����: {kolkupe} \n" +
                $"���������� ����� ����: {kolobj} \n" +
                $"���������� ����������� ����: {kolplaz} \n" +
                $"���������� �������� ����: {kolluks} \n" +
                $"-------------------------------------------------------------------------------------------------------");
        }
        static Train()
        {
            price = 45;
            object tr = new Train(1);
        }
        private Train(object k)
        {
            Console.WriteLine($"������ �������� �����������\n-----------------------");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Train train1 = new Train();
            train1.Info();
            train1.mainvivod();
            Train train2 = new Train("����", 13, "22:00", 12, 25, 34, 15);
            train2.Info();
            train2.mainvivod();
            Train train3 = new Train();
            train3.Punktnaz = "��������";
            train3.Number = 23;
            train3.Timeotp = "18:30";
            train3.Kolkupe = 17;
            train3.Kolobj = 13;
            train3.Kolplaz = 20;
            train3.Kolluks = 15;
            train3.Exampleset = 22;
            train3.Info();
            Console.WriteLine($"���� ������: {Train.price}");
            // Console.WriteLine($"���� ������: {train3.Exampleset}");
            train3.mainvivod();

            Console.WriteLine("REF AND OUT");
            int x = 22;
            int y = 35;
            int z;
            reff_out(ref x, y, out z);
            Console.WriteLine($"ref-out � ������: { z}");
            Console.WriteLine("");
            Console.WriteLine("����������� ���� �� ���������� ��������");
            Train.Count();
            Console.WriteLine("");

            Console.WriteLine("������ � ���������");
            Console.WriteLine($"��� ������� train1: {train1.GetType().FullName}");
            Console.WriteLine($"��� ������� train2: {train2.GetType().Name}");
            if (train1.Equals(train2) == false)
            {
                Console.WriteLine("������ train1 �� ����� train2");
            }
            Console.WriteLine("");

            Console.WriteLine("���-����");
            Console.WriteLine($"������� train1: {train1.GetHashCode()}");
            Console.WriteLine($"������� train2: {train2.GetHashCode()}");
            Console.WriteLine("");

            Console.WriteLine("Tostring objects");
            Console.WriteLine($"������� train1: {train1.ToString()}");
            Console.WriteLine($"������� train2: {train2.ToString()}");
            Console.WriteLine("");

            var train4 = new { Punktnaz = "�����", Number = 37, Timeotp = "23:00", Kolkupe = 20, Kolobj = 10, Kolplaz = 22, Kolluks = 20 };
            Console.WriteLine(train4);
            Console.WriteLine("");

            Console.WriteLine("������ ��������");
            Console.WriteLine("");
            Train[] massobj = new Train[5];
            massobj[0] = train1;
            massobj[1] = train2;
            massobj[2] = train3;
            massobj[3] = new Train { Punktnaz = "����", Number = 23, Timeotp = "22:00", Kolkupe = 20, Kolobj = 10, Kolplaz = 22, Kolluks = 20 };
            massobj[4] = new Train { Punktnaz = "����", Number = 23, Timeotp = "00:00", Kolkupe = 20, Kolobj = 10, Kolplaz = 22, Kolluks = 20 };
            for (int i = 0; i < 5; i++)
            {
                if (massobj[i].Punktnaz == "����")
                {
                    Console.WriteLine(" ������ � ������� ����������:  ����");
                    massobj[i].Info();
                }

            }
            Console.WriteLine("\n");
            for (int i = 0; i < 5; i++)
            {
                if (massobj[i].Punktnaz == "����" & massobj[i].Timeotp == "22:00")
                {
                    Console.WriteLine(" ������ � ������� ����������:  ���� � �������� �����������: 22:00");
                    massobj[i].Info();
                }
            }
        }
        static void reff_out(ref int x, int y, out int z)
        {
            z = x - y;
        }
    }
}