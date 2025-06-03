using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizTp3.Modelos;

namespace QuizTp3.Controladores.Autenticacion
{
    internal class Persistencia
    {
        public static int Save(string usuario, string pwd)
        {
            SQLiteCommand cmd = new("INSERT INTO user (usuario, pwd) VALUES (@usuario, @pwd)");
            cmd.Connection = Conexion.Connection;

            cmd.Parameters.Add(new SQLiteParameter("@usuario", usuario));
            cmd.Parameters.Add(new SQLiteParameter("@pwd", pwd));

            cmd.ExecuteNonQuery();

            cmd = new SQLiteCommand("SELECT last_insert_rowid()", Conexion.Connection);
            long lastId = (long)cmd.ExecuteScalar();
            return (int)lastId;
        }
    }
}
