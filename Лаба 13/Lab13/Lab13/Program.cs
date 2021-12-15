using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab13
{
    class Program
    {
        static void Main(string[] args)
        {
            SRVDirInfo.Info("D:\\ООП");
            Separator();
            SRVDiskInfo.Info();
            Separator();
            SRVFileInfo.Info(Path.GetRandomFileName());
            Separator();

            SRVFileManager.SRVInspector();
            List<string>? list = new List<string>();
            list = SRVLog.SearchByDay("5");
            list = SRVLog.Search("CorelDraw");
            foreach (var sm in list)
                Console.WriteLine(sm);
            Console.WriteLine(SRVLog.RemoverByTime(Convert.ToDateTime("08.12.2021 11:12:17"), Convert.ToDateTime("08.12.2021 11:28:35")));

        }
        public static void Separator()
        {
            Console.WriteLine("----------------------------------");
        }
    
        static class SRVDirInfo
        {
            public static void Info(string path)
            {
                try
                {
                    DirectoryInfo directory = new DirectoryInfo(path);
                    Console.WriteLine("Количество файлов: " + directory.GetFiles().Length);
                    Console.WriteLine("Время создания: " + directory.CreationTime);
                    Console.WriteLine("Количество поддиректорий: " + directory.GetDirectories().Length);
                    Console.WriteLine("Родительская директория: " + directory.Parent);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
        static class SRVLog
        {
            private static string path = "D:\\ООП\\Лаба 13\\Lab13\\SRVLog.txt";
            private static string path1 = "D:\\ООП\\Лаба 13\\Lab13\\SRVLog1.txt";
            public static void Log(string FileName, string Message)
            {

                string msg = $"[{DateTime.Now}] {FileName}: {Message}";
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLineAsync(msg);
                }
            }
            public static List<string>? Search(string SearchData)
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string FileData = sr.ReadToEnd();
                    List<string> SearchedInfo = new List<string>();
                    for (int i = 0; i < FileData.Length; i++)
                    {
                        for (int SearchDataIndex = 0, FileDataIndex = i; SearchDataIndex < SearchData.Length; SearchDataIndex++, FileDataIndex++)
                        {
                            if (FileData[FileDataIndex] == SearchData[SearchDataIndex])
                            {
                                if (SearchData.Length - 1 == SearchDataIndex)
                                {
                                    while (FileData[FileDataIndex] != '[')
                                        FileDataIndex--;
                                    string Message = "";
                                    while (FileData[FileDataIndex] != '\n')
                                    {
                                        Message += FileData[FileDataIndex];
                                        FileDataIndex++;
                                    }
                                    SearchedInfo.Add(Message);
                                    break;
                                }
                                else
                                    continue;
                            }
                            else
                                break;
                        }
                    }
                    if (SearchedInfo.Count > 0)
                        return SearchedInfo;
                    else
                        return null;
                }
            }
            public static List<string>? SearchByDay(string day)
            {
                if (Convert.ToInt32(day) < 0 || Convert.ToInt32(day) > 31)
                    return null;
                if (day.Length == 1)
                {
                    day += '0';
                    char[] arr = day.ToCharArray();
                    Array.Reverse(arr);
                    day = new string(arr);
                }

                List<string> SearchedData = new List<string>();
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string Line = sr.ReadLine();
                        if (Line[1] == day[0] && Line[2] == day[1])
                            SearchedData.Add(Line);
                    }
                }
                if (SearchedData.Count == 0)
                    return null;
                else
                    return SearchedData;
            }
            public static bool RemoverByTime(DateTime startTime, DateTime endTime)
            {
                if (startTime > endTime)
                    return false;

                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string Line = sr.ReadLine();
                        string date = "";
                        DateTime DT = new DateTime();
                        for (int i = 1; i < 20; i++)
                            date += Line[i];
                        try
                        {
                            DT = Convert.ToDateTime(date);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                            return false;
                        }
                        if (!(DT >= startTime && DT <= endTime))
                        {
                            using (StreamWriter sw = File.AppendText(path1))
                            {
                                sw.WriteLine(Line);
                            }
                        }
                    }
                }
                return true;
            }
        }
        static class SRVFileManager
        {
            public static void SRVInspector()
            {
                Directory.CreateDirectory("D:\\SRVInspect");
                var drive = DriveInfo.GetDrives()[1];
                string Message = "Список файлов и папок:\n";
                Message += FilesAndDirectories(drive.Name);
                File.AppendAllText("D:\\SRVInspect\\Info.txt", Message);

            }
            private static string FilesAndDirectories(string path)
            {
                string Message = "";
                List<string> ls = GetRecursFiles(path);
                foreach (string fname in ls)
                {
                    Message += fname;
                }
                return Message;
            }
            private static List<string> GetRecursFiles(string start_path)
            {
                List<string> ls = new List<string>();
                try
                {
                    string[] folders = Directory.GetDirectories(start_path);
                    foreach (string folder in folders)
                    {
                        ls.Add("Папка: " + folder + "\n");
                        ls.AddRange(GetRecursFiles(folder));
                        SRVLog.Log(folder, "Чтение имени папки");
                    }
                    string[] files = Directory.GetFiles(start_path);
                    foreach (string filename in files)
                    {
                        ls.Add("Файл: " + filename + "\n");
                        SRVLog.Log(filename, "Чтение имени файла");
                    }
                }
                catch (System.Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
                return ls;
            }
        }
        static class SRVFileInfo
        {
            public static void Info(string path)
            {
                try
                {
                    FileInfo file = new FileInfo(path);
                    Console.WriteLine("Польный путь: " + file.FullName);
                    Console.WriteLine("Размер:" + file.Length);
                    Console.WriteLine("Расширение: " + file.Extension);
                    Console.WriteLine("Имя: " + file.Name);
                    Console.WriteLine("Дата создания: " + File.GetCreationTime(path));
                    Console.WriteLine("Дата изменения: " + File.GetLastWriteTime(path));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
        static class SRVDiskInfo
        {
            public static void Info()
            {
                foreach (var drive in DriveInfo.GetDrives())
                {
                    try
                    {
                        Console.WriteLine("Имя диска: " + drive.Name);
                        Console.WriteLine("Файловая система: " + drive.DriveFormat);
                        Console.WriteLine("Тип диска: " + drive.DriveType);
                        Console.WriteLine("Общий объем свободного места (в байтах): " + drive.TotalFreeSpace);
                        Console.WriteLine("Размер диска (в байтах): " + drive.TotalSize);
                        Console.WriteLine("Метка тома диска: " + drive.VolumeLabel);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
        }
    }
}
