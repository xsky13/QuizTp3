using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace QuizTp3.Controladores
{
    internal class Conexion
    {
        static string connectionString = $"Data Source=../../../database.db";
        static SQLiteConnection conexion = new SQLiteConnection(connectionString);
        public static void OpenConnection()
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
                conexion.Open();
            //Activamos la gestión de llaves foráneas
            using (SQLiteCommand command = new SQLiteCommand("PRAGMA foreign_keys = ON;", conexion))
            {
                command.ExecuteNonQuery();
            }
        }
        public static void CloseConnection()
        {
            conexion.Close();
        }
        public static SQLiteConnection Connection
        {
            set { conexion = value; }
            get { return conexion; }
        }
    }
}
