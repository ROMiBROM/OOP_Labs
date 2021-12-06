using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace Lab12
{
    public static class Reflector
    {
        public static string Path = "D:\\ООП\\Лаба 12\\Lab12\\";
        public static string PathName = "CheckList(lab12).txt";
        public static void AssemblyName(object obj) //  класс, хранящий информацию о сборке
        {
            Type type = obj.GetType();
            string Info = "Имя сборки: " + type.Name + '\n' + "--------------------------\n";
            File.AppendAllText(Path + PathName, Info);
        }
         public static void PublicContructors(object obj)
        {
            string Info = "Есть ли публичные конструкторы: ";
            Type type = obj.GetType();
            ConstructorInfo[] ConstructorInfo = type.GetConstructors(); //возвращает все конструкторы данного типа в виде набора объектов ConstructorInfo
            if (ConstructorInfo.Length > 0)
                Info += "- да\n"+"-------------------------\n";
            else
                Info += " - нет\n" + "-------------------------\n";
            File.AppendAllText(Path + PathName, Info);
        }
        public static List<string> PublicMethods(object obj)
        {
            string PublicMethodsString = "Публичные методы: \n";
            Type type = obj.GetType();
            List<string> PublicMethodsList = new List<string>();

            var AllMethods = type.GetMethods(); // получает все методы типа в виде массива объектов MethodInfo
            foreach (var Met in AllMethods)
            {
                PublicMethodsList.Add(Met.Name);
                PublicMethodsString += Met.Name + "\n";
            }

            PublicMethodsString += "------------------------\n";
            if (PublicMethodsList.Count == 0)
                File.AppendAllText(Path + PathName, "Публичные методы: отсутствуют\n" +
                    "--------------------------------\n");
            else
                File.AppendAllText(Path + PathName, PublicMethodsString);
            return PublicMethodsList;
        }
        public static List<string> FieldsAndPropertiesInfo(object obj)
        {
            Type type = obj.GetType();
            string Info = "Поля:\n";
            List<string> FieldsAndProperties = new List<string>();
            List<string> Propertiess = new List<string>();

            var FieldsArr = type.GetFields(); // возвращает все поля данного типа в виде массива объектов FieldInfo

            foreach (FieldInfo FI in FieldsArr)
            {
                FieldsAndProperties.Add(FI.Name);
                Info += FI.Name + '\n';
            }

            if (FieldsAndProperties.Count==0)
                Info = "Поля: отсутствуют\n";
            Info += "\n";

            var Properties = type.GetProperties(); // получает все свойства в виде массива объектов PropertyInfo

            Info += "Свойства: \n";
            foreach (var PI in Properties)
            {
                Propertiess.Add(PI.Name);
                FieldsAndProperties.Add(PI.Name);
                Info += PI.Name + '\n';
            }

            if (Propertiess.Count==0)
                Info +="отсутствуют\n";

            Info += "------------------------------------\n";
            File.AppendAllText(Path + PathName, Info);
            return FieldsAndProperties;
        }
        public static List<string> Interfaces(object obj)
        {
            Type type = obj.GetType();
            string Info = "Реализованные интерфейсы:\n";
            List<string> InterfacesList = new List<string>();

            var Interfaces = type.GetInterfaces(); // получает все реализуемые данным типом интерфейсы в виде массива объектов Type

            foreach (var I in Interfaces)
            {
                InterfacesList.Add(I.Name);
                Info += I.Name + '\n';
            }

            Info += "\n";
            if (InterfacesList.Count == 0)
                File.AppendAllText(Path + PathName, "Реализованные интерфейсы: отсутствуют\n"+"-------------------------\n");
            else
                File.AppendAllText(Path + PathName, Info);
            return InterfacesList;
        }
        public static void MethodsByParameterType(object obj, Type Parameter)
        {
            Type type = obj.GetType();
            string Info = "Методы с типом параметра " + Parameter.Name + ":\n";
            string InfoStart = Info + "\n";

            var AllMethods = type.GetMethods(); //получает все методы типа в виде массива объектов MethodInfo
            foreach (var Met in AllMethods)
            {
                var MIParameters = Met.GetParameters(); //Массив типа, содержащий сведения, соответствующие сигнатуре метода
                foreach (var PI in MIParameters)
                {
                    if (PI.ParameterType == Parameter)
                    {
                        Info += Met.Name + '\n';
                        break;
                    }
                }
            }

            Info += "\n";
            if (InfoStart != Info)
                File.AppendAllText(Path + PathName, Info);
            else
                File.AppendAllText(Path + PathName, "Методы с типом параметра " + Parameter.Name + ": отсутствут\n" + "-----------------------------------\n");
        }
        public static object? Invoke(object obj, string MethodName, object?[]? Parameters)
        {
            Type type = obj.GetType();
            var Method = type.GetMethod(MethodName);
            var Result = Method.Invoke(obj, Parameters);
            return Result;
        }
        public static object? Create<T>(object?[]? Params)
        {
            Type type = typeof(T);
            var Constructors = type.GetConstructors();
            var Parameters = Constructors[0].GetParameters();
            object? Result = null;

            if (Params == null)
            {
                foreach (var Constructor in Constructors)
                {
                    if (Constructor.GetParameters().Length == 0)
                    {
                        Result = Constructor.Invoke(null);
                        break;
                    }
                }
            }
            else
            {
                foreach (var Constructor in Constructors)
                {
                    if (Constructor.GetParameters().Length == Params.Length)
                    {
                        Result = Constructor.Invoke(Params);
                        break;
                    }
                }
            }
            return Result;
        }
    }
}
