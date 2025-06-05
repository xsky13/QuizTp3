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
                Console.WriteLine($"Pregunta numero {i}: ");
                Console.WriteLine(preguntas[i].Enunciado);
                i++;

                preguntas[i].Opciones = pOpcion.GetbyId(preguntas[i].id);

                foreach (Opcion opcion in preguntas[i].Opciones)
                {
                    Console.WriteLine($"{opcion.NumeroOpcion}. {opcion.Texto}");
                }

                Console.WriteLine("fuap");
                preguntas.Remove(preguntas[i]);
            }


        }
    }
}
