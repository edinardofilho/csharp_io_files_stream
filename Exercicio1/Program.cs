using Exercicio1.Entities;
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
            if (!Directory.Exists(newPath + Path.DirectorySeparatorChar + "out"))
            {
                Directory.CreateDirectory(newPath + Path.DirectorySeparatorChar + "out");
            } 
           
            newPath = newPath + Path.DirectorySeparatorChar + "out" + Path.DirectorySeparatorChar + "summary.csv";

            List<Product> list = new List<Product>();

            try
            {
                using (FileStream stream = new FileStream(path, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        while (!reader.EndOfStream)
                        {
                            string[] vs = reader.ReadLine().Split(",");

                            list.Add(new Product(vs[0], double.Parse(vs[1], CultureInfo.InvariantCulture), int.Parse(vs[2])));
                        }
                    }
                }

                using (FileStream stream = new FileStream(newPath, FileMode.OpenOrCreate))
                {
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        foreach (Product p in list)
                        {
                            writer.WriteLine(p);
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
