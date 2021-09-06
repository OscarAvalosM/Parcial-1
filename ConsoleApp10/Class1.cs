using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary3
{
    class usuario
    {

        public static void xd()
        {

            bool showMenu = true;

            while (showMenu)

            {
                showMenu = Menu();
            }
            Console.ReadKey();
        }

        private static bool Menu()
        {

            Console.WriteLine("selecion de archio: ");
            Console.WriteLine("1. mostrar archivos");
            Console.WriteLine("2. Salir");
            Console.Write("\nOpcion: ");

            switch (Console.ReadLine())
            {

                case "1":

                    Console.WriteLine("Travajos de usuarios ");
                    foreach (KeyValuePair<object, object> data in readFile())
                    {
                        Console.WriteLine("{0}: {1}", data.Key, data.Value);
                    }
                    Console.ReadKey();
                    return true;
                case "2":
                    return false;
                default:
                    return false;
            }
        }

        private static string direcion()
        {
            string path = @"C:\Users\lobo1\source\repos\ConsoleApp10\registros\archivo.txt";
            return path;
        }

        private static Dictionary<object, object> readFile()
        {

            Dictionary<object, object> listData = new Dictionary<object, object>();


            using (var reader = new StreamReader(direcion()))
            {

                string lines;

                while ((lines = reader.ReadLine()) != null)
                {
                    string[] keyvalue = lines.Split(';');
                    if (keyvalue.Length == 2)
                    {
                        listData.Add(keyvalue[0], keyvalue[1]);
                    }
                }

            }


            return listData;
        }
    }
}


