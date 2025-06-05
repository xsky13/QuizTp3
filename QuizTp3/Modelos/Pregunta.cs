using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizTp3.Modelos
{
    internal class Pregunta
    {
        public int id {  get; set; }
        public string Enunciado { get; set; }
        public List<Opcion> Opciones { get; set; }
        public int RespuestaCorrecta { get; set; }
        public Categoria categoria { get; set; }
        public Dificultad Dificultad { get; set; }
    }
}
