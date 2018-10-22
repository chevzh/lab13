using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab13
{
    static class CEADiskInfo
    {
        public static void GetDriveFreeSpace()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach(var drive in drives)
            {

                Console.WriteLine(drive.Name);
                if (drive.IsReady)
                {
                    Console.WriteLine("Доступно {0:0.##} Гб",drive.AvailableFreeSpace / Math.Pow(1024,3) );
                }
                else
                {
                    Console.WriteLine("Недоступен");
                }
               
            }

        }


        public static void GetFileInfo()
        {

        }

        public static void GetDriveInfo()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            Console.WriteLine("-------------------Информация о дисках-------------------");
            foreach (var drive in drives)
            {
                Console.WriteLine(drive.Name);
                if (drive.IsReady)
                {
                    Console.WriteLine("Общий объём {0:0.##} Гб", drive.TotalSize / Math.Pow(1024, 3));
                    Console.WriteLine("Доступно {0:0.##} Гб", drive.AvailableFreeSpace / Math.Pow(1024, 3));
                    Console.WriteLine("Метка тома: {0}", drive.TotalSize);
                }
                else
                {
                    Console.WriteLine("Недоступен");
                }
            }
        }

    }
}
