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
        public static List<Categoria> categorias = new List<Categoria>();
        public static List<Dificultad> dificultades = new List<Dificultad>();
        public static List<Pregunta> preguntasActuales = new List<Pregunta>();
        static void Main(string[] args)
        {
            Conexion.OpenConnection();
            IniciarDatos();
            Menu();
            Console.Clear();
            string[] opciones = { "Jugar", "Podio", "Salir" };
            int seleccion = Herramienta.MenuSeleccionar(opciones, 1, $"Bienvenido, {usuarioActual.Username}");
            switch (seleccion)
            {
                case 1: nJuego.Jugar(usuarioActual, categorias, dificultades); break;
                //case 2: nJuego.; break;
                case 3: break;
            }
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

        public static void IniciarDatos()
        {
            SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM categoria");
            cmd.Connection = Conexion.Connection;
            SQLiteDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Categoria c = new Categoria();
                c.id = dr.GetInt32(0);
                c.nombre = dr.GetString(1);
                categorias.Add(c);
            }

            SQLiteCommand cmd2 = new SQLiteCommand("SELECT * FROM dificultad");
            cmd2.Connection = Conexion.Connection;
            SQLiteDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                Dificultad c2 = new Dificultad();
                c2.id = dr2.GetInt32(0);
                c2.dificultad = dr2.GetString(1);
                c2.puntos = dr2.GetInt32(2);
                dificultades.Add(c2);
            }
        }
    }
}
