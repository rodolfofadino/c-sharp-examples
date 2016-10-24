using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IOExamples
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Directories();
            WriteFiles();
            ReadFiles();
        }

        private static void Directories()
        {
            var pasta = "d:/pasta";

            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            var outraPasta = "d:/outraPasta";
            Directory.Move(pasta, outraPasta);

            Directory.Delete(outraPasta, true);

            var directories = Directory.GetDirectories("c:/projetostf", "*ds*", SearchOption.TopDirectoryOnly);
            var files = Directory.GetFiles("c:/projetostf", "*.config", SearchOption.AllDirectories);
        }

        private static void WriteFiles()
        {
            var inicio = DateTime.Now;

            using (var fileStream = new FileStream("d:\\test.txt", FileMode.Append, FileAccess.Write))
            {
                using (var streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.AutoFlush = false;

                    var line = "Lorem ipsum dolor sit amet, consectetur adipiscing";
                    for (var i = 0; i < 10000000; i++)
                    {
                        streamWriter.WriteLine(line);
                        if (i % 1000 == 0)
                            streamWriter.Flush();
                    }
                    streamWriter.Flush();
                }
            }

            var fim = DateTime.Now;
            var total = (fim - inicio).TotalMilliseconds;
            Console.WriteLine(total);
            Console.ReadKey();
            //49083,746ms
            //18760,734ms
        }

        private static void ReadFiles()
        {
            var text = File.ReadAllText("d:/test.txt");
            string[] allLines = File.ReadAllLines("d:/test.txt");
            int total = 0;
            foreach (var line in File.ReadLines("d:/test.txt"))
            {
                //processa a linha
                total++;
            }
            using (var fileStream = new FileStream("d:/test.txt", FileMode.Open, FileAccess.Read))
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        //processa a linha
                    }
                }
            }
        }










    }
}
