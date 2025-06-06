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
            Program.usuarios = [];
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
<<<<<<< HEAD
                u.Juegos = dr.GetInt32(5);
                u.Aciertos = dr.GetInt32(6);
=======
>>>>>>> c8cffb5c5dcb1a2f07c664546dc3c8623ec7b841
                Program.usuarios.Add(u);
            }
            seleccionPodio();
        }
        private static void seleccionPodio()
        {
            string[] podios = new string[] { "Segun los puntos", "Segun el promedio de respuestas correctas", "Volver" };
            int podio = Herramienta.MenuSeleccionar(podios, 1, "Selecciona el podio");
            switch (podio)
            {
                case 1: sPuntos(Program.usuarios); seleccionPodio(); break;
                case 2: sPromedio(Program.usuarios); seleccionPodio(); break;
                case 3: return;
            }
        }

        private static void sPuntos(List<Usuario> usuarios)
        {
<<<<<<< HEAD
            Console.Clear();


=======
            List<Usuario> usuariosOrdenados = usuarios.OrderByDescending(u => u.Puntaje).ToList();
>>>>>>> c8cffb5c5dcb1a2f07c664546dc3c8623ec7b841
            Console.WriteLine("Podio segun puntaje: ");
            int i = 0;
            foreach (Usuario usuario in usuarios.OrderByDescending(u => u.Puntaje).ToList())
            {
                Console.WriteLine($"{i + 1}. {usuario.Username}: {usuario.Puntaje}");
                i++;
            }
<<<<<<< HEAD

            Console.WriteLine("\nToque una tecla para volver...");
            Console.ReadKey(true);
        }
        private static void sPromedio(List<Usuario> usuarios)
        {
            Console.Clear();


            Console.WriteLine("Podio segun la cantidad de aciertos promedio: ");
            int i = 0;

            foreach (Usuario usuario in usuarios.OrderByDescending(u => u.Juegos != 0 ? u.Aciertos/u.Juegos : 0).ToList())
            {
                int promedio = usuario.Juegos != 0 ? usuario.Aciertos / usuario.Juegos : 0;
                Console.WriteLine($"{i + 1}. {usuario.Username}: {promedio}");
                i++;
            }


            Console.WriteLine("\nToque una tecla para volver...");
            Console.ReadKey(true);
=======
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
>>>>>>> c8cffb5c5dcb1a2f07c664546dc3c8623ec7b841
        }
    }
}
