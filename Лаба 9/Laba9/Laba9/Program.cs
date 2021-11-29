using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba9
{
    class Program
    {
        static void Main(string[] args)
        {

            User.PO[] po = new User.PO[2];
            po[0] = new User.PO();
            po[1] = new User.PO();
            po[0].Upgrade += (PO) => Console.WriteLine($"Для {PO} произошел Upgrade");
            po[0].Work += (PO) => Console.WriteLine($"Для {PO} произвелась Работа");
            int k = 1;
            foreach (User.PO i in po)
            {
                Console.WriteLine($"ПО {k}:");
                i.upgrade(i);
                i.work(i);
                k++;
                Console.WriteLine();
            }
            ////////////////////////////////
            string String="ASSA,sdsa";
            StringDeformate str = new StringDeformate();

            Func<string, string> DELEGATE = str1 =>str1.ToLower();// В нижний регистр
            String = DELEGATE(String);
            Console.WriteLine(String);

            
            DELEGATE += str1 => str1.ToUpper();//Верхний регистр
            String = DELEGATE(String);
            Console.WriteLine(String);
            
            DELEGATE += str.RemovePunctuationMarks;// убрать пунктуацию
            String = DELEGATE(String);
            Console.WriteLine(String);
            
            DELEGATE += str.SpaceDelete;//Убрать лишний проблеы
            String = DELEGATE(String);
            Console.WriteLine(String);
            
            Func<string, char, string> NOTPARAMS = (str1, ch) => str1 += ch;
            String = NOTPARAMS(String, 'V');//Добавление символа
            Console.WriteLine(String);
        }
    }
    public class User
    {

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
    class StringDeformate
    {
        public string RemovePunctuationMarks(string str)
        {
            string PunctuatinMarks = ",.;:-!";
            for (int i = 0; i < str.Length; i++)
            {
                foreach (char PunctuationMark in PunctuatinMarks)
                    if (str[i] == PunctuationMark)
                        str = str.Remove(i, 1);
            }
            return str;
        }
        public string SpaceDelete(string str)
        {
            for (int i = 0; i < str.Length; i++)
                if (str[i] == ' ' && str[i + 1] == ' ')
                    str = str.Remove(i + 1, 1);
            return str;
        }

    }
}
