using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizTp3.Modelos;
using BCrypt.Net;

namespace QuizTp3.Controladores.Autenticacion
{
    internal class Login
    {
        public static (bool verificado, Usuario current) Main()
        {
            Usuario usuario = new();
            bool verificado = false;

            while (!verificado)
            {
                Console.Write("Ingrese su usuario: ");
                string ingreso = Console.ReadLine();

                Usuario u = VerificarUsuario(ingreso);
                if (u != null)
                {
                    usuario = u;
                    verificado = true;
                }
                else
                {
                    Console.WriteLine("Este usuario no existe. Por favor intente de nuevo...");
                    Console.ReadKey(true);
                }
            }

            bool pwdVerificado = false;
            while (!pwdVerificado)
            {
                Console.Write("Ingrese su contraseña: ");
                string pwd = Console.ReadLine();

                if (AuthHelper.Verificar(pwd, usuario.Pwd))
                {
                    pwdVerificado = true;
                }
                else
                {
                    Console.WriteLine("Su contraseña es incorrecta. Por favor intente de nuevo...");
                    Console.ReadKey(true);
                }
            }

            return (true, usuario);
        }

        public static Usuario VerificarUsuario(string usuario)
        {
            Usuario user = Persistencia.getByUsername(usuario);
            if (user == null)
            {
                return null;
            }
            else { return user; }
        }
    }
}
