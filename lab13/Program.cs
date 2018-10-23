using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab13
{
    class Program
    {
        static void Main(string[] args)
        {

            CEADiskInfo.GetDriveFreeSpace();
            CEADiskInfo.GetDriveInfo();
            CEAFileInfo.GetFileInfo(@"C:\Users\eugen\Desktop\lab13\lab13.sln");
            CEADirInfo.GetDirInfo(@"C:\Users\eugen\Desktop\lab13\");


            #region Task 5

            CEAFileManager.CreateDirectory(@"C:\Users\eugen\Desktop\lab13\CEAInspect");
            CEAFileManager.CreateFile(@"C:\Users\eugen\Desktop\lab13\CEAInspect\CEAdirinfo.txt");
            CEAFileManager.WriteInfo(@"C:\Users\eugen\Desktop\lab13\CEAInspect\CEAdirinfo.txt", CEAFileManager.GetFilesAndFolders(@"D:\Steam"));
            if (File.Exists(@"C:\Users\eugen\Desktop\lab13\CEAInspect\CEACopy.txt"))
            {
                File.Delete(@"C:\Users\eugen\Desktop\lab13\CEAInspect\CEACopy.txt");
            }
            File.Copy(@"C:\Users\eugen\Desktop\lab13\CEAInspect\CEAdirinfo.txt", @"C:\Users\eugen\Desktop\lab13\CEAInspect\CEACopy.txt");
            File.Delete(@"C:\Users\eugen\Desktop\lab13\CEAInspect\CEAdirinfo.txt");

            //if (Directory.Exists(@"C:\Users\eugen\Desktop\lab13\CEAInspect\"))
            //{
            //    Directory.Delete(@"C:\Users\eugen\Desktop\lab13\CEAInspect\", true);
            //}
            CEAFileManager.CopyFiles(@"C:\Users\eugen\Desktop\lab13\lab13", ".cs");
            Directory.Move(@"C:\Users\eugen\Desktop\lab13\CEAFiles", @"C:\Users\eugen\Desktop\lab13\CEAInspect\CEAFiles");


            string sourceFile = @"C:\Users\eugen\Desktop\lab13\13_Потоки_файловая система.pdf"; // исходный файл
            string compressedFile = @"C:\Users\eugen\Desktop\lab13\lab13.gz"; // сжатый файл
            string targetFile = @"D:\lab13_new.pdf"; // восстановленный файл

            // создание сжатого файла
            CEAFileManager.Compress(sourceFile, compressedFile);
            // чтение из сжатого файла
            CEAFileManager.Decompress(compressedFile, targetFile);

            #endregion

            CEALog.FindInfo("Создание файла");
            CEALog.LastHourLog();

        }
    }
}
