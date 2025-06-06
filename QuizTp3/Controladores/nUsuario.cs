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
            Program.usuarios.Clear();
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
                u.Promedio = dr.GetInt32(4);
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
            List<Usuario> usuariosOrdenados = usuarios.OrderByDescending(u => u.Puntaje).ToList();
            Console.WriteLine("Podio segun puntaje: ");
            for (int i = 0; i < usuariosOrdenados.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {usuariosOrdenados[i].Username}: {usuariosOrdenados[i].Puntaje}");
            }
            Console.ReadKey(true);
            Program.MenuPrincipal();
        }
        private static void sPromedio(List<Usuario> usuarios)
        {
            List<Usuario> usuariosOrdenados = usuarios.OrderByDescending(u => u.Promedio).ToList();
            Console.WriteLine("Podio segun Promedio de respuestas correctas: ");
            for (int i = 0; i < usuariosOrdenados.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {usuariosOrdenados[i].Username}: {usuariosOrdenados[i].Promedio}%");
            }
            Console.ReadKey(true);
            Program.MenuPrincipal();
        }
    }
}
