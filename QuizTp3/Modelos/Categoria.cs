using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizTp3.Modelos
{
    internal class Categoria
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public List<Pregunta> preguntas { get; set; }

        public Categoria()
        {
            preguntas = new List<Pregunta>();

        }

        public Categoria(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
            preguntas = new List<Pregunta>();
        }
    }
}
