using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;

namespace QuizTp3.Controladores.Autenticacion
{
    internal class AuthHelper
    {
        public static string Hashear(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool Verificar(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
