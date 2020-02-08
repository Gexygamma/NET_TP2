using System;
using System.Collections.Generic;

namespace Util
{
    public class Validacion
    {
        private const int LongitudMinimaContraseña = 6;

        public static bool ValidarEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool ValidarClave(string clave, string confirmarClave)
        {
            return string.Compare(clave, confirmarClave) == 0 &&
                clave.Length >= LongitudMinimaContraseña;
        }
    }
}
