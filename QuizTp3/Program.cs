using System.Data.SQLite;
using Libreria2025;
using QuizTp3.Controladores;
using QuizTp3.Controladores.Autenticacion;
using QuizTp3.Modelos;

namespace QuizTp3
{
    internal class Program
    {
        public static bool loggedIn = false;
        public static Usuario usuarioActual = new();
        static void Main(string[] args)
        {
            Usuario usuarioActual;
            Conexion.OpenConnection();

            Menu();
            //Registrar.Registrarse();
            //var usuario = Login.Main();
            //usuarioActual = usuario.current;

            //if (usuario.verificado) Console.WriteLine($"Ingreso el usuario {usuarioActual.Username}");

            Conexion.CloseConnection();
        }

        static void Menu()
        {
            string[] opciones = { "Registrarse", "Iniciar sesion" };
            int opcion = Herramienta.MenuSeleccionar(opciones, 0, "Eliga una opcion");

            switch(opcion)
            {
                case 1: Registrar.Registrarse(); break;
                case 2: Login.Main(); break;
            }
        }
    }
}
