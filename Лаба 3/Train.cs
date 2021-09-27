using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
   public partial class Train
    {
        static public int count = 0;
        static public void Count()
        {
            Console.WriteLine($"Количество объектов: {count}");
        }
    }
}
