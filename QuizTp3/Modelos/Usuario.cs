using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizTp3.Modelos
{
    internal class Usuario
    {
        public int Id{ get; set; }
        public string Username { get; set; }
        public string Pwd { get; set; }
        public int Puntaje { get; set; }
        public int Promedio { get; set; }
        public int Juegos { get; set; }
        public int Aciertos { get; set; }

        public Usuario() { }

        public Usuario(int id, string username, string pwd, int puntaje, int promedio, int juegos, int aciertos)
        {
            Id = id;
            Username = username;
            Pwd = pwd;
            Puntaje = puntaje;
            Promedio = promedio;
            Juegos = juegos;
            Aciertos = aciertos;
        }
    }
}
