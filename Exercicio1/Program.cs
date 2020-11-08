using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Exercicio1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the path of source file: ");
            string path = Console.ReadLine();
            string newPath = Path.GetDirectoryName(path);
            Directory.CreateDirectory(newPath + Path.DirectorySeparatorChar + "out");
            newPath = newPath + Path.DirectorySeparatorChar + "out" + Path.DirectorySeparatorChar + "summary.csv";

            List<string[]> list = new List<string[]>();

            try
            {
                using (FileStream stream = new FileStream(path, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        while (!reader.EndOfStream)
                        {
                            list.Add(reader.ReadLine().Split(","));
                        }
                    }
                }

                using (FileStream stream = new FileStream(newPath, FileMode.OpenOrCreate))
                {


                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        foreach (string[] vs in list)
                        {
                            string temp = vs[0];
                            temp += ",";
                            temp += ((double.Parse(vs[1], CultureInfo.InvariantCulture)
                                * double.Parse(vs[2], CultureInfo.InvariantCulture))
                                .ToString("F2", CultureInfo.InvariantCulture));
                            writer.WriteLine(temp);
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Unexpected error! " + e.Message);
            }
        }
    }
}
