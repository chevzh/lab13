using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            
        //    string currentHour = DateTime.Now.Hour.ToString();
        //    List<string> dates = new List<string>();

        //    using (StreamReader sr = new StreamReader(@"C:\Users\eugen\Desktop\lab13\cealog.txt", System.Text.Encoding.Default))
        //    {              
        //        string line;
        //        while ((line = sr.ReadLine()) != null)
        //        {
        //            Match match = Regex.Match(line, @"\d[:]\d\d[:]\d\d" );
        //            if (match.Success)
        //            {
        //                Console.WriteLine(match.Captures[0].Value);
        //                dates.Add(match.Captures[0].Value);
        //            }

        //            Match match1 = Regex.Match(line, @"\d\d[:]\d\d[:]\d\d");
        //            if (match1.Success)
        //            {
        //                Console.WriteLine(match1.Captures[0].Value);
        //                // dates.Add(match1.Captures[0].Value);
        //            }
        //        }
        //    }
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
