using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Util
{
    public class Validacion
    {
        private const string EmailRegEx = ""; // TODO: Agregar RegEx para validación de emails.
        private const int LongitudMinimaContraseña = 6;

        public static bool ValidarEmail(string email)
        {
            return true; // Regex.IsMatch(email, EmailRegEx);
        }

        public static bool ValidarClave(string clave, string confirmarClave)
        {
            return string.Compare(clave, confirmarClave) == 0 &&
                clave.Length >= LongitudMinimaContraseña;
        }
    }
}
