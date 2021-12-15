using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Linq;
using System.Xml;
using System.Buffers;
using System.Runtime.Serialization;

namespace Lab14
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            persons.Add(new Person("Джек", "Red"));
            persons.Add(new Person("Роман", "Purple"));
            persons.Add(new Person("Парф", "Pink"));
            CustomSerializer.XMLSerializer(persons);
            CustomSerializer.BinSerializer(persons);
            CustomSerializer.JSONSerializerAsync(persons);
            //CustomSerializer.SOAPSerializer(persons);
            List<Person> Returned = CustomDeserializer.XMLDeserializer();

            foreach (var per in Returned)
            {
                Console.Write(per);
                Console.WriteLine(per.name);
                Console.WriteLine("----------------------");
            }

            XmlDocument xDoc = new XmlDocument();
             xDoc.Load("Person.xml");
            XDocument XD= XDocument.Load("Person.xml");
                Console.WriteLine(XD);
            XmlElement xRoot = xDoc.DocumentElement;

            var element = xRoot.SelectSingleNode("Person[name='Джек']");
            if (element != null)
                Console.WriteLine("\n" + element.OuterXml);

            element = xRoot.SelectSingleNode("Person[name='Парф']");
            if (element != null)
                Console.WriteLine(element.OuterXml + "\n");

            // Linq to XML
            XDocument xDocument = new XDocument();
            XElement Illustrator = new XElement("program");
            Illustrator.Add(new XAttribute("name", "Illustrator"));
            Illustrator.Add(new XElement("price", "1622 RUB"));
            Illustrator.Add(new XElement("period", "12 months"));

            XElement InCopy = new XElement("program");
            InCopy.Add(new XAttribute("name", "InCopy"));
            InCopy.Add(new XElement("price", "386 RUB"));
            InCopy.Add(new XElement("period", "12 months"));

            XElement Photoshop = new XElement("program");
            Photoshop.Add(new XAttribute("name", "Photoshop"));
            Photoshop.Add(new XElement("price", "800 RUB"));
            Photoshop.Add(new XElement("period", "6 months"));

            XElement Programs = new XElement("Programs");

            Programs.Add(Illustrator);
            Programs.Add(InCopy);
            Programs.Add(Photoshop);

            xDocument.Add(Programs);
            xDocument.Save("AdobePrograms.xml");

            XDocument xDocRoot = XDocument.Load("AdobePrograms.xml");
            var items = from xe in xDocRoot.Element("Programs").Elements("program")
                        where xe.Attribute("name").Value == "InCopy" || xe.Element("period").Value == "6 months"
                        select new AdobeProgram
                        {
                            Name = xe.Attribute("name").Value,
                            Price = xe.Element("price").Value,
                            Period = xe.Element("period").Value
                        };
            foreach (var item in items)
            {
                Console.WriteLine($"Name: {item.Name}\nPrice: {item.Price}\nPeriod: {item.Period}");
                Console.WriteLine("----------------------");
            }
        }
        [Serializable]
        public class Person
        {
            public string name;
            [NonSerialized]
            [XmlIgnore]
            public string surname;
            public Person(string Name, string Surname)
            {
                name = Name;
                surname = Surname;
            }
            public Person()
            {
                
            }
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
            }
        }
        static class CustomSerializer
        {
            private static string subl = "C:\\Users\\Acer\\AppData\\Local\\Programs\\Microsoft VS Code\\Code.exe";
            public static void XMLSerializer(List<Person> per)
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Person>));
                using (FileStream fs = new FileStream("Person.xml", FileMode.OpenOrCreate))
                {
                    xml.Serialize(fs, per);
                }
                Process.Start(subl, "Person.xml");
            }
            public static void BinSerializer(List<Person> per)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream("Person.bin", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, per);
                }
                Process.Start(subl, "Person.bin");
            }
            public static async Task JSONSerializerAsync(List<Person> per)
            {
                using (FileStream fs = new FileStream("Person.json", FileMode.OpenOrCreate))
                {

                    var json = Encoding.Default.GetBytes(JsonSerializer.Serialize(per));
                    fs.Write(json, 0, json.Length);

                }
                Process.Start(subl, "Person.json");
            }
            //public static void SOAPSerializer(List<Person> per)
            //{
            //    SoapFormatter formatter = new SoapFormatter();
            //    using (FileStream fs = new FileStream("Person.soap", FileMode.OpenOrCreate))
            //    {
            //        formatter.Serialize(fs, per);
            //    }
            //    Process.Start(subl, "Person.soap");
            //}
        }
        public static class CustomDeserializer
        {
            public static List<Person> JSONDeserializer()
            {
                using (FileStream fs = File.OpenRead("Person.json"))
                {
                    byte[] array = new byte[fs.Length];
                    fs.Read(array, 0, array.Length);
                    string per = Encoding.Default.GetString(array);
                    return JsonSerializer.Deserialize<List<Person>>(per);
                }
            }
            public static List<Person> XMLDeserializer()
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Person>));
                using (FileStream fs = File.OpenRead("Person.xml"))
                {
                    return xml.Deserialize(fs) as List<Person>;

                }
            }
            public static List<Person> BinDeserializer()
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = File.OpenRead("Person.bin"))
                {
                    return formatter.Deserialize(fs) as List<Person>;
                }
            }
            public static List<Person> SOAPDeserializer()
            {
                SoapFormatter formatter = new SoapFormatter();
                using (FileStream fs = File.OpenRead("Person.soap"))
                {
                    return formatter.Deserialize(fs) as List<Person>;
                }
            }
        }
        class AdobeProgram
        {
            public string Name { get; set; }
            public string Price { get; set; }
            public string Period { get; set; }
        }


    }
}
