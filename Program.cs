/* ЗАДАНИЕ 2
Напишите программу, которая считает размер папки на диске (вместе со всеми вложенными папками и файлами).
На вход метод принимает URL директории, в ответ — размер в байтах.*/

using System;
using System.IO;
public class FolderScaner
{
    public static long DirectorySize(string urlPath)
    {
        DirectoryInfo dir = new DirectoryInfo(urlPath);

        if (!Directory.Exists(urlPath))
        {
            Console.WriteLine($"Директории {urlPath} не существует!");
            return 0;
        }

        return (DirectoryCalculate(dir));
    }

    public static long DirectoryCalculate(DirectoryInfo dir)
    {
        long size = 0;  
        try
        {
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)

            {
                size += file.Length;
            }

            DirectoryInfo[] subDirs = dir.GetDirectories();
            foreach (DirectoryInfo directory in subDirs)

            {
                size += DirectoryCalculate(directory);
            }



        }
        catch (UnauthorizedAccessException e)
        {
            Console.WriteLine($"Ошибка доступа {e.Message}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка: {e.Message}");
        }

        return size;

    }
}
class Program
{
    static void Main(string[] args)
    {
        string urlPath = string.Empty;
        Console.Write("введите URL папки: ");
        urlPath = Console.ReadLine();

        long size = FolderScaner.DirectorySize(urlPath);
        Console.WriteLine($"Размер директории: {size}");
    }
}