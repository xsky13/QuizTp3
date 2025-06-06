using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Libreria2025;
using QuizTp3.Modelos;

namespace QuizTp3.Controladores
{
    internal class nUsuario
    {
        public static void GetPuntos()
        {
            Console.Clear();
            SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM user");
            cmd.Connection = Conexion.Connection;
            SQLiteDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Usuario u = new Usuario();
                u.Id = dr.GetInt32(0);
                u.Username = dr.GetString(1);
                u.Pwd = dr.GetString(2);
                u.Puntaje = dr.GetInt32(3);
                Program.usuarios.Add(u);
            }
            seleccionPodio();
        }
        private static void seleccionPodio()
        {
            string[] podios = new string[] { "Segun los puntos", "Segun el promedio de respuestas correctas" };
            int podio = Herramienta.MenuSeleccionar(podios, 1, "Selecciona el podio");
            switch (podio)
            {
                case 1: sPuntos(Program.usuarios); break;
                case 2: sPromedio(Program.usuarios); break;
            }
        }

        private static void sPuntos(List<Usuario> usuarios)
        {
            List<Usuario> usuariosOrdenados = new List<Usuario>();
            List<int> puntosOrdenados = new List<int>();
            List<int> puntos = new List<int>();
            for (int i = 0; i < usuarios.Count; i++)
            {
                puntos.Add(usuarios[i].Puntaje);
            }
            for (int i = 0; i < puntos.Count; i++)
            {
                puntosOrdenados.Add(puntos.Max());
                puntos.Remove(puntos[i]);
            }
            for (int i = 0; i < puntos.Count; i++)
            {
                for (int j = 0; j < usuarios.Count; j++)
                {
                    if (usuarios[j].Puntaje == puntos[i])
                    {
                        usuariosOrdenados.Add(usuarios[j]);
                    }
                    else { }
                }
            }


            Console.WriteLine("Podio segun puntaje: ");
            for (int i = 0; i < usuariosOrdenados.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {usuariosOrdenados[i].Username}: {usuariosOrdenados[i].Puntaje}");
            }
        }
        private static void sPromedio(List<Usuario> usuarios)
        {
            List<Usuario> usuariosOrdenados = new List<Usuario>();
            List<int> promediosOrdenados = new List<int>();
            List<int> promedios = new List<int>();
            for (int i = 0; i < usuarios.Count; i++)
            {
                promedios.Add(usuarios[i].Puntaje);
            }
            for (int i = 0; i < promedios.Count; i++)
            {
                promediosOrdenados.Add(promedios.Max());
                promedios.Remove(promedios[i]);
            }
            for (int i = 0; i < promedios.Count; i++)
            {
                for (int j = 0; j < usuarios.Count; j++)
                {
                    if (usuarios[j].Puntaje == promedios[i])
                    {
                        usuariosOrdenados.Add(usuarios[j]);
                    }
                    else { }
                }
            }


            Console.WriteLine("Podio segun puntaje: ");
            for (int i = 0; i < usuariosOrdenados.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {usuariosOrdenados[i].Username}: {usuariosOrdenados[i].Puntaje}");
            }
        }
    }
}
