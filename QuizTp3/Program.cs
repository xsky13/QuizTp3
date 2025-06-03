using System.Data.SQLite;
using QuizTp3.Controladores;
using QuizTp3.Controladores.Autenticacion;
using QuizTp3.Modelos;

namespace QuizTp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Usuario usuarioActual;
            Conexion.OpenConnection();

            //Registrar.Registrarse();
            var usuario = Login.Main();
            usuarioActual = usuario.current;

            if (usuario.verificado) Console.WriteLine($"Ingreso el usuario {usuarioActual.Username}");

            Conexion.CloseConnection();
        }
    }
}
