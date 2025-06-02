using System.Data.SQLite;
using QuizTp3.Controladores;

namespace QuizTp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Conexion.OpenConnection();

            Console.WriteLine("Hello, World!");

            Conexion.CloseConnection();
        }
    }
}
