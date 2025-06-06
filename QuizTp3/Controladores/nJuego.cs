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
        public static int Acertadas;

        public nJuego(pPregunta preguntas, nUsuario usuario)
        {
            _preguntas = preguntas;
            _usuario = usuario;
        }

        public static void ComenzarJuego(List<Pregunta> preguntas)
        {
            Console.Clear();
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

            Console.Clear();
            Console.WriteLine($"PUNTAJE: {Puntaje}");
            Console.WriteLine($"ACERTADAS: {Acertadas}/10");

            

            SQLiteCommand cmd = new SQLiteCommand("UPDATE user SET puntaje = @puntaje, cantidadJuegos=@cantidadJuegos, cantidadAciertos=@cantidadAciertos WHERE id = @id");
            cmd.Parameters.Add(new SQLiteParameter("@puntaje", Program.usuarioActual.Puntaje + Puntaje));
            cmd.Parameters.Add(new SQLiteParameter("@cantidadJuegos", Program.usuarioActual.Juegos + 1));
            cmd.Parameters.Add(new SQLiteParameter("@cantidadAciertos", Program.usuarioActual.Aciertos + Acertadas));
            cmd.Parameters.Add(new SQLiteParameter("@id", Program.usuarioActual.Id));
            cmd.Connection = Conexion.Connection;
            cmd.ExecuteNonQuery();

            Program.usuarioActual.Puntaje += Puntaje;
            Program.usuarioActual.Juegos++;
            Program.usuarioActual.Aciertos += Acertadas;

            Puntaje = 0;
            Acertadas = 0;

            Console.WriteLine("\nToque una tecla para volver...");
            Console.ReadKey(true);

            Program.MenuPrincipal();
        }

        public static void verificarSeleccion(Pregunta pregunta)
        {
            int selector = Herramienta.IngresoEnteros();
            int seleccion = 0;
            bool error = true;

            while (error)
            {
                if (selector == 1)
                {
                    seleccion = pregunta.Opciones[0].Id;
                    error = false;
                }
                else if (selector == 2)
                {
                    seleccion = pregunta.Opciones[1].Id;
                    error = false;
                }
                else if (selector == 3)
                {
                    seleccion = pregunta.Opciones[2].Id;
                    error = false;
                }
                else if (selector == 4)
                {
                    seleccion = pregunta.Opciones[3].Id;
                    error = false;
                }
                else
                {
                    Console.Write("\nVuelve a intentarlo. Selecciona un numero del 1 al 4: ");
                    selector = Herramienta.IngresoEnteros();
                    Console.WriteLine();
                }
            }

            if (seleccion == pregunta.RespuestaCorrecta)
            {
                Console.WriteLine("\nRespuesta CORRECTA");
                Puntaje += pregunta.Dificultad.puntos;
                Acertadas++;
            }
            else
            {
                Console.WriteLine("\nRespuesta INCORRECTA");
            }
        }
    }
}
