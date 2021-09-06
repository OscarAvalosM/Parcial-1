using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ClassLibrary1;
using ClassLibrary3;

namespace Parcial_1
{
    class Program
    {
        static void Main(string[] args)
        {
            inicio();
        }
        private static string direccion()
        {
            string path = @"C:\Users\lobo1\source\repos\ConsoleApp10\registros\usuarios.txt";
            return path;
        }
        private static bool inicio()
        {
            Console.WriteLine("****** Bienvenido al menu de login y registro *****");
            Console.WriteLine("Elija una opcion a tomar");
            Console.WriteLine("1 - iniciar sesion");
            Console.WriteLine("2 - Registro de usuarios");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("selecione su opcion :");

            switch (Console.ReadLine())
            {
                case "1":
                    comprobar();
                    Console.ReadKey();
                    return true;
                case "2":
                    registro();
                    return true;
                default:
                    return false;
            }
        }
        private static void registro()
        {
            Console.Clear();
            Console.WriteLine("REGISTRO DE USUARIO.");
            Console.WriteLine("Ingrese el nomnbre de usuario :");
            String newus = Console.ReadLine();
            Console.WriteLine("ingresar la contraseña :");
            string newpass = Console.ReadLine();

            using (StreamWriter pr = File.AppendText(direccion()))
            {
                pr.WriteLine("{0}; {1}", newus, newpass);
                pr.Close();
            }
            inicio();
        }

        private static Dictionary<object, object> read()
        {
            Dictionary<object, object> listdata = new Dictionary<object, object>();
            using (var reader = new StreamReader(direccion()))
            {
                string lines;
                while ((lines = reader.ReadLine()) != null)
                {
                    string[] keyvalue = lines.Split(';');
                    if (keyvalue.Length == 2)
                    {
                        listdata.Add(keyvalue[0], keyvalue[1]);
                    }
                }
            }
            return listdata;
        }


        private static bool search(string user)
        {
            if (!read().ContainsKey(user))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static bool comprobar()
        {
            string adminuser = "admin";
            string adminpass = "123";
            Console.WriteLine("Usuario");
            var user = Console.ReadLine();

            if (search(user))
            {
                Console.WriteLine("Cuenta Existente");
                Console.WriteLine("");
                Console.WriteLine("Contraseña");
                var pass = Console.ReadLine();

                if (!read().ContainsValue(pass))
                {
                    Console.Write("Contraseña Correcta");
                    Console.Write("Usted a ingresado como Usuario");
                    Console.Write("");
                    usuario.xd();
                    

                    return false;
                }
                else
                {
                    Console.Write("CONTRASENA INCORRECTA");
                    return true;
                }
            }
            else if (user == adminuser)
            {
                Console.WriteLine("EL usuario es adminitrador");
                Console.WriteLine("");
                Console.WriteLine("contraseña");
                var pass = Console.ReadLine();
                if (pass == adminpass)
                {
                    Console.Write("Contraseña Correcta");
                    Console.WriteLine("");
                    Console.Write("usted es administrador");
                    Console.Write(" ");

                    admin.dx();

                }
                return false;
            }
            else
            {
                Console.WriteLine("usuario no existente");
                return false;
            }
        }
    }
}