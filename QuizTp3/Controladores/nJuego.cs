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
                Console.WriteLine($"Preguntas restantes: {preguntas.Count}");
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

                Console.ReadKey();
                i++;
            }
            Program.MenuPrincipal();
        }

        public static void verificarSeleccion(Pregunta pregunta)
        {
            string selector = Console.ReadLine();
            int seleccion = 0;

            if (selector == "1")
            {
                seleccion = pregunta.Opciones[0].Id;
            }
            else if (selector == "2")
            {
                seleccion = pregunta.Opciones[1].Id;
            }
            else if (selector == "3")
            {
                seleccion = pregunta.Opciones[2].Id;
            }
            else if (selector == "4")
            {
                seleccion = pregunta.Opciones[3].Id;
            }
            else
            {
                Console.WriteLine(" Vuelve a intentarlo. Selecciona un numero del 1 al 4... ");
                verificarSeleccion(pregunta);
            }

            if (seleccion == pregunta.RespuestaCorrecta)
            {
                Console.WriteLine("Respuesta CORRECTA");
            }
            else
            {
                Console.WriteLine("Respuesta INCORRECTA");
            }
        }
    }
}
