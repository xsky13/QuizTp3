using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizTp3.Modelos;

namespace QuizTp3.Controladores
{
    internal class pOpcion
    {
        public static List<Opcion> GetbyId(int preguntaId)
        {
            List<Opcion> opciones = new List<Opcion>();
            SQLiteCommand cmd = new SQLiteCommand("SELECT id, nOpcion FROM opciones WHERE preguntaId = @preguntaId");
            cmd.Parameters.Add(new SQLiteParameter("@preguntaId", preguntaId));
            cmd.Connection = Conexion.Connection;
            SQLiteDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Opcion o = new Opcion();
                o.Id = dr.GetInt32(0);
                o.Texto = dr.GetString(1);
                opciones.Add(o);
            }
            return opciones;
        }
    }
}
