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
<<<<<<< HEAD
        public static int Acertadas;
=======
        private static int rCorrectas = 0;
        private static int promedioCorrectas = 0;
>>>>>>> c8cffb5c5dcb1a2f07c664546dc3c8623ec7b841

        public nJuego(pPregunta preguntas, nUsuario usuario)
        {
            _preguntas = preguntas;
            _usuario = usuario;
        }

        public static void ComenzarJuego(List<Pregunta> preguntas)
        {
<<<<<<< HEAD
            Console.Clear();
=======
>>>>>>> c8cffb5c5dcb1a2f07c664546dc3c8623ec7b841
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
<<<<<<< HEAD

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
=======

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
>>>>>>> c8cffb5c5dcb1a2f07c664546dc3c8623ec7b841
        }

        public static void verificarSeleccion(Pregunta pregunta)
        {
            int selector = Herramienta.IngresoEnteros();
            int seleccion = 0;
            bool error = true;

            while (error)
            {
<<<<<<< HEAD
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
=======
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
>>>>>>> c8cffb5c5dcb1a2f07c664546dc3c8623ec7b841
            }
        }
        static void mensaje(int seleccion, Pregunta pregunta)
        {
            if (seleccion == pregunta.RespuestaCorrecta)
            {
<<<<<<< HEAD
                Console.WriteLine("\nRespuesta CORRECTA");
                Puntaje += pregunta.Dificultad.puntos;
                Acertadas++;
=======
                Console.WriteLine("Respuesta CORRECTA");
                Program.puntaje += pregunta.Dificultad.puntos;
                rCorrectas++;
>>>>>>> c8cffb5c5dcb1a2f07c664546dc3c8623ec7b841
            }
            else
            {
                Console.WriteLine("\nRespuesta INCORRECTA");
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
