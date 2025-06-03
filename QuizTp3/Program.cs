using System.Data.SQLite;
using QuizTp3.Controladores;
using QuizTp3.Controladores.Autenticacion;

namespace QuizTp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Conexion.OpenConnection();

            Registrar.Registrarse();

            Conexion.CloseConnection();
        }
    }
}
