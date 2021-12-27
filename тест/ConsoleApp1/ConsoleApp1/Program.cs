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
            SuperHashSet<Geofigure> shashSet = new SuperHashSet<Geofigure>();
            Geofigure G1 = new Geofigure("Triangle");
            Geofigure G2 = new Geofigure("Oval");
            Geofigure G3 = new Geofigure("Circle");
            shashSet.Add(G1);
            shashSet.Add(G2);
            shashSet.Add(G3);
            shashSet.vivod();
            Console.WriteLine(shashSet.Count());
            Button b1 = new Button("Кнопка 1");
            Button b2 = new Button("Кнопка 2");
            User user = new User("Romango");
            user.Click += b1.Onсlick;
            user.Click += b2.Onсlick;
            user.GeneralClick();
        }
        class SuperHashSet<T>where T: Geofigure
        {
            private HashSet<T> hs=new HashSet<T>();
            public void Add(T g1)
            {
                hs.Add(g1);
            }
            public void Remove(T g1)
            {
                hs.Remove(g1);
            }
            public void vivod()
            {
                Console.WriteLine("Вывод объектов:");
                foreach(var g in hs)
                {
                    Console.WriteLine(g);
                }
            }
            public int Count()
            {
                var kol = hs.Count();
                return kol;
            }
        }
        class Button
        {
            private string NameOfButton;
            public Button(string nameOfButton)
            {
                NameOfButton = nameOfButton;
            }
            public void Onсlick(object sender, EventArgs e)
            {
                Console.WriteLine($"Нажали.........кнопка: {NameOfButton}");
            }
        }
        class User
        {
            public event EventHandler Click;
            private string Name;
            public User(string name)
            {
                Name = name;
            }
            public void GeneralClick()
            {
                Console.WriteLine($"{Name} нажал на кнопку");
                Click.Invoke(this, null);
            }

        }
        public class Geofigure
        {
            public string Name { get; set; }
            public Geofigure(string name)
            {
                Name = name;
            }
            public interface IEnumerator
            {
                IEnumerator GetEnumerator();
            }
            public void Print(Stack<Geofigure> ST)
            {
                Console.WriteLine("Вывод Стека:");
                foreach (var i in ST)
                {
                    Console.WriteLine(i.Name);
                }
            }
            public void Search(Stack<Geofigure> ST, string g)
            {
                Console.WriteLine("Поиск:");
                foreach (var i in ST)
                {
                    if (i.Name == g)
                    {
                        Console.WriteLine(i.Name);
                    }
                }
            }
        }
    }
}
