using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizTp3.Modelos
{
    internal class Dificultad
    {
        public int id {  get; set; }
        public int puntos {  get; set; }
        public string dificultad {  get; set; }

        public Dificultad()
        {
            
        }

        public Dificultad(int id, int puntos, string dificultad)
        {
            this.id = id;
            this.puntos = puntos;
            this.dificultad = dificultad;
        }
    }
}
