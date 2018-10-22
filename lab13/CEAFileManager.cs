using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab13
{
    class CEAFileManager
    {
        public static List<string> GetFilesAndFolders(string dirName)
        {
            return new List<string>(Directory.GetFileSystemEntries(dirName));
        }

        public static void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }

        public static void CreateFile(string path)
        {
            using (File.Create(path));
        }

        public static void WriteInfo(string path, IEnumerable<string> buffer)
        {
            using (StreamWriter sw = new StreamWriter(path,false,System.Text.Encoding.Default))
            {
                foreach (var str in buffer)
                {
                    sw.WriteLine(str);
                }
            }
        }

        public static void CopyFiles(string from, string extension)
        {

            DirectoryInfo dirInfo = new DirectoryInfo(from);

            DirectoryInfo destDir = new DirectoryInfo(@"C:\Users\eugen\Desktop\lab13\CEAFiles");
            if (!destDir.Exists)
            {
                CreateDirectory(@"C:\Users\eugen\Desktop\lab13\CEAFiles");
            }

            foreach(var file in dirInfo.GetFiles())
            {
                if (file.Extension.Equals(extension))
                {
                   File.Copy(file.FullName, @"C:\Users\eugen\Desktop\lab13\CEAFiles\"+file.Name);
                }
            }

        }

        public static void Compress(string sourceFile, string compressedFile)
        {
            // поток для чтения исходного файла
            using (FileStream sourceStream = new FileStream(sourceFile, FileMode.OpenOrCreate))
            {
                // поток для записи сжатого файла
                using (FileStream targetStream = File.Create(compressedFile))
                {
                    // поток архивации
                    using (GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress))
                    {
                        sourceStream.CopyTo(compressionStream); // копируем байты из одного потока в другой
                        Console.WriteLine("Сжатие файла {0} завершено. Исходный размер: {1}  сжатый размер: {2}.",
                            sourceFile, sourceStream.Length.ToString(), targetStream.Length.ToString());
                    }
                }
            }
        }

        public static void Decompress(string compressedFile, string targetFile)
        {
            // поток для чтения из сжатого файла
            using (FileStream sourceStream = new FileStream(compressedFile, FileMode.OpenOrCreate))
            {
                // поток для записи восстановленного файла
                using (FileStream targetStream = File.Create(targetFile))
                {
                    // поток разархивации
                    using (GZipStream decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(targetStream);
                        Console.WriteLine("Восстановлен файл: {0}", targetFile);
                    }
                }
            }
        }


    }
}
