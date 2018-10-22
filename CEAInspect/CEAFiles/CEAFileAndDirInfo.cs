using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab13
{
    static class CEAFileInfo
    {

        public static void GetFileInfo(string dirName)
        {
            FileInfo file = new FileInfo(dirName);

            if (file.Exists)
            {
                Console.WriteLine("-------------------Информация о файле {0}-------------------", file.Name);

                Console.WriteLine("Название каталога: {0}", file.Name);
                Console.WriteLine("Полное название каталога: {0}", file.FullName);
                Console.WriteLine("Время создания каталога: {0}", file.CreationTime);
                Console.WriteLine("Расширение: {0}", file.Extension);
            }         

        }

    }

    
    static class CEADirInfo
    {

        public static void GetDirInfo(string dirName)// переделать по заданию
        {
            DirectoryInfo dirInfo = new DirectoryInfo(dirName);

            Console.WriteLine("-------------------Информация о каталоге {0}-------------------", dirInfo.Name);
            
            Console.WriteLine("Количество файлов: {0}", Directory.GetFileSystemEntries(dirName).Count());
            Console.WriteLine("Время создания каталога: {0}", dirInfo.CreationTime);
            Console.WriteLine("Количество поддиректориев: {0}", Directory.GetDirectories(dirName).Count());
            Console.WriteLine("Родительские каталоги: ");
            while(dirInfo != null)
            {
                dirInfo = dirInfo.Parent;
                Console.WriteLine(dirInfo);
            }            

        }

    }

}



