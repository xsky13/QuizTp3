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
    internal class nJuego
    {
        private readonly pPregunta _preguntas;
        private readonly nUsuario _usuario;
        public static int Puntaje;
        private static int rCorrectas = 0;
        private static int promedioCorrectas = 0;

        public nJuego(pPregunta preguntas, nUsuario usuario)
        {
            _preguntas = preguntas;
            _usuario = usuario;
        }

        public static void ComenzarJuego(List<Pregunta> preguntas)
        {
            int i = 0;
            while (i < preguntas.Count)
            {
                Console.Clear();
                Console.WriteLine($"Pregunta numero {i + 1}: ");
                Console.WriteLine(preguntas[i].Enunciado);

                preguntas[i].Opciones = pOpcion.GetbyId(preguntas[i].id);

                int j = 1;
                foreach (Opcion opcion in preguntas[i].Opciones)
                {
                    Console.WriteLine($"{j}. {opcion.Texto}");
                    j++;
                }

                Console.WriteLine("Seleccione una opcion: ");
                verificarSeleccion(preguntas[i]);

                Console.ReadKey(true);                
                i++;
            }

            promedioCorrectas = rCorrectas * 10;


            if (Program.usuarioActual.Puntaje < Program.puntaje) 
            {
                SQLiteCommand cmd = new SQLiteCommand("UPDATE user SET puntaje = @puntaje WHERE id = @id");
                cmd.Parameters.Add(new SQLiteParameter("@puntaje", Program.puntaje));
                cmd.Parameters.Add(new SQLiteParameter("@id", Program.usuarioActual.Id));
                cmd.Connection = Conexion.Connection;
                cmd.ExecuteNonQuery();

            }
            if (Program.usuarioActual.Promedio < promedioCorrectas)
            {
                SQLiteCommand cmd = new SQLiteCommand("UPDATE user SET promedio = @promedio WHERE id = @id");
                cmd.Parameters.Add(new SQLiteParameter("@promedio", promedioCorrectas));
                cmd.Parameters.Add(new SQLiteParameter("@id", Program.usuarioActual.Id));
                cmd.Connection = Conexion.Connection;
                cmd.ExecuteNonQuery();
            }
            terminarJuego();
        }

        public static void verificarSeleccion(Pregunta pregunta)
        {
            string selector = Console.ReadLine();
            int seleccion = 0;

            if (selector == "1")
            {
                seleccion = pregunta.Opciones[0].Id;
                mensaje(seleccion, pregunta);
            }
            else if (selector == "2")
            {
                seleccion = pregunta.Opciones[1].Id;
                mensaje(seleccion, pregunta);
            }
            else if (selector == "3")
            {
                seleccion = pregunta.Opciones[2].Id;
                mensaje(seleccion, pregunta);
            }
            else if (selector == "4")
            {
                seleccion = pregunta.Opciones[3].Id;
                mensaje(seleccion, pregunta);
            }
            else
            {
                Console.WriteLine(" Vuelve a intentarlo. Selecciona un numero del 1 al 4... ");
                verificarSeleccion(pregunta);
            }
        }
        static void mensaje(int seleccion, Pregunta pregunta)
        {
            if (seleccion == pregunta.RespuestaCorrecta)
            {
                Console.WriteLine("Respuesta CORRECTA");
                Program.puntaje += pregunta.Dificultad.puntos;
                rCorrectas++;
            }
            else
            {
                Console.WriteLine("Respuesta INCORRECTA");
                Program.puntaje -= pregunta.Dificultad.puntos / 2;
            }
        }
        
        static void terminarJuego()
        {
            Program.puntaje = 0;
            rCorrectas = 0;
            Program.preguntasActuales.Clear();
            Program.categorias.Clear();
            Program.dificultades.Clear();
            Program.MenuPrincipal();
        }
    }
}
