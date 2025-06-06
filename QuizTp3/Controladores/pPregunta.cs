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
    internal class pPregunta
    {
        public static void GetAll(Usuario usuario, List<Categoria> categorias, List<Dificultad> dificultades)
        {
            Console.Clear();
            categorias.Add(new Categoria(6, "Todas"));
            dificultades.Add(new Dificultad(4, 0, "Todas"));
            int categoriaId = Herramienta.MenuSeleccionar(categorias.Select(c => c.nombre).ToArray(), 0, "Categorias");
            int dificultadId = Herramienta.MenuSeleccionar(dificultades.Select(c => c.dificultad).ToArray(), 0, "Seleccionar dificultad de las preguntas");
            if (categoriaId == 6)
            {
                if (dificultadId == 4)
                {
                    SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM pregunta");
                    cmd.Connection = Conexion.Connection;
                    SQLiteDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Pregunta p = new Pregunta();
                        p.id = dr.GetInt32(0);
                        p.Enunciado = dr.GetString(1);
                        p.categoria = Program.categorias.FirstOrDefault(c => c.id == dr.GetInt32(2));
                        p.RespuestaCorrecta = dr.GetInt32(3);
                        p.Dificultad = Program.dificultades.FirstOrDefault(d => d.id == dr.GetInt32(4));
                        Program.preguntasActuales.Add(p);
                    }
                }
                else
                {
                    SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM pregunta WHERE dificultadId = @dificultadId");
                    cmd.Parameters.Add(new SQLiteParameter("@dificultadId", dificultadId));
                    cmd.Connection = Conexion.Connection;
                    SQLiteDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Pregunta p = new Pregunta();
                        p.id = dr.GetInt32(0);
                        p.Enunciado = dr.GetString(1);
                        p.categoria = Program.categorias.FirstOrDefault(c => c.id == dr.GetInt32(2));
                        p.RespuestaCorrecta = dr.GetInt32(3);
                        p.Dificultad = Program.dificultades.FirstOrDefault(d => d.id == dr.GetInt32(4));
                        Program.preguntasActuales.Add(p);
                    }
                }
            }
            else
            {
                if (dificultadId == 4)
                {
                    SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM pregunta WHERE categoriaId = @categoriaId");
                    cmd.Parameters.Add(new SQLiteParameter("@categoriaId", categoriaId));
                    cmd.Connection = Conexion.Connection;
                    SQLiteDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Pregunta p = new Pregunta();
                        p.id = dr.GetInt32(0);
                        p.Enunciado = dr.GetString(1);
                        p.categoria = Program.categorias.FirstOrDefault(c => c.id == dr.GetInt32(2));
                        p.RespuestaCorrecta = dr.GetInt32(3);
                        p.Dificultad = Program.dificultades.FirstOrDefault(d => d.id == dr.GetInt32(4));
                        Program.preguntasActuales.Add(p);
                    }
                }
                else
                {
                    SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM pregunta WHERE dificultadId = @dificultadId AND categoriaId = @categoriaId");
                    cmd.Parameters.Add(new SQLiteParameter("@categoriaId", categoriaId));
                    cmd.Parameters.Add(new SQLiteParameter("@dificultadId", dificultadId));
                    cmd.Connection = Conexion.Connection;
                    SQLiteDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Pregunta p = new Pregunta();
                        p.id = dr.GetInt32(0);
                        p.Enunciado = dr.GetString(1);
                        p.categoria = Program.categorias.FirstOrDefault(c => c.id == dr.GetInt32(2));
                        p.RespuestaCorrecta = dr.GetInt32(3);
                        p.Dificultad = Program.dificultades.FirstOrDefault(d => d.id == dr.GetInt32(4));
                        Program.preguntasActuales.Add(p);
                    }
                }
            }
            ElegirPreguntas(Program.preguntasActuales);
        }
        public static void ElegirPreguntas(List<Pregunta> preguntas)
        {
            Random random = new Random();
            List<Pregunta> topPreguntas = preguntas
                .OrderBy(x => random.Next())
                .Take(10)
                .ToList();
            Program.preguntasActuales = topPreguntas;
            nJuego.ComenzarJuego(Program.preguntasActuales);
        }
    }
}
