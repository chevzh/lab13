using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab13
{
    class CEALog
    {

        public static void WriteToLog(string action, string fileName, string path)
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Users\eugen\Desktop\lab13\cealog.txt", true, System.Text.Encoding.Default))
            {
                sw.WriteLine("\n");
                sw.WriteLine(action);
                sw.WriteLine(DateTime.Now);
                sw.WriteLine($"Имя файла: {fileName}");
                sw.WriteLine($"Путь к файлу: {path}");
            }
        }


        public static void FindInfo(string action)
        {
            using (StreamReader sr = new StreamReader(@"C:\Users\eugen\Desktop\lab13\cealog.txt", System.Text.Encoding.Default))
            {
                string line;
                int counter = 0;
                bool writing = false;

                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains(action) || writing)
                    {
                        Console.WriteLine(line);
                        counter++;
                        if (counter != 4)
                        {
                            writing = true;
                        }
                        else
                        {
                            writing = false;
                        }                       
                    }
                    else
                    {
                        counter = 0;
                    }                 

                   

                }
            }
        }

        //public static void LastHourLog()
        //{
        //    string line;
        //    int counter = 0;
        //    bool writing = false;
        //    using (StreamReader sr = new StreamReader(@"C:\Users\eugen\Desktop\lab13\cealog.txt", System.Text.Encoding.Default))
        //    {
        //        while ((line = sr.ReadLine()) != null)
        //        {
        //            if (line.Contains(DateTime.Now.Hour.ToString()) || writing)
        //            {
        //                Console.WriteLine(line);
        //                counter++;
        //                if (counter != 4)
        //                {
        //                    writing = true;
        //                }
        //                else
        //                {
        //                    writing = false;
        //                }
        //            }
        //            else
        //            {
        //                counter = 0;
        //            }
        //        }
        //}

    }


    //class LogEventArgs
    //{
    //    //действие
    //    public string Action { get; }
    //    //имя файла
    //    public string FileName { get; }
    //    //путь к файлу
    //    public string Path { get; }

    //    public LogEventArgs(string action, string name, string path)
    //    {
    //        Action = action;
    //        FileName = name;
    //        Path = Path;
    //    }

    //}

}
