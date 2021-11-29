using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<Geofigure> ST1 = new Stack<Geofigure>();
            Geofigure G1 = new Geofigure("Triangle");
            Geofigure G2 = new Geofigure("Oval");
            Geofigure G3 = new Geofigure("Circle");
            ST1.Push(G1);
            ST1.Push(G2);
            ST1.Push(G3);
            G1.Print(ST1);
            ST1.Pop();
            Console.WriteLine(" ");
            G1.Search(ST1, "Oval");
            Console.WriteLine(" ");

            ArrayList obj = new ArrayList() { 1, 2, "oop", 'f', 2.0f };
            obj.Add("c#");
            obj.RemoveAt(0);
            Console.WriteLine("Универсальная коллекция:");
            foreach (var o in obj)
            {
                Console.WriteLine(o);
            }
            Console.WriteLine("Общее число элементов коллекции: {0}", obj.Count);
            Console.WriteLine("Универсальная коллекция 2:");
            Stack obj2 = new Stack();
            obj2.Push(2);
            obj2.Push("oop");
            obj2.Push('f');
            foreach (var o in obj2)
            {
                if (o == G1.Name)
                {
                    Console.WriteLine(o);
                }
            }
            foreach (var o in obj2)
            {
                Console.WriteLine(o);
            }
            Console.WriteLine(" ");

            ObservableCollection<User> users = new ObservableCollection<User>
            {
                new User { Name = "Bill"},
                new User { Name = "Tom"},
                new User { Name = "Alice"}
            };
            Console.WriteLine("Наблюданмая коллекция");
            users.CollectionChanged += Users_CollectionChanged;
            users.Add(new User { Name = "Bob" });
            users.RemoveAt(1);
            users[0] = new User { Name = "Anders" };

            foreach (User user in users)
            {
                Console.WriteLine(user.Name);
            }
        }

        private static void Users_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add: // если добавление
                    User newUser = e.NewItems[0] as User;
                    Console.WriteLine($"Добавлен новый объект: {newUser.Name}");
                    break;
                case NotifyCollectionChangedAction.Remove: // если удаление
                    User oldUser = e.OldItems[0] as User;
                    Console.WriteLine($"Удален объект: {oldUser.Name}");
                    break;
                case NotifyCollectionChangedAction.Replace: // если замена
                    User replacedUser = e.OldItems[0] as User;
                    User replacingUser = e.NewItems[0] as User;
                    Console.WriteLine($"Объект {replacedUser.Name} заменен объектом {replacingUser.Name}");
                    break;
            }
        }

    }

   

}
class User
{
    public string Name { get; set; }
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
            foreach(var i in ST)
            {
                Console.WriteLine(i.Name);
            }
        }
        public void Search(Stack<Geofigure> ST,string g)
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
